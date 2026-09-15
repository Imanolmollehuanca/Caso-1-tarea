using Caso_1_tarea.Models;

namespace Caso_1_tarea.Services;

public class ProveedorService : IProveedorService
{
    private readonly List<Proveedor> _proveedores = new();

    public async Task<IEnumerable<Proveedor>> GetAllAsync() => await Task.FromResult(_proveedores);

    public async Task CreateAsync(Proveedor proveedor)
    {
        _proveedores.Add(proveedor);
        await Task.CompletedTask;
    }
}