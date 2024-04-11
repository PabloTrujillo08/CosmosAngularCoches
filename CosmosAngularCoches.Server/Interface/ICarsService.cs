using CosmosAngularCoches.Server.Models;

namespace CosmosAngularCoches.Server.Interface
{
    public interface ICarsService
    {
        Task<IEnumerable<Cars>> GetMultipleCarsAsync(string query);
        Task<Cars> GetCarAsync(string id);
        Task AddCarAsync(Cars car);
        Task UpdateCarAsync(string id, Cars car);
        Task DeleteCarAsync(string id);
    }
}
