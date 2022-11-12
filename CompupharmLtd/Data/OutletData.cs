using CompupharmLtd.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace CompupharmLtd.Data
{
    public class OutletData
    {
        internal static string CreateOutlet(Outlet value)
        {
            string result = "01";
            var res = new Executive();
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
                string format = "yyyy-MM-dd HH:mm:ss";    // modify the format depending upon input required in the column in database 

                using (SqlCommand command = new SqlCommand($"INSERT INTO[dbo].[outlets]([Name],[Email],[PhoneNumber],[Street],[City],[State],[Country],[ZipCode],[DateAdded],[DateUpdated]) VALUES(@Name,@Email,@PhoneNumber,@Street,@City,@State,@Country,@ZipCode,@DateAdded,@DateUpdated)", connection))
                {
                    command.Parameters.AddWithValue("@Name", value.Name);
                    command.Parameters.AddWithValue("@Email", value.Email);
                    command.Parameters.AddWithValue("@PhoneNumber", value.PhoneNumber);
                    command.Parameters.AddWithValue("@Street", value.Street);
                    command.Parameters.AddWithValue("@City", value.City);
                    command.Parameters.AddWithValue("@State", value.State);
                    command.Parameters.AddWithValue("@Country", value.Country);
                    command.Parameters.AddWithValue("@ZipCode", value.ZipCode);
                    command.Parameters.AddWithValue("@DateAdded", SqlDbType.DateTime).Value = date.ToString(format);
                    command.Parameters.AddWithValue("@DateUpdated", SqlDbType.DateTime).Value = date.ToString(format);
                   

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

        internal static List<Outlet> AllOutletList()
        {

            List<Outlet> result = new List<Outlet>();


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

                using (SqlCommand command = new SqlCommand($"SELECT * FROM[dbo].[outlets] ", connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader != null)
                        {
                            while (reader.Read())
                            {
                                var res = new Outlet();
                                res.OutletID = reader.GetInt32(0);
                            //    res.OutletID = Convert.ToInt32(reader.GetOrdinal("OutletID"));
                                res.Name = reader["Name"].ToString().Trim();
                                res.City = reader["City"].ToString().Trim();
                                res.Country = reader["Country"].ToString().Trim();
                                res.State = reader["State"].ToString().Trim();
                                res.Email = reader["Email"].ToString().Trim();
                                res.Street = reader["Street"].ToString().Trim();
                                res.PhoneNumber = reader["PhoneNumber"].ToString().Trim();
                                res.ZipCode = reader["ZipCode"].ToString().Trim();
                                res.DateAdded = Convert.ToDateTime(reader.GetDateTime("DateAdded"));
                                res.DateUpdated = Convert.ToDateTime(reader.GetDateTime("DateUpdated"));
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

        internal static Outlet GetOutletByID(int OutletID)
        {
            var res = new Outlet();
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

                using (SqlCommand command = new SqlCommand($"SELECT * FROM[dbo].[outlets] where OutletID = {OutletID}", connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader != null)
                        {
                            while (reader.Read())
                            {
                                res.OutletID = Convert.ToInt32(reader.GetOrdinal("OutletID"));
                                res.Name = reader["Name"].ToString().Trim();
                                res.City = reader["City"].ToString().Trim();
                                res.Country = reader["Country"].ToString().Trim();
                                res.State = reader["State"].ToString().Trim();
                                res.Email = reader["Email"].ToString().Trim();
                                res.Street = reader["Street"].ToString().Trim();
                                res.PhoneNumber = reader["PhoneNumber"].ToString().Trim();
                                res.ZipCode = reader["ZipCode"].ToString().Trim();
                                res.DateAdded = Convert.ToDateTime(reader.GetDateTime("DateAdded"));
                                res.DateUpdated = Convert.ToDateTime(reader.GetDateTime("DateUpdated"));
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

      
        internal static string EditOutlet(Outlet value)
        {
            string result = "01";
            var res = new Executive();
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

                using (SqlCommand command = new SqlCommand($"UPDATE  [dbo].[outlets] SET [Name]=@Name,[Email]=@Email,[PhoneNumber]=@PhoneNumber,[Street]=@Street,[City]=@City,[State]=@State,[Country]=@Country,ZipCode =@ZipCode,DateAdded = @DateAdded, DateUpdated = @DateUpdated where OutletID ={value.OutletID}", connection))
                {
                    command.Parameters.AddWithValue("@Name", value.Name);
                    command.Parameters.AddWithValue("@Email", value.Email);
                    command.Parameters.AddWithValue("@PhoneNumber", value.PhoneNumber);
                    command.Parameters.AddWithValue("@Street", value.Street);
                    command.Parameters.AddWithValue("@City", value.City);
                    command.Parameters.AddWithValue("@State", value.State);
                    command.Parameters.AddWithValue("@Country", value.Country);
                    command.Parameters.AddWithValue("@ZipCode", value.ZipCode);
                    command.Parameters.AddWithValue("@DateAdded", value.DateAdded);
                    command.Parameters.Add("@DateUpdated", SqlDbType.DateTime).Value = date;


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

        internal static string DeleteOutlet(int id)
        {
            string result = "01";
            var res = new Executive();
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

                using (SqlCommand command = new SqlCommand($"Delete FROM [dbo].[outlets] WHERE [OutletID] ={id}", connection))
                {


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
    }
}
