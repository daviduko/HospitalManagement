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
        public DateTime BirthDate { get; protected set; }

        public Person(string name)
        {
            Name = name;
        }

        public Person(string name, DateTime birthDate) : this(name) 
        {
            BirthDate = birthDate;
        }

        public abstract override string ToString();
    }
}
