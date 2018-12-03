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
    [Route("api/Message")]
    public class MessageApiController : Controller
    {
        IGenericRepository<Message> _message;
        public MessageApiController(IGenericRepository<Message> message)
        {
            _message = message;
            //_mapper = mapper;
        }
        // GET: api/MessageApi
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/MessageApi/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }
        
        // POST: api/MessageApi
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        
        // PUT: api/MessageApi/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
