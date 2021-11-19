using System;
using System.Data.SqlClient;

namespace HelenaGrace.Models.Data
{
    public class CustomerDataService
    {
        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=HelenaGrace;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public bool addNewAppointment(Appointment appointment) 
        {
            //create and prepare sql statement.
            string query = "INSERT INTO dbo.[Appointments] (email,name,dateTime,phoneNumber) VALUES (@email,@name,@dateTime,@phoneNumber)";
            
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                
                //command.Parameters.Add("@Id", System.Data.SqlDbType.Int).Value = appointment.id;
                command.Parameters.Add("@email", System.Data.SqlDbType.VarChar, 50).Value = appointment.email;
                command.Parameters.Add("@name", System.Data.SqlDbType.VarChar, 50).Value = appointment.name;
                command.Parameters.Add("@dateTime", System.Data.SqlDbType.DateTime).Value = appointment.dateTime;
                command.Parameters.Add("@phoneNumber", System.Data.SqlDbType.VarChar, 50).Value = appointment.phoneNumber;

                Console.WriteLine(appointment.id.ToString(), appointment.name, appointment.dateTime, appointment.email, appointment.phoneNumber);
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return false;
                }
            }
            return true;
        }
    }
}
