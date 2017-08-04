<%@ Page Title="" Language="C#" MasterPageFile="~/MenuMaster.Master" AutoEventWireup="true"
    CodeBehind="Way.aspx.cs" Inherits="SpecialLogisticsSystem.AppPortal.Business.Way" %>

<%@ Register Src="/UserControls/LabelWayStatue.ascx" TagName="LabelWayStatue" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript">
        gridConfig.gridID = 'gridWay';
        gridConfig.gridSubID = 'gridProduction';
		gridConfig.isSaveSub = 'true';
        gridConfig.popupID = 'pop_PrintConstruct';
	    gridConfig.gridSubHeight =50;
        //关联发货人，收货人
        var viewSetting1 = {
			 glp_cust_ValueChanged: function (s, e) {
				var grid = s.GetGridView();
				grid.cp_cust_id = '';
				var index = grid.GetFocusedRowIndex();
				if (index != -1)
					viewSetting1.glp_cust_bind(grid, index);
			},
			glp_cust_bind: function (grid, index) {
				grid.GetRowValues(index, 'id;link_mobilephone;link_address;link_area;link_name', function OnGetRowValues(values) {
				    
					if (grid.name.indexOf('1') > 0) {

						    deliver_name.SetText(values[4]);
							deliver_mobile.SetText(values[1]);
							deliver_address.SetText(values[2]);
							deliver_area.SetText(values[3]);

						var gridview = window["customer_customelookup2_DDD_gv"];
					    gridview.PerformCallback(values[0]);
					}
					else {
					    consignee_name.SetText(values[4]);
						consignee_mobile.SetText(values[1]);
						consignee_address.SetText(values[2]);
						consignee_area.SetText(values[3]);
					}
				});
			},
        };
		//计算运费
		function calculateFreight(s, e){		
		        var number=gridProduction.GetEditor("production_number").GetValue();
				var weight=gridProduction.GetEditor("production_weight").GetValue();
				var size=gridProduction.GetEditor("production_size").GetValue();
				var rates=gridProduction.GetEditor("freight_rates").GetValue();
				var price_type=gridProduction.GetEditor("charge_mode").GetText();
                var totalPrice=0;
				switch (price_type) {
					case '件数':
                       totalPrice=rates*number;
					   break;
					case '体积':
                      totalPrice=rates*size;
					  break;
					case '重量':
                      totalPrice=rates*weight;
					  break;
			    }
				gridProduction.GetEditor("freight").SetText(String(totalPrice));
		}
		function setPrice(s,e){
		    var totalPrice=aggregate_amount.GetValue();
			var type_name=cmbCode2_DDD_L.GetValue();//结算方式
			spot_payment.SetValue(0);
			back_payment.SetValue(0);
			pick_payment.SetValue(0);
			production_payment.SetValue(0);
			switch (type_name) {
					case '0'://现付
                       spot_payment.SetValue(totalPrice);
					   break;
					case '1': //月结
					case '2'://回单付
                       back_payment.SetValue(totalPrice);
					  break;
					case '3'://提付
                       pick_payment.SetValue(totalPrice);
					  break;
					 case '4'://货款扣
                       production_payment.SetValue(totalPrice);
					  break;
			    }
		}
		//计算总费用
		function calculateTotalPrice(s,e){
				var freight=gridProduction.GetEditor("freight").GetValue();
				var premium=gridProduction.GetEditor("premium").GetValue();
				var receive_expenses=gridProduction.GetEditor("receive_expenses").GetValue();
				var other_expenses=gridProduction.GetEditor("other_expenses").GetValue();
				 $.ajax({
					type: "GET",
					url: "/UIHelpers/AjaxHelper.ashx",
					dataType: 'json',
					cache: false,
					async: true,
					data: { method: 'CalculateTotalPrice', freight: freight, premium: premium, receive_expenses: receive_expenses, other_expenses: other_expenses },
					success: function (json) {
						if (json && json.IsSuccessfully) {
							aggregate_amount.SetText(String(json.Data));
							setPrice(s,e)
						}
					}
				});
		}
		
        function filterCondition() {
            return { way_number: txt_way_number.GetValue(), receive_date_start: receive_date_start.lastSuccessText, receive_date_end: receive_date_end.lastSuccessText, is_hide:0 };
        }

		function setCustomer(s,e, index){
			var result=s.GetInputElement().value; 
			if(result!='') $('#hideText' + index).val(result);
	//	$.ajax({
//				type: "GET",
//				url: "/UIHelpers/AjaxHelper.ashx",
//				dataType: 'json',
//				cache: false,
//				async: true,
//				data: { method: 'InsertedCustomer', value: result },
//				success: function (json) {
//					if (json && json.IsSuccessfully) {
//					  var gridview = window["customer_customelookup1_DDD_gv"];
//			           gridview.Refresh();
//					}
//				}
//           });
		}
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SearchContent" runat="server">
    <ul id="viewSearch">
        <li class="caption">运单号： </li>
        <li>
            <cx:ASPxTextBox ID="txt_way_number" runat="server" Width="140px">
            </cx:ASPxTextBox>
        </li>
        <li class="caption">接单日期： </li>
        <li>
            <dx:DateRange ID="date_range" runat="server"></dx:DateRange>
        </li>
    </ul>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <cx:ASPxGridView ID="gridWay" runat="server" OnRowDeleting="gridWay_RowDeleting"
        OnRowInserting="gridWay_RowInserting" OnHtmlEditFormCreated="gridWay_HtmlEditFormCreated"
        DataSourceID="wayDataSource" DataSourceForceStandardPaging="true" OnInitNewRow="gridWay_InitNewRow"
        OnRowUpdating="gridWay_RowUpdating" KeyFieldName="id" RowCheckBox="true" OnCustomCallback="gridWay_CustomCallback">
        <Columns>
            <dx:GridViewDataTextColumn Width="40" Caption="序号" ToolTip="序号" CellStyle-HorizontalAlign="Center"
                Settings-AllowSort="False" FixedStyle="Left">
                <DataItemTemplate>
                    <%# Container.VisibleIndex + 1%></DataItemTemplate>
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="id" FieldName="id" Visible="false">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="接单日期" FieldName="receive_date" FixedStyle="Left"
                Width="85">
                <PropertiesTextEdit DisplayFormatString="yyyy/MM/dd" DisplayFormatInEditMode="True">
                </PropertiesTextEdit>
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="运单号" FieldName="way_number" FixedStyle="Left"
                Width="120">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataComboBoxColumn FieldName="bill_statue" Caption="状态" Width="80">
                <PropertiesComboBox TextField="Description" ValueField="Name" EnableSynchronization="False"
                    DataSourceID="billStatueDataSource">
                </PropertiesComboBox>
            </dx:GridViewDataComboBoxColumn>
            <dx:GridViewDataTextColumn Caption="起运地" FieldName="start_city" Width="70">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="目的地" FieldName="end_city" Width="70">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="发货人" FieldName="deliver_name" Width="85">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="收货人" FieldName="consignee_name" Width="85">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="货物名称" FieldName="production_name" Width="80">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataComboBoxColumn Caption="包装方式" FieldName="package_type_name" Width="80">
            </dx:GridViewDataComboBoxColumn>
            <dx:GridViewDataTextColumn Caption="件数" FieldName="production_number" Width="40">
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
            <dx:GridViewDataTextColumn Caption="经办人" FieldName="emp_name">
            </dx:GridViewDataTextColumn>
        </Columns>
        <Templates>
            <EditForm>
                <dx:EditToolBar ID="bill_statue" runat="server" MenuTye="WayMenu"></dx:EditToolBar>
                <table cellpadding="4" cellspacing="0" class="editTable1">
                    <tr>
						<td class="editFormCaption">
                            运单号<span class="red">*</span>:
                        </td>
                        <td class="editFormCell">
                            <dx:GeneralNumber ID="way_number" runat="server" CodeEnum="Way" Width="120"></dx:GeneralNumber>
                        </td>
                        <td class="editFormTh" colspan="8">
                            货物托运单
                        </td>
                    </tr>
                    <tr>
						 <td class="editFormCaption">
                            接单日期<span class="red">*</span>:
                        </td>
                        <td class="editFormCell">
                            <cx:ASPxDateEdit ID="receive_date" DefaultToday="true" runat="server" Width="120"
                                IsRequired="true">
                            </cx:ASPxDateEdit>
                        </td>
                        <td class="editFormCaption">
                            起站<span class="red">*</span>:
                        </td>
                        <td class="editFormCell">
                            <dx:CityLookUp ID="start_city" runat="server" Index="1" IsStartCity="true" IsRequrided="true" Width="120">
                            </dx:CityLookUp>
                        </td>
                        <td class="editFormCaption">
                            目的地<span class="red">*</span>:
                        </td>
                        <td class="editFormCell">
                            <dx:CityLookUp ID="end_city" runat="server" Index="2" IsEndCity="true" IsRequrided="true" Width="120">
                            </dx:CityLookUp>
                        </td>
                        <td class="editFormCaption">
                            经由:
                        </td>
                        <td class="editFormCell">
                            <dx:CityLookUp ID="pass_city" runat="server" Index="3" Width="120"></dx:CityLookUp>
                        </td>
                        <td class="editFormCaption">
                            订单类型<span class="red">*</span>:
                        </td>
                        <td class="editFormCell">
                            <dx:ComoboxCode ID="way_type" codeType="way_type" runat="server" DefaultValue="0"
                                Index="1" IsRequrided="true" Width="120"></dx:ComoboxCode>
                        </td>
                    </tr>
                    <tr>
                        <td class="editFormCaption">
                            查找发货人:
                        </td>
                        <td class="editFormCell">
                            <dx:CustomerLookUp ID="deliver_id" runat="server" CustomerEnum="Deliver"
                                ClientSideJs="viewSetting1.glp_cust_ValueChanged" Index="1" Width="120"></dx:CustomerLookUp>
                        </td>
						<td class="editFormCaption">
                            发货人<span class="red">*</span>:
                        </td>
                        <td class="editFormCell">
                            <cx:ASPxTextBox ID="deliver_name" runat="server" Width="120" IsRequired="true">
                            </cx:ASPxTextBox>
                        </td>
                        <td class="editFormCaption">
                            联系电话<span class="red">*</span>:
                        </td>
                        <td class="editFormCell">
                            <cx:ASPxTextBox ID="deliver_mobile" runat="server" Width="120" IsRequired="true">
                            </cx:ASPxTextBox>
                        </td>
                        <td class="editFormCaption">
                            地区<span class="red">*</span>:
                        </td>
                        <td class="editFormCell">
                            <cx:ASPxTextBox ID="deliver_area" runat="server" Width="120" IsRequired="true">
                            </cx:ASPxTextBox>
                        </td>
                        <td class="editFormCaption">
                            地址:
                        </td>
                        <td class="editFormCell">
                            <cx:ASPxTextBox ID="deliver_address" runat="server" Width="120">
                            </cx:ASPxTextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="editFormCaption">
                             查找收货人:
                        </td>
                        <td class="editFormCell">
                            <dx:CustomerLookUp ID="consignee_id" runat="server" CustomerEnum="Consignee"
                                ClientSideJs="viewSetting1.glp_cust_ValueChanged" Index="2" Width="120"></dx:CustomerLookUp>
                        </td>
						<td class="editFormCaption">
                            收货人<span class="red">*</span>:
                        </td>
                        <td class="editFormCell">
                            <cx:ASPxTextBox ID="consignee_name" runat="server" Width="120" IsRequired="true">
                            </cx:ASPxTextBox>
                        </td>
                        <td class="editFormCaption">
                            联系电话<span class="red">*</span>:
                        </td>
                        <td class="editFormCell">
                            <cx:ASPxTextBox ID="consignee_mobile" runat="server" Width="120" IsRequired="true" IsSubRequired="false">
                            </cx:ASPxTextBox>
                        </td>
                        <td class="editFormCaption">
                            地区<span class="red">*</span>:
                        </td>
                        <td class="editFormCell">
                            <cx:ASPxTextBox ID="consignee_area" runat="server" Width="120" IsRequired="true" IsSubRequired="false">
                            </cx:ASPxTextBox>
                        </td>
                        <td class="editFormCaption">
                            地址:
                        </td>
                        <td class="editFormCell">
                            <cx:ASPxTextBox ID="consignee_address" runat="server" Width="120">
                            </cx:ASPxTextBox>
                        </td>
                    </tr>
                </table>
                <div>
                    <cx:ASPxGridView ID="gridProduction" runat="server" ClientInstanceName="gridProduction"
                        IsPage="false" KeyFieldName="id" OnRowInserting="gridProduction_RowInserting"
                        OnRowUpdating="gridProduction_RowUpdating" OnHtmlEditFormCreated="gridProduction_HtmlEditFormCreated"
                        OnRowDeleting="gridProduction_RowDeleting" DataSourceID="productionDataSource"
                        EditingMode="Inline">
                        <Columns>
                            <dx:GridViewDataTextColumn Caption="id" FieldName="id" Visible="false">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="货物名称" FieldName="production_name" Width="120">
                                <PropertiesTextEdit>
                                    <ValidationSettings Display="Dynamic" SetFocusOnError="true" ErrorDisplayMode="ImageWithTooltip"
                                        ValidateOnLeave="true" ValidationGroup="validGroup">
                                        <RequiredField IsRequired="true" ErrorText="请选择车牌首字" />
                                    </ValidationSettings>
                                </PropertiesTextEdit>
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataComboBoxColumn Caption="包装方式" FieldName="package_type" Width="80">
                                <PropertiesComboBox TextField="para_name" ValueField="para_value" EnableSynchronization="False"
                                    DataSourceID="packtypeDataSource">
                                </PropertiesComboBox>
                            </dx:GridViewDataComboBoxColumn>
                            <dx:GridViewDataSpinEditColumn Caption="件数" FieldName="production_number" Width="80">
                                <PropertiesSpinEdit>
                                    <ClientSideEvents ValueChanged="function(s, e) {
										   calculateFreight(s,e);
										}" />
                                    <ValidationSettings Display="Dynamic" SetFocusOnError="true" ErrorDisplayMode="ImageWithTooltip"
                                        ValidateOnLeave="true" ValidationGroup="orderValidGroup">
                                        <RequiredField IsRequired="true" ErrorText="请选择车牌首字" />
                                    </ValidationSettings>
                                </PropertiesSpinEdit>
                            </dx:GridViewDataSpinEditColumn>
                            <dx:GridViewDataSpinEditColumn Caption="重量(吨)" FieldName="production_weight" Width="60">
                                <PropertiesSpinEdit>
                                    <ClientSideEvents ValueChanged="function(s, e) {
										   calculateFreight(s,e);
										}" />
                                </PropertiesSpinEdit>
                            </dx:GridViewDataSpinEditColumn>
                            <dx:GridViewDataSpinEditColumn Caption="体积(m&sup3;)" FieldName="production_size"
                                Width="60">
                                <PropertiesSpinEdit>
                                    <ClientSideEvents ValueChanged="function(s, e) {
										   calculateFreight(s,e);
										}" />
                                </PropertiesSpinEdit>
                            </dx:GridViewDataSpinEditColumn>
                            <dx:GridViewDataComboBoxColumn Caption="计费方式" FieldName="charge_mode" Width="80">
                                <PropertiesComboBox TextField="para_name" ValueField="para_value" EnableSynchronization="False"
                                    DataSourceID="chargemodeDataSource">
                                    <ClientSideEvents ValueChanged="function(s, e) {
										   calculateFreight(s,e);
										}" />
                                </PropertiesComboBox>
                            </dx:GridViewDataComboBoxColumn>
                            <dx:GridViewDataSpinEditColumn PropertiesSpinEdit-DisplayFormatString="c" Caption="计费单价"
                                FieldName="freight_rates" Width="70">
                                <PropertiesSpinEdit DisplayFormatString="c" NumberFormat="Custom">
                                    <ClientSideEvents ValueChanged="function(s, e) {
										   calculateFreight(s,e);
										}" />
                                </PropertiesSpinEdit>
                            </dx:GridViewDataSpinEditColumn>
                            <dx:GridViewDataSpinEditColumn PropertiesSpinEdit-DisplayFormatString="c" Caption="保额"
                                FieldName="coverage" Width="60">
                            </dx:GridViewDataSpinEditColumn>
                            <dx:GridViewDataSpinEditColumn PropertiesSpinEdit-DisplayFormatString="c" Caption="保费"
                                FieldName="premium" Width="60">
								 <PropertiesSpinEdit>
                                    <ClientSideEvents ValueChanged="function(s, e) {
										   calculateTotalPrice(s,e);
										}" />
                                </PropertiesSpinEdit>
                            </dx:GridViewDataSpinEditColumn>
                            <dx:GridViewDataSpinEditColumn PropertiesSpinEdit-DisplayFormatString="c" Caption="运费"
                                FieldName="freight" Width="80">
								<PropertiesSpinEdit>
                                    <ClientSideEvents ValueChanged="function(s, e) {
										   calculateTotalPrice(s,e);
										}" />
                                </PropertiesSpinEdit>
                            </dx:GridViewDataSpinEditColumn>
                            <dx:GridViewDataSpinEditColumn PropertiesSpinEdit-DisplayFormatString="c" Caption="代收款"
                                FieldName="agency_fund" Width="70">
                            </dx:GridViewDataSpinEditColumn>
                            <dx:GridViewDataSpinEditColumn PropertiesSpinEdit-DisplayFormatString="c" Caption="接货费"
                                FieldName="receive_expenses" Width="80">
								<PropertiesSpinEdit>
                                    <ClientSideEvents ValueChanged="function(s, e) {
										   calculateTotalPrice(s,e);
										}" />
                                </PropertiesSpinEdit>
                            </dx:GridViewDataSpinEditColumn>
                            <dx:GridViewDataSpinEditColumn PropertiesSpinEdit-DisplayFormatString="c" Caption="其他费"
                                FieldName="other_expenses" Width="80">
								<PropertiesSpinEdit>
                                    <ClientSideEvents ValueChanged="function(s, e) {
										   calculateTotalPrice(s,e);
										}" />
                                </PropertiesSpinEdit>
                            </dx:GridViewDataSpinEditColumn>
                        </Columns>
                        <TotalSummary>
                            <dx:ASPxSummaryItem FieldName="total_price" SummaryType="Sum" DisplayFormat="总金额：￥{0}" />
                        </TotalSummary>
                        <SettingsBehavior AllowSelectByRowClick="true" AllowFocusedRow="true" ConfirmDelete="true"
                            AllowSort="false" />
                        <SettingsText PopupEditFormCaption="编辑货物信息" />
                        <ClientSideEvents EndCallback="viewSetting.gridSub_EndCallback" Init="viewSetting.gridSub_EndCallback" />
                    </cx:ASPxGridView>
                </div>
                <table cellpadding="4" cellspacing="0" class="editTable">
                    <tr>
                        <td class="editFormCaption">
                            总金额:
                        </td>
                        <td class="editFormCell">
                            <cx:ASPxTextBox ID="aggregate_amount" IsPrice="true" IsReadOnly="true" runat="server"
                                Width="80">
                            </cx:ASPxTextBox>
                        </td>
                        <td class="editFormCaption">
                            结算方式<span class="red">*</span>:
                        </td>
                        <td class="editFormCell">
                            <dx:ComoboxCode ID="clearing_type" codeType="settle_type" runat="server" Width="80"
                                Index="2" IsRequrided="true" ClientSideJs="setPrice">
							</dx:ComoboxCode>
                        </td>
                        <td class="editFormCaption">
                            现付:
                        </td>
                        <td class="editFormCell">
                            <cx:ASPxTextBox ID="spot_payment" IsPrice="true" runat="server" Width="80">
                            </cx:ASPxTextBox>
                        </td>
                        <td class="editFormCaption">
                            提 付:
                        </td>
                        <td class="editFormCell">
                            <cx:ASPxTextBox ID="pick_payment" IsPrice="true" runat="server" Width="80">
                            </cx:ASPxTextBox>
                        </td>
                        <td class="editFormCaption">
                            回 付:
                        </td>
                        <td class="editFormCell">
                            <cx:ASPxTextBox ID="back_payment" IsPrice="true" runat="server" Width="80">
                            </cx:ASPxTextBox>
                        </td>
                        <td class="editFormCaption">
                            货款扣:
                        </td>
                        <td class="editFormCell">
                            <cx:ASPxTextBox ID="production_payment" IsPrice="true" runat="server" Width="80">
                            </cx:ASPxTextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="editFormCaption">
                            运输方式:
                        </td>
                        <td class="editFormCell">
                            <dx:ComoboxCode ID="shipping_type" codeType="carriage_type" runat="server" Width="80"
                                Index="3"></dx:ComoboxCode>
                        </td>
                        <td class="editFormCaption">
                            交货方式:
                        </td>
                        <td class="editFormCell">
                            <dx:ComoboxCode ID="delivery_type" codeType="delivery_type" runat="server" Width="80"
                                Index="4"></dx:ComoboxCode>
                        </td>
                        <td class="editFormCaption">
                            回单份数
                        </td>
                        <td class="editFormCell">
                            <cx:ASPxSpinEdit ID="receipt_portion" runat="server" IsInteger="true" Width="80">
                            </cx:ASPxSpinEdit>
                        </td>
                        <td class="editFormCaption">
                            回单号:
                        </td>
                        <td class="editFormCell">
                            <cx:ASPxTextBox ID="receipt_number" runat="server" Width="80">
                            </cx:ASPxTextBox>
                        </td>
                        <td class="editFormCaption">
                            代收类型:
                        </td>
                        <td class="editFormCell">
                            <dx:ComoboxCode ID="collection_type" codeType="agency_type" runat="server" Width="80"
                                Index="5"></dx:ComoboxCode>
                        </td>
                        <td class="editFormCaption">
                            回 扣:
                        </td>
                        <td class="editFormCell">
                            <cx:ASPxTextBox ID="bill_rebate" IsPrice="true" runat="server" Width="80">
                            </cx:ASPxTextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="editFormCaption">
                            备注:
                        </td>
                        <td class="editFormCell" colspan="11">
                            <cx:ASPxMemo ID="bill_memo" runat="server" Height="100%" Width="100%">
                            </cx:ASPxMemo>
                        </td>
                    </tr>
                </table>
            </EditForm>
        </Templates>
        <Settings ShowHorizontalScrollBar="true" ShowVerticalScrollBar="true" />
        <SettingsText PopupEditFormCaption="编辑运单信息" />
        <SettingsEditing Mode="PopupEditForm" PopupEditFormWidth="650" PopupEditFormHeight="345"
            PopupEditFormVerticalOffset="-5" PopupEditFormHorizontalOffset="-600" />
        <Border BorderWidth="0" />
        <ClientSideEvents EndCallback="viewSetting.grid_EndCallback" />
    </cx:ASPxGridView>
    <asp:ObjectDataSource ID="wayDataSource" runat="server" TypeName="SpecialLogisticsSystem.AppPortal.UIHelpers.WayProvider"
        EnablePaging="True" MaximumRowsParameterName="maxRows" StartRowIndexParameterName="startRow"
        SortParameterName="sorter" SelectMethod="GetDataByPaging" SelectCountMethod="GetRowsCount"
        OnSelecting="wayDataSource_Selecting"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="billStatueDataSource" runat="server" TypeName="SpecialLogisticsSystem.AppPortal.UIHelpers.EnumProvider"
        SelectMethod="GetWayStatueData"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="packtypeDataSource" runat="server" TypeName="SpecialLogisticsSystem.AppPortal.UIHelpers.EnumProvider"
        SelectMethod="GetPackTypeData"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="chargemodeDataSource" runat="server" TypeName="SpecialLogisticsSystem.AppPortal.UIHelpers.EnumProvider"
        SelectMethod="GetChargeModeData"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="productionDataSource" runat="server" SelectMethod="GetList"
        TypeName="SpecialLogisticsSystem.AppPortal.UIHelpers.ProductionTemporary" UpdateMethod="Update"
        InsertMethod="Insert" DeleteMethod="Delete"></asp:ObjectDataSource>
    <dx:PrintPopup ID="PrintPopup1" runat="server"></dx:PrintPopup>
    <dx:SendSms ID="SendSms1" runat="server"></dx:SendSms>
</asp:Content>
