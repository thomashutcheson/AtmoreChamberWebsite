using AtmoreChamber.Model;
using AtmoreChamber.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace AtmoreChamber.Controllers
{
    public class MemberDirectoriesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: MemberDirectories
        public ActionResult Index()
        {
            return View(db.MemberDirectories.ToList());
        }

        // GET: MemberDirectories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MemberDirectory memberDirectory = db.MemberDirectories.Find(id);
            if (memberDirectory == null)
            {
                return HttpNotFound();
            }
            return View(memberDirectory);
        }

        // GET: MemberDirectories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MemberDirectories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Business,BusinessAddress,Phone,Fax,Website")] MemberDirectory memberDirectory)
        {
            if (ModelState.IsValid)
            {
                db.MemberDirectories.Add(memberDirectory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(memberDirectory);
        }

        // GET: MemberDirectories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MemberDirectory memberDirectory = db.MemberDirectories.Find(id);
            if (memberDirectory == null)
            {
                return HttpNotFound();
            }
            return View(memberDirectory);
        }

        // POST: MemberDirectories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Business,BusinessAddress,Phone,Fax,Website")] MemberDirectory memberDirectory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(memberDirectory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(memberDirectory);
        }

        // GET: MemberDirectories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MemberDirectory memberDirectory = db.MemberDirectories.Find(id);
            if (memberDirectory == null)
            {
                return HttpNotFound();
            }
            return View(memberDirectory);
        }

        // POST: MemberDirectories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MemberDirectory memberDirectory = db.MemberDirectories.Find(id);
            db.MemberDirectories.Remove(memberDirectory);
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
