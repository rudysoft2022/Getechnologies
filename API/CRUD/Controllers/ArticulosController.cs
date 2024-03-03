using CRUD.Model;
using CRUD.Model.Entidades;
using CRUD.Model.NG;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Net;

namespace CRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticulosController : ControllerBase
    {

        [HttpGet("GetArticulos")]
        public IEnumerable<Articulos> GetArticulos()
        {

            return new ArticulosNG().GetArticulos();
        }

        [HttpGet("GetArticuloById")]
        public Articulos GetArticuloById([FromQuery] string input)
        {

            return new ArticulosNG().GetArticuloById(input);
        }

        [HttpPost("CreaActualizaArticulo")]
        public IActionResult CreaActualizaArticulo([FromBody] Articulos input)
        {
            Respuesta res = new ArticulosNG().CreaActualizaArticulo(input);
            if (res == Respuesta.Exito)
                return StatusCode((int)HttpStatusCode.Created);
            else
                return StatusCode((int)HttpStatusCode.Conflict);
        }

        [HttpDelete("BajaArticulo")]
        public IActionResult DeleteArticulo([FromQuery] string input)
        {
            Respuesta res = new ArticulosNG().BajaArticulo(input);
            if (res == Respuesta.Exito)
                return StatusCode((int)HttpStatusCode.Created);
            else
                return StatusCode((int)HttpStatusCode.Conflict);
        }
    }
}
