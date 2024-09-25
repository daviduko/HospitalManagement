using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement
{
    internal class Hospital
    {
        List<Person> people;

        public Hospital()
        {
            people = new List<Person>();
        }

        public void AddPerson(Person person)
        {
            if(!IsPersonOnTheList(person))
                people.Add(person);
            //else
            //    throw new Exception($"Person is already registered");
        }

        public void RemovePatient(Patient patient)
        {
            if (IsPersonOnTheList(patient))
            {
                people.Remove(patient);
                patient.Doctor.RemovePatient(patient);
            }
        }

        private bool IsPersonOnTheList(Person person)
        {
            foreach (Person p in people)
                if (p.Equals(person))
                    return true;

            return false;
        }

        public string DoctorsToString()
        {
            return AddPeopleToString<Doctor>("Doctors");
        }

        public List<T> GetListOf<T>() where T : Person
        {
            List<T> list = new List<T>();

            foreach (Person person in people)
                if (person.GetType() == typeof(T))
                    list.Add((T)person);

            return list;
        }

        public override string ToString()
        {
            string hospital = "";

            hospital += AddPeopleToString<Doctor>("Doctors");
            hospital += AddPeopleToString<Patient>("Patients");
            hospital += AddPeopleToString<Administrative>("Administratives");

            return hospital;
        }

        private string AddPeopleToString<T>(string groupName) where T : Person
        {
            string listedPeople = "";

            listedPeople += groupName + ":\n";

            foreach (T person in GetListOf<T>())
                listedPeople += "  - " + person.ToString() + "\n";

            return listedPeople;
        }
    }
}
