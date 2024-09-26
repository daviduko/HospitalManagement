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
        private int socialSecurityNumber;
        private string disease;
        private Doctor doctor;

        public Doctor Doctor 
        {
            get { return doctor; }
            set
            {
                doctor = value;
                doctor.AddPatient(this);
            } 
        }

        public Patient(string name) : base(name) { }

        public Patient(string name, Doctor doctor) : this(name)
        {
            Doctor = doctor;
        }

        public override string ToString()
        {
            string patient = $"{Name}:\n\t{base.ToString()}\n\tDisease: {disease}";

            if (socialSecurityNumber != 0)
                patient += $"\n\tSocialSecurityNumber: {socialSecurityNumber}";

            return patient;
        }
    }
}
