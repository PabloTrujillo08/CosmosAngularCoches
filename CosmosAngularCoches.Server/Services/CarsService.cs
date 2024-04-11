using CosmosAngularCoches.Server.Interface;
using CosmosAngularCoches.Server.Models;

namespace CosmosAngularCoches.Server.Services
{
    public class CarsService : ICarsService
    {

        public Task<Cars> AddCarAsync(Cars car)
        {
            throw new NotImplementedException();
        }

        public Task DeleteCarAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Cars> GetCarAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Cars>> GetCarsAsync(string query)
        {
            throw new NotImplementedException();
        }

        public Task<Cars> UpdateCarAsync(Cars car)
        {
            throw new NotImplementedException();
        }
    }
}
