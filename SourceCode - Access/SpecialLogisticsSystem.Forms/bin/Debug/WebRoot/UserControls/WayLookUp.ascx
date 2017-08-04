<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WayLookUp.ascx.cs" Inherits="SpecialLogisticsSystem.AppPortal.UserControls.WayLookUp" %>

<cx:ASPxGridLookup ID="way_customelookup" NewUrl="/Business/Way.aspx" runat="server" IncrementalFilteringMode="Contains"
    DataSourceForceStandardPaging="true" KeyFieldName="id"
    SelectionMode="Single" GridViewStyles-Cell-Wrap="False" TextFormatString="{1}"
    MultiTextSeparator=",">
    <Columns>
        <dx:GridViewCommandColumn ShowSelectCheckbox="True" />
        <dx:GridViewDataColumn FieldName="id" Visible="false" />
        <dx:GridViewDataColumn FieldName="way_number" Caption="运单号" Width="100px" />
        <dx:GridViewDataColumn FieldName="receive_date" Caption="接单日期" Width="100px" />
        <dx:GridViewDataColumn FieldName="deliver_name" Caption="发货人" Width="50px" />
        <dx:GridViewDataColumn FieldName="consignee_name" Caption="收货人" Width="100px" />
        <dx:GridViewDataColumn FieldName="bill_memo" Caption="备注" Width="100px" />
    </Columns>
    <GridViewProperties>
        <Settings ShowStatusBar="Visible" ShowFilterRow="True" GridLines="Both" ShowVerticalScrollBar="true" VerticalScrollableHeight="150" />
        <SettingsBehavior AllowFocusedRow="True" AllowSelectSingleRowOnly="True"></SettingsBehavior>
    </GridViewProperties>
</cx:ASPxGridLookup>
<asp:ObjectDataSource ID="wayDataSource" runat="server" TypeName="SpecialLogisticsSystem.AppPortal.UIHelpers.WayProvider"
    EnablePaging="True" MaximumRowsParameterName="maxRows" StartRowIndexParameterName="startRow"
    SortParameterName="sorter" SelectMethod="GetDataByPaging" SelectCountMethod="GetRowsCount"
    OnSelecting="wayDataSource_Selecting"></asp:ObjectDataSource>
