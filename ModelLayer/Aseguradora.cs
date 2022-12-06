using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
    public class Aseguradora
    {
        int idAseguradora;
        string nombre;
        string fechaCreacion;
        string fechaModificacion;
        List<Object> aseguradoras;

        ModelLayer.Usuario usuario;

        public int IdAseguradora { get => idAseguradora; set => idAseguradora = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string FechaCreacion { get => fechaCreacion; set => fechaCreacion = value; }
        public string FechaModificacion { get => fechaModificacion; set => fechaModificacion = value; }
        public ModelLayer.Usuario Usuario { get => usuario; set => usuario = value; }
        public List<object> Aseguradoras { get => aseguradoras; set => aseguradoras = value; }
    }
}
