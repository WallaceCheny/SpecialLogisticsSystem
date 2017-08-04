<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="StowageList.ascx.cs"
    Inherits="SpecialLogisticsSystem.AppPortal.UserControls.StowageList" %>
<%@ Register Src="/UserControls/EditToolBar.ascx" TagName="EditToolBar" TagPrefix="uc1" %>
<script type="text/javascript">
    function filterInnerCondition() {
        return { stowage_statue: 'Sended' };
    }
    $(function () {
        viewSetting.SearchInner(filterInnerCondition());
    });
    function OnEndCallback(s, e) {
        AdjustSize();
    }
    function AdjustSize() {
        gridPopupStowageDetail.SetHeight(180);
        gridStowage.SetHeight(180);
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
<dx:ASPxPopupControl ID="PopupStowageList" runat="server" CloseAction="CloseButton"
    Width="780px" Height="380px" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter"
    ClientInstanceName="PopupStowageList" HeaderText="获取配载发车信息" AllowDragging="True"
    ScrollBars="Auto" EnableAnimation="False" EnableViewState="False">
    <ContentCollection>
        <dx:PopupControlContentControl>
            <uc1:EditToolBar ID="menu" runat="server" MenuTye="SelectedMenu"></uc1:EditToolBar>
            <cx:ASPxGridView ID="gridStowage" runat="server" EnableRowsCache="true" DataSourceID="stowageDataSource"
                DataSourceForceStandardPaging="true" KeyFieldName="id" ClientIDMode="Static"
                RowRadio="true">
                <Columns>
                    <dx:GridViewDataTextColumn Caption="id" FieldName="id" Visible="false">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="编号" FieldName="stowage_number" Width="80">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataComboBoxColumn FieldName="stowage_statue" Caption="状态" Width="60">
                        <PropertiesComboBox TextField="Description" ValueField="Name" EnableSynchronization="False"
                            DataSourceID="stowageStatueDataSource">
                        </PropertiesComboBox>
                    </dx:GridViewDataComboBoxColumn>
                    <dx:GridViewDataTextColumn Caption="发车时间" FieldName="departure_time" Width="80">
                        <PropertiesTextEdit DisplayFormatString="yyyy/MM/dd" DisplayFormatInEditMode="True">
                        </PropertiesTextEdit>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="车牌" FieldName="car_no">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="司机" FieldName="link_name" Width="50">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="随车电话" FieldName="link_mobilephone" Width="90">
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
