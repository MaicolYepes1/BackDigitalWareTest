using DigitalWare.MODELS.Models;
using DigitalWare.MODELS.Requests;

namespace DigitalWare.CORE.ClientesCore.Interfaces
{
    public interface IClientesCore
    {
        Task<List<ClienteModel>> GetAll();
        Task<List<ClienteModel>> GetByClientId(int Id);
        Task<bool> CreateOrUpdate(ClienteRequest model);
        Task<bool> Delete(int id);
    }
}
