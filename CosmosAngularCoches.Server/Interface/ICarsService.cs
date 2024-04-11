using CosmosAngularCoches.Server.Models;

namespace CosmosAngularCoches.Server.Interface
{
    public interface ICarsService
    {
        Task<IEnumerable<Cars>> GetCarsAsync(string query);
        Task<Cars> GetCarAsync(string id);
        Task<Cars> AddCarAsync(Cars car);
        Task<Cars> UpdateCarAsync(Cars car);
        Task DeleteCarAsync(string id);
    }
}
