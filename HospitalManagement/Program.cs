using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Hospital hospital = new Hospital();

            Doctor doctor1 = new Doctor("Maria");
            Doctor doctor2 = new Doctor("Jordi");
            Doctor doctor3 = new Doctor("Laura");

            Patient patient1 = new Patient("Juan");
            Patient patient2 = new Patient("Pepe", doctor1);
            Patient patient3 = new Patient("Pol");

            Administrative admin1 = new Administrative("Pepa");
            Administrative admin2 = new Administrative("Juana");
            Administrative admin3 = new Administrative("Evaristo");

            hospital.AddPerson(patient1);
            hospital.AddPerson(patient2);
            hospital.AddPerson(patient3);
            hospital.AddPerson(doctor1);
            hospital.AddPerson(doctor2);
            hospital.AddPerson(doctor3);
            hospital.AddPerson(admin1);
            hospital.AddPerson(admin2);
            hospital.AddPerson(admin3);

            Console.WriteLine(hospital);
            Console.ReadLine();
        }
    }
}
