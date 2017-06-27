package data_parser;

public class Span {
	private int start, end;
	private String label, childLabels;
	public Span(int start, int end, String label, String childLabels){
		this.start=start;
		this.end=end;
		this.label=label;
		this.childLabels=childLabels;
	}
	
	public int getStart() {
		return start;
	}
	public int getEnd() {
		return end;
	}
	public String getLabel() {
		return label;
	}
	public String getChildLabels() {
		return childLabels;
	}
	
	@Override
	public String toString(){
		return String.format("%s(%d,%d)->[%s] ", label, start, end, childLabels);
	}
}
