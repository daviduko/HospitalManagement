using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement
{
    internal class Administrative : Person
    {
        public Administrative(string name) : base(name) { }

        public override string ToString()
        {
            return Name;
        }
    }
}
