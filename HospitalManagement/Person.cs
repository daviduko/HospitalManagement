using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement
{
    internal abstract class Person
    {
        public string Name { get; protected set; }
        public int PhoneNumber { get; set; }

        public Person(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            if (PhoneNumber != 0)
                return $"Tf: {PhoneNumber}";
            else
                return $"Tf:";
        }
    }
}
