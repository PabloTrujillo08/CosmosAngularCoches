using CosmosAngularCoches.Server.Models;

namespace CosmosAngularCoches.Server.Interface
{
    public interface ICarsService
    {
        Task<IEnumerable<Cars>> GetMultipleCarsAsync(string queryString);
        Task<Cars> GetCarAsync(string id, string make);
        Task AddCarAsync(Cars car);
        Task UpdateCarAsync(string id, Cars car);
        Task DeleteCarAsync(string id, string make);
    }
}
