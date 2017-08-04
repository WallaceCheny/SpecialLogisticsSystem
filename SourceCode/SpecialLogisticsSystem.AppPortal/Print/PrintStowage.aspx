<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PrintStowage.aspx.cs" Inherits="SpecialLogisticsSystem.AppPortal.Print.PrintStowage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <style type="text/css">
        body
        {
            border: 0px;
            font-size: 12px;
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
    <table style="width: 201mm; height: 20mm; margin: 0 auto;" cellpadding="5" cellspacing="0"
        border="1">
        <thead>
            <tr>
                <td colspan="21" style="font-size: 14px; font-weight: bold; text-align: center; border: none;">
                    <%=branch.name %>
                    &nbsp;&nbsp;装车清单
                </td>
            </tr>
        </thead>
        <tbody>
            <tr style="text-align: left;">
                <td colspan="4">
                    单号：<%= way.way_number%>
                </td>
                <td colspan="6">
                    车牌号码:沪B24370
                </td>
                <td colspan="5">
                    发车时间：7-25
                </td>
                <td colspan="5">
                    预计到达：
                </td>
            </tr>
            <tr style="text-align: left;">
                <td colspan="4">
                    起运站点：晋江
                </td>
                <td colspan="6">
                    司机姓名：小崔
                </td>
                <td colspan="11">
                    随车电话：18961903513
                </td>
            </tr>
            <tr style="text-align: left;">
                <td colspan="4">
                    接车站点：宝山区陈广路958号润生物流园
                </td>
                <td colspan="6">
                    到达主任：小崔
                </td>
                <td colspan="11">
                    联系电话：18961903513
                </td>
            </tr>
            <tr style="text-align: left;">
                <td colspan="10">
                    司机预付款：5000元
                </td>
                <td colspan="11">
                    起运站配载负责人：电话;18065567902
                </td>
            </tr>
            <tr>
                <td>
                    序号
                </td>
                <td>
                    运单号
                </td>
                <td>
                    到站
                </td>
                <td>
                    发货单位
                </td>
                <td>
                    收货单位
                </td>
                <td>
                    收货人电话
                </td>
                <td>
                    货物名称
                </td>
                <td>
                    件数
                </td>
                <td>
                    重量
                </td>
                <td>
                    体积
                </td>
                <td>
                    已付
                </td>
                <td>
                    提付
                </td>
                <td>
                    签单
                </td>
                <td>
                    回扣
                </td>
                <td>
                    票税
                </td>
                <td>
                    接货费
                </td>
                <td>
                    中转费
                </td>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>
            <%int i = 0; var details = consume.Consume_Detail.ToList(); foreach (dynamic detail in details)
              {
                  i++;%>
            <tr>
                <td>
                    <%= i%>
                </td>
                <td>
                    <%Response.Write(detail.pro_name);%>
                    &nbsp;
                    <%Response.Write(detail.format);%>
                </td>
                <td>
                    <%= detail.unit_amt%>
                </td>
                <td>
                    <%= detail.number%>
                </td>
                <td>
                    <%= detail.sum_bal%>
                </td>
                <td colspan="2">
                    <%= detail.rate%>
                </td>
                <td>
                    <%= detail.account_det%>
                </td>
                <td>
                    <%= detail.mode_cd_name%>
                </td>
                <td>
                    <%= detail.CrewsSale_Name%>
                </td>
                <td>
                    <%= detail.Crews_Name%>
                </td>
            </tr>
            <%} %>
        </tbody>
    </table>
</body>
</html>
