<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PrintPopup.ascx.cs"
    Inherits="SpecialLogisticsSystem.AppPortal.UserControls.PrintPopup" %>
<script type="text/javascript" language="javascript" src="/Scripts/LodopFuncs.js"></script>
<object id="LODOP" classid="clsid:2105C259-1E0C-4534-8141-A753534CB4CA" width="0"
    height="0">
    <embed id="LODOP_EM" type="application/x-print-lodop" width="0" height="0" pluginspage="/Documents/install_lodop32.exe"></embed>
</object>
<script type="text/javascript">
    $(function () {
        $("#btn_print_construct_a4").click(function () {
            $.post($("#btn_print_construct_a4").attr('url'), {}, function (result) {
                LODOP = getLodop(document.getElementById('LODOP'), document.getElementById('LODOP_EM'));
                //LODOP = getLodop(document.getElementById('LODOP'), '1111');
                LODOP.PRINT_INIT("施工单打印");
                LODOP.SET_PRINT_PAGESIZE(1, 2100, 1500, "A4");

                LODOP.ADD_PRINT_HTM(30, 35, 746, "100%", result);
                LODOP.SET_PRINT_STYLEA(1, "HOrient", 3);
                LODOP.SET_PRINT_STYLEA(1, "VOrient", 3);

                //LODOP.PRINT();
                LODOP.PREVIEW();
            });
        });

        $("#btn_print_construct_pin").click(function () {
	    var url=$("#btn_print_construct_pin").attr('url');
	    if(url.indexOf('ReportStowage') > 0)
	    {
		addTab("", '预装车清单', url, 'frame', 'print');
		return;
	    }
            $.post(url, {}, function (result) {
                LODOP = getLodop(document.getElementById('LODOP'), document.getElementById('LODOP_EM'));
                LODOP.PRINT_INIT("销售开单打印");
                LODOP.SET_PRINT_PAGESIZE(1, 2410,1400, "Letter");

                LODOP.ADD_PRINT_HTM("5mm","5mm","100%","100%", result);
                LODOP.SET_PRINT_STYLEA(1, "HOrient", 3);
                LODOP.SET_PRINT_STYLEA(1, "VOrient", 3);
                //LODOP.PRINT_DESIGN();
		//LODOP.SET_PRINT_STYLEA(0,"Angle",90);
                LODOP.PREVIEW();
            });
        });
    });
</script>
 <dx:ASPxPopupControl ID="pop_PrintConstruct" ClientInstanceName="pop_PrintConstruct"
        runat="server" CloseAction="CloseButton" HeaderText=" " AllowDragging="true"
        EnableAnimation="false" Modal="true" EnableViewState="false" Width="260px" PopupHorizontalAlign="WindowCenter"
        PopupVerticalAlign="WindowCenter" PopupVerticalOffset="-75" PopupHorizontalOffset="-85">
        <ContentCollection>
            <dx:PopupControlContentControl>
	     <table cellpadding="5" cellspacing="5" style="padding: 30px; Width:100%;">
                <tr>
                    <td style="text-align: center;">
                        <a id="btn_print_construct_pin" href="javascript:void(0);" target="_blank" class="easyui-linkbutton"
                            plain="false">确定打印</a>
                    </td>
                   <%-- <td>
                        <a id="btn_print_construct_a4" href="javascript:void(0);" class="easyui-linkbutton"
                            plain="false">A4格式</a>
                    </td>--%>
                </tr>
            </table>
                <%--  <table cellpadding="5" cellspacing="5" style="padding: 30px;">
                    <tr>
                        <td>
                            <a id="btn_print_construct_pin" href="javascript:void(0);" target="_blank" class="easyui-linkbutton"
                                plain="false">针式打印</a>
                        </td>
                        <td>
                            <a id="btn_print_construct_a4" href="javascript:void(0);" class="easyui-linkbutton"
                                plain="false">A4格式</a>
                        </td>
                    </tr>
                </table>--%>
            </dx:PopupControlContentControl>
        </ContentCollection>
        <ContentStyle Paddings-Padding="0" />
    </dx:ASPxPopupControl>
