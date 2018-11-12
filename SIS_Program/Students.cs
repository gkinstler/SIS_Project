using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace SIS_Program
{
    public class Students
    {
        public static string ConnectionString { get; set; }
        public int StudentId { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public List<Students> GetAllStudents()
        {
            MySqlConnection conn = new MySqlConnection(ConnectionString);

            List<Students> students = new List<Students>();

            using (conn)
            {
                conn.Open();

                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM students;";

                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    Students student = new Students()
                    {
                        StudentId = (int)dataReader["StudentID"],
                        FirstName = dataReader["firstname"].ToString(),
                        LastName = dataReader["lastname"].ToString(),
                    };

                    students.Add(student);
                }

                return students;
            }
        }
    }
}
