using _24HourChallenge.Models;
using _24HourChallenge.Services;
using Microsoft.Ajax.Utilities;
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
    public class CommentController : ApiController
    {
        public IHttpActionResult Get()
        {
            CommentService commentService = CreateCommentService();
            var comments = commentService.GetComments();
            return Ok(comments);
        }

        public IHttpActionResult Post(CommentCreate comment)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var service = CreateCommentService();

            if (!service.CreateComment(comment))
                return InternalServerError();

            return Ok();
        }

        private CommentService CreateCommentService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var commentService = new CommentService(userId);
            return commentService;
        }
    }
}
