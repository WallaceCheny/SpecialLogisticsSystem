<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DistrictLookUp.ascx.cs" Inherits="SpecialLogisticsSystem.AppPortal.UserControls.DistrictLookUp" %>
<cx:ASPxGridLookup id="district_customelookup" IsNew="false" runat="server" IncrementalFilteringMode="Contains"
    KeyFieldName="DistrictID" selectionmode="Single" gridviewstyles-cell-wrap="False" textformatstring="{0}-{1}-{2}">
    <Columns>
        <dx:GridViewDataColumn FieldName="ProvinceName" Caption="省份" Width="40px" />
        <dx:GridViewDataColumn FieldName="CityName" Caption="城市" Width="40px" />
	<dx:GridViewDataColumn FieldName="DistrictName" Caption="县/市" Width="60px"/>
    </Columns>
    <GridViewProperties>
        <Settings ShowStatusBar="Visible" ShowFilterRow="True" GridLines="Both" ShowVerticalScrollBar="true"
            VerticalScrollableHeight="150" />
        <SettingsBehavior AllowFocusedRow="True" AllowSelectSingleRowOnly="True"></SettingsBehavior>
    </GridViewProperties>
</cx:ASPxGridLookup>
