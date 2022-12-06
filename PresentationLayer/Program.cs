using ConsoleTables;
using System;
using System.Collections.Generic;

namespace PresentationLayer
{
    internal class Program
    {
        static void Main(string[] args)
        {

            /*Configuraciones de la consola*/
            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            Console.BufferWidth = 300;
            Console.ForegroundColor = ConsoleColor.Cyan;
            do
            {
                printMenu();
                Console.ReadLine();

            } while (true);
        }

        static void Redireccionar(double opcion)
        {
            switch (opcion)
            {
                case 1.1: Usuario.Add(); break;
                case 1.2: Empresa.Add(); break;

                case 2.1: Usuario.Update(); break;
                case 2.2: Empresa.Update(); break;

                case 3.1: Usuario.Delete(); break;
                case 3.2: Empresa.Delete(); break;

                case 4.1: Usuario.GetAll(); break;
                case 4.2: Empresa.GetAll();  break;

                case 5.1: Usuario.GetById(); break;
                case 5.2: Empresa.GetById(); break;

                case 6: System.Environment.Exit(0); break;
                default: Console.WriteLine("Opción invalida"); break;

            }
        }

        static double opcion = 0;
        static bool correcto = false;
        public static void printMenu()
        {

            Console.WriteLine("Escoge una opción");
            List<string> listTables = new List<string> { "Acciones", "Usuario", "Empresa" };
            List<string[]> listOptions = new List<string[]>
            {
                new []{"Insertar","1.1","1.2" },
                new []{"Actualizar","2.1","2.2" },
                new []{"Borrar","3.1","3.2" },
                new []{"Ver datos","4.1","4.2" },
                new []{"Buscar por Id","5.1","5.2" },
                new []{"Salir","6"," " },
            };
            var table = new ConsoleTable(listTables.ToArray());
            listOptions.ForEach(item =>
            {
                table.AddRow(item);
            });
            table.Write(Format.Alternative);


            Console.Write($"Opción: ");
            correcto = double.TryParse(Console.ReadLine(), out opcion);

            Redireccionar(opcion);

        }
    }
}
