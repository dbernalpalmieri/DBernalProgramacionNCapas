using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Rol
    {
        byte idRol;
        string nombre;
        List<object> roles;

        [Required]
        [DisplayName("Rol")]
        public byte IdRol { get => idRol; set => idRol = value; }
        //[Display(Name = "Rol")]
        [DisplayName("Rol")]
        public string Nombre { get => nombre; set => nombre = value; }
        public List<object> Roles { get => roles; set => roles = value; }
    }
}
