using System.Threading.Tasks;
using Caso_1_tarea.Data;
using Caso_1_tarea.Models;
using Caso_1_tarea.Repositories.Interfaces;

namespace Caso_1_tarea.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public IGenericRepository<Producto> Productos { get; }
        public IGenericRepository<MovimientoInventario> MovimientosInventario { get; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Productos = new GenericRepository<Producto>(_context);
            MovimientosInventario = new GenericRepository<MovimientoInventario>(_context);
        }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}