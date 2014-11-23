using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using EPMS.Interfaces.IServices;
using EPMS.Models.RequestModels;
using EPMS.Web.ModelMappers;
using EPMS.Web.Models;
using EPMS.Web.ViewModels.CaseType;
using EPMS.Web.ViewModels.Common;
using Prisoner = EPMS.Models.DomainModels.Prisoner;

namespace EPMS.Web.Controllers
{
    public class CaseTypeController : BaseController
    {
        private readonly ICaseTypeService oCaseTypeService;
        private readonly IPrisonerService oPrisonerService;
        
        #region Constructor

        public CaseTypeController(ICaseTypeService oCaseTypeService, IPrisonerService oPrisonerService)
        {
            this.oCaseTypeService = oCaseTypeService;
            this.oPrisonerService = oPrisonerService;
        }

        #endregion

        #region Public

        public ActionResult Index()
        {
            if (Request.UrlReferrer == null || Request.UrlReferrer.AbsolutePath == "/CaseType/Index")
            {
                Session["PageMetaData"] = null;
            }

            CaseTypeSearchRequest caseTypeSearchRequest = Session["PageMetaData"] as CaseTypeSearchRequest;

            Session["PageMetaData"] = null;

            ViewBag.MessageVM = TempData["MessageVm"] as MessageViewModel;

            return View(new CaseTypeViewModel
            {
                SearchRequest = caseTypeSearchRequest ?? new CaseTypeSearchRequest()
            });
        }

        [HttpPost]

        public ActionResult Index(CaseTypeSearchRequest caseTypeSearchRequest)
        {
            caseTypeSearchRequest.UserId = Guid.Parse(Session["LoginID"] as string);
            var caseTypes = oCaseTypeService.GetAllCaseType(caseTypeSearchRequest);
            IEnumerable<CaseType> caseTypeList = caseTypes.CaseTypes.Select(x => x.CreateFrom()).ToList();
            CaseTypeAjaxViewModel caseTypeListViewModel = new CaseTypeAjaxViewModel
            {
                data = caseTypeList,
                recordsTotal = caseTypes.TotalCount,
                recordsFiltered = caseTypes.TotalCount
            };

            // Keep Search Request in Session
            Session["PageMetaData"] = caseTypeSearchRequest;

            return Json(caseTypeListViewModel, JsonRequestBehavior.AllowGet);
        }

        public ActionResult AddEdit(int? id)
        {
            CaseTypeViewModel viewModel = new CaseTypeViewModel();
            if (id != null)
            {
                viewModel.CaseType = oCaseTypeService.FindCaseTypeById(id).CreateFrom();

            }
            return View(viewModel);
        }

        // POST: CaseType/AddEdit
        [HttpPost]
        public ActionResult AddEdit(CaseTypeViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }
            try
            {
                #region Update

                if (viewModel.CaseType.CaseTypeId > 0)
                {
                    var caseTypeToUpdate = viewModel.CaseType.CreateFrom();
                    viewModel.CaseType.UpdatedDate = DateTime.Now;
                    if (oCaseTypeService.UpdateCaseType(caseTypeToUpdate))
                    {
                        return RedirectToAction("Index");
                    }
                }
                #endregion

                #region Add

                else
                {
                    viewModel.CaseType.CreatedDate = DateTime.Now;
                    var modelToSave = viewModel.CaseType.CreateFrom();

                    if (oCaseTypeService.AddCaseType(modelToSave))
                    {
                        viewModel.CaseType.CaseTypeId = modelToSave.CaseTypeId;
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

        public ActionResult Delete(int caseTypeId)
        {
            var caseTypeToBeDeleted = oCaseTypeService.FindCaseTypeById(caseTypeId);
            try
            {
                var prisoners = oPrisonerService.LoadAllPrisoners();
                var enumerable = prisoners as IList<Prisoner> ?? prisoners.ToList();
                var prisonersWithTypeId = enumerable.Where(x => x.PrisonerCaseInfo.CaseTypeId != null && x.PrisonerCaseInfo.CaseTypeId == caseTypeId);
                if (!prisonersWithTypeId.Any())
                {
                    oCaseTypeService.DeleteCaseType(caseTypeToBeDeleted);
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