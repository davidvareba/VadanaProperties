using VadanaProperties.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace VadanaProperties.Repositories
{
    public class RealtorsRepository : IRealtorsRepository
    {
        private readonly IConfiguration _config;

        public RealtorsRepository(IConfiguration config)
        {
            _config = config;
        }

        public SqlConnection Connection
        {
            get
            {
                return new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            }
        }

        //Get all realtors
        public List<Realtor> GetAllRealtors()
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT Id,
	                                           [Name],
	                                           Phone,
	                                           Email, 
	                                           ImgURL
                                        FROM Realtor";
                    SqlDataReader reader = cmd.ExecuteReader();

                    List<Realtor> realtors = new List<Realtor>();
                    while (reader.Read())
                    {
                        Realtor realtor = new Realtor()
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            Name = reader.GetString(reader.GetOrdinal("Name")),
                            Phone = reader.GetString(reader.GetOrdinal("Phone")),
                            Email = reader.GetString(reader.GetOrdinal("Email")),
                            ImgURL = reader.GetString(reader.GetOrdinal("ImgURL"))
                        };
                        realtors.Add(realtor);
                    }
                    reader.Close();
                    return realtors;
                }
            }
        }

        //Get a realtor by Id
        public Realtor GetRealtorById(int id)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT Id,
	                                           [Name],
	                                           Phone,
	                                           Email, 
	                                           ImgURL
                                        FROM Realtor
										WHERE Id = @id";

                    cmd.Parameters.AddWithValue("@id", id);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        Realtor realtor = new Realtor()
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            Name = reader.GetString(reader.GetOrdinal("Name")),
                            Phone = reader.GetString(reader.GetOrdinal("Phone")),
                            Email = reader.GetString(reader.GetOrdinal("Email")),
                            ImgURL = reader.GetString(reader.GetOrdinal("ImgURL"))
                        };
                        reader.Close();
                        return realtor;
                    }
                    else
                    {
                        reader.Close();
                        return null;
                    }
                }
            }
        }

        //Add a realtor

        public void AddRealtor(Realtor realtor)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"INSERT INTO Realtor ([Name],
					                                        Email,
					                                        Phone,
					                                        ImgURL)
                                        OUTPUT INSERTED.Id
                                        VALUES (@name, @email, @phone, @phone)";

                    cmd.Parameters.AddWithValue("@name", realtor.Name);
                    cmd.Parameters.AddWithValue("@email", realtor.Email);
                    cmd.Parameters.AddWithValue("@phone", realtor.Phone);
                    cmd.Parameters.AddWithValue("@ImgUrl", realtor.ImgURL);

                    int id = (int)cmd.ExecuteScalar();

                    realtor.Id = id;
                }
            }
        }

        //Update a Realtor

        public void UpdateRealtor(Realtor realtor)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"UPDATE Realtor
                                        SET [Name] = @name, 
                                            Email = @email, 
                                            Phone = @phone
                                        WHERE Id = @id";

                    cmd.Parameters.AddWithValue("@name", realtor.Name);
                    cmd.Parameters.AddWithValue("@email", realtor.Email);
                    cmd.Parameters.AddWithValue("@phone", realtor.Phone);
                    cmd.Parameters.AddWithValue("@id", realtor.Id);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        //Delete a Realtor

        public void DeleteRealtor(int realtorId)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"DELETE FROM Realtor
                                        WHERE Id = @id";

                    cmd.Parameters.AddWithValue("@id", realtorId);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
