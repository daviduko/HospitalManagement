using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement
{
    public enum eDepartment
    {
        Finance = 1,
        PublicRelations,
        HRDepartment,
        EmergencyMedicine
    }

    internal class Administrative : Person
    {
        private eDepartment department;

        public eDepartment Department {  get { return department; } }
        public Administrative(string name, eDepartment dp) : base(name)
        {
            department = dp;
        }

        public override string ToString()
        {
            return $"{Name}:\n\t{base.ToString()}\n\tDepartment: {department.ToString()}";
        }
    }
}
