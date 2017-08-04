<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="RoleLookUp.ascx.cs" Inherits="SpecialLogisticsSystem.AppPortal.UserControls.RoleLookUp" %>
<cx:ASPxGridLookup ID="role_customelookup" NewUrl="/Cm/RoleMenu.aspx" runat="server" KeyFieldName="id" SelectionMode="Single"
    GridViewStyles-Cell-Wrap="False" TextFormatString="{0}">
    <Columns>
        <dx:GridViewDataColumn FieldName="role_name" Caption="角色名称" Width="80px" />
        <dx:GridViewDataColumn FieldName="description" Caption="角色描述" Width="150px" />
    </Columns>
    <GridViewProperties>
        <Settings ShowStatusBar="Visible" GridLines="Both" ShowVerticalScrollBar="true"
            VerticalScrollableHeight="150" />
        <SettingsBehavior AllowFocusedRow="True" AllowSelectSingleRowOnly="True"></SettingsBehavior>
    </GridViewProperties>
</cx:ASPxGridLookup>
