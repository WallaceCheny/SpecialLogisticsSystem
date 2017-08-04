<%@ Page Title="" Language="C#" MasterPageFile="~/MenuMaster.master" AutoEventWireup="true"
    CodeBehind="OtherPay.aspx.cs" Inherits="SpecialLogisticsSystem.AppPortal.Finance.OtherPay" %>
<%@ Register Src="/UserControls/WayLookUp.ascx" TagName="WayLookUp" TagPrefix="uc1" %>
<%@ Register Src="/UserControls/StowageLookUp.ascx" TagName="StowageLookUp" TagPrefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript">
        gridConfig.gridID = 'gridFinanceDaily';
		
		function filterCondition() {
              return { settle_number: txt_settle_number.GetValue(), input_date_begin: receive_date_start.lastSuccessText, input_date_begin: receive_date_end.lastSuccessText};
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SearchContent" runat="server">
   <ul id="viewSearch">
		<li  class="caption">
		    结算编号：
		</li>
		<li>
			<cx:ASPxTextBox ID="txt_settle_number" runat="server" Width="140px">
             </cx:ASPxTextBox>
		</li>
		<li  class="caption">
			结算日期：
		</li>
		 <li>
			 <ul>
			   <dx:DateRange ID="date_range"  runat="server"></dx:DateRange>
			</ul>
		 </li>
	</ul>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
     <cx:ASPxGridView ID="gridFinanceDaily" RowCheckBox="true" runat="server" OnRowDeleting="gridFinanceDaily_RowDeleting"
        OnRowInserting="gridFinanceDaily_RowInserting" OnHtmlEditFormCreated="gridFinanceDaily_HtmlEditFormCreated"
        OnRowUpdating="gridFinanceDaily_RowUpdating" KeyFieldName="id" DataSourceID="dailyDataSource" DataSourceForceStandardPaging="true">
        <Columns>
		    <dx:GridViewDataTextColumn Caption="id" FieldName="id"  Visible="false">
            </dx:GridViewDataTextColumn>
			<dx:GridViewDataTextColumn Caption="结算编号" FieldName="settle_number" >
            </dx:GridViewDataTextColumn>
			<dx:GridViewDataTextColumn Caption="科目" FieldName="category_type_name" >
            </dx:GridViewDataTextColumn>
			<dx:GridViewDataTextColumn Caption="收入" FieldName="input_money" >
            </dx:GridViewDataTextColumn>
			<dx:GridViewDataTextColumn Caption="支出" FieldName="output_money" >
            </dx:GridViewDataTextColumn>
			<dx:GridViewDataTextColumn Caption="结算方式" FieldName="settle_type_name" >
            </dx:GridViewDataTextColumn>
			<dx:GridViewDataTextColumn Caption="负责人" FieldName="emp_name" >
            </dx:GridViewDataTextColumn>
			<dx:GridViewDataTextColumn Caption="日期" FieldName="input_date" >
            </dx:GridViewDataTextColumn>
			<dx:GridViewDataTextColumn Caption="摘要" FieldName="remark" >
            </dx:GridViewDataTextColumn>
			<dx:GridViewDataTextColumn Caption="分支机构" FieldName="branch_name" >
            </dx:GridViewDataTextColumn>
        </Columns>
        <Templates>
            <EditForm>
                <dx:EditToolBar ID="EditToolBar1" runat="server"></dx:EditToolBar>
                <table cellpadding="4" cellspacing="0" class="editTable">
                    <tr>
                        <td class="editFormCaption">
                            单据编号:<span class="red">*</span>:
                        </td>
                        <td class="editFormCell">
                            <dx:GeneralNumber ID="settle_number" runat="server" CodeEnum="Finance" Width="120"></dx:GeneralNumber>
                        </td>
                        <td class="editFormCaption">
                            科目：
                        </td>
                        <td class="editFormCell">
                            <dx:ComoboxCode ID="category_type" codeType="finance_category" runat="server" Width="120" Index="0"></dx:ComoboxCode>
                        </td>
                    </tr>
                    <tr>
                        <td class="editFormCaption">
                            收入：
                        </td>
                        <td class="editFormCell">
                            <cx:ASPxTextBox ID="input_money" runat="server" Width="120" IsPrice="true">
							</cx:ASPxTextBox>
                        </td>
                        <td class="editFormCaption">
                            支出：
                        </td>
                        <td class="editFormCell">
                             <cx:ASPxTextBox ID="output_money" runat="server" Width="120" IsPrice="true">
							</cx:ASPxTextBox>
                        </td>
                    </tr>
					  <tr>
                        <td class="editFormCaption">
							托运单:
						</td>
						<td class="editFormCell">
							<uc1:WayLookUp ID="way_id" runat="server"></uc1:WayLookUp>
						</td>
                        <td class="editFormCaption">
                            发车单:
                        </td>
                        <td class="editFormCell">
                        	<uc2:StowageLookUp ID="stowage_id" runat="server"></uc2:StowageLookUp>
                        </td>
                    </tr>
					 </tr>
					  <tr>
                        <td class="editFormCaption">
							结算方式:
						</td>
						<td class="editFormCell">
							 <dx:ComoboxCode ID="settle_type" runat="server" CodeType="finance_settle_type" Width="120" Index="1"></dx:ComoboxCode>
						</td>
                        <td class="editFormCaption">
                            
                        </td>
                        <td class="editFormCell">
                          
                        </td>
                    </tr>
					<tr>
						<td class="editFormCaption">
							经办人<span class="red">*</span>:
						</td>
						<td class="editFormCell">
							<dx:EmployeeLookUp ID="operator_man" runat="server" Width="120" IsSetDefault="true">
							</dx:EmployeeLookUp>
						</td>
						<td class="editFormCaption">
							结算日期<span class="red">*</span>:
						</td>
						<td class="editFormCell">
							<cx:ASPxDateEdit ID="input_date" runat="server" Width="120" DefaultToday="true">
							</cx:ASPxDateEdit>
						</td>
					</tr>
					<tr>
						<td class="editFormCaption">
							摘要:
						</td>
						<td class="editFormCell" colspan="3">
							<cx:ASPxMemo ID="remark" runat="server" Height="100%" Width="100%">
							</cx:ASPxMemo>
						</td>
					</tr>
                </table>
            </EditForm>
        </Templates>
        <SettingsText PopupEditFormCaption="编辑日常结算" />
        <Border BorderWidth="0" />
        <ClientSideEvents EndCallback="viewSetting.grid_EndCallback" />
    </cx:ASPxGridView>
	 <asp:ObjectDataSource ID="dailyDataSource" runat="server" TypeName="SpecialLogisticsSystem.AppPortal.UIHelpers.FinanceOther"
        EnablePaging="True" MaximumRowsParameterName="maxRows" StartRowIndexParameterName="startRow"
        SortParameterName="sorter" SelectMethod="GetDataByPaging" SelectCountMethod="GetRowsCount"
        OnSelecting="dailyDataSource_Selecting"></asp:ObjectDataSource>
</asp:Content>
