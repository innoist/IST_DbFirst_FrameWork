using System.Web.Mvc;
using IdentitySample.Controllers;

namespace EPMS.Web.Controllers
{
    public class UnauthorizedRequestController : Controller
    {
        //
        // GET: /UnauthorizedRequest/
        public ActionResult Index()
        {
            return View();
        }
	}
}