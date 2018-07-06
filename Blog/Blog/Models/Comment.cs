using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Blog.Models
{
    public class Comment
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Nombre obligatoria")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Contenido obligatoria")]
        public string Text { get; set; }
        public DateTime Date { get; set; }
        public int IdPost { get; set; }
    }
}