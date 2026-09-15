using System.Collections.Generic;
using System.Threading.Tasks;
using Caso_1_tarea.Models;

namespace Caso_1_tarea.Services.Interfaces
{
    public interface IProductosService
    {
        Task<IEnumerable<Producto>> ObtenerTodosAsync();
        Task<Producto?> ObtenerPorIdAsync(int id);
        Task CrearAsync(Producto producto);
        Task<bool> RegistrarEntradaAsync(int productoId, int cantidad, string observacion);
        Task<bool> RegistrarSalidaAsync(int productoId, int cantidad, string observacion);
    }
}