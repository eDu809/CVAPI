using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CVAPI.Models
{
    public class ExperienciaL
    {
        [Key]
        public int Id_Experiencia { get; set; }
        public string Nombre_Empresa { get; set; }
        public string Posicion_Empresa { get; set; }
        public string Descripcion_Posicion { get; set; }
    }
}
