namespace Caso_1_tarea.Models;

public class Alerta
{
    public int Id { get; set; }
    public int ProductoId { get; set; }
    public string NombreProducto { get; set; } = null!;
    public int StockActual { get; set; }
    public int StockMinimo { get; set; }
    public DateTime FechaGeneracion { get; set; } = DateTime.Now;
    public string Mensaje { get; set; } = null!;
}
