namespace Caso_1_tarea.Models;

public class MovimientoHistorialDto
{
    public int ProductoId { get; set; }
    public string NombreProducto { get; set; } = null!;
    public string TipoMovimiento { get; set; } = null!;
    public int Cantidad { get; set; }
    public DateTime Fecha { get; set; }
}
