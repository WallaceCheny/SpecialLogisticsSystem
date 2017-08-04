<%@ Page Title="" Language="C#" MasterPageFile="~/MenuMaster.Master" AutoEventWireup="true"
    CodeBehind="Code.aspx.cs" Inherits="SpecialLogisticsSystem.AppPortal.Cm.Code" %>

<%@ Register Src="/UserControls/EditToolBar.ascx" TagName="EditToolBar" TagPrefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script language="javascript" type="text/javascript">
        gridConfig.gridMainID = "gridParaType";
        gridConfig.gridID = 'gridCode';
        gridConfig.ChangeSize = 'false';
        $(function () {
            gridParaType.SetFocusedRowIndex(gridParaType.GetFocusedRowIndex() + 1);
        });
        function gridParaType_OnSelectRoleChange(s, e) {
            s.GetSelectedFieldValues("Description", function (val) {
                labShowSelectText.SetValue("您当前选择参数类型是：" + val);
            });
            s.GetSelectedFieldValues("Name", function (val) {
                gridCode.PerformCallback(val);
            });
        }		
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width: 100%; height: 100%;">
        <tr>
            <td style="width: 230px; margin-left: 0px; padding: 5px;">
                <div style="overflow: auto; height: 100%;">
                    <table style="width: 100%">
                        <tr>
                            <td style="width: 220px">
                                <span style="height: auto; color: Red; font-size: 13px; font: Arial, Helvetica, sans-serif;">
                                    <dx:ASPxLabel ID="labShowSelectText" runat="server" Text="请选择系统参数类型,进行编辑。" ClientInstanceName="labShowSelectText">
                                    </dx:ASPxLabel>
                                </span>
                            </td>
                        </tr>
                    </table>
                    <cx:ASPxGridView ID="gridParaType" runat="server" AutoGenerateColumns="False" ClientInstanceName="gridParaType"
                        Width="280px" OnSelectionChanged="gridParaType_SelectionChanged" IsEditing="true" RowRadio="true"
                        KeyFieldName="Name">
                        <SettingsBehavior AllowFocusedRow="True" ConfirmDelete="True" AllowSelectByRowClick="true"
                            AllowSelectSingleRowOnly="true" ProcessSelectionChangedOnServer="false" />
                        <ClientSideEvents SelectionChanged="gridParaType_OnSelectRoleChange" EndCallback="viewSetting.grid_EndCallback"/>
                        <Columns>
                            <dx:GridViewDataTextColumn Caption="参数类别" FieldName="Name" Name="Name"
                                Visible="false" ToolTip="参数类别" VisibleIndex="1" Width="80" HeaderStyle-HorizontalAlign="Center">
                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                <CellStyle VerticalAlign="Middle" HorizontalAlign="Left" />
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="参数类别" FieldName="Description" ToolTip="参数类别名称"
                                VisibleIndex="2" Width="100">
                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                            </dx:GridViewDataTextColumn>
                        </Columns>
                        <SettingsPager PageSize="30" Mode="ShowPager">
                        </SettingsPager>
                    </cx:ASPxGridView>
                </div>
            </td>
            <td valign="top">
                <div style="padding: 5px; overflow: auto;">
                    <cx:ASPxGridView ID="gridCode" runat="server" AutoGenerateColumns="False" ClientInstanceName="gridCode"
                        OnCustomCallback="gridCode_CustomCallback" KeyFieldName="id" OnHtmlEditFormCreated="gridCode_HtmlEditFormCreated"
                        OnRowDeleting="gridCode_RowDeleting" OnRowInserting="gridCode_RowInserting" OnRowUpdating="gridCode_RowUpdating"
                        OnSelectionChanged="gridParaType_SelectionChanged">
                        <Templates>
                            <EditForm>
                                <uc3:EditToolBar ID="EditToolBar1" runat="server"></uc3:EditToolBar>
                                <table style="width: 95%; padding-top: 29px">
                                    <tr>
                                        <td align="right" width="20px">
                                            <dx:ASPxLabel ID="lblCodeValue" runat="server" Text="参数值：">
                                            </dx:ASPxLabel>
                                        </td>
                                        <td align="left" width="30%">
                                            <dx:ASPxTextBox ID="para_value" runat="server" Width="170px" NullText="参数值输入不得重复..">
                                            </dx:ASPxTextBox>
                                        </td>
                                        <td align="right" width="20px">
                                            <dx:ASPxLabel ID="lblCodeName" runat="server" Text="参数名称：">
                                            </dx:ASPxLabel>
                                        </td>
                                        <td align="left" width="30%">
                                            <dx:ASPxTextBox ID="PARA_NAME" runat="server" Width="170px" NullText="界面上显示的文字..">
                                            </dx:ASPxTextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" width="20px">
                                            <dx:ASPxLabel ID="lblOn" runat="server" Text="是否启用：">
                                            </dx:ASPxLabel>
                                        </td>
                                        <td align="left">
                                            <dx:ASPxComboBox runat="server" ID="eff_ind" Width="170px">
                                                <Items>
                                                    <dx:ListEditItem Text="不启用" Value="0" />
                                                    <dx:ListEditItem Text="启用" Value="1" />
                                                </Items>
                                            </dx:ASPxComboBox>
                                        </td>
                                        <td align="right" width="20px">
                                            <dx:ASPxLabel ID="lblDescription" runat="server" Text="参数说明：">
                                            </dx:ASPxLabel>
                                        </td>
                                        <td align="left">
                                            <dx:ASPxMemo Width="170px" ID="para_demo" runat="server">
                                            </dx:ASPxMemo>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" width="20px">
                                            <dx:ASPxLabel ID="lblUpdater" runat="server" Text="修改人：">
                                            </dx:ASPxLabel>
                                        </td>
                                        <td align="left" width="30%">
                                            <dx:ASPxTextBox ID="update_opr" runat="server" Width="170px" Text="" BackColor="#e0e0e0">
                                            </dx:ASPxTextBox>
                                        </td>
                                        <td align="right" width="20px">
                                            <dx:ASPxLabel ID="lblUpdateDate" runat="server" Text="修改日期：">
                                            </dx:ASPxLabel>
                                        </td>
                                        <td align="left" width="30%">
                                            <dx:ASPxTextBox ID="update_date" runat="server" Width="170px" Text="" BackColor="#e0e0e0">
                                            </dx:ASPxTextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" width="20px">
                                            <dx:ASPxLabel ID="lblSort" runat="server" Text="排序：">
                                            </dx:ASPxLabel>
                                        </td>
                                        <td align="left" width="30%">
                                            <dx:ASPxSpinEdit ID="sort" runat="server" Width="170px">
                                            </dx:ASPxSpinEdit>
                                        </td>
                                        <td align="right" width="20px">
			
                                        </td>
                                        <td align="left" width="30%">
											<cx:ASPxCheckBox ID="is_default" runat="server" Text="是否是默认值" Checked="false" EnableViewState="false" />
                                        </td>
                                    </tr>
                                </table>
                            </EditForm>
                        </Templates>
                        <Columns>
                            <dx:GridViewDataTextColumn Caption="参数类别" FieldName="para_type" VisibleIndex="1"
                                Width="100px" Visible="false">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="参数值" FieldName="para_value" ToolTip="参数值" VisibleIndex="2">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="类别名称" FieldName="para_type_name" VisibleIndex="3">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="参数名称" FieldName="para_name" VisibleIndex="4">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataCheckColumn Caption="是否启用" FieldName="eff_ind" VisibleIndex="5">
                                <PropertiesCheckEdit ValueChecked="1" ValueUnchecked="0" ValueType="System.Char">
                                </PropertiesCheckEdit>
                            </dx:GridViewDataCheckColumn>
							<dx:GridViewDataCheckColumn Caption="是默认值" FieldName="is_default">
                                <PropertiesCheckEdit ValueChecked="1" ValueUnchecked="0" ValueType="System.Char">
                                </PropertiesCheckEdit>
                            </dx:GridViewDataCheckColumn>
                            <dx:GridViewDataSpinEditColumn Caption="排序" FieldName="sort" VisibleIndex="6">
                            </dx:GridViewDataSpinEditColumn>
                            <dx:GridViewDataMemoColumn Caption="参数说明" FieldName="para_demo" VisibleIndex="6">
                            </dx:GridViewDataMemoColumn>
                            <dx:GridViewDataTextColumn Caption="修改人" FieldName="update_opr" VisibleIndex="7">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="更新日期" FieldName="update_date" VisibleIndex="8">
                                <PropertiesTextEdit DisplayFormatString="yyyy/MM/dd" DisplayFormatInEditMode="True">
                                </PropertiesTextEdit>
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewCommandColumn VisibleIndex="0" ButtonType="Image" Caption="操作" HeaderStyle-HorizontalAlign="Center"
                                Width="200px">
                                <EditButton Visible="True" Text="编辑">
                                    <Image ToolTip="编辑" Url="~/Images/commad/edit1.gif">
                                    </Image>
                                </EditButton>
                                <NewButton Visible="True">
                                    <Image ToolTip="添加一行" Url="~/Images/commad/add.gif">
                                    </Image>
                                </NewButton>
                                <DeleteButton Visible="True" Text="删除">
                                    <Image ToolTip="删除" Url="~/Images/commad/delete.gif" AlternateText="删除">
                                    </Image>
                                </DeleteButton>
                                <CancelButton>
                                    <Image ToolTip="取消" Url="~/Images/commad/cancel.gif">
                                    </Image>
                                </CancelButton>
                                <UpdateButton>
                                    <Image ToolTip="保 存" Url="~/Images/commad/save.gif">
                                    </Image>
                                </UpdateButton>
                                <ClearFilterButton Visible="True">
                                    <Image ToolTip="取消过滤" Url="../Images/commad/verifydialog.ico">
                                    </Image>
                                </ClearFilterButton>
                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                            </dx:GridViewCommandColumn>
                        </Columns>
                        <SettingsBehavior AllowFocusedRow="True" ConfirmDelete="True" />
                        <Settings VerticalScrollableHeight="260" ShowGroupPanel="false" GridLines="Both">
                        </Settings>
                        <SettingsText CommandUpdate="保存" CommandCancel="取消" CommandDelete="删除" ConfirmDelete="确定删除该记录吗 ？"
                            EmptyDataRow="无数据" PopupEditFormCaption="编辑系统参数信息" />
                        <SettingsEditing Mode="PopupEditForm" PopupEditFormHorizontalAlign="WindowCenter"
                            PopupEditFormVerticalAlign="WindowCenter" PopupEditFormHeight="200px" PopupEditFormWidth="550px" />
                    </cx:ASPxGridView>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
