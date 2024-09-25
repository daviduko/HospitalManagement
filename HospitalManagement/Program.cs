using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement
{
    enum eOption
    {
        Exit,
        RegisterDoctor,
        RegisterPatient,
        RegisterAdministrative,
        ListDoctors,
        ListDoctorsPatients,
        DeletePatient,
        HospitalPeople
    }
    internal class Program
    {
        static Hospital hospital;
        static void Main(string[] args)
        {
            hospital = new Hospital();
            Menu();
        }

        static void Menu()
        {
            eOption option;

            do
            {
                Console.WriteLine(@"
0. Exit
1. Register a doctor
2. Register a patient
3. Register an dministrative
4. List of doctors
5. List of the patients of a doctor
6. Delete a patient
7. People from hospital");
                
                option = (eOption)int.Parse(Console.ReadLine());

                switch(option)
                {
                    case eOption.Exit:
                        return;
                    case eOption.RegisterDoctor:
                        RegisterDoctor();
                        break;
                    case eOption.RegisterPatient:
                        RegisterPatient();
                        break;
                    case eOption.RegisterAdministrative:
                        break;
                    case eOption.ListDoctors:
                        break;
                    case eOption.ListDoctorsPatients:
                        break;
                    case eOption.DeletePatient:
                        break;
                    case eOption.HospitalPeople:
                        Console.WriteLine(hospital);
                        break;
                }

            } while (AskToContinue("Do you want to do something else?"));
        }

        static void RegisterDoctor()
        {
            Console.WriteLine("Type the doctor's name");
            Doctor doctor = new Doctor(Console.ReadLine());
            hospital.AddPerson(doctor);
        }

        static void RegisterPatient()
        {
            string name, doctorName;
            Console.WriteLine("Type the patient's name");
            name = Console.ReadLine();
            Console.WriteLine("Type the name of the doctor");
            doctorName = Console.ReadLine();

            foreach (Doctor d in hospital.GetListOf<Doctor>())
            {
                if (d.Name == doctorName)
                {
                    Patient p = new Patient(name, d);
                    hospital.AddPerson(p);
                    return;
                }
            }

            Doctor doctor = new Doctor(doctorName);
            hospital.AddPerson(doctor);

            Patient patient = new Patient(name, doctor);
            hospital.AddPerson(patient);
        }

        static bool AskToContinue(string question)
        {
            string answer;
            bool keep = true;
            do
            {
                Console.WriteLine($"{question} (y/n)");
                answer = Console.ReadLine();
            } while (answer != "y" && answer != "n");

            if (answer == "n")
                keep = false;

            return keep;
        }
    }


}
