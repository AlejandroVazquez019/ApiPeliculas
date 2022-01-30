using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Peliculas.Models.Response;
using Peliculas.Models;
using Peliculas.Models.Request;

namespace Peliculas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            Respuesta oRespuesta = new Respuesta();

            try
            {
                using (PeliculasContext db = new PeliculasContext())
                {
                    var lst = db.Pelis.ToList();
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
        public IActionResult Add(PeliculasRequest Models)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                using (PeliculasContext db = new PeliculasContext())
                {
                    Peli Opeli = new Peli();
                    Opeli.Id = Models.Id;
                    Opeli.Titulo = Models.Titulo;
                    Opeli.Director = Models.Director;
                    Opeli.Genero = Models.Genero;
                    Opeli.Puntuacion = Models.Puntuacion;
                    Opeli.Rating = Models.Rating;
                    Opeli.FechaPublicacion = Models.FechaPublicacion;
                    db.Pelis.Add(Opeli);
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

        //METODO PARA EDITAR
        [HttpPut]
        public IActionResult Editar(PeliculasRequest Models)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                using (PeliculasContext db = new PeliculasContext())
                {

                    //ID para modificar los datos
                    Peli Opeli = db.Pelis.Find(Models.Id);
                    Opeli.Titulo = Models.Titulo;
                    Opeli.Director = Models.Director;
                    Opeli.Genero = Models.Genero;
                    Opeli.Puntuacion = Models.Puntuacion;
                    Opeli.Rating = Models.Rating;
                    Opeli.FechaPublicacion = Models.FechaPublicacion;
                    //Indica que se modifico
                    db.Entry(Opeli).State = Microsoft.EntityFrameworkCore.EntityState.Modified; ;
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

        //METODO PARA ELIMINAR EL ID
        [HttpDelete("{id}")]
        public IActionResult Eliminar(int Id)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                using (PeliculasContext db = new PeliculasContext())
                {

                    //para eliminar una pelicula con el ID
                    Peli Opeli = db.Pelis.Find(Id);

                    //
                    //elimina los datos en el Registro
                    db.Remove(Opeli);
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
    }
}