<%@ Page Title="" Language="C#" MasterPageFile="~/MenuMaster.master" AutoEventWireup="true"
    CodeBehind="SequenceNumber.aspx.cs" Inherits="SpecialLogisticsSystem.AppPortal.Cm.SequenceNumber" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript">
        gridConfig.gridID = 'gridNumber';
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <cx:ASPxGridView ID="gridNumber" runat="server" OnHtmlEditFormCreated="gridNumber_HtmlEditFormCreated"
        OnRowUpdating="gridNumber_RowUpdating" KeyFieldName="id" RowRadio="true">
        <Columns>
            <dx:GridViewDataTextColumn Caption="id" FieldName="id"  Visible="false">
            </dx:GridViewDataTextColumn>
			<dx:GridViewDataTextColumn Caption="编号" FieldName="code" Visible="false">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="编号" FieldName="name">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="前缀" FieldName="prefix">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="日期类型" FieldName="date_type">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="中缀" FieldName="infix">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="自增流水号长度" FieldName="index_length">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="后缀" FieldName="suffix">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="当前最大日期值" FieldName="max_date">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="当前最大流水号值" FieldName="CurrentMaxValue">
            </dx:GridViewDataTextColumn>
        </Columns>
        <Templates>
            <EditForm>
                <dx:EditToolBar ID="EditToolBar1" runat="server"></dx:EditToolBar>
                <table cellpadding="4" cellspacing="0" class="editTable">
				   <tr>
                        <td class="editFormCaption">
                            格式说明：
                        </td>
                        <td class="editFormCell" colspan="3" style="color:red;">
                            生成出的格式为（前缀+日期+中缀+自增序号+后缀）
                        </td>
                    </tr>
                    <tr>
                        <td class="editFormCaption">
                            编号<span class="red">*</span>：
                        </td>
                        <td class="editFormCell">
                            <cx:ASPxTextBox ID="name" runat="server" Width="170px" IsReadOnly="true">
                            </cx:ASPxTextBox>
							<cx:ASPxTextBox ID="code" runat="server" Visible="false">
                            </cx:ASPxTextBox>
                        </td>
                        <td class="editFormCaption">
                            前缀：
                        </td>
                        <td class="editFormCell">
                            <cx:ASPxTextBox ID="prefix" runat="server" Width="170px">
                            </cx:ASPxTextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="editFormCaption">
                            日期类型：
                        </td>
                        <td class="editFormCell">
							<cx:ASPxTextBox ID="date_type" runat="server" Width="170px">
                            </cx:ASPxTextBox>
                        </td>
						<td class="editFormCaption">
                            中缀：
                        </td>
                        <td class="editFormCell">
                            <cx:ASPxTextBox ID="infix" runat="server" Width="170px">
                            </cx:ASPxTextBox>
                        </td>
                    </tr>
					<tr>
                        <td class="editFormCaption">
                            自增流水号长度：
                        </td>
                        <td class="editFormCell">
                             <cx:ASPxSpinEdit ID="index_length" runat="server"></cx:ASPxSpinEdit>
                        </td>
						 <td class="editFormCaption">
                            后缀：
                        </td>
                        <td class="editFormCell">
                             <cx:ASPxTextBox ID="suffix" runat="server"  Width="170px"></cx:ASPxTextBox>
                        </td>
                    </tr>
                </table>
            </EditForm>
        </Templates>
        <SettingsText PopupEditFormCaption="编辑编号设置" />
        <Border BorderWidth="0" />
        <ClientSideEvents EndCallback="viewSetting.grid_EndCallback" />
    </cx:ASPxGridView>
</asp:Content>
