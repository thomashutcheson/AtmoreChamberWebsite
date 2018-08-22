using AtmoreChamber.Models;
using Square.Connect.Api;
using Square.Connect.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
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
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Create(Product productModel)
        {
            string fileName = Path.GetFileNameWithoutExtension(productModel.ImageFile.FileName);
            string extension = Path.GetExtension(productModel.ImageFile.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            productModel.ImagePath = "~/Content/images/products/" + fileName;
            fileName = Path.Combine(Server.MapPath("~/Content/images/products/"), fileName);
            productModel.ImageFile.SaveAs(fileName);
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                db.Products.Add(productModel);
                db.SaveChanges();
            }
            ModelState.Clear();
            return View();
        }


        /* commented out, would not upload image to directory
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Create([Bind(Include = "ProductID,ProductTitle,ProductDescription,ImagePath,ProductPrice,ImageFile")] Product product)
        {
            if (ModelState.IsValid)
            {
                if (Request.Files != null)
                {
                    foreach (string key in Request.Files)
                    {
                        var file = Request.Files[key]; 
                        if (file.ContentLength > 0)
                        {
                            string fileName = Path.GetFileNameWithoutExtension(product.ImageFile.FileName);
                            string extension = Path.GetExtension(product.ImageFile.FileName);
                            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                            product.ImagePath = "~/Content/images/products/" + fileName;
                            fileName = Path.Combine(Server.MapPath("~/Content/images/products/"), fileName);
                            product.ImageFile.SaveAs(fileName);
                            //using (ApplicationDbContext db = new ApplicationDbContext())
                            {
                                db.Products.Add(product);
                                db.SaveChanges();
                            }
                            ModelState.Clear();
                            return View();
                        }
                    }
                }
            }
            return View();
        } */

        // GET: Products/Edit/5
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
        public ActionResult Edit([Bind(Include = "ProductID,ProductTitle,ProductDescription,ImagePath,ProductPrice")] Product products)
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
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
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


        public ActionResult SqPaymentForm()
        {
            return View();
        }

        public ActionResult SqPaymentProcessing()
        {
            return View();
        }

        public ActionResult PaymentConfirmation()
        {
            return View();
        }



        public ActionResult ChargeNonce()
        {

            string accessToken = "sandbox-sq0atb-D4TFGj4GmAew2U1yDuxe3Q";

            // Set the location ID
            string locId = "CBASECShk_d_mWkyYVT6bgiV52AgAQ";


            //Create configuration object for apiClient
            Square.Connect.Client.Configuration apiConfiguration = new Square.Connect.Client.Configuration();
            apiConfiguration.AccessToken = accessToken;

            //Create instance of api client
            Square.Connect.Client.ApiClient apiClient = new Square.Connect.Client.ApiClient(apiConfiguration);


            //Create instance of Orders api
            OrdersApi orderApi = new OrdersApi(apiConfiguration);

            //Create instance of Orders api
            CheckoutApi checkoutApi = new CheckoutApi(apiConfiguration);


            //Grab items from session and put them in a list
            List<Item> cartSession = (List<Item>)Session["cart"] != null ? (List<Item>)Session["cart"] : new List<Item>();


            //Create Line Item Request instance
            List<CreateOrderRequestLineItem> lineItems = new List<CreateOrderRequestLineItem>();

            //Create line item for each item stored in the cart session
            foreach (var item in cartSession)
            {
                int lineItemPrice = (int)(item.Product.ProductPrice * 100);

                Money price = new Money(lineItemPrice, Money.CurrencyEnum.USD);
                CreateOrderRequestLineItem lineItem = new CreateOrderRequestLineItem(item.Product.ProductTitle, item.Quantity.ToString(), price);

                lineItems.Add(lineItem);

            }

            string idempotencyKey = Guid.NewGuid().ToString();

            //Create new order request instance with cart items
            CreateOrderRequest orderRequest = new CreateOrderRequest(idempotencyKey, null, lineItems);

            //Get return URL
            //var urlBuilder =
            //new System.UriBuilder(Request.Url.AbsoluteUri)
            //{
            //    Path = Url.Action("PaymentConfirmation", "Products"),
            //    Query = null,
            //};

            //Uri uri = urlBuilder.Uri;
            //string url = urlBuilder.ToString();
            //UNCOMMENT AND CHANGE LAST NULL PARAMETER TO url


            CreateCheckoutRequest checkoutRequest = new CreateCheckoutRequest(idempotencyKey, orderRequest, true, null, null, null);

            try
            {
                var checkoutResponse = checkoutApi.CreateCheckout(locId, checkoutRequest);

                return Redirect(checkoutResponse.Checkout.CheckoutPageUrl);

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
