using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EPMS.Interfaces.IServices;
using EPMS.WebBase.Mvc;

namespace EPMS.Web.Controllers
{
    public class ReportsController : BaseController
    {
        //
        // GET: /Reports/
        [SiteAuthorize(PermissionKey = "PrisonerReport")]
        public ActionResult PrisonerReport()
        {
            return View();
        }
	}
}