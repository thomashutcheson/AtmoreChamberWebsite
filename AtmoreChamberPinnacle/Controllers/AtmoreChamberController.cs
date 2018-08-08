using System.Web.Mvc;

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
