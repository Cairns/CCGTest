using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FileHandling.BO
{
    [DataContract]
    public class ContactAddress
    {
        [DataMember]
        public string Line1 { get; set; }
        [DataMember]
        public string Line2 { get; set; }

        public override string ToString()
        {
            return $"{nameof(Line1)} : {this.Line1} \n{nameof(this.Line2)} : {this.Line2}";
        }
    }
}
