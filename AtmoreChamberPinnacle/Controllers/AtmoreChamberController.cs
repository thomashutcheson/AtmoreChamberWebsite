using AtmoreChamberPinnacle.Models;
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
    public class AtmoreChamberController : Controller
    {
        public ActionResult Index()
        {
            return View("ExecutiveBoard");
        }

        public ActionResult ExecutiveBoard()
        { 
            return View();
        }

        public ActionResult BoardOfDirectors()
        {
            return View();
        }

        public ActionResult Staff()
        {
            return View();
        }

        [Authorize]
        public ActionResult Members()
        {
            return View();
        }

        //public ActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}
