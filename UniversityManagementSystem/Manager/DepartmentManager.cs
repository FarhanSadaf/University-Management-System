using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityManagementSystem.Gateway;
using UniversityManagementSystem.Model;

namespace UniversityManagementSystem.Manager
{
    class DepartmentManager
    {
        private DepartmentGateway departmentGateway = new DepartmentGateway();

        public List<Department> GetAllDepartments()
        {
            return departmentGateway.GetAllDepartments();
        }
    }
}
