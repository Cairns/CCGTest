using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FileHandling.BO
{
    [DataContract]
    public class Contact
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public ContactAddress Address { get; set; }

        public override string ToString()
        {
            return $"{nameof(this.Name)} : {this.Name} \n{nameof(this.Address)}\n{this.Address.ToString()}";
        }
    }
}
