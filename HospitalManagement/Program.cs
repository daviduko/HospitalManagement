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
        EditInfo,
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
                Console.Clear();

                Console.WriteLine(@"
0. Exit
1. Register a doctor
2. Register a patient
3. Register an dministrative
4. List of doctors
5. List of the patients of a doctor
6. Delete a patient
7. Edit data of a person of the hospital
8. People from hospital");
                
                option = (eOption)int.Parse(Console.ReadLine());

                Console.Clear();

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
                        RegisterAdministrative();
                        break;
                    case eOption.ListDoctors:
                        Console.WriteLine(hospital.DoctorsToString());
                        break;
                    case eOption.ListDoctorsPatients:
                        ShowDoctorsPatients();
                        break;
                    case eOption.DeletePatient:
                        RemovePatient();
                        break;
                    case eOption.EditInfo:
                        MenuEdit();
                        break;
                    case eOption.HospitalPeople:
                        Console.WriteLine(hospital);
                        break;
                }

            } while (AskIf("Do you want to do something else?"));
        }

        static void RegisterDoctor()
        {
            string name, specialty;
            Console.WriteLine("Type the doctor's name");
            name = Console.ReadLine();

            Console.WriteLine($"Type the specialty of Dr.{name}");
            specialty = Console.ReadLine();
            Doctor doctor = new Doctor(name, specialty);

            hospital.AddPerson(doctor);
        }

        static void RegisterPatient()
        {
            string name, doctorName;
            Console.WriteLine("Type the patient's name");
            name = Console.ReadLine();
            Console.WriteLine("Type the name of the doctor");
            doctorName = Console.ReadLine();

            Doctor doctor = hospital.GetListOf<Doctor>().Find(d => d.Name == doctorName);

            if(doctor == null)
                doctor = new Doctor(doctorName);

            hospital.AddPerson(doctor);
            
            Patient patient = new Patient(name, doctor);
            hospital.AddPerson(patient);
        }

        static void RegisterAdministrative()
        {
            string name;
            int option;
            eDepartment department;
            Console.WriteLine("Type the administrative's name");
            name = Console.ReadLine();

            do
            {
                Console.WriteLine($@"Select the department of {name}
1. Finance
2. Public relations
3. HR department
4. Emergency Medicine");
            } while (!int.TryParse(Console.ReadLine(), out option) || option > 4 || option < 1);

            department = (eDepartment)option;

            Administrative admin = new Administrative(name, department);
            hospital.AddPerson(admin);
        }

        static void ShowDoctorsPatients()
        {
            Console.WriteLine("Type the name of the doctor");
            string name = Console.ReadLine();

            Doctor doctor = hospital.GetListOf<Doctor>().Find(d => d.Name == name);

            if(doctor != null)
            {
                string patients = $"\nDr {name} patients:\n";

                foreach(Patient p in doctor.Patients) 
                    patients += "  - " + p.Name + "\n";

                Console.WriteLine(patients);
            }
            else
            {
                Console.WriteLine("There's no doctor with that name");
            }
            
        }

        static void RemovePatient()
        {
            Console.WriteLine("Type the name of the patient you want to remove");
            Patient patient = hospital.GetListOf<Patient>().Find(p => p.Name == Console.ReadLine());

            if(patient != null)
            {
                hospital.RemovePatient(patient);
            }
            else
                Console.WriteLine("There's no patient with that name");
        }

        static void MenuEdit()
        {
            int option;

            do
            {
                Console.WriteLine(@"Which type of person do you want to edit?
1. Doctor
2. Patient
3. Administrative");
            } while (int.TryParse(Console.ReadLine(), out option) || option < 1 || option > 3);

            List<Person> list;

            switch (option)
            {
                case 1:
                    list = hospital.GetListOf<Doctor>();
                    break;
                case 2:
                    break;
                case 3:
                    break;
            }

             
        }

        static bool AskIf(string question)
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
