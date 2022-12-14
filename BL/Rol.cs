using DL_EF;
using ML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Rol
    {
        public static Result GetAllEF()
        {
            Result result = new Result();
            try
            {
                using (DBernalProgramacionNCapasEntities context = new DBernalProgramacionNCapasEntities())
                {
                    var execute = context.RolGet(null).ToList();
                    if (execute.Count > 0)
                    {
                        result.Objects = new List<object>();
                        ML.Rol rol = null;

                        foreach (var item in execute)
                        {
                            rol = new ML.Rol();

                            rol.IdRol = item.IdRol;
                            rol.Nombre = item.Nombre;
                            
                            result.Objects.Add(rol);
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
    }
}
