<%@ Page Title="" Language="C#" MasterPageFile="~/MenuMaster.Master" AutoEventWireup="true"
    CodeBehind="User.aspx.cs" Inherits="SpecialLogisticsSystem.AppPortal.Cm.User" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript">
        gridConfig.gridID = 'gridUser';
        gridConfig.gridSubID = 'gridShowBranch';
		gridConfig.gridSubHeight =120;
			function filterCondition() {
                return { user_name: txt_user_name.GetValue(), branch_id: cbb_branch_id.GetValue() };
            }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SearchContent" runat="server">
    <ul id="viewSearch">
		<li class="caption">
		     用户名：
		</li>
		<li>
			  <cx:ASPxTextBox ID="txt_user_name"  runat="server" Width="140px">
               </cx:ASPxTextBox>
		</li>
		<li class="caption">
			 所属机构：
		</li>
		<li>
			  <dx:ASPxComboBox ID="branch_id" runat="server" ClientInstanceName="cbb_branch_id"
                    Width="140px" DropDownStyle="DropDown" IncrementalFilteringMode="StartsWith"
                    EnableSynchronization="False">
                </dx:ASPxComboBox>
		</li>
	</ul>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <cx:ASPxGridView ID="gridUser" runat="server" KeyFieldName="id" RowCheckBox="true"
        OnRowInserting="gridUser_RowInserting" OnRowDeleting="gridUser_RowDeleting" OnRowUpdating="gridUser_RowUpdating"
        OnHtmlEditFormCreated="gridUser_HtmlEditFormCreated" OnCustomCallback="gridUser_CustomCallback" OnInitNewRow="gridUser_InitNewRow"
        OnAfterPerformCallback="gridUser_AfterPerformCallback" OnPageIndexChanged="gridUser_PageIndexChanged">
        <Columns>
            <dx:GridViewDataTextColumn Caption="是否是管理员" FieldName="role_is_admin" Visible="false">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="所属机构ID" FieldName="branch_id" Visible="false">
            </dx:GridViewDataTextColumn>
			<dx:GridViewDataTextColumn Caption="角色ID" FieldName="role_id" Visible="false">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="所属机构" FieldName="branch_name" VisibleIndex="1"
                HeaderStyle-HorizontalAlign="Center">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn CellStyle-ForeColor="Red" Caption="用户密码" Visible="false"
                FieldName="password">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="用户名" FieldName="user_name" VisibleIndex="2" HeaderStyle-HorizontalAlign="Center">
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="员工编号" FieldName="emp_Info_Id" ToolTip="关联员工帐号" Visible="false">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="员工名称" FieldName="employee_name" ToolTip="关联员工姓名" VisibleIndex="5">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="账户状态" FieldName="status_name" VisibleIndex="6">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="账户状态" FieldName="user_status" Visible="false">
            </dx:GridViewDataTextColumn>
			<dx:GridViewDataTextColumn Caption="角色" FieldName="role_name">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="默认查阅机构" FieldName="def_branch_name" VisibleIndex="8">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="查阅机构ID" FieldName="def_show_branch" Visible="false">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="可查阅机构ID" FieldName="can_show_branch" Visible="false">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="更新时间" FieldName="update_date" VisibleIndex="10"
                HeaderStyle-HorizontalAlign="Center">
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
            </dx:GridViewDataTextColumn>
        </Columns>
        <Templates>
            <EditForm>
                <dx:EditToolBar ID="EditToolBar1" runat="server"></dx:EditToolBar>
                <table cellpadding="4" cellspacing="0" class="editTable">
                    <tr>
                        <td align="right" class="editFormCaption">
                            所属机构：
                        </td>
                        <td class="editFormCell">
						   <dx:BranchLookUp ID="branch_id" runat="server" Index="0"></dx:BranchLookUp>
                        </td>
                        <td align="right" class="editFormCaption">
                            默认查阅机构：
                        </td>
                        <td class="editFormCell">
						   <dx:BranchLookUp ID="def_show_branch" runat="server" Index="1"></dx:BranchLookUp>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="editFormCaption">
                            用户名称：
                        </td>
                        <td class="editFormCell" id="tbUserName">
                            <cx:ASPxTextBox ID="user_name" runat="server" Width="100%" IsRequired="true">
                            </cx:ASPxTextBox>
                        </td>
                        <td align="right" class="editFormCaption">
                            <dx:ASPxLabel ID="ASPxLabel10" ForeColor="Red" runat="server" Text="默认密码：">
                            </dx:ASPxLabel>
                        </td>
                        <td class="editFormCell">
                            <dx:ASPxLabel ID="ASPxLabel12" ForeColor="Red" runat="server" Text="新增用户密码为【888888】">
                            </dx:ASPxLabel>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="editFormCaption">
                            关联员工姓名：
                        </td>
                        <td class="editFormCell">
						    <dx:EmployeeLookUp ID="emp_Info_Id" runat="server"></dx:EmployeeLookUp>
                        </td>
                        <td align="right" class="editFormCaption">
                            <dx:ASPxLabel ID="ASPxLabel5" runat="server" Text="账户状态：">
                            </dx:ASPxLabel>
                        </td>
                        <td class="editFormCell">
						    <dx:ComoboxCode ID="user_status" codeType="user_status" runat="server" IsRequired="true"></dx:ComoboxCode>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="editFormCaption">
                            角色：
                        </td>
                        <td class="editFormCell">
						    <dx:RoleLookUp ID="role_id" runat="server" IsRequrided="true"></dx:RoleLookUp>
                        </td>
						<td align="right" class="editFormCaption">
                           
                        </td>
                        <td class="editFormCell">
						    
                        </td>
                    </tr>
                </table>
                <div class="gvw_header">
                    <span style="display: block; padding: 0px 0px 0px 10px; background-position: 5px;
                        text-align: center">可查看机构</span>
                </div>
                <div>
                    <dx:MainToolBar ID="MainToolBar1" runat="server" IsSubMenu="true"></dx:MainToolBar>
                    <cx:ASPxGridView ID="gridShowBranch" runat="server" ClientInstanceName="gridShowBranch"
                        AutoGenerateColumns="False" KeyFieldName="id" OnRowInserting="gridShowBranch_RowInserting"
                        OnRowUpdating="gridShowBranch_RowUpdating" RowCheckBox="true" EditingMode="EditFormAndDisplayRow" OnDataBinding="gridShowBranch_DataBinding" OnRowDeleting="gridShowBranch_RowDeleting" OnHtmlEditFormCreated="gridShowBranch_HtmlEditFormCreated">
                        <Columns>
                            <dx:GridViewDataTextColumn Caption="id" FieldName="id" Visible="false">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="branch_id" FieldName="branch_id" Visible="false">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="机构" FieldName="name" ToolTip="机构" VisibleIndex="5">
                            </dx:GridViewDataTextColumn>
                        </Columns>
                        <Templates>
                            <EditForm>
                                <dx:EditToolBar ID="EditToolBar2" runat="server" MenuTye="SubMenu"></dx:EditToolBar>
                                <table cellpadding="4" cellspacing="0" class="editTable">
                                    <tr>
                                        <td align="right" class="editFormCaption" style="width: 10%">
                                            所属机构：
                                        </td>
                                        <td class="editFormCell" style="width: 40%">
                                            <dx:ASPxComboBox ID="branch_id" runat="server" Width="100%" DropDownStyle="DropDownList"
                                                TextField="name" ValueField="id" TextFormatString="{0}" ValueType="System.String"
                                                EnableIncrementalFiltering="True" EnableSynchronization="False">
                                                <Columns>
                                                    <dx:ListBoxColumn FieldName="name" Width="100px" Caption="机构名称" />
                                                    <dx:ListBoxColumn FieldName="link_name" Width="50px" Caption="联系人" />
                                                    <dx:ListBoxColumn FieldName="link_address" Width="100px" Caption="地址" />
                                                </Columns>
                                                <ValidationSettings Display="Dynamic" SetFocusOnError="true" ErrorDisplayMode="ImageWithTooltip"
                                                    ValidateOnLeave="true" ValidationGroup="validGroup">
                                                    <RequiredField IsRequired="true" ErrorText="请选择所属机构" />
                                                </ValidationSettings>
                                            </dx:ASPxComboBox>
                                        </td>
                                    </tr>
                                </table>
                            </EditForm>
                        </Templates>
                        <Settings GridLines="Both" ShowVerticalScrollBar="true" />
                        <SettingsBehavior AllowSelectByRowClick="true" AllowFocusedRow="true" ConfirmDelete="true"
                            AllowSort="false" />
                        <SettingsText Title="可查看机构" PopupEditFormCaption="编辑可查看机构" />
                        <SettingsPager Mode="ShowAllRecords" />
                        <Border BorderWidth="0" />
                    </cx:ASPxGridView>
                </div>
            </EditForm>
        </Templates>
        <SettingsText PopupEditFormCaption="编辑用户信息" />
	    <SettingsEditing Mode="PopupEditForm" PopupEditFormWidth="570" />
        <Border BorderWidth="0" />
		<ClientSideEvents EndCallback="viewSetting.grid_EndCallback" />
    </cx:ASPxGridView>
</asp:Content>
