using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24HourChallenge.Data
{
    public class Like
    {
        [Key]
        public int LikeId { get; set; }

        [ForeignKey(nameof(Post))]
        public int LikedPostId { get; set; }
        public virtual Post Post { get; set; }

        [ForeignKey(nameof(User))]
        public Guid LikerId { get; set; }
        public virtual User User { get; set; }
    }
}