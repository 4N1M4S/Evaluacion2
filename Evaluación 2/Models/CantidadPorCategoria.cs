namespace Evaluación_2.Models
{
    public class CantidadPorCategoria
    {
        public string Nombre { get; set; }
        public int Cantidad { get; set; }

        public CantidadPorCategoria(string nombre, int cantidad)
        {
            this.Nombre = nombre;
            this.Cantidad = cantidad;
        }

        public CantidadPorCategoria()
        {
        }
    }
}
