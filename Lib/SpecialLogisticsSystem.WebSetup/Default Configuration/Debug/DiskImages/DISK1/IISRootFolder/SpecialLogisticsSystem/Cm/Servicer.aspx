<%@ Page Title="" Language="C#" MasterPageFile="~/MenuMaster.Master" AutoEventWireup="true" CodeBehind="Servicer.aspx.cs" Inherits="SpecialLogisticsSystem.AppPortal.Cm.Servicer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript">
        gridConfig.gridID = 'gridServicer';
		function filterCondition() {
             return { name:txt_name.GetValue(), link_name:txt_link_name.GetValue(), link_name:txt_address.GetValue() };
         }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SearchContent" runat="server">
    <ul id="viewSearch">
		<li class="caption">
		     名称：
		</li>
		<li>
			  <cx:ASPxTextBox ID="txt_name"  runat="server" Width="140px">
              </cx:ASPxTextBox>
		</li>
		<li class="caption">
			 联系人：
		</li>
		<li>
			  <cx:ASPxTextBox ID="txt_link_name"  runat="server" Width="140px">
              </cx:ASPxTextBox>
		</li>
		<li class="caption">
			 地址：
		</li>
		<li>
			  <cx:ASPxTextBox ID="txt_address"  runat="server" Width="140px">
              </cx:ASPxTextBox>
		</li>
	</ul>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <cx:ASPxGridView ID="gridServicer" runat="server" OnRowDeleting="gridServicer_RowDeleting"
        OnRowInserting="gridServicer_RowInserting" OnHtmlEditFormCreated="gridServicer_HtmlEditFormCreated"
        OnRowUpdating="gridServicer_RowUpdating" KeyFieldName="id" RowCheckBox="true" OnAfterPerformCallback="gridServicer_AfterPerformCallback" >
        <Columns>
		    <dx:GridViewDataTextColumn Caption="link_id" FieldName="link_id" Visible="false">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="编号" FieldName="code">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="名称" FieldName="name">
            </dx:GridViewDataTextColumn>
			<dx:GridViewDataTextColumn Caption="信誉等级" FieldName="creditlevel_name">
            </dx:GridViewDataTextColumn>
			<dx:GridViewDataTextColumn Caption="信誉等级" FieldName="credit_level" Visible="false">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="联系人" FieldName="link_name">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="电话" FieldName="link_telephone">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="手机" FieldName="link_mobilephone">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="所在地区" FieldName="link_area" Width="150">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="地址" FieldName="link_address">
            </dx:GridViewDataTextColumn>
			<dx:GridViewDataTextColumn Caption="备注" FieldName="link_memo">
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
                            信誉等级<span class="red">*</span>：
                        </td>
                        <td class="editFormCell">
                            <dx:ComoboxCode ID="credit_level" codeType="customer_credit" runat="server" IsRequired="true" ></dx:ComoboxCode>
                        </td>
                    </tr>
                    <tr>
                        <td class="editFormCaption">
                            编码：
                        </td>
                        <td class="editFormCell" colspan="3">
						    <dx:GeneralNumber ID="code" runat="server" CodeEnum="Servicer" Width="170"></dx:GeneralNumber>
                        </td>
                    </tr>
                    <dx:LinkMan ID="link_id" runat="server" />
                </table>
            </EditForm>
        </Templates>
        <SettingsText PopupEditFormCaption="编辑服务商信息" />
        <Border BorderWidth="0" />
		<ClientSideEvents EndCallback="viewSetting.grid_EndCallback" />
    </cx:ASPxGridView>
</asp:Content>
