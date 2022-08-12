using DigitalWare.MODELS.Models;
using DigitalWare.MODELS.Requests;

namespace DigitalWare.CORE.ProductosCore.Interfaces
{
    public interface IProductosCore
    {
        Task<List<ProductoModel>> GetAll();
        Task<List<ProductoModel>> GetByClientId(int Id);
        Task<bool> CreateOrUpdate(ProductoRequest model);
        Task<bool> Delete(int id);
    }
}
