using Microsoft.AspNetCore.Mvc;
using Caso_1_tarea.Services;
using Caso_1_tarea.Services.Interfaces;
 
namespace Caso_1_tarea.Controllers;
 
[ApiController]
[Route("api/[controller]")]
public class InformesController : ControllerBase
{
    private readonly IInformeService _informeService;
    private readonly IProductosService _productosService;
 
    public InformesController(IInformeService informeService, IProductosService productosService)
    {
        _informeService = informeService;
        _productosService = productosService;
    }
 
    [HttpGet("estado-inventario")]
    public async Task<IActionResult> EstadoInventario()
    {
        var productos = await _productosService.ObtenerTodosAsync();
        return Ok(_informeService.GenerarEstadoInventario(productos));
    }
 
    [HttpGet("stock-bajo")]
    public async Task<IActionResult> StockBajo()
    {
        var productos = await _productosService.ObtenerTodosAsync();
        return Ok(_informeService.GenerarProductosStockBajo(productos));
    }
    
}