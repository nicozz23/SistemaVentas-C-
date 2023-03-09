using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WSVENTA1.Models;
using WSVENTA1.Models.Response;
using WSVENTA1.Models.Request;

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
                    oRespuesta.message = ex.Message;
                }
            return Ok(oRespuesta);
        }

        [HttpPost]
        public IActionResult Add(ClienteRequest oModel)
        {
            Respuesta oRespuesta = new Respuesta();
            
            try
            {
                using (SistemaVentaContext db = new SistemaVentaContext())
                {
                    Cliente ocliente = new Cliente();
                    ocliente.Nombre = oModel.Nombre;
                    db.Clientes.Add(ocliente);
                    db.SaveChanges();
                    oRespuesta.success=1;

                }
                    
                        
            }
            catch (Exception ex)
            {
                oRespuesta.message = ex.Message;
            }

            return Ok(oRespuesta);
        }

        [HttpPut]
        public IActionResult Update(ClienteRequest oModel)
        {
            Respuesta oRespuesta = new Respuesta();

            try
            {
                using (SistemaVentaContext db = new SistemaVentaContext())
                {
                    Cliente ocliente = db.Clientes.Find(oModel.IdCliente);
                    ocliente.Nombre = oModel.Nombre;
                    db.Entry(ocliente).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    db.SaveChanges();
                    oRespuesta.success = 1;

                }


            }
            catch (Exception ex)
            {
                oRespuesta.message = ex.Message;
            }

            return Ok(oRespuesta);
        }

        [HttpDelete ("{IdCliente}") ]
        public IActionResult Delete(int IdCliente)
        {
            Respuesta oRespuesta = new Respuesta();

            try
            {
                using (SistemaVentaContext db = new SistemaVentaContext())
                {
                    Cliente ocliente = db.Clientes.Find(IdCliente);
                    db.Remove(ocliente);
                    db.SaveChanges();
                    oRespuesta.success = 1;
                }


            }
            catch (Exception ex)
            {
                oRespuesta.message = ex.Message;
            }

            return Ok(oRespuesta);
        }



    }
}
 