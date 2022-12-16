using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Empresa
    {
        int idEmpresa;
        string nombre;
        string telefono;
        string email;
        string direccionWeb;
        string logo;
        List<object> empresas;

        public int IdEmpresa { get => idEmpresa; set => idEmpresa = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string Email { get => email; set => email = value; }
        public string DireccionWeb { get => direccionWeb; set => direccionWeb = value; }
        public string Logo { get => logo; set => logo = value; }
        public List<object> Empresas { get => empresas; set => empresas = value; }
    }
}
