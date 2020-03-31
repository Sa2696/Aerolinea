using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Aerolinea.Models
{
    public class Avion
    {
       [Key]
        public string Serie { get; set; }
        public string Nombre { get; set; }
        public string Fabricante { get; set; }

        public Boolean Activo { get; set; }
        public Boolean Inactivo { get; set; }

    }
}
