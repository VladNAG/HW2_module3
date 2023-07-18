using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HW2_module3
{
    public class Contact : IContact, IComparable<Contact>
    {
        public Contact(string name, string pohe)
        {
            Neme = name;
            Pone = pohe;
        }

        public string Neme { get; set; }
        public string Pone { get; set; }

        public int CompareTo(Contact? other)
        {
            return Neme.CompareTo(other?.Neme);
        }
    }
}
