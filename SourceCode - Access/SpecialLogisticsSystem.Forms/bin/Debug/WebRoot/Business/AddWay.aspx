<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="AddWay.aspx.cs" Inherits="SpecialLogisticsSystem.AppPortal.Business.AddWay" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="/Scripts/gridConfig.js" type="text/javascript"></script>
    <script type="text/javascript">
        gridConfig.gridSubID = 'gridProduction';
        gridConfig.popupID = 'pop_PrintConstruct';
        gridConfig.callBackID = 'cbk_input';
        //关联发货人，收货人
        var viewSetting1 = {
            glp_cust_ValueChanged: function (s, e) {
                var grid = s.GetGridView();
                grid.cp_cust_id = '';
                var index = grid.GetFocusedRowIndex();
                if (index != -1)
                    viewSetting1.glp_cust_bind(grid, index);
                else
                    viewSetting.glp_cust_clear();
            },
            glp_cust_bind: function (grid, index) {
                grid.GetRowValues(index, 'link_name;link_mobilephone;link_address;link_area;', function OnGetRowValues(values) {
                    if (grid.name.indexOf('1') > 0) {
                        deliver_mobile.SetText(values[1]);
                        deliver_address.SetText(values[2]);
                        deliver_area.SetText(values[3]);
                    }
                    else {
                        consignee_mobile.SetText(values[1]);
                        consignee_address.SetText(values[2]);
                        consignee_area.SetText(values[3]);
                    }
                });
            },
            grid_EndCallback: function (s, e) {
                gridProduction.SetHeight(100);
            },
			cbk_input_CallbackComplete: function (s, e) {
                var json = $.parseJSON(e.result);
                if (json.success) {
					$("#btn_print_construct_pin").attr('href', '/Reports/Test.aspx?id=' + json.id);
                    pop_PrintConstruct.Show();
                }
                else {
                    showMsg({ msg: json.msg });
                }
            },
			Search: function () {
				var filterCondition = { way_number: number.GetValue() }
				cbk_select.PerformCallback(String(filterCondition));
			}
        };
    </script>
    <script src="/Scripts/viewSetting.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <dx:ASPxCallback ID="cbk_input" runat="server" ClientInstanceName="cbk_input" OnCallback="cbk_input_Callback">
        <ClientSideEvents CallbackComplete="viewSetting1.cbk_input_CallbackComplete" />
    </dx:ASPxCallback>
	<dx:ASPxCallback ID="cbk_select" runat="server" ClientInstanceName="cbk_select" OnCallback="cbk_select_Callback">
    </dx:ASPxCallback>
    <dx:ASPxMenu runat="server" ID="saveMenu" RenderMode="Lightweight" ClientInstanceName="saveMenu"
        ItemAutoWidth="false" Width="100%" ShowAsToolbar="true">
        <Items>
            <dx:MenuItem Text="保存" Name="save_call" Image-SpriteProperties-CssClass="icon save" />
            <dx:MenuItem Text="新增" Name="add" Image-SpriteProperties-CssClass="icon add" />
            <dx:MenuItem Text="下达入库" Name="add" Image-SpriteProperties-CssClass="icon add" />
            <dx:MenuItem Text="反下达" Name="add" Image-SpriteProperties-CssClass="icon add" />
            <dx:MenuItem Text="打印运单" Name="print" Image-SpriteProperties-CssClass="icon print" />
            <dx:MenuItem Text="发短信" Name="message" Image-SpriteProperties-CssClass="icon message" />
            <dx:MenuItem Text="刷新" Name="refresh" Image-SpriteProperties-CssClass="icon refresh" />
            <dx:MenuItem Text="帮助" Name="help" Image-SpriteProperties-CssClass="icon help" />
            <dx:MenuItem Text="状态" Name="building">
                <Template>
                    <div class="last_menu">
                        状态：<dx:ASPxLabel ForeColor="Red" ClientInstanceName="lblStatue" runat="server" ID="lblStatue"
                            Text="新建" />
                    </div>
                </Template>
            </dx:MenuItem>
        </Items>
        <Border BorderWidth="0" />
        <ClientSideEvents ItemClick="viewSetting.viewMenu_ItemClick" />
    </dx:ASPxMenu>
        <table cellpadding="4" cellspacing="0" class="editTable">
            <tr>
                <td class="editFormCaption">
                    运单号<span class="red">*</span>:
                </td>
                <td class="editFormCell">
					<table>
					  <tr>
						<td>
							<dx:GeneralNumber ID="way_number" runat="server" CodeEnum="Way"></dx:GeneralNumber>
						</td>
						<td>
                   			<cx:ASPxButton ID="btnSearch" runat="server" EnableTheming="False" Text="查询" EnableDefaultAppearance="False" AllowFocus="False" AutoPostBack="False" Width="100%" CssPostfix="botton">
											<Image Url="../Scripts/themes/icons/search.png" Width="16px" Height="16px" />
											<ClientSideEvents Click="viewSetting1.Search" />
						   </cx:ASPxButton>
					    </td>
					  </tr>
				   </table>
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
            <dx:ASPxMenu runat="server" ID="save_Menu" RenderMode="Classic" ClientInstanceName="save_Menu"
                ItemAutoWidth="false" Width="100%" ShowAsToolbar="true">
                <Items>
                    <dx:MenuItem Text="新增" Name="add_sub" Image-SpriteProperties-CssClass="icon add" />
                    <dx:MenuItem Text="修改" Name="edit_sub" Image-SpriteProperties-CssClass="icon edit" />
                    <dx:MenuItem Text="删除" Name="delete_sub" Image-SpriteProperties-CssClass="icon delete" />
                </Items>
                <Border BorderWidth="0" />
                <ClientSideEvents ItemClick="viewSetting.viewMenu_ItemClick" />
            </dx:ASPxMenu>
            <cx:ASPxGridView ID="gridProduction" runat="server" ClientInstanceName="gridProduction"
                KeyFieldName="id" OnRowInserting="gridProduction_RowInserting" OnRowUpdating="gridProduction_RowUpdating"
                OnHtmlEditFormCreated="gridProduction_HtmlEditFormCreated" OnRowDeleting="gridProduction_RowDeleting"
                OnDataBinding="gridProduction_DataBinding">
                <Columns>
                    <dx:GridViewDataTextColumn Caption="id" FieldName="id" Visible="false">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="货物名称" FieldName="production_name">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataComboBoxColumn Caption="包装方式" FieldName="package_type_name">
                    </dx:GridViewDataComboBoxColumn>
                    <dx:GridViewDataTextColumn Caption="件数" FieldName="production_number">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="重量" FieldName="production_weight">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="体积" FieldName="production_size">
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
                        <dx:EditToolBar ID="EditToolBar2" runat="server" MenuTye="SubMenu"></dx:EditToolBar>
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
                <ClientSideEvents EndCallback="viewSetting1.grid_EndCallback" Init="viewSetting1.grid_EndCallback"/>
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
