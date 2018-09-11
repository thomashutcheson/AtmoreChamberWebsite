using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AtmoreChamber.Models;
using AtmoreChamberPinnacle.Models;

namespace AtmoreChamberPinnacle.Controllers
{
    public class ParagraphController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Paragraph
        public ActionResult Index()
        {
            return View(db.Paragraphs.ToList());
        }

        // GET: Paragraph/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Paragraph paragraph = db.Paragraphs.Find(id);
            if (paragraph == null)
            {
                return HttpNotFound();
            }
            return View(paragraph);
        }

        // GET: Paragraph/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Paragraph/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Title,Link,Subtitle,Text")] Paragraph paragraph)
        {
            if (ModelState.IsValid)
            {
                db.Paragraphs.Add(paragraph);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(paragraph);
        }

        // GET: Paragraph/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Paragraph paragraph = db.Paragraphs.Find(id);
            if (paragraph == null)
            {
                return HttpNotFound();
            }
            return View(paragraph);
        }

        // POST: Paragraph/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Title,Link,Subtitle,Text")] Paragraph paragraph)
        {
            if (ModelState.IsValid)
            {
                db.Entry(paragraph).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(paragraph);
        }

        // GET: Paragraph/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Paragraph paragraph = db.Paragraphs.Find(id);
            if (paragraph == null)
            {
                return HttpNotFound();
            }
            return View(paragraph);
        }

        // POST: Paragraph/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Paragraph paragraph = db.Paragraphs.Find(id);
            db.Paragraphs.Remove(paragraph);
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
