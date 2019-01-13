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
using Westeros.Events.Web.Services.Messages;

namespace Westeros.Events.Web.Controllers.Api
{
    [Produces("application/json")]
    [Route("api/Messages")]
    public class PeopleApiController : Controller
    {
       private IGenericRepository<IMessage> _message;
       private IMapper _mapper;
       private IMessageSender _messageSender;

        public PeopleApiController(IGenericRepository<IMessage> message, IMapper mapper,IMessageSender messageSender)
        {
            _message = message;
            _mapper = mapper;
            _messageSender = messageSender;
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
            _messageSender.SendMessage(_mapper.Map<Message>(value));
     
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
