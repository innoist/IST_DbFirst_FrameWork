using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EPMS.Interfaces.IServices;
using EPMS.Models.RequestModels;
using EPMS.Models.DomainModels;
using EPMS.Web.ModelMappers;
using EPMS.Web.Models;
using EPMS.Web.ViewModels.Common;
using EPMS.Web.ViewModels.DetentionLocation;
using EPMS.Web.ViewModels.DetentionLocation;
using DetentionLocation = EPMS.Web.Models.DetentionLocation;
//using Prisoner = EPMS.Models.DomainModels.Prisoner;

namespace EPMS.Web.Controllers
{
    public class DetentionLocationController : BaseController
    {
        private readonly IDetentionLocationService oDetentionLocationService;
        private readonly IPrisonerService oPrisonerService;

        #region Constructor

        public DetentionLocationController(IDetentionLocationService oDetentionLocationService, IPrisonerService oPrisonerService)
        {
            this.oDetentionLocationService = oDetentionLocationService;
            this.oPrisonerService = oPrisonerService;
        }

        #endregion

        #region Public

        public ActionResult Index()
        {
            if (Request.UrlReferrer == null || Request.UrlReferrer.AbsolutePath == "/DetentionLocation/Index")
            {
                Session["PageMetaData"] = null;
            }

            DetentionLocationSearchRequest detentionLocationSearchRequest =
                Session["PageMetaData"] as DetentionLocationSearchRequest;

            Session["PageMetaData"] = null;

            ViewBag.MessageVM = TempData["MessageVm"] as MessageViewModel;

            return View(new DetentionLocationViewModel
            {
                SearchRequest = detentionLocationSearchRequest ?? new DetentionLocationSearchRequest()
            });
        }

        [HttpPost]

        public ActionResult Index(DetentionLocationSearchRequest detentionLocationSearchRequest)
        {
            detentionLocationSearchRequest.UserId = Guid.Parse(Session["LoginID"] as string);
            var detentionAuthorities = oDetentionLocationService.GetAllDetentionLocations(detentionLocationSearchRequest);
            IEnumerable<DetentionLocation> detentionLocationList =
                detentionAuthorities.DetentionLocations.Select(x => x.CreateFrom()).ToList();
            DetentionLocationAjaxViewModel detentionLocationAjaxViewModel = new DetentionLocationAjaxViewModel
            {
                data = detentionLocationList,
                recordsTotal = detentionAuthorities.TotalCount,
                recordsFiltered = detentionAuthorities.TotalCount
            };

            // Keep Search Request in Session
            Session["PageMetaData"] = detentionLocationSearchRequest;

            return Json(detentionLocationAjaxViewModel, JsonRequestBehavior.AllowGet);
        }

        public ActionResult AddEdit(int? id)
        {
            DetentionLocationViewModel viewModel = new DetentionLocationViewModel();
            if (id != null)
            {
                viewModel.DetentionLocation = oDetentionLocationService.FindDetentionLocationById(id).CreateFrom();

            }
            return View(viewModel);
        }

        // POST: DetentionLocation/AddEdit
        [HttpPost]
        public ActionResult AddEdit(DetentionLocationViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }
            try
            {
                #region Update

                if (viewModel.DetentionLocation.DetentionLocationId > 0)
                {
                    var detentionLocationToUpdate = viewModel.DetentionLocation.CreateFrom();
                    viewModel.DetentionLocation.UpdatedDate = DateTime.Now;
                    if (oDetentionLocationService.UpdateDetentionLocation(detentionLocationToUpdate))
                    {
                        return RedirectToAction("Index");
                    }
                }
                    #endregion

                    #region Add

                else
                {
                    viewModel.DetentionLocation.CreatedDate = DateTime.Now;
                    var modelToSave = viewModel.DetentionLocation.CreateFrom();

                    if (oDetentionLocationService.AddDetentionLocation(modelToSave))
                    {
                        viewModel.DetentionLocation.DetentionLocationId = modelToSave.DetentionLocationId;
                        return RedirectToAction("Index");
                    }
                }

                #endregion

            }
            catch (Exception e)
            {
                return RedirectToAction("AddEdit");
            }
            return View(viewModel);
        }

        public ActionResult Delete(int detentionLocationId)
        {
            var detentionLocationToBeDeleted = oDetentionLocationService.FindDetentionLocationById(detentionLocationId);
            try
            {
                var prisoners = oPrisonerService.LoadAllPrisoners();
                var enumerable = prisoners as IList<EPMS.Models.DomainModels.Prisoner> ?? prisoners.ToList();
                var prisonersWithDetentionId = enumerable.Where(x => x.PrisonerCaseInfo.DetentionLocationId != null && x.PrisonerCaseInfo.DetentionLocationId == detentionLocationId);
                if (!prisonersWithDetentionId.Any())
                {
                    oDetentionLocationService.DeleteDetentionLocation(detentionLocationToBeDeleted);
                    return
                    Json(
                        new
                        {
                            response = "Successfully Deleted  ",
                            status = (int)HttpStatusCode.OK
                        }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return
                    Json(
                        new
                        {
                            response = "Failed to delete. Error: Used in Prisoner Case Info ",
                            status = (int)HttpStatusCode.BadRequest
                        }, JsonRequestBehavior.AllowGet);
                }

            }
            catch (Exception exp)
            {
                return
                    Json(
                        new
                        {
                            response = "Failed to delete. Error: " + exp.Message,
                            status = (int)HttpStatusCode.BadRequest
                        }, JsonRequestBehavior.AllowGet);
            }
        }

    #endregion

    }
}