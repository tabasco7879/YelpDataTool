using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace JsonDataImporter
{
    [DataContract]
    class Review
    {
        [DataMember]
        public ReviewVote votes { get; set; }

        [DataMember]
        public string user_id { get; set; }

        [DataMember]
        public string review_id { get; set; }

        [DataMember]
        public decimal stars { get; set; }

        [DataMember]
        public string date { get; set; }

        [DataMember]
        public string text { get; set; }

        [DataMember]
        public string type { get; set; }

        [DataMember]
        public string business_id { get; set; }
    }
}
