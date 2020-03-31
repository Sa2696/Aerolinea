using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Aerolinea.Models
{
    public class Categoria_Vuelo
    {
        [Key]
        public string SerieAvion { get; set; }
        public string Cliente { get; set; }
        public string Destino { get; set; }
        public DateTime Entrada { get; set; }
        public DateTime Salida { get; set; }
        public string Categorias  { get; set; }
    }
    public enum Categoria
    {

      Economica,
      Ejecutiva,
      PraClase




    }
}
