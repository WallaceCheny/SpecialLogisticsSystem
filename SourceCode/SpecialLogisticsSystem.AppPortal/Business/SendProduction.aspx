<%@ Page Title="" Language="C#" MasterPageFile="~/MenuMaster.master" AutoEventWireup="true" CodeBehind="SendProduction.aspx.cs" Inherits="SpecialLogisticsSystem.AppPortal.Business.SendProduction" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript">
        gridConfig.gridID = 'gridDeliver';
        gridConfig.gridSubID = 'gridDeliverDetail';
		gridConfig.gridSubHeight =230;
		gridConfig.popupID='pop_PrintConstruct';
		gridConfig.popuSelectedTypeName="Deliver";
		   //关联运单
        var viewSetting1 = {
            glp_ValueChanged: function (s, e) {
                var grid = s.GetGridView();
                grid.cp_cust_id = '';
                var index = grid.GetFocusedRowIndex();
                if (index != -1)
                    viewSetting1.glp_bind(grid,index);

            },
            glp_bind: function (grid,index) {
                 grid.GetRowValues(index, 'production_number;', function OnGetRowValues(values) {
                        production_number.SetText(values[0]);
                });
            },
			grid_EndCallback: function (s, e) {
			
			},
			textChange: function (s,e) {
				gridDeliverDetail.PerformCallback('Update');
			}
        };
		function filterCondition() {
              return { way_number: txt_way_number.GetValue(), receive_date_start: receive_date_start.GetValue(), receive_date_end: receive_date_end.GetValue()};
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SearchContent" runat="server">
   <ul id="viewSearch">
		<li  class="caption">
		    发车号：
		</li>
		<li>
			<cx:ASPxTextBox ID="txt_way_number" runat="server" Width="140px">
             </cx:ASPxTextBox>
		</li>
		<li  class="caption">
			发车日期：
		</li>
		<li>
			 <dx:DateRange ID="date_range"  runat="server"></dx:DateRange>
		 </li>
	</ul>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <cx:ASPxGridView ID="gridDeliver" runat="server" OnRowDeleting="gridDeliver_RowDeleting" OnInitNewRow="gridDeliver_InitNewRow"
        OnRowInserting="gridDeliver_RowInserting" OnHtmlEditFormCreated="gridDeliver_HtmlEditFormCreated"
        EnableRowsCache="true" DataSourceID="DeliverDataSource" DataSourceForceStandardPaging="true"
        OnRowUpdating="gridDeliver_RowUpdating" KeyFieldName="id" RowCheckBox="true">
        <Columns>
            <dx:GridViewDataTextColumn Width="40" Caption="序号" ToolTip="序号" CellStyle-HorizontalAlign="Center"
                Settings-AllowSort="False" FixedStyle="Left">
                <DataItemTemplate>
                    <%# Container.VisibleIndex + 1%></DataItemTemplate>
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="id" FieldName="id"  Visible="false">
            </dx:GridViewDataTextColumn>
		    <dx:GridViewDataTextColumn Caption="送货单号" FieldName="deliver_number" >
            </dx:GridViewDataTextColumn>
			<dx:GridViewDataComboBoxColumn FieldName="deliver_statue" Caption="状态"  Width="80">
                <PropertiesComboBox TextField="Description" ValueField="Name" EnableSynchronization="False" DataSourceID="DeliverStatueDataSource">
                </PropertiesComboBox>
            </dx:GridViewDataComboBoxColumn>
			<dx:GridViewDataTextColumn Caption="条码" FieldName="deliver_barcode" >
            </dx:GridViewDataTextColumn>
			<dx:GridViewDataTextColumn Caption="送货网点" FieldName="branch_name" >
            </dx:GridViewDataTextColumn>
			<dx:GridViewDataTextColumn Caption="送货日期" FieldName="deliver_date" >
            </dx:GridViewDataTextColumn>
			<dx:GridViewDataTextColumn Caption="车牌号" FieldName="car_no" >
            </dx:GridViewDataTextColumn>
			<dx:GridViewDataTextColumn Caption="送货员" FieldName="deliver_man" >
            </dx:GridViewDataTextColumn>
			<dx:GridViewDataTextColumn Caption="仓管员" FieldName="warehose_man_name" >
            </dx:GridViewDataTextColumn>
        </Columns> 
		<SettingsDetail ShowDetailRow="true" />
        <Templates>
		      <DetailRow>
                <dx:ASPxGridView ID="gridDeliverDetail" runat="server" ClientInstanceName="gridDeliverDetail"
                    AutoGenerateColumns="False" Width="100%" KeyFieldName="id" OnLoad="gridDeliverDetail_Load">
                    <Columns>
							<dx:GridViewDataTextColumn Caption="运单号" FieldName="way_number"  Width="80">
							</dx:GridViewDataTextColumn>
							<dx:GridViewDataTextColumn Caption="到站" FieldName="end_city"  Width="80">
							</dx:GridViewDataTextColumn>
							<dx:GridViewDataTextColumn Caption="发货方" FieldName="deliver_name"  Width="80">
							</dx:GridViewDataTextColumn>
							<dx:GridViewDataTextColumn Caption="收货方" FieldName="consignee_name"  Width="80">
							</dx:GridViewDataTextColumn>
							<dx:GridViewDataTextColumn Caption="货物名称" FieldName="production_name"  Width="80">
							</dx:GridViewDataTextColumn>
							<dx:GridViewDataTextColumn Caption="重量" FieldName="production_weight"  Width="80">
							</dx:GridViewDataTextColumn>
							<dx:GridViewDataTextColumn Caption="体积" FieldName="production_size"  Width="80">
							</dx:GridViewDataTextColumn>
							<dx:GridViewDataTextColumn Caption="件数" FieldName="production_number"  Width="80">
							</dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="送货费" FieldName="send_bill" >
							</dx:GridViewDataTextColumn>
                    </Columns>
                    <Settings GridLines="Both" ShowVerticalScrollBar="false" ShowFooter="true" />
                    <SettingsBehavior AllowSelectByRowClick="true" AllowFocusedRow="false" ConfirmDelete="true"
                        AllowSort="false" />
                    <SettingsText EmptyDataRow="无数据" />
                    <SettingsPager Mode="ShowAllRecords" />
                    <Border BorderWidth="0" />
                </dx:ASPxGridView>
            </DetailRow>
            <EditForm>
                <dx:EditToolBar ID="EditToolBar1" runat="server"></dx:EditToolBar>
                <table cellpadding="4" cellspacing="0" class="editTable1">
                    <tr>
                        <td class="editFormCaption">
                            送货单号<span class="red">*</span>:
                        </td>
                        <td class="editFormCell">
                            <dx:GeneralNumber ID="deliver_number" runat="server" CodeEnum="Deliver" Width="100">
                            </dx:GeneralNumber>
                        </td>
						 <td class="editFormTh" colspan="2">
                            送货单
                        </td>
                        <td class="editFormCaption">
                            送货时间<span class="red">*</span>:
                        </td>
                        <td class="editFormCell">
                            <cx:ASPxDateEdit ID="deliver_date" DefaultToday="true" runat="server" Width="170"
                                IsRequired="true">
                            </cx:ASPxDateEdit>
                        </td>
                    </tr>
                    <tr>
					   <td class="editFormCaption">
                            送货网点<span class="red">*</span>:
                        </td>
                        <td class="editFormCell">
                            <dx:BranchLookUp ID="branch_id" runat="server" Index="1" IsRequrided="true"></dx:BranchLookUp>
                        </td>
                        <td class="editFormCaption">
                            车牌号<span class="red">*</span>:
                        </td>
                        <td class="editFormCell">
						    <dx:CarLookUp ID="deliver_carno" runat="server" Index="1" IsRequrided="true">
                            </dx:CarLookUp>
                        </td>
                        <td class="editFormCaption">
                            送货员:
                        </td>
                        <td class="editFormCell">
						    <cx:ASPxTextBox ID="deliver_man" runat="server" Width="170">
                            </cx:ASPxTextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="editFormCaption">
                            仓管员<span class="red">*</span>:
                        </td>
                        <td class="editFormCell">
                            <dx:EmployeeLookUp ID="warehousem_man" runat="server" Index="1" IsRequrided="true"></dx:EmployeeLookUp>
                        </td>
					    <td class="editFormCaption">
                            条码扫描:
                        </td>
                        <td class="editFormCell">
                           <cx:ASPxTextBox ID="deliver_barcode" runat="server" Width="170">
                            </cx:ASPxTextBox>
                        </td>
						<td class="editFormCaption">
                            
                        </td>
                        <td class="editFormCell">
						
                        </td>
                    </tr>
                </table>
                <div>
                    <dx:MainToolBar ID="MainToolBar1" runat="server" PageToolBar="SelectedMenu"></dx:MainToolBar>
                    <cx:ASPxGridView ID="gridDeliverDetail" runat="server" ClientInstanceName="gridDeliverDetail" KeyFieldName="id"
                        OnCustomCallback="gridDeliverDetail_CustomCallback"
						OnHtmlRowCreated="gridDeliverDetail_HtmlRowCreated" DataSourceID="deliverDetailDataSource">
                        <Columns>
						   <dx:GridViewCommandColumn VisibleIndex="0" ButtonType="Image" Caption="操作" HeaderStyle-HorizontalAlign="Center"  width="50">
                                <DeleteButton Visible="True" Text="删除">
									<Image Height="16px" ToolTip="删除" Url="~/Images/commad/delete_16x.ico" Width="16px">
									</Image>
								</DeleteButton>
                            </dx:GridViewCommandColumn>
                            <dx:GridViewDataTextColumn Caption="id" FieldName="id" Visible="false">
                            </dx:GridViewDataTextColumn>
							<dx:GridViewDataComboBoxColumn FieldName="production_id" Caption="运单号"  Width="80">
								<PropertiesComboBox TextField="way_number" ValueField="id" EnableSynchronization="False" DataSourceID="productionDataSource">
								</PropertiesComboBox>
							</dx:GridViewDataComboBoxColumn>
							<dx:GridViewDataComboBoxColumn FieldName="production_id" Caption="货物名称"  Width="80">
								<PropertiesComboBox TextField="production_name" ValueField="id" EnableSynchronization="False" DataSourceID="productionDataSource">
								</PropertiesComboBox>
							</dx:GridViewDataComboBoxColumn>
							<dx:GridViewDataComboBoxColumn FieldName="production_id" Caption="到站"  Width="80">
								<PropertiesComboBox TextField="end_city" ValueField="id" EnableSynchronization="False" DataSourceID="productionDataSource">
								</PropertiesComboBox>
							</dx:GridViewDataComboBoxColumn>
							<dx:GridViewDataComboBoxColumn FieldName="production_id" Caption="发货方"  Width="80">
								<PropertiesComboBox TextField="deliver_name" ValueField="id" EnableSynchronization="False" DataSourceID="productionDataSource">
								</PropertiesComboBox>
							</dx:GridViewDataComboBoxColumn>
							<dx:GridViewDataComboBoxColumn FieldName="production_id" Caption="收货方"  Width="80">
								<PropertiesComboBox TextField="consignee_name" ValueField="id" EnableSynchronization="False" DataSourceID="productionDataSource">
								</PropertiesComboBox>
							</dx:GridViewDataComboBoxColumn>
							<dx:GridViewDataComboBoxColumn FieldName="production_id" Caption="重量"  Width="80">
								<PropertiesComboBox TextField="production_weight" ValueField="id" EnableSynchronization="False" DataSourceID="productionDataSource">
								</PropertiesComboBox>
							</dx:GridViewDataComboBoxColumn>
							<dx:GridViewDataComboBoxColumn FieldName="production_id" Caption="体积"  Width="80">
								<PropertiesComboBox TextField="production_size" ValueField="id" EnableSynchronization="False" DataSourceID="productionDataSource">
								</PropertiesComboBox>
							</dx:GridViewDataComboBoxColumn>
                            <dx:GridViewDataTextColumn Caption="送货费" FieldName="send_bill">
							     <DataItemTemplate>
                                      <cx:ASPxTextBox  ID="txtSendBill" IsPrice="true" runat="server" Width="100" TextChangedJS="viewSetting1.textChange"/>
                                      </cx:ASPxTextBox>
                                  </DataItemTemplate>
                            </dx:GridViewDataTextColumn>
                        </Columns>
                        <Templates>
                            <EditForm>
                                <dx:EditToolBar ID="EditToolBar2" runat="server"  MenuTye="SubMenu"></dx:EditToolBar>
                                <table cellpadding="4" cellspacing="0" class="editTable">
                                    <tr>
                                        <td class="editFormCaption">
                                            货物名称<span class="red">*</span>:
                                        </td>
                                        <td class="editFormCell">
                                           <dx:ProductionLookUp ID="production_id" runat="server" Index="1" IsRequrided="true" WayType="Special" ClientSideJs="viewSetting1.glp_ValueChanged"></dx:ProductionLookUp>
										 <td class="editFormCaption">
                                            送货费<span class="red">*</span>:
                                        </td>
                                        <td class="editFormCell">
                                            <cx:ASPxTextBox ID="send_bill" runat="server" IsPrice="true" Width="80"
                                                IsSubRequired="true">
                                            </cx:ASPxTextBox>
                                        </td>
                                        <%--<td  class="editFormCaption">
                                            体积(m&sup3;):
                                        </td>
                                        <td class="editFormCell">
                                            <cx:ASPxSpinEdit ID="production_size" runat="server" Width="80">
                                            </cx:ASPxSpinEdit>
                                        </td>
                                       
                                        <td class="editFormCaption">
                                            体重(Kg):
                                        </td>
                                        <td class="editFormCell">
                                            <cx:ASPxSpinEdit ID="production_weight" runat="server" Width="80">
                                            </cx:ASPxSpinEdit>
                                        </td>--%>
                                    </tr>
                                </table>
                            </EditForm>
                        </Templates>
                        <SettingsBehavior AllowSelectByRowClick="true" AllowFocusedRow="true" ConfirmDelete="true"
                            AllowSort="false" />
                        <SettingsText PopupEditFormCaption="编辑货物信息" />
						 <Border BorderWidth="0" />
						 <ClientSideEvents EndCallback="viewSetting.gridSub_EndCallback" Init="viewSetting.gridSub_EndCallback" />
						 <SettingsText Title="系统提示" EmptyDataRow="无数据" PopupEditFormCaption="编辑" ConfirmDelete="确定删除本行记录吗 ？" />
                    </cx:ASPxGridView>
                </div>
            </EditForm>
        </Templates>
        <SettingsText PopupEditFormCaption="编辑送货信息" />
        <SettingsEditing Mode="PopupEditForm" PopupEditFormWidth="750" PopupEditFormHeight="400"
             />
        <Border BorderWidth="0" />
        <ClientSideEvents EndCallback="viewSetting.grid_EndCallback" />
    </cx:ASPxGridView>
	<asp:ObjectDataSource ID="deliverDetailDataSource" runat="server" SelectMethod="GetList"      TypeName="SpecialLogisticsSystem.AppPortal.UIHelpers.DeliverDetailTemporary" UpdateMethod="Update" InsertMethod="Insert" DeleteMethod="Delete" ></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="DeliverDataSource" runat="server" TypeName="SpecialLogisticsSystem.AppPortal.UIHelpers.DeliverProvider"
        EnablePaging="True" MaximumRowsParameterName="maxRows" StartRowIndexParameterName="startRow"
        SortParameterName="sorter" SelectMethod="GetDataByPaging" SelectCountMethod="GetRowsCount"
        OnSelecting="DeliverDataSource_Selecting"></asp:ObjectDataSource>
	<asp:ObjectDataSource ID="productionDataSource" runat="server" TypeName="SpecialLogisticsSystem.AppPortal.UIHelpers.ProductionProvider"
        SelectMethod="GetProduction"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="DeliverStatueDataSource" runat="server" TypeName="SpecialLogisticsSystem.AppPortal.UIHelpers.EnumProvider"
        SelectMethod="GetWayStatueData"></asp:ObjectDataSource>
	<dx:ProductionList ID="productionList" runat="server" ClosingJs="function(s,e){gridDeliverDetail.Refresh();}" Statue="Arrival" WayType="0"></dx:ProductionList>
    <dx:ASPxPopupControl ID="pop_PrintConstruct" ClientInstanceName="pop_PrintConstruct"
        runat="server" CloseAction="CloseButton" HeaderText=" " AllowDragging="true"
        EnableAnimation="false" Modal="true" EnableViewState="false" Width="260px" PopupHorizontalAlign="WindowCenter"
        PopupVerticalAlign="WindowCenter" PopupVerticalOffset="-75" PopupHorizontalOffset="-85">
        <ContentCollection>
            <dx:PopupControlContentControl>
                <table cellpadding="5" cellspacing="5" style="padding: 30px;">
                    <tr>
                        <td>
                            <a id="btn_print_construct_pin" href="javascript:void(0);" target="_blank" class="easyui-linkbutton"
                                plain="false">针式打印</a>
                        </td>
                        <td>
                            <a id="btn_print_construct_a4" href="javascript:void(0);" class="easyui-linkbutton"
                                plain="false">A4格式</a>
                        </td>
                    </tr>
                </table>
            </dx:PopupControlContentControl>
        </ContentCollection>
        <ContentStyle Paddings-Padding="0" />
    </dx:ASPxPopupControl>
</asp:Content>

