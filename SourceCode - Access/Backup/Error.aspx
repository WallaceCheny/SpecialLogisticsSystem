<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="SpecialLogisticsSystem.AppPortal.Error" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <style type="text/css">
        #error
        {
            margin: 100px auto 50px auto;
            width: 360px;
            min-height: 190px;
            padding-left: 280px;
            background: url(/images/error_info.jpg) no-repeat;
        }
        #error h1
        {
            font-size: 15px;
            padding-top: 40px;
        }
        #error p
        {
            font-size: 13px;
            line-height: 30px;
        }
        #error a
        {
            color: #ff7e2d;
            font-size: 13px;
            text-decoration: none;
        }
        #error a:hover
        {
            text-decoration: underline;
        }
        .error_laste
        {
            margin: 10px auto;
            font-size: 13px;
            padding-top: 10px;
            border-top: 1px solid #bcbcbc;
            text-align: center;
        }
        .error_laste .link
        {
            padding-bottom: 10px;
        }
        .error_laste .link span
        {
            display: inline-block;
            width: 10px;
        }
    </style>
    <script type="text/javascript">
        var c = 5
        var t
        function timedCount() {
            //$('#timeCount').text(c);
            document.getElementById("timeCount").innerHTML = c;
            c = c - 1;
            t = setTimeout("timedCount()", 1000);
            if (c == 0) {
                stopCount();
                window.location = "/Default.aspx";
            }
        }

        function stopCount() {
            clearTimeout(t)
        }
    </script>
</head>
<body>
<form id="form1" runat="server">
    <div id="error">
        <h1>
            您浏览的网页暂时不能显示</h1>
        <p>
            你正在浏览的网页可能被删除、重命名或暂时不可用。
            <br />
            自动跳转<span id="timeCount">5</span>秒 如果你的浏览器没有跳转，<a href="/Default.aspx">请点这里>></a>
            <br />
            或在线给管理员留言, 给您造成的不便敬请见谅。
            <br />
            <asp:HyperLink ID="hyError" runat="server">错误日志</asp:HyperLink>
        </p>
    </div>
    </form>
</body>
</html>
