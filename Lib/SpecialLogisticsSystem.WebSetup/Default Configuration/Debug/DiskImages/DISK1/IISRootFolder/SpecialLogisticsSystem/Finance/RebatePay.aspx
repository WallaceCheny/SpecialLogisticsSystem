<%@ Page Title="" Language="C#" MasterPageFile="~/MenuMaster.Master" AutoEventWireup="true" CodeBehind="RebatePay.aspx.cs" Inherits="SpecialLogisticsSystem.AppPortal.Finance.RebatePay" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript">
        gridConfig.gridID = 'gridWay';
        var viewSetting1 = {

        };
        function filterCondition() {
            return { way_number: txt_way_number.GetValue(), receive_date_start: receive_date_start.GetValueString()
            , receive_date_end: receive_date_end.GetValueString(),settle_name:com_settle_statue.GetText() };
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SearchContent" runat="server">
    <ul id="viewSearch">
		<li class="caption">
		    运单号：
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
		    发货人：
		</li>
		<li>
			<cx:ASPxTextBox ID="txt_sender" runat="server" Width="80px">
            </cx:ASPxTextBox>
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
  <cx:ASPxGridView ID="gridWay" runat="server" 
        DataSourceID="wayDataSource" DataSourceForceStandardPaging="true" OnRowUpdating="gridWay_RowUpdating" 
        KeyFieldName="id" RowCheckBox="true" OnCustomCallback="gridWay_CustomCallback" OnHtmlEditFormCreated="gridWay_HtmlEditFormCreated">
        <Columns>
            <dx:GridViewDataTextColumn Width="40" Caption="序号" ToolTip="序号" CellStyle-HorizontalAlign="Center"
                Settings-AllowSort="False" FixedStyle="Left">
                <DataItemTemplate>
                    <%# Container.VisibleIndex + 1%></DataItemTemplate>
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="way_id" FieldName="way_id" Visible="false">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="接单日期" FieldName="receive_date" FixedStyle="Left"
                Width="80">
				<PropertiesTextEdit DisplayFormatString="yyyy/MM/dd" DisplayFormatInEditMode="True">
                </PropertiesTextEdit>
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="运单号" FieldName="way_number" FixedStyle="Left"
                Width="85">
            </dx:GridViewDataTextColumn>
			<dx:GridViewDataComboBoxColumn FieldName="bill_statue" Caption="状态"  Width="60">
                <PropertiesComboBox TextField="Description" ValueField="Name" EnableSynchronization="False" DataSourceID="billStatueDataSource">
                </PropertiesComboBox>
            </dx:GridViewDataComboBoxColumn>
			<dx:GridViewDataTextColumn Caption="发货人" FieldName="deliver_name" Width="85">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="收货人" FieldName="consignee_name" Width="85">
            </dx:GridViewDataTextColumn>
			<dx:GridViewDataTextColumn Caption="结算状态" FieldName="settle_name" Width="70">
            </dx:GridViewDataTextColumn>
			<dx:GridViewDataTextColumn Caption="回扣" FieldName="bill_rebate" Width="65">
            </dx:GridViewDataTextColumn>
			<dx:GridViewDataTextColumn Caption="运费金额" FieldName="aggregate_amount" Width="80">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="现付" FieldName="spot_payment" Width="65">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="提付" FieldName="pick_payment" Width="65">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="回付" FieldName="back_payment">
            </dx:GridViewDataTextColumn>
			<dx:GridViewDataTextColumn Caption="结算方式" FieldName="settle_type_name">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="备注" FieldName="bill_memo">
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
							运单号<span class="red">*</span>:
						</td>
						<td class="editFormCell">
							<cx:ASPxTextBox ID="way_number" runat="server" Width="120"  IsReadOnly="true">
							</cx:ASPxTextBox>
						</td>						
					</tr>
					<tr>
						<td class="editFormCaption">
							回扣金额<span class="red">*</span>:
						</td>
						<td class="editFormCell">
							<cx:ASPxTextBox ID="bill_rebate" runat="server" Width="120" IsPrice="true" IsReadOnly="true">
							</cx:ASPxTextBox>
						</td>
						<td class="editFormCaption">
							结算金额<span class="red">*</span>:
						</td>
						<td class="editFormCell">
							<cx:ASPxTextBox ID="settle_money" runat="server" Width="120" IsPrice="true">
							</cx:ASPxTextBox>
						</td>
					</tr>
					<tr>
					   <td class="editFormCaption">
							结算方式:
						</td>
						<td class="editFormCell">
							 <dx:ComoboxCode ID="settle_type" runat="server" CodeType="finance_settle_type" Width="120"  Index="1"></dx:ComoboxCode>
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
							<cx:ASPxMemo ID="remark" runat="server" Height="100%" Width="100%">
							</cx:ASPxMemo>
						</td>
					</tr>
				</table>
			</EditForm>
		</Templates>
		<SettingsText PopupEditFormCaption="回扣发放" />
        <Settings ShowVerticalScrollBar="true"/>
        <SettingsEditing Mode="PopupEditForm" PopupEditFormWidth="430" PopupEditFormHeight="250" />
        <Border BorderWidth="0" />
        <ClientSideEvents EndCallback="viewSetting.grid_EndCallback" />
    </cx:ASPxGridView>
	<asp:ObjectDataSource ID="wayDataSource" runat="server" TypeName="SpecialLogisticsSystem.AppPortal.UIHelpers.FinanceDiscount"
        EnablePaging="True" MaximumRowsParameterName="maxRows" StartRowIndexParameterName="startRow"
        SortParameterName="sorter" SelectMethod="GetDataByPaging" SelectCountMethod="GetRowsCount"
        OnSelecting="wayDataSource_Selecting"></asp:ObjectDataSource>
	 <asp:ObjectDataSource ID="billStatueDataSource" runat="server" TypeName="SpecialLogisticsSystem.AppPortal.UIHelpers.EnumProvider"
        SelectMethod="GetWayStatueData"></asp:ObjectDataSource>
</asp:Content>
