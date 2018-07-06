using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Blog.Models
{
    public class Post
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Nombre obligatoria")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Nombre obligatoria")]
        public string Content { get; set; }
        public int IdCategory { get; set; }
        public DateTime Date { get; set; }


    }
}