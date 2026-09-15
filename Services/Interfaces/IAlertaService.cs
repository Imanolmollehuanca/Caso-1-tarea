using Caso_1_tarea.Models;

namespace Caso_1_tarea.Services.Interfaces;

public interface IAlertaService
{
    List<Alerta> GenerarAlertasStockBajo(IEnumerable<Producto> productos);
    List<Alerta> ObtenerAlertasActivas();
}
