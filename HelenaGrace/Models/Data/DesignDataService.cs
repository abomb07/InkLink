using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace HelenaGrace.Models.Data
{
    public class DesignDataService
    {
        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=HelenaGrace;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public List<Design> GetAll()
        {
            List<Design> allDesigns = new List<Design>();

            string sqlStatement = "SELECT * FROM dbo.[DESIGN]";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Design d1 = new Design();
                        d1.Id = (int)reader["ID"];
                        d1.Description = (string)reader["DESCRIPTION"];
                        d1.Path = (string)reader["PICTURE"];
                        d1.DateTime = (DateTime)reader["DATETIME"];
                        allDesigns.Add(d1);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
            return allDesigns;
        }

        public bool Insert(Design design)
        {
            bool success = false;
            string sqlStatement = "INSERT INTO dbo.[DESIGN] (DESCRIPTION, PICTURE, DATETIME) VALUES (@description, @picture, @datetime)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);

                command.Parameters.Add("@description", System.Data.SqlDbType.NText).Value = design.Description;
                command.Parameters.Add("@picture", System.Data.SqlDbType.VarChar, 256).Value = design.Path;
                command.Parameters.Add("@datetime", System.Data.SqlDbType.DateTime).Value = design.DateTime;
                try
                {
                    connection.Open();
                    if (command.ExecuteNonQuery() > 0)
                        success = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
            return success;
        }
    }
}
