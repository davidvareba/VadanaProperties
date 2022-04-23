using VadanaProperties.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace VadanaProperties.Repositories
{
    public interface IRealtorsRepository
    {
        List<Realtor> GetAllRealtors();
        Realtor GetRealtorById(int realtorId);
        public void AddRealtor(Realtor realtor);
        public void UpdateRealtor(Realtor realtor);
        public void DeleteRealtor(int realtorId);
    }
}
