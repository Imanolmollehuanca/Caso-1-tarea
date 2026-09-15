using System;
using System.Threading.Tasks;
using Caso_1_tarea.Models;

namespace Caso_1_tarea.Repositories.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Producto> Productos { get; }
        IGenericRepository<MovimientosInventario> MovimientosInventario { get; }
        Task<int> CompleteAsync();
    }
}