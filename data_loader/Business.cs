using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace JsonDataImporter
{
    [DataContract]
    class Business
    {
        [DataMember]
        public string business_id { get; set; }

        [DataMember]
        public string full_address { get; set; }

        [DataMember]
        public bool open { get; set; }

        [DataMember]
        public string[] categories { get; set; }

        [DataMember]
        public string city { get; set; }

        [DataMember]
        public int review_count { get; set; }

        [DataMember]
        public string name { get; set; }

        [DataMember]
        public string state { get; set; }

        [DataMember]
        public decimal stars { get; set; }
    }
}
