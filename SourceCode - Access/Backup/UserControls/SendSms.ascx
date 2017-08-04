<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SendSms.ascx.cs" Inherits="SpecialLogisticsSystem.AppPortal.UserControls.SendSms" %>
<%@ Register Src="/UserControls/EditToolBar.ascx" TagName="EditToolBar" TagPrefix="uc2" %>
<script type="text/javascript">
    gridConfig.callBackID = "reback";
    function reback_CallbackComplete(s, e) {
        if (e.result == "true") {
            SpecialLogisticsSystem.Util.ReLocation();
        } else {
            pop_Sms.Hide();
            showMsg({ msg: "操作失败，请联系管理员" });
        }
    }   
</script>
<dx:ASPxCallback ID="reback" ClientIDMode="Static" runat="server" OnCallback="reback_Callback">
    <ClientSideEvents CallbackComplete="reback_CallbackComplete" />
</dx:ASPxCallback>
<dx:ASPxPopupControl ID="pop_Sms" ClientInstanceName="pop_Sms" runat="server" CloseAction="CloseButton"
    HeaderText="发送短信" AllowDragging="true" EnableAnimation="false" Modal="true" EnableViewState="false"
    Width="400px" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter"
    PopupVerticalOffset="-75" PopupHorizontalOffset="-85">
    <ContentCollection>
        <dx:PopupControlContentControl>
            <uc2:EditToolBar ID="EditToolBar2" runat="server" MenuTye="SmsMenu"></uc2:EditToolBar>
            <table cellpadding="4" cellspacing="0" class="editTable">
                <tr>
                    <td class="editFormCaption">
                        收信人<span class="red">*</span>:
                    </td>
                    <td class="editFormCell">
                        <cx:ASPxTextBox ID="txtReceiver" runat="server" Width="400" IsRequired="true">
                        </cx:ASPxTextBox>
                    </td>
                </tr>
                <tr>
                    <td class="editFormCaption">
                        短信内容:
                    </td>
                    <td class="editFormCell" colspan="3">
                        <cx:ASPxMemo ID="txtSmsContext" runat="server" Height="100%" Width="100%">
                        </cx:ASPxMemo>
                    </td>
                </tr>
            </table>
        </dx:PopupControlContentControl>
    </ContentCollection>
    <ContentStyle Paddings-Padding="0" />
</dx:ASPxPopupControl>
