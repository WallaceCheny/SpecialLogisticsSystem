<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LinkMan.ascx.cs" Inherits="SpecialLogisticsSystem.AppPortal.UserControls.LinkMan" %>
<%@ Register Src="/UserControls/Area.ascx" TagName="Area" TagPrefix="uc1" %>
<%@ Register Src="/UserControls/CityLookUp.ascx" TagName="CityLookUp" TagPrefix="uc2" %>
<tr>
    <td class="editFormCaption">
        联系人<span class="red">*</span>：
    </td>
    <td class="editFormCell">
        <cx:ASPxTextBox ID="txtLink" runat="server" Width="170px" IsRequired="true">
        </cx:ASPxTextBox>
    </td>
    <td class="editFormCaption">
        省/市<span class="red">*</span>：
    </td>
    <td class="editFormCell">
        <uc2:CityLookUp ID="CityLookUp1" runat="server" IsRequired="true"/>
    </td>
</tr>
<tr>
    <td class="editFormCaption">
        手机<span class="red">*</span>：
    </td>
    <td class="editFormCell">
        <cx:ASPxTextBox ID="txtMobilePhone" runat="server" Width="170px"  IsRequired="true">
        </cx:ASPxTextBox>
    </td>
    <td class="editFormCaption">
        地址：
    </td>
    <td class="editFormCell">
        <cx:ASPxTextBox ID="txtAddress" runat="server" Width="170px">
        </cx:ASPxTextBox>
    </td>
</tr>
<tr>
    <td class="editFormCaption">
        电话：
    </td>
    <td class="editFormCell">
        <cx:ASPxTextBox ID="txtTelephone" runat="server" Width="170px">
        </cx:ASPxTextBox>
    </td>
    <td class="editFormCaption">
    </td>
    <td class="editFormCell">
    </td>
</tr>
<tr>
    <td>
        备注:
    </td>
    <td class="editFormCell" colspan="3">
        <dx:ASPxMemo ID="txtMemo" runat="server" Height="71px" Width="430px">
        </dx:ASPxMemo>
    </td>
</tr>
