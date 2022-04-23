using VadanaProperties.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace VadanaProperties.Repositories
{
    public class ListingsRepository : IListingsRepository
    {
        private readonly IConfiguration _config;

        public ListingsRepository(IConfiguration config)
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
        public List<Listing> GetAllListings()
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                                      SELECT
                                      Id,
                                      Address,
                                      SquareFoot,
                                      Rent,
                                      Details,
                                      YearBuilt,
                                      City,
                                      ImgUrl,
                                      RealtorId,
                                      UserId
                                      FROM Listing
                                      ";

                    SqlDataReader reader = cmd.ExecuteReader();

                    List<Listing> listings = new List<Listing>();
                    while (reader.Read())
                    {
                        Listing listing = new Listing
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            Address = reader.GetString(reader.GetOrdinal("Address")),
                            SquareFoot = reader.GetInt32(reader.GetOrdinal("SquareFoot")),
                            Rent = reader.GetInt32(reader.GetOrdinal("Rent")),
                            Details = reader.GetString(reader.GetOrdinal("Details")),
                            YearBuilt = reader.GetInt32(reader.GetOrdinal("YearBuilt")),
                            City = reader.GetString(reader.GetOrdinal("City")),
                            ImgUrl = reader.GetString(reader.GetOrdinal("ImgUrl")),
                            RealtorId = reader.GetInt32(reader.GetOrdinal("RealtorId")),
                            UserId = reader.GetInt32(reader.GetOrdinal("UserId"))
                        };

                        listings.Add(listing);
                    }

                    reader.Close();

                    return listings;
                }
            }
        }

        public Listing GetListingById(int id)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                                      SELECT
                                      Id,
                                      Address,
                                      SquareFoot,
                                      Rent,
                                      Details,
                                      YearBuilt,
                                      City,
                                      ImgUrl,
                                      RealtorId,
                                      UserId
                                      FROM Listing WHERE Id = @id
                                      ";

                    cmd.Parameters.AddWithValue("@id", id);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        Listing listing = new Listing
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            Address = reader.GetString(reader.GetOrdinal("Address")),
                            SquareFoot = reader.GetInt32(reader.GetOrdinal("SquareFoot")),
                            Rent = reader.GetInt32(reader.GetOrdinal("Rent")),
                            Details = reader.GetString(reader.GetOrdinal("Details")),
                            YearBuilt = reader.GetInt32(reader.GetOrdinal("YearBuilt")),
                            City = reader.GetString(reader.GetOrdinal("City")),
                            ImgUrl = reader.GetString(reader.GetOrdinal("ImgUrl")),
                            RealtorId = reader.GetInt32(reader.GetOrdinal("RealtorId")),
                            UserId = reader.GetInt32(reader.GetOrdinal("UserId"))
                        };

                        reader.Close();
                        return listing;
                    }
                    else
                    {
                        reader.Close();
                        return null;
                    }
                }
            }
        }

        public List<Listing> GetListingsByRealtorId(int id)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                                      SELECT
                                      Id,
                                      Address,
                                      SquareFoot,
                                      Rent,
                                      Details,
                                      YearBuilt,
                                      City,
                                      ImgUrl,
                                      RealtorId,
                                      UserId
                                      FROM Listing WHERE RealtorId = @id
                                      ";

                    cmd.Parameters.AddWithValue("id", id);

                    SqlDataReader reader = cmd.ExecuteReader();

                    List<Listing> listings = new List<Listing>();
                    while (reader.Read())
                    {
                        Listing listing = new Listing
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            Address = reader.GetString(reader.GetOrdinal("Address")),
                            SquareFoot = reader.GetInt32(reader.GetOrdinal("SquareFoot")),
                            Rent = reader.GetInt32(reader.GetOrdinal("Rent")),
                            Details = reader.GetString(reader.GetOrdinal("Details")),
                            YearBuilt = reader.GetInt32(reader.GetOrdinal("YearBuilt")),
                            City = reader.GetString(reader.GetOrdinal("City")),
                            ImgUrl = reader.GetString(reader.GetOrdinal("ImgUrl")),
                            RealtorId = reader.GetInt32(reader.GetOrdinal("RealtorId")),
                            UserId = reader.GetInt32(reader.GetOrdinal("UserId"))
                        };
                        listings.Add(listing);

                    }
                    reader.Close();
                    return listings;
                }
            }
        }

        public void UpdateListing(Listing listing)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        Update Listing
                        SET
                            Address = @address
                            SquareFoot = @squareFoot
                            Rent = @rent
                            Details = @details
                            YearBuilt = @yearBuilt
                            City = @city
                            ImgUrl = @imgUrl
                            RealtorId = @realtorId
                        WHERE Id = @id";

                    cmd.Parameters.AddWithValue("@address", listing.Address);
                    cmd.Parameters.AddWithValue("@squareFoot", listing.SquareFoot);
                    cmd.Parameters.AddWithValue("@details", listing.Details);
                    cmd.Parameters.AddWithValue("@yearBuilt", listing.YearBuilt);
                    cmd.Parameters.AddWithValue("@City", listing.City);
                    cmd.Parameters.AddWithValue("@imgUrl", listing.ImgUrl);
                    cmd.Parameters.AddWithValue("@realtorId", listing.RealtorId);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void DeleteListing(int id)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        DELETE FROM Listing
                        WHERE Id = @id
                        ";

                    cmd.Parameters.AddWithValue("@id", id);

                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void AddListing(Listing listing)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"INSERT INTO Listing 
                                                (Address,
                                                SquareFoot,
                                                Rent,
                                                Details,
                                                YearBuilt,
                                                City,
                                                ImgUrl,
                                                AgentId,
                                                UserId)
                    OUTPUT Inserted.Id
                    VALUES (@address, @squareFoot, @rent, @details, @year, @city, @imgurl, @agentId, @userId)";

                    cmd.Parameters.AddWithValue("@address", listing.Address);
                    cmd.Parameters.AddWithValue("@squareFoot", listing.SquareFoot);
                    cmd.Parameters.AddWithValue("@rent", listing.Rent);
                    cmd.Parameters.AddWithValue("@details", listing.Details);
                    cmd.Parameters.AddWithValue("@year", listing.YearBuilt);
                    cmd.Parameters.AddWithValue("@city", listing.City);
                    cmd.Parameters.AddWithValue("@imgurl", listing.ImgUrl);
                    cmd.Parameters.AddWithValue("@agentId", listing.RealtorId);
                    cmd.Parameters.AddWithValue("@userId", listing.UserId);

                    int id = (int)cmd.ExecuteScalar();

                    listing.Id = id;
                }
            }
        }

    }
}
