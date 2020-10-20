using _24HourChallenge.Models;
using _24HourChallenge.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace _24HourChallenge.WebAPI.Controllers
{
    public class UserController : ApiController
    {
        public IHttpActionResult Get()
        {
            UserService userService = CreateUserService();
            var users = userService.GetUsers();
            return Ok(users);
        }

        public IHttpActionResult Post(UserCreate user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateUserService();

            if (!service.CreateUser(user))
                return InternalServerError();

            return Ok();
        }

        private UserService CreateUserService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var userService = new UserService(userId);
            return userService;
        }
    }
}
