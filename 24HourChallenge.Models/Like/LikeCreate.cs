using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24HourChallenge.Models
{
    public class LikeCreate
    {
        [Required]
        public int LikedPostId { get; set; }
        public Guid LikerId { get; set; }

    }
}
