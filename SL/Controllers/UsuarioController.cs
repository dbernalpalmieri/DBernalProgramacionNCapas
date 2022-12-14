using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;

namespace ServiceLayer.Controllers
{

    public class UsuarioController : ApiController
    {
        // GET: api/<UsuarioController>
        [HttpGet]
        [Route("api/Usuario/GetAll")]
        public IHttpActionResult GetAll()
        {
            ML.Usuario usuario = new ML.Usuario();
            ML.Result result = BL.Usuario.GetAllEF(usuario);

            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }

        //// GET api/<UsuarioController>/5
        [HttpGet]
        [Route("api/Usuario/GetById/{idUsuario}")]
        public IHttpActionResult GetById(int idUsuario)
        {
            if (idUsuario != 0)
            {
                ML.Result result = BL.Usuario.GetByIdEF(idUsuario);
                if (result.Correct)
                {
                    return Ok(result);
                }
                else
                {
                    return NotFound();
                }
            }
            else
            {
                return BadRequest("Especifica el Id del objeto a buscar");
            }

        }

        // GET api/<UsuarioController>/5
        [HttpGet]
        [Route("api/Usuario/GetByUsernameEmail/{UsernameEmail}")]
        public IHttpActionResult GetByUsernameEmail(string UsernameEmail)
        {
            if (!UsernameEmail.IsNullOrWhiteSpace())
            {
                ML.Result result = BL.Usuario.GetByUsernameEmail(UsernameEmail);
                if (result.Correct)
                {
                    return Ok(result);
                }
                else
                {
                    return NotFound();
                }
            }
            else
            {
                return BadRequest();
            }

        }

        //[HttpPost("GetAllParam")]
        //public IActionResult Post(string? nombre, string? apellidoPaterno, byte idRol)
        //{
        //    ML.Usuario usuario = new ML.Usuario();
        //    usuario.Rol = new Rol();
        //    usuario.Nombre = nombre;
        //    usuario.ApellidoPaterno = apellidoPaterno;
        //    usuario.Rol.IdRol = idRol;

        //    ML.Result result = BL.Usuario.GetAll(usuario);
        //    if (result.Correct)
        //    {
        //        return Ok(result);
        //    }
        //    else
        //    {
        //        return NotFound(result);
        //    }
        //}

        [HttpPost]
        [Route("api/Usuario/GetAll")]
        public IHttpActionResult PostGetAll(ML.Usuario usuario)
        {
            ML.Result result = BL.Usuario.GetAllEF(usuario);

            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }


        [HttpPost]
        [Route("api/Usuario/Add")]
        public IHttpActionResult Post([FromBody] ML.Usuario usuario)
        {
            ML.Result result = BL.Usuario.AddEF(usuario);
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut]
        [Route("api/Usuario/Update")]
        public IHttpActionResult Put([FromBody] ML.Usuario usuario)
        {
            if (usuario.IdUsuario != null && usuario.IdUsuario != 0)
            {
                ML.Result result = BL.Usuario.Update(usuario);
                if (result.Correct)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest(result.Message);
                }
            }
            else
            {
                return BadRequest("Especifica el Id del objeto a buscar");
            }
        }

        //[HttpPut("UpdateStatus/{idUsuario}")]
        //public IActionResult Put(int idUsuario)
        //{
        //    if (idUsuario != null && idUsuario != 0)
        //    {
        //        ML.Result result = BL.Usuario.UpdateStatus(idUsuario);
        //        if (result.Correct)
        //        {
        //            return Ok(result);
        //        }
        //        else
        //        {
        //            return BadRequest(result);
        //        }
        //    }
        //    else
        //    {
        //        return BadRequest(new
        //        {
        //            correct = false,
        //            message = "Especifica el Id del objeto a actualizar"
        //        });
        //    }
        //}

        //// DELETE api/<UsuarioController>/5
        [HttpDelete]
        [Route("api/Usuario/Delete/{idUsuario}")]
        public IHttpActionResult Delete(int idUsuario)
        {
            if (idUsuario != null && idUsuario != 0)
            {
                ML.Result result = BL.Usuario.Delete(idUsuario);
                if (result.Correct)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest(result.Message);
                }
            }
            else
            {
                return BadRequest("Especifica el Id del objeto a buscar");
            }
        }
    }
}
