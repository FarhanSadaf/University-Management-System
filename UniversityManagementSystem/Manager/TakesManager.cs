using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityManagementSystem.Gateway;
using UniversityManagementSystem.Model;

namespace UniversityManagementSystem.Manager
{
    class TakesManager
    {
        private TakesGateway takesGateway = new TakesGateway();

        public List<StudentTakesCourse> GetFromTakes()
        {
            return takesGateway.GetFromTakes();
        }

        public string SaveTakes(Takes takes)
        {
            /*if (studentGateway.DoesRollExist(student.RollNo, 0))
            {
                return "Roll No. already exists!";
            }*/
            int rowAffected = takesGateway.SaveTakes(takes);
            if (rowAffected > 0)
            {
                return "Data inserted successfully.";
            }
            return "Insertion failed!";
        }
    }
}
