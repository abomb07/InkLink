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

                    /*
                    SqlParameter idParam = new SqlParameter("id", System.Data.SqlDbType.Int, 0);
                    SqlParameter emailParam = new SqlParameter("email", System.Data.SqlDbType.VarChar, 50);
                    SqlParameter nameParam = new SqlParameter("name", System.Data.SqlDbType.VarChar, 50);
                    SqlParameter dateTimeParam = new SqlParameter("dateTime", System.Data.SqlDbType.DateTime);
                    SqlParameter phoneNumberParam = new SqlParameter("phoneNumber", System.Data.SqlDbType.VarChar, 50);

                    idParam.Value = appointment.id;
                    emailParam.Value = appointment.email;
                    nameParam.Value = appointment.name;
                    dateTimeParam.Value = appointment.dateTime;
                    phoneNumberParam.Value = appointment.phoneNumber;

                    command.Parameters.Add(idParam);
                    command.Parameters.Add(emailParam);
                    command.Parameters.Add(nameParam);
                    command.Parameters.Add(dateTimeParam);
                    command.Parameters.Add(phoneNumberParam);
                    */

                    //call prepare and execute query.
                    //command.Prepare();
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
