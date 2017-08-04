<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="BillWay.aspx.cs" Inherits="SpecialLogisticsSystem.AppPortal.Reports.BillWay" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <dx:ReportViewerControl ID="ReportViewerControl1" runat="server" Report="<%#new SpecialLogisticsSystem.AppPortal.XtraReports.XtraReport1()%>"
        ReportName="SpecialLogisticsSystem.AppPortal.XtraReports.XtraReport1">
    </dx:ReportViewerControl>
</asp:Content>
