package data_parser;

import java.util.*;
import edu.stanford.nlp.pipeline.*;
import edu.stanford.nlp.util.*;
import edu.stanford.nlp.ling.*;
import edu.stanford.nlp.trees.*;
import java.sql.*;

public class Document {
	private String doc_id, text;
	private List<List<Span>> sentence_spans;
	private List<String> sentence_texts, pos_texts, lemma_texts;

	public Document(String doc_id, String text) {
		this.doc_id = doc_id;
		this.text = text;
		sentence_spans = new ArrayList<List<Span>>();
		sentence_texts = new ArrayList<String>();
		pos_texts = new ArrayList<String>();
		lemma_texts = new ArrayList<String>();		
	}
	
	public void parse(StanfordCoreNLP pipeline) {
		// create an empty Annotation just with the given text
		Annotation document = new Annotation(text);

		// run all Annotators on this text
		pipeline.annotate(document);

		// these are all the sentences in this document
		// a CoreMap is essentially a Map that uses class objects as keys and
		// has values with custom types
		List<CoreMap> sentences = document.get(CoreAnnotations.SentencesAnnotation.class);

		for (CoreMap sentence : sentences) {			
			StringBuilder sentence_text=new StringBuilder();
			StringBuilder pos_text=new StringBuilder();
			StringBuilder lemma_text=new StringBuilder();
			List<Span> spans=new ArrayList<Span>();
			// traversing the words in the current sentence
			// a CoreLabel is a CoreMap with additional token-specific methods			
			for (CoreLabel token : sentence.get(CoreAnnotations.TokensAnnotation.class)) {
				// this is the text of the token
				String word = token.get(CoreAnnotations.TextAnnotation.class);
				if (sentence_text.length()==0)
					sentence_text.append(word);
				else
					sentence_text.append(" " + word); 
				
				// this is the POS tag of the token
				String pos = token.get(CoreAnnotations.PartOfSpeechAnnotation.class);
				if (pos_text.length()==0)
					pos_text.append(pos);
				else
					pos_text.append(" " + pos);	
				
				// this is the lemma of the token
				String lemma = token.get(CoreAnnotations.LemmaAnnotation.class);
				if (lemma_text.length()==0)
					lemma_text.append(lemma);
				else
					lemma_text.append(" " + lemma);
			}			

			sentence_texts.add(sentence_text.toString());
			pos_texts.add(pos_text.toString());
			lemma_texts.add(lemma_text.toString());			
			
			// this is the parse tree of the current sentence
			// it can cause out of memory when too many tokens			
			Tree tree = sentence.get(TreeCoreAnnotations.TreeAnnotation.class);
			tree.setSpans();
			getSpans(tree, spans);
            sentence_spans.add(spans);
		}
	}

	private void getSpans(Tree tree, List<Span> res) {
		if (tree == null || tree.isLeaf() || tree.firstChild().isLeaf())
			return;
		String childLabels = null;
		for (Tree child : tree.getChildrenAsList()) {
			if (childLabels == null)
				childLabels = child.value();
			else
				childLabels += " " + child.value();
			getSpans(child, res);
		}
		Span span = new Span(tree.getSpan().getSource(), tree.getSpan().getTarget(), tree.value(), childLabels);
		res.add(span);
	}
	
	public void submitChanges(PreparedStatement pstmt_sentence, PreparedStatement pstmt_span){
		for(int i=0; i<sentence_texts.size(); i++){
			try{				
				pstmt_sentence.setNString(1, doc_id);
				pstmt_sentence.setInt(2, i+1);
				pstmt_sentence.setNString(3, sentence_texts.get(i));
				pstmt_sentence.setNString(4, pos_texts.get(i));
				pstmt_sentence.setNString(5, lemma_texts.get(i));
				pstmt_sentence.execute();				
				for(int j=0; j<sentence_spans.get(i).size(); j++){
					Span span=sentence_spans.get(i).get(j);
					pstmt_span.setNString(1, doc_id);
					pstmt_span.setInt(2, i+1);
					pstmt_span.setInt(3, j+1);
					pstmt_span.setInt(4, span.getStart());
					pstmt_span.setInt(5, span.getEnd());
					pstmt_span.setNString(6, span.getLabel());
					pstmt_span.setNString(7, span.getChildLabels());
					pstmt_span.execute();					
				}				
			}catch(Exception e){
				e.printStackTrace();
			}
		}
	}

	public static void main(String[] args) {
		Properties props = new Properties();
		props.setProperty("annotators", "tokenize, ssplit, pos, lemma, parse");
		props.setProperty("parse.maxlen", "100");
		StanfordCoreNLP pipeline = new StanfordCoreNLP(props);
						
		String connectionURL= "jdbc:sqlserver://localhost;" +
				"databaseName=yelp;integratedSecurity=true;";
		Connection conn=null;
		Statement stmt=null;
		PreparedStatement pstmt_sentence=null;
		PreparedStatement pstmt_span=null;
		ResultSet rs=null;
		try{
			Class.forName("com.microsoft.sqlserver.jdbc.SQLServerDriver");
			conn=DriverManager.getConnection(connectionURL);
			String sql="SELECT [review_id], [text] FROM review";
			stmt=conn.createStatement();
			rs = stmt.executeQuery(sql);
			String insert_sql_sentence="INSERT INTO review_sentence([review_id]" +
					",[sentence_id]"+
					",[sentence_text]"+
					",[sentence_pos]"+
					",[sentence_lemma])" +
					" VALUES(?,?,?,?,?)";
			pstmt_sentence=conn.prepareStatement(insert_sql_sentence);			
			String insert_sql_span="INSERT INTO [review_sentence_span]"+
					"([review_id]"+
			        ",[sentence_id]"+
			        ",[span_id]"+
			        ",[start]"+
			        ",[end]"+
			        ",[span_label]"+
			        ",[children])"+
			        " VALUES(?,?,?,?,?,?,?)";
			pstmt_span=conn.prepareStatement(insert_sql_span);
			int counter=0;
			while (rs.next()){
				Document d=new Document(rs.getNString(1), rs.getNString(2));
				d.parse(pipeline);				
				d.submitChanges(pstmt_sentence, pstmt_span);
				counter++;
				if (counter%100==0){
					System.out.println(String.format("%d reivews processed", counter));					
				}
			}
			
		}catch(Exception e){
			e.printStackTrace();
		}finally{
			if (rs!=null) {try{ rs.close(); } catch(Exception e){}}
			if (stmt!=null) {try{ stmt.close(); } catch(Exception e){}}
			if (pstmt_sentence!=null) {try{ pstmt_sentence.close(); } catch(Exception e){}}
			if (pstmt_span!=null) {try{ pstmt_span.close(); } catch(Exception e){}}
			if (conn!=null) {try{ conn.close(); } catch(Exception e){}}
		}		
	}
}
