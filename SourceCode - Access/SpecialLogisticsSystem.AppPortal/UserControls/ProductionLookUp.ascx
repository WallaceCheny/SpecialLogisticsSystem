<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProductionLookUp.ascx.cs" Inherits="SpecialLogisticsSystem.AppPortal.UserControls.ProductionLookUp" %>
<cx:ASPxGridLookup ID="product_customelookup" NewUrl="/Business/Way.aspx" runat="server" KeyFieldName="id" SelectionMode="Single"
    GridViewStyles-Cell-Wrap="False" TextFormatString="{1}">
    <Columns>
        <dx:GridViewDataColumn FieldName="way_number" Caption="运单号" Width="80px" />
        <dx:GridViewDataColumn FieldName="production_name" Caption="货物名称" Width="100px" />
	<dx:GridViewDataColumn FieldName="deliver_name" Caption="发货人" Width="80px" />
	<dx:GridViewDataColumn FieldName="consignee_name" Caption="收货人" Width="80px" />
	<dx:GridViewDataColumn FieldName="production_number" Caption="件数"  />
	<dx:GridViewDataColumn FieldName="production_size" Caption="体积"  Visible="false" />
	<dx:GridViewDataColumn FieldName="production_weight" Caption="重量"  Visible="false" />
    </Columns>
    <GridViewProperties>
        <Settings ShowStatusBar="Visible" GridLines="Both" ShowVerticalScrollBar="true"
            VerticalScrollableHeight="150" />
        <SettingsBehavior AllowFocusedRow="True" AllowSelectSingleRowOnly="True"></SettingsBehavior>
    </GridViewProperties>
</cx:ASPxGridLookup>
