using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class AseguradoraController : Controller
    {

        PL_MVC.ServiceAseguradora.AseguradoraClient context = new PL_MVC.ServiceAseguradora.AseguradoraClient();
        // GET: Aseguradora
        [HttpGet]
        public ActionResult GetAll()
        {
            var resultService = context.GetAll();

            ViewBag.Message = resultService.Message;

            ML.Aseguradora aseguradora = new ML.Aseguradora();

            aseguradora.Aseguradoras = resultService.Correct ? resultService.Objects.ToList() : new List<object> { };

            //ModelLayer.Result result = BusinessLayer.Aseguradora.GetAll();
            //ViewBag.Message = result.Message;

            //ModelLayer.Aseguradora aseguradora = new ModelLayer.Aseguradora();
            //if (result.Correct /*&& result.Objects.Count >0*/)
            //{
            //    aseguradora.Aseguradoras = result.Objects;
            //}
            return View(aseguradora);

        }

        // [HttpDelete]
        public ActionResult Delete(int? IdAseguradora)
        {
            if (IdAseguradora == null)
            {
                //return Redirect("/Aseguradora/GetAll");
                return RedirectToAction("GetAll", "Aseguradora");
            }
            else
            {
                //ModelLayer.Result result = BusinessLayer.Aseguradora.Delete(IdAseguradora.Value);
                var resultService = context.Delete(IdAseguradora.Value);
                ViewBag.Message = resultService.Message;
                if (resultService.Correct)
                {
                    // return Redirect("/Usuario/GetAll");
                }
            }
            return PartialView("Modal");
        }





        [HttpGet]
        public ActionResult Form(int? IdAseguradora)
        {
            // Instanciamos un objeto 
            ML.Aseguradora aseguradora = new ML.Aseguradora();

            // Inicializamos los objetos que hacen referencia a la información que le complementa.
            ML.Usuario user = new ML.Usuario();
            ML.Result resultUsuarios = BL.Usuario.GetAllEF(user);

            aseguradora.Usuario = new ML.Usuario();

            if (IdAseguradora == null)
            {
                // Pasamos esos parámetros a nuestros objeto

                aseguradora.Usuario.Usuarios = resultUsuarios.Objects;
                // ADD
                return View(aseguradora);
            }
            else
            {
                //ModelLayer.Result result = BusinessLayer.Aseguradora.GetById(IdAseguradora.Value);
                var resultService = context.GetById(IdAseguradora.Value);
                ViewBag.Message = resultService.Message;
                if (resultService.Correct && resultService.Object != null)
                {
                    // Igualamos el objeto con lo obtenido en la consulta
                    aseguradora = (ML.Aseguradora)resultService.Object;
                    // Pasamos esos parámetros a nuestros objeto
                    aseguradora.Usuario.Usuarios = resultUsuarios.Objects;

                    return View(aseguradora);
                }
                return RedirectToAction("GetAll", "Aseguradora");
                // return Redirect("/Aseguradora/GetAll");
            }
        }
        [HttpPost]
        public ActionResult Form(ML.Aseguradora aseguradora)
        {
            // ADD
            if (aseguradora.IdAseguradora == 0)
            {
                if (aseguradora != null)
                {
                    //ModelLayer.Result result = BusinessLayer.Aseguradora.Add(aseguradora);
                    var resultService = context.Add(aseguradora);
                    ViewBag.Message = resultService.Message;
                    if (resultService.Correct)
                    {
                        ModelState.Clear();
                    }
                }
            }
            else
            // UPDATE
            {
                if (aseguradora != null)
                {
                    //ModelLayer.Result result = BusinessLayer.Aseguradora.Update(aseguradora);
                    var resultService = context.Update(aseguradora);
                    ViewBag.Message = resultService.Message;
                    if (resultService.Correct)
                    {
                        ModelState.Clear();
                    }
                }
            }
            return PartialView("Modal");
        }
    }
}