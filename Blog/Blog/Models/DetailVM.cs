using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog.Models
{
    public class DetailVM: PostVM
    {
        public Comment comment { get; set; }
        public List<Comment> comments { get; set; }
    }
}