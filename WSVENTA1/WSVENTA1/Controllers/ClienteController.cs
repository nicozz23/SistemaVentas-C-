using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WSVENTA1.Controllers.Models.Response;
using WSVENTA1.Models;


namespace WSVENTA1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            Respuesta oRespuesta = new Respuesta();
            oRespuesta.success = 0;
            try
            {

            
            using (SistemaVentaContext db = new SistemaVentaContext())
            {
                var lst = db.Clientes.ToList();
                oRespuesta.success = 1;
                oRespuesta.Data = lst;

                
            }

            }
            catch (Exception ex)
            {
                oRespuesta.messagge = ex.Message;
            }
            return Ok(oRespuesta);
        }
    }
}
