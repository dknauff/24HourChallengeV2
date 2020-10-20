using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24HourChallenge.Data
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Text { get; set; }

        [ForeignKey(nameof(User))]
        public Guid AuthorId { get; set; }
        public virtual User User { get; set; }

        [ForeignKey(nameof(Post))]
        public int CommentPostId { get; set; }
        public virtual Post Post { get; set; }
        public virtual ICollection<Reply> Replies { get; set; } = new List<Reply>();
    }
}
