using CRUDLab.Models;
using CRUDLab.Models.Request;
using CRUDLab.Models.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDLab.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController : ControllerBase
    {
        [HttpGet]
        public ActionResult Get()
        {
            Respuesta<List<Persona>> oRespuesta = new Respuesta<List<Persona>>();

            try
            {
                using (LabCRUDContext db = new LabCRUDContext())
                {
                    var lst = db.Personas.ToList();
                    oRespuesta.Exito = 1;
                    oRespuesta.Data = lst;
                }
            }
            catch (Exception ex)
            {

                oRespuesta.Mensaje = ex.Message;
            }
                

            return Ok(oRespuesta);
        }

        [HttpPost]
        public ActionResult Add(PersonaRequest model)
        {
            Respuesta<object> oRespuesta = new Respuesta<object>();

            try
            {
                using (LabCRUDContext db = new LabCRUDContext())
                {
                    Persona oPersona = new Persona();
                    oPersona.Nombre = model.nombre;
                    oPersona.Edad = model.edad;
                    oPersona.Email = model.email;
                    db.Personas.Add(oPersona);
                    db.SaveChanges();
                    oRespuesta.Exito = 1;
                }
            }
            catch (Exception ex)
            {

                oRespuesta.Mensaje = ex.Message;
            }


            return Ok(oRespuesta);
        }

        [HttpPut]
        public ActionResult Edit(PersonaRequest model)
        {
            Respuesta<object> oRespuesta = new Respuesta<object>();

            try
            {
                using (LabCRUDContext db = new LabCRUDContext())
                {
                    Persona oPersona = db.Personas.Find(model.id);
                    oPersona.Nombre = model.nombre;
                    oPersona.Edad = model.edad;
                    oPersona.Email = model.email;
                    db.Entry(oPersona).State = Microsoft.EntityFrameworkCore.EntityState.Modified; ;
                    db.SaveChanges();
                    oRespuesta.Exito = 1;
                }
            }
            catch (Exception ex)
            {

                oRespuesta.Mensaje = ex.Message;
            }


            return Ok(oRespuesta);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            Respuesta<object> oRespuesta = new Respuesta<object>();

            try
            {
                using (LabCRUDContext db = new LabCRUDContext())
                {
                    Persona oPersona = db.Personas.Find(id);
                    db.Remove(oPersona);
                    db.SaveChanges();
                    oRespuesta.Exito = 1;
                }
            }
            catch (Exception ex)
            {

                oRespuesta.Mensaje = ex.Message;
            }


            return Ok(oRespuesta);
        }

        [HttpGet("{Id}")]
        public ActionResult Get(int Id)
        {
            Respuesta<Persona> oRespuesta = new Respuesta<Persona>();

            try
            {
                using (LabCRUDContext db = new LabCRUDContext())
                {
                    var lst = db.Personas.Find(Id);
                    oRespuesta.Exito = 1;
                    oRespuesta.Data = lst;
                }
            }
            catch (Exception ex)
            {

                oRespuesta.Mensaje = ex.Message;
            }


            return Ok(oRespuesta);
        }

    }
}
