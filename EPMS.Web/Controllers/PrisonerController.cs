using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Web.Hosting;
using EPMS.Models.DomainModels;
using EPMS.Models.RequestModels;
using EPMS.Web.Files;
using EPMS.Web.ModelMappers;
using EPMS.Web.ViewModels.Common;
using EPMS.Web.ViewModels.Prisoner;
using System.Web.Mvc;
using EPMS.Interfaces.IServices;
using EPMS.WebBase.Mvc;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Prisoner = EPMS.Web.Models.Prisoner;

namespace EPMS.Web.Controllers
{
    public class PrisonerController : BaseController
    {
        #region Private

        private readonly IPrisonerService oService;
        private readonly ICaseTypeService oCaseTypeService;
        private readonly ICaseStatusService oCaseStatusService;
        private readonly IDetentionAuthorityService oDetanAuthorityService;
        private readonly IDetentionLocationService oDetanLocationService;
        private readonly ICityService oCityService;

        /// <summary>
        /// Add File Data in Attachment Table
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        private bool AddFile(PrisonerViewModel viewModel)
        {
            try
            {
                var filename = viewModel.Prisoner.UploadFile.FileName;
                var prisonerId = viewModel.Prisoner.PrisonerId;
                if (prisonerId > 0)
                {
                    filename = (prisonerId+ "-" + filename);
                }
                //viewModel.Prisoner.FileName = viewModel.Prisoner.UploadFile.FileName;
                //var filePathOriginal = Server.MapPath(ConfigurationManager.AppSettings["PrisonerFiles"]);
                //if (!Directory.Exists(filePathOriginal))
                //{
                //    Directory.CreateDirectory(filePathOriginal);
                //}
                //var savedFileName = Path.Combine(filePathOriginal, filename);
                //viewModel.Prisoner.UploadFile.SaveAs(savedFileName);
                viewModel.Prisoner.Attachment = new Attachment
                                                {
                                                    AttachmentName = viewModel.Prisoner.AttachmentName ?? string.Empty,
                                                    PrisonerId =(int) viewModel.Prisoner.PrisonerId,
                                                    FileName = filename,
                                                    Comment = viewModel.Prisoner.AttachmentComment ?? string.Empty,
                                                    CreatedBy = Session["LoginID"] as string,
                                                    CreatedDate = DateTime.Now
                                                };

                return true;
            }
            catch (Exception)
            {
                TempData["ErrorMessage"] = "File Not Saved Successfully";
                return false;
            }

        }

        /// <summary>
        /// Save Files in "PrisonerFiles Folder"
        /// </summary>
        /// <param name="viewModel"></param>
        private void SaveFileInFolder(PrisonerViewModel viewModel)
        {
            if (viewModel.Prisoner.UploadFile != null)
            {

                var filename = viewModel.Prisoner.PrisonerId + "-" + viewModel.Prisoner.UploadFile.FileName;

                var filePathOriginal = Server.MapPath(ConfigurationManager.AppSettings["PrisonerFiles"]);
                if (!Directory.Exists(filePathOriginal))
                {
                    Directory.CreateDirectory(filePathOriginal);
                }
                var savedFileName = Path.Combine(filePathOriginal, filename);
                viewModel.Prisoner.UploadFile.SaveAs(savedFileName);
            }
        }

        #endregion

        #region Constructor

        public PrisonerController(IPrisonerService iService, ICaseTypeService oCaseTypeService,
            ICaseStatusService oCaseStatusService, IDetentionLocationService oDetanLocationService,
            IDetentionAuthorityService oDetanAuthorityService, ICityService oCityService)
        {
            oService = iService;
            this.oCaseTypeService = oCaseTypeService;
            this.oCaseStatusService = oCaseStatusService;
            this.oDetanAuthorityService = oDetanAuthorityService;
            this.oCityService = oCityService;
            this.oDetanLocationService = oDetanLocationService;
        }

        #endregion

        #region Public
        public ActionResult Index()
        {
            if (Request.UrlReferrer == null || Request.UrlReferrer.AbsolutePath == "/Prisoner/Index")
            {
                Session["PageMetaData"] = null;
            }

            PrisonerSearchRequest prisonerSearchRequest = Session["PageMetaData"] as PrisonerSearchRequest;

            Session["PageMetaData"] = null;

            ViewBag.MessageVM = TempData["MessageVm"] as MessageViewModel;

            return View(new PrisonerViewModel
                        {
                            CaseTypes = oCaseTypeService.LoadAll(),
                            SearchRequest = prisonerSearchRequest ?? new PrisonerSearchRequest()
                        });
        }

        [HttpPost]

