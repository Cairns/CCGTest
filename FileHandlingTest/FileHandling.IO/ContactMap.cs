using CsvHelper.Configuration;
using FileHandling.BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileHandling.IO
{
    public class ContactMap : ClassMap<Contact>
    {
        public ContactMap()
        {
            Map(m => m.Name);
            References<ContactAddressMap>(m => m.Address);
        }
    }
}
