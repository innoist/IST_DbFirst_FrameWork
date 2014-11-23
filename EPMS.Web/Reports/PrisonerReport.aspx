<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms"
    TagPrefix="rsweb" %>
<%@ Register Assembly="System.Runtime, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" Namespace="System.Runtime" TagPrefix="runtime" %>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PrisonerReport.aspx.cs" Inherits="EPMS.Web.Reports.PrisonerReport" MasterPageFile="~/Views/Shared/ES.Master" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <%-- <div class="tab-content">
        <div class="tab-pane active" id="tab_1">
            <div class="portlet box grey-salt">
                <div class="portlet-title">
                    <div class="caption">
                        <i class="fa fa-user"></i>Prisoner Reward
                    </div>
                    <div class="tools" style="min-height: 50px;">
                        <a href="javascript:;" class="collapse"></a>
                    </div>
                </div>
                <div class="portlet-body form">
                        <rsweb:ReportViewer ID="ReportViewerRewards" runat="server" Width="100%" Font-Names="Verdana"  Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt">
    </rsweb:ReportViewer>
    </div>
            </div>
        </div>
    </div>  --%>
    <div class="matter" style="margin-left: 10px; margin-right: 10px;">
        <div>
            <!-- Dashboard Graph starts -->
            <div class="row">
                <div class="col-md-12">
                    <div class="widget">
                        <div class="widget-head">
                            &nbsp;
                            <div class="pull-right">
                                <asp:Button ID="btnReset" runat="server" CssClass="btn btn-primary" Text="Reset" OnClick="btnReset_OnClick" />
                            </div>
                            &nbsp;
                            <div class="pull-right">
                                <asp:Button ID="btnFilter" runat="server" CssClass="btn btn-success"  Style="margin-right: 15px;" Text="Filter" OnClick="btnFilter_OnClick" />
                            </div>
                            &nbsp;

                            <div class="widget-icons pull-left">
                                <a href="#" class="wminimize">Filters</a> <%--<i class="fa fa-chevron-up"></i>--%>
                            </div>
                            <div class="clearfix"></div>
                        </div>
                        <div class="widget-content filterArea">
                            <div class="padd">
                                <!-- Form starts.  -->
                                <table>
                                    <tr>
                                        <td> <label class="control-label col-lg-12">Prisoner Name </label> </td>
                                        <td> <asp:TextBox ID="TextBox1" runat="server" ></asp:TextBox> </td>
                                        
                                        <td> <label class="control-label col-lg-12">Prisoner CNIC </label> </td>
                                        <td> <asp:TextBox ID="TextBox2" runat="server" ></asp:TextBox> </td>
                                        
                                        <td> <label class="control-label col-lg-12">Prisoner Passport </label> </td>
                                        <td> <asp:TextBox ID="TextBox3" runat="server" ></asp:TextBox> </td>
                                    
                                    </tr>

                                    <tr>
                                        <td> <label class="control-label col-lg-12">Prisoner Iqama </label> </td>
                                        <td> <asp:TextBox ID="TextBox4" runat="server" ></asp:TextBox> </td>
                                        
                                        <td> <label class="control-label col-lg-12">Prisoner Address </label> </td>
                                        <td> <asp:TextBox ID="TextBox5" runat="server" ></asp:TextBox> </td>
                                        
                                        <td> <label class="control-label col-lg-12">Case Types </label></td>
                                        <td> <asp:DropDownList ID="CaseTypes" CssClass="reportDropdown" runat="server"/> </td>
                                    </tr>
                                    
                                </table>
                            </div>
                            <br />
                        </div>

                        <div class="widget-head">

                            <rsweb:ReportViewer ID="PrisonerViewer" runat="server" Width="100%" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Height="800px"></rsweb:ReportViewer>

                        </div>
                    </div>

                </div>
            </div>
        </div>
    </div>


    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <script>
        //$(document).ready(function () {
        //    $("#dtStart").datepicker({
        //        changeMonth: true,
        //        changeYear: true,
        //        maxDate: new Date()
        //    });
        //});
    </script>
    <style>
        body {
            padding-top: 0px !important;
        }
    </style>
</asp:Content>
