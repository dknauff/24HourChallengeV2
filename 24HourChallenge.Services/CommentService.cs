using _24HourChallenge.Data;
using _24HourChallenge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFHourChallenge.Models;

namespace _24HourChallenge.Services
{
    public class CommentService
    {
        private readonly Guid _postId;
        public CommentService(Guid postId)
        {
            _postId = postId;
        }
        public bool CreateComment(CommentCreate model)
        {
            var entity =
                new Comment()
                {
                    CommentPostId = _postId,
                    Text = model.Text,
                    AuthorId = model.AuthorId,
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Comments.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<CommentList> GetNotes()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Comments
                        .Where(e => e.CommentPostId == _postId)
                        .Select(
                            e =>
                                new CommentList
                                {
                                    CommentId = e.Id,
                                    Text = e.Text,
                                    AuthorId = e.AuthorId,
                                    CommentPost = e.CommentPostId
                                }
                        );

                return query.ToArray();
            }
        }
    }
}
