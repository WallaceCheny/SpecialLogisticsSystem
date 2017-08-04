<%@ Page Title="" Language="C#" MasterPageFile="~/MenuMaster.Master" AutoEventWireup="true"
    CodeBehind="Employee.aspx.cs" Inherits="SpecialLogisticsSystem.AppPortal.Cm.Employee" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript">
        gridConfig.gridID = 'gridEmployee';
		function filterCondition() {
            return { emp_no: txt_emp_no.GetValue(), emp_name: txt_emp_name.GetValue(), remark: txt_remark.GetValue() };
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SearchContent" runat="server">
    <ul id="viewSearch">
		<li class="caption">
		     员工编号：
		</li>
		<li>
			  <cx:ASPxTextBox ID="txt_emp_no"  runat="server" Width="140px">
               </cx:ASPxTextBox>
		</li>
		<li class="caption">
			 姓名：
		</li>
		<li>
			   <cx:ASPxTextBox ID="txt_emp_name"  runat="server" Width="140px">
               </cx:ASPxTextBox>
		</li>
		<li class="caption">
			 备注：
		</li>
		<li>
			   <cx:ASPxTextBox ID="txt_remark"  runat="server" Width="140px">
               </cx:ASPxTextBox>
		</li>
	</ul>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <cx:ASPxGridView ID="gridEmployee" runat="server" OnRowDeleting="gridEmployee_RowDeleting" RowCheckBox="true"
        OnRowInserting="gridEmployee_RowInserting" OnHtmlEditFormCreated="gridEmployee_HtmlEditFormCreated"
        OnRowUpdating="gridEmployee_RowUpdating" KeyFieldName="id" OnAfterPerformCallback="gridEmployee_AfterPerformCallback">
        <Columns>
            <dx:GridViewDataTextColumn Caption="员工编号" FieldName="emp_no">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="姓名" FieldName="emp_name">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="性别" FieldName="sex_name">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="性别" FieldName="sex_ind" Visible="false">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="任职状态" FieldName="status_name">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="任职状态" FieldName="status" Visible="false">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="出生年月" FieldName="birthday">
                <PropertiesTextEdit DisplayFormatString="yyyy/MM/dd" DisplayFormatInEditMode="True">
                </PropertiesTextEdit>
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="手机" FieldName="mobilephone">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="备注" FieldName="remark">
            </dx:GridViewDataTextColumn>
        </Columns>
        <Templates>
            <EditForm>
                <dx:EditToolBar ID="EditToolBar1" runat="server"></dx:EditToolBar>
                <table cellpadding="4" cellspacing="0" class="editTable">
                    <tr>
                        <td class="editFormCaption">
                            员工编号：
                        </td>
                        <td class="editFormCell" colspan="3">
                            <dx:GeneralNumber ID="emp_no" runat="server" CodeEnum="Emp">
                            </dx:GeneralNumber>
                        </td>
                    </tr>
                    <tr>
                        <td class="editFormCaption">
                            姓名<span class="red">*</span>：
                        </td>
                        <td class="editFormCell">
                            <cx:ASPxTextBox ID="emp_name" runat="server" Width="170px" IsRequired="true">
                            </cx:ASPxTextBox>
                        </td>
                        <td class="editFormCaption">
                            生日：
                        </td>
                        <td class="editFormCell">
                            <cx:ASPxDateEdit ID="birthday" runat="server">
                            </cx:ASPxDateEdit>
                        </td>
                    </tr>
                    <tr>
                        <td class="editFormCaption">
                            性别：
                        </td>
                        <td class="editFormCell">
                            <dx:ComoboxCode ID="sex_ind" codeType="sex" runat="server" Index="0"></dx:ComoboxCode>
                        </td>
                        <td class="editFormCaption">
                            任职状态<span class="red">*</span>：
                        </td>
                        <td class="editFormCell">
                            <dx:ComoboxCode ID="status" codeType="office_statue" runat="server"  Index="1"></dx:ComoboxCode>
                        </td>
                    </tr>
                    <tr>
                        <td class="editFormCaption">
                            手机<span class="red">*</span>：
                        </td>
                        <td class="editFormCell">
                            <cx:ASPxTextBox ID="mobilephone" runat="server" Width="170px"  IsRequired="true">
                            </cx:ASPxTextBox>
                        </td>
                        <td class="editFormCaption">
                            电话
                        </td>
                        <td class="editFormCell">
                            <cx:ASPxTextBox ID="telphone" runat="server" Width="170px">
                            </cx:ASPxTextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="editFormCaption">
                            备注：
                        </td>
                        <td class="editFormCell" colspan="3">
                            <cx:ASPxTextBox ID="remark" runat="server" Width="425px">
                            </cx:ASPxTextBox>
                        </td>
                    </tr>
                </table>
            </EditForm>
        </Templates>
        <SettingsText PopupEditFormCaption="编辑员工信息" />
        <Border BorderWidth="0" />
		<ClientSideEvents EndCallback="viewSetting.grid_EndCallback" />
    </cx:ASPxGridView>
</asp:Content>
