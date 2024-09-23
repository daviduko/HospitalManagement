using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement
{
    internal class Patient : Person
    {
        public Doctor Doctor { get; set; }

        public Patient(string name) : base(name) { }

        public Patient(string name, Doctor doctor) : this(name)
        {
            Doctor = doctor;
        }

        public override string ToString()
        {
            string extra = Doctor == null ? "" : $", {Doctor}";
            return $"{Name}{extra}";
        }
    }
}
