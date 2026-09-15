using System;
using System.Collections.Generic;

namespace Caso_1_tarea.Models;

public partial class Producto
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public decimal Precio { get; set; }

    public string Categoria { get; set; } = null!;

    public int CantidadEnInventario { get; set; }

    public int StockMinimo { get; set; }

    public virtual ICollection<MovimientosInventario> MovimientosInventarios { get; set; } = new List<MovimientosInventario>();
}
