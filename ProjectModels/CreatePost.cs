using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectModels
{
    public class CreatePost
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Text { get; set; }
    }
}
