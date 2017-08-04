 <%@ Page Title="" Language="C#" MasterPageFile="~/MenuMaster.master" AutoEventWireup="true"
    CodeBehind="Branch.aspx.cs" Inherits="SpecialLogisticsSystem.AppPortal.Cm.Branch" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript">
        gridConfig.gridID = 'gridBranch';
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <cx:ASPxGridView  ID="gridBranch"  RowCheckBox="true" runat="server"  OnRowDeleting="gridBranch_RowDeleting"
        OnRowInserting="gridBranch_RowInserting" OnHtmlEditFormCreated="gridBranch_HtmlEditFormCreated"
        OnRowUpdating="gridBranch_RowUpdating" KeyFieldName="id">
        <Columns>
            <dx:GridViewDataTextColumn Caption="编号" FieldName="code">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="名称" FieldName="name">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="网点类型" FieldName="site_name">
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
                            <cx:ASPxTextBox ID="name" runat="server" Width="170px" IsRequired="true">
                            </cx:ASPxTextBox>
                        </td>
                        <td class="editFormCaption">
                            网点类型<span class="red">*</span>：
                        </td>
                        <td class="editFormCell">
                            <dx:ComoboxCode ID="site_type" codeType="site_type" runat="server" IsRequired="true"></dx:ComoboxCode>
                        </td>
                    </tr>
                    <tr>
                        <td class="editFormCaption">
                            编码：
                        </td>
                        <td class="editFormCell">
                            <dx:GeneralNumber ID="code" runat="server" Width="170" CodeEnum="Branch">
                            </dx:GeneralNumber>
                        </td>
                        <td class="editFormCaption">
                            上级机构：
                        </td>
                        <td class="editFormCell">
							 <dx:BranchLookUp ID="parent_id" runat="server" IsNew="false"></dx:BranchLookUp>
                        </td>
                    </tr>
                    <dx:LinkMan ID="link_id" runat="server" />
                </table>
            </EditForm>
        </Templates>
        <SettingsText PopupEditFormCaption="编辑网点信息" />
        <Border BorderWidth="0" />
		<ClientSideEvents EndCallback="viewSetting.grid_EndCallback" />
    </cx:ASPxGridView>
</asp:Content>
