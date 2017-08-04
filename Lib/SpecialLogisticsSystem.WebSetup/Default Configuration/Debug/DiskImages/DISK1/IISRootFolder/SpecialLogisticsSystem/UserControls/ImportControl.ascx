<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ImportControl.ascx.cs"
    Inherits="SpecialLogisticsSystem.AppPortal.UserControls.ImportControl" %>
<tr>
    <th>
        <dx:ASPxLabel ID="lblTitle" runat="server" Text="客户资料：">
        </dx:ASPxLabel>  
    </th>
    <td class="editFormCell">
        <cx:ASPxUploadControl ID="ASPxUploadControl1" ClientInstanceName="uploader" runat="server" Size="30" OnFileUploadComplete="ASPxUploadControl1_FileUploadComplete">
	   <ClientSideEvents FileUploadStart="viewSetting.FileUploadStart" FileUploadComplete="viewSetting.OnFileUploadComplete" />
        </cx:ASPxUploadControl>
    </td>
    <td>
        <cx:ASPxButton ID="btnSubmit" runat="server" Text="导入" AutoPostBack="False">
            <ClientSideEvents Click="function(s, e) { window[s.cpClientInstanceName].Upload(); }" />
        </cx:ASPxButton>
    </td>
    <td>
        <dx:ASPxHyperLink ID="linkModel" runat="server" Text="下载模板"></dx:ASPxHyperLink>
    </td>
</tr>
<tr>
    <td colspan="4" style="border-bottom: 1px solid #ddd; color: red;">
        <dx:ASPxLabel ID="lblNote" runat="server" Text="注：">
        </dx:ASPxLabel>  
    </td>
</tr>
