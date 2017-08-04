<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MainToolBar.ascx.cs"
    Inherits="SpecialLogisticsSystem.AppPortal.UserControls.MainToolBar" %>
<dx:ASPxMenu runat="server" ID="viewMenu" RenderMode="Lightweight" ClientInstanceName="viewMenu"
    ItemAutoWidth="false" Width="100%" ShowAsToolbar="true" OnItemClick="viewMenu_ItemClick">
    <Items>
        <dx:MenuItem Text="新增" Name="add" Image-SpriteProperties-CssClass="icon add" />
        <dx:MenuItem Text="修改" Name="edit" Image-SpriteProperties-CssClass="icon edit" />
        <dx:MenuItem Text="删除" Name="delete" Image-SpriteProperties-CssClass="icon delete" />
        <dx:MenuItem Text="客户结算" Name="settle" Image-SpriteProperties-CssClass="icon settle"
            Visible="false" />
        <dx:MenuItem Text="重置默认密码" Name="set_password" Image-SpriteProperties-CssClass="icon wrench"
            Visible="false" />
        <dx:MenuItem Text="下达入库" Name="instorage" Image-SpriteProperties-CssClass="icon add"
            Visible="false" />
        <dx:MenuItem Text="反下达" Name="outstorage" Image-SpriteProperties-CssClass="icon add"
            Visible="false" />
        <dx:MenuItem Text="打印运单" Name="print" Image-SpriteProperties-CssClass="icon print"
            Visible="false" />
        <dx:MenuItem Text="确认到货" Name="confirm" Image-SpriteProperties-CssClass="icon confirm"
            Visible="false" />
        <dx:MenuItem Text="签收" Name="signed" Image-SpriteProperties-CssClass="icon signed"
            Visible="false" />
        <dx:MenuItem Text="发短信" Name="message" Image-SpriteProperties-CssClass="icon message"
            Visible="false" />
        <dx:MenuItem Text="保存" Name="save_call" Image-SpriteProperties-CssClass="icon save"
            Visible="false" />
        <dx:MenuItem Text="导出" Name="export" Image-SpriteProperties-CssClass="icon report">
            <Items>
                <dx:MenuItem Text="导出XLSX" Name="XLSX" Image-SpriteProperties-CssClass="page_white_xlsx icon">
                </dx:MenuItem>
                <dx:MenuItem Text="导出XLS" Name="XLS" Image-SpriteProperties-CssClass="page_white_excel icon">
                </dx:MenuItem>
            </Items>
        </dx:MenuItem>
        <dx:MenuItem Text="刷新" Name="refresh" Image-SpriteProperties-CssClass="icon refresh" />
        <dx:MenuItem Text="帮助" Name="help" Image-SpriteProperties-CssClass="icon help">
	    <Items>
                <dx:MenuItem Text="文字-帮助" Name="word_help" Image-SpriteProperties-CssClass="word_help icon">
                </dx:MenuItem>
                <dx:MenuItem Text="视频-帮助" Name="video_help" Image-SpriteProperties-CssClass="video_help icon">
                </dx:MenuItem>
            </Items>
	</dx:MenuItem>
    </Items>
    <Border BorderWidth="0" />
    <ClientSideEvents ItemClick="viewSetting.viewMenu_ItemClick" />
</dx:ASPxMenu>
<dx:ASPxGridViewExporter ID="gridExport" runat="server">
</dx:ASPxGridViewExporter>
