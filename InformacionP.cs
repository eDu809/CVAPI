using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CVAPI.Models
{
    public class InformacionP
    {
        [Key]
        public int Id_Persona { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public Decimal Edad { get; set; }
        public Decimal Cedula { get; set; }
        public string Direccion { get; set; }
        public Decimal Telefono { get; set; }

    }
}
