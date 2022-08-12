using DigitalWare.CORE.ProductosCore.Interfaces;
using DigitalWare.MODELS.Requests;
using Microsoft.AspNetCore.Mvc;

namespace DigitalWare.API.Controllers.Productos
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        #region Dependency
        private readonly IProductosCore _producto;
        #endregion

        #region Constructor
        public ProductosController(IProductosCore producto)
        {
            _producto = producto;
        }
        #endregion

        #region Methods

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var res = await _producto.GetAll();
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
                var res = await _producto.GetByClientId(Id);
                return res != null ? Ok(res) : NotFound();
            }
            catch (Exception e)
            {
                return NotFound(e);
            }
        }



        [HttpPost]
        public async Task<IActionResult> CreateOrUpdate(ProductoRequest model)
        {
            try
            {
                var res = await _producto.CreateOrUpdate(model);
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
                var res = await _producto.Delete(id);
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
