using Caso_1_tarea.Models;
using Caso_1_tarea.Services.Interfaces;

namespace Caso_1_tarea.Services;
 
public class AlertaService : IAlertaService
{
    private readonly List<Alerta> _alertasActivas = new();
    private int _siguienteId = 1;
 
    public List<Alerta> GenerarAlertasStockBajo(IEnumerable<Producto> productos)
    {
        var nuevasAlertas = new List<Alerta>();
 
        foreach (var producto in productos)
        {
            if (producto.CantidadEnInventario <= producto.StockMinimo)
            {
                var alerta = new Alerta
                {
                    Id = _siguienteId++,
                    ProductoId = producto.Id,
                    NombreProducto = producto.Nombre,
                    StockActual = producto.CantidadEnInventario,
                    StockMinimo = producto.StockMinimo,
                    Mensaje = $"El producto '{producto.Nombre}' necesita reposición " +
                              $"(stock actual: {producto.CantidadEnInventario}, mínimo: {producto.StockMinimo})"
                };
 
                nuevasAlertas.Add(alerta);
                _alertasActivas.Add(alerta);
            }
        }
 
        return nuevasAlertas;
    }
 
    public List<Alerta> ObtenerAlertasActivas()
    {
        return _alertasActivas.ToList();
    }
}