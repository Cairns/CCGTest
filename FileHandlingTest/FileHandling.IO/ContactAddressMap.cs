using CsvHelper.Configuration;
using FileHandling.BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileHandling.IO
{
    public class ContactAddressMap : ClassMap<ContactAddress>
    {
        public ContactAddressMap()
        {
            Map(m => m.Line1).Name("address_line1");
            Map(m => m.Line2).Name("address_line2");
        }
    }
}
