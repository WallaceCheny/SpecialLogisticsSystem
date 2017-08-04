<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProductionSign.ascx.cs"
    Inherits="SpecialLogisticsSystem.AppPortal.UserControls.ProductionSign" %>
<%@ Register Src="/UserControls/EmployeeLookUp.ascx" TagName="EmployeeLookUp" TagPrefix="uc1" %>
<%@ Register Src="/UserControls/EditToolBar.ascx" TagName="EditToolBar" TagPrefix="uc2" %>
<dx:ASPxPopupControl ID="pop_Signer" ClientInstanceName="pop_Signer" runat="server"
    CloseAction="CloseButton" HeaderText="录入货物签收信息" AllowDragging="true" EnableAnimation="false"
    Modal="true" EnableViewState="false" Width="280px" PopupHorizontalAlign="WindowCenter"
    PopupVerticalAlign="WindowCenter" PopupVerticalOffset="-75" PopupHorizontalOffset="-85">
    <ContentCollection>
        <dx:PopupControlContentControl>
            <uc2:EditToolBar ID="EditToolBar2" runat="server" MenuTye="PopupMenu"></uc2:EditToolBar>
            <table cellpadding="4" cellspacing="0" class="editTable">
                <tr>
                    <td class="editFormCaption">
                        签收人<span class="red">*</span>:
                    </td>
                    <td class="editFormCell">
                        <cx:ASPxTextBox ID="signer" runat="server" Width="100" IsRequired="true">
                        </cx:ASPxTextBox>
                    </td>
                    <td class="editFormCaption">
                        证件号:
                    </td>
                    <td class="editFormCell">
                        <cx:ASPxTextBox ID="signer_identity" runat="server" Width="100">
                        </cx:ASPxTextBox>
                    </td>
                </tr>
                <tr>
                    <td class="editFormCaption">
                        签收说明:
                    </td>
                    <td class="editFormCell" colspan="3">
                        <cx:ASPxMemo ID="signer_memo" runat="server" Height="100%" Width="100%">
                        </cx:ASPxMemo>
                    </td>
                </tr>
                <tr>
                    <td class="editFormCaption">
                        签收时间<span class="red">*</span>:
                    </td>
                    <td class="editFormCell">
                        <cx:ASPxDateEdit ID="signer_date" DefaultToday="true" runat="server" Width="100">
                        </cx:ASPxDateEdit>
                    </td>
                    <td class="editFormCaption">
                        经办人:
                    </td>
                    <td class="editFormCell">
                        <uc1:EmployeeLookUp ID="emp_id" runat="server" IsSetDefault="true" Width="100"></uc1:EmployeeLookUp>
                    </td>
                </tr>
            </table>
        </dx:PopupControlContentControl>
    </ContentCollection>
    <ContentStyle Paddings-Padding="0" />
</dx:ASPxPopupControl>
