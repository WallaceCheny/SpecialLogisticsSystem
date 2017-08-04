<%@ Page Title="" Language="C#" MasterPageFile="~/MultipleTab.Master" AutoEventWireup="true"
    CodeBehind="FinanceSummary.aspx.cs" Inherits="SpecialLogisticsSystem.AppPortal.Analyze.FinanceSummary" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript">
        menuList =
             {
                 "address":
                 [
                      { "title": "图表分析", "url": "FinanceGraphic.aspx" },
                      { "title": "列表明细", "url": "FinanceList.aspx" }
                 ]
             };
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="tabs" class="easyui-tabs" fit="true" border="false" style="overflow: hidden;">
        <div title="图表分析" style="overflow: hidden;">
        </div>
        <div title="列表明细" style="overflow: hidden;">
        </div>
    </div>
</asp:Content>
