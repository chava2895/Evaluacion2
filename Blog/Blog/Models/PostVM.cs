using Blog.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog.Models
{
    public class PostVM
    {
        public List<Post> Posts { get;  set; }
        public List<Category> Categories { get;  set; }
        public Post post;
        public void SaveCategories(BlogContent blog)
        {
            if (blog.Category.ToList().Count==0)
            {
                List<Category> categories = new List<Category>
                {
                    new Category{ Name="Terror"},
                    new Category{ Name="Romance"},
                    new Category{ Name="Accion"},
                    new Category{ Name="Comedia"},
                    new Category{ Name="Misterio"},
                };
                blog.Category.AddRange(categories);
                blog.SaveChanges();
            }
        }

    }
}