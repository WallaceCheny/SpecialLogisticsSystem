<%@ Page Title="" Language="C#" MasterPageFile="~/MenuMaster.Master" AutoEventWireup="true"
    CodeBehind="Customer.aspx.cs" Inherits="SpecialLogisticsSystem.AppPortal.Cm.Customer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript">
        gridConfig.gridID = 'gridCustomer';
        gridConfig.gridSubID = 'gridConsignee';
		gridConfig.gridSubHeight =165;
		function filterCondition() {
            return { customer_name: txt_ClientName.GetText(), link_name: txt_LinkName.GetText()
			, link_mobilephone: txt_Mobile.GetText(), link_address: txt_Address.GetText() };
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SearchContent" runat="server">
    <ul id="viewSearch">
		<li class="caption">
		    客户名称：
		</li>
		<li>
			<cx:ASPxTextBox ID="txt_ClientName" runat="server" Width="120px">
            </cx:ASPxTextBox>
		</li>
		<li class="caption">
			联系人：
		</li>
		 <li>
			<cx:ASPxTextBox ID="txt_LinkName" runat="server" Width="120px">
            </cx:ASPxTextBox>
		 </li>
		 <li class="caption">
			手机：
		</li>
		 <li>
			<cx:ASPxTextBox ID="txt_Mobile" runat="server" Width="120px">
            </cx:ASPxTextBox>
		 </li>
		 <li class="caption">
			地址：
		</li>
		 <li>
			<cx:ASPxTextBox ID="txt_Address" runat="server" Width="120px">
            </cx:ASPxTextBox>
		 </li>
	</ul>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <cx:ASPxGridView ID="gridCustomer" runat="server" OnRowDeleting="gridCustomer_RowDeleting"  OnInitNewRow="gridCustomer_InitNewRow"
        OnRowInserting="gridCustomer_RowInserting" OnHtmlEditFormCreated="gridCustomer_HtmlEditFormCreated"
        OnRowUpdating="gridCustomer_RowUpdating" KeyFieldName="id" RowCheckBox="true" OnAfterPerformCallback="gridCustomer_AfterPerformCallback" >
        <Columns>
		    <dx:GridViewDataTextColumn Caption="link_id" FieldName="link_id" Visible="false">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="客户名称" FieldName="customer_name">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="信用等级" FieldName="credit_level_name">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="信用等级" FieldName="credit_level" Visible="false">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="联系人" FieldName="link_name">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="电话" FieldName="link_telephone">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="手机" FieldName="link_mobilephone">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="所在地区" FieldName="link_area">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="地址" FieldName="link_address">
            </dx:GridViewDataTextColumn>
			<dx:GridViewDataTextColumn Caption="创建日期" FieldName="create_date">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="所属业务员" FieldName="emp_id" Visible="false">
            </dx:GridViewDataTextColumn>
        </Columns>
        <Templates>
            <EditForm>
                <dx:EditToolBar ID="EditToolBar1" runat="server"></dx:EditToolBar>
                <table cellpadding="4" cellspacing="0" class="editTable">
                    <tr>
                        <td class="editFormCaption">
                            名称<span class="red">*</span>：
                        </td>
                        <td class="editFormCell">
                            <cx:ASPxTextBox ID="customer_name" runat="server" Width="170px" IsRequired="true">
                            </cx:ASPxTextBox>
                        </td>
                        <td class="editFormCaption">
                            信用等级：
                        </td>
                        <td class="editFormCell">
                            <dx:ComoboxCode ID="credit_level" codeType="customer_credit" runat="server"></dx:ComoboxCode>
                        </td>
                    </tr>
                    <dx:LinkMan ID="link_id" runat="server" Index="0" IsDefault="true"/>
                </table>
                <div class="gvw_header">
                    <span style="display: block; padding: 0px 0px 0px 10px; background-position: 5px;
                        text-align: center">收货方信息</span>
                </div>
                <div>
					<dx:MainToolBar ID="MainToolBar1" runat="server" IsSubMenu="true"></dx:MainToolBar>
                    <cx:ASPxGridView ID="gridConsignee" runat="server" ClientInstanceName="gridConsignee"
                        KeyFieldName="id"  RowCheckBox="true" OnRowInserting="gridConsignee_RowInserting"
                        OnRowUpdating="gridConsignee_RowUpdating" OnHtmlEditFormCreated="gridConsignee_HtmlEditFormCreated"
                        OnRowDeleting="gridConsignee_RowDeleting" OnDataBinding="gridConsignee_DataBinding">
                        <Columns>
                            <dx:GridViewDataTextColumn Caption="id" FieldName="id" Visible="false">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="联系人" FieldName="link.link_name">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="联系电话" FieldName="link.link_mobilephone" ToolTip="联系电话">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="所在地区" FieldName="link.link_area">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="详细地址" FieldName="link.link_address">
                            </dx:GridViewDataTextColumn>
                        </Columns>
                        <Templates>
                            <EditForm>
                                <dx:EditToolBar ID="EditToolBar2" runat="server"  MenuTye="SubMenu"></dx:EditToolBar>
								<table cellpadding="4" cellspacing="0" class="editTable">
									<dx:LinkMan ID="link_id" runat="server" IsSubRequired="true" Index="1" IsEndCity="true"/>
								</table>
                            </EditForm>
                        </Templates>
                        <Settings GridLines="Both" ShowVerticalScrollBar="true" />
                        <SettingsBehavior AllowSelectByRowClick="true" AllowFocusedRow="true" ConfirmDelete="true"
                            AllowSort="false" />
                        <SettingsText PopupEditFormCaption="编辑收货方信息" />
                        <SettingsPager Mode="ShowAllRecords" />
                        <Border BorderWidth="0" />
                    </cx:ASPxGridView>
                </div>
            </EditForm>
        </Templates>
        <SettingsText PopupEditFormCaption="编辑客户信息" />
        <SettingsEditing Mode="PopupEditForm" PopupEditFormWidth="620" PopupEditFormHeight="470"/>
        <Border BorderWidth="0" />
		<ClientSideEvents EndCallback="viewSetting.grid_EndCallback" />
    </cx:ASPxGridView>
</asp:Content>
