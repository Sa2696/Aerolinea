using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Aerolinea.Models
{
    public class Empleado
    {
        
       public string Id { get; set; } 
       public string Nombre { get; set; }

       public string Direccion { get; set; }
       public long Telefono { get; set; }
       public string Cargo { get; set; }

    }
}
