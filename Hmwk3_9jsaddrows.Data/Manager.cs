using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Hmwk3_9jsaddrows.Data
{

    public class Manager
    {

        public string _connection;
        public Manager(string connect)
        {
            _connection = connect;
        }

        public List<Person> GetPpl()
        {

            using SqlConnection connect = new SqlConnection(_connection);
            using SqlCommand cmd = connect.CreateCommand();
            cmd.CommandText = @"select * from people";

            var result = new List<Person>();
            connect.Open();
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                result.Add(new Person
                {
                    Id = (int)reader["id"],
                    FirstName = (string)reader["FirstName"],
                    LastName = (string)reader["LastName"],
                    Age = (int)reader["Age"]


                });
            }
            return result;
        }
        public void Add(List<Person> people)
        {


            foreach (Person p in people)
            {

                using SqlConnection connect = new SqlConnection(_connection);
                using SqlCommand cmd = connect.CreateCommand();
                cmd.CommandText = @"insert into people(firstname, lastname, age)
                        values(@firstname, @lastname, @age)";
                cmd.Parameters.AddWithValue("@firstname", p.FirstName);
                cmd.Parameters.AddWithValue("@lastname", p.LastName);
                cmd.Parameters.AddWithValue("@age", p.Age);

                connect.Open();
                cmd.ExecuteNonQuery();
                connect.Close();
                connect.Dispose();
            }





        }

    }

}





public class Person
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
}
