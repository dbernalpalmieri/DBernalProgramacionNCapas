using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ModelLayer;

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
            ModelLayer.Empresa empresa = new ModelLayer.Empresa();
            result = BusinessLayer.Empresa.GetAllEF(empresa);
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
        public ActionResult GetAll(ModelLayer.Empresa empresa)
        {
            ModelLayer.Result result = BusinessLayer.Empresa.GetAllEF(empresa);

            ViewBag.Message = result.Message;
            if (result.Correct && result.Objects.Count > 0)
            {
                empresa = new ModelLayer.Empresa();
                empresa.Empresas = result.Objects;

            }
            else
            {
                empresa = new ModelLayer.Empresa();
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
                result = BusinessLayer.Empresa.DeleteEF(IdEmpresa.Value);
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
            ModelLayer.Empresa empresa = new ModelLayer.Empresa();
            if (IdEmpresa == null)
            {
                return View(empresa);
            }
            else
            {
                /// GETBYID
                result = BusinessLayer.Empresa.GetByIdEF(IdEmpresa.Value);
                ViewBag.Message = result.Message;
                if (result.Correct && result.Object != null)
                {
                    empresa = (ModelLayer.Empresa)result.Object;
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
        public ActionResult Form(ModelLayer.Empresa empresa)
        {
            // ADD
            if (empresa.IdEmpresa == 0)
            {
                if (empresa != null)
                {
                    result = BusinessLayer.Empresa.AddEF(empresa);
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
                    result = BusinessLayer.Empresa.UpdateEF(empresa);
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