<%@ Page Title="" Language="C#" MasterPageFile="~/MenuMaster.Master" AutoEventWireup="true"
    CodeBehind="Menu.aspx.cs" Inherits="SpecialLogisticsSystem.AppPortal.Cm.Menu" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript">
        gridConfig.treeID = 'treeList';
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <dx:ASPxTreeList ID="treeList" runat="server" AutoGenerateColumns="False" OnNodeUpdating="treeList_NodeUpdating"
        OnNodeDeleting="treeList_NodeDeleting" OnNodeInserting="treeList_NodeInserting"
        OnNodeValidating="treeList_NodeValidating" OnInitNewNode="treeList_InitNewNode"
        OnNodeInserted="treeList_NodeInserted" OnStartNodeEditing="treeList_StartNodeEditing"
        Width="800px">
        <Columns>
            <dx:TreeListTextColumn FieldName="name" Name="name" VisibleIndex="0" Caption="菜单名称"
                ToolTip="菜单名称" HeaderStyle-HorizontalAlign="Center" EditCellStyle-HorizontalAlign="Right">
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
                <EditFormCaptionStyle HorizontalAlign="Right" VerticalAlign="Middle">
                </EditFormCaptionStyle>
            </dx:TreeListTextColumn>
            <dx:TreeListTextColumn FieldName="tip" Name="tip" VisibleIndex="1" Caption="鼠标显示"
                ToolTip="鼠标显示" HeaderStyle-HorizontalAlign="Center">
                <EditFormCaptionStyle HorizontalAlign="Right" VerticalAlign="Middle">
                </EditFormCaptionStyle>
            </dx:TreeListTextColumn>
            <dx:TreeListComboBoxColumn Caption="父菜单" FieldName="parent_id" Name="parent_id" ToolTip="父菜单"
                VisibleIndex="2" HeaderStyle-HorizontalAlign="Center">
                <EditFormCaptionStyle HorizontalAlign="Right" VerticalAlign="Middle">
                </EditFormCaptionStyle>
            </dx:TreeListComboBoxColumn>
            <dx:TreeListSpinEditColumn FieldName="menu_order" Name="menu_order" VisibleIndex="3"
                AllowSort="True" Width="40" Caption="排序" SortIndex="0" SortOrder="Ascending"
                ToolTip="排序顺序" HeaderStyle-HorizontalAlign="Center">
                <PropertiesSpinEdit MinValue="0" SpinButtons-ShowIncrementButtons="true">
                </PropertiesSpinEdit>
                <EditFormCaptionStyle HorizontalAlign="Right" VerticalAlign="Middle">
                </EditFormCaptionStyle>
            </dx:TreeListSpinEditColumn>
            <dx:TreeListComboBoxColumn Caption="菜单图片" FieldName="icon" ToolTip="菜单图片" VisibleIndex="4">
                <EditFormCaptionStyle HorizontalAlign="Right" VerticalAlign="Middle">
                </EditFormCaptionStyle>
            </dx:TreeListComboBoxColumn>
            <dx:TreeListHyperLinkColumn Caption="链接" FieldName="action" Name="action" ToolTip="菜单链接"
                VisibleIndex="6" HeaderStyle-HorizontalAlign="Center">
                <EditFormCaptionStyle HorizontalAlign="Right" VerticalAlign="Middle">
                </EditFormCaptionStyle>
            </dx:TreeListHyperLinkColumn>
            <dx:TreeListCheckColumn Caption="是否主菜单" FieldName="is_main" ToolTip="是否主菜单" VisibleIndex="8">
                <PropertiesCheckEdit ValueChecked="true" ValueUnchecked="false" ValueType="System.Boolean">
                </PropertiesCheckEdit>
                <EditFormCaptionStyle HorizontalAlign="Right" VerticalAlign="Middle">
                </EditFormCaptionStyle>
            </dx:TreeListCheckColumn>
        </Columns>
        <Templates>
            <EditForm>
                <dx:EditToolBar ID="EditToolBar1" runat="server" MenuTye="TreeMenu"></dx:EditToolBar>
                <dx:ASPxTreeListTemplateReplacement ReplacementType="Editors" ID="ASPxTreeListTemplateReplacement1"
                    runat="server"></dx:ASPxTreeListTemplateReplacement>
            </EditForm>
        </Templates>
        <SettingsText CommandUpdate="保存" CommandCancel="取消" />
        <SettingsEditing ConfirmDelete="true" Mode="PopupEditForm" />
        <SettingsPopupEditForm Width="500" Caption="编辑菜单" AllowResize="true" HorizontalAlign="WindowCenter"
            VerticalAlign="WindowCenter" HorizontalOffset="-85" VerticalOffset="-75" />
        <Styles>
            <AlternatingNode VerticalAlign="Middle" HorizontalAlign="Center">
            </AlternatingNode>
        </Styles>
        <Settings GridLines="Both" />
        <SettingsPager PageSize="15" Summary-Text="第{0}/{1}页(共{2}条)" />
        <SettingsBehavior AllowFocusedNode="true" />
        <Paddings Padding="0" />
        <Border BorderWidth="0" />
        <SettingsSelection Enabled="false" />
        <ClientSideEvents EndCallback="viewSetting.treeList_EndCallback" />
    </dx:ASPxTreeList>
</asp:Content>
