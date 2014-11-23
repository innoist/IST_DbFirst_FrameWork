using System;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using EPMS.Interfaces.IServices;
using EPMS.Web.ModelMappers;
using EPMS.Web.Models;
using EPMS.Web.ViewModels.Prisoner;

namespace EPMS.Web.Controllers
{
    [RequireHttps]
    //[Authorize]
    public class AdminController : BaseController
    {
        private readonly IPrisonerService prisonerService;


        public AdminController( IPrisonerService prisonerService)
        {
            this.prisonerService = prisonerService;
        }

        #region Home/Index
        public ActionResult Index()
        {
            PrisonerViewModel oViewModel = new PrisonerViewModel
            {
                PrisonerList = prisonerService.GetAllPrisoners().Select(x => x.CreateFrom()),
                PrisonerDetainedList = prisonerService.GetAllDetainedPrisoners(DateTime.Now.AddDays(-30).Date, DateTime.Now.Date).Select(x => x.CreateFrom()),
                PrisonerReleasedList = prisonerService.GetAllReleasedPrisoners(DateTime.Now.AddDays(-30).Date, DateTime.Now.Date).Select(x => x.CreateFrom())
            };
            oViewModel=SetStats(oViewModel);
            return View(oViewModel);
        }
        [HttpPost]
        public ActionResult Index(PrisonerRequestModel requestModel)
        {
            PrisonerViewModel oViewModel = new PrisonerViewModel
            {
                PrisonerList = prisonerService.GetAllPrisoners().Select(x => x.CreateFrom()),
                PrisonerDetainedList = prisonerService.GetAllDetainedPrisoners(requestModel.StartDate.Date,requestModel.EndDate.Date).Select(x=>x.CreateFrom()),
                PrisonerReleasedList = prisonerService.GetAllReleasedPrisoners(requestModel.StartDate.Date, requestModel.EndDate.Date).Select(x => x.CreateFrom())
            };

            return Json(oViewModel, JsonRequestBehavior.AllowGet);
        }

        private static PrisonerViewModel SetStats(PrisonerViewModel oViewModel)
        {
            DateTime dtStart = DateTime.Now.AddDays(-30); //new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);//Start of month
            dtStart = new DateTime(dtStart.Year, dtStart.Month, dtStart.Day);//Configuring now to last 30 days
            DateTime dtWeekStart = DateTime.Now.AddDays(-7);
            dtWeekStart = new DateTime(dtWeekStart.Year, dtWeekStart.Month, dtWeekStart.Day);//LAST 7 DAYS
            //Detained
            oViewModel.DetainedToday = oViewModel.PrisonerDetainedList.Count(x => x.DetentionDateDt == DateTime.Now.Date);
            oViewModel.DetainedWeek = oViewModel.PrisonerDetainedList.Count(x => (x.DetentionDateDt >= dtWeekStart) && (x.DetentionDateDt <= DateTime.Now.Date));
            oViewModel.DetainedMonth = oViewModel.PrisonerDetainedList.Count();
            //Released
            oViewModel.ReleasedToday = oViewModel.PrisonerReleasedList.Count(x => x.ReleaseDateDt == DateTime.Now.Date);
            oViewModel.ReleasedWeek = oViewModel.PrisonerReleasedList.Count(x => (x.ReleaseDateDt >= dtWeekStart) && (x.ReleaseDateDt <= DateTime.Now.Date));
            oViewModel.ReleasedMonth = oViewModel.PrisonerReleasedList.Count();
            return oViewModel;
        }
        #endregion

        #region Common

        private void DeleteFile(string pathName, string fileName)
        {
            var folderPath = Server.MapPath(ConfigurationManager.AppSettings[pathName]);
            FileInfo fileInfo = new FileInfo(folderPath + fileName);
            if (fileInfo.Exists)
            {
                fileInfo.Delete();
            }
        }
        #endregion
    }
}
