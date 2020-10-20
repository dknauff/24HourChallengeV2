using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24HourChallenge.Models
{
    public class CommentList
    {
        public int CommentId { get; set; }
        public string Text { get; set; }
        public Guid AuthorId { get; set; }
        public Guid CommentPost { get; set; }

    }
}
