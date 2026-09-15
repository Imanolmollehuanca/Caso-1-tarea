using Microsoft.AspNetCore.Mvc;
using Caso_1_tarea.Services;
using Caso_1_tarea.Services.Interfaces;
 
namespace Caso_1_tarea.Controllers;
 
[ApiController]
[Route("api/[controller]")]
public class AlertasController : ControllerBase
{
    private readonly IAlertaService _alertaService;
    private readonly IProductosService _productosService;
 
    public AlertasController(IAlertaService alertaService, IProductosService productosService)
    {
        _alertaService = alertaService;
        _productosService = productosService;
    }
 
    // Genera nuevas alertas revisando el inventario actual
    [HttpGet("generar")]
    public async Task<IActionResult> Generar()
    {
        var productos = await _productosService.ObtenerTodosAsync();
        var alertas = _alertaService.GenerarAlertasStockBajo(productos);
        return Ok(alertas);
    }
 
    // Consulta las alertas ya generadas
    [HttpGet("activas")]
    public IActionResult Activas()
    {
        return Ok(_alertaService.ObtenerAlertasActivas());
    }
}