        public ActionResult Index(PrisonerSearchRequest prisonerSearchRequest)
        {
            prisonerSearchRequest.UserId = Guid.Parse(Session["LoginID"] as string);
            var prisoners = oService.GetAllPrisoners(prisonerSearchRequest);
            IEnumerable<Prisoner> prisonerList = prisoners.Prisoners.Select(x => x.CreateFrom(false)).ToList();
            PrisonerAjaxViewModel prisonerListViewModel = new PrisonerAjaxViewModel
                                                          {
                                                              data = prisonerList,
                                                              recordsTotal = prisoners.TotalCount,
                                                              recordsFiltered = prisoners.TotalCount
                                                          };

            // Keep Search Request in Session
            Session["PageMetaData"] = prisonerSearchRequest;

            return Json(prisonerListViewModel, JsonRequestBehavior.AllowGet);
        }

        // GET: Prisoner/AddEdit
        //[Authorize(Roles = "Employee")]
        [SiteAuthorize(PermissionKey = "PrisonerAddEdit")]
        public ActionResult AddEdit(int? id)
        {
            PrisonerViewModel viewModel = new PrisonerViewModel();
            if (id != null)
            {
                viewModel.Prisoner = oService.FindPrisonerById(id).CreateFrom(true);

            }
            viewModel.CaseTypes = oCaseTypeService.LoadAll();
            viewModel.CaseStatuses = oCaseStatusService.LoadAll();
            viewModel.DetanAuthorities = oDetanAuthorityService.LoadAll();
            viewModel.DetanLocations = oDetanLocationService.LoadAll();
            viewModel.Cities = oCityService.LoadAll();
            return View(viewModel);
        }

        // POST: Prisoner/AddEdit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddEdit(PrisonerViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.CaseTypes = oCaseTypeService.LoadAll();
                viewModel.CaseStatuses = oCaseStatusService.LoadAll();
                viewModel.DetanAuthorities = oDetanAuthorityService.LoadAll();
                viewModel.DetanLocations = oDetanLocationService.LoadAll();
                viewModel.Cities = oCityService.LoadAll();
                return View(viewModel);
            }
            try
            {
                #region Update 

                if (viewModel.Prisoner.PrisonerId > 0)
                {
                    if (viewModel.Prisoner.UploadFile != null)
                    {
                        var result = AddFile(viewModel);
                        if (result == false)
                        {
                            throw new Exception("Error: File Not Saved Successfully!");
                        }
                        SaveFileInFolder(viewModel);
                    }
                    var prisonerToUpdate = viewModel.Prisoner.CreateFrom(true);
                    if (viewModel.Prisoner.UploadFile != null)
                    {
                        prisonerToUpdate.Attachments.LastOrDefault().FileName = viewModel.Prisoner.Attachment.FileName;
                    }
                    viewModel.Prisoner.UpdatedDate = DateTime.Now;
                    if (oService.UpdatePrisoner(prisonerToUpdate))
                    {
                        return RedirectToAction("Index");
                    }
                }
                    #endregion

                    #region Add

                else
                {
                    viewModel.Prisoner.CreatedDate = DateTime.Now;
                    var modelToSave = viewModel.Prisoner.CreateFrom(true);

                    #region Add File

                    if (viewModel.Prisoner.UploadFile != null)
                    {
                        viewModel.Prisoner.PrisonerId = modelToSave.PrisonerId;
                        var result = AddFile(viewModel);
                        if (result == false)
                        {
                            throw new Exception("Error: File Not Saved Successfully!");
                        }
                    }

                    #endregion

                    if (oService.AddPrisoner(modelToSave))
                    {
                        viewModel.Prisoner.PrisonerId = modelToSave.PrisonerId;
                        SaveFileInFolder(viewModel);
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
        [SiteAuthorize(PermissionKey = "DeletePrisoner")]
        public ActionResult Delete(int prisonerId)
        {
            var prisonerToBeDeleted = oService.FindPrisonerById(prisonerId);
            try
            {
                oService.DeletePrisoner(prisonerToBeDeleted);
            }
            catch (Exception exp)
            {
                return
                    Json(
                        new
                        {
                            response = "Failed to delete. Error: " + exp.Message,
                            status = (int) HttpStatusCode.BadRequest
                        }, JsonRequestBehavior.AllowGet);
            }

            return Json(new {response = "Successfully deleted!", status = (int) HttpStatusCode.OK},
                JsonRequestBehavior.AllowGet);
        }

        public FileStreamResult GenerateOutPass(int Id)
        {
            var prisoner = oService.FindPrisonerById(Id);
            
            string mapPath = HostingEnvironment.MapPath("~/Resources/OP1.pdf");
            var pdfPath = Path.Combine(mapPath);
            var formFieldMap = PDFHelper.GetFormFieldNames(pdfPath);
            //Filling Fields
            formFieldMap["form1[0].#subform[0].Name_01[0]"] = prisoner.PrisonerFirstNameE;

            var pdfContents = PDFHelper.GeneratePDF(pdfPath, formFieldMap);

            MemoryStream outputStream = new MemoryStream();

            Document document = new Document();

            MemoryStream stream = new MemoryStream(pdfContents);
            PdfWriter.GetInstance(document, stream);

            byte[] byteInfo = stream.ToArray();
            outputStream.Write(byteInfo, 0, byteInfo.Length);
            outputStream.Position = 0;

            return File(outputStream, "application/pdf");
        }

        #endregion

    }
}