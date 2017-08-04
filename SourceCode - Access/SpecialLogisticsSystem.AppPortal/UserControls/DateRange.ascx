<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DateRange.ascx.cs" Inherits="SpecialLogisticsSystem.AppPortal.UserControls.DateRange" %>
<ul>
    <li>
        <cx:ASPxDateEdit ID="receive_date_start" runat="server" Width="100" />
    </li>
    <li class="caption">- </li>
    <li>
        <cx:ASPxDateEdit ID="receive_date_end" DefaultToday="true" runat="server" Width="100" />
    </li>
</ul>
