<%@ Page Title="" Language="C#" MasterPageFile="~/MenuMaster.master" AutoEventWireup="true"
    CodeBehind="FinanceGraphic.aspx.cs" Inherits="SpecialLogisticsSystem.AppPortal.Analyze.FinanceGraphic" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
  <script type="text/javascript">
        gridConfig.chartID = 'chtFinance';
		function filterCondition() {
              return { input_date_begin: receive_date_start.GetValueString(), input_date_begin: receive_date_end.GetValueString()};
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
		<li  class="caption">
		    日期类型：
		</li>
		<li>
			<dx:ComboxSystem ID="comSystem" runat="server" codeType="ChartSearchType" Width="100" DefaultIndex="0"></dx:ComboxSystem>
		</li>
		<li  class="caption">
			结算日期：
		</li>
		 <li>
			 <ul>
			   <dx:DateRange ID="date_range"  runat="server"></dx:DateRange>
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
                <cx:WebChartControl ID="chtFinance" runat="server"
                    Width="1160px" Height="400px" OnCustomCallback="chtFinance_CustomCallback">
					<Titles>
						<dxcharts:ChartTitle Text="收支对比图"></dxcharts:ChartTitle>
					</Titles>
                </cx:WebChartControl>
            </td>
        </tr>
    </table>
</asp:Content>
