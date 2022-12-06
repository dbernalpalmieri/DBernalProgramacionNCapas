﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLayer;
using DataLayer;
using DataLayer_EF;
using System.Data.SqlClient;
using System.Data.Entity.Core.Objects;
using System.Globalization;
using System.Data;
using System.IO;
using static System.Net.Mime.MediaTypeNames;

namespace BusinessLayer
{
    public class Usuario
    {
        // SQL Client
        // Normal
        public static Result Add(ModelLayer.Usuario usuario)
        {
            Result result = new Result();
            try
            {
                query = "INSERT INTO [Usuario] ([Nombre],[ApellidoPaterno],[ApellidoMaterno],[Sexo],[FechaNacimiento],[Email],[Password],[UserName],[IdRol],[Telefono],[Celular],[CURP])" +
                    "VALUES (@Nombre,@ApellidoPaterno,@ApellidoMaterno,@Sexo,CONVERT (DATE, @FechaNacimiento, 103),@Email,@Password,@UserName,@IdRol,@Telefono,@Celular,@CURP)";
                using (SqlConnection context = new SqlConnection(Conexion.GetConnection()))
                {
                    SqlCommand cmd = new SqlCommand(query, context);

                    // Parámetros de entrada
                    cmd.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                    cmd.Parameters.AddWithValue("@ApellidoPaterno", usuario.ApellidoPaterno);
                    cmd.Parameters.AddWithValue("@ApellidoMaterno", usuario.ApellidoMaterno);
                    cmd.Parameters.AddWithValue("@Sexo", usuario.Sexo);
                    cmd.Parameters.AddWithValue("@FechaNacimiento", usuario.FechaNacimiento);
                    cmd.Parameters.AddWithValue("@Email", usuario.Email);
                    cmd.Parameters.AddWithValue("@Password", usuario.Password);
                    cmd.Parameters.AddWithValue("@UserName", usuario.UserName);
                    cmd.Parameters.AddWithValue("@IdRol", usuario.Rol.IdRol);
                    cmd.Parameters.AddWithValue("@Telefono", usuario.Telefono);
                    cmd.Parameters.AddWithValue("@Celular", usuario.Celular);
                    cmd.Parameters.AddWithValue("@CURP", usuario.Curp);


                    // Abrimos conexión
                    cmd.Connection = context;
                    cmd.Connection.Open();

                    int execute = cmd.ExecuteNonQuery();

                    // Obtenemos los parámetros de salida
                    result.Message = $"Mensaje: Registro insertado exitosamente.";

                    if (execute > 0)
                    {
                        //result.Correct = true;
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
        public static Result Update(ModelLayer.Usuario usuario)
        {
            Result result = new Result();
            try
            {
                query = "UPDATE [Usuario] SET [Nombre] = @Nombre, [ApellidoPaterno] = @ApellidoPaterno, [ApellidoMaterno] = @ApellidoMaterno, [Sexo] = @Sexo, " +
                    "[FechaNacimiento] = CONVERT (DATE, @FechaNacimiento, 103), [Email] = @Email, [Password] = @Password, [UserName] = @UserName, [IdRol] = @IdRol, [Telefono] = @Telefono, " +
                    "[Celular] = @Celular, [CURP] = @CURP WHERE IdUsuario = @IdUsuario";
                using (SqlConnection context = new SqlConnection(Conexion.GetConnection()))
                {
                    SqlCommand cmd = new SqlCommand(query, context);

                    // Parámetros de entrada
                    cmd.Parameters.AddWithValue("@IdUsuario", usuario.IdUsuario);
                    cmd.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                    cmd.Parameters.AddWithValue("@ApellidoPaterno", usuario.ApellidoPaterno);
                    cmd.Parameters.AddWithValue("@ApellidoMaterno", usuario.ApellidoMaterno);
                    cmd.Parameters.AddWithValue("@Sexo", usuario.Sexo);
                    cmd.Parameters.AddWithValue("@FechaNacimiento", usuario.FechaNacimiento);
                    cmd.Parameters.AddWithValue("@Email", usuario.Email);
                    cmd.Parameters.AddWithValue("@Password", usuario.Password);
                    cmd.Parameters.AddWithValue("@UserName", usuario.UserName);
                    cmd.Parameters.AddWithValue("@IdRol", usuario.Rol.IdRol);
                    cmd.Parameters.AddWithValue("@Telefono", usuario.Telefono);
                    cmd.Parameters.AddWithValue("@Celular", usuario.Celular);
                    cmd.Parameters.AddWithValue("@CURP", usuario.Curp);

                    // Abrimos conexión
                    cmd.Connection = context;
                    cmd.Connection.Open();

                    int execute = cmd.ExecuteNonQuery();


                    result.Message = $"Mensaje: Registro actualizado correctamente.";

                    if (execute > 0)
                    {
                        //result.Correct = true;
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
        public static Result Delete(int IdUsuario)
        {
            Result result = new Result();
            try
            {
                query = "DELETE FROM [Usuario] WHERE IdUsuario = @IdUsuario";
                using (SqlConnection context = new SqlConnection(Conexion.GetConnection()))
                {
                    SqlCommand cmd = new SqlCommand(query, context);

                    // Parámetros de entrada
                    cmd.Parameters.AddWithValue("@IdUsuario", IdUsuario);

                    // Abrimos conexión
                    cmd.Connection = context;
                    cmd.Connection.Open();

                    int execute = cmd.ExecuteNonQuery();

                    result.Message = $"Mensaje: Registro eliminado exitosamente.";

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

        // Procedimientos Almacenados
        static string query = "";
        public static Result GetById(int IdUsuario)
        {
            Result result = new Result();
            try
            {
                query = "UsuarioGet";
                using (SqlConnection context = new SqlConnection(Conexion.GetConnection()))
                {
                    SqlCommand cmd = new SqlCommand(query, context);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdUsuario", IdUsuario);

                    // Abrimos conexión
                    cmd.Connection = context;
                    cmd.Connection.Open();

                    // Indicamos que solo se obtenga una sola fila
                    SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.SingleRow);

                    if (reader.HasRows)
                    {
                        reader.Read();

                        ModelLayer.Usuario usuario = new ModelLayer.Usuario();
                        usuario.Rol = new ModelLayer.Rol();
                        usuario.IdUsuario = reader.GetInt32(0);
                        usuario.Nombre = reader.GetString(1);
                        usuario.ApellidoPaterno = reader.GetString(2);
                        usuario.ApellidoMaterno = reader.GetString(3);
                        usuario.Sexo = char.Parse(reader["Sexo"].ToString().Trim());
                        usuario.FechaNacimiento = reader.GetDateTime(5).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                        usuario.Email = reader.GetString(6);
                        usuario.Password = reader.GetString(7);
                        usuario.UserName = reader.GetString(8);
                        usuario.Rol.IdRol = reader.GetByte(9);
                        usuario.Telefono = reader.GetString(10);
                        usuario.Celular = reader.GetString(11);
                        usuario.Curp = reader.GetString(12);
                        result.Object = usuario;
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
                query = "UsuarioGet";
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
                        ModelLayer.Usuario usuario = null;
                        result.Objects = new List<object>();
                        while (reader.Read())
                        {
                            usuario = new ModelLayer.Usuario();
                            usuario.Rol = new ModelLayer.Rol();
                            usuario.IdUsuario = reader.GetInt32(0);
                            usuario.Nombre = reader.GetString(1);
                            usuario.ApellidoPaterno = reader.GetString(2);
                            usuario.ApellidoMaterno = reader.GetString(3);
                            usuario.Sexo = char.Parse(reader["Sexo"].ToString().Trim());
                            usuario.FechaNacimiento = reader.GetDateTime(5).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                            usuario.Email = reader.GetString(6);
                            usuario.Password = reader.GetString(7);
                            usuario.UserName = reader.GetString(8);
                            usuario.Rol.IdRol = reader.GetByte(9);
                            usuario.Telefono = reader.GetString(10);
                            usuario.Celular = reader.GetString(11);
                            usuario.Curp = reader.GetString(12);
                            result.Objects.Add(usuario);
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
        public static Result AddSP(ModelLayer.Usuario usuario)
        {
            Result result = new Result();
            try
            {
                query = "UsuarioAdd";
                using (SqlConnection context = new SqlConnection(Conexion.GetConnection()))
                {
                    SqlCommand cmd = new SqlCommand(query, context);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Parámetros de entrada
                    cmd.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                    cmd.Parameters.AddWithValue("@ApellidoPaterno", usuario.ApellidoPaterno);
                    cmd.Parameters.AddWithValue("@ApellidoMaterno", usuario.ApellidoMaterno);
                    cmd.Parameters.AddWithValue("@Sexo", usuario.Sexo);
                    cmd.Parameters.AddWithValue("@FechaNacimiento", usuario.FechaNacimiento);
                    cmd.Parameters.AddWithValue("@Email", usuario.Email);
                    cmd.Parameters.AddWithValue("@Password", usuario.Password);
                    cmd.Parameters.AddWithValue("@UserName", usuario.UserName);
                    cmd.Parameters.AddWithValue("@IdRol", usuario.Rol.IdRol);
                    cmd.Parameters.AddWithValue("@Telefono", usuario.Telefono);
                    cmd.Parameters.AddWithValue("@Celular", usuario.Celular);
                    cmd.Parameters.AddWithValue("@CURP", usuario.Curp);

                    // Parámetros de salida
                    cmd.Parameters.Add("@IdAlumno", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("@Mensaje", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output;

                    // Abrimos conexión
                    cmd.Connection = context;
                    cmd.Connection.Open();

                    int execute = cmd.ExecuteNonQuery();

                    // Obtenemos los parámetros de salida
                    string mensaje = cmd.Parameters["@Mensaje"].Value.ToString();
                    int idUsuario = int.Parse(cmd.Parameters["@IdAlumno"].Value.ToString());

                    result.Message = $"Mensaje: {mensaje}";

                    if (execute > 0)
                    {
                        result.Object = new ModelLayer.Usuario
                        {
                            IdUsuario = idUsuario
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
        public static Result UpdateSP(ModelLayer.Usuario usuario)
        {
            Result result = new Result();
            try
            {
                query = "UsuarioUpdate";
                using (SqlConnection context = new SqlConnection(Conexion.GetConnection()))
                {
                    SqlCommand cmd = new SqlCommand(query, context);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Parámetros de entrada
                    cmd.Parameters.AddWithValue("@IdUsuario", usuario.IdUsuario);
                    cmd.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                    cmd.Parameters.AddWithValue("@ApellidoPaterno", usuario.ApellidoPaterno);
                    cmd.Parameters.AddWithValue("@ApellidoMaterno", usuario.ApellidoMaterno);
                    cmd.Parameters.AddWithValue("@Sexo", usuario.Sexo);
                    cmd.Parameters.AddWithValue("@FechaNacimiento", usuario.FechaNacimiento);
                    cmd.Parameters.AddWithValue("@Email", usuario.Email);
                    cmd.Parameters.AddWithValue("@Password", usuario.Password);
                    cmd.Parameters.AddWithValue("@UserName", usuario.UserName);
                    cmd.Parameters.AddWithValue("@IdRol", usuario.Rol.IdRol);
                    cmd.Parameters.AddWithValue("@Telefono", usuario.Telefono);
                    cmd.Parameters.AddWithValue("@Celular", usuario.Celular);
                    cmd.Parameters.AddWithValue("@CURP", usuario.Curp);

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
        public static Result DeleteSP(int IdUsuario)
        {
            Result result = new Result();
            try
            {
                query = "UsuarioDelete";
                using (SqlConnection context = new SqlConnection(Conexion.GetConnection()))
                {
                    SqlCommand cmd = new SqlCommand(query, context);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Parámetros de entrada
                    cmd.Parameters.AddWithValue("@IdUsuario", IdUsuario);

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
        public static Result AddEF(ModelLayer.Usuario usuario)
        {
            Result result = new Result();
            try
            {
                using (DBernalProgramacionNCapasEntities context = new DBernalProgramacionNCapasEntities())
                {
                    // Type is System.Data.Entity.Core.Objects.ObjectParameter
                    ObjectParameter Mensaje = new ObjectParameter("Mensaje", typeof(string));
                    ObjectParameter IdUsuario = new ObjectParameter("IdUsuario", typeof(int));

                    int execute = context.UsuarioAdd(
                        usuario.Nombre,
                        usuario.ApellidoPaterno,
                        usuario.ApellidoMaterno,
                        usuario.Sexo.ToString(),
                        usuario.FechaNacimiento,
                        usuario.Email,
                        usuario.Password,
                        usuario.UserName,
                        usuario.Rol.IdRol,
                        usuario.Telefono,
                        usuario.Celular,
                        usuario.Curp,
                        usuario.Imagen,
                        usuario.Direccion.Calle,
                        usuario.Direccion.NumeroInterior,
                        usuario.Direccion.NumeroExterior,
                        usuario.Direccion.Colonia.IdColonia,
                        Mensaje,
                        IdUsuario);
                    string mensaje = Convert.ToString(Mensaje.Value);
                    int idUsuario = Convert.ToInt32(IdUsuario.Value);
                    result.Message = $"Mensaje: {mensaje}";

                    if (execute > 0)
                    {
                        result.Object = new ModelLayer.Usuario
                        {
                            IdUsuario = idUsuario
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
        public static Result UpdateEF(ModelLayer.Usuario usuario)
        {
            Result result = new Result();
            try
            {
                using (DBernalProgramacionNCapasEntities context = new DBernalProgramacionNCapasEntities())
                {
                    // Parámetros que nos regresa el procedimiento almacenado
                    ObjectParameter Mensaje = new ObjectParameter("Mensaje", typeof(string));

                    int execute = context.UsuarioUpdate(
                        usuario.IdUsuario,
                        usuario.Nombre,
                        usuario.ApellidoPaterno,
                        usuario.ApellidoMaterno,
                        usuario.Sexo.ToString(),
                        usuario.FechaNacimiento,
                        usuario.Email,
                        usuario.Password,
                        usuario.UserName,
                        usuario.Rol.IdRol,
                        usuario.Telefono,
                        usuario.Celular,
                        usuario.Curp,
                        usuario.Imagen,
                        usuario.Direccion.Calle,
                        usuario.Direccion.NumeroInterior,
                        usuario.Direccion.NumeroExterior,
                        usuario.Direccion.Colonia.IdColonia,
                        Mensaje);

                    // Recuperamos el valor del parámetro que nos devuelve la base de datos
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


        public static ModelLayer.Result UpdateStatus(int IdUsuario)
        {
            ModelLayer.Result result = new ModelLayer.Result();
            try
            {
                using (DBernalProgramacionNCapasEntities context = new DBernalProgramacionNCapasEntities())
                {
                    // Parámetros que nos regresa el procedimiento almacenado
                    ObjectParameter Mensaje = new ObjectParameter("Mensaje", typeof(string));
                    // Ejecución de la Query
                    int execute = context.UsuarioChangeStatus(IdUsuario, Mensaje);

                    // Recuperamos el valor del parámetro que nos devuelve la base de datos
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


        public static Result DeleteEF(int IdUsuario)
        {
            Result result = new Result();
            try
            {
                using (DBernalProgramacionNCapasEntities context = new DBernalProgramacionNCapasEntities())
                {
                    // Parámetros que nos regresa el procedimiento almacenado
                    ObjectParameter Mensaje = new ObjectParameter("Mensaje", typeof(string));

                    int execute = context.UsuarioDelete(IdUsuario, Mensaje);

                    // Recuperamos el valor del parámetro que nos devuelve la base de datos
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
        public static Result GetAllEF(ModelLayer.Usuario usuario)
        {
            Result result = new Result();
            try
            {
                using (DBernalProgramacionNCapasEntities context = new DBernalProgramacionNCapasEntities())
                {
                    usuario.Rol = (usuario.Rol == null) ? new ModelLayer.Rol() : usuario.Rol;


                    var execute = context.UsuarioGet(null, usuario.Nombre, usuario.ApellidoPaterno, usuario.Rol.IdRol).ToList();

                    // result.Objects = new List<object>(execute);


                    if (execute.Count > 0)
                    {
                        result.Objects = new List<object>();
                        ModelLayer.Usuario usuarioObj = null;


                        foreach (var item in execute)
                        {
                            usuarioObj = new ModelLayer.Usuario();


                            usuarioObj.IdUsuario = item.IdUsuario;
                            usuarioObj.Nombre = item.Nombre;
                            usuarioObj.ApellidoPaterno = item.ApellidoPaterno;
                            usuarioObj.ApellidoMaterno = item.ApellidoMaterno;
                            usuarioObj.FechaNacimiento = item.FechaNacimiento.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                            usuarioObj.Email = item.Email;
                            usuarioObj.Sexo = char.Parse(item.Sexo.Trim());
                            usuarioObj.Password = item.Password;
                            usuarioObj.UserName = item.UserName;
                            usuarioObj.Telefono = item.Telefono;
                            usuarioObj.Celular = item.Celular;
                            usuarioObj.Curp = item.CURP;
                            usuarioObj.Imagen = item.Imagen;
                            usuarioObj.Status = item.Status;

                            usuarioObj.NombreCompleto = $"{item.Nombre} {item.ApellidoPaterno} {item.ApellidoMaterno}";

                            usuarioObj.Rol = new ModelLayer.Rol();
                            usuarioObj.Rol.IdRol = item.IdRol;
                            usuarioObj.Rol.Nombre = item.RolNombre;

                            usuarioObj.Direccion = new ModelLayer.Direccion();
                            usuarioObj.Direccion.IdDireccion = item.IdDireccion;
                            usuarioObj.Direccion.Calle = item.Calle;
                            usuarioObj.Direccion.NumeroExterior = item.NumeroExterior;
                            usuarioObj.Direccion.NumeroInterior = item.NumeroInterior;

                            usuarioObj.Direccion.Colonia = new ModelLayer.Colonia();
                            usuarioObj.Direccion.Colonia.IdColonia = item.IdColonia;
                            usuarioObj.Direccion.Colonia.Nombre = item.ColoniaNombre;
                            usuarioObj.Direccion.Colonia.CodigoPostal = item.CodigoPostal;

                            usuarioObj.Direccion.Colonia.Municipio = new ModelLayer.Municipio();
                            usuarioObj.Direccion.Colonia.Municipio.IdMunicipio = item.IdMunicipio;
                            usuarioObj.Direccion.Colonia.Municipio.Nombre = item.MunicipioNombre;

                            usuarioObj.Direccion.Colonia.Municipio.Estado = new ModelLayer.Estado();
                            usuarioObj.Direccion.Colonia.Municipio.Estado.IdEstado = item.IdEstado;
                            usuarioObj.Direccion.Colonia.Municipio.Estado.Nombre = item.EstadoNombre;

                            usuarioObj.Direccion.Colonia.Municipio.Estado.Pais = new ModelLayer.Pais();
                            usuarioObj.Direccion.Colonia.Municipio.Estado.Pais.IdPais = item.IdPais;
                            usuarioObj.Direccion.Colonia.Municipio.Estado.Pais.Nombre = item.PaisNombre;

                            result.Objects.Add(usuarioObj);
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
                result.Exeption = error;
                result.Message = $"Ups ocurrió un error: {error.Message}";
                result.Correct = false;
            }
            return result;
        }



        public static Result GetByIdEF(int IdUsario)
        {
            Result result = new Result();
            try
            {
                using (DBernalProgramacionNCapasEntities context = new DBernalProgramacionNCapasEntities())
                {
                    var execute = context.UsuarioGet(IdUsario, null, null, null).SingleOrDefault();
                    //var execute = context.UsuarioGet(IdUsario).FirstOrDefault();
                    if (execute != null)
                    {

                        ModelLayer.Usuario usuario = new ModelLayer.Usuario();

                        usuario.IdUsuario = execute.IdUsuario;
                        usuario.Nombre = execute.Nombre;
                        usuario.ApellidoPaterno = execute.ApellidoPaterno;
                        usuario.ApellidoMaterno = execute.ApellidoMaterno;
                        usuario.FechaNacimiento = execute.FechaNacimiento.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                        usuario.Email = execute.Email;
                        usuario.Sexo = char.Parse(execute.Sexo.Trim());
                        usuario.Password = execute.Password;
                        usuario.UserName = execute.UserName;
                        usuario.Telefono = execute.Telefono;
                        usuario.Celular = execute.Celular;
                        usuario.Curp = execute.CURP;
                        usuario.Imagen = execute.Imagen;

                        usuario.Rol = new ModelLayer.Rol();
                        usuario.Rol.IdRol = execute.IdRol;
                        usuario.Rol.Nombre = execute.RolNombre;

                        usuario.Direccion = new ModelLayer.Direccion();
                        usuario.Direccion.IdDireccion = execute.IdDireccion;
                        usuario.Direccion.Calle = execute.Calle;
                        usuario.Direccion.NumeroExterior = execute.NumeroExterior;
                        usuario.Direccion.NumeroInterior = execute.NumeroInterior;

                        usuario.Direccion.Colonia = new ModelLayer.Colonia();
                        usuario.Direccion.Colonia.IdColonia = execute.IdColonia;
                        usuario.Direccion.Colonia.Nombre = execute.ColoniaNombre;
                        usuario.Direccion.Colonia.CodigoPostal = execute.CodigoPostal;

                        usuario.Direccion.Colonia.Municipio = new ModelLayer.Municipio();
                        usuario.Direccion.Colonia.Municipio.IdMunicipio = execute.IdMunicipio;
                        usuario.Direccion.Colonia.Municipio.Nombre = execute.MunicipioNombre;

                        usuario.Direccion.Colonia.Municipio.Estado = new ModelLayer.Estado();
                        usuario.Direccion.Colonia.Municipio.Estado.IdEstado = execute.IdEstado;
                        usuario.Direccion.Colonia.Municipio.Estado.Nombre = execute.EstadoNombre;

                        usuario.Direccion.Colonia.Municipio.Estado.Pais = new ModelLayer.Pais();
                        usuario.Direccion.Colonia.Municipio.Estado.Pais.IdPais = execute.IdPais;
                        usuario.Direccion.Colonia.Municipio.Estado.Pais.Nombre = execute.PaisNombre;


                        result.Object = usuario;
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

        /// LINQ
        public static Result GetAllLinq()
        {
            Result result = new Result();
            try
            {
                using (DBernalProgramacionNCapasEntities context = new DBernalProgramacionNCapasEntities())
                {

                    var execute = (from users in context.Usuarios select users).ToList();

                    if (execute.Count > 0 && execute != null)
                    {
                        result.Objects = new List<object>();
                        ModelLayer.Usuario usuario = null;


                        foreach (var item in execute)
                        {
                            usuario = new ModelLayer.Usuario();
                            usuario.Rol = new ModelLayer.Rol();
                            usuario.IdUsuario = item.IdUsuario;
                            usuario.Nombre = item.Nombre;
                            usuario.ApellidoPaterno = item.ApellidoPaterno;
                            usuario.ApellidoMaterno = item.ApellidoMaterno;
                            usuario.FechaNacimiento = item.FechaNacimiento.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                            usuario.Email = item.Email;
                            usuario.Sexo = char.Parse(item.Sexo.Trim());
                            usuario.Password = item.Password;
                            usuario.UserName = item.UserName;
                            usuario.Rol.IdRol = item.IdRol;
                            usuario.Telefono = item.Telefono;
                            usuario.Celular = item.Celular;
                            usuario.Curp = item.CURP;
                            result.Objects.Add(usuario);
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

        public static Result GetByIdLinq(int IdUsuario)
        {
            Result result = new Result();
            try
            {
                using (DBernalProgramacionNCapasEntities context = new DBernalProgramacionNCapasEntities())
                {

                    var execute = context.Usuarios.SingleOrDefault(usuario => usuario.IdUsuario == IdUsuario);

                    if (execute != null)
                    {
                        ModelLayer.Usuario usuario = new ModelLayer.Usuario();
                        usuario.Rol = new ModelLayer.Rol();
                        usuario.IdUsuario = execute.IdUsuario;
                        usuario.Nombre = execute.Nombre;
                        usuario.ApellidoPaterno = execute.ApellidoPaterno;
                        usuario.ApellidoMaterno = execute.ApellidoMaterno;
                        usuario.FechaNacimiento = execute.FechaNacimiento.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                        usuario.Email = execute.Email;
                        usuario.Sexo = char.Parse(execute.Sexo.Trim());
                        usuario.Password = execute.Password;
                        usuario.UserName = execute.UserName;
                        usuario.Rol.IdRol = execute.IdRol;
                        usuario.Telefono = execute.Telefono;
                        usuario.Celular = execute.Celular;
                        usuario.Curp = execute.CURP;
                        result.Object = usuario;
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

        public static Result AddLinq(ModelLayer.Usuario usuario)
        {
            Result result = new Result();
            try
            {
                using (DBernalProgramacionNCapasEntities context = new DBernalProgramacionNCapasEntities())
                {
                    DataLayer_EF.Usuario usuarioEF = new DataLayer_EF.Usuario
                    {
                        Nombre = usuario.Nombre,
                        ApellidoPaterno = usuario.ApellidoPaterno,
                        ApellidoMaterno = usuario.ApellidoMaterno,
                        Sexo = usuario.Sexo.ToString(),
                        FechaNacimiento = DateTime.ParseExact(usuario.FechaNacimiento, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None),
                        Email = usuario.Email,
                        Password = usuario.Password,
                        UserName = usuario.UserName,
                        IdRol = usuario.Rol.IdRol,
                        Telefono = usuario.Telefono,
                        Celular = usuario.Celular,
                        CURP = usuario.Curp
                    };
                    context.Usuarios.Add(usuarioEF);
                    int execute = context.SaveChanges();

                    if (execute > 0)
                    {
                        int idUsuario = usuarioEF.IdUsuario;
                        result.Message = $"Mensaje: Registrado ingresado en la Base de Datos.";
                        result.Object = new ModelLayer.Usuario
                        {
                            IdUsuario = idUsuario
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

        public static Result UpdateLinq(ModelLayer.Usuario usuarioML)
        {
            Result result = new Result();
            try
            {
                using (DBernalProgramacionNCapasEntities context = new DBernalProgramacionNCapasEntities())
                {
                    DataLayer_EF.Usuario usuarioEF = context.Usuarios.SingleOrDefault(usuario => usuario.IdUsuario == usuarioML.IdUsuario);

                    //usuarioEF.IdUsuario = usuarioML.IdUsuario;
                    usuarioEF.Nombre = usuarioML.Nombre;
                    usuarioEF.ApellidoPaterno = usuarioML.ApellidoPaterno;
                    usuarioEF.ApellidoMaterno = usuarioML.ApellidoMaterno;
                    usuarioEF.Sexo = usuarioML.Sexo.ToString();
                    usuarioEF.FechaNacimiento = DateTime.ParseExact(usuarioML.FechaNacimiento, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None);
                    usuarioEF.Email = usuarioML.Email;
                    usuarioEF.Password = usuarioML.Password;
                    usuarioEF.UserName = usuarioML.UserName;
                    usuarioEF.IdRol = usuarioML.Rol.IdRol;
                    usuarioEF.Telefono = usuarioML.Telefono;
                    usuarioEF.Celular = usuarioML.Celular;
                    usuarioEF.CURP = usuarioML.Curp;

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

        public static Result DeleteLinq(int IdUsuario)
        {
            Result result = new Result();
            try
            {
                using (DBernalProgramacionNCapasEntities context = new DBernalProgramacionNCapasEntities())
                {
                    var buscarUsuario = context.Usuarios.FirstOrDefault(usuario => usuario.IdUsuario == IdUsuario);
                    var eliminarUsuario = context.Usuarios.Remove(buscarUsuario);
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

        public static void convertImage(string imagen)
        {
            byte[] imageArray = File.ReadAllBytes(imagen);
            Console.WriteLine(imageArray);
        }
    }


}