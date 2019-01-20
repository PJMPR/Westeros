using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Westeros.Diet.ApiClient.Contracts;
using Westeros.Diet.Data.Model;
using Westeros.Diet.Data.Repositories;

namespace Westeros.Diet.Web.Controllers.Api
{
    [Produces("application/json")]
    [Route("api/UserProfilesApi")]
    public class UserProfilesApiController : Controller
    {
        IGenericRepository<UserProfile> _userProfiles;
        IMapper _mapper;

        public UserProfilesApiController(IGenericRepository<UserProfile> userProfiles, IMapper mapper)
        {
            _userProfiles = userProfiles;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult Get()
        {
            return Json(_mapper.Map<List<UserProfileDto>>(_userProfiles.Get()));
        }

        [HttpGet("{id}", Name = "GetUserProfile")]
        public ActionResult Get(int id)
        {
            var result = _userProfiles.GetByID(id);
            if (result == null)
                return StatusCode(404);
            return Json(_mapper.Map<UserProfileDto>(result));
        }

        [HttpPost]
        public ActionResult Post([FromBody]UserProfileDto value)
        {
            _userProfiles.Insert(new UserProfile
            {
                Id = value.Id,
                Name = value.Name,
                Surname = value.Surname,
                Login = value.Login,
                Email = value.Email,
                Sex = value.Sex,
                Age = value.Age,
                Weight = value.Weight,
                Height = value.Height
            });
            _userProfiles.SaveChanges();
            return StatusCode(201);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody]UserProfileDto value)
        {
            var userProfile = _userProfiles.GetByID(id);
            if (userProfile == null) return StatusCode(404);
            userProfile.Name = value.Name;
            userProfile.Surname = value.Surname;
            userProfile.Login = value.Login;
            userProfile.Email = value.Email;
            userProfile.Sex = value.Sex;
            userProfile.Age = value.Age;
            userProfile.Weight = value.Weight;
            userProfile.Height = value.Height;
            _userProfiles.Update(userProfile);
            _userProfiles.SaveChanges();
            return StatusCode(200);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _userProfiles.Delete(id);
            _userProfiles.SaveChanges();
            return StatusCode(200);
        }
    }
}
