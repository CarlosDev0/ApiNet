using Modelo.Hero;
using Persistencia.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HeroApi.Controller
{
    public class HeroController : ApiController
    {
        private static List<Hero> _listItems { get; set; } = new List<Hero>();
        // GET api/<controller>
        public IEnumerable<Hero> Get()
        {
            
            IEnumerable<Hero>listHeros = HeroDM.getHeroes();
            return listHeros;
            
        }

        // GET api/<controller>
        public HttpResponseMessage Get(int id)
        {
            Hero item = HeroDM.getHero(id);
            
            if (item != null)
            {
                
                return Request.CreateResponse(HttpStatusCode.OK, item);
            }
            return Request.CreateResponse(HttpStatusCode.NotFound);
        }

        // POST api/<controller>
        public HttpResponseMessage Post([FromBody]Hero model)
        {
            if (string.IsNullOrEmpty(model?.name))
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            Boolean respuesta = HeroDM.addHero(model);

              if (respuesta) { 
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, "El heroe fue creado exitosamente.");
                return response;
                    }
            
            else
                return Request.CreateResponse(HttpStatusCode.NotAcceptable, "No fue posible crear el Heroe.");
        }

        // PUT api/<controller>
        public HttpResponseMessage Put([FromBody]Hero model)
        {
            if (string.IsNullOrEmpty(model?.name))
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            Boolean respuesta = HeroDM.updateHero(model);
            if (respuesta) { 
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, "El heroe fue actualizado exitosamente.");
                return response;
            
            }
            else
                return Request.CreateResponse(HttpStatusCode.NotAcceptable, model);
            
        }

        // DELETE api/<controller>
        public HttpResponseMessage Delete(int id)
        {
            
            if (id != 0)
            {
                Hero model = new Hero(id, "");
                Boolean respuesta = HeroDM.deleteHero(model);
                if (respuesta) { 
                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, "El heroe fue eliminado exitosamente.");
                    return response;
                }
                else
                    return Request.CreateResponse(HttpStatusCode.NotAcceptable, model);
                
       
            }
            return Request.CreateResponse(HttpStatusCode.NotFound);
        }
    }
}