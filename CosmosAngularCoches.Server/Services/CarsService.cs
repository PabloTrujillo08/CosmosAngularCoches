using CosmosAngularCoches.Server.Interface;
using CosmosAngularCoches.Server.Models;
using Microsoft.Azure.Cosmos;
using System.ComponentModel;

namespace CosmosAngularCoches.Server.Services
{
    public class CarsService : ICarsService
    {

        private readonly Microsoft.Azure.Cosmos.Container _container;


        public CarsService(CosmosClient dbClient, string databaseName, string containerName)
        {
            _container = dbClient.GetContainer(databaseName, containerName);
        }


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
