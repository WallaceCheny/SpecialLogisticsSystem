<%@ Page Title="" Language="C#" MasterPageFile="~/MenuMaster.Master" AutoEventWireup="true"
    CodeBehind="Transfer.aspx.cs" Inherits="SpecialLogisticsSystem.AppPortal.Business.Transfer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript">
        gridConfig.gridID = 'gridTransfer';
        gridConfig.gridSubID = 'gridTransferDetail';
        gridConfig.popupID = 'pop_PrintConstruct';
		gridConfig.popuSelectedTypeName="Transfer";
		gridConfig.gridSubHeight =200;
        //关联运单
        var viewSetting1 = {
            glp_service_ValueChanged: function (s, e) {
                var grid = s.GetGridView();
                var index = grid.GetFocusedRowIndex();
                if (index != -1)
                    viewSetting1.glp_bind(grid, index);

            },
            glp_bind: function (grid, index) {
                grid.GetRowValues(index, 'link_name;link_mobilephone;link_address;name', function OnGetRowValues(values) {
                    link_name.SetText(values[0]);
					link_mobilephone.SetText(values[1]);
					get_address.SetText(values[2]);
					service_name.SetText(values[3]);
                });
            },
            grid_EndCallback: function (s, e) {

            },
			textChange: function (s,e) {
				gridTransferDetail.PerformCallback('Update');
			}
        };
        function filterCondition() {
            return { way_number: txt_way_number.GetValue(), receive_date_start: receive_date_start.GetValue(), receive_date_end: receive_date_end.GetValue() };
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SearchContent" runat="server">
    <ul id="viewSearch">
        <li class="caption">发车号： </li>
        <li>
            <cx:ASPxTextBox ID="txt_way_number" runat="server" Width="140px">
            </cx:ASPxTextBox>
        </li>
        <li class="caption">发车日期： </li>
        <li>
             <dx:DateRange ID="date_range"  runat="server"></dx:DateRange>
        </li>
    </ul>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <cx:ASPxGridView ID="gridTransfer" runat="server" OnRowDeleting="gridTransfer_RowDeleting"
        OnRowInserting="gridTransfer_RowInserting" OnHtmlEditFormCreated="gridTransfer_HtmlEditFormCreated"
        EnableRowsCache="true" DataSourceID="transferDataSource" DataSourceForceStandardPaging="true"
        OnRowUpdating="gridTransfer_RowUpdating" KeyFieldName="id" RowCheckBox="true" OnInitNewRow="gridTransfer_InitNewRow">
        <Columns>
            <dx:gridviewdatatextcolumn width="40" caption="序号" tooltip="序号" cellstyle-horizontalalign="Center"
                settings-allowsort="False" fixedstyle="Left">
                <DataItemTemplate>
                    <%# Container.VisibleIndex + 1%></DataItemTemplate>
            </dx:gridviewdatatextcolumn>
            <dx:gridviewdatatextcolumn caption="id" fieldname="id" visible="false">
            </dx:gridviewdatatextcolumn>
            <dx:gridviewdatatextcolumn caption="中转批次" fieldname="transfer_number">
            </dx:gridviewdatatextcolumn>
            <dx:gridviewdatatextcolumn caption="中转日期" fieldname="transfer_date">
				<PropertiesTextEdit DisplayFormatString="yyyy/MM/dd" DisplayFormatInEditMode="True">
                </PropertiesTextEdit>
            </dx:gridviewdatatextcolumn>
			<dx:gridviewdatacomboboxcolumn fieldname="transfer_statue" caption="状态" width="80">
                <PropertiesComboBox TextField="Description" ValueField="Name" EnableSynchronization="False"
                    DataSourceID="transferStatueDataSource">
                </PropertiesComboBox>
            </dx:gridviewdatacomboboxcolumn>
            <dx:gridviewdatatextcolumn caption="服务商" fieldname="service_name">
            </dx:gridviewdatatextcolumn>
                        <dx:gridviewdatatextcolumn caption="提货地址" fieldname="get_address">
            </dx:gridviewdatatextcolumn>
            <dx:gridviewdatatextcolumn caption="联系人" fieldname="link_name">
            </dx:gridviewdatatextcolumn>
            <dx:gridviewdatatextcolumn caption="联系电话" fieldname="link_mobilephone">
            </dx:gridviewdatatextcolumn>
            <dx:gridviewdatatextcolumn caption="结算方式" fieldname="settle_type_name">
            </dx:gridviewdatatextcolumn>
            <dx:gridviewdatatextcolumn caption="交接方式" fieldname="connect_type_name">
            </dx:gridviewdatatextcolumn>
            <dx:gridviewdatatextcolumn caption="配载方式" fieldname="go_type_name">
            </dx:gridviewdatatextcolumn>
            <dx:gridviewdatatextcolumn caption="经办人" fieldname="transfer_operator_name">
            </dx:gridviewdatatextcolumn>
            <dx:gridviewdatatextcolumn caption="备注" fieldname="transfer_memo">
            </dx:gridviewdatatextcolumn>
        </Columns>
        <SettingsDetail ShowDetailRow="true" />
        <Templates>
            <DetailRow>
                <dx:aspxgridview id="gridTransferDetail" runat="server" clientinstancename="gridTransferDetail"
                    autogeneratecolumns="False" width="100%" keyfieldname="id" onload="gridTransferDetail_Load">
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
                        <dx:GridViewDataTextColumn Caption="服务商单号" FieldName="service_no">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="中转费" FieldName="transfer_bill">
                        </dx:GridViewDataTextColumn>
                    </Columns>
                    <Settings GridLines="Both" ShowVerticalScrollBar="false" ShowFooter="true" />
                    <SettingsBehavior AllowSelectByRowClick="true" AllowFocusedRow="false" ConfirmDelete="true"
                        AllowSort="false" />
                    <SettingsText EmptyDataRow="无数据" />
                    <SettingsPager Mode="ShowAllRecords" />
                    <Border BorderWidth="0" />
                </dx:aspxgridview>
            </DetailRow>
            <EditForm>
                <dx:edittoolbar id="EditToolBar1" runat="server"></dx:edittoolbar>
                <table cellpadding="4" cellspacing="0" class="editTable1">
                    <tr>
                        <td class="editFormCaption">
                            中转号<span class="red">*</span>:
                        </td>
                        <td class="editFormCell">
                            <dx:generalnumber id="transfer_number" runat="server" codeenum="Transfer" width="120">
                            </dx:generalnumber>
                        </td>
                        <td class="editFormTh" colspan="4">
                            中转外包
                        </td>
                        <td class="editFormCaption">
                            中转时间<span class="red">*</span>:
                        </td>
                        <td class="editFormCell">
                            <cx:ASPxDateEdit ID="transfer_date" DefaultToday="true" runat="server" width="120"
                                IsRequired="true">
                            </cx:ASPxDateEdit>
                        </td>
                    </tr>
                    <tr>
                        <td class="editFormCaption">
                            服务商查询<span class="red">*</span>:
                        </td>
                        <td class="editFormCell">
                            <dx:servicerlookup id="service_id" runat="server" index="1" width="120" ClientSideJs="viewSetting1.glp_service_ValueChanged"></dx:servicerlookup>
                        </td>
						<td class="editFormCaption">
                            服务商<span class="red">*</span>:
                        </td>
                        <td class="editFormCell">
                            <cx:ASPxTextBox ID="service_name" runat="server" Width="120" IsRequired="true">
                            </cx:ASPxTextBox>
                        </td>
                        <td class="editFormCaption">
                            提货地址:
                        </td>
                        <td class="editFormCell">
                            <cx:ASPxTextBox ID="get_address" runat="server" Width="120">
                            </cx:ASPxTextBox>
                        </td>
                        <td class="editFormCaption">
                            联系人<span class="red">*</span>:
                        </td>
                        <td class="editFormCell">
                            <cx:ASPxTextBox ID="link_name" runat="server" Width="120" IsRequired="true">
                            </cx:ASPxTextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="editFormCaption">
                            联系电话<span class="red">*</span>:
                        </td>
                        <td class="editFormCell">
                            <cx:ASPxTextBox ID="link_mobilephone" runat="server" Width="120" IsRequired="true">
                            </cx:ASPxTextBox>
                        </td>
                        <td class="editFormCaption">
                            配载方式<span class="red">*</span>:
                        </td>
                        <td class="editFormCell">
                            <dx:comoboxcode id="go_type" codetype="carriage_type" runat="server" width="120" index="3">
                            </dx:comoboxcode>
                        </td>
                        <td class="editFormCaption">
                            结算方式:
                        </td>
                        <td class="editFormCell">
                            <dx:comoboxcode id="settle_type" codetype="settle_type" runat="server" width="120"
                                index="2"></dx:comoboxcode>
                        </td>
						<td class="editFormCaption">
                            交接方式:
                        </td>
                        <td class="editFormCell">
                            <dx:comoboxcode id="connect_type" codetype="connect_type" runat="server" width="120"
                                index="1"></dx:comoboxcode>
                        </td>
                    </tr>
                    <tr>
                        <td class="editFormCaption">
                            经办人<span class="red">*</span>:
                        </td>
                        <td class="editFormCell" colspan="7">
                            <dx:employeelookup id="transfer_operator" runat="server" width="120" IsSetDefault="true"></dx:employeelookup>
                        </td>
                    </tr>
					<tr>
                        <td class="editFormCaption">
                            备注:
                        </td>
                        <td class="editFormCell" colspan="7">
                            <cx:ASPxMemo ID="transfer_memo" runat="server" Height="100%" Width="100%">
                            </cx:ASPxMemo>
                        </td>
                    </tr>
                </table>
                <div>
                    <dx:MainToolBar ID="MainToolBar1" runat="server" PageToolBar="SelectedMenu"></dx:MainToolBar>
                    <cx:ASPxGridView ID="gridTransferDetail" runat="server" ClientInstanceName="gridTransferDetail"
                        KeyFieldName="id" DataSourceID="transferDetailDataSource" OnCustomCallback="gridTransferDetail_CustomCallback"
						OnHtmlRowCreated="gridTransferDetail_HtmlRowCreated">
                        <Columns>
						    <dx:GridViewCommandColumn VisibleIndex="0" ButtonType="Image" Caption="操作" HeaderStyle-HorizontalAlign="Center"  width="50">
                                <DeleteButton Visible="True" Text="删除">
									<Image Height="16px" ToolTip="删除" Url="~/Images/commad/delete_16x.ico" Width="16px">
									</Image>
								</DeleteButton>
                            </dx:GridViewCommandColumn>
                            <dx:gridviewdatatextcolumn caption="id" fieldname="id" visible="false">
                            </dx:gridviewdatatextcolumn>
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
                            <dx:gridviewdatatextcolumn caption="服务商单号" fieldname="service_no">
							     <DataItemTemplate>
                                      <cx:ASPxTextBox  ID="txtServiceNo" runat="server" Width="60" TextChangedJS="viewSetting1.textChange"/>
                                      </cx:ASPxTextBox>
                                  </DataItemTemplate>
                            </dx:gridviewdatatextcolumn>
                            <dx:gridviewdatatextcolumn caption="中转费" fieldname="transfer_bill">
							       <DataItemTemplate>
                                      <cx:ASPxTextBox  ID="txtTransferBill" IsPrice="true" runat="server" Width="50" TextChangedJS="viewSetting1.textChange"/>
                                      </cx:ASPxTextBox>
                                  </DataItemTemplate>
                            </dx:gridviewdatatextcolumn>
                        </Columns>
                        <Templates>
                            <EditForm>
                                <dx:edittoolbar id="EditToolBar2" runat="server" menutye="SubMenu"></dx:edittoolbar>
                                <table cellpadding="4" cellspacing="0" class="editTable">
                                    <tr>
                                        <td class="editFormCaption">
                                            货物名称<span class="red">*</span>:
                                        </td>
                                        <td class="editFormCell">
                                            <dx:productionlookup id="production_id" runat="server" index="1" isrequrided="true"
                                                waytype="Transfer"></dx:productionlookup>
                                        </td>
                                        <td class="editFormCaption">
                                            服务商单号:
                                        </td>
                                        <td class="editFormCell">
                                            <cx:ASPxTextBox ID="service_no" runat="server" Width="80">
                                            </cx:ASPxTextBox>
                                        </td>
                                        <td class="editFormCaption">
                                            中转费:
                                        </td>
                                        <td class="editFormCell">
                                            <cx:ASPxTextBox ID="transfer_bill" IsPrice="true" runat="server" Width="80">
                                            </cx:ASPxTextBox>
                                        </td>
                                    </tr>
                                </table>
                            </EditForm>
                        </Templates>
                        <SettingsBehavior AllowSelectByRowClick="true" AllowFocusedRow="true" ConfirmDelete="true"
                            AllowSort="false" />
						 <Border BorderWidth="0" />
						 <ClientSideEvents EndCallback="viewSetting.gridSub_EndCallback" Init="viewSetting.gridSub_EndCallback" />
						 <SettingsText Title="系统提示" EmptyDataRow="无数据" PopupEditFormCaption="编辑" ConfirmDelete="确定删除本行记录吗 ？" />
                    </cx:ASPxGridView>
                </div>
            </EditForm>
        </Templates>
        <SettingsText PopupEditFormCaption="编辑中转信息" />
        <SettingsEditing Mode="PopupEditForm" PopupEditFormWidth="750" PopupEditFormHeight="400" />
        <Border BorderWidth="0" />
        <ClientSideEvents EndCallback="viewSetting.grid_EndCallback" />
    </cx:ASPxGridView>
	<asp:ObjectDataSource ID="transferDetailDataSource" runat="server" SelectMethod="GetList"      TypeName="SpecialLogisticsSystem.AppPortal.UIHelpers.TransferDetailTemporary" UpdateMethod="Update" InsertMethod="Insert" DeleteMethod="Delete" ></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="transferDataSource" runat="server" TypeName="SpecialLogisticsSystem.AppPortal.UIHelpers.TransferProvider"
        EnablePaging="True" MaximumRowsParameterName="maxRows" StartRowIndexParameterName="startRow"
        SortParameterName="sorter" SelectMethod="GetDataByPaging" SelectCountMethod="GetRowsCount"
        OnSelecting="transferDataSource_Selecting"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="transferStatueDataSource" runat="server" TypeName="SpecialLogisticsSystem.AppPortal.UIHelpers.EnumProvider"
        SelectMethod="GetWayStatueData"></asp:ObjectDataSource>
	<dx:ProductionList ID="productionList" runat="server" ClosingJs="function(s,e){gridTransferDetail.Refresh();}" Statue="New,Storage" WayType="1"></dx:ProductionList>
    <dx:aspxpopupcontrol id="pop_PrintConstruct" clientinstancename="pop_PrintConstruct"
        runat="server" closeaction="CloseButton" headertext=" " allowdragging="true"
        enableanimation="false" modal="true" enableviewstate="false" width="260px" popuphorizontalalign="WindowCenter"
        popupverticalalign="WindowCenter" popupverticaloffset="-75" popuphorizontaloffset="-85">
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
    </dx:aspxpopupcontrol>
</asp:Content>
