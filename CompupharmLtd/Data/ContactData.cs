using CompupharmLtd.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace CompupharmLtd.Data
{
    public class ContactData
    {
        

            public static string  Create(ContactRequest contact)
            {
            string result = "01";
            var res = new Contact();
            //   List<Product> result = new List<Product>();


            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

            builder.DataSource = "polling.database.windows.net";
            builder.UserID = "pollingAdmin";
            builder.Password = "pollAdmin$";
            builder.InitialCatalog = "CompupharmLtd";

            SqlConnection connection = new SqlConnection(builder.ConnectionString);

            Console.WriteLine("\nQuery data example:");
            Console.WriteLine("=========================================\n");

            connection.Open();
            try
            {
                Guid id = Guid.NewGuid();
                DateTime date = DateTime.Now;

                using (SqlCommand command = new SqlCommand($"INSERT INTO [dbo].[Contact] (ContactID,SenderName,Message,SenderEmail,Sender_PhoneNumber,Date_Recieved,Date_Updated)VALUES(@ContactID,@SenderName,@Message, @SenderEmail,@Sender_PhoneNumber,@Date_Recieved,@Date_Updated)", connection))
                {
                    command.Parameters.AddWithValue("@SenderEmail", contact.Email);
                    command.Parameters.AddWithValue("@ContactID", id);
                    command.Parameters.AddWithValue("@SenderName", contact.Name);
                    command.Parameters.AddWithValue("@Message", contact.Message);
                    command.Parameters.AddWithValue("@Sender_PhoneNumber", contact.PhoneNumber);
                    command.Parameters.Add("@Date_Recieved", SqlDbType.DateTime).Value = date;
                    command.Parameters.Add("@Date_Updated", SqlDbType.DateTime).Value = date;


                    var re = command.ExecuteNonQuery();

                    if (re == 1)
                    {
                        result = id.ToString();
                    }


                }


            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {
                if (connection.State != ConnectionState.Closed)
                {
                    connection.Close();

                }
            }

            //Console.WriteLine("\nDone. Press enter.");
            //Console.ReadLine();



            return result;
        }

        internal static string EditContactMessage(Contact editInfo)
        {

            string result = "01";
            var res = new Contact();
            //   List<Product> result = new List<Product>();


            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

            builder.DataSource = "polling.database.windows.net";
            builder.UserID = "pollingAdmin";
            builder.Password = "pollAdmin$";
            builder.InitialCatalog = "CompupharmLtd";

            SqlConnection connection = new SqlConnection(builder.ConnectionString);

            Console.WriteLine("\nQuery data example:");
            Console.WriteLine("=========================================\n");

            connection.Open();
            try
            {
                DateTime date = DateTime.Now;

                using (SqlCommand command = new SqlCommand($"Update [dbo].[Contact] Set SenderName= @SenderName,Message = @Message,SenderEmail = @SenderEmail,Sender_PhoneNumber = @Sender_PhoneNumber,Date_Updated = @Date_Updated,Response=@Response,Responder = @Responder where ContactID = @ContactID", connection))
                {
                    command.Parameters.AddWithValue("@SenderEmail", editInfo.Email);
                    command.Parameters.AddWithValue("@ContactID", editInfo.ticketID);
                    command.Parameters.AddWithValue("@SenderName", editInfo.Name);
                    command.Parameters.AddWithValue("@Message", editInfo.Message);
                    command.Parameters.AddWithValue("@Response", editInfo.Response);
                    command.Parameters.AddWithValue("@Responder", editInfo.Responder);
                    command.Parameters.AddWithValue("@Sender_PhoneNumber", editInfo.PhoneNumber);
                    command.Parameters.Add("@Date_Updated", SqlDbType.DateTime).Value = date;


                    var re = command.ExecuteNonQuery();

                    if (re == 1)
                    {
                        result = "00";
                    }


                }


            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {
                if (connection.State != ConnectionState.Closed)
                {
                    connection.Close();

                }
            }

            //Console.WriteLine("\nDone. Press enter.");
            //Console.ReadLine();



            return result;
        }

        internal static List<Contact> GetAllContactMessage()
        {
            List<Contact> result = new List<Contact>();

            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

            builder.DataSource = "polling.database.windows.net";
            builder.UserID = "pollingAdmin";
            builder.Password = "pollAdmin$";
            builder.InitialCatalog = "CompupharmLtd";

            SqlConnection connection = new SqlConnection(builder.ConnectionString);

            Console.WriteLine("\nQuery data example:");
            Console.WriteLine("=========================================\n");

            connection.Open();
            try
            {

                using (SqlCommand command = new SqlCommand($"SELECT * FROM[dbo].[Contact] ", connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader != null)
                        {
                            while (reader.Read())
                            {
                                Contact res = new Contact();

                                //result.UserID = int.Parse(reader["UserID"]); 
                                res.ticketID = reader["ContactID"].ToString().Trim();

                                res.Name = reader["SenderName"].ToString().Trim();
                                res.Email = reader["SenderEmail"].ToString().Trim();
                                res.Message = reader["Message"].ToString().Trim();
                                res.Response = reader["Response"].ToString().Trim();
                                res.Responder = reader["Responder"].ToString().Trim();
                                res.PhoneNumber = reader["Sender_PhoneNumber"].ToString().Trim();
                                res.DateCreated = Convert.ToDateTime(reader.GetDateTime("Date_Recieved"));
                                result.Add(res);
                            }
                        }

                    }
                }


            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {
                if (connection.State != ConnectionState.Closed)
                {
                    connection.Close();

                }
            }

            //Console.WriteLine("\nDone. Press enter.");
            //Console.ReadLine();



            return result;
        }

        internal static string DeleteContactByID(string id)
        {
            string result = "01";


            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

            builder.DataSource = "polling.database.windows.net";
            builder.UserID = "pollingAdmin";
            builder.Password = "pollAdmin$";
            builder.InitialCatalog = "CompupharmLtd";

            SqlConnection connection = new SqlConnection(builder.ConnectionString);

            Console.WriteLine("\nQuery data example:");
            Console.WriteLine("=========================================\n");

            connection.Open();
            try
            {

                using (SqlCommand command = new SqlCommand($"Delete  FROM [dbo].[Contact] where ContactID = '{id}'", connection))
                {
                  int  ret = command.ExecuteNonQuery();
                    if (ret == 1)
                    {
                        result = "00";
                    }
                }


            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {
                if (connection.State != ConnectionState.Closed)
                {
                    connection.Close();

                }
            }

            //Console.WriteLine("\nDone. Press enter.");
            //Console.ReadLine();



            return result;
        }

        public static Contact GetContactByID(string value)
        {
            var result = new Contact();


            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

            builder.DataSource = "polling.database.windows.net";
            builder.UserID = "pollingAdmin";
            builder.Password = "pollAdmin$";
            builder.InitialCatalog = "CompupharmLtd";

            SqlConnection connection = new SqlConnection(builder.ConnectionString);

            Console.WriteLine("\nQuery data example:");
            Console.WriteLine("=========================================\n");

            connection.Open();
            try
            {

                using (SqlCommand command = new SqlCommand($"SELECT * FROM[dbo].[Contact] where ContactID = '{value}'", connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {

                        while (reader.Read())
                        {

                            //  result.UserID = int.Parse(reader["UserID"]); 
                            result.ticketID = reader["ContactID"].ToString().Trim();
                              
                            result.Name = reader["SenderName"].ToString().Trim();
                            result.Email = reader["SenderEmail"].ToString().Trim();
                            result.Message = reader["Message"].ToString().Trim();
                            result.Response = reader["Response"].ToString().Trim();
                            result.Responder = reader["Responder"].ToString().Trim();
                            result.PhoneNumber = reader["Sender_PhoneNumber"].ToString().Trim();
                            result.DateCreated = Convert.ToDateTime(reader.GetDateTime("Date_Recieved"));

                        }

                    }
                }


            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {
                if (connection.State != ConnectionState.Closed)
                {
                    connection.Close();

                }
            }

            //Console.WriteLine("\nDone. Press enter.");
            //Console.ReadLine();



            return result;
        }
         }
    
}
