using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Westeros.Events.Data.Model;
using Westeros.Events.Data.Repositories;
namespace Westeros.Events.Web.Controllers.Api
{
    [Produces("application/json")]
    [Route("api/Messages")]
    public class PeopleApiController : Controller
    {
       IGenericRepository<Message> _message;
       // IMapper _mapper;

        public PeopleApiController(IGenericRepository<Message> message)
        {
            _message = message;
            //_mapper = mapper;
        }

        [HttpGet]
        public ActionResult Get()
        {
            return Json(_message.Get());
        }
        
        [HttpGet("{id}", Name = "Get")]
        public ActionResult Get(int id)
        {
            var result = _message.GetByID(id);
            if (result == null)
                return StatusCode(404);
            return Json(result);
        }
        
        [HttpPost]
        public ActionResult Post([FromBody]Message value)
        {
             MailSender.SendMail(value);
     
            return StatusCode(201);
        }       
        
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _message.Delete(id);
            _message.SaveChanges();
            return StatusCode(200);
        }
    }
}
