using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Evaluación_2.Models;

namespace Evaluación_2.Data
{
    public class Evaluación_2Context : DbContext
    {
        public Evaluación_2Context (DbContextOptions<Evaluación_2Context> options)
            : base(options)
        {
        }

        public DbSet<Evaluación_2.Models.Categoria>? Categoria { get; set; }

        public DbSet<Evaluación_2.Models.Producto>? Producto { get; set; }
    }
}
