using System;
using System.Collections.Generic;

namespace Caso_1_tarea.Models;

public partial class MovimientosInventario
{
    public int Id { get; set; }

    public int ProductoId { get; set; }

    public string Tipo { get; set; } = null!;

    public int Cantidad { get; set; }

    public DateTime? Fecha { get; set; }

    public string? Observacion { get; set; }

    public virtual Producto Producto { get; set; } = null!;
}
