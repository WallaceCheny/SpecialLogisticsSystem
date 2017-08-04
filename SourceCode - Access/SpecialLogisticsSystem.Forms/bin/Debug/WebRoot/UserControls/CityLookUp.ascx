<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CityLookUp.ascx.cs"
    Inherits="SpecialLogisticsSystem.AppPortal.UserControls.CityLookUp" %>
<cx:ASPxGridLookup ID="city_customelookup" IsNew="false" runat="server" IncrementalFilteringMode="Contains"
    KeyFieldName="Name" SelectionMode="Single" GridViewStyles-Cell-Wrap="False" TextFormatString="{0}">
    <Columns>
        <dx:GridViewDataColumn FieldName="Name" Caption="城市" Width="100%" />
    </Columns>
    <GridViewProperties>
        <Settings ShowStatusBar="Visible" ShowFilterRow="True" GridLines="Both" ShowVerticalScrollBar="true"
            VerticalScrollableHeight="150" />
        <SettingsBehavior AllowFocusedRow="True" AllowSelectSingleRowOnly="True"></SettingsBehavior>
    </GridViewProperties>
</cx:ASPxGridLookup>
