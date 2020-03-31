using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityManagementSystem.Gateway;
using UniversityManagementSystem.Model;

namespace UniversityManagementSystem.Manager
{
    class StudentManager
    {
        private StudentGateway studentGateway = new StudentGateway();
        
        public string SaveStudent(Student student)
        {
            if (studentGateway.DoesRollExist(student.RollNo, 0))
            {
                return "Roll No. already exists!";
            }
            int rowAffected = studentGateway.SaveStudent(student);
            if (rowAffected > 0)
            {
                return "Data inserted successfully.";
            }
            return "Insertion failed!";
        }

        public List<StudentWithDept> GetAllStudents()
        {
            return studentGateway.GetAllStudents();
        }

        public List<StudentWithDept> GetStudentsByName(string name)
        {
            return studentGateway.GetStudentsByName(name);
        }

        public string UpdateStudent(Student student, int id)
        {
            if (studentGateway.DoesRollExist(student.RollNo, id))
            {
                return "Roll No. already exists!";
            }
            int rowAffected = studentGateway.UpdateStudent(student, id);
            if (rowAffected > 0)
            {
                return "Data updated successfully.";
            }
            return "Update failed!";
        }

        public string DeleteStudent(int id)
        {
            int rowAffected = studentGateway.DeleteStudent(id);
            if (rowAffected > 0)
            {
                return "Data deleted successfully.";
            }
            return "Delete failed!";
        }

    }
}
