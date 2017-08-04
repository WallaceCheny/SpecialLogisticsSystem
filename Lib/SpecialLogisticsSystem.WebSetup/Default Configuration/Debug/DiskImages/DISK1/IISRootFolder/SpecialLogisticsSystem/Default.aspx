<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SpecialLogisticsSystem.AppPortal.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>易运专线物流管理系统 1.0</title>
    <link rel="shortcut icon" href="/favicon.ico" type="image/x-icon" sizes="64x64"/>
    <link href="Styles/Site.css" rel="stylesheet" type="text/css" />
    <link href="/Scripts/themes/tanblue/easyui.css" rel="stylesheet" type="text/css" />
    <link href="/Scripts/themes/icon.css" rel="stylesheet" type="text/css" />
    <script src="/Scripts/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="/Scripts/jquery.easyui.min.js" type="text/javascript"></script>
    <script src="/Scripts/easyui-lang-zh_CN.js" type="text/javascript"></script>
    <script src="/Scripts/model_unit.js" type="text/javascript"></script>
    <script src="/Scripts/main.js" type="text/javascript"></script>
</head>
<body id="mainBody" class="easyui-layout" style="overflow-y: hidden" scroll="no">
    <script type="text/javascript">
      var _menus = $.parseJSON('<%=Menus%>');
      function selectMenu(index) {
          $("ul.bgcss li div").removeClass("selected");
          $("ul.bgcss li div").eq(index).addClass("selected");
      }
    </script>
    <div region="north" border="false" class="header">
        <div style="width: 100%; position: absolute; top: 10px; z-index: 999; color: #fff">
            <div style="float: right; margin-right: 100px">
                <div style="float: left">
                    <label id="labelwelcome"></label><asp:Literal ID="lblEmpName" runat="server"></asp:Literal>(<asp:Literal ID="lblUserName"
                        runat="server" Text="" />)，欢迎您！</div>
                <div style="float: left; margin-left: 10px;">
                    <a style="color: #fff" href="javascript:void(0);" id="editpass">修改密码</a></div>
                <div style="float: left; margin-left: 10px;">
                    <a style="color: #fff" href="javascript:void(0);" id="loginOut" class="last">退出登录</a></div>
            </div>
        </div>
        <div class="topnav clearfix" style="position: absolute; top: 30px; z-index: 999;
            width: 100%; text-align: right">
            <div style="float: right; margin-right: 10px">
                <ul class="bgcss">
                    <li class="first">
                        <div class="selected">
                            <a id="todayTip" href="#">今日提醒</a></div>
                    </li>
                    <li>
                        <div>
                            <a href="default.aspx">刷新</a></div>
                    </li>
                    <li class="last">
                        <div>
                            <a href="#">联系我们</a></div>
                    </li>
                </ul>
            </div>
        </div>
        <div id="header" style="height: 73px;">
            <div style="width: 100%; background: url(Images/new/header_right.png) repeat-x;">
                <div>
                    <img src="Images/new/header_left.png" width="313px" height="73px" alt="" />
                </div>
            </div>
            <div class="clear">
            </div>
        </div>
    </div>
    <div region="south" style="height:1px; line-height:1px; text-align: center">
        <div class="footer">
            copyright@2013 by </div>
    </div>
    <div region="west" split="true" style="width: 170px; border: 0px; border-right: 1px solid #bac6d4;
        overflow: hidden;">
        <div id="nav" class="easyui-accordion" fit="true" border="false">
        </div>
    </div>
    <div region="center" style="background: #eee; overflow-y: hidden; border: 0px;">
        <div id="tabs" class="easyui-tabs" fit="true" border="false">
            <div title="首页" style="overflow: hidden;">
                <iframe id="WebSiteUrl" name="WebSiteUrl" scrolling="auto" frameborder="0" src="/WebSite/Default.htm"
                    style="width: 100%; height: 100%;"></iframe>
            </div>
        </div>
    </div>
    <div id="changePwd" closed="true" class="easyui-window" title="修改密码" collapsible="false"
        minimizable="false" maximizable="false" icon="user" style="width: 300px; height: 210px;
        padding: 5px; background: #fafafa;">
        <div class="easyui-layout" fit="true">
            <div region="center" border="false" style="padding: 10px;">
                <form id="form_Login" method="post">
                <table cellpadding="3">
                    <tr>
                        <td>
                            原密码：
                        </td>
                        <td>
                            <input id="txtOldPass" name="oldPassword" type="password" class="easyui-validatebox"
                                required="true" missingmessage="请填写原密码" validtype="length[6,20]" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            新密码：
                        </td>
                        <td>
                            <input id="txtNewPass" name="newPassword" type="password" class="easyui-validatebox"
                                required="true" missingmessage="请填写原密码" validtype="length[6,20]" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            确定密码：
                        </td>
                        <td>
                            <input id="txtRePass" type="password" class="easyui-validatebox" required="true"
                                missingmessage="请填写确定密码" validtype="equalTo['#txtNewPass']" />
                        </td>
                    </tr>
                </table>
                </form>
            </div>
            <div region="south" border="false" style="text-align: right; height: 30px; line-height: 30px;">
                <a id="btn_ChangePwd" class="easyui-linkbutton" href="javascript:void(0)">保存</a>
                <a id="btn_Cancel_ChangePwd" class="easyui-linkbutton" href="javascript:void(0)">取消</a>
            </div>
        </div>
    </div>
    <div id="mm" class="easyui-menu" style="width: 150px;">
        <div id="mm-tabupdate">
            刷新</div>
        <div class="menu-sep">
        </div>
        <div id="mm-tabclose">
            关闭</div>
        <div id="mm-tabcloseall">
            关闭全部</div>
        <div id="mm-tabcloseother">
            关闭其它</div>
        <div class="menu-sep">
        </div>
        <div id="mm-tabcloseright">
            关闭右边</div>
        <div id="mm-tabcloseleft">
            关闭左边</div>
    </div>
</body>
</html>
