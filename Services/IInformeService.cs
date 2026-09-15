using Caso_1_tarea.Models;
 
namespace Caso_1_tarea.Services;
 
public interface IInformeService
{
    List<EstadoInventarioDto> GenerarEstadoInventario(IEnumerable<Producto> productos);
    List<EstadoInventarioDto> GenerarProductosStockBajo(IEnumerable<Producto> productos);
    List<MovimientoHistorialDto> GenerarHistorialMovimientos(IEnumerable<MovimientoInventario> movimientos);
    List<ProductoMasVendidoDto> GenerarProductosMasVendidos(IEnumerable<MovimientoInventario> movimientos, int topN = 5);
}