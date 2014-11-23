<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms"
    TagPrefix="rsweb" %>
<%@ Register Assembly="System.Runtime, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" Namespace="System.Runtime" TagPrefix="runtime" %>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PrisonerInfo.aspx.cs" Inherits="EPMS.Web.Reports.PrisonerInfo" MasterPageFile="~/Views/Shared/ES.Master" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
                            
<rsweb:ReportViewer ID="PrisonerViewer1" runat="server" Width="100%" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Height="600px"></rsweb:ReportViewer>

 <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>                       
</asp:Content>