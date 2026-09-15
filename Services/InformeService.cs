using Caso_1_tarea.Models;
 
namespace Caso_1_tarea.Services;
 
public class InformeService : IInformeService
{
    public List<EstadoInventarioDto> GenerarEstadoInventario(IEnumerable<Producto> productos)
    {
        return productos.Select(p => new EstadoInventarioDto
        {
            ProductoId = p.Id,
            Nombre = p.Nombre,
            Categoria = p.Categoria,
            CantidadEnInventario = p.CantidadEnInventario,
            StockMinimo = p.StockMinimo,
            Precio = p.Precio
        }).ToList();
    }
 
    public List<EstadoInventarioDto> GenerarProductosStockBajo(IEnumerable<Producto> productos)
    {
        return GenerarEstadoInventario(productos).Where(dto => dto.StockBajo).ToList();
    }
 
    public List<MovimientoHistorialDto> GenerarHistorialMovimientos(IEnumerable<MovimientoInventario> movimientos)
    {
        return movimientos
            .OrderByDescending(m => m.Fecha)
            .Select(m => new MovimientoHistorialDto
            {
                ProductoId = m.ProductoId,
                TipoMovimiento = m.TipoMovimiento.ToString(),
                Cantidad = m.Cantidad,
                Fecha = m.Fecha
            }).ToList();
    }
 
    public List<ProductoMasVendidoDto> GenerarProductosMasVendidos(IEnumerable<MovimientoInventario> movimientos, int topN = 5)
    {
        return movimientos
            .Where(m => m.TipoMovimiento.ToString() == "Salida")
            .GroupBy(m => m.ProductoId)
            .Select(g => new ProductoMasVendidoDto
            {
                ProductoId = g.Key,
                CantidadVendida = g.Sum(m => m.Cantidad)
            })
            .OrderByDescending(dto => dto.CantidadVendida)
            .Take(topN)
            .ToList();
    }
}