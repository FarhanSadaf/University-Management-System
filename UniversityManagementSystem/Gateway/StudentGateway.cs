using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityManagementSystem.Model;

namespace UniversityManagementSystem.Gateway
{
    class StudentGateway
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["UniversityDBConString"].ConnectionString;
        private SqlConnection connection;
        private SqlCommand command;
        private SqlDataReader reader;
        private string query;

        public StudentGateway()
        {
            connection = new SqlConnection(connectionString);
        }

        public int SaveStudent(Student student)
        {
            connection.Open();
            query = "INSERT INTO Student (name, roll, department_id, age, phone_no, email) VALUES(@name, @roll, @department_id, @age, @phone_no, @email)";
            command = new SqlCommand(query, connection);
            command.Parameters.Clear();
            command.Parameters.AddWithValue("name", student.Name);
            command.Parameters.AddWithValue("roll", student.RollNo);
            command.Parameters.AddWithValue("department_id", student.DepartmentId);
            command.Parameters.AddWithValue("age", student.Age);
            command.Parameters.AddWithValue("phone_no", student.PhoneNo);
            command.Parameters.AddWithValue("email", student.Email);

            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowAffected;
        }

        public bool DoesRollExist(string roll, int currentId)
        {
            query = "SELECT * FROM Student WHERE roll = @roll AND id<>@id";
            command = new SqlCommand();
            command.CommandText = query;
            command.Connection = connection;
            //Parameterized Query
            command.Parameters.Clear();
            command.Parameters.Add("roll", SqlDbType.NVarChar);
            command.Parameters["roll"].Value = roll;
            command.Parameters.Add("id", SqlDbType.Int);
            command.Parameters["id"].Value = currentId;

            connection.Open();
            reader = command.ExecuteReader();
            bool rollExist = reader.HasRows;
            reader.Close();
            connection.Close();
            return rollExist;
        }

        public List<StudentWithDept> GetAllStudents()
        {
            command = new SqlCommand();
            command.CommandText = "SELECT * FROM StudentWithDept";
            command.Connection = connection;
            connection.Open();
            reader = command.ExecuteReader();

            List<StudentWithDept> students = new List<StudentWithDept>();
            while (reader.Read())
            {
                StudentWithDept studentWithDept = new StudentWithDept();
                studentWithDept.SId = Convert.ToInt32(reader["s_id"]);
                studentWithDept.SName = reader["s_name"].ToString();
                studentWithDept.SRollNo = reader["s_roll"].ToString();
                studentWithDept.SAge = Convert.ToInt32(reader["s_age"]);
                studentWithDept.SPhoneNo = reader["s_phone_no"].ToString();
                studentWithDept.SEmail = reader["s_email"].ToString();
                studentWithDept.DId = (int)reader["d_id"];
                studentWithDept.DCode = reader["d_code"].ToString();
                studentWithDept.DName = reader["d_name"].ToString();

                students.Add(studentWithDept);
            }

            reader.Close();
            connection.Close();
            return students;
        }

        public List<StudentWithDept> GetStudentsByName(string name)
        {
            query = "SELECT * FROM StudentWithDept WHERE s_name LIKE '%"+name+"%'";
            command = new SqlCommand(query, connection);
            connection.Open();
            reader = command.ExecuteReader();

            List<StudentWithDept> students = new List<StudentWithDept>();
            while (reader.Read())
            {
                StudentWithDept studentWithDept = new StudentWithDept();
                studentWithDept.SId = Convert.ToInt32(reader["s_id"]);
                studentWithDept.SName = reader["s_name"].ToString();
                studentWithDept.SRollNo = reader["s_roll"].ToString();
                studentWithDept.SAge = Convert.ToInt32(reader["s_age"]);
                studentWithDept.SPhoneNo = reader["s_phone_no"].ToString();
                studentWithDept.SEmail = reader["s_email"].ToString();
                studentWithDept.DId = (int)reader["d_id"];
                studentWithDept.DCode = reader["d_code"].ToString();
                studentWithDept.DName = reader["d_name"].ToString();

                students.Add(studentWithDept);
            }

            reader.Close();
            connection.Close();
            return students;
        }

        public int UpdateStudent(Student student, int id)
        {
            query = "UPDATE Student SET name = '"+student.Name+"', roll = '"+student.RollNo+"', department_id = '"+student.DepartmentId+"', age = "+student.Age+", phone_no = '"+student.PhoneNo+"', email = '"+student.Email+"' WHERE id = "+id+"";
            command = new SqlCommand(query, connection);        
            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowAffected;
        }

        public int DeleteStudent(int id)
        {
            query = "DELETE FROM Student WHERE id = " + id + "";
            command = new SqlCommand(query, connection);
            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowAffected;
        }
    }
}
