using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Aerolinea.Models
{
    public class Vuelo
    {
        [Key]
        public string IdVuelo { get; set; }
        public string Nombre_Vuelo { get; set; }

        public DateTime Fecha_Salida { get; set; }
        public DateTime Fecha_Entrada { get; set; }
        public string Origen { get; set; }
        public string Destino { get; set; }
    }
}
