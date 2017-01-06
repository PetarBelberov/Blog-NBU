using Blog_Petar_Belberov.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Net;

namespace Blog_Petar_Belberov.Controllers
{
    public class ArticleController : Controller
    {
        // GET: Article
        public ActionResult Index()
        {
            return RedirectToAction("List");
        }

        // GET: Article/List
        public ActionResult List()
        {
            using (var database = new BlogDBContext())
            {
                 //Get articles from database
                var articles = database.Articles
                    .Include(a => a.Author)
                    .ToList();

                return View(articles);
            }
        }

        // GET: Article/Details
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            using (var database = new BlogDBContext())
            {
                //Get article from database
                var article = database.Articles
                    .Where(a => a.Id == id)
                    .Include(a => a.Author)
                    .First();

                if (article == null)
                {
                    return HttpNotFound();
                }

                return View(article);
            }
        }

        // GET: Article/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Article/Create
        [HttpPost]
        public ActionResult Create(Article article)
        {
            if (ModelState.IsValid)
            {
                using (var database = new BlogDBContext())
                {
                    //Get author id
                    var authorId = database.Users
                       .Where(u => u.UserName == this.User.Identity.Name)
                       .First()
                       .Id;

                    //Get articles author
                    article.AuthorId = authorId;

                    //Get article in DB
                    database.Articles.Add(article);
                    database.SaveChanges();

                    return RedirectToAction("Index");
                }
            }
   
            return View(article);
        }

        // GET: Article/Delete
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            using (var database = new BlogDBContext())
            {
                // Get article from database
                var article = database.Articles
                     .Where(a => a.Id == id)
                     .Include(a => a.Author)
                     .First();

                // Check if article exists
                if (article == null)
                {
                    return HttpNotFound();
                }

                // Pass article to view
                return View(article);
            }
        }

        // POST: Article/Delete
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            using (var database = new BlogDBContext())
            {
                // Get article from database
                var article = database.Articles
                     .Where(a => a.Id == id)
                     .Include(a => a.Author)
                     .First();

                // Check if article exists
                if (article == null)
                {
                    return HttpNotFound();
                }

                // Delete article from database
                database.Articles.Remove(article);
                database.SaveChanges();

                // Redirect to index page
                return RedirectToAction("Index");
            }
        }
    }
}