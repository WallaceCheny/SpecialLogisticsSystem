<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CustomerPayDetail.ascx.cs"
    Inherits="SpecialLogisticsSystem.AppPortal.UserControls.CustomerPayDetail" %>
<%@ Register Src="/UserControls/EditToolBar.ascx" TagName="EditToolBar" TagPrefix="uc2" %>
<%@ Register Src="/UserControls/ComoboxCode.ascx" TagName="ComoboxCode" TagPrefix="uc1" %>
<dx:ASPxPopupControl ID="pop_Signer" ClientInstanceName="pop_Signer" runat="server"
    CloseAction="CloseButton" HeaderText="客户结算" AllowDragging="true" EnableAnimation="false"
    Modal="true" EnableViewState="false" Width="260px" PopupHorizontalAlign="WindowCenter"
    PopupVerticalAlign="WindowCenter" PopupVerticalOffset="-75" PopupHorizontalOffset="-85">
    <ContentCollection>
        <dx:PopupControlContentControl>
            <uc2:EditToolBar ID="EditToolBar2" runat="server" IsPopupMenu="true"></uc2:EditToolBar>
            <table cellpadding="4" cellspacing="0" class="editTable">
                <tr>
                    <td class="editFormCaption">
                        运单号<span class="red">*</span>:
                    </td>
                    <td class="editFormCell">
                        <cx:ASPxTextBox ID="way_number" runat="server" Width="80">
                        </cx:ASPxTextBox>
                    </td>
                    <td class="editFormCaption">
                        单据总额:
                    </td>
                    <td class="editFormCell">
                        <cx:ASPxTextBox ID="aggregate_amount" runat="server" Width="80">
                        </cx:ASPxTextBox>
                    </td>
                </tr>
                <tr>
                    <td class="editFormCaption">
                        现付:
                    </td>
                    <td class="editFormCell">
                        <cx:ASPxTextBox ID="spot_payment" runat="server" Height="100%" Width="100%">
                        </cx:ASPxTextBox>
                    </td>
                    <td class="editFormCaption">
                        回单/月结<span class="red">*</span>:
                    </td>
                    <td class="editFormCell">
                        <cx:ASPxTextBox ID="back_payment" runat="server" Width="80">
                        </cx:ASPxTextBox>
                    </td>
                </tr>
                <tr>
                    <td class="editFormCaption">
                        已结金额:
                    </td>
                    <td class="editFormCell">
                        <cx:ASPxTextBox ID="already_payment" runat="server" Width="80">
                        </cx:ASPxTextBox>
                    </td>
                    <td class="editFormCaption">
                        结算金额<span class="red">*</span>:
                    </td>
                    <td class="editFormCell">
                        <cx:ASPxTextBox ID="settle_accounts"  IsPrice="true" runat="server" Width="80">
                        </cx:ASPxTextBox>
                    </td>
                </tr>
                <tr>
                    <td class="editFormCaption">
                        结算方式:
                    </td>
                    <td class="editFormCell">
                         <uc1:ComoboxCode ID="settle_mode" runat="server"></uc1:ComoboxCode>
                    </td>
                    <td class="editFormCaption">
                        收款日期<span class="red">*</span>:
                    </td>
                    <td class="editFormCell">
                        <cx:ASPxDateEdit ID="collection_day" runat="server" Width="80">
                        </cx:ASPxDateEdit>
                    </td>
                </tr>
                <tr>
                    <td class="editFormCaption">
                        结算备注:
                    </td>
                    <td class="editFormCell" colspan="3">
                        <cx:ASPxMemo ID="settle_memo" runat="server" Height="100%" Width="100%">
                        </cx:ASPxMemo>
                    </td>
                </tr>
            </table>
        </dx:PopupControlContentControl>
    </ContentCollection>
    <ContentStyle Paddings-Padding="0" />
</dx:ASPxPopupControl>
