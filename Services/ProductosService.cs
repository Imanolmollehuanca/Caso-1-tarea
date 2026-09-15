using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Caso_1_tarea.Models;
using Caso_1_tarea.Repositories.Interfaces;
using Caso_1_tarea.Services.Interfaces;

namespace Caso_1_tarea.Services
{
    public class ProductosService : IProductosService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductosService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Producto>> ObtenerTodosAsync()
        {
            return await _unitOfWork.Productos.GetAllAsync();
        }

        public async Task<Producto?> ObtenerPorIdAsync(int id)
        {
            return await _unitOfWork.Productos.GetByIdAsync(id);
        }

        public async Task CrearAsync(Producto producto)
        {
            await _unitOfWork.Productos.AddAsync(producto);
            await _unitOfWork.CompleteAsync();
        }

        public async Task<bool> RegistrarEntradaAsync(int productoId, int cantidad, string observacion)
        {
            var producto = await _unitOfWork.Productos.GetByIdAsync(productoId);
            if (producto == null || cantidad <= 0) return false;

            producto.CantidadEnInventario += cantidad;
            _unitOfWork.Productos.Update(producto);

            var movimiento = new MovimientosInventario
            {
                ProductoId = productoId,
                Tipo = "ENTRADA",
                Cantidad = cantidad,
                Fecha = DateTime.Now,
                Observacion = observacion
            };

            await _unitOfWork.MovimientosInventario.AddAsync(movimiento);
            await _unitOfWork.CompleteAsync();
            return true;
        }

        public async Task<bool> RegistrarSalidaAsync(int productoId, int cantidad, string observacion)
        {
            var producto = await _unitOfWork.Productos.GetByIdAsync(productoId);
            if (producto == null || cantidad <= 0 || producto.CantidadEnInventario < cantidad)
            {
                return false;
            }

            producto.CantidadEnInventario -= cantidad;
            _unitOfWork.Productos.Update(producto);

            var movimiento = new MovimientosInventario
            {
                ProductoId = productoId,
                Tipo = "SALIDA",
                Cantidad = cantidad,
                Fecha = DateTime.Now,
                Observacion = observacion
            };

            await _unitOfWork.MovimientosInventario.AddAsync(movimiento);
            await _unitOfWork.CompleteAsync();
            return true;
        }
    }
}