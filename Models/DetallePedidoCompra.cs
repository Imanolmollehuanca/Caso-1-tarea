namespace Caso_1_tarea.Models;

public class DetallePedidoCompra
{
    public int Id { get; set; }
    public int PedidoCompraId { get; set; }
    public int ProductoId { get; set; }
    public int Cantidad { get; set; }
    public decimal PrecioUnitario { get; set; }

    public virtual PedidoCompra PedidoCompra { get; set; } = null!;
}