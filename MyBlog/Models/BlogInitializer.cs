using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MyBlog.Models
{
    public class BlogInitializer:DropCreateDatabaseIfModelChanges<BlogContext>
    {
        protected override void Seed(BlogContext context)
        {
            List<Category> categories = new List<Category>()
            {
                new Category() {CategoryName="C#"},
                new Category() {CategoryName="Asp.Net MVC"},
                new Category() {CategoryName="Asp.Net WebForm"},
                new Category() {CategoryName="Windows Form"},
            };

            foreach (var item in categories)
            {
                context.Categories.Add(item);
            }
            context.SaveChanges();

            List<Blog> blogs = new List<Blog>()
            {
                new Blog() {Tittle="C# Delegates Hakkında", Description="Açıklama açıklanır açıklanıyor açıklayacı",AddDate=DateTime.Now.AddDays(-10),HomePage=true,Confirmation=true,Content="Açıklamak iyidir açıklayıcıdır ve çok güzeldir açıklama yapmak herkes açıklama yapmalı ve yaptırmalı açıklamalar hayatın bir bütünüdür açıklamak iyidir güzeldir.",Picture="1.jpg",CategoryId=1 },
                new Blog() {Tittle="C# Delegates Hakkında", Description="Açıklama açıklanır açıklanıyor açıklayacı",AddDate=DateTime.Now.AddDays(-10),HomePage=false,Confirmation=false,Content="Açıklamak iyidir açıklayıcıdır ve çok güzeldir açıklama yapmak herkes açıklama yapmalı ve yaptırmalı açıklamalar hayatın bir bütünüdür açıklamak iyidir güzeldir.",Picture="1.jpg",CategoryId=1 },
                new Blog() {Tittle="C# Delegates Hakkında", Description="Açıklama açıklanır açıklanıyor açıklayacı",AddDate=DateTime.Now.AddDays(-10),HomePage=true,Confirmation=true,Content="Açıklamak iyidir açıklayıcıdır ve çok güzeldir açıklama yapmak herkes açıklama yapmalı ve yaptırmalı açıklamalar hayatın bir bütünüdür açıklamak iyidir güzeldir.",Picture="2.jpg",CategoryId=1 },
                new Blog() {Tittle="C# Generic List Hakkında", Description="Açıklama açıklanır açıklanıyor açıklayacı",AddDate=DateTime.Now.AddDays(-10),HomePage=true,Confirmation=true,Content="Açıklamak iyidir açıklayıcıdır ve çok güzeldir açıklama yapmak herkes açıklama yapmalı ve yaptırmalı açıklamalar hayatın bir bütünüdür açıklamak iyidir güzeldir.",Picture="1.jpg",CategoryId=2 },
                new Blog() {Tittle="C# Web Forms Hakkında", Description="Açıklama açıklanır açıklanıyor açıklayacı",AddDate=DateTime.Now.AddDays(-10),HomePage=false,Confirmation=false,Content="Açıklamak iyidir açıklayıcıdır ve çok güzeldir açıklama yapmak herkes açıklama yapmalı ve yaptırmalı açıklamalar hayatın bir bütünüdür açıklamak iyidir güzeldir.",Picture="2.jpg",CategoryId=2 },
                new Blog() {Tittle="C# Mvc Hakkında", Description="Açıklama açıklanır açıklanıyor açıklayacı",AddDate=DateTime.Now.AddDays(-10),HomePage=false,Confirmation=false,Content="Açıklamak iyidir açıklayıcıdır ve çok güzeldir açıklama yapmak herkes açıklama yapmalı ve yaptırmalı açıklamalar hayatın bir bütünüdür açıklamak iyidir güzeldir.",Picture="1.jpg",CategoryId=2 },
                new Blog() {Tittle="C# Delegates Hakkında", Description="Açıklama açıklanır açıklanıyor açıklayacı",AddDate=DateTime.Now.AddDays(-10),HomePage=true,Confirmation=true,Content="Açıklamak iyidir açıklayıcıdır ve çok güzeldir açıklama yapmak herkes açıklama yapmalı ve yaptırmalı açıklamalar hayatın bir bütünüdür açıklamak iyidir güzeldir.",Picture="2.jpg",CategoryId=3 },
                new Blog() {Tittle="C# Delegates Hakkında", Description="Açıklama açıklanır açıklanıyor açıklayacı",AddDate=DateTime.Now.AddDays(-10),HomePage=true,Confirmation=true,Content="Açıklamak iyidir açıklayıcıdır ve çok güzeldir açıklama yapmak herkes açıklama yapmalı ve yaptırmalı açıklamalar hayatın bir bütünüdür açıklamak iyidir güzeldir.",Picture="1.jpg",CategoryId=3 },
                new Blog() {Tittle="C# Delegates Hakkında", Description="Açıklama açıklanır açıklanıyor açıklayacı",AddDate=DateTime.Now.AddDays(-10),HomePage=false,Confirmation=false,Content="Açıklamak iyidir açıklayıcıdır ve çok güzeldir açıklama yapmak herkes açıklama yapmalı ve yaptırmalı açıklamalar hayatın bir bütünüdür açıklamak iyidir güzeldir.",Picture="2.jpg",CategoryId=3 },
                new Blog() {Tittle="C# Delegates Hakkında", Description="Açıklama açıklanır açıklanıyor açıklayacı",AddDate=DateTime.Now.AddDays(-10),HomePage=true,Confirmation=true,Content="Açıklamak iyidir açıklayıcıdır ve çok güzeldir açıklama yapmak herkes açıklama yapmalı ve yaptırmalı açıklamalar hayatın bir bütünüdür açıklamak iyidir güzeldir.",Picture="1.jpg",CategoryId=4 },
                new Blog() {Tittle="C# Delegates Hakkında", Description="Açıklama açıklanır açıklanıyor açıklayacı",AddDate=DateTime.Now.AddDays(-10),HomePage=true,Confirmation=true,Content="Açıklamak iyidir açıklayıcıdır ve çok güzeldir açıklama yapmak herkes açıklama yapmalı ve yaptırmalı açıklamalar hayatın bir bütünüdür açıklamak iyidir güzeldir.",Picture="2.jpg",CategoryId=4 },
                new Blog() {Tittle="C# Delegates Hakkında", Description="Açıklama açıklanır açıklanıyor açıklayacı",AddDate=DateTime.Now.AddDays(-10),HomePage=true,Confirmation=true,Content="Açıklamak iyidir açıklayıcıdır ve çok güzeldir açıklama yapmak herkes açıklama yapmalı ve yaptırmalı açıklamalar hayatın bir bütünüdür açıklamak iyidir güzeldir.",Picture="1.jpg",CategoryId=4 },
              
            };
            foreach (var item in blogs)
            {
                context.Blogs.Add(item);
            }
            context.SaveChanges();

            base.Seed(context);
        }
    }
}