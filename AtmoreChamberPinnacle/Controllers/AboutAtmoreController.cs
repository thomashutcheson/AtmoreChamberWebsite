using AtmoreChamber.Models;
using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;

namespace AtmoreChamber.Controllers
{
    public class AboutAtmoreController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult OurHistory()
        {
            return View();
        }

        public ActionResult OurCommunity()
        { 
            return View();
        }

        public ActionResult RelocationandHelpfulResources()
        {
            return View();
        }

        public ActionResult InformationRequest()
        {
            return View();
        }

        //    public ActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}
