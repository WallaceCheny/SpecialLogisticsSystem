<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CarLookUp.ascx.cs" Inherits="SpecialLogisticsSystem.AppPortal.UserControls.CarLookUp" %>
<cx:ASPxGridLookup ID="car_customelookup" NewUrl="/Cm/Car.aspx" runat="server" KeyFieldName="id"
    SelectionMode="Single" GridViewStyles-Cell-Wrap="False" TextFormatString="{2}"
    MultiTextSeparator=",">
    <Columns>
        <dx:GridViewCommandColumn ShowSelectCheckbox="True" />
        <dx:GridViewDataColumn FieldName="id" Visible="false" />
        <dx:GridViewDataColumn FieldName="link_id" Visible="false" />
        <dx:GridViewDataColumn FieldName="car_no" Caption="车牌号" Width="100px" />
        <dx:GridViewDataColumn FieldName="link_name" Caption="司机" Width="50px" />
        <dx:GridViewDataColumn FieldName="link_mobilephone" Caption="手机" Width="100px" />
        <dx:GridViewDataColumn FieldName="car_type_name" Caption="车辆类型" Width="70px" />
        <dx:GridViewDataColumn FieldName="car_memo" Caption="备注" Width="100px" />
    </Columns>
    <GridViewProperties>
        <Settings ShowStatusBar="Visible" GridLines="Both" ShowVerticalScrollBar="true" VerticalScrollableHeight="150" />
        <SettingsBehavior AllowFocusedRow="True" AllowSelectSingleRowOnly="True"></SettingsBehavior>
    </GridViewProperties>
</cx:ASPxGridLookup>
