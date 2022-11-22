using CompupharmLtd.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace CompupharmLtd.Data
{
    public class ExecutiveData
    {
        internal static List<Executive> AllExecutiveList()
        {
            List<Executive> result = new List<Executive>();


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

                using (SqlCommand command = new SqlCommand($"SELECT * FROM[dbo].[executive] ", connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader != null)
                        {
                            while (reader.Read())
                            {
                                var res = new Executive();
                                res.ExecutiveID = reader.GetInt32(0);
                              //  res.ExecutiveID = Convert.ToInt32(reader.GetOrdinal("ExecutiveID"));
                                res.Name = reader["Name"].ToString().Trim();
                                res.ShortDescription = reader["ShortDescription"].ToString().Trim();
                                res.FullDescription = reader["FullDescription"].ToString().Trim();
                                res.AcademmicQualifications = reader["AcademmicQualifications"].ToString().Trim();
                                res.Email = reader["Email"].ToString().Trim();
                              //  res.Image = reader["Image"].ToString().Trim();
                                res.Title = reader["Title"].ToString().Trim();
                                res.DateCreated = Convert.ToDateTime(reader.GetDateTime("DateCreated"));
                                res.Position = reader["Position"].ToString().Trim();
                                res.DateEmployed = Convert.ToDateTime(reader.GetDateTime("DateEmployed"));
                                res.DateOfBirth = Convert.ToDateTime(reader.GetDateTime("DateOfBirth"));
                                res.DateUpdated = Convert.ToDateTime(reader.GetDateTime("DateUpdated"));
                                res.ResignationDate = Convert.ToDateTime(reader.GetDateTime("ResignationDate"));
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

        internal static Executive GetExecutiveByID(int id)
        {
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

                using (SqlCommand command = new SqlCommand($"SELECT * FROM[dbo].[executive] where ExecutiveID = '{id}'", connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader != null)
                        {
                            while (reader.Read())
                            {
                                res.ExecutiveID = Convert.ToInt32(reader.GetOrdinal("ExecutiveID"));
                                res.Name = reader["Name"].ToString().Trim();
                                res.ShortDescription = reader["ShortDescription"].ToString().Trim();
                                res.FullDescription = reader["FullDescription"].ToString().Trim();
                                res.AcademmicQualifications = reader["AcademmicQualifications"].ToString().Trim();
                                res.Email = reader["Email"].ToString().Trim();
                                //                       res.Image = reader["Image"].ToString().Trim();
                                res.Title = reader["Title"].ToString().Trim();
                                res.DateCreated = Convert.ToDateTime(reader.GetDateTime("DateCreated"));
                                res.Position = reader["Position"].ToString().Trim();
                                res.DateEmployed = Convert.ToDateTime(reader.GetDateTime("DateEmployed"));
                                res.DateOfBirth = Convert.ToDateTime(reader.GetDateTime("DateOfBirth"));
                                res.DateUpdated = Convert.ToDateTime(reader.GetDateTime("DateUpdated"));
                                res.ResignationDate = Convert.ToDateTime(reader.GetDateTime("ResignationDate"));
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

        internal static string CreateExecutive(Executive value)
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

                using (SqlCommand command = new SqlCommand($"INSERT INTO[dbo].[executive]([Name],[Email],[AcademmicQualifications],[Title],[ShortDescription],[FullDescription],[Position],[DateCreated],[DateUpdated],[DateOfBirth],[DateEmployed],[ResignationDate]) VALUES(@Name,@Email,@AcademmicQualifications,@Title,@ShortDescription,@FullDescription,@Position,@DateCreated,@DateUpdated,@DateOfBirth,@DateEmployed,@ResignationDate)", connection))
                {
                    command.Parameters.AddWithValue("@Name", value.Name);
                    command.Parameters.AddWithValue("@Email", value.Email);
                    command.Parameters.AddWithValue("@AcademmicQualifications", value.AcademmicQualifications);
                    command.Parameters.AddWithValue("@Title", value.Title);
                    command.Parameters.AddWithValue("@ShortDescription", value.ShortDescription);
                    command.Parameters.AddWithValue("@FullDescription", value.FullDescription);
                    command.Parameters.AddWithValue("@Position", value.Position);
                  //  command.Parameters.AddWithValue("@Image", value.Image);
                    command.Parameters.AddWithValue("@DateCreated", SqlDbType.DateTime).Value = date.ToString(format);
                    command.Parameters.AddWithValue("@DateUpdated", SqlDbType.DateTime).Value = date.ToString(format);
                    command.Parameters.AddWithValue("@DateOfBirth", value.DateOfBirth);
                    command.Parameters.AddWithValue("@DateEmployed", value.DateEmployed);
                    command.Parameters.AddWithValue("@ResignationDate", value.DateEmployed);               

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

        internal static Executive GetExecutiveUsingEmail(string email)
        {
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

                using (SqlCommand command = new SqlCommand($"Select * FROM [dbo].[executive] WHERE [email] ='{email}'", connection))
                {


                    using (SqlDataReader reader = command.ExecuteReader())
                        if (reader != null)
                        {
                            while (reader.Read())
                            {
                                // ([id],[product_name],[short_desc],[full_desc],[price],[quantity],[created_date],[status]
                                //ar res = new Executive();
                                res.ExecutiveID = Convert.ToInt32(reader["ExecutiveID"]);
                                res.Name = reader["Name"].ToString().Trim();
                                res.ShortDescription = reader["ShortDescription"].ToString().Trim();
                                res.FullDescription = reader["FullDescription"].ToString().Trim();
                                res.AcademmicQualifications = reader["AcademmicQualifications"].ToString().Trim();
                                res.Email = reader["Email"].ToString().Trim();
                               // res.Image = reader["Image"].ToString().Trim();
                                res.Title = reader["Title"].ToString().Trim();
                                res.DateCreated = Convert.ToDateTime(reader.GetDateTime("DateCreated"));
                                res.Position = reader["Position"].ToString().Trim();
                                res.DateEmployed = Convert.ToDateTime(reader.GetDateTime("DateEmployed"));
                                res.DateOfBirth = Convert.ToDateTime(reader.GetDateTime("DateOfBirth"));
                                res.DateUpdated = Convert.ToDateTime(reader.GetDateTime("DateUpdated"));
                                res.ResignationDate = Convert.ToDateTime(reader.GetDateTime("ResignationDate"));
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
    
        internal static string EditExecutive(Executive value)
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

                using (SqlCommand command = new SqlCommand($"UPDATE  [dbo].[executive] SET [Name]=@Name,[Email]=@Email,[AcademmicQualifications]=@AcademmicQualifications,[Title]=@Title,[ShortDescription]=@ShortDescription,[FullDescription]=@FullDescription,[Position]=@Position,DateOfBirth = @DateOfBirth,DateEmployed = @DateEmployed,ResignationDate=@ResignationDate,DateCreated = @DateCreated,DateUpdated = @DateUpdated where ExecutiveID ={value.ExecutiveID}", connection))
                {
                    command.Parameters.AddWithValue("@Name", value.Name);
                    command.Parameters.AddWithValue("@Email", value.Email);
                    command.Parameters.AddWithValue("@AcademmicQualifications", value.AcademmicQualifications);
                    command.Parameters.AddWithValue("@Title", value.Title);
                    command.Parameters.AddWithValue("@ShortDescription", value.ShortDescription);
                    command.Parameters.AddWithValue("@FullDescription", value.FullDescription);
                    command.Parameters.AddWithValue("@Position", value.Position);
                   // command.Parameters.AddWithValue("@Image", value.Image);
                    command.Parameters.AddWithValue("@DateCreated", value.DateCreated);
                    command.Parameters.AddWithValue("@DateOfBirth", value.DateOfBirth);
                    command.Parameters.AddWithValue("@DateEmployed", value.DateEmployed);
                    command.Parameters.AddWithValue("@ResignationDate", value.ResignationDate);
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

        internal static string DeleteExecutive(int id)
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

                using (SqlCommand command = new SqlCommand($"Delete FROM [dbo].[executive] WHERE [ExecutiveID] ={id}", connection))
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
