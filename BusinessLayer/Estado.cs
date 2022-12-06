using DataLayer_EF;
using ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class Estado
    {
        public static Result GetByIdPais(int IdPais)
        {
            Result result = new Result();
            try
            {
                using (DBernalProgramacionNCapasEntities context = new DBernalProgramacionNCapasEntities())
                {
                    var execute = context.EstadoGetByIdPais(IdPais).ToList();
                    //var execute = context.EmpresaGet(IdEmpresa).FirstOrDefault();

                    if (execute.Count > 0)
                    {
                        result.Objects = new List<object>();
                        ModelLayer.Estado estado = null;


                        foreach (var item in execute)
                        {
                            estado = new ModelLayer.Estado();
                            estado.Pais = new ModelLayer.Pais();

                            estado.IdEstado = item.IdEstado;    
                            estado.Nombre = item.Nombre;
                            estado.Pais.IdPais = item.IdPais;
                            result.Objects.Add(estado);
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
    }
}
