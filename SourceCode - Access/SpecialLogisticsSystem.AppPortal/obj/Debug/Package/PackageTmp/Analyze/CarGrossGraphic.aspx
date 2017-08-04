<%@ Page Title="" Language="C#" MasterPageFile="~/MenuMaster.master" AutoEventWireup="true" CodeBehind="CarGrossGraphic.aspx.cs" Inherits="SpecialLogisticsSystem.AppPortal.Analyze.CarGrossGraphic" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
  <script type="text/javascript">
        gridConfig.chartID = 'chtStowageGross';
		function filterCondition() {
              return { stowage_number: txt_stowage_number.GetValue(), departure_time_begin: receive_date_start.lastSuccessText, departure_time_end: receive_date_end.lastSuccessText};
        }
		var viewSetting1 = {
		    chb_Bar_CheckedChanged: function (s, e) {
                chb_Bar.SetChecked(true);
                chb_Line.SetChecked(false);
                viewSetting.Search(filterCondition());
            },
            chb_Line_CheckedChanged: function (s, e) {
                chb_Bar.SetChecked(false)
                chb_Line.SetChecked(true);
                viewSetting.Search(filterCondition());
            },
		};
     </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SearchContent" runat="server">
    <ul id="viewSearch">
		<li class="caption">车次编号： </li>
        <li>
            <cx:ASPxTextBox ID="txt_stowage_number" runat="server" Width="140px">
            </cx:ASPxTextBox>
        </li>
        <li class="caption">发车日期： </li>
        <li>
            <ul>
                <dx:DateRange ID="date_range" runat="server"></dx:DateRange>
            </ul>
        </li>
		 <li>
			 <dx:ASPxCheckBox ID="chb_Bar" runat="server" ClientInstanceName="chb_Bar" Text="柱型图">
                    <ClientSideEvents CheckedChanged="viewSetting1.chb_Bar_CheckedChanged" />
              </dx:ASPxCheckBox>
		</li>
		<li>
			  <dx:ASPxCheckBox ID="chb_Line" runat="server" ClientInstanceName="chb_Line" Text="线型图">
                    <ClientSideEvents CheckedChanged="viewSetting1.chb_Line_CheckedChanged" />
              </dx:ASPxCheckBox>
		</li>
	</ul>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <table border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td align="center">
            </td>
        </tr>
        <tr>
            <td align="center" style="padding-left: 10px">
                <cx:WebChartControl ID="chtStowageGross" runat="server"
                    Width="1160px" Height="400px" OnCustomCallback="chtStowageGross_CustomCallback">
					<Titles>
						<dxcharts:ChartTitle Text="单车毛利图"></dxcharts:ChartTitle>
					</Titles>
                </cx:WebChartControl>
            </td>
        </tr>
    </table>
</asp:Content>