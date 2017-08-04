<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EditToolBar.ascx.cs"
    Inherits="SpecialLogisticsSystem.AppPortal.UserControls.EditToolBar" %>
<dx:ASPxMenu runat="server" ID="saveMenu" RenderMode="Lightweight" ClientInstanceName="saveMenu"
    ItemAutoWidth="false" Width="100%" ShowAsToolbar="true">
    <Items>
        <dx:MenuItem Text="保存" Name="save" Image-SpriteProperties-CssClass="icon save" />
        <dx:MenuItem Text="保存并打印" Name="save_print" Image-SpriteProperties-CssClass="icon save_print" Visible="false"/>
        <dx:MenuItem Text="取消" Name="cancel" Image-SpriteProperties-CssClass="icon cancel" />
        <dx:MenuItem Text="状态" Name="building" Image-SpriteProperties-CssClass="last_menu" Visible="false">
            <Template>
                <asp:Panel ID="paneStatue" CssClass="last_menu" runat="server">
                    状态：<dx:ASPxLabel ForeColor="Red" ClientInstanceName="lblStatue" runat="server" ID="lblStatue"
                        Text="新建" />
                </asp:Panel>
            </Template>
        </dx:MenuItem>
    </Items>
    <Border BorderWidth="0" />
    <ClientSideEvents ItemClick="viewSetting.viewMenu_ItemClick" />
</dx:ASPxMenu>
