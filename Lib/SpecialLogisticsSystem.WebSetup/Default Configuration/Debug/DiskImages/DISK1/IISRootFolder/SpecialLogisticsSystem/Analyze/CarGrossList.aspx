<%@ Page Title="" Language="C#" MasterPageFile="~/MenuMaster.master" AutoEventWireup="true"
    CodeBehind="CarGrossList.aspx.cs" Inherits="SpecialLogisticsSystem.AppPortal.Analyze.CarGrossList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript">
        gridConfig.gridID = 'gridStowageProfile';
        function filterCondition() {
            return { stowage_number: txt_stowage_number.GetValue(), departure_time_begin: receive_date_start.GetValueString(), departure_time_end: receive_date_end.GetValueString() };
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SearchContent" runat="server">
    <ul id="viewSearch">
        <li class="caption">车次编号： </li>
        <li>
            <cx:ASPxTextBox ID="txt_stowage_number" runat="server" Width="140px">
            </cx:ASPxTextBox>
        </li>
        <li class="caption">发车日期： </li>
        <li>
            <ul>
                <dx:DateRange ID="date_range" runat="server"></dx:DateRange>
            </ul>
        </li>
    </ul>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <cx:ASPxGridView ID="gridStowageProfile" runat="server" DataSourceID="grossDataSource"
        DataSourceForceStandardPaging="true" KeyFieldName="id">
        <Columns>
            <dx:GridViewDataTextColumn Width="40" Caption="序号" ToolTip="序号" CellStyle-HorizontalAlign="Center"
                Settings-AllowSort="False" FixedStyle="Left">
                <DataItemTemplate>
                    <%# Container.VisibleIndex + 1%>
                </DataItemTemplate>
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="车次编号" FieldName="stowage_number">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="发车时间" FieldName="departure_time">
                <PropertiesTextEdit DisplayFormatString="yyyy/MM/dd" DisplayFormatInEditMode="True">
                </PropertiesTextEdit>
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="车牌" FieldName="car_no">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="司机" FieldName="link_name">
            </dx:GridViewDataTextColumn>
             <dx:GridViewDataSpinEditColumn Caption="应收客户" FieldName="total_payment" PropertiesSpinEdit-DisplayFormatString="c">
            </dx:GridViewDataSpinEditColumn>
			<dx:GridViewBandColumn Caption="支出" ToolTip="支出" CellStyle-HorizontalAlign="Center">
                <Columns>
                    <dx:GridViewDataSpinEditColumn FieldName="rebate_payment" Caption="客户回扣" ToolTip="客户回扣" PropertiesSpinEdit-DisplayFormatString="c" />
                    <dx:GridViewDataSpinEditColumn FieldName="deliver_payment" Caption="应付司机" ToolTip="应付司机" PropertiesSpinEdit-DisplayFormatString="c" />
					<dx:GridViewDataSpinEditColumn FieldName="unload_fee" Caption="卸货费" ToolTip="卸货费"
					PropertiesSpinEdit-DisplayFormatString="c" />
					<dx:GridViewDataSpinEditColumn FieldName="outside_fee" Caption="外请搬运" ToolTip="外请搬运" PropertiesSpinEdit-DisplayFormatString="c" />
					<dx:GridViewDataSpinEditColumn FieldName="transfer_bill" Caption="中转费" ToolTip="中转费" PropertiesSpinEdit-DisplayFormatString="c" />
                </Columns>
            </dx:GridViewBandColumn>
			<dx:GridViewDataSpinEditColumn Caption="发车利润" FieldName="gross" PropertiesSpinEdit-DisplayFormatString="c">
            </dx:GridViewDataSpinEditColumn>
        </Columns>
        <Border BorderWidth="0" />
        <ClientSideEvents EndCallback="viewSetting.grid_EndCallback" />
    </cx:ASPxGridView>
    <asp:ObjectDataSource ID="grossDataSource" runat="server" TypeName="SpecialLogisticsSystem.AppPortal.UIHelpers.StowageGrossProvider"
        EnablePaging="True" MaximumRowsParameterName="maxRows" StartRowIndexParameterName="startRow"
        SortParameterName="sorter" SelectMethod="GetDataByPaging" SelectCountMethod="GetRowsCount"
        OnSelecting="grossDataSource_Selecting"></asp:ObjectDataSource>
</asp:Content>
