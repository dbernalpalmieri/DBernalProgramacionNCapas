using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Usuario
    {
        int idUsuario;
        string nombre;
        string apellidoPaterno;
        string apellidoMaterno;
        char sexo;
        string fechaNacimiento;
        string email;
        string password;
        string userName;
        string telefono;
        string celular;
        string curp;
        ML.Rol rol;
        List<object> usuarios;
        ML.Direccion direccion;

        string imagen;

        bool status;

        string nombreCompleto;

        public int IdUsuario { get => idUsuario; set => idUsuario = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string ApellidoPaterno { get => apellidoPaterno; set => apellidoPaterno = value; }
        public string ApellidoMaterno { get => apellidoMaterno; set => apellidoMaterno = value; }
        public char Sexo { get => sexo; set => sexo = value; }
        public string FechaNacimiento { get => fechaNacimiento; set => fechaNacimiento = value; }
        public string Email { get => email; set => email = value; }
        public string Password { get => password; set => password = value; }
        public string UserName { get => userName; set => userName = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string Celular { get => celular; set => celular = value; }
        public string Curp { get => curp; set => curp = value; }
        public Rol Rol { get => rol; set => rol = value; }
        public List<object> Usuarios { get => usuarios; set => usuarios = value; }
        public Direccion Direccion { get => direccion; set => direccion = value; }
        public string Imagen { get => imagen; set => imagen = value; }
        public bool Status { get => status; set => status = value; }
        public string NombreCompleto { get => nombreCompleto; set => nombreCompleto = value; }
    }
}
