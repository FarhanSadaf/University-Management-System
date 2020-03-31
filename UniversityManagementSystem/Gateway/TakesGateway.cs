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
    class TakesGateway
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["UniversityDBConString"].ConnectionString;
        private SqlConnection connection;
        private SqlCommand command;
        private SqlDataReader reader;
        private string query;

        public TakesGateway()
        {
            connection = new SqlConnection(connectionString);
        }

        public List<StudentTakesCourse> GetFromTakes()
        {
            query = "SELECT * FROM StudentTakesCourse";
            command = new SqlCommand(query, connection);
            connection.Open();
            reader = command.ExecuteReader();

            List<StudentTakesCourse> sTakes = new List<StudentTakesCourse>();
            while (reader.Read())
            {
                StudentTakesCourse takes = new StudentTakesCourse();
                takes.SName = reader["s_name"].ToString();
                takes.SRoll = reader["s_roll"].ToString();
                takes.CId = reader["c_id"].ToString();
                takes.CName = reader["c_name"].ToString();
                takes.CCredit = Convert.ToDouble(reader["c_credit"]);
                takes.EnrollDate = Convert.ToDateTime(reader["enroll_date"]);

                sTakes.Add(takes);
            }

            reader.Close();
            connection.Close();
            return sTakes;
        }

        public int SaveTakes(Takes takes)
        {
            query = "INSERT INTO Takes(student_id, course_id, enroll_date) VALUES(@student_id, @course_id, @enroll_date)";
            command = new SqlCommand(query, connection);
            command.Parameters.Clear();
            command.Parameters.AddWithValue("student_id", takes.StudentId);
            command.Parameters.AddWithValue("course_id", takes.CourseId);
            command.Parameters.AddWithValue("enroll_date", takes.EnrollDate);
            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowAffected;
        }
    }
}
