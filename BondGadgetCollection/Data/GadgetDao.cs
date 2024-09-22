using BondGadgetCollection.Models;
using System;
using System.Data.SqlClient;
using static System.Net.Mime.MediaTypeNames;
using System.Drawing;

namespace BondGadgetCollection.Data
{
    public class GadgetDao
    {
        private string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BondGadgetDatabase;Integrated Security=True;Connect Timeout=30;Encrypt=False";
        public List<GadgetModel> FetchAll()
        {
            List<GadgetModel> returnList = new List<GadgetModel>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string sqlQuery = "SELECT * FROM dbo.Gadgets";
                    SqlCommand command = new SqlCommand(sqlQuery, connection);

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            GadgetModel gadget = new GadgetModel
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                Description = reader.GetString(2),
                                AppearsIn = reader.GetString(3),
                                WithThisActor = reader.GetString(4)
                            };

                            returnList.Add(gadget);
                        }
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                Console.WriteLine($"SQL Exception: {sqlEx.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"General Exception: {ex.Message}");
                throw;
            }

            return returnList;
        }

        public GadgetModel FetchOne(int id)
        {
            GadgetModel gadget = new GadgetModel();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string sqlQuery = "SELECT * FROM dbo.Gadgets WHERE Id = @id";
                    SqlCommand command = new SqlCommand(sqlQuery, connection);

                    //associate id parameter

                    command.Parameters.Add("@Id", System.Data.SqlDbType.Int).Value = id;

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();


                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {

                            gadget.Id = reader.GetInt32(0);
                            gadget.Name = reader.GetString(1);
                            gadget.Description = reader.GetString(2);
                            gadget.AppearsIn = reader.GetString(3);
                            gadget.WithThisActor = reader.GetString(4);


                        }
                    }
                }

            }
            catch (SqlException sqlEx)
            {
                Console.WriteLine($"SQL Exception: {sqlEx.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"General Exception: {ex.Message}");
                throw;
            }

            return gadget;
        }

        //create new

        public int CreateOrUpdate(GadgetModel gadgetModel)
        {
            GadgetModel gadget = new GadgetModel();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string sqlQuery = "";

                    if (gadgetModel.Id <= 0)
                    {
                        sqlQuery = "INSERT INTO dbo.Gadgets values(@Name, @Description, @AppearsIn, @WithThisActor)";

                    }
                    else
                    {
                        sqlQuery = "UPDATE dbo.Gadgets SET Name = @Name, Description = @Description, AppearsIn = @AppearsIn, WithThisActor = @WithThisActor WHERE Id = @Id";
                    }

                    SqlCommand command = new SqlCommand(sqlQuery, connection);

                    //associate id parameter
                    command.Parameters.Add("@Id", System.Data.SqlDbType.VarChar, 1000).Value = gadgetModel.Id;

                    command.Parameters.Add("@Name", System.Data.SqlDbType.VarChar, 1000).Value = gadgetModel.Name;
                    command.Parameters.Add("@Description", System.Data.SqlDbType.VarChar, 1000).Value = gadgetModel.Description;
                    command.Parameters.Add("@AppearsIn", System.Data.SqlDbType.VarChar, 1000).Value = gadgetModel.AppearsIn;
                    command.Parameters.Add("@WithThisActor", System.Data.SqlDbType.VarChar, 1000).Value = gadgetModel.WithThisActor;


                    connection.Open();
                    int newID = command.ExecuteNonQuery();

                    return newID;

                }

            }
            catch (SqlException sqlEx)
            {
                Console.WriteLine($"SQL Exception: {sqlEx.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"General Exception: {ex.Message}");
                throw;
            }

            //return newID;
        }

        public int Delete(int id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string sqlQuery = "DELETE FROM dbo.Gadgets WHERE Id = @id";

                    SqlCommand command = new SqlCommand(sqlQuery, connection);

                    //associate id parameter
                    command.Parameters.Add("@Id", System.Data.SqlDbType.VarChar, 1000).Value = id;


                    connection.Open();
                    int deletedId = command.ExecuteNonQuery();

                    return deletedId;

                }

            }
            catch (SqlException sqlEx)
            {
                Console.WriteLine($"SQL Exception: {sqlEx.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"General Exception: {ex.Message}");
                throw;
            }
        }

        internal List<GadgetModel> SearchForName(string searchPhrase)
        {
            List<GadgetModel> returnList = new List<GadgetModel>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string sqlQuery = "SELECT * FROM dbo.Gadgets WHERE NAME LIKE @searchForMe";
                    SqlCommand command = new SqlCommand(sqlQuery, connection);
                    command.Parameters.Add("@SearchForMe", System.Data.SqlDbType.NChar).Value = "%" + searchPhrase + "%";

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            GadgetModel gadget = new GadgetModel
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                Description = reader.GetString(2),
                                AppearsIn = reader.GetString(3),
                                WithThisActor = reader.GetString(4)
                            };

                            returnList.Add(gadget);
                        }
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                Console.WriteLine($"SQL Exception: {sqlEx.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"General Exception: {ex.Message}");
                throw;
            }

            return returnList;
        }


    


        // delete

        //update

        //
    }
}
