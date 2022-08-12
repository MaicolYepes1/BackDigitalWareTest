using DigitalWare.CORE.ClientesCore.Interfaces;
using DigitalWare.MODELS.Requests;
using Microsoft.AspNetCore.Mvc;

namespace DigitalWare.API.Controllers.Clientes
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        #region Dependency
        private readonly IClientesCore _cliente;
        #endregion

        #region Constructor
        public ClientesController(IClientesCore cliente)
        {
            _cliente = cliente;
        }
        #endregion

        #region Methods

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var res = await _cliente.GetAll();
                return res != null ? Ok(res) : NotFound();
            }
            catch (Exception e)
            {
                return NotFound(e);
            }
        }


        [HttpGet]
        [Route("GetByClientId/{Id}")]
        public async Task<IActionResult> GetByClientId(int Id)
        {
            try
            {
                var res = await _cliente.GetByClientId(Id);
                return res != null ? Ok(res) : NotFound();
            }
            catch (Exception e)
            {
                return NotFound(e);
            }
        }



        [HttpPost]
        public async Task<IActionResult> CreateOrUpdate(ClienteRequest model)
        {
            try
            {
                var res = await _cliente.CreateOrUpdate(model);
                return res != false ? Ok(res) : BadRequest();
            }
            catch (Exception e)
            {
                return NotFound(e);
            }
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var res = await _cliente.Delete(id);
                return res == false ? BadRequest() : Ok(res);
            }
            catch (Exception e)
            {
                return NotFound(e);
            }
        }
        #endregion
    }
}
