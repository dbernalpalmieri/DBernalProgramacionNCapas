using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ML;

namespace MVC.Controllers
{
    public class EmpresaController : Controller
    {
        Result result = new Result();

        /// <summary>
        /// GET: Traemos los registros de la tabla empresa
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetAll()
        {
            ML.Empresa empresa = new ML.Empresa();
            result = BL.Empresa.GetAllEF(empresa);
            ViewBag.Message = result.Message;
            if (result.Correct && result.Objects.Count > 0)
            {
                //IEnumerable<ModelLayer.Usuario> usuarios = result.Objects.OfType<ModelLayer.Usuario>().ToList();
               
                empresa.Empresas = result.Objects;
                return View(empresa);
            }
            return View("/");
        }


        [HttpPost]
        public ActionResult GetAll(ML.Empresa empresa)
        {
            ML.Result result = BL.Empresa.GetAllEF(empresa);

            ViewBag.Message = result.Message;
            if (result.Correct && result.Objects.Count > 0)
            {
                empresa = new ML.Empresa();
                empresa.Empresas = result.Objects;

            }
            else
            {
                empresa = new ML.Empresa();
                empresa.Empresas = new List<object> { };
            }
            return View(empresa);
        }

        public ActionResult Delete(int? IdEmpresa)
        {
            if (IdEmpresa == null)
            {
                return Redirect("/Empresa/GetAll");
            }
            else
            {
                result = BL.Empresa.DeleteEF(IdEmpresa.Value);
                ViewBag.Message = result.Message;
                if (result.Correct)
                {
                    // return Redirect("/Usuario/GetAll");
                }
            }
            return PartialView("Modal");
        }

        /// <summary>
        /// Usaremos la misma vista para ADD y UPDATE por ello validamos si
        /// al invocar al controller se le envía el parámetro del ID
        /// </summary>
        /// <param name="IdEmpresa"></param>
        /// <returns>View</returns>
        [HttpGet]
        public ActionResult Form(int? IdEmpresa)
        {
            ML.Empresa empresa = new ML.Empresa();
            if (IdEmpresa == null)
            {
                return View(empresa);
            }
            else
            {
                /// GETBYID
                result = BL.Empresa.GetByIdEF(IdEmpresa.Value);
                ViewBag.Message = result.Message;
                if (result.Correct && result.Object != null)
                {
                    empresa = (ML.Empresa)result.Object;
                }
                return View(empresa);
            }
        }
        /// <summary>
        /// Como es la misma vista evaluamos si es un ADD o UPDATE
        /// y sin importar sera enviado a un Modal de un PartialView
        /// </summary>
        /// <param name="empresa"></param>
        /// <returns>PartialView</returns>
        [HttpPost]
        public ActionResult Form(ML.Empresa empresa)
        {
            // ADD
            if (empresa.IdEmpresa == 0)
            {
                if (empresa != null)
                {
                    result = BL.Empresa.AddEF(empresa);
                    ViewBag.Message = result.Message;
                    if (result.Correct)
                    {
                        ModelState.Clear();
                    }
                }
            }
            else
            // UPDATE
            {
                if (empresa != null)
                {
                    result = BL.Empresa.UpdateEF(empresa);
                    ViewBag.Message = result.Message;
                    if (result.Correct)
                    {
                        ModelState.Clear();
                    }
                }
            }
            return PartialView("Modal");
        }
    }
}