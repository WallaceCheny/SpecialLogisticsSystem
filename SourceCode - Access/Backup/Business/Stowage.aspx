<%@ Page Title="" Language="C#" MasterPageFile="~/MenuMaster.Master" AutoEventWireup="true"
    CodeBehind="Stowage.aspx.cs" Inherits="SpecialLogisticsSystem.AppPortal.Business.Stowage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript">
        gridConfig.gridID = 'gridStowage';
        gridConfig.gridSubID = 'gridStowageDetail';
		gridConfig.gridSubHeight =160;
		gridConfig.popupID='pop_PrintConstruct';
		//关联运单
        var viewSetting1 = {
            glpBranch_ValueChanged: function (s, e) {
                var grid = s.GetGridView();
                grid.cp_cust_id = '';
                var index = grid.GetFocusedRowIndex();
                if (index != -1)
                    viewSetting1.glp_bind(grid,index);
            },
            glp_bind: function (grid,index) {
                 grid.GetRowValues(index, 'link_name;link_mobilephone', function OnGetRowValues(values) {
                        end_branch_linkname.SetText(values[0]);
						end_branch_linktelephone.SetText(values[1]);
                });
            },
			glpCar_ValueChanged: function (s, e) {
                var grid = s.GetGridView();
                var index = grid.GetFocusedRowIndex();
                if (index != -1)
                    viewSetting1.glpCar_bind(grid,index);

            },
            glpCar_bind: function (grid,index) {
                 grid.GetRowValues(index, 'link_name;link_mobilephone;car_no', function OnGetRowValues(values) {
                       link_name.SetText(values[0]);
					   link_mobilephone.SetText(values[1]);
					   car_no.SetText(values[2]);
                });
            }
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
    <cx:ASPxGridView ID="gridStowage" runat="server" OnRowDeleting="gridStowage_RowDeleting"
        OnRowInserting="gridStowage_RowInserting" OnHtmlEditFormCreated="gridStowage_HtmlEditFormCreated"
        EnableRowsCache="true" DataSourceID="stowageDataSource" DataSourceForceStandardPaging="true" OnCustomCallback="gridStowage_CustomCallback"
        OnRowUpdating="gridStowage_RowUpdating" KeyFieldName="id" RowCheckBox="true" OnInitNewRow="gridStowage_InitNewRow">
        <Columns>
            <dx:GridViewDataTextColumn Width="40" Caption="序号" ToolTip="序号" CellStyle-HorizontalAlign="Center"
                Settings-AllowSort="False" FixedStyle="Left">
                <DataItemTemplate>
                    <%# Container.VisibleIndex + 1%></DataItemTemplate>
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="id" FieldName="id"  Visible="false">
            </dx:GridViewDataTextColumn>
			<dx:GridViewDataTextColumn Caption="发车号" FieldName="stowage_number" Width="100">
            </dx:GridViewDataTextColumn>
			<dx:GridViewDataComboBoxColumn FieldName="stowage_statue" Caption="状态"  Width="80">
                <PropertiesComboBox TextField="Description" ValueField="Name" EnableSynchronization="False" DataSourceID="stowageStatueDataSource">
                </PropertiesComboBox>
            </dx:GridViewDataComboBoxColumn>
			<dx:GridViewDataTextColumn Caption="发车时间" FieldName="departure_time">
			    <PropertiesTextEdit DisplayFormatString="yyyy/MM/dd" DisplayFormatInEditMode="True">
                </PropertiesTextEdit>
            </dx:GridViewDataTextColumn>
			<dx:GridViewDataTextColumn Caption="预计到达" FieldName="plan_arrivle">
			    <PropertiesTextEdit DisplayFormatString="yyyy/MM/dd" DisplayFormatInEditMode="True">
                </PropertiesTextEdit>
            </dx:GridViewDataTextColumn>
			<dx:GridViewDataTextColumn Caption="车牌" FieldName="car_no">
            </dx:GridViewDataTextColumn>
			<dx:GridViewDataTextColumn Caption="司机" FieldName="link_name">
            </dx:GridViewDataTextColumn>
			<dx:GridViewDataTextColumn Caption="随车电话" FieldName="link_mobilephone">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="预付" FieldName="prepay">
            </dx:GridViewDataTextColumn>
			<dx:GridViewDataTextColumn Caption="到付" FieldName="arrive_payment">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="回结" FieldName="back_payment">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="配载人员" FieldName="emp_name">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="起运站" FieldName="start_branch_name">
            </dx:GridViewDataTextColumn>
			<dx:GridViewDataTextColumn Caption="目的" FieldName="end_branch_name">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="备注" FieldName="main_memo">
            </dx:GridViewDataTextColumn>
        </Columns> 
		<SettingsDetail ShowDetailRow="true" />
        <Templates>
		      <DetailRow>
                <dx:ASPxGridView ID="gridStowageDetail" runat="server" ClientInstanceName="gridStowageDetail"
                    AutoGenerateColumns="False" Width="100%" KeyFieldName="id" OnLoad="gridStowageDetail_Load">
                    <Columns>
					       <dx:GridViewDataTextColumn Width="40" Caption="序号" ToolTip="序号" CellStyle-HorizontalAlign="Center"
								Settings-AllowSort="False" FixedStyle="Left">
								<DataItemTemplate>
									<%# Container.VisibleIndex + 1%></DataItemTemplate>
							</dx:GridViewDataTextColumn>
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
							<dx:GridViewDataTextColumn Caption="重量(吨)" FieldName="production_weight"  Width="80">
                            </dx:GridViewDataTextColumn>
							<dx:GridViewDataTextColumn Caption="体积(m&sup3;)" FieldName="production_size"  Width="80">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="件数" FieldName="production_number"  Width="80">
                            </dx:GridViewDataTextColumn>
							<dx:GridViewDataTextColumn Caption="现付" FieldName="spot_payment"  Width="80">
                            </dx:GridViewDataTextColumn>
							<dx:GridViewDataTextColumn Caption="提付" FieldName="pick_payment"  Width="80">
                            </dx:GridViewDataTextColumn>
							<dx:GridViewDataTextColumn Caption="回付" FieldName="back_payment"  Width="80">
                            </dx:GridViewDataTextColumn>
							<dx:GridViewDataTextColumn Caption="运费" FieldName="freight"  Width="80">
                            </dx:GridViewDataTextColumn>
                    </Columns>
                    <Settings GridLines="Both" ShowVerticalScrollBar="false" ShowFooter="true"/>
                    <SettingsBehavior AllowSelectByRowClick="true" AllowFocusedRow="false" ConfirmDelete="true"
                        AllowSort="false" />
                    <SettingsText EmptyDataRow="无数据" />
                    <SettingsPager Mode="ShowAllRecords" />
                    <Border BorderWidth="0" />
					<TotalSummary>
					    <dx:ASPxSummaryItem FieldName="way_number" SummaryType="Sum" DisplayFormat="合计：" />
					    <dx:ASPxSummaryItem FieldName="production_weight" SummaryType="Sum" DisplayFormat="{0}" />
						<dx:ASPxSummaryItem FieldName="production_size" SummaryType="Sum" DisplayFormat="{0}"/>
						<dx:ASPxSummaryItem FieldName="production_number" SummaryType="Sum" DisplayFormat="{0}"/>
                        <dx:ASPxSummaryItem FieldName="freight" SummaryType="Sum" DisplayFormat="总运费：￥{0}" />
                    </TotalSummary>
                </dx:ASPxGridView>
            </DetailRow>
            <EditForm>
                <dx:EditToolBar ID="stowage_statue" runat="server" MenuTye="StowageMenu"></dx:EditToolBar>
                <table cellpadding="4" cellspacing="0" class="editTable1">
                    <tr>
                        <td class="editFormCaption">
                            发车号<span class="red">*</span>:
                        </td>
                        <td class="editFormCell">
                            <dx:GeneralNumber ID="stowage_number" runat="server" CodeEnum="Stowage" Width="100">
                            </dx:GeneralNumber>
                        </td>
						 <td class="editFormTh" colspan="4">
                            货物发车单
                        </td>
						<td class="editFormCaption">
                            预计到达<span class="red">*</span>:
                        </td>
                        <td class="editFormCell">
                            <cx:ASPxDateEdit ID="plan_arrivle" DefaultAddToday="2" runat="server" Width="120"
                                IsRequired="true">
                            </cx:ASPxDateEdit>
                        </td>
                    </tr>
                    <tr>
					   <td class="editFormCaption">
                            车牌号查询:
                        </td>
                        <td class="editFormCell">
                            <dx:CarLookUp ID="car_id" runat="server" Width="120" Index="1" ClientSideJs="viewSetting1.glpCar_ValueChanged">
                            </dx:CarLookUp>
                        </td>
						 <td class="editFormCaption">
                            车牌号<span class="red">*</span>:
                        </td>
                        <td class="editFormCell">
                            <cx:ASPxTextBox ID="car_no" runat="server" Width="120" IsRequired="true">
                           </cx:ASPxTextBox>
                        </td>
                        <td class="editFormCaption">
                            司机<span class="red">*</span>:
                        </td>
                        <td class="editFormCell">
						   <cx:ASPxTextBox ID="link_name" runat="server" Width="120" IsRequired="true">
                           </cx:ASPxTextBox>
                        </td>
                        <td class="editFormCaption">
                            司机电话:
                        </td>
                        <td class="editFormCell">
						    <cx:ASPxTextBox ID="link_mobilephone" runat="server" Width="120">
                            </cx:ASPxTextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="editFormCaption">
                            起运网点<span class="red">*</span>:
                        </td>
                        <td class="editFormCell">
                            <dx:BranchLookUp ID="start_branch" runat="server" Index="1" Width="120" IsRequrided="true"></dx:BranchLookUp>
                        </td>
					    <td class="editFormCaption">
                            目的网点<span class="red">*</span>:
                        </td>
                        <td class="editFormCell">
                            <dx:BranchLookUp ID="end_branch" runat="server" Index="2" Width="120" IsRequrided="true" ClientSideJs="viewSetting1.glpBranch_ValueChanged"></dx:BranchLookUp>
                        </td>
						<td class="editFormCaption">
                            到达主任:
                        </td>
                        <td class="editFormCell">
						    <cx:ASPxTextBox ID="end_branch_linkname" runat="server" Width="120">
                            </cx:ASPxTextBox>
                        </td>
						<td class="editFormCaption">
                            联系电话:
                        </td>
                        <td class="editFormCell">
						    <cx:ASPxTextBox ID="end_branch_linktelephone" runat="server" Width="120">
                            </cx:ASPxTextBox>
                        </td>
                    </tr>
					<tr>
						
					    <td class="editFormCaption">
                            预付<span class="red">*</span>:
                        </td>
                        <td class="editFormCell">
                          <cx:ASPxTextBox ID="prepay" IsPrice="true" Width="120" runat="server">
                          </cx:ASPxTextBox>
                        </td>
                        <td class="editFormCaption">
                            到付:
                        </td>
                        <td class="editFormCell">
                          <cx:ASPxTextBox ID="arrive_payment" IsPrice="true" Width="120" runat="server">
                          </cx:ASPxTextBox>
                        </td>
						<td class="editFormCaption">
                            回结:
                        </td>
                        <td class="editFormCell">
                           <cx:ASPxTextBox ID="back_payment" IsPrice="true" WidthPixel="80" runat="server">
                          </cx:ASPxTextBox>
                        </td>
					    <td class="editFormCaption">
                            发车时间<span class="red">*</span>:
                        </td>
                        <td class="editFormCell">
                            <cx:ASPxDateEdit ID="departure_time" DefaultToday="true" runat="server" Width="120"
                                IsRequired="true">
                            </cx:ASPxDateEdit>
                        </td>
					</tr>
					<tr>
                        <td class="editFormCaption">
                            备注:
                        </td>
                        <td class="editFormCell" colspan="7">
                            <cx:ASPxMemo ID="main_memo" runat="server" Height="100%" Width="100%">
                            </cx:ASPxMemo>
                        </td>
                    </tr>
                </table>
                <div>
                    <dx:MainToolBar ID="MainToolBar1" runat="server" PageToolBar="SelectedMenu"></dx:MainToolBar>
                    <cx:ASPxGridView ID="gridStowageDetail"  runat="server" ClientInstanceName="gridStowageDetail" KeyFieldName="id"
                        DataSourceID="stowageDetailDataSource">
                        <Columns>
						    <dx:GridViewCommandColumn VisibleIndex="0" ButtonType="Image" Caption="操作" HeaderStyle-HorizontalAlign="Center" Width="40">
                                <DeleteButton Visible="True" Text="删除">
									<Image Height="16px" ToolTip="删除" Url="~/Images/commad/delete_16x.ico" Width="16px">
									</Image>
								</DeleteButton>
                            </dx:GridViewCommandColumn>
                            <dx:GridViewDataTextColumn Caption="id" FieldName="id" Visible="false">
                            </dx:GridViewDataTextColumn>
							 <dx:GridViewDataTextColumn FieldName="production.way_number" caption="运单号" width="100">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="production.production_name" caption="货物名称" width="70">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="production.end_city" caption="到站" width="60">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="production.deliver_name" caption="发货方">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="production.consignee_name" caption="收货方">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="production.production_weight" caption="重量(吨)"  width="60">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="production.production_size" caption="体积(m&sup3;)"  width="60">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="production.production_number" caption="件数"  width="50">
                            </dx:GridViewDataTextColumn>
							<dx:GridViewDataTextColumn Caption="现付" FieldName="production.spot_payment"  Width="60">
                            </dx:GridViewDataTextColumn>
							<dx:GridViewDataTextColumn Caption="提付" FieldName="production.pick_payment"  Width="60">
                            </dx:GridViewDataTextColumn>
							<dx:GridViewDataTextColumn Caption="回付" FieldName="production.back_payment"  Width="60">
                            </dx:GridViewDataTextColumn>
							 <dx:GridViewDataTextColumn FieldName="production.aggregate_amount" caption="总运费"  width="70">
                            </dx:GridViewDataTextColumn>
                        </Columns>
						<TotalSummary>
						    <dx:ASPxSummaryItem FieldName="production.way_number" SummaryType="Sum" DisplayFormat="合计：" />
							<dx:ASPxSummaryItem FieldName="production.production_weight" SummaryType="Sum" DisplayFormat="{0}" />
							<dx:ASPxSummaryItem FieldName="production.production_size" SummaryType="Sum" DisplayFormat="{0}"/>
							<dx:ASPxSummaryItem FieldName="production.production_number" SummaryType="Sum" DisplayFormat="{0}" />
							<dx:ASPxSummaryItem FieldName="production.aggregate_amount" SummaryType="Sum" DisplayFormat="￥{0}" />
						</TotalSummary>
						 <Settings GridLines="Both" ShowVerticalScrollBar="false" ShowFooter="true"/>
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
        <SettingsText PopupEditFormCaption="编辑配载发车信息" />
        <SettingsEditing Mode="PopupEditForm" PopupEditFormWidth="850" PopupEditFormHeight="400"
             />
        <Border BorderWidth="0" />
		 <ClientSideEvents EndCallback="viewSetting.grid_EndCallback" />
    </cx:ASPxGridView>

	<asp:ObjectDataSource ID="stowageDetailDataSource" runat="server" SelectMethod="GetList"      TypeName="SpecialLogisticsSystem.AppPortal.UIHelpers.StowageDetailTemporary" UpdateMethod="Update" InsertMethod="Insert" DeleteMethod="Delete" ></asp:ObjectDataSource>

    <asp:ObjectDataSource ID="stowageDataSource" runat="server" TypeName="SpecialLogisticsSystem.AppPortal.UIHelpers.StowageProvider"
        EnablePaging="True" MaximumRowsParameterName="maxRows" StartRowIndexParameterName="startRow"
        SortParameterName="sorter" SelectMethod="GetDataByPaging" SelectCountMethod="GetRowsCount"
        OnSelecting="stowageDataSource_Selecting"></asp:ObjectDataSource>

    <asp:ObjectDataSource ID="stowageStatueDataSource" runat="server" TypeName="SpecialLogisticsSystem.AppPortal.UIHelpers.EnumProvider"
        SelectMethod="GetStowageStatueData"></asp:ObjectDataSource>
    <dx:ProductionList ID="productionList" runat="server" ClosingJs="function(s,e){gridStowageDetail.Refresh();}" Statue="New,Storage" WayType="0"></dx:ProductionList>
	<dx:PrintPopup ID="PrintPopup1" runat="server"></dx:PrintPopup>
</asp:Content>
