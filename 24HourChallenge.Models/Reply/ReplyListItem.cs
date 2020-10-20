using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24HourChallenge.Models.Reply
{
    public class ReplyListItem
    {
        public int ReplyId { get; set; }
        public int ReplyCommentId { get; set; }
        public Guid AuthorId { get; set; }
        public string Text { get; set; }
    }
}
