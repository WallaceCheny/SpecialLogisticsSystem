<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PrintWay.aspx.cs" Inherits="SpecialLogisticsSystem.AppPortal.Print.PrintWay" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        body
        {
            border: 0px;
            font-size: 13px;
        }
        table
        {
            border-right: 1px solid black;
            border-bottom: 1px solid black;
        }
        table td
        {
            border-top: 1px solid black;
            border-left: 1px solid black;
            padding: 5px;
            white-space: nowrap;
        }
    </style>
</head>
<body>
    <table style="width: 201mm; height: 20mm; margin: 0 auto; border: none;" cellpadding="5"
        cellspacing="0" border="0">
        <thead>
            <tr>
                <td colspan="11" style="font-size: 18px; font-weight: bold; text-align: center; border: none;">
                    <%=branch.name %>
                    &nbsp;&nbsp;托运单
                </td>
            </tr>
        </thead>
        <tbody>
            <tr style="text-align: left;">
                <td colspan="8" style="border: none;">
                </td>
                <td colspan="3" style="border: none; text-align: right;">
                    单号：<%= way.way_number%>
                </td>
            </tr>
            <tr style="text-align: left;">
                <td style="border: none;">
                    起站：
                    <%= way.start_city%>
                </td>
                <td colspan="9" style="border: none;">
                    &nbsp;&nbsp;
                </td>
                <td style="border: none;">
                    到站：
                    <%= way.end_city%>
                </td>
            </tr>
            <tr style="text-align: left;">
                <td style="border: none;">
                    托运日期:
                    <%= way.receive_date%>
                </td>
                <td colspan="9" style="border: none;">
                    &nbsp;&nbsp;
                </td>
                <td style="border: none;">
                    交货方式:<%= way.delivery_type_name%>
                </td>
            </tr>
        </tbody>
    </table>
    <table style="width: 201mm; height: 80mm; margin: 0 auto; text-align: center;" cellpadding="5"
        cellspacing="0" border="0">
        <tbody>
            <tr>
                <td rowspan="3">
                    托运人
                </td>
                <td>
                    单位
                </td>
                <td colspan="3">
                    <%= way.deliver_name%>
                </td>
                <td rowspan="3">
                    收货人
                </td>
                <td>
                    单位
                </td>
                <td colspan="3">
                    <%= way.consignee_name%>
                </td>
            </tr>
            <tr>
                <td>
                    电话
                </td>
                <td colspan="3">
                    <%= way.deliver_mobile%>
                </td>
                <td>
                    电话
                </td>
                <td colspan="3">
                    <%= way.consignee_mobile%>
                </td>
            </tr>
            <tr>
                <td>
                    地址
                </td>
                <td colspan="3">
                    <%= way.deliver_address%>
                </td>
                <td>
                    地址
                </td>
                <td colspan="3">
                    <%= way.consignee_address%>
                </td>
            </tr>
            <tr>
                <td>
                    货物名称
                </td>
                <td>
                    包装
                </td>
                <td>
                    件数
                </td>
                <td>
                    重量(吨)
                </td>
                <td>
                    体积m3
                </td>
                <td>
                    运费(元)
                </td>
                <td style="text-align: left;" colspan="4" rowspan="4">
                    本公司声明：托运的货物如果损失或被盗，有<br />
                    保价的，货物实际损失高的，按声明价值赔偿<br />
                    ，货物实际损失底的，按货物实际损失赔偿；<br />
                    未保价的按不高于300元给予赔偿。
                </td>
            </tr>
            <tr>
                <td>
                    <%= way.production_name%>
                </td>
                <td>
                    <%= way.package_type_name%>
                </td>
                <td>
                    <%= way.production_number%>
                </td>
                <td>
                    <%= way.production_weight%>
                </td>
                <td>
                    <%= way.production_size%>
                </td>
                <td>
                    <%= way.freight%>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    运杂费合计
                </td>
                <td colspan="5">
                    <%= way.freight_chinese%>
                </td>
                <td style="text-align: right;">
                    代收货款
                </td>
                <td colspan="3">
                    <%= way.agency_fund%>
                </td>
            </tr>
            <tr>
                <td>
                    现付
                </td>
                <td>
                    <%= way.spot_payment%>
                </td>
                <td>
                    提付
                </td>
                <td>
                    <%= way.pick_payment%>
                </td>
                <td>
                    回付
                </td>
                <td>
                    <%= way.back_payment%>
                </td>
                <td colspan="4">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td rowspan="2">
                    协<br />
                    定<br />
                    事<br />
                    宜
                </td>
                <td colspan="5" rowspan="2" style="text-align: left;">
                    ①托运的货物外包装必须符合卡车运输装载规范,货物交接权以外包 装表面验收完<br />
                    好为准.在外包装完好或无异状的情况下,托运人自行承 担包装内货物的损坏、缺少。<br />
                    ②托运人不得伪报货物名称，严禁夹带 危险品及过奖规定的违禁品，因此给承运人<br />
                    造成的损失由托运人承担 。③本公司提供保价运输服务，托运人只能选择保价或<br />
                    不保价运输， 选择报价运输的，按声明价格的3‰缴纳保价费。④货物运抵目的地<br />
                    后承运人免费存储3天，超过3天收货人必须交仓储费，超过30天承运 人有权处置
                </td>
                <td colspan="4" style="text-align: left; vertical-align: top; padding: 0; margin: 0">
                    本人已阅读并同意
                    <br />
                    <br />
                    <br />
                    托运人签字:
                </td>
            </tr>
            <tr>
                <td colspan="4" style="text-align: left; vertical-align: top;">
                    承运人签字:
                </td>
            </tr>
        </tbody>
    </table>
</body>
</html>
