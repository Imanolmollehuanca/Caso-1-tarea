namespace Caso_1_tarea.Models;

public class PedidoCompra
{
    public int Id { get; set; }
    public int ProveedorId { get; set; }
    public DateTime FechaPedido { get; set; } = DateTime.Now;
    public string Estado { get; set; } = "Pendiente"; // Pendiente, Enviado, Recibido, Cancelado

    public virtual Proveedor Proveedor { get; set; } = null!;
    public virtual ICollection<DetallePedidoCompra> Detalles { get; set; } = new List<DetallePedidoCompra>();
}