<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Area.ascx.cs" Inherits="SpecialLogisticsSystem.AppPortal.UserControls.Area" %>
<table>
    <tr>
        <td>
            <cx:ASPxComboBox ID="ddlProvince" ClientInstanceName="ddlProvince" runat="server" IsSetDefault="true"
                Width="62px">
                <ClientSideEvents SelectedIndexChanged="function(s, e) { ddlCity.PerformCallback(s.GetValue()); }" />
            </cx:ASPxComboBox>
        </td>
        <td>
            <cx:ASPxComboBox ID="ddlCity" ClientInstanceName="ddlCity"  IsSetDefault="true" OnCallback="ddlCity_Callback"
                runat="server" Width="62px">
                <ClientSideEvents SelectedIndexChanged="function(s, e) {  ddlDistrict.PerformCallback(s.GetValue()); }" />
            </cx:ASPxComboBox>
        </td>
        <td>
            <cx:ASPxComboBox ID="ddlDistrict" ClientInstanceName="ddlDistrict"  IsSetDefault="true" OnCallback="ddlDistrict_Callback"
                runat="server" Width="62px">
            </cx:ASPxComboBox>
        </td>
    </tr>
</table>
