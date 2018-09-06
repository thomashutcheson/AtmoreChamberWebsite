using AtmoreChamber.Models;
using AtmoreChamberPinnacle.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace AtmoreChamberPinnacle.Controllers
{
    public class JumbotronController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Jumbotron
        public ActionResult Index()
        {
            return View(db.Jumbotrons.ToList());
        }

        // GET: Jumbotron/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jumbotron jumbotron = db.Jumbotrons.Find(id);
            if (jumbotron == null)
            {
                return HttpNotFound();
            }
            return View(jumbotron);
        }

        // POST: Jumbotron/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "JumbotronID,Title,Paragraph,ImagePath")] Jumbotron jumbotron)
        {
            if (ModelState.IsValid)
            {
                db.Entry(jumbotron).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(jumbotron);
        }

    }
}
