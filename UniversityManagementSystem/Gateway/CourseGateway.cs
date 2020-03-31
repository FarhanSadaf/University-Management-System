using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityManagementSystem.Model;

namespace UniversityManagementSystem.Gateway
{
    class CourseGateway
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["UniversityDBConString"].ConnectionString;
        private SqlConnection connection;
        private SqlCommand command;
        private SqlDataReader reader;
        private string query;

        public CourseGateway()
        {
            connection = new SqlConnection(connectionString);
        }

        public List<Course> GetAllCourses()
        {
            query = "SELECT * FROM Course";
            command = new SqlCommand(query, connection);
            connection.Open();
            reader = command.ExecuteReader();

            List<Course> courses = new List<Course>();
            while (reader.Read())
            {
                Course course = new Course();
                course.Id = reader["id"].ToString();
                course.Credit = Convert.ToDouble(reader["credit"]);
                course.Name = reader["name"].ToString();

                courses.Add(course);
            }

            reader.Close();
            connection.Close();
            return courses;
        }
    }
}
