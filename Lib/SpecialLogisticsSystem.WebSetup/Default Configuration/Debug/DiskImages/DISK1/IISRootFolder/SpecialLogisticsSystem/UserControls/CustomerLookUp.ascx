<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CustomerLookUp.ascx.cs"
    Inherits="SpecialLogisticsSystem.AppPortal.UserControls.CustomerLookUp" %>
<cx:ASPxGridLookup ID="customer_customelookup" NewUrl="/Cm/Customer.aspx" runat="server"
    KeyFieldName="id" SelectionMode="Single" GridViewStyles-Cell-Wrap="False" TextFormatString="{1}"
    ClientIDMode="Static" IncrementalFilteringMode="Contains">
    <Columns>
        <dx:GridViewDataColumn FieldName="customer_name" Caption="客户" Width="80px" />
        <dx:GridViewDataColumn FieldName="link_name" Caption="姓名" Width="80px" />
        <dx:GridViewDataColumn FieldName="link_mobilephone" Caption="电话" Width="100px" />
        <dx:GridViewDataColumn FieldName="link_area" Caption="地区" Width="150px" />
        <dx:GridViewDataColumn FieldName="link_address" Caption="地址" Width="80px" />
    </Columns>
    <GridViewProperties>
        <Settings ShowStatusBar="Visible" ShowFilterRow="True" GridLines="Both" ShowVerticalScrollBar="true"
            VerticalScrollableHeight="150" />
        <SettingsBehavior  AllowSelectSingleRowOnly="True" AllowFocusedRow="True"  EnableRowHotTrack="True"></SettingsBehavior>
    </GridViewProperties>
</cx:ASPxGridLookup>
<asp:HiddenField ID="hideText" runat="server" ClientIDMode="Static"/>

