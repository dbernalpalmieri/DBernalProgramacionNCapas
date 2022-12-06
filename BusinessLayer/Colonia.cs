using DataLayer_EF;
using ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class Colonia
    {
        public static Result GetByIdMunicipio(int IdMunicipio)
        {
            Result result = new Result();
            try
            {
                using (DBernalProgramacionNCapasEntities context = new DBernalProgramacionNCapasEntities())
                {
                    var execute = context.ColoniaGetByIdMunicipio(IdMunicipio).ToList();
                    //var execute = context.EmpresaGet(IdEmpresa).FirstOrDefault();

                    if (execute.Count > 0)
                    {
                        result.Objects = new List<object>();
                        ModelLayer.Colonia colonia = null;

                        foreach (var item in execute)
                        {
                            colonia = new ModelLayer.Colonia();
                            colonia.Municipio = new ModelLayer.Municipio();


                            colonia.IdColonia = item.IdColonia;
                            colonia.Nombre = item.Nombre;
                            colonia.CodigoPostal = item.CodigoPostal;   
                            colonia.Municipio.IdMunicipio = item.IdMunicipio;

                            result.Objects.Add(colonia);
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
