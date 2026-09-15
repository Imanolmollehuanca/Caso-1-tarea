using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Caso_1_tarea.Models;
using Caso_1_tarea.Services.Interfaces;

namespace Caso_1_tarea.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductosController : ControllerBase
    {
        private readonly IProductosService _productosService;

        public ProductosController(IProductosService productosService)
        {
            _productosService = productosService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var productos = await _productosService.ObtenerTodosAsync();
            return Ok(productos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var producto = await _productosService.ObtenerPorIdAsync(id);
            if (producto == null) return NotFound("Producto no encontrado.");
            return Ok(producto);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Producto producto)
        {
            await _productosService.CrearAsync(producto);
            return Ok(new { mensaje = "Producto creado exitosamente", producto });
        }
    }
}