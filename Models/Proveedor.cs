namespace Caso_1_tarea.Models;

public class Proveedor
{
    public int Id { get; set; }
    public string Nombre { get; set; } = null!;
    public string RucDocumento { get; set; } = null!;
    public string? Email { get; set; }
    public string? Telefono { get; set; }
    public string? Direccion { get; set; }

    public virtual ICollection<PedidoCompra> PedidosCompra { get; set; } = new List<PedidoCompra>();
}