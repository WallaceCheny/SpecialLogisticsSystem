<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="SendEmail.Web._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <table style="width: 100%;">
        <tr>
            <td>
                收件人：
            </td>
            <td>
                <asp:TextBox ID="txtReceiver" runat="server" Width="691px"></asp:TextBox>
            </td>
            <td>
            
            </td>
        </tr>
        <tr>
            <td>
                主题：
            </td>
            <td>
                <asp:TextBox ID="txtSubject" runat="server" Width="691px"></asp:TextBox>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                内容：
            </td>
            <td>
                <asp:TextBox ID="txtContent" TextMode="MultiLine" runat="server" Height="268px" Width="691px"></asp:TextBox>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
                <asp:Button ID="btnSend" runat="server" Text="发送" OnClick="btnSend_Click" />
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
</asp:Content>
