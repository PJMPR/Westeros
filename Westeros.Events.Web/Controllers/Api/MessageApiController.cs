using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Westeros.Events.ApiClient.Contracts;
using Westeros.Events.Data.Model;
using Westeros.Events.Data.Repositories;
namespace Westeros.Events.Web.Controllers.Api
{
    [Produces("application/json")]
    [Route("api/Messages")]
    public class PeopleApiController : Controller
    {
       IGenericRepository<IMessage> _message;
       IMapper _mapper;

        public PeopleApiController(IGenericRepository<IMessage> message, IMapper mapper)
        {
            _message = message;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult Get()
        {
            return Json(_mapper.Map<List<MessageDto>>(_message.Get()));
        }
        
        [HttpGet("{id}", Name = "Get")]
        public ActionResult Get(int id)
        {
            var result = _message.GetByID(id);
            if (result == null)
                return StatusCode(404);
            return Json(_mapper.Map<MessageDto>(result));
        }
        
        [HttpPost]
        public ActionResult Post([FromBody]MessageDto value)
        {
             MailSender.SendMail(_mapper.Map<Message>(value));
     
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
