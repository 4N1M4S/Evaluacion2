using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Evaluación_2.Models
{
    public class Producto
    {
        [Key]
        public int ID { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public int precio { get; set; }
        public int stock { get; set; }
        public int CategoriaID { get; set; }
        [ForeignKey("CategoriaID")]
        public bool estado { get; set; }

        public virtual Categoria Categoria { get; set; }
    }
}
