using Evaluación_2.Data;
using Evaluación_2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace Evaluación_2.Controllers
{
    public class EstadisticasController : Controller
    {
        private readonly Evaluación_2Context _context;

        public EstadisticasController(Evaluación_2Context context)
        {
            _context = context;
        }

        public dynamic ViewBag { get; set; }
        
        /// <summary>
        /// Método que retorna el stock total de una Categoría
        /// </summary>
        /// <param name="categoria"></param>
        /// <returns>
        /// Retorna el stock total
        /// </returns>
        public int TotalProductos(Categoria categoria)
        {
            int total = 0;
            var query = from p in _context.Producto where p.Categoria.ID == categoria.ID select p;
            foreach(var item in query)
            {
                total += item.stock;
            }
            return total;
        }

        /// <summary>
        /// Método que retorna el promedio de precios de una Categoría
        /// </summary>
        /// <param name="categoria"></param>
        /// <returns>
        /// Retorna el precio total
        /// </returns>
        public int PromedioPrecios(Categoria categoria)
        {
            int promedio = 0;
            var query = from p in _context.Producto where p.Categoria.ID == categoria.ID select p;
            foreach (var item in query)
            {
                promedio += item.precio;
            }

            promedio /= query.Count();

            return promedio;
        }

        /// <summary>
        /// Método que guarda una lista con los nombres de
        /// los Productos y el porcentaje que representan en
        /// el total de artículos de la Categoría
        /// </summary>
        /// <returns>
        /// Un List<CantidadPorCategoría> con lo antes mencionado
        /// </returns>
        public List<CantidadPorCategoria> GetPorcentajes(Categoria categoria)
        {
            List<CantidadPorCategoria> CantidadCategoria = new();

            //Query consigue todos los productos de la categoría actual
            var query = from p in _context.Producto where p.Categoria == categoria select p;

            //Revisa cada producto de la categoría
            foreach(var producto in query)
            {
                string nombre = producto.nombre;
                int porcentaje = (producto.stock * 100) / TotalProductos(categoria);
                CantidadPorCategoria datosProducto = new(nombre, porcentaje);
                CantidadCategoria.Add(datosProducto);
            }


            return CantidadCategoria;
        }

        public async Task<IActionResult> Index(int? id)
        {
            Console.WriteLine("Id: "+id);
            var categoria = await _context.Categoria
                .FirstOrDefaultAsync(m => m.ID == id);
            int precioPromedio = PromedioPrecios(categoria);
            List<CantidadPorCategoria> porcentajes = GetPorcentajes(categoria);
            Estadísticas estadísticas = new(porcentajes, precioPromedio);
            ViewData["Productos"] = estadísticas.DatosProductos;
            ViewData["Promedios"] = estadísticas.PromedioPrecios;
            return View(estadísticas);
        }
    }
}
