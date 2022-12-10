using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SL_WCF
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Operaciones" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Operaciones.svc o Operaciones.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Operaciones : IOperaciones
    {
        
        public int Add(int numeroUno, int numeroDos)
        {
            return numeroUno + numeroDos;
        }

        public int Sub(int numeroUno, int numeroDos)
        {
            return numeroUno - numeroDos;
        }

        public int Mul(int numeroUno, int numeroDos)
        {
            return numeroUno * numeroDos;
        }
        public int Div(int numeroUno, int numeroDos)
        {
            return numeroUno / numeroDos;
        }
        public string Saludar(string nombre)
        {
            return $"Hola {nombre}";
        }
    }
}
