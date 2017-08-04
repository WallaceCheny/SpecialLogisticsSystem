<%@ Page Title="" Language="C#" MasterPageFile="~/MenuMaster.Master" AutoEventWireup="true" CodeBehind="Arrival.aspx.cs" Inherits="SpecialLogisticsSystem.AppPortal.Business.Arrival" %>

<%@ Register Src="/UserControls/ProductionSign.ascx" TagName="ProductionSign" TagPrefix="uc1" %>
<%@ Register Src="/UserControls/ProductionListByCar.ascx" TagName="ProductionListByCar" TagPrefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript">
        gridConfig.gridID = 'gridWay';
        gridConfig.popupID = 'pop_Signer';
		gridConfig.popupGridID='gridStowage';
		gridConfig.popupSelectedGridID='gridPopupStowageDetail';
		gridConfig.gridSubID = 'gridStowageDetail';
		gridConfig.gridSubHeight =230;
		//gridConfig.popuSelectedTypeName="Arrival";
        var viewSetting1 = {
        };
        function filterCondition() {
            return { way_number: txt_way_number.GetValue(), receive_date_start: receive_date_start.GetValueString(), receive_date_end: receive_date_end.GetValueString(),bill_statue:cmbWayStatue.GetValue(), is_hide:0 };
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SearchContent" runat="server">
    <ul id="viewSearch">
		<li class="caption">
		    运单号：
		</li>
		<li>
			<cx:ASPxTextBox ID="txt_way_number" runat="server" Width="140px">
            </cx:ASPxTextBox>
		</li>
		<li class="caption">
			接单日期：
		</li>
		 <li>
			 <dx:DateRange ID="date_range"  runat="server"></dx:DateRange>
		 </li>
		 <li class="caption">
		    运单状态：
		</li>
		<li>
			<cx:ASPxComboBox ID="cmbWayStatue" runat="server" DataSourceID="wayStatueDataSource" 
            TextField="Description" ValueField="Name" Width="100px" SelectedIndex="5"
            EnableCallbackMode="True" EnableViewState="false"/>
			<asp:ObjectDataSource ID="wayStatueDataSource" runat="server" TypeName="SpecialLogisticsSystem.AppPortal.UIHelpers.EnumProvider"
				SelectMethod="GetWayStatueData"></asp:ObjectDataSource>
		</li>
	</ul>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
  <cx:ASPxGridView ID="gridWay" runat="server" 
        DataSourceID="wayDataSource" DataSourceForceStandardPaging="true"  OnRowInserting="gridWay_RowInserting" 
        KeyFieldName="id" RowCheckBox="true" OnCustomCallback="gridWay_CustomCallback" OnInitNewRow="gridWay_InitNewRow">
        <Columns>
            <dx:GridViewDataTextColumn Width="40" Caption="序号" ToolTip="序号" CellStyle-HorizontalAlign="Center"
                Settings-AllowSort="False" FixedStyle="Left">
                <DataItemTemplate>
                    <%# Container.VisibleIndex + 1%></DataItemTemplate>
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="id" FieldName="id" Visible="false">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="接单日期" FieldName="receive_date" FixedStyle="Left"
                Width="80">
				<PropertiesTextEdit DisplayFormatString="yyyy/MM/dd" DisplayFormatInEditMode="True">
                </PropertiesTextEdit>
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="运单号" FieldName="way_number" FixedStyle="Left"
                Width="85">
            </dx:GridViewDataTextColumn>
			<dx:GridViewDataComboBoxColumn FieldName="bill_statue" Caption="状态"  Width="80">
                <PropertiesComboBox TextField="Description" ValueField="Name" EnableSynchronization="False" DataSourceID="billStatueDataSource">
                </PropertiesComboBox>
            </dx:GridViewDataComboBoxColumn>
			<dx:GridViewDataTextColumn Caption="发车日期" FieldName="departure_time" Width="80">
			    <PropertiesTextEdit DisplayFormatString="yyyy/MM/dd" DisplayFormatInEditMode="True">
                </PropertiesTextEdit>
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="车牌号" FieldName="car_no" Width="80">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="车次编号" FieldName="stowage_number" Width="85">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="起运地" FieldName="start_city" Width="80">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="目的地" FieldName="end_city" Width="80">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="发货人" FieldName="deliver_name" Width="85">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="收货人" FieldName="consignee_name" Width="85">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="现付" FieldName="spot_payment" Width="65">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="提付" FieldName="pick_payment" Width="65">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="回付" FieldName="back_payment" Width="65">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="货款扣" FieldName="production_payment" Width="65">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="运输方式" FieldName="shipping_type_name">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="运输方式" FieldName="shipping_type" Visible="false">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="交货方式" FieldName="delivery_type_name">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="交货方式" FieldName="delivery_type" Visible="false">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="回单份数" FieldName="receipt_portion">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="回单号" FieldName="receipt_number">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="代收类型" FieldName="collection_type" Visible="false">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="代收类型" FieldName="collection_type_name">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="备注" FieldName="bill_memo">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="提付网点" FieldName="bring_site" Visible="false">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="提付人" FieldName="bring_man">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="回扣网点" FieldName="back_site" Visible="false">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="回扣结算人" FieldName="back_man">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="经由" FieldName="pass_city">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="总金额" FieldName="aggregate_amount">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="结算方式" FieldName="clearing_type_name">
            </dx:GridViewDataTextColumn>
        </Columns>
		<Templates>
            <EditForm>
                <dx:EditToolBar ID="EditToolBar1" runat="server"></dx:EditToolBar>
                <table cellpadding="4" cellspacing="0" class="editTable1">
                    <tr>
                        <td class="editFormCaption">
                            到车时间<span class="red">*</span>:
                        </td>
                        <td class="editFormCell">
                            <cx:ASPxDateEdit ID="arrival_date" DefaultToday="true" runat="server" Width="100"
                                IsRequired="true">
                            </cx:ASPxDateEdit>
                        </td>
						 <td class="editFormTh" colspan="2">
                            到货确认
                        </td>
                         <td class="editFormCaption">
                            卸点体积:
                        </td>
                        <td class="editFormCell">
                            <cx:ASPxTextBox ID="unload_size" runat="server" Width="100">
                           </cx:ASPxTextBox>
                        </td>
                    </tr>
                    <tr>
					  
                        <td class="editFormCaption">
                            卸点重量:
                        </td>
                        <td class="editFormCell">
						   <cx:ASPxTextBox ID="unload_weight" runat="server" Width="100">
                           </cx:ASPxTextBox>
                        </td>
                        <td class="editFormCaption">
                            卸货费:
                        </td>
                        <td class="editFormCell">
						    <cx:ASPxTextBox ID="unload_fee" IsPrice="true" WidthPixel="100" runat="server">
                          </cx:ASPxTextBox>
                        </td>
						<td class="editFormCaption">
                            外请搬运:
                        </td>
                        <td class="editFormCell" colspan="5">
						    <cx:ASPxTextBox ID="outside_fee" IsPrice="true" runat="server" Width="100">
                            </cx:ASPxTextBox>
                        </td>
                    </tr>
                </table>
                <div>
                    <dx:MainToolBar ID="MainToolBar1" runat="server" PageToolBar="SelectedMenu"></dx:MainToolBar>
                    <cx:ASPxGridView ID="gridStowageDetail"  runat="server" ClientInstanceName="gridStowageDetail" KeyFieldName="id"
                        DataSourceID="stowageDetailDataSource">
                        <Columns>
						    <dx:GridViewCommandColumn VisibleIndex="0" ButtonType="Image" Caption="操作" HeaderStyle-HorizontalAlign="Center">
                                <DeleteButton Visible="True" Text="删除">
									<Image Height="16px" ToolTip="删除" Url="~/Images/commad/delete_16x.ico" Width="16px">
									</Image>
								</DeleteButton>
                            </dx:GridViewCommandColumn>
                            <dx:GridViewDataTextColumn Caption="id" FieldName="id" Visible="false">
                            </dx:GridViewDataTextColumn>
							<dx:GridViewDataTextColumn FieldName="production.way_number" caption="运单号">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="production.production_name" caption="货物名称">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="production.end_city" caption="到站">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="production.deliver_name" caption="发货方">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="production.consignee_name" caption="收货方">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="production.production_weight" caption="重量"  width="50">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="production.production_size" caption="体积"  width="50">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="production.production_number" caption="件数"  width="50">
                            </dx:GridViewDataTextColumn>
                        </Columns>
                        <SettingsBehavior AllowSelectByRowClick="true" AllowFocusedRow="true" ConfirmDelete="true"
                            AllowSort="false" />
						 <Border BorderWidth="0" />
						 <ClientSideEvents EndCallback="viewSetting.gridSub_EndCallback" Init="viewSetting.gridSub_EndCallback" />
						 <SettingsText Title="系统提示" EmptyDataRow="无数据" PopupEditFormCaption="编辑" ConfirmDelete="确定删除本行记录吗 ？" />
                    </cx:ASPxGridView>
                </div>
            </EditForm>
        </Templates>
		<SettingsText PopupEditFormCaption="编辑到车信息" />
        <Settings ShowHorizontalScrollBar="true" ShowVerticalScrollBar="true"/>
        <SettingsEditing Mode="PopupEditForm" PopupEditFormWidth="600" PopupEditFormHeight="375"
            PopupEditFormVerticalOffset="-5" PopupEditFormHorizontalOffset="0" />
        <Border BorderWidth="0" />
        <ClientSideEvents EndCallback="viewSetting.grid_EndCallback" />
    </cx:ASPxGridView>
	<asp:ObjectDataSource ID="stowageDetailDataSource" runat="server" SelectMethod="GetList"      TypeName="SpecialLogisticsSystem.AppPortal.UIHelpers.StowageDetailTemporary" UpdateMethod="Update" InsertMethod="Insert" DeleteMethod="Delete" ></asp:ObjectDataSource>
	<asp:ObjectDataSource ID="wayDataSource" runat="server" TypeName="SpecialLogisticsSystem.AppPortal.UIHelpers.WayProvider"
        EnablePaging="True" MaximumRowsParameterName="maxRows" StartRowIndexParameterName="startRow"
        SortParameterName="sorter" SelectMethod="GetDataByPaging" SelectCountMethod="GetRowsCount"
        OnSelecting="wayDataSource_Selecting"></asp:ObjectDataSource>
	 <asp:ObjectDataSource ID="billStatueDataSource" runat="server" TypeName="SpecialLogisticsSystem.AppPortal.UIHelpers.EnumProvider"
        SelectMethod="GetWayStatueData"></asp:ObjectDataSource>
	 <uc1:ProductionSign ID="ProductionSign1" runat="server"></uc1:ProductionSign>
	 <uc2:ProductionListByCar ID="ProductionListByCar1" runat="server" ClosingJs="function(s,e){gridStowageDetail.Refresh();}"></uc2:ProductionListByCar>
</asp:Content>
