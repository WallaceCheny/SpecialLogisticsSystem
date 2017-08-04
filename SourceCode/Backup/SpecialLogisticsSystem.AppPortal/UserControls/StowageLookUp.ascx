<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="StowageLookUp.ascx.cs"
    Inherits="SpecialLogisticsSystem.AppPortal.UserControls.StowageLookUp" %>
<cx:ASPxGridLookup ID="stowage_customelookup" NewUrl="/Business/Stowage.aspx" runat="server"
    DataSourceForceStandardPaging="true" KeyFieldName="id"
    SelectionMode="Single" GridViewStyles-Cell-Wrap="False" TextFormatString="{1}"
    MultiTextSeparator=",">
    <Columns>
        <dx:GridViewCommandColumn ShowSelectCheckbox="True" />
        <dx:GridViewDataColumn FieldName="id" Visible="false" />
        <dx:GridViewDataColumn FieldName="stowage_number" Caption="发车号" Width="100px" />
        <dx:GridViewDataColumn FieldName="departure_time" Caption="发车时间" Width="100px" />
        <dx:GridViewDataColumn FieldName="car_no" Caption="车牌" Width="50px" />
        <dx:GridViewDataColumn FieldName="link_name" Caption="司机" Width="100px" />
        <dx:GridViewDataColumn FieldName="main_memo" Caption="备注" Width="100px" />
    </Columns>
    <GridViewProperties>
        <Settings ShowStatusBar="Visible" ShowFilterRow="True" GridLines="Both" ShowVerticalScrollBar="true" VerticalScrollableHeight="150" />
    </GridViewProperties>
</cx:ASPxGridLookup>
<asp:ObjectDataSource ID="stowageDataSource" runat="server" TypeName="SpecialLogisticsSystem.AppPortal.UIHelpers.StowageProvider"
    EnablePaging="True" MaximumRowsParameterName="maxRows" StartRowIndexParameterName="startRow"
    SortParameterName="sorter" SelectMethod="GetDataByPaging" SelectCountMethod="GetRowsCount"
    OnSelecting="stowageDataSource_Selecting"></asp:ObjectDataSource>
