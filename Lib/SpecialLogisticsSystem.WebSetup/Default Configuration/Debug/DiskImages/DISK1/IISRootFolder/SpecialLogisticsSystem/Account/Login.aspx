<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="Login.aspx.cs"
    Inherits="SpecialLogisticsSystem.AppPortal.Account.Login" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <style type="text/css">
        html, body
        {
            margin: 0;
            padding: 0;
            height: 100%;
        }
        body
        {
            background-color: #fff;
        }
        #main
        {
            position: absolute;
            top: 40%;
            left: 40%;
            background: url(/images/new/loginDivbg.png);
            width: 556px;
            height: 250px;
            margin: -125px 0 0 -210px;
        }
        
        .loginbutton
        {
            background: #fff;
            background-image: url(/images/new/login_btn_login.png);
            height: 60px;
            width: 66px;
            border: 0;
            cursor: pointer;
        }
        
        .resetbutton
        {
            background: #fff;
            background-image: url(/images/new/login_btn_reset.png);
            height: 60px;
            width: 66px;
            border: 0;
            cursor: pointer;
        }
        
        .floater
        {
            width: 1px;
            padding-top: 18%;
        }
        
        .content
        {
            position: absolute;
            left: 195px;
            right: 0;
            top: 135px;
            bottom: 0;
            overflow: auto;
            height: 90px;
            width: 425px;
        }
        .side
        {
            position: absolute;
            left: 0;
            padding: 20px 0px 0px 15px;
        }
        .side .logo
        {
            background: url(/images/new/login_toplogo.png) no-repeat;
            width: 193px;
            height: 43px;
            padding-bottom: 70px;
        }
        .side p
        {
            padding: 3px 0 3px 22px;
            color: #6AA5C2;
            font-size: 14px;
            margin: 0px;
        }
        .side .site
        {
            background: url(/images/site.png) no-repeat 0px 3px;
        }
        .side .tel
        {
            background: url(/images/tel.png) no-repeat 0px 4px;
        }
        .bottom
        {
            position: absolute;
            width: 556px;
            margin: 0 auto;
            bottom: 0;
            left: 30px;
            text-align: center;
            padding: 0px 3px 5px 0px;
            font-size: 12px;
        }
        .content form
        {
            padding: 30px 0 0 0;
        }
        .frmCustom li
        {
            width: 320px;
        }
        .txtbox
        {
            border: 1px solid #ccc;
            width: 130px;
            padding: 2px;
        }
        .failureNotification
        {
            color: Red;
            font-size: 11px;
        }
    </style>
	<script type="text/javascript">
	    $(function () {
	        var isChrome = window.navigator.userAgent.indexOf("Chrome") !== -1 
	        if (!isChrome) {
	            window.location.href = "/WebSite/BrowserTips.htm";
	        }
	    });
	</script>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div class="floater">
    </div>
    <div id="main" class="centered">
        <div class="content" style="overflow-y: hidden">
            <asp:Login ID="LoginUser" runat="server" EnableViewState="true" RenderOuterTable="false"
                OnAuthenticate="login_Authenticate" FailureText="您的密码输入有错，请重新输入">
                <LayoutTemplate>
                    <div style="float: left; width: 180px; height: 100%">
                        <table style="width: 180px; height: 100%" border="0px">
                            <tr>
                                <td style="width: 240px; height: 25px">
                                    <asp:TextBox ID="UserName" runat="server" CssClass="txtbox" TabIndex="10"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <div style="margin-top: 5px">
                                        <asp:TextBox ID="Password" runat="server" CssClass="txtbox" TabIndex="11" TextMode="Password"></asp:TextBox>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                <asp:Label ID="FailureText" runat="server" EnableViewState="false" CssClass="failureNotification"></asp:Label>
                                    <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName"
                                        CssClass="failureNotification" ErrorMessage="用户名不能为空." ToolTip="用户名不能为空."></asp:RequiredFieldValidator>
                                    <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password"
                                        CssClass="failureNotification" ErrorMessage="密码不能为空." ToolTip="密码不能为空."></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div style="float: left;">
                        <div style="float: left">
                            <div style="float: left">
                                <asp:Button ID="LoginButton" runat="server" CommandName="Login" TabIndex="12" CssClass="loginbutton" />
                            </div>
                            <div style="float: left; margin-left: 10px;">
                                <button id="btn_Colse" class="resetbutton" tabindex="13" onclick="document.forms(0).reset();"
                                    type="button">
                                </button>
                            </div>
                        </div>
                    </div>
                </LayoutTemplate>
            </asp:Login>
        </div>
        <div class="bottom">
            Powered by YongLong Software@&nbsp;Copyright 2013 xxx All rights reserved.
        </div>
    </div>
</asp:Content>
