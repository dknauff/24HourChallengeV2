﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24HourChallenge.Models
{
    public class CommentCreate
    {
        [Required]
        public string Text { get; set; }
        public Guid AuthorId { get; set; }
        public int CommentPostId { get; set; }
    }
}
