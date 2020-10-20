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
    [Authorize]
    public class LikeController : ApiController
    {
        public IHttpActionResult Get()
        {
            LikeService likeService = CreateLikeService();
            var notes = likeService.GetLikes();
            return Ok(notes);
        }
        public IHttpActionResult Post(LikeCreate like)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateLikeService();

            if (!service.CreateLike(like))
                return InternalServerError();

            return Ok();
        }

        private LikeService CreateLikeService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var noteService = new LikeService(userId);
            return noteService;
        }
    }
}
