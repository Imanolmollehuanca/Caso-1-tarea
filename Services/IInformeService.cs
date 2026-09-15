using Caso_1_tarea.Models;
 
namespace Caso_1_tarea.Services;
 
public interface IInformeService
{
    List<EstadoInventarioDto> GenerarEstadoInventario(IEnumerable<Producto> productos);
    List<EstadoInventarioDto> GenerarProductosStockBajo(IEnumerable<Producto> productos);
    List<MovimientoHistorialDto> GenerarHistorialMovimientos(IEnumerable<MovimientosInventario> movimientos);
    List<ProductoMasVendidoDto> GenerarProductosMasVendidos(IEnumerable<MovimientosInventario> movimientos, int topN = 5);
}