<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Export.aspx.cs" Inherits="SpecialLogisticsSystem.AppPortal.Cm.Import" %>

<%@ Register Src="../UserControls/ImportControl.ascx" TagName="ImportControl" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="/Scripts/gridConfig.js" type="text/javascript"></script>
    <script src="/Scripts/viewSetting.js" type="text/javascript"></script>
    <script type="text/javascript">
        var viewSetting = {
		    FileUploadStart: function(s, e) {
			    showProcess({ isOpen: true, title: jslang.Tips, msg: jslang.PublishData })
			    //PopupProgressingPanel.Show();
                //pbProgressing.SetPosition(0);
                pnlProgressingInfo.SetContentHtml("");
			},
		    Upload: function (s,e) {
				window[s.cpClientInstanceName].Upload();
			},
            OnFileUploadComplete: function (s,e) {
                cbk_Import.PerformCallback(e.callbackData);
            },
            cbk_Import_CallbackComplete: function (s, e) {
                //var json = $.parseJSON(e.result);
                //showMsg({ msg: json.msg, isAlert: true });
				//lblMessage.SetText(e.result);
				//PopupProgressingPanel.Hide();
				showProcess({ isOpen: false });
				if(e.result!="")
				{
					showMsg({ msg: e.result, isAlert: true });
				}
            }
        };
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <dx:ASPxCallback ID="cbk_Import" runat="server" ClientInstanceName="cbk_Import" OnCallback="cbk_Import_Callback">
        <ClientSideEvents CallbackComplete="viewSetting.cbk_Import_CallbackComplete" />
    </dx:ASPxCallback>
    <dx:ASPxPopupControl ID="popImport" ClientInstanceName="popImport" runat="server" CloseAction="CloseButton"
        HeaderText="导入数据" AllowDragging="true" ShowOnPageLoad="True" EnableAnimation="false"
        EnableViewState="false" Width="450px" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter"
        PopupVerticalOffset="-75" PopupHorizontalOffset="-85">
        <ContentCollection>
            <dx:PopupControlContentControl>
                <dx:MainToolBar ID="viewMenu" runat="server" PageToolBar="Export" />
                <table cellpadding="4" cellspacing="0" class="editTable">
                    <uc1:ImportControl ID="customer" CurrentImportType="Customer" Note="注：系统已客户名称作为唯一标识。" Index="1" runat="server" />
                    <uc1:ImportControl ID="way" CurrentImportType="Way"  Note="注：系统已运单号作为唯一标识。" Index="2" runat="server" />
					  <uc1:ImportControl ID="stowage" CurrentImportType="Stowage"  Note="注：系统发车日期和车牌号作为唯一标识。" Index="3" runat="server" />
                </table>
				<dx:ASPxLabel ID="lblMessage"  ForeColor="Red" ClientInstanceName="lblMessage" runat="server">
				</dx:ASPxLabel> 
            </dx:PopupControlContentControl>
        </ContentCollection>
        <ContentStyle Paddings-Padding="0" />
    </dx:ASPxPopupControl>
	<dx:ASPxPopupControl ID="ASPxPopupControl1" runat="server" ClientInstanceName="PopupProgressingPanel"
        Modal="True" CloseAction="None" Width="400px" PopupHorizontalAlign="WindowCenter"
        PopupVerticalAlign="WindowCenter" AllowDragging="True" 
        HeaderText="正在导入...." ShowCloseButton="False" ShowPageScrollbarWhenModal="true">
        <ContentCollection>
            <dx:PopupControlContentControl ID="PopupControlContentControl1" runat="server">
                <table style="width: 100%;">
                    <tr>
                        <td style="width: 100%;">
                            <dx:ASPxProgressBar ID="pbProgressing" ClientInstanceName="pbProgressing" runat="server"
                                Width="100%">
                            </dx:ASPxProgressBar>
                        </td>
                    </tr>
                </table>
                <dx:ASPxPanel ID="pnlProgressingInfo" ClientInstanceName="pnlProgressingInfo" runat="server"
                    Width="100%">
                    <PanelCollection>
                        <dx:PanelContent ID="PanelContent1" runat="server">
                        </dx:PanelContent>
                    </PanelCollection>
                </dx:ASPxPanel>
            </dx:PopupControlContentControl>
        </ContentCollection>
    </dx:ASPxPopupControl>
</asp:Content>
