using Caso_1_tarea.Models;

namespace Caso_1_tarea.Services;

public interface IProveedorService
{
    Task<IEnumerable<Proveedor>> GetAllAsync();
    Task CreateAsync(Proveedor proveedor);
}