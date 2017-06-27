using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;

namespace JsonDataImporter
{
    class Program
    {
        static void Main(string[] args)
        {
            

        }

        static void LoadReview(string reviewDataFile)
        {
            StreamReader reader = new StreamReader(new FileStream(@"C:\Users\tao.chen\Baiduyun\Yelp\yelp_dataset_challenge_academic_dataset\yelp_academic_dataset_review.json", FileMode.Open));
            DataContractJsonSerializer d = new DataContractJsonSerializer(typeof(Review), new Type[] { typeof(ReviewVote) }.AsEnumerable());
            ReviewDataContext context = new ReviewDataContext();
            string l = null;
            int counter = 0;
            while ((l = reader.ReadLine()) != null)
            {
                MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(l));
                Review r = (Review)d.ReadObject(stream);
                review r1 = new review();
                r1.review_id = r.review_id;
                r1.user_id = r.user_id;
                r1.business_id = r.business_id;
                r1.text = r.text;
                r1.stars = r.stars;
                r1.date = DateTime.Parse(r.date);
                r1.type = r.type;
                context.reviews.InsertOnSubmit(r1);
                review_vote rv = new review_vote();
                rv.cool = r.votes.cool;
                rv.funny = r.votes.funny;
                rv.useful = r.votes.useful;
                rv.review_id = r.review_id;
                context.review_votes.InsertOnSubmit(rv);

                counter++;
                if (counter % 1000 == 0)
                {
                    Console.WriteLine("counter {0}", counter);
                    context.SubmitChanges();
                    context = new ReviewDataContext();
                }
            }
            context.SubmitChanges();
        }

        static void LoadBusiness(string businessDataFile)
        {
            StreamReader reader = new StreamReader(new FileStream(businessDataFile, FileMode.Open));
            DataContractJsonSerializer d = new DataContractJsonSerializer(typeof(Business));
            string l = null;
            BusinessDataContext context = new BusinessDataContext();
            int counter = 0;
            while ((l = reader.ReadLine()) != null)
            {
                MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(l));
                Business b = (Business)d.ReadObject(stream);
                business b1 = new business();
                b1.business_id = b.business_id;
                b1.full_address = b.full_address;
                b1.open = b.open;
                b1.city = b.city;
                b1.review_count = b.review_count;
                b1.stars = b.stars;
                b1.state = b.state;
                b1.name = b.name;
                foreach (string category in b.categories)
                {
                    business_category bc = new business_category();
                    bc.business_id = b.business_id;
                    bc.category = category;
                    context.business_categories.InsertOnSubmit(bc);
                }
                context.businesses.InsertOnSubmit(b1);
                counter += 1;
                if (counter % 1000 == 0)
                    Console.WriteLine("counter {0}", counter);
            }
            context.SubmitChanges();
        }
    }
}
