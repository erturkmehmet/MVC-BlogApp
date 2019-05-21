using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyBlog.Models;

namespace MyBlog.Controllers
{
    
    public class BlogController : Controller
    {
        private BlogContext db = new BlogContext();

        // GET: Blog
        public ActionResult List(int? id,string AnahtarKelime)
        {
            var blogs = db.Blogs
                                .Where(x => x.Confirmation == true) //bloglara tıklanıldığında onaylı olanların hepsi gelsin.
                               .Select(x =>
                               new BlogModel()
                               {
                                   Id = x.Id,
                                   Tittle = x.Tittle.Length > 100 ? x.Tittle.Substring(0, 100) + "..." : x.Tittle,
                                   Description = x.Description,
                                   AddDate = x.AddDate,
                                   HomePage = x.HomePage,
                                   Confirmation = x.Confirmation,
                                   Picture = x.Picture,
                                   CategoryId = x.CategoryId
                               }).AsQueryable();

            if (string.IsNullOrEmpty(AnahtarKelime) == false)
            {
                blogs = blogs.Where(x => x.Tittle.Contains(AnahtarKelime) || x.Description.Contains(AnahtarKelime));
            }

            if (id!=null)
            {
                blogs = blogs.Where(x => x.CategoryId == id);
            }
                               
            return View(blogs.ToList());
        }

         
        public ActionResult Index()
        {
            var blogs = db.Blogs.Include(b => b.Category).OrderByDescending(x=>x.AddDate);
            return View(blogs.ToList());
        }

        // GET: Blog/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = db.Blogs.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        // GET: Blog/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "CategoryName");
            return View();
        }

        // POST: Blog/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Tittle,Description,Picture,Content,CategoryId")] Blog blog)
        {
            if (ModelState.IsValid)
            {
                blog.AddDate = DateTime.Now;

                db.Blogs.Add(blog);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "CategoryName", blog.CategoryId);
            return View(blog);
        }

        // GET: Blog/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = db.Blogs.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "CategoryName", blog.CategoryId);
            return View(blog);
        }

        // POST: Blog/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Tittle,Description,Picture,Confirmation,HomePage,Content,CategoryId")] Blog blog)
        {
            if (ModelState.IsValid)
            {
                var entity = db.Blogs.Find(blog.Id);
                if (entity != null)
                {
                    entity.Tittle = blog.Tittle;
                    entity.Description = blog.Description;
                    entity.Picture = blog.Picture;
                    entity.Content = blog.Content;
                    entity.Confirmation = blog.Confirmation;
                    entity.HomePage = blog.HomePage;
                    entity.CategoryId = blog.CategoryId;

                    TempData["Blog"] = entity;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
               
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "CategoryName", blog.CategoryId);
            return View(blog);
        }

        // GET: Blog/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = db.Blogs.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        // POST: Blog/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Blog blog = db.Blogs.Find(id);
            db.Blogs.Remove(blog);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
