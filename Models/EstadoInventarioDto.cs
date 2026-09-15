namespace Caso_1_tarea.Models;

public class EstadoInventarioDto
{
    public int ProductoId { get; set; }
    public string Nombre { get; set; } = null!;
    public string Categoria { get; set; } = null!;
    public int CantidadEnInventario { get; set; }
    public int StockMinimo { get; set; }
    public decimal Precio { get; set; }
    public bool StockBajo => CantidadEnInventario <= StockMinimo;
}
