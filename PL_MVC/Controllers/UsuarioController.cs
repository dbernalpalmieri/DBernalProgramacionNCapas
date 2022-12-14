using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Mvc;
using BL;
using ML;
using Newtonsoft.Json;

namespace MVC.Controllers
{
    public class UsuarioController : Controller
    {
        string urlAPI = System.Configuration.ConfigurationManager.AppSettings["DBernalProgramacionNCapas"];


        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string user_name, string password)
        {

            return View();
        }

        Result result = new Result();
        [HttpGet]
        public ActionResult GetAll()
        {
            //ModelLayer.Usuario user = new ModelLayer.Usuario();
            //user.Rol = new ModelLayer.Rol();

            //ModelLayer.Result result = BusinessLayer.Usuario.GetAllEF(user);
            //Result resultRoles = BusinessLayer.Rol.GetAllEF();

            //ViewBag.Message = result.Message;

            //if (result.Correct && result.Objects.Count > 0 && resultRoles.Correct)
            //{
            //    //IEnumerable<ModelLayer.Usuario> usuarios = result.Objects.OfType<ModelLayer.Usuario>().ToList();
            //    ModelLayer.Usuario usuario = new ModelLayer.Usuario();
            //    usuario.Rol = new ModelLayer.Rol();
            //    usuario.Rol.Roles = resultRoles.Objects;

            //    usuario.Usuarios = result.Objects;
            //    return View(usuario);
            //}
            //return View("/");


            ML.Result result = new ML.Result();
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Clear();
                    httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    httpClient.BaseAddress = new Uri(urlAPI);


                    //Sending request to find web api REST service resource using HttpClient
                    var request = httpClient.GetAsync("Usuario/GetAll");
                    request.Wait();

                    //Checking the response is successful or not which is sent using HttpClient
                    var response = request.Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var readContent = response.Content.ReadAsStringAsync().Result;

                        ML.Result resultAPI = JsonConvert.DeserializeObject<ML.Result>(readContent);

                        result.Message = resultAPI.Message;

                        if (resultAPI.Correct)
                        {
                            result.Objects = new List<object>();
                            foreach (var item in resultAPI.Objects)
                            {
                                ML.Usuario user = JsonConvert.DeserializeObject<ML.Usuario>(item.ToString());
                                result.Objects.Add(user);
                            }
                            result.Correct = true;
                        }
                    }
                }
            }
            catch (Exception error)
            {
                result.Correct = false;
                result.Message = error.Message;
            }


            ViewBag.Message = result.Message;

            ML.Usuario usuario = new ML.Usuario();
            usuario.Rol = new ML.Rol();

            Result resultRoles = BL.Rol.GetAllEF();
            usuario.Rol.Roles = resultRoles.Objects;

            if (result.Correct)
            {
                usuario.Usuarios = result.Objects;
            }
            else
            {
                usuario.Usuarios = new List<object> { };
            }
            return View(usuario);
        }

        [HttpPost]
        public ActionResult GetAll(ML.Usuario usuario)
        {
            //ModelLayer.Result result = BusinessLayer.Usuario.GetAllEF(usuario);
            //Result resultRoles = BusinessLayer.Rol.GetAllEF();
            //ViewBag.Message = result.Message;
            //if (result.Correct && result.Objects.Count > 0 && resultRoles.Correct)
            //{
            //    //IEnumerable<ModelLayer.Usuario> usuarios = result.Objects.OfType<ModelLayer.Usuario>().ToList();
            //    usuario = new ModelLayer.Usuario();
            //    usuario.Rol = new ModelLayer.Rol();
            //    usuario.Rol.Roles = resultRoles.Objects;

            //    usuario.Usuarios = result.Objects;
            //    return View(usuario);
            //}
            //return View("/");


            ML.Result result = new ML.Result();
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Clear();
                    httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    httpClient.BaseAddress = new Uri(urlAPI);


                    HttpContent content = new StringContent(JsonConvert.SerializeObject(usuario), Encoding.UTF8, "application/json");

                    //Sending request to find web api REST service resource using HttpClient
                    var request = httpClient.PostAsync("Usuario/GetAll", content);
                    request.Wait();

                    //Checking the response is successful or not which is sent using HttpClient
                    var response = request.Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var readContent = response.Content.ReadAsStringAsync().Result;

                        ML.Result resultAPI = JsonConvert.DeserializeObject<ML.Result>(readContent);

                        result.Message = resultAPI.Message;

                        if (resultAPI.Correct)
                        {
                            result.Objects = new List<object>();
                            foreach (var item in resultAPI.Objects)
                            {
                                ML.Usuario user = JsonConvert.DeserializeObject<ML.Usuario>(item.ToString());
                                result.Objects.Add(user);
                            }
                            result.Correct = true;
                        }
                    }
                }
            }
            catch (Exception error)
            {
                result.Correct = false;
                result.Message = error.Message;
            }


            ViewBag.Message = result.Message;
            Result resultRoles = BL.Rol.GetAllEF();

            usuario.Rol = new ML.Rol();
            usuario.Rol.Roles = resultRoles.Objects;

            if (result.Correct)
            {
                usuario.Usuarios = result.Objects;
            }
            else
            {
                usuario.Usuarios = new List<object> { };
            }
            return View(usuario);
        }

        [HttpGet]
        public ActionResult GetById(int? IdUsuario)
        {
            if (IdUsuario == null)
            {
                return Redirect("/Usuario/GetAll");
            }
            else
            {
                ML.Usuario usuario = new ML.Usuario();
                result = BL.Usuario.GetByIdEF(IdUsuario.Value);
                ViewBag.Message = result.Message;
                if (result.Correct && result.Object != null)
                {
                    usuario = (ML.Usuario)result.Object;
                    return PartialView("GetById", usuario);
                }
            }
            return PartialView("GetById");
        }
        public ActionResult Delete(int? IdUsuario)
        {
            if (IdUsuario == null)
            {
                return Redirect("/Usuario/GetAll");
            }
            else
            {
                result = BL.Usuario.DeleteEF(IdUsuario.Value);
                ViewBag.Message = result.Message;
                if (result.Correct)
                {
                    // return Redirect("/Usuario/GetAll");
                }
            }
            return PartialView("Modal");
        }


        [HttpGet]
        public ActionResult Form(int? IdUsuario)
        {
            Result resultRoles = BL.Rol.GetAllEF();
            Result resultPaises = BL.Pais.GetAll();


            if (resultRoles.Correct && resultPaises.Correct)
            {
                // Instanciamos un objeto alumno
                ML.Usuario usuario = new ML.Usuario();

                // Inicializamos los objetos que hacen referencia a la información del usuario.
                usuario.Rol = new ML.Rol();
                usuario.Direccion = new ML.Direccion();
                usuario.Direccion.Colonia = new ML.Colonia();
                usuario.Direccion.Colonia.Municipio = new ML.Municipio();
                usuario.Direccion.Colonia.Municipio.Estado = new ML.Estado();
                usuario.Direccion.Colonia.Municipio.Estado.Pais = new ML.Pais();

                if (IdUsuario == null)
                {
                    // Pasamos esos parámetros a nuestros objetos
                    usuario.Direccion.Colonia.Municipio.Estado.Pais.Paises = resultPaises.Objects;
                    usuario.Rol.Roles = resultRoles.Objects;
                    // ADD

                }
                else
                {
                    ML.Result result = BL.Usuario.GetByIdEF(IdUsuario.Value);
                    ViewBag.Message = result.Message;
                    // GET BY ID
                    if (result.Correct && result.Object != null)
                    {
                        // Igualamos el objeto usuario con lo obtenido en la consulta
                        usuario = (ML.Usuario)result.Object;

                        // Volvemos a pasar el listado de elementos que componen al objeto Usuario ya que se borraron en la igualación
                        usuario.Rol.Roles = resultRoles.Objects;
                        usuario.Direccion.Colonia.Municipio.Estado.Pais.Paises = resultPaises.Objects;

                        // Obtenemos algunos elementos 
                        Result resultEstados = BL.Estado.GetByIdPais(usuario.Direccion.Colonia.Municipio.Estado.Pais.IdPais);
                        Result resultMunicipios = BL.Municipio.GetByIdEstado(usuario.Direccion.Colonia.Municipio.Estado.IdEstado);
                        Result resultColonias = BL.Colonia.GetByIdMunicipio(usuario.Direccion.Colonia.Municipio.IdMunicipio);
                        // Los igualamos a la parte del usuario que corresponde
                        usuario.Direccion.Colonia.Municipio.Estado.Estados = resultEstados.Objects;
                        usuario.Direccion.Colonia.Municipio.Municipios = resultMunicipios.Objects;
                        usuario.Direccion.Colonia.Colonias = resultColonias.Objects;

                    }
                }
                return View(usuario);

            }
            return Redirect("/Usuario/GetAll");
        }

        public JsonResult GetEstados(int IdPais)
        {
            result = BL.Estado.GetByIdPais(IdPais);

            return Json(result.Objects, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetMunicipios(int IdEstado)
        {
            result = BL.Municipio.GetByIdEstado(IdEstado);

            return Json(result.Objects, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetColonias(int IdMunicipio)
        {
            result = BL.Colonia.GetByIdMunicipio(IdMunicipio);

            return Json(result.Objects, JsonRequestBehavior.AllowGet);
        }

        public static string ConvertToBase64String(HttpPostedFileBase image)
        {
            int fileSizeInBytes = image.ContentLength;
            using (var br = new BinaryReader(image.InputStream))
            {
                return Convert.ToBase64String(br.ReadBytes(fileSizeInBytes));
            }
        }

        public JsonResult ChangeStatus(int IdUsuario)
        {
            ML.Result result = BL.Usuario.UpdateStatus(IdUsuario);
            return Json(result);
        }


        [HttpPost]
        public ActionResult Form(ML.Usuario usuario)
        {
            //HttpPostedFileBase image
            // Guardamos la imagen que ingreso el usuario y la pasamos a un arreglo de Bytes
            
            if (usuario != null && ModelState.IsValid)
            {
                HttpPostedFileBase image = Request.Files["image"];
                // Verificamos si se envió imagen
                if (image != null && image.ContentLength > 0)
                {
                    // Guardamos la imagen que ingreso el usuario y la pasamos a Base64 String
                    usuario.Imagen = ConvertToBase64String(image);
                }
                // ADD
                if (usuario.IdUsuario == 0)
                {

                    ML.Result result = BL.Usuario.AddEF(usuario);
                    ViewBag.Message = result.Message;
                    if (result.Correct)
                    {
                        ModelState.Clear();
                    }
                }
                else
                // UPDATE
                {
                    ML.Result result = BL.Usuario.UpdateEF(usuario);
                    ViewBag.Message = result.Message;
                    if (result.Correct)
                    {

                        ModelState.Clear();
                    }
                }
            }
            else
            {
                Result resultRoles = BL.Rol.GetAllEF();
                Result resultPaises = BL.Pais.GetAll();

                usuario.Rol = new ML.Rol();
                usuario.Direccion = new ML.Direccion();
                usuario.Direccion.Colonia = new ML.Colonia();
                usuario.Direccion.Colonia.Municipio = new ML.Municipio();
                usuario.Direccion.Colonia.Municipio.Estado = new ML.Estado();
                usuario.Direccion.Colonia.Municipio.Estado.Pais = new ML.Pais();

                usuario.Rol.Roles = resultRoles.Objects;
                usuario.Direccion.Colonia.Municipio.Estado.Pais.Paises = resultPaises.Objects;

                ViewBag.Message = "La información dada está incompleta.";
                return View(usuario);
            }
            return PartialView("Modal");
        }

        //public static byte[] ConvertToBytes(HttpPostedFileBase image)
        //{
        //    int fileSizeInBytes = image.ContentLength;
        //    using (var br = new BinaryReader(image.InputStream))
        //    {
        //        return br.ReadBytes(fileSizeInBytes);
        //    }
        //}

        //// UPDATE
        //// Llamamos a la vista del formulario para editar los datos
        //public ActionResult Update(int IdUsuario = 0)
        //{
        //    result = BusinessLayer.Usuario.GetByIdEF(IdUsuario);
        //    ViewBag.mensaje = "";
        //    if (result.Correct && result.Object != null)
        //    {
        //        ModelLayer.Usuario usuario = (ModelLayer.Usuario)result.Object;
        //        return View(usuario);
        //    }
        //    return View("/");
        //}
        //// Ejecutamos la actualización de los datos cuando se da clic en botón 
        //[HttpPost]
        //public ActionResult Update(ModelLayer.Usuario usuario)
        //{
        //    result = BusinessLayer.Usuario.UpdateEF(usuario);
        //    if (result.Correct)
        //    {
        //        ViewBag.mensaje = result.Message;
        //        return Redirect("/Usuario/GetAll");
        //    }

        //    return View(usuario);
        //}

        //// ADD: Usuario
        //// Llama a la vista con el formulario
        //public ActionResult Add()
        //{
        //    ViewBag.mensaje = "";
        //    return View();
        //}
        //// Recibe los datos del formulario
        //[HttpPost]
        //public ActionResult Add(ModelLayer.Usuario usuario)
        //{
        //    if (usuario != null && ModelState.IsValid)
        //    {
        //        result = BusinessLayer.Usuario.AddEF(usuario);
        //        if (result.Correct)
        //        {
        //            ViewBag.mensaje = result.Message;
        //            ModelState.Clear();
        //            return Redirect("/Usuario/GetAll");
        //        }
        //    }
        //    //ViewBag.mensaje = "Error: Campos Incompletos";
        //    return View(usuario);
        //}
    }
}