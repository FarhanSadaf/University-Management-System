using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityManagementSystem.Gateway;
using UniversityManagementSystem.Model;

namespace UniversityManagementSystem.Manager
{
    class CourseManager
    {
        private CourseGateway courseGateway = new CourseGateway();

        public List<Course> GetAllCourses()
        {
            return courseGateway.GetAllCourses();
        }
    }
}
