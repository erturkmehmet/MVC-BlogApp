using MyBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBlog.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        private BlogContext context = new BlogContext();
        public ActionResult Index()
        {
            var blogs = context.Blogs
                .Where(x => x.Confirmation == true && x.HomePage == true)
                               .Select(x =>
                               new BlogModel()
                               {
                                   Id = x.Id,
                                   Tittle = x.Tittle.Length > 100 ? x.Tittle.Substring(0, 100) + "..." : x.Tittle,
                                   Description = x.Description,
                                   AddDate = x.AddDate,
                                   HomePage = x.HomePage,
                                   Confirmation = x.Confirmation,
                                   Picture = x.Picture
                               });
                               
            return View(blogs.ToList());
        }


    }
}