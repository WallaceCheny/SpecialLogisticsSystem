<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="Config.aspx.cs" Inherits="SpecialLogisticsSystem.AppPortal.Cm.Config" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
 <script src="/Scripts/Theme.js" type="text/javascript"></script>
 <script src="/Scripts/gridConfig.js" type="text/javascript"></script>
 <script type="text/javascript">
		gridConfig.callBackID = 'cbk_input';
        var viewSetting1 = {
			cbk_input_CallbackComplete: function (s, e) {
                var json = $.parseJSON(e.result);
                showMsg({ msg: json.msg });
            }
        };
</script>
<script src="/Scripts/viewSetting.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<dx:ASPxCallback ID="cbk_input" runat="server" ClientInstanceName="cbk_input" OnCallback="cbk_input_Callback">
        <ClientSideEvents CallbackComplete="viewSetting1.cbk_input_CallbackComplete" />
    </dx:ASPxCallback>
    <dx:ASPxPopupControl ID="popConfig" ClientInstanceName="popConfig" runat="server" CloseAction="CloseButton"
        HeaderText="参数设置" AllowDragging="true" ShowOnPageLoad="True" EnableAnimation="false"
        EnableViewState="false" Width="450px" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter"
        PopupVerticalOffset="-75" PopupHorizontalOffset="-85">
        <ContentCollection>
            <dx:PopupControlContentControl>
                <dx:MainToolBar ID="viewMenu" runat="server" PageToolBar="Config" />
					<table cellpadding="4" cellspacing="0" class="editTable">
							<tr>
								<td align="right" class="editFormCaption">
									主题设置：
								</td>
								<td class="editFormCell">
									<dx:ThemeSelector ID="cbbTheme" runat="server">
								    </dx:ThemeSelector>
								</td>
								<td align="right" class="editFormCaption">
									查询类型：
								</td>
								<td class="editFormCell">
									<dx:ComboxSystem ID="search_type" runat="server" codeType="SearchType" IsRequrided="true"></dx:ComboxSystem>
								</td>
							</tr>
							<tr>
								<td align="right" class="editFormCaption">
									从：
								</td>
								<td class="editFormCell">
									<dx:CityLookUp ID="start_city" runat="server" Index="1" IsRequrided="true">
									</dx:CityLookUp>
								</td>
								<td align="right" class="editFormCaption">
									到：
								</td>
								<td class="editFormCell">
									<dx:CityLookUp ID="end_city" runat="server" Index="2" IsRequrided="true"></dx:CityLookUp>
								</td>
							</tr>
							<tr>
								<td align="right" class="editFormCaption">
									
								</td>
								<td class="editFormCell">
									<cx:ASPxCheckBox ID="get_free" runat="server" Text="接货费免费" Checked="false" EnableViewState="false" />
								</td>
								<td align="right" class="editFormCaption">
									
								</td>
								<td class="editFormCell">
                                <cx:ASPxCheckBox ID="other_free" runat="server" Text="其他费免费" Checked="false" EnableViewState="false" />
									<cx:ASPxCheckBox ID="set_free" runat="server" Text="送货费免费" Checked="false" EnableViewState="false"  Visible="false" />
								</td>
							</tr>
							<%--<tr>
								<td align="right" class="editFormCaption">
									
								</td>
								<td class="editFormCell">
									<cx:ASPxCheckBox ID="other_free" runat="server" Text="其他费免费" Checked="false" EnableViewState="false" />
								</td>
								<td align="right" class="editFormCaption">
									
								</td>
								<td class="editFormCell">
								
								</td>
							</tr>--%>
							<tr>
								<td align="right" class="editFormCaption">
									短信帐号：
								</td>
								<td class="editFormCell">
									<cx:ASPxTextBox ID="txt_account_name"  runat="server" Width="140px">
									</cx:ASPxTextBox>
								</td>
								<td align="right" class="editFormCaption">
									短信密码：
								</td>
								<td class="editFormCell">
                                    <asp:TextBox ID="txt_account_password" TextMode="Password" runat="server"></asp:TextBox>
								</td>
							</tr>
							<tr>
								<td align="right" class="editFormCaption">
									短信签名：
								</td>
								<td class="editFormCell">
									<cx:ASPxTextBox ID="txt_sms_singer"  runat="server" Width="140px">
									</cx:ASPxTextBox>
								</td>
								<td colspan="2">
									<a href="http://www.lx198.com" 
									target="_blank" style="text-decoration:underline;">查看短信详细信息（http://www.lx198.com）</a>
								</td>
							</tr>
					</table>
			      </dx:PopupControlContentControl>
        </ContentCollection>
        <ContentStyle Paddings-Padding="0" />
    </dx:ASPxPopupControl>
</asp:Content>
