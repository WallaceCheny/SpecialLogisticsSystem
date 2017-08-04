<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BranchLookUp.ascx.cs"
    Inherits="SpecialLogisticsSystem.AppPortal.UserControls.BranchLookUp" %>
<cx:ASPxGridLookup ID="branch_customelookup" NewUrl="/Cm/Branch.aspx" runat="server"
    KeyFieldName="id" SelectionMode="Single" GridViewStyles-Cell-Wrap="False" TextFormatString="{1}" MultiTextSeparator=",">
    <Columns>
        <dx:GridViewCommandColumn showselectcheckbox="True" />
        <dx:gridviewdatacolumn fieldname="id" visible="false" />
        <dx:gridviewdatacolumn fieldname="name" caption="机构名称" width="100px" />
        <dx:gridviewdatacolumn fieldname="link_name" caption="联系人" width="50px" />
	<dx:gridviewdatacolumn fieldname="link_mobilephone" caption="联系电话" width="85px" />
        <dx:gridviewdatacolumn fieldname="link_area" caption="所在地区" width="150px" />
        <dx:gridviewdatacolumn fieldname="link_address" caption="地址" width="100px" />
    </Columns>
    <GridViewProperties>
        <Settings ShowStatusBar="Visible" GridLines="Both" ShowVerticalScrollBar="true" VerticalScrollableHeight="150" />
        <SettingsBehavior AllowFocusedRow="True" AllowSelectSingleRowOnly="True"></SettingsBehavior>
    </GridViewProperties>
</cx:ASPxGridLookup>
