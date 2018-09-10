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
    public class TextBoxesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TextBoxes
        public ActionResult Index()
        {
            return View(db.TextBoxes.ToList());
        }

        // GET: TextBoxes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TextBox textBox = db.TextBoxes.Find(id);
            if (textBox == null)
            {
                return HttpNotFound();
            }
            return View(textBox);
        }

        // GET: TextBoxes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TextBoxes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Title,Paragraph")] TextBox textBox)
        {
            if (ModelState.IsValid)
            {
                db.TextBoxes.Add(textBox);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(textBox);
        }

        // GET: TextBoxes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TextBox textBox = db.TextBoxes.Find(id);
            if (textBox == null)
            {
                return HttpNotFound();
            }
            return View(textBox);
        }

        // POST: TextBoxes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Title,Paragraph")] TextBox textBox)
        {
            if (ModelState.IsValid)
            {
                db.Entry(textBox).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(textBox);
        }

        // GET: TextBoxes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TextBox textBox = db.TextBoxes.Find(id);
            if (textBox == null)
            {
                return HttpNotFound();
            }
            return View(textBox);
        }

        // POST: TextBoxes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TextBox textBox = db.TextBoxes.Find(id);
            db.TextBoxes.Remove(textBox);
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
