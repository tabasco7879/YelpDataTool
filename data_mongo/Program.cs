using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using MongoDB.Bson;
using MongoDB.Bson.IO;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

namespace FeatureBuilder
{
    class Program
    {
        static void Main(string[] args)
        {           
            buildTokenTable();
            buildVocab();
            exportToMongoDB();
            exportSentenceToMongoDB();
            exportRatingToMongoDB();
        }

        static void exportRatingToMongoDB()
        {
            var client = new MongoClient();
            var ratingCollection =
                client.GetDatabase("yelp").GetCollection<BsonDocument>("rating");
            using (var reviewDB = new ReviewDBDataContext())
            {
                var query = from review in reviewDB.reviews
                            select new
                            {
                                doc_id = review.review_id,
                                rating = review.stars
                            };
                foreach (var r in query)
                {
                    var doc = new BsonDocument
                    {
                        {"doc_id", r.doc_id },
                        {"rating", Convert.ToInt32(r.rating) },
                    };
                    ratingCollection.InsertOne(doc);
                }
            }
        }

        static void exportSentenceToMongoDB()
        {
            var client = new MongoClient();
            var sentDataCollection =
                client.GetDatabase("yelp").GetCollection<BsonDocument>("sent_text");

            using (var reviewDB = new ReviewDBDataContext())
            {
                var query = from review_sentence in reviewDB.review_sentences
                            join train_set in reviewDB.train_sets on review_sentence.review_id equals train_set.review_id
                            orderby review_sentence.review_id, review_sentence.sentence_id
                            select new
                            {
                                doc_id = review_sentence.review_id,
                                sent_id = review_sentence.sentence_id,
                                sent_text = review_sentence.sentence_text,
                                sent_pos = review_sentence.sentence_pos,
                                sent_lemma = review_sentence.sentence_lemma
                            };
                foreach (var q in query)
                {
                    var doc = new BsonDocument
                    {
                        {"doc_id", q.doc_id},
                        {"sent_id", q.sent_id},
                        {"sent_text", q.sent_text},
                        {"sent_pos", q.sent_pos},
                        {"sent_lemma", q.sent_lemma},
                    };
                    sentDataCollection.InsertOne(doc);
                }
            }
        }

        static void exportToMongoDB(int vocab_size_threshold = 10000, int non_vocab_id = 100000)
        {
            var client = new MongoClient();
            var sentDataCollection =
                client.GetDatabase("yelp").GetCollection<BsonDocument>("sent_data2");

            using (var reviewDB = new ReviewDBDataContext())
            {
                var q_vocab = from v in reviewDB.vocab_news
                              join t in reviewDB.tokens on v.token_id equals t.token_id
                              select new
                              {
                                  vocab_id = v.vocab_id,
                                  token_str = t.token_str
                              };
                Dictionary<string, int> vocab = new Dictionary<string, int>();
                foreach (var v in q_vocab)
                {
                    vocab.Add(v.token_str, v.vocab_id);
                }

                var query = from review_sentence in reviewDB.review_sentences
                            join train_set in reviewDB.train_sets on review_sentence.review_id equals train_set.review_id
                            orderby review_sentence.review_id, review_sentence.sentence_id
                            select new
                            {
                                doc_id = review_sentence.review_id,
                                sent_id = review_sentence.sentence_id,
                                sentence_lemma = review_sentence.sentence_lemma
                            };
                foreach (var sent in query)
                {
                    string[] lemmas = sent.sentence_lemma.Split(' ');
                    int[] vs = new int[lemmas.Length];
                    for (int i = 0; i < vs.Length; i++)
                    {
                        int vid;
                        if (vocab.TryGetValue(lemmas[i], out vid))
                            vs[i] = vid;
                        else
                            vs[i] = non_vocab_id;
                    }
                    var doc = new BsonDocument
                    {
                        {"doc_id", sent.doc_id},
                        {"sent_id", sent.sent_id},
                        {"sent_data", new BsonArray(vs)}
                    };
                    sentDataCollection.InsertOne(doc);
                }
            }
        }

