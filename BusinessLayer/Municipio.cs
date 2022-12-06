﻿using DataLayer_EF;
using ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class Municipio
    {
        public static Result GetByIdEstado(int IdEstado)
        {
            Result result = new Result();
            try
            {
                using (DBernalProgramacionNCapasEntities context = new DBernalProgramacionNCapasEntities())
                {
                    var execute = context.MunicipioGetByIdEstado(IdEstado).ToList();
                    //var execute = context.EmpresaGet(IdEmpresa).FirstOrDefault();

                    if (execute.Count > 0)
                    {
                        result.Objects = new List<object>();
                        ModelLayer.Municipio municipio = null;

                        foreach (var item in execute)
                        {
                            municipio = new ModelLayer.Municipio();
                            municipio.Estado = new ModelLayer.Estado();

                            municipio.IdMunicipio = item.IdMunicipio;
                            municipio.Nombre = item.Nombre;
                            municipio.Estado.IdEstado = item.IdEstado;

                            result.Objects.Add(municipio);
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
