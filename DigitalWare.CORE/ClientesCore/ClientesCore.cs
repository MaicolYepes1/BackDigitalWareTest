using AutoMapper;
using DigitalWare.CORE.ClientesCore.Interfaces;
using DigitalWare.DATA.Context;
using DigitalWare.MODELS.Entities;
using DigitalWare.MODELS.Models;
using DigitalWare.MODELS.Requests;

namespace DigitalWare.CORE.CleintesCore
{
    public class ClientesCore : IClientesCore
    {
        #region Dependency
        private readonly DigitalWareDBContext _context;
        private readonly IMapper _mapper;
        #endregion

        #region Constructor
        public ClientesCore(DigitalWareDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        #endregion

        #region Methods

        public async Task<List<ClienteModel>> GetAll()
        {
            var res = _context.Clientes.ToList();
            if (res.Count != 0)
            {
                var map = _mapper.Map<List<ClienteModel>>(res);
                return await Task.FromResult(map);
            }
            else
            {
                return null;
            }
        }


        public async Task<List<ClienteModel>> GetByClientId(int Id)
        {
            var res = _context.Clientes.Where(z => z.ClienteId == Id).ToList();
            if (res.Count != 0)
            {
                var map = _mapper.Map<List<ClienteModel>>(res);
                return await Task.FromResult(map);
            }
            else
            {
                return null;
            }
        }

        public async Task<bool> CreateOrUpdate(ClienteRequest model)
        {
            var map = _mapper.Map<ClienteEntitie>(model);

            if (map.ClienteId != 0)
            {
                _context.Clientes.Update(map);
                var res = _context.SaveChangesAsync();
                return await Task.FromResult(Convert.ToBoolean(res.Result));
            }
            else
            {
                var exist = _context.Clientes.Where(_x => _x.ClienteId == map.ClienteId).FirstOrDefault();
                if (exist != null)
                {
                    return false;
                }
                _context.Clientes.Add(map);
                var res = _context.SaveChangesAsync();
                return await Task.FromResult(Convert.ToBoolean(res.Result));
            }
        }

        public async Task<bool> Delete(int id)
        {
            if (id != 0)
            {
                var clienteDeleted = _context.Clientes.Where(x => x.ClienteId == id).FirstOrDefault();
                _context.Clientes.Remove(clienteDeleted);
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
