using Blog.DB;
using Blog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog
        public ActionResult Index()
        {
            using (var blog = new BlogContent())
            {
                PostVM post = new PostVM();
                post.Posts = blog.Post.ToList();
                post.Categories = blog.Category.ToList();
                return View(post);
            }       
        }
        public ActionResult ManagePost(int? Id)
        {
            using (var blog = new BlogContent())
            {
                PostVM post = new PostVM();
                post.SaveCategories(blog);
                post.Categories = blog.Category.ToList();
                if (Id.HasValue)
                {
                    post.post = blog.Post.Find(Id);
                    return View(post);
                }
                else
                {
                    return View(post);
                }
               
            }
        }
        [HttpPost]
        public ActionResult ManagePost(Post post)
        {
            if (ModelState.IsValid)
            {

            }
                using (var blog = new BlogContent())
                {
                    if (post.Id == 0)
                    {
                    post.Date = DateTime.Now;
                    blog.Post.Add(post);
                    }
                    else
                    {
                        Post _post = blog.Post.Find(post.Id);
                        _post.Title = post.Title;
                        _post.IdCategory = post.IdCategory;
                        _post.Content = post.Content;
                    }
                    blog.SaveChanges();
                    return RedirectToAction("Index");
                }
        }
        public ActionResult Delete(int? id)
        {
            if (!id.HasValue) return HttpNotFound();

            using (var blog = new BlogContent())
            {
                Post post = blog.Post.Find(id);
                if (post == null) return new HttpNotFoundResult();
                return View(post);
            }
        }
        [HttpPost]
        public ActionResult Delete(Post post)
        {
            using (var  blog = new BlogContent())
            {
                Post pos = blog.Post.Find(post.Id);
                blog.Post.Remove(pos);
                blog.SaveChanges();
                return RedirectToAction("Index");
            }
        }
        public ActionResult Detail(int? id)
        {
            if (!id.HasValue) return HttpNotFound();
            using (var blog = new BlogContent())
            {
                DetailVM detail = new DetailVM();
                detail.post = blog.Post.Find(id);
                detail.Categories = blog.Category.ToList();
                detail.comments = blog.Comment.Where(com => com.IdPost == id.Value).ToList();
                if (detail.post == null) return new HttpNotFoundResult();
                return View(detail);
            }
        }
        [HttpPost]
        public ActionResult Detail(DetailVM detail)
        {
            using (var blog = new BlogContent())
            {
                detail.comment.Date = DateTime.Now;
                detail.comment.IdPost = detail.post.Id;
                blog.Comment.Add(detail.comment);
                blog.SaveChanges();
            }
            return Detail(detail.post.Id);
        }
    }
}