<%@ Page Title="" Language="C#" MasterPageFile="~/MenuMaster.master" AutoEventWireup="true"
    CodeBehind="FinanceList.aspx.cs" Inherits="SpecialLogisticsSystem.AppPortal.Analyze.FinanceList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript">
        gridConfig.gridID = 'gridFinance';
		function filterCondition() {
              return { settle_number: txt_settle_number.GetValue(), input_date_begin: receive_date_start.lastSuccessText, input_date_begin: receive_date_end.lastSuccessText};
        }
     </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SearchContent" runat="server">
 <ul id="viewSearch">
		<li  class="caption">
		    结算编号：
		</li>
		<li>
			<cx:ASPxTextBox ID="txt_settle_number" runat="server" Width="140px">
             </cx:ASPxTextBox>
		</li>
		<li  class="caption">
			结算日期：
		</li>
		 <li>
			 <ul>
			   <dx:DateRange ID="date_range"  runat="server"></dx:DateRange>
			</ul>
		 </li>
	</ul>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <cx:ASPxGridView ID="gridFinance" runat="server" DataSourceID="financeDataSource"
        DataSourceForceStandardPaging="true" KeyFieldName="id">
        <Columns>
            <dx:GridViewDataTextColumn Width="40" Caption="序号" ToolTip="序号" CellStyle-HorizontalAlign="Center"
                Settings-AllowSort="False" FixedStyle="Left">
                <DataItemTemplate>
                    <%# Container.VisibleIndex + 1%>
                </DataItemTemplate>
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="分支机构" FieldName="branch_id"  Visible="false">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="结算编号" FieldName="settle_number">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="科目" FieldName="category_type_name">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="收入" FieldName="input_money">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="支出" FieldName="output_money">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="结算方式" FieldName="settle_type_name">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="负责人" FieldName="emp_name">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="日期" FieldName="input_date">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="摘要" FieldName="remark">
            </dx:GridViewDataTextColumn>
        </Columns>
        <Border BorderWidth="0" />
        <ClientSideEvents EndCallback="viewSetting.grid_EndCallback" />
    </cx:ASPxGridView>
    <asp:ObjectDataSource ID="financeDataSource" runat="server" TypeName="SpecialLogisticsSystem.AppPortal.UIHelpers.FinanceAll"
        EnablePaging="True" MaximumRowsParameterName="maxRows" StartRowIndexParameterName="startRow"
        SortParameterName="sorter" SelectMethod="GetDataByPaging" SelectCountMethod="GetRowsCount"
        OnSelecting="financeDataSource_Selecting"></asp:ObjectDataSource>
</asp:Content>
