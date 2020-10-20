using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace _24HourChallenge.Models
{
    public class PostCreate
    {
        [Required]
        public string Title { get; set; }
        public string Text { get; set; }
    }
}
