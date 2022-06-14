using Microsoft.EntityFrameworkCore;

namespace Evaluación_2.Models
{
    [Keyless]
    public class Estadísticas
    {
        public List<CantidadPorCategoria> DatosProductos { get; set; }
        public int PromedioPrecios { get; set; }

        public Estadísticas(List<CantidadPorCategoria> datosProductos, int promedioPrecios)
        {
            DatosProductos = datosProductos;
            PromedioPrecios = promedioPrecios;
        }

        public Estadísticas()
        {
        }
    }
}
