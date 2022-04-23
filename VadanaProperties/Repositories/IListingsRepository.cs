using VadanaProperties.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace VadanaProperties.Repositories
{
    public interface IListingsRepository
    {
        List<Listing> GetAllListings();
        Listing GetListingById(int id);
        List<Listing> GetListingsByRealtorId(int id);
        public void UpdateListing(Listing listing);
        public void DeleteListing(int id);
        public void AddListing(Listing listing);
    }
}
