<%@ Page Title="" Language="C#" MasterPageFile="~/MenuMaster.Master" AutoEventWireup="true" CodeBehind="DriverPay.aspx.cs" Inherits="SpecialLogisticsSystem.AppPortal.Finance.DriverPay" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript">
        gridConfig.gridID = 'gridFinanceDeliver';
		//关联运单
        var viewSetting1 = {
           glp_ValueChanged: function (s, e) {
                var grid =  window[gridConfig.gridID];
                var index = grid.GetFocusedRowIndex();
                if (index != -1)
                    viewSetting1.glp_bind(grid,index);

            },
            glp_bind: function (grid,index) {
                 grid.GetRowValues(index, 'prepay;arrive_payment;back_payment', function OnGetRowValues(values) {
				       var settle_type_name= cmbSystem.GetValue();
					   switch (settle_type_name) {
							case 'PrePay':
								settle_money.SetText(String(values[0]));
								break;
							case 'ArrivalPay':
							    settle_money.SetText(String(values[1]));
								break;
						    case 'BackPay':
							    settle_money.SetText(String(values[2]));
								break;
						}
                       
                });
            },
        };
		function filterCondition() {
              return { stowage_number: txt_stowage_number.GetValue(), departure_time_begin: receive_date_start.lastSuccessText, departure_time_end: receive_date_end.lastSuccessText};
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SearchContent" runat="server">
   <ul id="viewSearch">
		<li  class="caption">
		    发车号：
		</li>
		<li>
			<cx:ASPxTextBox ID="txt_stowage_number" runat="server" Width="140px">
             </cx:ASPxTextBox>
		</li>
		<li  class="caption">
			发车日期：
		</li>
		 <li>
			 <ul>
			   <dx:DateRange ID="date_range"  runat="server"></dx:DateRange>
			</ul>
		 </li>
	</ul>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <cx:ASPxGridView ID="gridFinanceDeliver" runat="server" OnRowUpdating="gridFinanceDeliver_RowUpdating" 
        EnableRowsCache="true" DataSourceID="deliverDataSource" DataSourceForceStandardPaging="true" OnHtmlEditFormCreated="gridFinanceDeliver_HtmlEditFormCreated"
         KeyFieldName="id" RowRadio="true">
        <Columns>
            <dx:GridViewDataTextColumn Width="40" Caption="序号" ToolTip="序号" CellStyle-HorizontalAlign="Center"
                Settings-AllowSort="False" FixedStyle="Left">
                <DataItemTemplate>
                    <%# Container.VisibleIndex + 1%></DataItemTemplate>
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="id" FieldName="id"  Visible="false">
            </dx:GridViewDataTextColumn>
			<dx:GridViewDataTextColumn Caption="车次编号" FieldName="stowage_number" Width="80">
            </dx:GridViewDataTextColumn>
			<dx:GridViewDataComboBoxColumn FieldName="stowage_statue" Caption="状态"  Width="60">
                <PropertiesComboBox TextField="Description" ValueField="Name" EnableSynchronization="False" DataSourceID="stowageStatueDataSource">
                </PropertiesComboBox>
            </dx:GridViewDataComboBoxColumn>
			<dx:GridViewDataTextColumn Caption="发车时间" FieldName="departure_time" Width="80">
			    <PropertiesTextEdit DisplayFormatString="yyyy/MM/dd" DisplayFormatInEditMode="True">
                </PropertiesTextEdit>
            </dx:GridViewDataTextColumn>
			<dx:GridViewDataTextColumn Caption="车牌" FieldName="car_no" Width="80">
            </dx:GridViewDataTextColumn>
			<dx:GridViewDataTextColumn Caption="司机" FieldName="link_name" Width="50">
            </dx:GridViewDataTextColumn>
			<dx:GridViewDataTextColumn Caption="随车电话" FieldName="link_mobilephone" Width="90">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="预付" FieldName="prepay">
            </dx:GridViewDataTextColumn>
			<dx:GridViewDataTextColumn Caption="预付结算" FieldName="pre_settle_name">
            </dx:GridViewDataTextColumn>
			<dx:GridViewDataTextColumn Caption="到付" FieldName="arrive_payment">
            </dx:GridViewDataTextColumn>
			<dx:GridViewDataTextColumn Caption="到付结算" FieldName="arrive_settle_name">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="回付" FieldName="back_payment">
            </dx:GridViewDataTextColumn>
			<dx:GridViewDataTextColumn Caption="回付结算" FieldName="back_settle_name">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="配载人员" FieldName="emp_name">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="起运站" FieldName="start_branch_name" Width="80">
            </dx:GridViewDataTextColumn>
			<dx:GridViewDataTextColumn Caption="目的站" FieldName="end_branch_name" Width="80">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="备注" FieldName="main_memo">
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
							结算类型<span class="red">*</span>:
						</td>
						<td class="editFormCell">
							<dx:ComboxSystem ID="settle_type" runat="server" Width="120" codeType="StowageSettleType" ClientSideJs="viewSetting1.glp_ValueChanged">
							</dx:ComboxSystem>
						</td>						
					</tr>
					<tr>
					    <td class="editFormCaption">
							车次号<span class="red">*</span>:
						</td>
						<td class="editFormCell">
							<cx:ASPxTextBox ID="stowage_number" runat="server" Width="120"  IsReadOnly="true">
							</cx:ASPxTextBox>
						</td>	
						<td class="editFormCaption">
							司机:
						</td>
						<td class="editFormCell">
						    <cx:ASPxTextBox ID="link_name" runat="server" Width="120"  IsReadOnly="true">
							</cx:ASPxTextBox>
						</td>
					</tr>
					<tr>
						<td class="editFormCaption">
							结算金额<span class="red">*</span>:
						</td>
						<td class="editFormCell">
							<cx:ASPxTextBox ID="settle_money" runat="server" Width="120" IsPrice="true" IsReadOnly="true">
							</cx:ASPxTextBox>
						</td>
						<td class="editFormCaption">
							结算方式:
						</td>
						<td class="editFormCell">
							 <dx:ComoboxCode ID="settle_mode" runat="server" CodeType="finance_settle_type" Width="120"></dx:ComoboxCode>
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
							结算备注:
						</td>
						<td class="editFormCell" colspan="3">
							<cx:ASPxMemo ID="driver_memo" runat="server" Height="100%" Width="100%">
							</cx:ASPxMemo>
						</td>
					</tr>
				</table>
            </EditForm>
        </Templates>
        <SettingsText PopupEditFormCaption="司机结算" />
         <SettingsEditing Mode="PopupEditForm" PopupEditFormWidth="430" PopupEditFormHeight="250"
            />
        <Border BorderWidth="0" />
		 <ClientSideEvents EndCallback="viewSetting.grid_EndCallback" />
    </cx:ASPxGridView>

    <asp:ObjectDataSource ID="deliverDataSource" runat="server" TypeName="SpecialLogisticsSystem.AppPortal.UIHelpers.FinanceDeliver"
        EnablePaging="True" MaximumRowsParameterName="maxRows" StartRowIndexParameterName="startRow"
        SortParameterName="sorter" SelectMethod="GetDataByPaging" SelectCountMethod="GetRowsCount"
        OnSelecting="deliverDataSourceDataSource_Selecting"></asp:ObjectDataSource>

    <asp:ObjectDataSource ID="stowageStatueDataSource" runat="server" TypeName="SpecialLogisticsSystem.AppPortal.UIHelpers.EnumProvider"
        SelectMethod="GetStowageStatueData"></asp:ObjectDataSource>
    <dx:ProductionList ID="productionList" runat="server" ClosingJs="function(s,e){gridFinanceDeliverDetail.Refresh();}" Statue="New,Storage" WayType="0"></dx:ProductionList>
</asp:Content>
