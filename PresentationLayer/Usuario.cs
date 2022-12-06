using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLayer;
using BusinessLayer;
using ConsoleTables;


namespace PresentationLayer
{
    public class Usuario
    {
        public static void Add()
        {
            ModelLayer.Usuario usuario = new ModelLayer.Usuario();

            usuario = getData(usuario);
            if (usuario != null)
            {
                // Ejecutamos la operación en la base de datos
                Result result = BusinessLayer.Usuario.AddLinq(usuario);

                print(result.Message, "");
                if (result.Correct)
                {
                    usuario = (ModelLayer.Usuario)result.Object;

                    result = GetById(usuario.IdUsuario);
                    //result = BusinessLayer.Usuario.GetByIdEF(usuario.IdUsuario);
                    printTable(result);
                }
            }
        }
        public static void Update()
        {
            ModelLayer.Usuario usuario = new ModelLayer.Usuario();
            Result result;

            print("Escribe los datos del usuario a modificar", "");
            print("Id Usuario: ");
            usuario.IdUsuario = int.Parse(Console.ReadLine());

            result = GetById(usuario.IdUsuario);
            print(result.Message, "");

            if (result.Correct && result.Object != null)
            {
                printTable(result);

                usuario = getData(usuario);
                if (usuario != null)
                {
                    // Ejecutamos la operación en la base de datos
                    result = BusinessLayer.Usuario.UpdateLinq(usuario);
                    print(result.Message, "");
                    
                    if (result.Correct)
                    {
                        result = GetById(usuario.IdUsuario);
                        printTable(result);
                    }
                }
            }
        }
        public static void Delete()
        {
            ModelLayer.Usuario usuario = new ModelLayer.Usuario();
            Result result;

            print("Escribe los datos del usuario a eliminar", "");
            print("Id Usuario: ");
            usuario.IdUsuario = int.Parse(Console.ReadLine());

            result = GetById(usuario.IdUsuario); ;
            print(result.Message, "");

            if (result.Correct && result.Object != null)
            {
                printTable(result);
                print("¿Estas seguro de eliminar este registro? (S/N): ");
                string eliminar = Console.ReadLine().ToLower();
                if (eliminar.Equals("s"))
                {
                    // Ejecutamos la operación en la base de datos
                    result = BusinessLayer.Usuario.DeleteLinq(usuario.IdUsuario);
                    print(result.Message,"");
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

        public static void GetAll()
        {
            // Ejecutamos la operación en la base de datos
            Result result = BusinessLayer.Usuario.GetAllLinq();
            print(result.Message, "");
            if (result.Correct && result.Objects.Count > 0)
            {
                printTable(result);
            }
        }
        public static void GetById()
        {
            ModelLayer.Usuario usuario = new ModelLayer.Usuario();

            print("Escribe los datos del usuario a encontrar", "");
            print("Id Usuario: ");
            usuario.IdUsuario = int.Parse(Console.ReadLine());

            Result result = GetById(usuario.IdUsuario);

            print(result.Message, "");
            if (result.Correct && result.Object != null)
            {
                printTable(result);
            }
        }

        public static Result GetById(int IdUsuario)
        {
            // Ejecutamos la operación en la base de datos
            Result result = BusinessLayer.Usuario.GetByIdLinq(IdUsuario);
            return result;
        }

        static void printTable(Result result)
        {
            //Column column = new Column();
            //column = BusinessLayer.Usuario.getColumsName();
            //var camposName = column.Columns.ToArray();

            var table = new ConsoleTable("Id Usuario", "Nombre", "Apellido Paterno", "Apellido Materno", "Sexo", "Fecha Nacimiento", "Email", "Password", "User Name", "Teléfono", "Celular", "CURP", "Id Rol");

            ModelLayer.Usuario tempUser = null;
            if (result.Objects != null)
            {
                result.Objects.ForEach(obj =>
                {
                    tempUser = (ModelLayer.Usuario)obj;
                    table.AddRow(
                        tempUser.IdUsuario,
                        tempUser.Nombre,
                        tempUser.ApellidoPaterno,
                        tempUser.ApellidoMaterno,
                        tempUser.Sexo,
                        tempUser.FechaNacimiento,
                        tempUser.Email,
                        tempUser.Password,
                        tempUser.UserName,
                        tempUser.Telefono,
                        tempUser.Celular,
                        tempUser.Curp,
                        tempUser.Rol.IdRol);
                });
            }
            else
            {
                tempUser = result.Object as ModelLayer.Usuario;
                table.AddRow(
                    tempUser.IdUsuario,
                    tempUser.Nombre,
                    tempUser.ApellidoPaterno,
                    tempUser.ApellidoMaterno,
                    tempUser.Sexo,
                    tempUser.FechaNacimiento,
                    tempUser.Email,
                    tempUser.Password,
                    tempUser.UserName,
                    tempUser.Telefono,
                    tempUser.Celular,
                    tempUser.Curp,
                    tempUser.Rol.IdRol);
            }

            table.Write(Format.Alternative);
        }

        static void print(string mensaje) => Console.Write(mensaje);
        static void print(string mensaje, string mensajeDos = "") => Console.WriteLine(mensaje);

        static ModelLayer.Usuario getData(ModelLayer.Usuario usuario)
        {
            bool correct = true;
            try
            {
                print("Escribe los datos del usuario", "");

                print("Nombre: ");
                usuario.Nombre = Console.ReadLine();

                print("Apellido Paterno: ");
                usuario.ApellidoPaterno = Console.ReadLine();

                print("Apellido Materno: ");
                usuario.ApellidoMaterno = Console.ReadLine();

                print("Sexo (M/F): ");
                usuario.Sexo = char.Parse(Console.ReadLine());

                print("Fecha de Nacimiento (DD/MM/YYYY): ");
                usuario.FechaNacimiento = Console.ReadLine();
                correct = DateTime.TryParseExact(usuario.FechaNacimiento, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out _);
                //usuario.FechaNacimiento = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture);

                print("Correo Electrónico: ");
                usuario.Email = Console.ReadLine();

                print("Contraseña: ");
                usuario.Password = Console.ReadLine();

                print("Nick Name: ");
                usuario.UserName = Console.ReadLine();

                print("Teléfono de casa: ");
                usuario.Telefono = Console.ReadLine();
                //correct = long.TryParse(usuario.Telefono, out _) && usuario.Telefono.Length >= 10;

                print("Teléfono Celular: ");
                usuario.Celular = Console.ReadLine();
                //correct = long.TryParse(usuario.Celular, out _) && usuario.Celular.Length >= 10;

                print("CURP: ");
                usuario.Curp = Console.ReadLine();

                print("Número de Rol: ");
                usuario.Rol = new ModelLayer.Rol();
                usuario.Rol.IdRol = byte.Parse(Console.ReadLine());

                if (!correct)
                {
                    print($"Datos ingresados incorrectos, vuelve a intentarlo", "");
                    usuario = null;
                }


            }
            catch (Exception error)
            {
                print($"Datos ingresados incorrectos, error '{error.Message}'", "");
                usuario = null;
            }
            return usuario;
        }
    }


}





















//Result result = BusinessLayer.Usuario.getColumsName();

//print(result.Message, "");
//if (result.Correct && result.Objects.Count > 0)
//{
//    printTable(result);
//}



//public static void AddStore()
//{
//    ModelLayer.Usuario usuario = new ModelLayer.Usuario();


//    usuario.Nombre = "Jose";
//    usuario.ApellidoPaterno = "Matias";
//    usuario.ApellidoMaterno = "Escobedo";
//    usuario.Sexo = 'M';
//    usuario.FechaNacimiento = DateTime.ParseExact("20/09/1999", "dd/MM/yyyy", CultureInfo.InvariantCulture);
//    usuario.Correo = "joseph@gmail.com";
//    usuario.Password = "12345";
//    usuario.UserName = "jose";
//    usuario.IdRol = 4;


//    /* Mandamos a la capa correspondiente el objeto lleno*/
//    Result result = BusinessLayer.Usuario.Insert(usuario);

//    print("Mensaje: " + result.Message);
//    if (result.Correct)
//    {
//        usuario = (ModelLayer.Usuario)result.Object;
//        result = BusinessLayer.Usuario.GetById(usuario);
//        printTable(result);
//    }
//}