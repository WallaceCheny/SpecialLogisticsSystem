<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SenderAndReceiver.ascx.cs"
    Inherits="SpecialLogisticsSystem.AppPortal.UserControls.SenderAndReceiver" %>
<%@ Register Src="/UserControls/CustomerLookUp.ascx" TagName="CustomerLookUp" TagPrefix="uc1" %>
	<dx:ASPxCallback ID="cbk_select" runat="server" ClientInstanceName="cbk_select" OnCallback="cbk_select_Callback">
    </dx:ASPxCallback>
<tr>
    <td class="editFormCaption">
        发货人<span class="red">*</span>:
    </td>
    <td class="editFormCell">
        <uc1:CustomerLookUp ID="deliver_id" runat="server" CustomerEnum="Deliver" IsRequrided="true"
            ClientSideJs="viewSetting1.glp_cust_ValueChanged" Index="1"></uc1:CustomerLookUp>
    </td>
    <td class="editFormCaption">
        联系电话<span class="red">*</span>:
    </td>
    <td class="editFormCell">
        <cx:ASPxTextBox ID="deliver_mobile" runat="server" Width="170">
        </cx:ASPxTextBox>
    </td>
    <td class="editFormCaption">
        地区<span class="red">*</span>:
    </td>
    <td class="editFormCell">
        <cx:ASPxTextBox ID="deliver_area" runat="server" Width="170">
        </cx:ASPxTextBox>
    </td>
    <td class="editFormCaption">
        地址:
    </td>
    <td class="editFormCell">
        <cx:ASPxTextBox ID="deliver_address" runat="server" Width="170">
        </cx:ASPxTextBox>
    </td>
</tr>
<tr>
    <td class="editFormCaption">
        收货人<span class="red">*</span>:
    </td>
    <td class="editFormCell">
        <uc1:CustomerLookUp ID="consignee_id" runat="server" CustomerEnum="Consignee" IsRequrided="true"
            ClientSideJs="viewSetting1.glp_cust_ValueChanged" Index="2"></uc1:CustomerLookUp>
    </td>
    <td class="editFormCaption">
        联系电话<span class="red">*</span>:
    </td>
    <td class="editFormCell">
        <cx:ASPxTextBox ID="consignee_mobile" runat="server" Width="170">
        </cx:ASPxTextBox>
    </td>
    <td class="editFormCaption">
        地区<span class="red">*</span>:
    </td>
    <td class="editFormCell">
        <cx:ASPxTextBox ID="consignee_area" runat="server" Width="170">
        </cx:ASPxTextBox>
    </td>
    <td class="editFormCaption">
        地址:
    </td>
    <td class="editFormCell">
        <cx:ASPxTextBox ID="consignee_address" runat="server" Width="170">
        </cx:ASPxTextBox>
    </td>
</tr>
