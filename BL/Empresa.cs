using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ML;
using DL;
using DL_EF;
using System.Data.Entity.Core.Objects;
using System.Globalization;
using System.Data.SqlClient;
using System.Data;
using System.Runtime.Remoting.Messaging;

namespace BL
{
    public class Empresa
    {
        /// SQL Client
        static string query = "";
        public static Result GetById(int IdEmpresa)
        {
            Result result = new Result();
            try
            {
                query = "EmpresaGet";
                using (SqlConnection context = new SqlConnection(Conexion.GetConnection()))
                {
                    SqlCommand cmd = new SqlCommand(query, context);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdEmpresa", IdEmpresa);

                    // Abrimos conexión
                    cmd.Connection = context;
                    cmd.Connection.Open();

                    // Indicamos que solo se obtenga una sola fila
                    SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.SingleRow);

                    if (reader.HasRows)
                    {
                        reader.Read();

                        ML.Empresa empresa = new ML.Empresa();
                        empresa.IdEmpresa = reader.GetInt32(0);
                        empresa.Nombre = reader.GetString(1);
                        empresa.Telefono = reader.GetString(2);
                        empresa.Email = reader.GetString(3);
                        empresa.DireccionWeb = reader.GetString(4);

                        result.Object = empresa;
                        result.Correct = true;
                        result.Message = $"Información obtenida con éxito de la base de datos";
                    }
                    else
                    {
                        result.Correct = false;
                        result.Message = $"404 NOT FOUND";
                    }
                    cmd.Connection.Close();
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
        public static Result GetAll()
        {
            Result result = new Result();
            try
            {
                query = "EmpresaGet";
                using (SqlConnection context = new SqlConnection(Conexion.GetConnection()))
                {
                    SqlCommand cmd = new SqlCommand(query, context);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Abrimos conexión
                    cmd.Connection = context;
                    cmd.Connection.Open();

                    // Indicamos que solo se obtenga una sola fila
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        ML.Empresa empresa = null;
                        result.Objects = new List<object>();
                        while (reader.Read())
                        {
                            empresa = new ML.Empresa();
                            empresa.IdEmpresa = reader.GetInt32(0);
                            empresa.Nombre = reader.GetString(1);
                            empresa.Telefono = reader.GetString(2);
                            empresa.Email = reader.GetString(3);
                            empresa.DireccionWeb = reader.GetString(4);
                            result.Objects.Add(empresa);
                        }
                        result.Correct = true;
                        result.Message = $"Información obtenida con éxito de la base de datos";
                    }
                    else
                    {
                        result.Correct = false;
                        result.Message = $"404 NOT FOUND";
                    }
                    cmd.Connection.Close();
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
        public static Result Add(ML.Empresa empresa)
        {
            Result result = new Result();
            try
            {
                query = "EmpresaAdd";
                using (SqlConnection context = new SqlConnection(Conexion.GetConnection()))
                {
                    SqlCommand cmd = new SqlCommand(query, context);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Parámetros de entrada
                    cmd.Parameters.AddWithValue("@Nombre", empresa.Nombre);
                    cmd.Parameters.AddWithValue("@Telefono", empresa.Telefono);
                    cmd.Parameters.AddWithValue("@Email", empresa.Email);
                    cmd.Parameters.AddWithValue("@DireccionWeb", empresa.DireccionWeb);

                    // Parámetros de salida
                    cmd.Parameters.Add("@IdEmpresa", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("@Mensaje", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output;

                    // Abrimos conexión
                    cmd.Connection = context;
                    cmd.Connection.Open();

                    int execute = cmd.ExecuteNonQuery();

                    // Obtenemos los parámetros de salida
                    string mensaje = cmd.Parameters["@Mensaje"].Value.ToString();
                    int idEmpresa = int.Parse(cmd.Parameters["@IdEmpresa"].Value.ToString());

                    result.Message = $"Mensaje: {mensaje}";

                    if (execute > 0)
                    {
                        result.Object = new ML.Empresa
                        {
                            IdEmpresa = idEmpresa
                        };
                        result.Correct = true;
                    }

                    cmd.Connection.Close();
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
        public static Result Update(ML.Empresa empresa)
        {
            Result result = new Result();
            try
            {
                query = "EmpresaUpdate";
                using (SqlConnection context = new SqlConnection(Conexion.GetConnection()))
                {
                    SqlCommand cmd = new SqlCommand(query, context);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Parámetros de entrada
                    cmd.Parameters.AddWithValue("@IdEmpresa", empresa.IdEmpresa);
                    cmd.Parameters.AddWithValue("@Nombre", empresa.Nombre);
                    cmd.Parameters.AddWithValue("@Telefono", empresa.Telefono);
                    cmd.Parameters.AddWithValue("@Email", empresa.Email);
                    cmd.Parameters.AddWithValue("@DireccionWeb", empresa.DireccionWeb);

                    // Parámetros de salida
                    cmd.Parameters.Add("@Mensaje", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output;

                    // Abrimos conexión
                    cmd.Connection = context;
                    cmd.Connection.Open();

                    int execute = cmd.ExecuteNonQuery();

                    // Obtenemos los parámetros de salida
                    string mensaje = cmd.Parameters["@Mensaje"].Value.ToString();

                    result.Message = $"Mensaje: {mensaje}";

                    if (execute > 0)
                    {
                        result.Correct = true;
                    }
                    cmd.Connection.Close();

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
        public static Result Delete(int IdEmpresa)
        {
            Result result = new Result();
            try
            {
                query = "EmpresaDelete";
                using (SqlConnection context = new SqlConnection(Conexion.GetConnection()))
                {
                    SqlCommand cmd = new SqlCommand(query, context);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Parámetros de entrada
                    cmd.Parameters.AddWithValue("@IdEmpresa", IdEmpresa);

                    // Parámetros de salida
                    cmd.Parameters.Add("@Mensaje", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output;

                    // Abrimos conexión
                    cmd.Connection = context;
                    cmd.Connection.Open();

                    int execute = cmd.ExecuteNonQuery();

                    // Obtenemos los parámetros de salida
                    string mensaje = cmd.Parameters["@Mensaje"].Value.ToString();

                    result.Message = $"Mensaje: {mensaje}";

                    if (execute > 0)
                    {
                        result.Correct = true;
                    }
                    cmd.Connection.Close();
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



        /// Entity Framework Métodos
        public static Result GetByIdEF(int IdEmpresa)
        {
            Result result = new Result();
            try
            {
                using (DBernalProgramacionNCapasEntities context = new DBernalProgramacionNCapasEntities())
                {
                    var execute = context.EmpresaGet(IdEmpresa, null).SingleOrDefault();
                    //var execute = context.EmpresaGet(IdEmpresa).FirstOrDefault();

                    if (execute != null)
                    {

                        ML.Empresa empresa = new ML.Empresa();
                        empresa.IdEmpresa = execute.IdEmpresa;
                        empresa.Nombre = execute.Nombre;
                        empresa.Telefono = execute.Telefono;
                        empresa.Email = execute.Email;
                        empresa.DireccionWeb = execute.DireccionWeb;
                        empresa.Logo = execute.Logo;

                        result.Object = empresa;
                        result.Correct = true;
                        result.Message = $"Información obtenida con éxito de la base de datos";
                    }
                    else
                    {
                        result.Correct = false;
                        result.Message = $"404 NOT FOUND";
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

        public static Result GetAllEF(ML.Empresa empresa)
        {
            Result result = new Result();
            try
            {
                using (DBernalProgramacionNCapasEntities context = new DBernalProgramacionNCapasEntities())
                {
                    var execute = context.EmpresaGet(null, empresa.Nombre).ToList();
                    if (execute.Count > 0)
                    {
                        result.Objects = new List<object>();
                        ML.Empresa empresaObj = null;

                        foreach (var item in execute)
                        {
                            empresaObj = new ML.Empresa();
                            empresaObj.IdEmpresa = item.IdEmpresa;
                            empresaObj.Nombre = item.Nombre;
                            empresaObj.Telefono = item.Telefono;
                            empresaObj.Email = item.Email;
                            empresaObj.DireccionWeb = item.DireccionWeb;
                            empresaObj.Logo = item.Logo;
                            result.Objects.Add(empresaObj);
                        }
                        result.Correct = true;
                        result.Message = $"Información obtenida con éxito de la base de datos";
                    }
                    else
                    {
                        result.Correct = false;
                        result.Message = $"404 NOT FOUND";
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

        public static Result AddEF(ML.Empresa empresa)
        {
            Result result = new Result();
            try
            {
                using (DBernalProgramacionNCapasEntities context = new DBernalProgramacionNCapasEntities())
                {
                    // Type is System.Data.Entity.Core.Objects.ObjectParameter
                    ObjectParameter Mensaje = new ObjectParameter("Mensaje", typeof(string));
                    ObjectParameter IdEmpresa = new ObjectParameter("IdEmpresa", typeof(int));

                    int execute = context.EmpresaAdd(
                        empresa.Nombre,
                        empresa.Telefono,
                        empresa.Email,
                        empresa.DireccionWeb,
                        empresa.Logo,
                        Mensaje,
                        IdEmpresa);

                    string mensaje = Convert.ToString(Mensaje.Value);
                    int idEmpresa = Convert.ToInt32(IdEmpresa.Value);

                    result.Message = $"Mensaje: {mensaje}";

                    if (execute > 0)
                    {
                        result.Object = new ML.Empresa
                        {
                            IdEmpresa = idEmpresa
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

        public static Result UpdateEF(ML.Empresa empresa)
        {
            Result result = new Result();
            try
            {
                using (DBernalProgramacionNCapasEntities context = new DBernalProgramacionNCapasEntities())
                {
                    // Type is System.Data.Entity.Core.Objects.ObjectParameter
                    ObjectParameter Mensaje = new ObjectParameter("Mensaje", typeof(string));

                    //context.Entry(empresa).State = System.Data.Entity.EntityState.Modified;

                    int execute = context.EmpresaUpdate(
                        empresa.Nombre,
                        empresa.Telefono,
                        empresa.Email,
                        empresa.DireccionWeb,
                        empresa.Logo,
                        empresa.IdEmpresa,
                        Mensaje);
                    string mensaje = Convert.ToString(Mensaje.Value);

                    result.Message = $"Mensaje: {mensaje}";

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

        public static Result DeleteEF(int IdEmpresa)
        {
            Result result = new Result();
            try
            {
                using (DBernalProgramacionNCapasEntities context = new DBernalProgramacionNCapasEntities())
                {
                    // Type is System.Data.Entity.Core.Objects.ObjectParameter
                    ObjectParameter Mensaje = new ObjectParameter("Mensaje", typeof(string));

                    int execute = context.EmpresaDelete(IdEmpresa,Mensaje);
                    string mensaje = Convert.ToString(Mensaje.Value);

                    result.Message = $"Mensaje: {mensaje}";

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

        /// LINQ
        
        public static Result GetAllLinq()
        {
            Result result = new Result();
            try
            {
                using (DBernalProgramacionNCapasEntities context = new DBernalProgramacionNCapasEntities())
                {

                    var execute = (from empresas in context.Empresas select new
                    {
                        IdEmpresa = empresas.IdEmpresa,
                        Nombre = empresas.Nombre,
                        Telefono = empresas.Telefono,
                        Email = empresas.Email,
                        DireccionWeb = empresas.DireccionWeb
                    });

                    if (execute.ToList().Count > 0 && execute != null)
                    {
                        result.Objects = new List<object>();
                        ML.Empresa empresa = null;

                        foreach (var item in execute)
                        {
                            empresa = new ML.Empresa();
                            empresa.IdEmpresa = item.IdEmpresa;
                            empresa.Nombre = item.Nombre;
                            empresa.Telefono = item.Telefono;
                            empresa.Email = item.Email;
                            empresa.DireccionWeb = item.DireccionWeb;

                            result.Objects.Add(empresa);
                        }
                        result.Correct = true;
                        result.Message = $"Información obtenida con éxito de la base de datos";
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
                result.Exeption = error;
                result.Message = $"Ups ocurrió un error: {error.Message}";
                result.Correct = false;
            }
            return result;
        }
        public static Result GetByIdLinq(int IdEmpresa)
        {
            Result result = new Result();
            try
            {
                using (DBernalProgramacionNCapasEntities context = new DBernalProgramacionNCapasEntities())
                {

                    //var execute = context.Empresas.SingleOrDefault(empresa => empresa.IdEmpresa == IdEmpresa);
                    var execute = (from empresas in context.Empresas
                                   where empresas.IdEmpresa == IdEmpresa
                                   select new
                                   {
                                       IdEmpresa = empresas.IdEmpresa,
                                       Nombre = empresas.Nombre,
                                       Telefono = empresas.Telefono,
                                       Email = empresas.Email,
                                       DireccionWeb = empresas.DireccionWeb
                                   }).SingleOrDefault();

                    if (execute != null)
                    {
                        ML.Empresa empresa = new ML.Empresa();
                        empresa.IdEmpresa = execute.IdEmpresa;
                        empresa.Nombre = execute.Nombre;
                        empresa.Telefono = execute.Telefono;
                        empresa.Email = execute.Email;
                        empresa.DireccionWeb = execute.DireccionWeb;

                        result.Object = empresa;
                        result.Correct = true;
                        result.Message = $"Información obtenida con éxito de la base de datos";
                    }
                    else
                    {
                        result.Correct = false;
                        result.Message = $"404 NOT FOUND";
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

        public static Result AddLinq(ML.Empresa empresa)
        {
            Result result = new Result();
            try
            {
                using (DBernalProgramacionNCapasEntities context = new DBernalProgramacionNCapasEntities())
                {
                    DL_EF.Empresa empresaEF = new DL_EF.Empresa
                    {
                        Nombre = empresa.Nombre,
                        Telefono = empresa.Telefono,
                        Email = empresa.Email,
                        DireccionWeb = empresa.DireccionWeb,
                    };
                    context.Empresas.Add(empresaEF);
                    int execute = context.SaveChanges();
                    
                    if (execute > 0)
                    {
                        int idEmpresa = empresaEF.IdEmpresa;
                        result.Message = $"Mensaje: Registrado ingresado en la Base de Datos.";
                        result.Object = new ML.Empresa
                        {
                            IdEmpresa = idEmpresa
                        };
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.Message = $"Mensaje: Registrado NO ingresado en la Base de Datos.";
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

        public static Result UpdateLinq(ML.Empresa empresaML)
        {
            Result result = new Result();
            try
            {
                using (DBernalProgramacionNCapasEntities context = new DBernalProgramacionNCapasEntities())
                {
                    DL_EF.Empresa empresaEF = context.Empresas.SingleOrDefault(empresa => empresa.IdEmpresa == empresaML.IdEmpresa);

                    //empresaEF.IdEmpresa = empresaML.IdEmpresa;
                    empresaEF.Nombre = empresaML.Nombre;
                    empresaEF.Telefono = empresaML.Telefono;
                    empresaEF.Email = empresaML.Email;
                    empresaEF.DireccionWeb = empresaML.DireccionWeb;

                    int execute = context.SaveChanges();

                    if (execute > 0)
                    {
                        result.Correct = true;
                        result.Message = $"Mensaje: Registrado actualizado en la Base de Datos.";
                    }
                    else
                    {
                        result.Correct = false;
                        result.Message = $"Mensaje: Registrado NO actualizado en la Base de Datos.";
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

        public static Result DeleteLinq(int IdEmpresa)
        {
            Result result = new Result();
            try
            {
                using (DBernalProgramacionNCapasEntities context = new DBernalProgramacionNCapasEntities())
                {
                    var buscarUsuario = context.Empresas.FirstOrDefault(empresa => empresa.IdEmpresa == IdEmpresa);
                    var eliminarUsuario = context.Empresas.Remove(buscarUsuario);
                    int execute = context.SaveChanges();

                    if (execute > 0)
                    {
                        result.Correct = true;
                        result.Message = $"Mensaje: Registro eliminado exitosamente de la base de datos.";
                    }
                    else
                    {
                        result.Correct = false;
                        result.Message = $"Mensaje: Registro NO eliminado de la base de datos.";
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
    }
}
