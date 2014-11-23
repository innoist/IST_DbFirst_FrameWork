using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EPMS.Implementation.Services;
using EPMS.Interfaces.IServices;
using EPMS.Models.DomainModels;
using EPMS.Models.RequestModels;
using EPMS.Web.ModelMappers;
using EPMS.WebBase.UnityConfiguration;
using Microsoft.Practices.Unity;
using Microsoft.Reporting.WebForms;

namespace EPMS.Web.Reports
{
    public partial class PrisonerInfo : System.Web.UI.Page
    {

        public IPrisonerService PrisonerService { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {
                return;
            }
            SetupReport();
        }

        private void SetupReport()
        {

            var id = Request.QueryString["id"];
            PrisonerService = UnityWebActivator.Container.Resolve<IPrisonerService>();

            PrisonerViewer1.ProcessingMode = ProcessingMode.Local;
            PrisonerViewer1.LocalReport.ReportPath = Server.MapPath("~/Reports/PrisonerInfo.rdlc");
            PrisonerSearchRequest request = new PrisonerSearchRequest();
            request.Id = Convert.ToInt32(id);
            
            ReportDataSource reportDataSource = new ReportDataSource
            {
                Name = "DataSet1",
                Value = PrisonerService.GetAllPrisoners(request).Prisoners.Select(x=> x.CreateFrom())
            };

            PrisonerViewer1.LocalReport.EnableExternalImages = true;
            PrisonerViewer1.LocalReport.EnableHyperlinks = true;
            PrisonerViewer1.HyperlinkTarget = "_blank";
            PrisonerViewer1.LinkActiveColor = System.Drawing.Color.Blue;
            PrisonerViewer1.LocalReport.DataSources.Clear();
            PrisonerViewer1.LocalReport.DataSources.Add(reportDataSource);

        }
    }
}