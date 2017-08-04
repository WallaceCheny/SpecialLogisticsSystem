<%@ Page Title="" Language="C#" MasterPageFile="~/MultipleTab.Master" AutoEventWireup="true"
    CodeBehind="ArrivalMain.aspx.cs" Inherits="SpecialLogisticsSystem.AppPortal.Business.ArrivalMain" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript">
        menuList =
             {
                 "address":
                 [
                      { "title": "到货管理", "url": "Arrival.aspx" },
                      { "title": "送货管理", "url": "SendProduction.aspx" }
                 ]
             };
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="tabs" class="easyui-tabs" fit="true" border="false" style="overflow: hidden;">
        <div title="到货管理" style="overflow: hidden;">
        </div>
        <div title="送货管理" style="overflow: hidden;">
        </div>
    </div>
</asp:Content>
