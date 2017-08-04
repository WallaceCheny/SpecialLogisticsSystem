<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Export.aspx.cs" Inherits="SpecialLogisticsSystem.AppPortal.Cm.Export" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
 <table>
        <tr>
            <td width="60px"   style="height:16px;" colspan="4">
                <dx:ASPxButton ID="btnHelp" runat="server" EnableTheming="False" Text="帮助" EnableDefaultAppearance="False"
                    AllowFocus="False" AutoPostBack="False" Width="60" Height="16" CssPostfix="botton">
                    <Image Url="../Scripts/themes/icons/help.png" Width="16px" Height="16px" />
                    <ClientSideEvents Click=" MicroTeam.Util.Help" />
                </dx:ASPxButton>
            </td>
        </tr>
        <tr>
            <th>
                客户：
            </th>
            <td>
                <asp:FileUpload ID="file_cust" runat="server" />
            </td>
            <td>
                <asp:Button ID="btn_cust" runat="server" Text="上传" OnClick="btn_cust_Click" /><asp:Label
                    ID="lab_cust" runat="server"></asp:Label>
            </td>
            <td>
                <a href="/files/excel/客户导入模版.xlsx" target="_blank">下载模板</a>
            </td>
        </tr>
        <tr>
            <td colspan="4" style="border-bottom: 1px solid #ddd; color: red;">
                注：首先要确认文件里的卡类型在系统中已经存在，如果不存在请先增加。
            </td>
        </tr>
    </table>
    <dx:ASPxMemo runat="server" Columns="100" Rows="10" ID="stock_msg" ClientInstanceName="stock_msg"
        ClientVisible="false" />
</asp:Content>
