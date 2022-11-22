 using CompupharmLtd.Model;
using System;
using System.Data;
using System.Data.SqlClient;

namespace CompupharmLtd.Data
{
    public class UserData
    {


        public static LoginUser LoginData(string value)
        { var result = new LoginUser();
            

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

                    using (SqlCommand command = new SqlCommand($"SELECT UserID,Year,Password ,UserName FROM[dbo].[Customer] where UserName = '{value.ToLower()}'", connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            while (reader.Read())
                            {
                          
                              //  result.UserID = int.Parse(reader["UserID"]);
                            result.UserID = int.Parse(reader["UserID"].ToString());

                            result.Password = reader["Password"].ToString().Trim() ;
                                result.UserName = reader["UserName"].ToString().Trim();
                                result.Year = int.Parse(reader["Year"].ToString());

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

        internal static string CreateData(User customer)
        {
            //  var result = new User   ();
            string result = "01";

            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

            builder.DataSource = "polling.database.windows.net";
            builder.UserID = "pollingAdmin";
            builder.Password = "pollAdmin$";
            builder.InitialCatalog = "CompupharmLtd";

            SqlConnection connection = new SqlConnection(builder.ConnectionString);

            Console.WriteLine("\nQuery data example:");
            Console.WriteLine("=========================================\n");
            int ret = 6;
            connection.Open();
            try
            {
                DateTime date = DateTime.Now;

                            SqlCommand cmd = new SqlCommand($"INSERT INTO [dbo].[Customer] ([Year],[CompanyName],[UserName],[CompanyEmail] ,[CompanyPhone],[Password],[AccountVerified] ,[Date_Created],[Date_Updated] ,[CompanyAddress],[DateVerified]) VALUES (@yearID,@CompanyName,@UserName,@CompanyEmail,@CompanyPhone,@Password,@AccountVerified,@Date_Created,@Date_Updated,@CompanyAddress,@DateVerified)", connection);
       
                            cmd.Parameters.AddWithValue("@CompanyName", customer.CompanyName);
                            cmd.Parameters.AddWithValue("@CompanyPhone", customer.CompanyPhone);
                            cmd.Parameters.AddWithValue("@CompanyEmail", customer.Email);
                            cmd.Parameters.AddWithValue("@Password", customer.Password.ToLower());
                            cmd.Parameters.AddWithValue("@UserName", customer.Username.ToLower());
                            cmd.Parameters.AddWithValue("@yearID",date.Year);
                            cmd.Parameters.AddWithValue("@CompanyAddress", customer.CompanyAddress);
                        //    cmd.Parameters.AddWithValue("@CompanyCertificate", customer.CompanyCertificate);
                            cmd.Parameters.AddWithValue("@AccountVerified", 1);
                            cmd.Parameters.AddWithValue("@Date_Created", customer.Date_Created).Value=date;
                            cmd.Parameters.AddWithValue("@Date_Updated", customer.Date_Updated).Value = date;
                            cmd.Parameters.AddWithValue("@DateVerified", customer.Date_Verified).Value = date;
                           ret = cmd.ExecuteNonQuery();
                if (ret == 1)
                {
                    result = "00";
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

        internal static User GetUserUsingEmail(string email)
        {
            var res = new User();


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

                using (SqlCommand command = new SqlCommand($"SELECT * FROM[dbo].[Customer] where CompanyEmail = '{email}'", connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader != null)
                        {
                            while (reader.Read())
                            {
                                res.Year = reader["Year"].ToString().Trim();
                                res.UserID = Convert.ToInt32(reader.GetOrdinal("UserID"));
                                res.CompanyName = reader["CompanyName"].ToString().Trim();
                                res.Username = reader["UserName"].ToString().Trim();
                                res.Email = reader["CompanyEmail"].ToString().Trim();
                                res.CompanyPhone = reader["CompanyPhone"].ToString().Trim();
                                res.Password = reader["Password"].ToString().Trim();
                             // res.CompanyCertificate = reader["CompanyCertificate"].ToString().Trim();
                                res.AccountVerified = Convert.ToInt32(reader.GetOrdinal("AccountVerified"));
                                res.CompanyAddress = reader["CompanyAddress"].ToString().Trim();
                                res.Date_Created = Convert.ToDateTime(reader.GetDateTime("Date_Created"));
                                res.Date_Updated = Convert.ToDateTime(reader.GetDateTime("Date_Updated"));
                                res.Date_Verified = Convert.ToDateTime(reader.GetDateTime("DateVerified"));
                              
                              
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



            return res;
        }

        internal static string UpdateData(User customer)
        {
            //  var result = new User   ();
            string result = "01";

            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

            builder.DataSource = "polling.database.windows.net";
            builder.UserID = "pollingAdmin";
            builder.Password = "pollAdmin$";
            builder.InitialCatalog = "CompupharmLtd";

            SqlConnection connection = new SqlConnection(builder.ConnectionString);

            Console.WriteLine("\nQuery data example:");
            Console.WriteLine("=========================================\n");
            int ret = 6;
            connection.Open();
            try
            {
                DateTime date = DateTime.Now;

                SqlCommand cmd = new SqlCommand($"Update [dbo].[Customer] set [CompanyName]=@CompanyName,[UserName]=@UserName,[CompanyEmail]=@CompanyEmail,[CompanyPhone]=@CompanyPhone,[Password]=@Password,[AccountVerified]=@AccountVerified,[Date_Updated]=@DateUpdated,[CompanyAddress]=@CompanyAddress,[DateVerified]=@DateVerified where Year=@yearID AND UserID={customer.UserID}", connection);

                cmd.Parameters.AddWithValue("@CompanyName", customer.CompanyName);
                cmd.Parameters.AddWithValue("@CompanyPhone", customer.CompanyPhone);
                cmd.Parameters.AddWithValue("@CompanyEmail", customer.Email);
                cmd.Parameters.AddWithValue("@Password", customer.Password);
                cmd.Parameters.AddWithValue("@UserName", customer.Username);
                cmd.Parameters.AddWithValue("@yearID", customer.Year);
                cmd.Parameters.AddWithValue("@CompanyAddress", customer.CompanyAddress);
              //cmd.Parameters.AddWithValue("@CompanyCertificate", customer.CompanyCertificate);
                cmd.Parameters.AddWithValue("@AccountVerified", customer.AccountVerified);
                cmd.Parameters.AddWithValue("@Date_Created", customer.Date_Created);
                cmd.Parameters.AddWithValue("@DateUpdated", customer.Date_Updated).Value = date;
                cmd.Parameters.AddWithValue("@DateVerified", customer.Date_Verified);
                ret = cmd.ExecuteNonQuery();
                if (ret == 1)
                {
                    result = "00";
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