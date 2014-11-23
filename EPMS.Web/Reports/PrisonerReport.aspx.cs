using EPMS.Interfaces.IServices;
using EPMS.Models.RequestModels;
using EPMS.Web.ModelMappers;
using Microsoft.Practices.Unity;
using Microsoft.Reporting.WebForms;
using System;
using System.Linq;
using System.Web.UI.WebControls;
using EPMS.WebBase.UnityConfiguration;

namespace EPMS.Web.Reports
{
    
    public partial class PrisonerReport : System.Web.UI.Page
    {
        public IPrisonerService PrisonerService{ get; set; }
        public ICaseTypeService oCaseTypeService { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {
                return;
            }
            //RegisterTypes();

            if (!Page.IsPostBack)
            {
                oCaseTypeService = UnityWebActivator.Container.Resolve<ICaseTypeService>();
                CaseTypes.DataTextField = "CaseTypeName";
                CaseTypes.DataValueField = "CaseTypeId";
                CaseTypes.DataSource = oCaseTypeService.LoadAll();
                CaseTypes.DataBind();
                CaseTypes.Items.Insert(0, new ListItem("--- Select Case type ---", "0")); 

              //  PopulateControls();
            }

            SetupReport();
        }

       
        private void PopulateControls()
        {
            //Register drop downs if there is any
            throw new NotImplementedException();
        }

        private void RegisterTypes()
        {
            //ISERVICE TYPES
        }
        private void SetupReport()
        {
            PrisonerService = UnityWebActivator.Container.Resolve<IPrisonerService>();
            
            PrisonerViewer.ProcessingMode = ProcessingMode.Local;
            PrisonerViewer.LocalReport.ReportPath = Server.MapPath("~/Reports/PrisonerReport.rdlc");

            // var prisoners = PrisonerService.GetAllPrisoners( request);
            PrisonerSearchRequest request = new PrisonerSearchRequest();
            request.PrisonerName = TextBox1.Text;
            request.PrisonerCnic = TextBox2.Text;
            request.PrisonerPassport = TextBox3.Text;
            request.Iqama = TextBox4.Text;
            request.Address = TextBox5.Text;
            request.CaseType = int.Parse(CaseTypes.SelectedValue); 

            ReportDataSource reportDataSource = new ReportDataSource
            {
                Name = "DataSet1",
                Value = PrisonerService.GetAllPrisoners(request).Prisoners.Select(x=> x.CreateFrom())
            };
            
            PrisonerViewer.LocalReport.EnableExternalImages = true;
            PrisonerViewer.LocalReport.EnableHyperlinks = true;
            PrisonerViewer.HyperlinkTarget = "_blank";
            PrisonerViewer.LinkActiveColor = System.Drawing.Color.Blue;
            PrisonerViewer.LocalReport.DataSources.Clear();
            PrisonerViewer.LocalReport.DataSources.Add(reportDataSource);
            ReportParameter[] tblParam = new ReportParameter[6];
            tblParam[0] = new ReportParameter("FilterName", TextBox1.Text);
            tblParam[1] = new ReportParameter("FilterPrisonerCNIC", TextBox2.Text);
            tblParam[2] = new ReportParameter("FilterPrisonerPassport", TextBox3.Text);
            tblParam[3] = new ReportParameter("FilterPrisonerIqama", TextBox4.Text);
            tblParam[4] = new ReportParameter("FilterPrisonerAddress", TextBox5.Text);
            tblParam[5] = new ReportParameter("FilterCaseType", CaseTypes.SelectedValue == "0"? string.Empty: CaseTypes.SelectedItem.Text);
            PrisonerViewer.LocalReport.SetParameters(tblParam);
            PrisonerViewer.LocalReport.Refresh();
        }
    
        protected void btnReset_OnClick(object sender, EventArgs e)
        {
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            TextBox4.Text = "";
            TextBox5.Text = "";
            CaseTypes.SelectedIndex = 0;
            SetupReport();
        }

        protected void btnFilter_OnClick(object sender, EventArgs e)
        {
            SetupReport();
        }
    }
}