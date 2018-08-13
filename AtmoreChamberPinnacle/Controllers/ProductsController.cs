using AtmoreChamber.Models;
using Square.Connect.Api;
using Square.Connect.Model;
using System;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AtmoreChamberPinnacle.Controllers
{
    public class ProductsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Products
        public ActionResult Manage()
        {
            return View(db.Products.ToList());
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product products = db.Products.Find(id);
            if (products == null)
            {
                return HttpNotFound();
            }
            return View(products);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductID,ProductTitle,ProductDescription,ProductIMG,ProductPrice")] Product product)
        {
            if (ModelState.IsValid)
            {
                if (Request.Files != null)
                {
                    foreach (HttpPostedFile file in Request.Files)
                    {
                        if (file.ContentLength > 0)
                        {
                            var fileName = Path.GetFileName(file.FileName);
                            var path = Path.Combine(Server.MapPath("~/Content/images/products"), fileName);
                            file.SaveAs(path);
                            product.ProductIMG = fileName;
                        }
                    }
                }

                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(product);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product products = db.Products.Find(id);
            if (products == null)
            {
                return HttpNotFound();
            }
            return View(products);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductID,ProductTitle,ProductDescription,ProductIMG,ProductPrice")] Product products)
        {
            if (ModelState.IsValid)
            {
                db.Entry(products).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(products);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product products = db.Products.Find(id);
            if (products == null)
            {
                return HttpNotFound();
            }
            return View(products);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product products = db.Products.Find(id);
            db.Products.Remove(products);
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

        public async Task<ActionResult> Index()
        {
            var Products = db.Products.SqlQuery("SELECT * FROM dbo.Products").ToList();


            return View(Products);
        }

        public ActionResult AddressForm()
        {

            return View();
        }

        public ActionResult SqPaymentForm()
        {

            return View();
        }

        public ActionResult SqPaymentProcessing()
        {

            return View();
        }


        // Below is the Square API required C#


        //public Example()
        //{
        //    Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";
        //}

        //// Retrieving your location IDs
        //public void RetrieveLocations()
        //{
        //    LocationsApi _locationsApi = new LocationsApi();
        //    var response = _locationsApi.ListLocations();
        //}

    
        // Charge the card nonce
        public ActionResult ChargeNonce(int amount, string nonce, string locationId)
        {
            // Every payment you process for a given business have a unique idempotency key.
            // If you're unsure whether a particular payment succeeded, you can reattempt
            // it with the same idempotency key without worrying about double charging
            // the buyer.
            string idempotencyKey = Guid.NewGuid().ToString();

            // Monetary amounts are specified in the smallest unit of the applicable currency.
            // This amount is in cents. It's also hard-coded for $1, which is not very useful.
            string currency = "USD";
            Money money = new Money(amount, Money.CurrencyEnum.USD);
            ChargeRequest body = new ChargeRequest(AmountMoney: money, IdempotencyKey: idempotencyKey, CardNonce: nonce);
            TransactionsApi transactionsApi = new TransactionsApi();
            var response = transactionsApi.Charge(locationId, body);


            return View("SqPaymentProcessing", "products");
        }



    





    }
}
