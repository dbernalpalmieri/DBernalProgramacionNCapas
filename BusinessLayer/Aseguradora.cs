using DataLayer_EF;
using ModelLayer;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;

namespace BusinessLayer
{
    public class Aseguradora
    {
        public static Result GetAll()
        {
            ModelLayer.Result result = new ModelLayer.Result();

            try
            {

                using (DBernalProgramacionNCapasEntities context = new DBernalProgramacionNCapasEntities())
                {
                    var execute = context.AseguradoraGet(null).ToList();

                    result.Objects = new List<object>();

                    if (execute.Count > 0)
                    {
                        ModelLayer.Aseguradora aseguradora = null;

                        foreach (var item in execute)
                        {
                            aseguradora = new ModelLayer.Aseguradora();
                            aseguradora.IdAseguradora = item.IdAseguradora;
                            aseguradora.Nombre = item.Nombre;
                            aseguradora.FechaCreacion = item.FechaCreacion.ToString();
                            aseguradora.FechaModificacion = item.FechaModificacion.ToString();

                            aseguradora.Usuario = new ModelLayer.Usuario();

                            aseguradora.Usuario.IdUsuario = item.IdUsuario;
                            aseguradora.Usuario.Nombre = item.NombreUsuario;
                            aseguradora.Usuario.ApellidoPaterno = item.ApellidoPaterno;
                            aseguradora.Usuario.ApellidoMaterno = item.ApellidoMaterno;

                            aseguradora.Usuario.NombreCompleto = $"{item.NombreUsuario} {item.ApellidoPaterno} {item.ApellidoMaterno}";

                            result.Objects.Add(aseguradora);

                        }



                        result.Correct = true;
                        result.Message = $"Información obtenida con éxito de la base de datos.";
                    }
                    else
                    {
                        result.Correct = true;
                        result.Message = $"404 NOT FOUND";
                    }
                }

            }
            catch (Exception error)
            {

                result.Correct = false;
                result.Exeption = error;
                result.Message = $"Ups ocurrió un error: {error.Message}";
            }

            return result;

        }

        public static Result GetById(int IdAseguradora)
        {
            ModelLayer.Result result = new ModelLayer.Result();

            try
            {

                using (DBernalProgramacionNCapasEntities context = new DBernalProgramacionNCapasEntities())
                {
                    var execute = context.AseguradoraGet(IdAseguradora).SingleOrDefault();


                    if (execute != null)
                    {
                        ModelLayer.Aseguradora aseguradora = new ModelLayer.Aseguradora();
                        aseguradora.IdAseguradora = execute.IdAseguradora;
                        aseguradora.Nombre = execute.Nombre;
                        aseguradora.FechaCreacion = execute.FechaCreacion.ToString();
                        aseguradora.FechaModificacion = execute.FechaModificacion.ToString();

                        aseguradora.Usuario = new ModelLayer.Usuario();

                        aseguradora.Usuario.IdUsuario = execute.IdUsuario;
                        aseguradora.Usuario.Nombre = execute.NombreUsuario;
                        aseguradora.Usuario.ApellidoPaterno = execute.ApellidoPaterno;
                        aseguradora.Usuario.ApellidoMaterno = execute.ApellidoMaterno;

                        result.Object = aseguradora;

                        result.Correct = true;
                        result.Message = $"Información obtenida con éxito de la base de datos.";
                    }
                    else
                    {
                        result.Correct = true;
                        result.Message = $"404 NOT FOUND";
                    }
                }

            }
            catch (Exception error)
            {

                result.Correct = false;
                result.Exeption = error;
                result.Message = $"Ups ocurrió un error: {error.Message}";
            }


            return result;
        }

        public static Result Add(ModelLayer.Aseguradora aseguradora)
        {
            Result result = new Result();
            try
            {
                using (DBernalProgramacionNCapasEntities context = new DBernalProgramacionNCapasEntities())
                {
                   
                    // Type is System.Data.Entity.Core.Objects.ObjectParameter
                    ObjectParameter Mensaje = new ObjectParameter("Mensaje", typeof(string));
                    ObjectParameter IdAseguradora = new ObjectParameter("IdAseguradora", typeof(int));

                    int execute = context.AseguradoraAdd(aseguradora.Nombre, aseguradora.Usuario.IdUsuario, Mensaje, IdAseguradora);


                    string message = Convert.ToString(Mensaje.Value);
                    int idAseguradora = Convert.ToInt32(IdAseguradora.Value);

                    result.Message = $"Mensaje: {message}";



                    if (execute > 0)
                    {
                        result.Object = new ModelLayer.Aseguradora
                        {
                            IdAseguradora = idAseguradora
                        };
                        result.Correct = true;
                    }
                }

            }
            catch (Exception error)
            {

                result.Exeption = error;
                result.Message = $"Ups ocurrió un error: {error.Message}";
                result.Correct = false;
            }

            return result;
        }

        public static Result Update(ModelLayer.Aseguradora aseguradora)
        {
            Result result = new Result();
            try
            {
                using (DBernalProgramacionNCapasEntities context = new DBernalProgramacionNCapasEntities())
                {
                    ObjectParameter Mensaje = new ObjectParameter("Mensaje", typeof(string));

                    int execute = context.AseguradoraUpdate(aseguradora.Nombre, aseguradora.Usuario.IdUsuario, aseguradora.IdAseguradora, Mensaje);

                    string message = Convert.ToString(Mensaje.Value);
                    result.Message = $"Mensaje: {message}";

                    if (execute > 0)
                    {
                        result.Correct = true;
                    }
                }

            }
            catch (Exception error)
            {

                result.Exeption = error;
                result.Message = $"Ups ocurrió un error: {error.Message}";
                result.Correct = false;
            }

            return result;
        }

        public static Result Delete(int IdAseguradora)
        {
            Result result = new Result();
            try
            {
                using (DBernalProgramacionNCapasEntities context = new DBernalProgramacionNCapasEntities())
                {

                    ObjectParameter Mensaje = new ObjectParameter("Mensaje", typeof(string));
                    int execute = context.AseguradoraDelete(IdAseguradora, Mensaje);

                    string message = Convert.ToString(Mensaje.Value);
                    result.Message = $"Mensaje: {message}";

                    if (execute > 0)
                    {
                        result.Correct = true;
                    }
                }

            }
            catch (Exception error)
            {

                result.Exeption = error;
                result.Correct = false;
                result.Message = $"Ups ocurrió un error: {error.Message}";
            }

            return result;
        }
    }
}
