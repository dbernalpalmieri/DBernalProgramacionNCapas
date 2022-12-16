using ConsoleTables;
using ML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    public class Empresa
    {
        public static void Add()
        {
            ML.Empresa empresa = new ML.Empresa();

            empresa = getData(empresa);
            if (empresa != null)
            {
                // Ejecutamos la operación en la base de datos
                Result result = BL.Empresa.AddLinq(empresa);

                print(result.Message, "");
                if (result.Correct)
                {
                    empresa = (ML.Empresa)result.Object;

                    result = GetById(empresa.IdEmpresa);
                    //result = BusinessLayer.Empresa.GetByIdEF(empresa.IdEmpresa);
                    printTable(result);
                }
            }
        }

        public static void Update()
        {
            ML.Empresa empresa = new ML.Empresa();
            print("Escribe los datos de la empresa a modificar", "");
            print("Id Empresa: ");
            empresa.IdEmpresa = int.Parse(Console.ReadLine());

            Result result = GetById(empresa.IdEmpresa);
            print(result.Message, "");

            if (result.Correct && result.Object != null)
            {
                printTable(result);

                empresa = getData(empresa);
                if (empresa != null)
                {
                    // Ejecutamos la operación en la base de datos
                    result = BL.Empresa.UpdateLinq(empresa);

                    print(result.Message, "");
                    if (result.Correct)
                    {
                        result = GetById(empresa.IdEmpresa);
                        printTable(result);
                    }
                }
            }
        }

        public static void Delete()
        {
            ML.Empresa empresa = new ML.Empresa();
            print("Escribe los datos de la empresa a eliminar", "");
            print("Id Empresa: ");
            empresa.IdEmpresa = int.Parse(Console.ReadLine());

            Result result = GetById(empresa.IdEmpresa);
            print(result.Message, "");

            if (result.Correct && result.Object != null)
            {
                printTable(result);
                print("¿Estas seguro de eliminar este registro? (S/N): ");
                string eliminar = Console.ReadLine().ToLower();
                if (eliminar.Equals("s"))
                {
                    // Ejecutamos la operación en la base de datos
                    result = BL.Empresa.DeleteLinq(empresa.IdEmpresa);
                    print(result.Message, "");
                    if (result.Correct)
                    {
                        GetAll();
                    }
                }
                else
                {
                    print("Ninguna acción realizada.", "");
                }
            }

        }

        public static void GetById()
        {
            ML.Empresa empresa = new ML.Empresa();
            print("Escribe los datos de la empresa a encontrar", "");
            print("Id Empresa: ");
            empresa.IdEmpresa = int.Parse(Console.ReadLine());

            Result result = GetById(empresa.IdEmpresa);

            print(result.Message, "");
            if (result.Correct && result.Object != null)
            {
                printTable(result);
            }
        }

        public static Result GetById(int IdEmpresa)
        {
            // Ejecutamos la operación en la base de datos
            Result result = BL.Empresa.GetByIdLinq(IdEmpresa);
            return result;
        }

        public static void GetAll()
        {
            // Ejecutamos la operación en la base de datos
            Result result = BL.Empresa.GetAllLinq();
            print(result.Message, "");
            if (result.Correct && result.Objects.Count > 0)
            {
                printTable(result);
            }
        }

        static void printTable(Result result)
        {
            //Column column = new Column();
            //column = BusinessLayer.Usuario.getColumsName();
            //var camposName = column.Columns.ToArray();

            var table = new ConsoleTable("Id Empresa", "Nombre", "Teléfono", "Email", "Dirección Web");

            ML.Empresa tempEmpresa = null;
            if (result.Objects != null)
            {
                result.Objects.ForEach(obj =>
                {
                    tempEmpresa = obj as ML.Empresa;
                    table.AddRow(
                        tempEmpresa.IdEmpresa,
                        tempEmpresa.Nombre,
                        tempEmpresa.Telefono,
                        tempEmpresa.Email,
                        tempEmpresa.DireccionWeb);
                });
            }
            else
            {
                tempEmpresa = result.Object as ML.Empresa;
                table.AddRow(
                        tempEmpresa.IdEmpresa,
                        tempEmpresa.Nombre,
                        tempEmpresa.Telefono,
                        tempEmpresa.Email,
                        tempEmpresa.DireccionWeb);
            }
            table.Write(Format.Alternative);
        }

        static void print(string mensaje) => Console.Write(mensaje);
        static void print(string mensaje, string mensajeDos = "") => Console.WriteLine(mensaje);

        static ML.Empresa getData(ML.Empresa empresa)
        {
            try
            {
                print("Escribe los datos de la empresa", "");
                print("Nombre: ");
                empresa.Nombre = Console.ReadLine();

                print("Teléfono: ");
                empresa.Telefono = Console.ReadLine();

                print("Correo Electrónico: ");
                empresa.Email = Console.ReadLine();

                print("Dirección Web: ");
                empresa.DireccionWeb = Console.ReadLine();


            }
            catch (Exception error)
            {
                print($"Datos ingresados incorrectos, error '{error.Message}'", "");
                empresa = null;
            }
            return empresa;
        }
    }
}
