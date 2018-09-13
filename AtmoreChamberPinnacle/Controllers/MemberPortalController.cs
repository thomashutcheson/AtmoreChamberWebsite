using System.Web.Mvc;

namespace AtmoreChamberPinnacle.Controllers
{
    [Authorize]
    public class MemberPortalController : Controller
    {
        // GET: MemberPortal
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult RenewMembership()
        {
            return View();
        }

        public ActionResult Resources()
        {
            return View();
        }

        public ActionResult SubmitInfo()
        {
            return View();
        }

        public ActionResult SubmitLogo()
        {
            return View();
        }

        public ActionResult UpdateProfile()
        {
            return View();
        }


    }
}