        static void buildVocab(int token_freq_threshold = 20, int token_doc_freq_threshold = 10)
        {
            HashSet<string> stopwords = new HashSet<string>();
            using (var reader = new StreamReader(new FileStream("stopwords.txt", FileMode.Open)))
            {
                string l;
                while ((l = reader.ReadLine()) != null)
                {
                    stopwords.Add(l);
                }
            }
            using (var reviewDB = new ReviewDBDataContext())
            {
                int total_reviews = reviewDB.train_sets.Count();
                var query = from token in reviewDB.tokens
                            where token.token_freq >= token_freq_threshold
                                    && token.token_doc_freq >= token_doc_freq_threshold
                                    && token.token_doc_freq < total_reviews / 5
                            orderby token.token_score descending
                            select new
                            {
                                token_str = token.token_str,
                                token_id = token.token_id
                            };
                int vocab_id = 0;
                foreach (var token in query)
                {
                    if (char.IsLetter(token.token_str[0]) && !stopwords.Contains(token.token_str))
                    {
                        vocab_new v = new vocab_new();
                        v.token_id = token.token_id;
                        v.vocab_id = vocab_id;
                        vocab_id++;
                        reviewDB.vocab_news.InsertOnSubmit(v);
                    }
                }
                reviewDB.SubmitChanges();
            }
        }

        static void buildTokenTable()
        {
            using (var reviewDB = new ReviewDBDataContext())
            {
                var query = from review_sentence in reviewDB.review_sentences
                            join train_set in reviewDB.train_sets on review_sentence.review_id equals train_set.review_id
                            orderby review_sentence.review_id, review_sentence.sentence_id
                            select new
                            {
                                review_id = review_sentence.review_id,
                                sentence_id = review_sentence.sentence_id,
                                sentence_lemma = review_sentence.sentence_lemma,
                                sentence_pos = review_sentence.sentence_pos
                            };
                int token_id = 0;
                Dictionary<string, token> token_dict = new Dictionary<string, token>();
                Dictionary<string, Dictionary<string, int>> token_pos = new Dictionary<string, Dictionary<string, int>>();
                string last_review_id = null;
                int review_count = 0;
                HashSet<string> tokens_in_review = new HashSet<string>();
                // collect token and pos
                foreach (var sentence in query)
                {
                    if (last_review_id != sentence.review_id)
                        tokens_in_review.Clear();
                    string[] lemmas = sentence.sentence_lemma.Split(' ');
                    string[] pos = sentence.sentence_pos.Split(' ');
                    for (int i = 0; i < lemmas.Length; i++)
                    {
                        token t = null;
                        string lemma = lemmas[i].ToLowerInvariant();
                        if (!token_dict.TryGetValue(lemma, out t))
                        {
                            t = new token();
                            t.token_id = token_id;
                            token_id += 1;
                            t.token_str = lemma;
                            t.token_freq = 1;
                            t.token_doc_freq = 1;
                            tokens_in_review.Add(lemma);
                            token_dict.Add(t.token_str, t);
                            // process pos
                            var d = new Dictionary<string, int>();
                            token_pos.Add(lemma, d);
                            d.Add(pos[i], 1);
                        }
                        else
                        {
                            t.token_freq += 1;
                            if (!tokens_in_review.Contains(lemma))
                            {
                                t.token_doc_freq += 1;
                                tokens_in_review.Add(lemma);
                            }
                            // process pos
                            if (!token_pos[lemma].ContainsKey(pos[i]))
                                token_pos[lemma].Add(pos[i], 1);
                            else
                                token_pos[lemma][pos[i]] += 1;
                        }
                    }
                    if (last_review_id != sentence.review_id)
                        review_count += 1;
                    last_review_id = sentence.review_id;
                }

                foreach (var t in token_dict.Values)
                {
                    int top3 = 0;
                    string pos_str = null;
                    foreach (KeyValuePair<string, int> kvp in token_pos[t.token_str].OrderByDescending(kvp => kvp.Value))
                    {
                        if (top3 == 0)
                            pos_str = kvp.Key;
                        else if (top3 == 3)
                            break;
                        else
                            pos_str += " " + kvp.Key;
                        top3 += 1;
                    }
                    t.token_pos = pos_str;
                    reviewDB.tokens.InsertOnSubmit(t);
                }

                reviewDB.SubmitChanges();
            }
        }
    }
}
