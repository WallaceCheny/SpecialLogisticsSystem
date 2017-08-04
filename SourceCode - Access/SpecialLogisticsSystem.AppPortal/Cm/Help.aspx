<%@ Page Title="" Language="C#" MasterPageFile="~/MenuMaster.Master" AutoEventWireup="true"
    CodeBehind="Help.aspx.cs" Inherits="SpecialLogisticsSystem.AppPortal.Cm.Help" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="/Styles/Help.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        gridConfig.popupID = "popHelp";
        gridConfig.callBackID = "reback";
        var viewSetting = {
            viewSplitter_PaneResized: function (s, e) {
                if (e.pane.name === "GridPane") {
                    helpHtmlEditor.SetHeight(e.pane.GetClientHeight() + 200);
                }
            },
            viewMenu_ItemClick: function (s, e) {
                var name = e.item.name;
                switch (name) {
                    case 'save':
                        reback.PerformCallback();
                        break;
                    case 'cancel':
                        //gvw_Car.CancelEdit();
                        break;
                }
            }
        };
        function reback_CallbackComplete(s, e) {
            if (e.result == "true") {
                SpecialLogisticsSystem.Util.ReLocation();
            } else {
                popHelp.Hide();
                showMsg({ msg: "操作失败，请联系管理员" });
            }
        }   
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:HiddenField ID="hideMenuID" runat="server" />
    <dx:ASPxCallback ID="reback" ClientIDMode="Static" runat="server" OnCallback="reback_Callback">
        <ClientSideEvents CallbackComplete="reback_CallbackComplete" />
    </dx:ASPxCallback>
    <asp:Panel ID="Panel1" runat="server" Width="100%" Height="100%" ScrollBars="Both"
        Style="margin-right: 145px;background-color:White; padding:10px;">
        <asp:Literal ID="literalHelp" runat="server"></asp:Literal>
    </asp:Panel>
    <dx:ASPxPopupControl ID="popHelp" ClientInstanceName="popHelp" runat="server" CloseAction="CloseButton"
        HeaderText="编辑帮助信息" AllowDragging="true" EnableAnimation="false" Modal="true"
        EnableViewState="false" Width="900px" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter">
        <ContentCollection>
            <dx:PopupControlContentControl>
                <dx:EditToolBar ID="EditToolBar1" runat="server" MenuTye="HelpMenu"></dx:EditToolBar>
                <dx:ASPxHtmlEditor ID="helpHtmlEditor" runat="server" ClientInstanceName="helpHtmlEditor"
                    Width="100%">
                    <SettingsImageUpload UploadImageFolder="~/UploadImages/">
                        <ValidationSettings AllowedFileExtensions=".jpe,.jpeg,.jpg,.gif,.png" MaxFileSize="500000">
                        </ValidationSettings>
                    </SettingsImageUpload>
					<CssFiles>
						<dx:HtmlEditorCssFile FilePath="/Styles/Help.css"></dx:HtmlEditorCssFile>
					</CssFiles>
                </dx:ASPxHtmlEditor>
            </dx:PopupControlContentControl>
        </ContentCollection>
        <ContentStyle Paddings-Padding="0" />
    </dx:ASPxPopupControl>
</asp:Content>
