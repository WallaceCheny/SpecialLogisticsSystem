<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProductionListByCar.ascx.cs"
    Inherits="SpecialLogisticsSystem.AppPortal.UserControls.ProductionListByCar" %>
<%@ Register Src="/UserControls/EditToolBar.ascx" TagName="EditToolBar" TagPrefix="uc1" %>
<script type="text/javascript">
    function filterInnerCondition() {
        return { stowage_statue: 'Sended' };
    }
    $(function () {
        viewSetting.SearchInner(filterInnerCondition());
    });
    var viewSetting_PurchSelect = {
        viewSplitter_PaneResized: function (s, e) {
            if (e.pane.name === "GridPane") {
                //ASPxPageControl1.SetHeight(e.pane.GetClientHeight() - viewMenu.GetMainElement().offsetHeight - $('#viewSearch').height());
                //e.pane.SetSize($('#viewSearch').height() + viewMenu.GetMainElement().offsetHeight + 30);
                //alert($('#viewSearch').height() + viewMenu.GetMainElement().offsetHeight + 30);
            } else if (e.pane.name == "GridBottomPane") {
                gridStock.SetWidth(e.pane.GetClientWidth());
            }
            AdjustSize();
        },
        gridStock_EndCallback: function (s, e) {
            viewSplitter.GetPaneByName("GridBottomPane").RaiseResizedEvent();

        },
        viewMenu_ItemClick: function (s, e) {
            var name = e.item.name;
            switch (name) {
                case 'addin': pop_storage_in.Show(); break;
                case 'addout': pop_storage_out.Show(); break;
                case 'edit': var index = gridStock.GetFocusedRowIndex();
                    /*popuEditStockManager.SetContentUrl("StockManagerPro.aspx?manager=edit&mid=" + index);*/
                    if (index != -1) {
                        showEdit(index);
                    } else {
                        alert("请选择一条记录");
                    }
                    break;
                //case 'save': gridStock.UpdateEdit(); break;     
                case 'delete':
                    if (gridStock.GetSelectedRowCount() > 0) {
                        gridStock.GetSelectedFieldValues("statusvalue", delete_Callback);
                        //showConfirm({ msg: '确定删除选中的记录吗?', callback: function () { gridStock.PerformCallback('Delete'); showMsg({ msg: '删除成功' }); } });
                    }
                    else showMsg({ msg: '请选择要删除的记录' });
                    break;
                case 'save': gridStock.UpdateEdit(); break;
                case 'cancel': gridStock.CancelEdit(); break;
                case 'refresh': location.href = "StoreManageList.aspx";
            }
        },
        Search: function () {
            search();

        }
    }
    function search() {
        var filterCondition = new Array();
        if (txt_name.GetValue())
            filterCondition.push(" id in (select stock_manage_id from T_Stock_Manage_Detail left join T_Prd_Info on T_Prd_Info.id = T_Stock_Manage_Detail.prd_id "
                        + "where T_Prd_Info.name like '%" + txt_name.GetValue() + "%' "
                        + "or T_Prd_Info.short_name like '%" + txt_name.GetValue() + "%' "
                        + "or T_Prd_Info.bar_code like '%" + txt_name.GetValue() + "%'  )");
        if (cbb_supplier_cd.GetValue() && cbb_supplier_cd.GetValue() != "")
            filterCondition.push(" [zh_id]='" + cbb_supplier_cd.GetValue() + "'");
        if (dteFrom.GetValue())
            filterCondition.push(" [insert_time] >= '" + dteFrom.GetText() + " 00:00:00'");
        if (dteEnd.GetValue())
            filterCondition.push(" [insert_time] <= '" + dteEnd.GetText() + " 23:59:59'");
        if (cbb_manager_type_cd.GetValue() && cbb_manager_type_cd.GetValue() != "")
            filterCondition.push(" [stock_manage_cd]='" + cbb_manager_type_cd.GetValue() + "'");
        if (cbb_shop_id.GetValue()) {
            var shop = cbb_shop_id.GetValue();
            if (cbb_shop_id.GetValue().indexOf(',') > 0) {
                shop = cbb_shop_id.GetValue().replaceAll(",", "','")
            }
            filterCondition.push(" [shop_id] in ('" + shop + "') ");
        }
        gridStock.ApplyFilter(filterCondition.join(' and '));
    }
    function OnEndCallback(s, e) {
        AdjustSize();
    }
    function AdjustSize() {
        gridPopupStowageDetail.SetHeight(180);
        gridStowage.SetHeight(180);
    }
    function InsertIntoTempStock(s, e) {
        var selectRowCount = gridPopupStowageDetail.GetSelectedRowCount();
        if (selectRowCount > 0) {
            gridPopupStowageDetail.GetSelectedFieldValues("Idstr", InsertIntoTempStock_CustomCallBack);
            gridPopupStowageDetail.UnselectRows();
        } else {
            alert("请选择需要退货的产品");
        }
    }

    function InsertIntoTempStock_CustomCallBack(result) {
        var locationurl = document.location.href;
        //InsertPrdIntoTempStock(locationurl, result, Insert_EndCallBack);
        InsertSuppReturnTempStock(locationurl, result, Insert_EndCallBack);
    }

    function Insert_EndCallBack(res) {
        alert(res.IsSuccessfully);
        if (PopupProductList) {
            cleanFilter();
            gridPopupStowageDetail.UnselectAllRowsOnPage();
            gridPopupStowageDetail.Search();
            PopupProductList.Hide();
        } else {
            alert("异常操作");
        }
    }
    function mainRowClick(s, e) {
        s.GetRowValues(e.visibleIndex, 'id', function OnGetRowValues(values) {
            gridPopupStowageDetail.PerformCallback(values);
        });
    }
