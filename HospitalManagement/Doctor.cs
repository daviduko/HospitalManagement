using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement
{
    internal class Doctor : Person
    {
        string specialty;
        List<Patient> patients;

        public List<Patient> Patients { get { return patients; } }

        public Doctor(string name) : base(name)
        {
            patients = new List<Patient>();
        }

        public Doctor(string name, string specialty) : this(name)
        {
            this.specialty = specialty;
        }

        public void AddPatient(Patient patient)
        {
            if(!IsPatientIsOnTheList(patient))
                patients.Add(patient);
            else
                throw new Exception($"Patient is already on the {this} list");
        }

        public void RemovePatient(Patient patient)
        {
            if (IsPatientIsOnTheList(patient))
                patients.Remove(patient);
            else
                throw new Exception($"Patient is not on the {this} list");
        }

        private bool IsPatientIsOnTheList(Patient patient)
        {
            foreach (Patient pat in patients)
                if(pat == patient)
                    return true;

            return false;
        }

        public override string ToString()
        {
            string doctor = $"Dr.{Name}:\n\tSpecialty: {specialty}\n";
            doctor += "\t" + base.ToString();

            return doctor;
        }
    }
}
