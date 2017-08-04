<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EmployeeLookUp.ascx.cs" Inherits="SpecialLogisticsSystem.AppPortal.UserControls.EmployeeLookUp" %>
<cx:ASPxGridLookup ID="employee_customelookup" NewUrl="/Cm/Employee.aspx" runat="server" KeyFieldName="id" SelectionMode="Single"
    GridViewStyles-Cell-Wrap="False" TextFormatString="{1}">
    <Columns>
        <dx:GridViewDataColumn FieldName="emp_no" Caption="员工编号" Width="80px" />
        <dx:GridViewDataColumn FieldName="emp_name" Caption="员工姓名" Width="80px" />
        <dx:GridViewDataColumn FieldName="branch_name" Caption="所属机构" Width="80px" />
	<dx:GridViewDataColumn FieldName="emp_type_cd" Caption="工种类型" Width="80px" />
    </Columns>
    <GridViewProperties>
        <Settings ShowStatusBar="Visible" GridLines="Both" ShowVerticalScrollBar="true"
            VerticalScrollableHeight="150" />
        <SettingsBehavior AllowFocusedRow="True" AllowSelectSingleRowOnly="True"></SettingsBehavior>
    </GridViewProperties>
</cx:ASPxGridLookup>
