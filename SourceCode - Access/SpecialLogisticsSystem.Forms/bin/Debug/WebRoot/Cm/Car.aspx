<%@ Page Title="" Language="C#" MasterPageFile="~/MenuMaster.master" AutoEventWireup="true"
    CodeBehind="Car.aspx.cs" Inherits="SpecialLogisticsSystem.AppPortal.Cm.Car" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript">
        gridConfig.gridID = 'gridCar';
		function filterCondition() {
            return {car_no: txt_car_no.GetValue(), link_name: txt_link_name.GetValue(), car_memo: txt_remark.GetValue() };
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SearchContent" runat="server">
    <ul id="viewSearch">
		<li class="caption">
		     车牌号：
		</li>
		<li>
			  <cx:ASPxTextBox ID="txt_car_no"  runat="server" Width="140px">
               </cx:ASPxTextBox>
		</li>
		<li class="caption">
			 司机：
		</li>
		<li>
			   <cx:ASPxTextBox ID="txt_link_name"  runat="server" Width="140px">
               </cx:ASPxTextBox>
		</li>
		<li class="caption">
			 备注：
		</li>
		<li>
			   <cx:ASPxTextBox ID="txt_remark"  runat="server" Width="140px">
               </cx:ASPxTextBox>
		</li>
	</ul>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <cx:ASPxGridView ID="gridCar" RowCheckBox="true" runat="server" OnRowDeleting="gridCar_RowDeleting"
        OnRowInserting="gridCar_RowInserting" OnHtmlEditFormCreated="gridCar_HtmlEditFormCreated"
        OnRowUpdating="gridCar_RowUpdating" KeyFieldName="id" OnAfterPerformCallback="gridCar_AfterPerformCallback">
        <Columns>
			<dx:GridViewDataTextColumn Caption="link_id" FieldName="link_id" Visible="false">
            </dx:GridViewDataTextColumn>
		    <dx:GridViewDataTextColumn Caption="车牌号" FieldName="car_no">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="车主" FieldName="car_owner">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="司机" FieldName="link_name">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="所属部门" FieldName="branch_name">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="保险单号" FieldName="insurance_number">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="厂牌型号" FieldName="car_produce_no">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="车辆类型" FieldName="car_type_name">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="车辆性质" FieldName="car_nature_name">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="发动机号" FieldName="car_engine_number">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="行驶证号" FieldName="car_drive_no">
            </dx:GridViewDataTextColumn>
			<dx:GridViewDataTextColumn Caption="备注" FieldName="car_memo">
            </dx:GridViewDataTextColumn>
        </Columns>
        <Templates>
            <EditForm>
                <dx:EditToolBar ID="EditToolBar1" runat="server"></dx:EditToolBar>
                <table cellpadding="4" cellspacing="0" class="editTable">
				    <tr>
					    <td colspan="4" class="editFormTh">
						   车辆信息
						</td>
				   </tr>
                    <tr>
                        <td class="editFormCaption">
                            车牌号<span class="red">*</span>：
                        </td>
                        <td class="editFormCell">
                            <cx:ASPxTextBox ID="car_no" runat="server" Width="170px" IsRequired="true">
                            </cx:ASPxTextBox>
                        </td>
                        <td class="editFormCaption">
                            保险卡号：
                        </td>
                        <td class="editFormCell">
                            <cx:ASPxTextBox ID="insurance_number"  runat="server" Width="170px">
                            </cx:ASPxTextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="editFormCaption">
                            厂牌型号：
                        </td>
                        <td class="editFormCell">
                            <cx:ASPxTextBox ID="car_produce_no"  runat="server" Width="170px">
                            </cx:ASPxTextBox>
                        </td>
                        <td class="editFormCaption">
                            车辆类型：
                        </td>
                        <td class="editFormCell">
                              <dx:ComoboxCode ID="car_type" codeType="car_type" runat="server" Width="170"></dx:ComoboxCode>
                        </td>
                    </tr>
					  <tr>
                        <td class="editFormCaption">
                            行驶证号：
                        </td>
                        <td class="editFormCell">
                            <cx:ASPxTextBox ID="car_drive_no"  runat="server" Width="170px">
                            </cx:ASPxTextBox>
                        </td>
                        <td class="editFormCaption">
                            车辆性质：
                        </td>
                        <td class="editFormCell">
                            <dx:ComoboxCode ID="car_nature" codeType="car_nature" runat="server" Width="170"></dx:ComoboxCode>
                        </td>
                    </tr>
					<tr>
                        <td class="editFormCaption">
                            发动机号：
                        </td>
                        <td class="editFormCell">
                            <cx:ASPxTextBox ID="car_engine_number"  runat="server" Width="170px">
                            </cx:ASPxTextBox>
                        </td>
                        <td class="editFormCaption">
                            车主：
                        </td>
                        <td class="editFormCell">
						   <cx:ASPxTextBox ID="car_owner"  runat="server" Width="170px">
                           </cx:ASPxTextBox>
                        </td>
                    </tr>
					<tr>
					    <td colspan="4" class="editFormTh">
						   司机信息
						</td>
				   </tr>
                   <dx:LinkMan ID="car_link" runat="server" />
                </table>
            </EditForm>
        </Templates>
        <SettingsText PopupEditFormCaption="编辑车辆信息" />
        <Border BorderWidth="0" />
        <ClientSideEvents EndCallback="viewSetting.grid_EndCallback" />
    </cx:ASPxGridView>
</asp:Content>
