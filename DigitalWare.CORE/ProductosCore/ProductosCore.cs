using AutoMapper;
using DigitalWare.CORE.ProductosCore.Interfaces;
using DigitalWare.DATA.Context;
using DigitalWare.MODELS.Entities;
using DigitalWare.MODELS.Models;
using DigitalWare.MODELS.Requests;

namespace DigitalWare.CORE.ProductosCore
{
    public class ProductosCore : IProductosCore
    {
        #region Dependency
        private readonly DigitalWareDBContext _context;
        private readonly IMapper _mapper;
        #endregion

        #region Constructor
        public ProductosCore(DigitalWareDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        #endregion

        #region Methods

        public async Task<List<ProductoModel>> GetAll()
        {
            var res = _context.Productos.ToList();
            if (res.Count != 0)
            {
                var map = _mapper.Map<List<ProductoModel>>(res);
                return await Task.FromResult(map);
            }
            else
            {
                return null;
            }
        }


        public async Task<List<ProductoModel>> GetByClientId(int Id)
        {
            var res = _context.Productos.Where(z => z.ProductoId == Id).ToList();
            if (res.Count != 0)
            {
                var map = _mapper.Map<List<ProductoModel>>(res);
                return await Task.FromResult(map);
            }
            else
            {
                return null;
            }
        }

        public async Task<bool> CreateOrUpdate(ProductoRequest model)
        {
            var map = _mapper.Map<ProductoEntitie>(model);

            if (map.ProductoId != 0)
            {
                _context.Productos.Update(map);
                var res = _context.SaveChangesAsync();
                return await Task.FromResult(Convert.ToBoolean(res.Result));
            }
            else
            {
                var exist = _context.Clientes.Where(_x => _x.ClienteId == map.ProductoId).FirstOrDefault();
                if (exist != null)
                {
                    return false;
                }
                _context.Productos.Add(map);
                var res = _context.SaveChangesAsync();
                return await Task.FromResult(Convert.ToBoolean(res.Result));
            }
        }

        public async Task<bool> Delete(int id)
        {
            if (id != 0)
            {
                var productoDeleted = _context.Productos.Where(x => x.ProductoId == id).FirstOrDefault();
                _context.Productos.Remove(productoDeleted);
                var res = _context.SaveChangesAsync();
                return await Task.FromResult(Convert.ToBoolean(res.Result));
            }
            else
            {
                return await Task.FromResult(Convert.ToBoolean(false));
            }
        }
        #endregion
    }
}
