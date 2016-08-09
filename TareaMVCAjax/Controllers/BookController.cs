using TareaMVCAjax.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AjaxExample.Controllers
{
    public class BookController : Controller
    {

        private ApplicationDbContext db;

        public BookController()
        {
           db = new ApplicationDbContext();
        }

      
        // GET: Book
        public ActionResult Index()
        {
            return View();
        }

        
        public ActionResult GetBooks()
        {
            var books = db.Books.ToList();

            return Json(books, JsonRequestBehavior.AllowGet);
        }

       
        public ActionResult Get(int id)
        {
            var book = db.Books.ToList().Find(m => m.Id == id);
            return Json(book, JsonRequestBehavior.AllowGet);
        }

        
        [HttpPost]
        public ActionResult Create([Bind(Exclude = "Id")] Book book)
        {
            if (ModelState.IsValid)
            {
                db.Books.Add(book);
                db.SaveChanges();
            }

            return Json(book, JsonRequestBehavior.AllowGet);
        }

       
        [HttpPost]
        public ActionResult Update(Book book)
        {
            if (ModelState.IsValid)
            {
                db.Entry(book).State = EntityState.Modified;
                db.SaveChanges();
            }

            return Json(book, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var book = db.Books.ToList().Find(m => m.Id == id);
            if (book != null)
            {
                db.Books.Remove(book);
                db.SaveChanges();
            }

            return Json(book, JsonRequestBehavior.AllowGet);
        }
    }
}