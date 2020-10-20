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
    public class LikeService
    {
        private readonly Guid _userId;

        public LikeService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateLike(LikeCreate model)
        {
            var entity =
                new Like()
                {
                    LikedPostId = model.LikedPostId,
                    LikerId = model.LikerId
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Likes.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<LikeListItem> GetLikes()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Likes
                        .Where(e => e.LikerId == _userId)
                        .Select(
                            e =>
                                new LikeListItem
                                {
                                    LikeId = e.LikeId,
                                    LikedPostId = e.LikedPostId,
                                }
                        );

                return query.ToArray();
            }
        }
    }
}
