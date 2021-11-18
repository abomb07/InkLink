using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace HelenaGrace.Models.Data
{
    public class UserDataService
    {
        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=HelenaGrace;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public bool findUserByEmailAndPassword(User user)
        {
            bool success = false;

            string sqlStatement = "SELECT * FROM dbo.[USER] WHERE EMAIL = @email and PASSWORD = @password";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);

                command.Parameters.Add("@email", System.Data.SqlDbType.VarChar, 40).Value = user.Email;
                command.Parameters.Add("@password", System.Data.SqlDbType.VarChar, 40).Value = user.Password;

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                        reader.Read();
                        user.FirstName = (string)reader["FIRST_NAME"];
                        user.LastName = (string)reader["LAST_NAME"];
                        user.Email = (string)reader["EMAIL"];
                        user.PhoneNumber = (string)reader["PHONE_NUMBER"];
                        user.Bio = (string)reader["BIO"];
                        success = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return success;
        }
    }
}
