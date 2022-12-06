using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class AseguradoraController : Controller
    {
        // GET: Aseguradora
        [HttpGet]
        public ActionResult GetAll()
        {
            
                ModelLayer.Result result = BusinessLayer.Aseguradora.GetAll();
                ViewBag.Message = result.Message;

                ModelLayer.Aseguradora aseguradora = new ModelLayer.Aseguradora();
                if (result.Correct /*&& result.Objects.Count >0*/)
                {
                    aseguradora.Aseguradoras = result.Objects;
                }
               return View(aseguradora);
            
        }
    }
}