</script>
<asp:HiddenField ID="hideStatue" runat="server" />
<dx:ASPxPopupControl ID="PopupProductList" runat="server" CloseAction="CloseButton"
    Width="780px" Height="380px" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter"
    ClientInstanceName="PopupProductList" HeaderText="获取运单信息" AllowDragging="True"
    ScrollBars="Auto" EnableAnimation="False" EnableViewState="False">
    <ContentCollection>
        <dx:PopupControlContentControl>
            <dx:ASPxCallbackPanel ID="ProductListPopCallBack" runat="server" ClientInstanceName="ProductListPopCallBack">
                <PanelCollection>
                    <dx:PanelContent>
                        <uc1:EditToolBar ID="menu" runat="server" MenuTye="SelectedMenu"></uc1:EditToolBar>
                        <dx:ASPxSplitter ID="productionSplitter" runat="server" FullscreenMode="True" Width="100%"
                            Height="100%" Orientation="Vertical" ClientInstanceName="productionSplitter">
                            <Panes>
                                <dx:SplitterPane Size="130px" Name="GridPane" PaneStyle-Paddings-Padding="0" PaneStyle-Border-BorderWidth="0">
                                    <ContentCollection>
                                        <dx:SplitterContentControl ID="SplitterContentControl1" runat="server">
                                            <cx:ASPxGridView ID="gridStowage" runat="server" EnableRowsCache="true" DataSourceID="stowageDataSource"
                                                DataSourceForceStandardPaging="true" KeyFieldName="id" ClientIDMode="Static"
                                                RowRadio="true">
                                                <Columns>
                                                    <dx:GridViewDataTextColumn Caption="id" FieldName="id" Visible="false">
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn Caption="编号" FieldName="stowage_number"  Width="80">
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataComboBoxColumn FieldName="stowage_statue" Caption="状态" Width="60">
                                                        <PropertiesComboBox TextField="Description" ValueField="Name" EnableSynchronization="False"
                                                            DataSourceID="stowageStatueDataSource">
                                                        </PropertiesComboBox>
                                                    </dx:GridViewDataComboBoxColumn>
                                                    <dx:GridViewDataTextColumn Caption="发车时间" FieldName="departure_time"  Width="80">
                                                        <PropertiesTextEdit DisplayFormatString="yyyy/MM/dd" DisplayFormatInEditMode="True">
                                                        </PropertiesTextEdit>
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn Caption="车牌" FieldName="car_no">
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn Caption="司机" FieldName="link_name"  Width="50">
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn Caption="随车电话" FieldName="link_mobilephone"  Width="90">
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn Caption="预付" FieldName="prepay">
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn Caption="回付" FieldName="back_payment">
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn Caption="配载人员" FieldName="emp_name">
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn Caption="备注" FieldName="main_memo">
                                                    </dx:GridViewDataTextColumn>
                                                </Columns>
                                                <Border BorderWidth="0" />
                                                <ClientSideEvents RowClick="mainRowClick" EndCallback="OnEndCallback" />
                                            </cx:ASPxGridView>
                                        </dx:SplitterContentControl>
                                    </ContentCollection>
                                </dx:SplitterPane>
                                <dx:SplitterPane Size="190px" Name="GridButtonPane" PaneStyle-Paddings-Padding="0"
                                    PaneStyle-Border-BorderWidth="0">
                                    <ContentCollection>
                                        <dx:SplitterContentControl ID="SplitterContentControl2" runat="server">
                                            <cx:ASPxGridView ID="gridPopupStowageDetail" runat="server" ClientInstanceName="gridPopupStowageDetail"
                                                AutoGenerateColumns="False" Width="100%" KeyFieldName="id" RowCheckBox="true"
                                                OnCustomCallback="gridWayDetail_CustomCallback" IsPage="false">
                                                <Columns>
                                                    <dx:GridViewDataTextColumn Width="40" Caption="序号" ToolTip="序号" CellStyle-HorizontalAlign="Center"
                                                        Settings-AllowSort="False" FixedStyle="Left">
                                                        <DataItemTemplate>
                                                            <%# Container.VisibleIndex + 1%>
                                                        </DataItemTemplate>
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn Caption="id" FieldName="id" Visible="false">
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn Caption="接单日期" FieldName="receive_date" FixedStyle="Left">
                                                        <PropertiesTextEdit DisplayFormatString="yyyy/MM/dd" DisplayFormatInEditMode="True">
                                                        </PropertiesTextEdit>
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn Caption="运单号" FieldName="way_number" FixedStyle="Left"
                                                        Width="85">
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataComboBoxColumn FieldName="bill_statue" Caption="状态">
                                                        <PropertiesComboBox TextField="Description" ValueField="Name" EnableSynchronization="False"
                                                            DataSourceID="billStatueDataSource">
                                                        </PropertiesComboBox>
                                                    </dx:GridViewDataComboBoxColumn>
                                                    <dx:GridViewDataTextColumn Caption="起运地" FieldName="start_city">
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn Caption="目的地" FieldName="end_city">
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn Caption="发货人" FieldName="deliver_name">
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn Caption="收货人" FieldName="consignee_name">
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn Caption="备注" FieldName="bill_memo">
                                                    </dx:GridViewDataTextColumn>
                                                </Columns>
                                                <Settings GridLines="Both" ShowVerticalScrollBar="false" ShowFooter="true" />
                                                <SettingsBehavior AllowSelectByRowClick="true" AllowFocusedRow="false" ConfirmDelete="true"
                                                    AllowSort="false" />
                                                <SettingsText EmptyDataRow="无数据" />
                                                <SettingsPager Mode="ShowAllRecords" />
                                                <Border BorderWidth="0" />
                                            </cx:ASPxGridView>
                                        </dx:SplitterContentControl>
                                    </ContentCollection>
                                </dx:SplitterPane>
                            </Panes>
                            <ClientSideEvents PaneResized="viewSetting_PurchSelect.viewSplitter_PaneResized" />
                        </dx:ASPxSplitter>
                    </dx:PanelContent>
                </PanelCollection>
            </dx:ASPxCallbackPanel>
        </dx:PopupControlContentControl>
    </ContentCollection>
    <ContentStyle Paddings-Padding="0" />
    <ClientSideEvents CloseButtonClick="function(s, e) { PopupProductList.Hide(); }" />
</dx:ASPxPopupControl>
<asp:ObjectDataSource ID="stowageStatueDataSource" runat="server" TypeName="SpecialLogisticsSystem.AppPortal.UIHelpers.EnumProvider"
    SelectMethod="GetStowageStatueData"></asp:ObjectDataSource>
<asp:ObjectDataSource ID="stowageDataSource" runat="server" TypeName="SpecialLogisticsSystem.AppPortal.UIHelpers.StowageProvider"
    EnablePaging="True" MaximumRowsParameterName="maxRows" StartRowIndexParameterName="startRow"
    SortParameterName="sorter" SelectMethod="GetDataByPaging" SelectCountMethod="GetRowsCount"
    OnSelecting="stowageDataSource_Selecting"></asp:ObjectDataSource>
