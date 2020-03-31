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
    class DepartmentGateway
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["UniversityDBConString"].ConnectionString;
        private SqlConnection connection;
        private SqlCommand command;
        private SqlDataReader reader;
        private string query;

        public DepartmentGateway()
        {
            connection = new SqlConnection(connectionString);
        }

        public List<Department> GetAllDepartments()
        {
            query = "SELECT * FROM Department";
            command = new SqlCommand(query, connection);
            connection.Open();
            reader = command.ExecuteReader();

            List<Department> departments = new List<Department>();
            while (reader.Read())
            {
                Department department = new Department();
                department.Id = (int)reader["id"];
                department.Code = reader["code"].ToString();
                department.Name = reader["name"].ToString();

                departments.Add(department);
            }

            reader.Close();
            connection.Close();
            return departments;
        }

    }
}
