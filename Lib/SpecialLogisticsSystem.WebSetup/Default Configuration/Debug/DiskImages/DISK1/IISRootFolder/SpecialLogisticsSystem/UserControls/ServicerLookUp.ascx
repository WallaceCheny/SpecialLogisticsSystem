<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ServicerLookUp.ascx.cs" Inherits="SpecialLogisticsSystem.AppPortal.UserControls.ServicerLookUp" %>
<cx:ASPxGridLookup ID="service_customelookup" NewUrl="/Cm/Servicer.aspx" runat="server"
    KeyFieldName="id" SelectionMode="Single" GridViewStyles-Cell-Wrap="False" TextFormatString="{1}">
    <Columns>
        <dx:gridviewdatacolumn fieldname="id" visible="false" />
        <dx:gridviewdatacolumn fieldname="name" caption="服务商" width="100px" />
        <dx:gridviewdatacolumn fieldname="link_name" caption="联系人" width="50px" />
        <dx:gridviewdatacolumn fieldname="link_mobilephone" caption="联系电话" width="150px" />
	<dx:gridviewdatacolumn fieldname="link_address" caption="地址" width="150px" />
    </Columns>
    <GridViewProperties>
        <Settings ShowStatusBar="Visible" GridLines="Both" ShowVerticalScrollBar="true" VerticalScrollableHeight="150" />
        <SettingsBehavior AllowFocusedRow="True" AllowSelectSingleRowOnly="True"></SettingsBehavior>
    </GridViewProperties>
</cx:ASPxGridLookup>