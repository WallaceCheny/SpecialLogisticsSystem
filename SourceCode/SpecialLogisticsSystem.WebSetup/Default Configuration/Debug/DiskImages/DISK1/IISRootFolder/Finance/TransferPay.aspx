<%@ Page Title="" Language="C#" MasterPageFile="~/MenuMaster.Master" AutoEventWireup="true" CodeBehind="TransferPay.aspx.cs" Inherits="SpecialLogisticsSystem.AppPortal.Finance.TransferPay" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript">
        gridConfig.gridID = 'gridFinanceService';
        var viewSetting1 = {

        };
        function filterCondition() {
            return { transfer_number: txt_way_number.GetValue(), receive_date_start: receive_date_start.GetValueString()
            , receive_date_end: receive_date_end.GetValueString(),settle_name:com_settle_statue.GetText() };
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SearchContent" runat="server">
    <ul id="viewSearch">
		<li class="caption">
		    中转号：
		</li>
		<li>
			<cx:ASPxTextBox ID="txt_way_number" runat="server" Width="100px">
            </cx:ASPxTextBox>
		</li>
		<li class="caption">
			接单日期：
		</li>
		 <li>
			 <dx:DateRange ID="date_range"  runat="server"></dx:DateRange>
		 </li>
		 <li  class="caption">
		    结算状态：
		</li>
		<li>
			<cx:ASPxComboBox ID="com_settle_statue" runat="server" Width="80px">
				<Items>
                    <dx:ListEditItem Text="未结算"  Value="0" Selected="true" />
                    <dx:ListEditItem Text="已结算" Value="1" />
                </Items>
            </cx:ASPxComboBox>
		</li>
	</ul>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
  <cx:ASPxGridView ID="gridFinanceService" runat="server" 
        DataSourceID="wayDataSource" DataSourceForceStandardPaging="true" OnRowUpdating="gridFinanceService_RowUpdating" 
        KeyFieldName="id" RowCheckBox="true" OnCustomCallback="gridFinanceService_CustomCallback" OnHtmlEditFormCreated="gridFinanceService_HtmlEditFormCreated">
        <Columns>
            <dx:GridViewDataTextColumn Width="40" Caption="序号" ToolTip="序号" CellStyle-HorizontalAlign="Center"
                Settings-AllowSort="False" FixedStyle="Left">
                <DataItemTemplate>
                    <%# Container.VisibleIndex + 1%></DataItemTemplate>
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="中转日期" FieldName="transfer_date" FixedStyle="Left"
                Width="80">
				<PropertiesTextEdit DisplayFormatString="yyyy/MM/dd" DisplayFormatInEditMode="True">
                </PropertiesTextEdit>
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="中转号" FieldName="transfer_number" FixedStyle="Left"
                Width="85">
            </dx:GridViewDataTextColumn>
			  <dx:gridviewdatacomboboxcolumn fieldname="transfer_statue" caption="状态" width="80">
                <PropertiesComboBox TextField="Description" ValueField="Name" EnableSynchronization="False"
                    DataSourceID="transferStatueDataSource">
                </PropertiesComboBox>
            </dx:gridviewdatacomboboxcolumn>
			<dx:GridViewDataTextColumn Caption="中转费" FieldName="transfer_bill" Width="80">
            </dx:GridViewDataTextColumn>
			<dx:GridViewDataTextColumn Caption="结算状态" FieldName="settle_name" Width="80">
            </dx:GridViewDataTextColumn>
			<dx:GridViewDataTextColumn Caption="结算方式" FieldName="settle_type_name"  Width="80">
            </dx:GridViewDataTextColumn>
			 <dx:gridviewdatatextcolumn caption="服务商" fieldname="service_name"  Width="80">
            </dx:gridviewdatatextcolumn>
            <dx:GridViewDataTextColumn Caption="备注" FieldName="transfer_memo">
            </dx:GridViewDataTextColumn>
        </Columns>
		<Templates>
			<EditForm>
				<dx:EditToolBar ID="EditToolBar2" runat="server"></dx:EditToolBar>
				<table cellpadding="4" cellspacing="0" class="editTable">
					<tr>
					   <td class="editFormCaption">
                            单据编号:<span class="red">*</span>:
                        </td>
                        <td class="editFormCell">
                            <dx:GeneralNumber ID="settle_number" runat="server" CodeEnum="Finance" Width="120"></dx:GeneralNumber>
                        </td>
						<td class="editFormCaption">
							中转号<span class="red">*</span>:
						</td>
						<td class="editFormCell">
							<cx:ASPxTextBox ID="transfer_number" runat="server" Width="120"  IsReadOnly="true">
							</cx:ASPxTextBox>
						</td>						
					</tr>
					<tr>
						<td class="editFormCaption">
							服务商<span class="red">*</span>:
						</td>
						<td class="editFormCell">
							<cx:ASPxTextBox ID="service_name" runat="server" Width="120"  IsReadOnly="true">
							</cx:ASPxTextBox>
						</td>	
						<td class="editFormCaption">
							中转金额:
						</td>
						<td class="editFormCell">
							<cx:ASPxTextBox ID="transfer_bill" runat="server" Width="120" IsPrice="true" IsReadOnly="true">
							</cx:ASPxTextBox>
						</td>
					</tr>
					<tr>
						<td class="editFormCaption">
							结算金额<span class="red">*</span>:
						</td>
						<td class="editFormCell">
							<cx:ASPxTextBox ID="settlement_payment" runat="server" Width="120" IsPrice="true" IsReadOnly="true">
							</cx:ASPxTextBox>
						</td>
						<td class="editFormCaption">
							结算方式:
						</td>
						<td class="editFormCell">
							 <dx:ComoboxCode ID="settlement_mode" runat="server" CodeType="finance_settle_type" Width="120"  Index="1"></dx:ComoboxCode>
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
							收款日期<span class="red">*</span>:
						</td>
						<td class="editFormCell">
							<cx:ASPxDateEdit ID="payment_date" runat="server" Width="120" DefaultToday="true">
							</cx:ASPxDateEdit>
						</td>
					</tr>
					<tr>
						<td class="editFormCaption">
							结算备注:
						</td>
						<td class="editFormCell" colspan="3">
							<cx:ASPxMemo ID="service_memo" runat="server" Height="100%" Width="100%">
							</cx:ASPxMemo>
						</td>
					</tr>
				</table>
			</EditForm>
		</Templates>
		<SettingsText PopupEditFormCaption="中转结算" />
        <Settings ShowVerticalScrollBar="true"/>
        <SettingsEditing Mode="PopupEditForm" PopupEditFormWidth="430" PopupEditFormHeight="250" />
        <Border BorderWidth="0" />
        <ClientSideEvents EndCallback="viewSetting.grid_EndCallback" />
    </cx:ASPxGridView>
	<asp:ObjectDataSource ID="wayDataSource" runat="server" TypeName="SpecialLogisticsSystem.AppPortal.UIHelpers.FinanceService"
        EnablePaging="True" MaximumRowsParameterName="maxRows" StartRowIndexParameterName="startRow"
        SortParameterName="sorter" SelectMethod="GetDataByPaging" SelectCountMethod="GetRowsCount"
        OnSelecting="wayDataSource_Selecting"></asp:ObjectDataSource>
	 <asp:ObjectDataSource ID="transferStatueDataSource" runat="server" TypeName="SpecialLogisticsSystem.AppPortal.UIHelpers.EnumProvider"
        SelectMethod="GetWayStatueData"></asp:ObjectDataSource>
</asp:Content>