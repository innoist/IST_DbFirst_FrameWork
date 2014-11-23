using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EPMS.Interfaces.IServices;
using EPMS.Models.RequestModels;
using EPMS.Web.ModelMappers;
using EPMS.Web.Models;
using EPMS.Web.ViewModels.CaseStatus;
using EPMS.Web.ViewModels.Common;
using Prisoner = EPMS.Models.DomainModels.Prisoner;

namespace EPMS.Web.Controllers
{
    public class CaseStatusController : BaseController
    {
        private readonly ICaseStatusService oCaseStatusService;
        private readonly IPrisonerService oPrisonerService;
        
        #region Constructor

        public CaseStatusController(ICaseStatusService oCaseStatusService, IPrisonerService oPrisonerService)
        {
            this.oCaseStatusService = oCaseStatusService;
            this.oPrisonerService = oPrisonerService;
        }

        #endregion

        #region Public

        public ActionResult Index()
        {
            if (Request.UrlReferrer == null || Request.UrlReferrer.AbsolutePath == "/CaseStatus/Index")
            {
                Session["PageMetaData"] = null;
            }

            CaseStatusSearchRequest caseStatusSearchRequest = Session["PageMetaData"] as CaseStatusSearchRequest;

            Session["PageMetaData"] = null;

            ViewBag.MessageVM = TempData["MessageVm"] as MessageViewModel;

            return View(new CaseStatusViewModel
            {
                SearchRequest = caseStatusSearchRequest ?? new CaseStatusSearchRequest()
            });
        }

        [HttpPost]

        public ActionResult Index(CaseStatusSearchRequest caseStatusSearchRequest)
        {
            caseStatusSearchRequest.UserId = Guid.Parse(Session["LoginID"] as string);
            var caseStatuss = oCaseStatusService.GetAllCaseStatuses(caseStatusSearchRequest);
            IEnumerable<CaseStatus> prisonerList = caseStatuss.CaseStatuses.Select(x => x.CreateFrom()).ToList();
            CaseStatusAjaxViewModel prisonerListViewModel = new CaseStatusAjaxViewModel
            {
                data = prisonerList,
                recordsTotal = caseStatuss.TotalCount,
                recordsFiltered = caseStatuss.TotalCount
            };

            // Keep Search Request in Session
            Session["PageMetaData"] = caseStatusSearchRequest;

            return Json(prisonerListViewModel, JsonRequestBehavior.AllowGet);
        }

        public ActionResult AddEdit(int? id)
        {
            CaseStatusViewModel viewModel = new CaseStatusViewModel();
            if (id != null)
            {
                viewModel.CaseStatus = oCaseStatusService.FindCaseStatusById(id).CreateFrom();

            }
            return View(viewModel);
        }

        // POST: CaseStatus/AddEdit
        [HttpPost]
        public ActionResult AddEdit(CaseStatusViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }
            try
            {
                #region Update

                if (viewModel.CaseStatus.CaseStatusId > 0)
                {
                    var caseStatusToUpdate = viewModel.CaseStatus.CreateFrom();
                    viewModel.CaseStatus.UpdatedDate = DateTime.Now;
                    if (oCaseStatusService.UpdateCaseStatus(caseStatusToUpdate))
                    {
                        return RedirectToAction("Index");
                    }
                }
                #endregion

                #region Add

                else
                {
                    viewModel.CaseStatus.CreatedDate = DateTime.Now;
                    var modelToSave = viewModel.CaseStatus.CreateFrom();

                    if (oCaseStatusService.AddCaseStatus(modelToSave))
                    {
                        viewModel.CaseStatus.CaseStatusId = modelToSave.CaseStatusId;
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

        public ActionResult Delete(int caseStatusId)
        {
            var caseStatusToBeDeleted = oCaseStatusService.FindCaseStatusById(caseStatusId);
            try
            {
                var prisoners = oPrisonerService.LoadAllPrisoners();
                var enumerable = prisoners as IList<Prisoner> ?? prisoners.ToList();
                var prisonersWithStatusId = enumerable.Where(x => x.PrisonerCaseInfo.CaseStatusId != null && x.PrisonerCaseInfo.CaseStatusId == caseStatusId);
                if (!prisonersWithStatusId.Any())
                {
                    oCaseStatusService.DeleteCaseStatus(caseStatusToBeDeleted);
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