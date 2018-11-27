using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Westeros.Demo.ApiClient.Contracts;
using Westeros.Demo.Data.Model;
using Westeros.Demo.Data.Repositories;

namespace Westeros.Demo.Web.Controllers.Api
{
    [Produces("application/json")]
    [Route("api/People")]
    public class PeopleApiController : Controller
    {
        IGenericRepository<Person> _people;
        IMapper _mapper;

        public PeopleApiController(IGenericRepository<Person> people, IMapper mapper)
        {
            _people = people;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult Get()
        {
            return Json(_mapper.Map<List<PersonDto>>(_people.Get()));
        }
        
        [HttpGet("{id}", Name = "Get")]
        public ActionResult Get(int id)
        {
            var result = _people.GetByID(id);
            if (result == null)
                return StatusCode(404);
            return Json(_mapper.Map<PersonDto>(result));
        }
        
        [HttpPost]
        public ActionResult Post([FromBody]PersonDto value)
        {
            _people.Insert(new Person
            {
                LastName = value.LastName,
                Name = value.Name
            });
            _people.SaveChanges()
            return StatusCode(201);
        }
        
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody]PersonDto value)
        {
            var person = _people.GetByID(id);
            if (person == null) return StatusCode(404);
            person.Name = value.Name;
            person.LastName = value.LastName;
            _people.Update(person);
            _people.SaveChanges();
            return StatusCode(200);
        }
        
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _people.Delete(id);
            _people.SaveChanges();
            return StatusCode(200);
        }
    }
}
