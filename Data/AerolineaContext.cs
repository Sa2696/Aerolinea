using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Aerolinea.Models;

namespace Aerolinea.Models
{
    public class AerolineaContext : DbContext
    {
        public AerolineaContext(DbContextOptions<AerolineaContext> options)
            : base(options)
        {
        }

        public DbSet<Aerolinea.Models.Avion> Avion { get; set; }

        public DbSet<Aerolinea.Models.Empleado> Empleado { get; set; }

        public DbSet<Aerolinea.Models.Vuelo> Vuelo { get; set; }

        public DbSet<Aerolinea.Models.Cliente> Cliente { get; set; }

        public DbSet<Aerolinea.Models.Categoria_Vuelo> Categoria_Vuelo { get; set; }
    }
}
