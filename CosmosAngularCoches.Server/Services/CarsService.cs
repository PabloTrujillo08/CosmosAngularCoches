using CosmosAngularCoches.Server.Interface;
using CosmosAngularCoches.Server.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.Cosmos;
using System.ComponentModel;
using System.Xml.Linq;

namespace CosmosAngularCoches.Server.Services
{
    public class CarsService : ICarsService
    {

        private readonly Microsoft.Azure.Cosmos.Container _container;


        public CarsService(CosmosClient dbClient, string databaseName, string containerName)
        {
            _container = dbClient.GetContainer(databaseName, containerName);
        }


        public async Task AddCarAsync(Cars car)
        {
            await _container.CreateItemAsync(car, new PartitionKey(car.Id));
        }

        public async Task DeleteCarAsync(string id)
        {
            await _container.DeleteItemAsync<Cars>(id, new PartitionKey(id));
        }

        public async Task<Cars> GetCarAsync(string id)
        {
            try
            {
                var response = await _container.ReadItemAsync<Cars>(id, new PartitionKey(id));
                return response.Resource;
            }
            catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null!;
            }
        }

        public async Task<IEnumerable<Cars>> GetMultipleCarsAsync(string queryString)
        {
            var query = _container.GetItemQueryIterator<Cars>(new QueryDefinition(queryString));
            var results = new List<Cars>();
            while (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();
                results.AddRange(response.ToList());
            }
            return results;
        }

        public async Task UpdateCarAsync(string id, Cars car)
        {
            await _container.UpsertItemAsync(car, new PartitionKey(id));
        }
    }
}
