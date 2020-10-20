using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24HourChallenge.Models
{
    public class LikeListItem
    {
        public int LikeId { get; set; }
        public int LikedPostId { get; set; }
        public Guid LikerId { get; set; }
    }
}