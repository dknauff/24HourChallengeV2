using _24HourChallenge.Data;
using _24HourChallenge.Models.Reply;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFHourChallenge.Models;

namespace _24HourChallenge.Services
{
    public class ReplyService
    {
        private readonly Guid _userId;

        public ReplyService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateReply(ReplyCreate model)
        {
            var entity =
                new Reply()
                {
                    AuthorId = model.AuthorId,
                    Text = model.Text,
                    ReplyCommentId = model.ReplyCommentId
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Replies.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<ReplyListItem> GetReplies()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Replies
                        .Where(e => e.AuthorId == _userId)
                        .Select(
                            e =>
                                new ReplyListItem
                                {
                                    AuthorId = e.AuthorId,
                                    Text = e.Text,
                                    ReplyCommentId = e.ReplyCommentId
                                }
                        );

                return query.ToArray();
            }
        }
    }
}
