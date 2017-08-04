<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestPaging.aspx.cs" Inherits="SpecialLogisticsSystem.AppPortal.Business.TestPaging" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
      <form id="frmMain" runat="server">
        <dx:ASPxButton ID="ASPxButton1" runat="server" Text="Export Grid" 
            style="margin-bottom:10px;" OnClick="ASPxButton1_Click">
	   </dx:ASPxButton>
	   <dx:ASPxCallback ID="cbk_input" runat="server" ClientInstanceName="cbk_input" OnCallback="cbk_input_Callback">
       </dx:ASPxCallback>
        <dx:ASPxGridView ID="ASPxGridView1" runat="server" DataSourceForceStandardPaging="true" 
            DataSourceID="ObjectDataSource1" Width="100%" KeyFieldName="id"  RowCheckBox="true">
			       <Columns>
            <dx:GridViewDataTextColumn Width="40" Caption="序号" ToolTip="序号" CellStyle-HorizontalAlign="Center"
                Settings-AllowSort="False" FixedStyle="Left">
                <DataItemTemplate>
                    <%# Container.VisibleIndex + 1%></DataItemTemplate>
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="id" FieldName="id" Visible="false">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="接单日期" FieldName="receive_date" FixedStyle="Left"
                Width="150">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="运单号" FieldName="way_number" FixedStyle="Left"
                Width="85">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="状态" FieldName="bill_statue" Width="80">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="起运地" FieldName="start_city" Width="100">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="目的地" FieldName="end_city" Width="100">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="发货人" FieldName="deliver_name" Width="85">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="收货人" FieldName="consignee_name" Width="85">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="现付" FieldName="spot_payment" Width="65">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="提付" FieldName="pick_payment" Width="65">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="回付" FieldName="back_payment">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="货款扣" FieldName="production_payment">
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
            <dx:GridViewDataTextColumn Caption="结算方式" FieldName="clearing_type">
            </dx:GridViewDataTextColumn>
        </Columns>
        <Templates>
            <%--<DetailRow>
                <dx:ASPxGridView ID="gridWayDetail" runat="server" ClientInstanceName="gridWayDetail"
                    AutoGenerateColumns="False" Width="100%" KeyFieldName="id" OnLoad="gridWayDetail_Load">
                    <Columns>
                        <dx:GridViewDataTextColumn Caption="id" FieldName="id" Visible="false">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="货物名称" FieldName="production_name" Width="80">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataComboBoxColumn Caption="包装方式" FieldName="package_type_name" Width="80">
                        </dx:GridViewDataComboBoxColumn>
                        <dx:GridViewDataTextColumn Caption="件数" FieldName="production_number" Width="40">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="重量" FieldName="production_weight" Width="50">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="体积" FieldName="production_size" Width="50">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="计费方式" FieldName="charge_mode_name" Width="50">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataSpinEditColumn PropertiesSpinEdit-DisplayFormatString="c" Caption="运费"
                            FieldName="freight" Width="50">
                        </dx:GridViewDataSpinEditColumn>
                        <dx:GridViewDataSpinEditColumn PropertiesSpinEdit-DisplayFormatString="c" Caption="总费用"
                            FieldName="total_price">
                        </dx:GridViewDataSpinEditColumn>
                    </Columns>
                    <Settings GridLines="Both" ShowVerticalScrollBar="false" ShowFooter="true" />
                    <SettingsBehavior AllowSelectByRowClick="true" AllowFocusedRow="false" ConfirmDelete="true"
                        AllowSort="false" />
                    <SettingsText EmptyDataRow="无数据" />
                    <SettingsPager Mode="ShowAllRecords" />
                    <Border BorderWidth="0" />
                </dx:ASPxGridView>
            </DetailRow>--%>
            <EditForm>
                <dx:EditToolBar ID="EditToolBar1" runat="server"></dx:EditToolBar>
                <table cellpadding="4" cellspacing="0" class="editTable1">
                    <tr>
                        <td class="editFormCaption">
                            运单号<span class="red">*</span>:
                        </td>
                        <td class="editFormCell">
                            <dx:GeneralNumber ID="way_number" runat="server" CodeEnum="Way" Width="100"></dx:GeneralNumber>
                        </td>
                        <td class="editFormTh" colspan="4">
                            货物托运单
                        </td>
                        <td class="editFormCaption">
                            接单日期<span class="red">*</span>:
                        </td>
                        <td class="editFormCell">
                            <cx:ASPxDateEdit ID="receive_date" DefaultToday="true" runat="server" Width="170"
                                IsRequired="true">
                            </cx:ASPxDateEdit>
                        </td>
                    </tr>
                    <tr>
                        <td class="editFormCaption">
                            起站<span class="red">*</span>:
                        </td>
                        <td class="editFormCell">
                            <dx:CityLookUp ID="start_city" runat="server" Index="1" IsDefault="true" IsRequrided="true">
                            </dx:CityLookUp>
                        </td>
                        <td class="editFormCaption">
                            目的地<span class="red">*</span>:
                        </td>
                        <td class="editFormCell">
                            <dx:CityLookUp ID="end_city" runat="server" Index="2" IsRequrided="true"></dx:CityLookUp>
                        </td>
                        <td class="editFormCaption">
                            经由:
                        </td>
                        <td class="editFormCell">
                            <dx:CityLookUp ID="pass_city" runat="server" Index="3"></dx:CityLookUp>
                        </td>
                        <td class="editFormCaption">
                            订单类型<span class="red">*</span>:
                        </td>
                        <td class="editFormCell">
                            <dx:ComoboxCode ID="way_type" codeType="way_type" runat="server" DefaultValue="0"
                                Index="1" IsRequrided="true"></dx:ComoboxCode>
                        </td>
                    </tr>
                    <tr>
                        <td class="editFormCaption">
                            发货人<span class="red">*</span>:
                        </td>
                        <td class="editFormCell">
                            <dx:CustomerLookUp ID="deliver_id" runat="server" CustomerEnum="Deliver" IsRequrided="true"
                                ClientSideJs="viewSetting1.glp_cust_ValueChanged" Index="1"></dx:CustomerLookUp>
                        </td>
                        <td class="editFormCaption">
                            联系电话<span class="red">*</span>:
                        </td>
                        <td class="editFormCell">
                            <cx:ASPxTextBox ID="deliver_mobile" runat="server" Width="170">
                            </cx:ASPxTextBox>
                        </td>
                        <td class="editFormCaption">
                            地区<span class="red">*</span>:
                        </td>
                        <td class="editFormCell">
                            <cx:ASPxTextBox ID="deliver_area" runat="server" Width="170">
                            </cx:ASPxTextBox>
                        </td>
                        <td class="editFormCaption">
                            地址:
                        </td>
                        <td class="editFormCell">
                            <cx:ASPxTextBox ID="deliver_address" runat="server" Width="170">
                            </cx:ASPxTextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="editFormCaption">
                            收货人<span class="red">*</span>:
                        </td>
                        <td class="editFormCell">
                            <dx:CustomerLookUp ID="consignee_id" runat="server" CustomerEnum="Consignee" IsRequrided="true"
                                ClientSideJs="viewSetting1.glp_cust_ValueChanged" Index="2"></dx:CustomerLookUp>
                        </td>
                        <td class="editFormCaption">
                            联系电话<span class="red">*</span>:
                        </td>
                        <td class="editFormCell">
                            <cx:ASPxTextBox ID="consignee_mobile" runat="server" Width="170">
                            </cx:ASPxTextBox>
                        </td>
                        <td class="editFormCaption">
                            地区<span class="red">*</span>:
                        </td>
                        <td class="editFormCell">
                            <cx:ASPxTextBox ID="consignee_area" runat="server" Width="170">
                            </cx:ASPxTextBox>
                        </td>
                        <td class="editFormCaption">
                            地址:
                        </td>
                        <td class="editFormCell">
                            <cx:ASPxTextBox ID="consignee_address" runat="server" Width="170">
                            </cx:ASPxTextBox>
                        </td>
                    </tr>
                </table>
                <div>
                    <dx:MainToolBar ID="MainToolBar1" runat="server" IsSubMenu="true"></dx:MainToolBar>
                    <cx:ASPxGridView ID="gridProduction" runat="server" ClientInstanceName="gridProduction"
                        KeyFieldName="id" >
                        <Columns>
                            <dx:GridViewDataTextColumn Caption="id" FieldName="id" Visible="false">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="货物名称" FieldName="production_name">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataComboBoxColumn Caption="包装方式" FieldName="package_type_name">
                            </dx:GridViewDataComboBoxColumn>
                            <dx:GridViewDataTextColumn Caption="件数" FieldName="production_number" Width="40">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="重量" FieldName="production_weight" Width="50">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="体积" FieldName="production_size" Width="50">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="计费方式" FieldName="charge_mode_name">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataSpinEditColumn PropertiesSpinEdit-DisplayFormatString="c" Caption="计费单价"
                                FieldName="freight_rates" Visible="false">
                            </dx:GridViewDataSpinEditColumn>
                            <dx:GridViewDataSpinEditColumn PropertiesSpinEdit-DisplayFormatString="c" Caption="保额"
                                FieldName="coverage">
                            </dx:GridViewDataSpinEditColumn>
                            <dx:GridViewDataSpinEditColumn PropertiesSpinEdit-DisplayFormatString="c" Caption="保费"
                                FieldName="premium">
                            </dx:GridViewDataSpinEditColumn>
                            <dx:GridViewDataSpinEditColumn PropertiesSpinEdit-DisplayFormatString="c" Caption="运费"
                                FieldName="freight">
                            </dx:GridViewDataSpinEditColumn>
                            <dx:GridViewDataSpinEditColumn PropertiesSpinEdit-DisplayFormatString="c" Caption="代收款"
                                FieldName="agency_fund">
                            </dx:GridViewDataSpinEditColumn>
                            <dx:GridViewDataSpinEditColumn PropertiesSpinEdit-DisplayFormatString="c" Caption="送货费"
                                FieldName="delivery_expense">
                            </dx:GridViewDataSpinEditColumn>
                            <dx:GridViewDataSpinEditColumn PropertiesSpinEdit-DisplayFormatString="c" Caption="其他费用"
                                FieldName="other_expenses">
                            </dx:GridViewDataSpinEditColumn>
                            <dx:GridViewDataSpinEditColumn PropertiesSpinEdit-DisplayFormatString="c" Caption="总费用"
                                FieldName="total_price">
                            </dx:GridViewDataSpinEditColumn>
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
                                            <cx:ASPxTextBox ID="production_name" runat="server" WidthPixel="80" IsSubRequired="true">
                                            </cx:ASPxTextBox>
                                        </td>
                                        <td class="editFormCaption">
                                            包装方式<span class="red">*</span>:
                                        </td>
                                        <td class="editFormCell">
                                            <dx:ComoboxCode ID="package_type" codeType="wrap_type" runat="server" Width="80"
                                                IsSubRequired="true"></dx:ComoboxCode>
                                        </td>
                                        <td class="editFormCaption">
                                            件数<span class="red">*</span>:
                                        </td>
                                        <td class="editFormCell">
                                            <cx:ASPxSpinEdit ID="production_number" runat="server" IsInteger="true" Width="80"
                                                IsSubRequired="true">
                                            </cx:ASPxSpinEdit>
                                        </td>
                                        <td class="editFormCaption">
                                            体重(Kg):
                                        </td>
                                        <td class="editFormCell">
                                            <cx:ASPxSpinEdit ID="production_weight" runat="server" Width="80">
                                            </cx:ASPxSpinEdit>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="editFormCaption">
                                            体积(m&sup3;):
                                        </td>
                                        <td class="editFormCell">
                                            <cx:ASPxSpinEdit ID="production_size" runat="server" Width="80">
                                            </cx:ASPxSpinEdit>
                                        </td>
                                        <td class="editFormCaption">
                                            计费方式:
                                        </td>
                                        <td class="editFormCell">
                                            <dx:ComoboxCode ID="charge_mode" codeType="price_type" runat="server" Width="80">
                                            </dx:ComoboxCode>
                                        </td>
                                        <td class="editFormCaption">
                                            计费单价:
                                        </td>
                                        <td class="editFormCell">
                                            <cx:ASPxTextBox ID="freight_rates" IsPrice="true" WidthPixel="80" runat="server">
                                            </cx:ASPxTextBox>
                                        </td>
                                        <td class="editFormCaption">
                                            运费:
                                        </td>
                                        <td class="editFormCell">
                                            <cx:ASPxTextBox ID="freight" runat="server" IsPrice="true" WidthPixel="80">
                                            </cx:ASPxTextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="editFormCaption">
                                            代收款:
                                        </td>
                                        <td class="editFormCell">
                                            <cx:ASPxTextBox ID="agency_fund" IsPrice="true" WidthPixel="80" runat="server">
                                            </cx:ASPxTextBox>
                                        </td>
                                        <td class="editFormCaption">
                                            保额:
                                        </td>
                                        <td class="editFormCell">
                                            <cx:ASPxTextBox ID="coverage" IsPrice="true" WidthPixel="80" runat="server">
                                            </cx:ASPxTextBox>
                                        </td>
                                        <td class="editFormCaption">
                                            保费:
                                        </td>
                                        <td class="editFormCell">
                                            <cx:ASPxTextBox ID="premium" IsPrice="true" WidthPixel="80" runat="server">
                                            </cx:ASPxTextBox>
                                        </td>
                                        <td class="editFormCaption">
                                            送货费:
                                        </td>
                                        <td class="editFormCell">
                                            <cx:ASPxTextBox ID="delivery_expense" IsPrice="true" WidthPixel="80" runat="server">
                                            </cx:ASPxTextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="editFormCaption">
                                            其他费:
                                        </td>
                                        <td class="editFormCell" colspan="7">
                                            <cx:ASPxTextBox ID="other_expenses" IsPrice="true" WidthPixel="80" runat="server">
                                            </cx:ASPxTextBox>
                                        </td>
                                    </tr>
                                </table>
                            </EditForm>
                        </Templates>
                        <Settings ShowFooter="True" />
                        <TotalSummary>
                            <dx:ASPxSummaryItem FieldName="total_price" SummaryType="Sum" DisplayFormat="总金额：￥{0}" />
                        </TotalSummary>
                        <SettingsBehavior AllowSelectByRowClick="true" AllowFocusedRow="true" ConfirmDelete="true"
                            AllowSort="false" />
                        <SettingsText PopupEditFormCaption="编辑货物信息" />
                       
                    </cx:ASPxGridView>
                </div>
                <table cellpadding="4" cellspacing="0" class="editTable">
                    <tr>
                        <td class="editFormCaption">
                            总金额:
                        </td>
                        <td class="editFormCell">
                            <cx:ASPxTextBox ID="aggregate_amount" IsPrice="true" runat="server" Width="80">
                            </cx:ASPxTextBox>
                        </td>
                        <td class="editFormCaption">
                            结算方式:
                        </td>
                        <td class="editFormCell">
                            <dx:ComoboxCode ID="clearing_type" codeType="settle_type" runat="server" Width="80"
                                Index="2"></dx:ComoboxCode>
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
                            <cx:ASPxTextBox ID="receipt_number" runat="server" WidthPixel="80">
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
                            <cx:ASPxTextBox ID="bill_rebate" IsPrice="true" runat="server" WidthPixel="80">
                            </cx:ASPxTextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="editFormCaption">
                            备注:
                        </td>
                        <td class="editFormCell" colspan="7">
                            <cx:ASPxTextBox ID="bill_memo" runat="server" WidthPixel="940">
                            </cx:ASPxTextBox>
                        </td>
                    </tr>
                </table>
            </EditForm>
        </Templates>
        <Settings ShowHorizontalScrollBar="true" />
        <SettingsText PopupEditFormCaption="编辑运单信息" />
        <SettingsEditing Mode="PopupEditForm" PopupEditFormWidth="750" PopupEditFormHeight="400"
            PopupEditFormVerticalOffset="-5" PopupEditFormHorizontalOffset="-500" />
        <Border BorderWidth="0" />
		 <SettingsPager AlwaysShowPager="true" Mode="ShowPager" PageSize="10" Position="TopAndBottom" />
        </dx:ASPxGridView>
    </form>

    <dx:ASPxGridViewExporter ID="ASPxGridViewExporter1" runat="server" GridViewID="ASPxGridView1" />
    

    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectCountMethod="GetDataCount"
        SelectMethod="GetData" TypeName="SpecialLogisticsSystem.AppPortal.UIHelpers.GridViewExport" EnablePaging="true"
        MaximumRowsParameterName="maxRows" StartRowIndexParameterName="startRow" OnSelecting="ObjectDataSource1_Selecting"></asp:ObjectDataSource>

		<asp:ObjectDataSource ID="wayDataSource" runat="server" TypeName="SpecialLogisticsSystem.AppPortal.UIHelpers.WayProvider"
        EnablePaging="True" MaximumRowsParameterName="maxRows" StartRowIndexParameterName="startRow"
        SortParameterName="sorter" SelectMethod="GetDataByPaging" SelectCountMethod="GetRowsCount"
        OnSelecting="wayDataSource_Selecting"></asp:ObjectDataSource>
</body>
</html>
