<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ThemeSelector.ascx.cs"
    Inherits="SpecialLogisticsSystem.AppPortal.UserControls.ThemeSelector" %>
<a class="DemoSprite Button" id="ThemeSelectorButton" onclick="ThemeSelectorPopup.Show();">
    主题</a>
<dx:ASPxPopupControl ID="ThemeSelectorPopup" ClientInstanceName="ThemeSelectorPopup"
    CssClass="ThemeSelectorPopup" runat="server" EnableTheming="false" PopupElementID="ThemeSelectorButton"
    PopupHorizontalAlign="LeftSides" ShowShadow="true" EnableAnimation="false" PopupAction="LeftMouseClick"
    RenderMode="Lightweight" PopupVerticalAlign="Below" PopupVerticalOffset="1" ShowHeader="False"
    EnableDefaultAppearance="false">
    <ContentCollection>
        <dx:PopupControlContentControl ID="PopupControlContentControl1" runat="server">
            <div id="ThemesContainer">
                <asp:Repeater runat="server" ID="ThemesContainerRepeater" EnableViewState="false">
                    <ItemTemplate>
                        <dx:ASPxMenu ID="themeGroupMenu" CssClass="ThemeGroupMenu" runat="server" EnableTheming="false"
                            EnableViewState="false" EnableDefaultAppearance="False" RenderMode="Lightweight"
                            ItemImagePosition="Top" OnDataBinding="Menu_DataBinding">
                            <ClientSideEvents ItemClick="function(s,e){ DXTheme.SetCurrentTheme(e.item.name);}" />
                        </dx:ASPxMenu>
                        <b class="Clear"></b>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </dx:PopupControlContentControl>
    </ContentCollection>
    <ClientSideEvents PopUp="DXTheme.ThemeSelectorPopupPopUp" CloseUp="DXTheme.ThemeSelectorPopupCloseUp" />
</dx:ASPxPopupControl>
