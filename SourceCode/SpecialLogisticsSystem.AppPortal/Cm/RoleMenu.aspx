<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="RoleMenu.aspx.cs" Inherits="SpecialLogisticsSystem.AppPortal.Cm.RoleMenu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script language="javascript" type="text/javascript">
        function gridRole_EndCallback(s, e) {
            if (s.cp_callbackMsg != undefined && s.cp_callbackMsg != "") {
                showMsg({ msg: s.cp_callbackMsg });
                s.cp_callbackMsg = "";
            }
        }
        function gridRole_OnSelectRoleChange(s, e) {
            s.GetSelectedFieldValues("role_name", function (val) {
                labShowSelectText.SetValue("您当前选择的角色是：" + val);
            });
            s.GetSelectedFieldValues("id", function (val) {
                treeListMenu.PerformCallback(val);
            });
        }
        function OnGridSelectionComplete(values) {
            for (var i = 0; i < values.length - 1; i++) {
                gridR.SelectRowsByKey(values[i], false);
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div style="width: 520px; margin-left: 30px; margin-top: 5px; float: left; overflow: auto;">
        <table style="width: 96%">
            <tr>
                <td style="width: 260px">
                    <div style="height: auto; color: Red;">
                        <dx:ASPxLabel ID="labShowSelectText" runat="server" Text="选择角色类型，可设置选中角色所属菜单权限" ClientInstanceName="labShowSelectText">
                        </dx:ASPxLabel>
                    </div>
                </td>
                <td align="right">
                    <dx:ASPxButton runat="server" ID="btn_Save" Text="保存" OnClick="btn_Save_Click">
                    </dx:ASPxButton>
                </td>
                <td width="60px">
                    <dx:ASPxButton ID="btnHelp" runat="server" EnableTheming="False" Text="帮助" EnableDefaultAppearance="False"
                        AllowFocus="False" AutoPostBack="False" Width="100%" CssPostfix="botton">
                        <Image Url="../Scripts/themes/icons/help.png" Width="16px" Height="16px" />
                        <ClientSideEvents Click=" SpecialLogisticsSystem.Util.Help" />
                    </dx:ASPxButton>
                </td>
            </tr>
        </table>
        <dx:ASPxGridView ID="gridRole" runat="server" AutoGenerateColumns="False" KeyFieldName="id"
            ClientInstanceName="gridRole" Width="500px" OnRowDeleting="gridRole_RowDeleting"
            OnRowInserting="gridRole_RowInserting" OnRowUpdating="gridRole_RowUpdating">
            <SettingsBehavior AllowSelectByRowClick="true" AllowSelectSingleRowOnly="true" ProcessSelectionChangedOnServer="false" />
            <ClientSideEvents SelectionChanged="gridRole_OnSelectRoleChange" />
            <Columns>
                <dx:GridViewCommandColumn ShowSelectCheckbox="True" VisibleIndex="0" Width="40" Caption="选择">
                </dx:GridViewCommandColumn>
                <dx:GridViewDataColumn Caption="id" FieldName="id" Visible="false">
                </dx:GridViewDataColumn>
                <dx:GridViewDataTextColumn Caption="角色名称" FieldName="role_name" Name="role_name"
                    ToolTip="角色名称" VisibleIndex="1" Width="80" HeaderStyle-HorizontalAlign="Center">
                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                    <CellStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn Caption="角色描述" FieldName="description" ToolTip="角色描述"
                    VisibleIndex="2">
                </dx:GridViewDataTextColumn>
                <dx:GridViewCommandColumn VisibleIndex="4" ButtonType="Image" Caption="操作" HeaderStyle-HorizontalAlign="Center">
                    <EditButton Visible="True" Text="编辑">
                        <Image ToolTip="编辑" Url="~/Images/commad/edit.ico">
                        </Image>
                    </EditButton>
                    <NewButton Visible="True">
                        <Image ToolTip="添加一行" Url="~/Images/commad/add.ico">
                        </Image>
                    </NewButton>
                    <DeleteButton Visible="True" Text="删除">
                        <Image Height="16px" ToolTip="删除" Url="~/Images/commad/delete_16x.ico" Width="16px">
                        </Image>
                    </DeleteButton>
                    <SelectButton Text="选择">
                        <Image Url="~/Images/commad/Save.ico">
                        </Image>
                    </SelectButton>
                    <ClearFilterButton Visible="True">
                    </ClearFilterButton>
                    <CancelButton>
                        <Image ToolTip="取消" Url="~/Images/commad/cancel.gif">
                        </Image>
                    </CancelButton>
                    <UpdateButton>
                        <Image ToolTip="保 存" Url="~/Images/commad/save.gif">
                        </Image>
                    </UpdateButton>
                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                </dx:GridViewCommandColumn>
            </Columns>
            <SettingsEditing PopupEditFormShowHeader="False" PopupEditFormWidth="500px" NewItemRowPosition="Top" />
            <SettingsPager PageSize="15" Mode="ShowPager">
                <Summary Text="页: {0} / {1} (共 {2} 行)" />
            </SettingsPager>
			<Border BorderWidth="1" />    
            <SettingsText Title="系统提示" EmptyDataRow="无数据" PopupEditFormCaption="编辑" ConfirmDelete="确定删除本行记录吗 ？" />
			<ClientSideEvents EndCallback="gridRole_EndCallback" />
        </dx:ASPxGridView>
    </div>
    <div style="width: 250px; margin-left: 20px; margin-top: 10px; float: left; max-height: 500px;
        overflow: auto;">
        <dx:ASPxTreeList ID="treeListMenu" runat="server" AutoGenerateColumns="False" OnCustomCallback="treeListMenu_CustomCallback"
            ClientInstanceName="treeListMenu">
            <Columns>
                <dx:TreeListTextColumn Caption="菜单角色选择" FieldName="name" ToolTip="菜单角色选择" VisibleIndex="0">
                    <DataCellTemplate>
                        <table cellpadding="0" cellspacing="0">
                            <tr>
                                <td>
                                    <span class='<%# Eval("icon") %> icon' style="display: block;"></span>
                                </td>
                                <td>
                                    <asp:Label ID="imgbtnUpdateWeb" runat="server" Text='<%# Eval("name") %>' />
                                </td>
                            </tr>
                        </table>
                    </DataCellTemplate>
                </dx:TreeListTextColumn>
                <dx:TreeListTextColumn FieldName="icon" Visible="False" VisibleIndex="1">
                </dx:TreeListTextColumn>
            </Columns>
            <SettingsBehavior AllowFocusedNode="True" />
            <SettingsSelection Enabled="True" />
        </dx:ASPxTreeList>
    </div>
</asp:Content>
