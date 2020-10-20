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
    public class UserService
    {
        private readonly Guid _userId;

        public UserService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateUser(UserCreate model)
        {
            var entity =
                new User()
                {
                    Id = _userId,
                    Name = model.Name,
                    Email = model.Email
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Users1.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<UserListItem> GetUsers()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Users1
                        .Where(e => e.Id == _userId)
                        .Select(
                            e =>
                                new UserListItem
                                {
                                    UserId = e.Id,
                                    Name = e.Name,
                                    Email = e.Email
                                }
                      );

                return query.ToArray();
            }
        }
    }
}
