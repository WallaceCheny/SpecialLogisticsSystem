<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProductionList.ascx.cs"
    Inherits="SpecialLogisticsSystem.AppPortal.UserControls.ProductionList" %>
<%@ Register Src="/UserControls/EditToolBar.ascx" TagName="EditToolBar" TagPrefix="uc1" %>
<script type="text/javascript">
    function filterInnerCondition() {
        return { way_number: txt_way_number.GetValue(), bill_statue: $('#hideStatue').val(), way_type: $('#hideType').val(), is_hide: 0 };
    }
</script>
<asp:HiddenField ID="hideStatue" runat="server" />
<asp:HiddenField ID="hideType" runat="server" />
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
                        <table>
                            <tr>
                                <td>
                                    <ul id="viewSearch">
                                        <li class="caption">运单号： </li>
                                        <li>
                                            <cx:ASPxTextBox ID="txt_way_number" runat="server" Width="140px">
                                            </cx:ASPxTextBox>
                                        </li>
                                    </ul>
                                </td>
                                <td>
                                    <cx:ASPxButton ID="btnInnerSearch" runat="server" IsSearch="true" JsSearch="function() { viewSetting.SearchInner(filterInnerCondition()); }">
                                    </cx:ASPxButton>
                                </td>
                            </tr>
                        </table>
                        <cx:ASPxGridView ID="gridWayTemp" runat="server" DataSourceID="wayDataSource" DataSourceForceStandardPaging="true"
                            KeyFieldName="id" RowCheckBox="true">
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
                                    Width="100">
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
				<dx:GridViewDataTextColumn Caption="货物名称" FieldName="production_name" Width="80">
				</dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="备注" FieldName="bill_memo">
                                </dx:GridViewDataTextColumn>
                            </Columns>
                            <Border BorderWidth="0" />
                        </cx:ASPxGridView>
                    </dx:PanelContent>
                </PanelCollection>
            </dx:ASPxCallbackPanel>
        </dx:PopupControlContentControl>
    </ContentCollection>
    <ContentStyle Paddings-Padding="0" />
    <ClientSideEvents CloseButtonClick="function(s, e) { PopupProductList.Hide(); }" />
</dx:ASPxPopupControl>
<asp:ObjectDataSource ID="wayDataSource" runat="server" TypeName="SpecialLogisticsSystem.AppPortal.UIHelpers.WayProvider"
    EnablePaging="True" MaximumRowsParameterName="maxRows" StartRowIndexParameterName="startRow"
    SortParameterName="sorter" SelectMethod="GetDataByPaging" SelectCountMethod="GetRowsCount"
    OnSelecting="wayDataSource_Selecting"></asp:ObjectDataSource>
<asp:ObjectDataSource ID="billStatueDataSource" runat="server" TypeName="SpecialLogisticsSystem.AppPortal.UIHelpers.EnumProvider"
    SelectMethod="GetWayStatueData"></asp:ObjectDataSource>
