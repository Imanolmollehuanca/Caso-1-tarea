using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Caso_1_tarea.Services.Interfaces;

namespace Caso_1_tarea.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InventarioController : ControllerBase
    {
        private readonly IProductosService _productosService;

        public InventarioController(IProductosService productosService)
        {
            _productosService = productosService;
        }

        [HttpPost("entrada")]
        public async Task<IActionResult> RegistrarEntrada(int productoId, int cantidad, string observacion = "Entrada de stock")
        {
            var resultado = await _productosService.RegistrarEntradaAsync(productoId, cantidad, observacion);
            if (!resultado) return BadRequest("No se pudo registrar la entrada. Verifique los datos.");
            
            return Ok(new { mensaje = "Entrada registrada correctamente en el inventario." });
        }

        [HttpPost("salida")]
        public async Task<IActionResult> RegistrarSalida(int productoId, int cantidad, string observacion = "Salida de stock")
        {
            var resultado = await _productosService.RegistrarSalidaAsync(productoId, cantidad, observacion);
            if (!resultado) return BadRequest("No se pudo registrar la salida. Stock insuficiente o datos inválidos.");

            return Ok(new { mensaje = "Salida registrada correctamente en el inventario." });
        }
    }
}