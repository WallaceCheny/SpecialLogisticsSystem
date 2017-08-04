$(function () {
    var now = new Date(), hour = now.getHours();
    if (hour > 4 && hour < 6) { $("#labelwelcome").html(jslang.hour1) }
    else if (hour < 9) { $("#labelwelcome").html(jslang.hour2) }
    else if (hour < 12) { $("#labelwelcome").html(jslang.hour3) }
    else if (hour < 14) { $("#labelwelcome").html(jslang.hour4) }
    else if (hour < 17) { $("#labelwelcome").html(jslang.hour5) }
    else if (hour < 19) { $("#labelwelcome").html(jslang.hour6) }
    else if (hour < 22) { $("#labelwelcome").html(jslang.hour7) }
    else { $("#labelwelcome").html(jslang.hour8) }
    $('#tabs').tabs({ onClose: function (title) { if ($('[tab="' + title + '"]').length > 0) $('[tab="' + title + '"]').dialog("destroy"); } });
    $('#changePwd').window({ width: 300, modal: true, shadow: true, closed: true, resizable: false });
    //
    $('#editpass').click(function () { $('#changePwd').window('open'); });
    $('#btn_ChangePwd').click(function () {
        submitForm({
            formID: $('#form_Login'), url: '/Account/ChangePassword.aspx', isMsg: true,
            callback: function (data) {
                $('#form_Login').form('clear'); $('#changePwd').window('close');
            }
        });
    });
    $('#btn_Cancel_ChangePwd').click(function () { $('#changePwd').window('close'); })
    $('#loginOut').click(function () {
        $.messager.confirm(jslang.Tips, jslang.ConfirmLogout, function (r) {
            if (r) { location.href = '/account/logout.aspx'; }
        });
    });
    $('#sysRefresh').click(function () { location.reload(); });
    initLeftMenu();
    tabClose();
    tabCloseEven();
});
function _top(obj) {
    var top = obj.offset().top + obj.outerHeight();
    if (top < $(document).scrollTop()) top = obj.offset().top + obj.outerHeight();
    return top;
}
//初始化左侧
function initLeftMenu(menus) {
    if (menus) { _menus = $.parseJSON(menus); }
    $(_menus).each(function (i, n) {
        var menulist = '';
        menulist += '<ul class="sys_menus">';
        $(n.children).each(function (j, o) {
            menulist += '<li><div><a ref="' + o.id + '" title="' + o.tip + '" href="javascript:void(0)" rel="' +
            (o.attributes.loadType == 'report' && !o.attributes.url ? '/report?id=' + o.id : o.attributes.url) + '" urlType="' +
            o.attributes.loadType + '"><span class="' + (o.iconCls ? o.iconCls : 'application') + '" >&nbsp;</span><label class="nav">' +
            o.text + '</label></a></div></li> ';
        })
        menulist += '</ul>';
        $('#nav').accordion('add', {
            title: n.text,
            content: menulist,
            iconCls: (n.iconCls ? n.iconCls : 'put'), // + '_32X32',
            headerCls: 'nav_header', selected: i == 0
        });
    });
    $('.easyui-accordion li a').click(function () {
        var tabTitle = $(this).children('.nav').text();
        var urlType = $(this).attr("urlType") ? $(this).attr("urlType") : "frame";
        var menuid = $(this).attr("ref");
        var sepcialChar = $(this).attr("rel").indexOf('?') > 0 ? "&" : "?";
        var url = $(this).attr("rel"); //+sepcialChar + "menu_id=" + menuid + "&menu_name=" + escape(tabTitle);
        var icon = getIcon(menuid);
        addTab(menuid, tabTitle, url, urlType, icon);
        $('.easyui-accordion li div').removeClass("selected");
        $(this).parent().addClass("selected");
    });
}
//获取左侧导航的图标
function getIcon(menuid) {
    var icon = '';
    $(_menus).each(function (i, n) {
        $(n.children).each(function (j, o) {
            if (o.id == menuid) {
                icon = o.iconCls ? o.iconCls : 'application';
                return false;
            }
        })
    })
    return icon;
}
//增加tab
function addTab(menuid, subtitle, url, urlType, icon) {
    var tab = $('#tabs').tabs('getTab', subtitle);
    var tabid = '';
    if (tab) tabid = tab.panel('options').id;
    if (tab && menuid == tabid) {
        $('#tabs').tabs('select', subtitle);
    } else {
        if (tab) {
            updateTab(menuid, subtitle, url, urlType);
        } else {
            //subtitle = tab ? subtitle + '_' + menuid : subtitle;
            var tab = $('#tabs').tabs('getTab', subtitle);
            if (tab)
                $('#tabs').tabs('select', subtitle);
            else {
                if (urlType == 'load') {
                    $('#tabs').tabs('add', {
                        id: menuid, url: url, title: subtitle, urlType: urlType, icon: icon, closable: true,
                        href: createContent("menu_" + menuid, url, urlType)
                    });
                } else {
                    $('#tabs').tabs('add', {
                        id: menuid, url: url, title: subtitle, urlType: urlType, icon: icon, closable: true,
                        content: createContent("menu_" + menuid, url, urlType)
                    });
                }
            }
        }
    }
    tabClose();
}
//更新tab
function updateTab(menuid, subtitle, url, urlType) {
    var tab = $('#tabs').tabs('getTab', subtitle);
    $('#tabs').tabs('update', { tab: tab, options: { content: createContent("menu_" + menuid, url, urlType)} });
    $('#tabs').tabs('select', subtitle);
}
//增加URL框架
function createContent(id, url, urlType) {
    var c = '';
    if (urlType == 'load')
        c = !url ? 'about:blank;' : url;
    else
        c = '<iframe id="' + id + '" name="' + id + '" scrolling="auto" frameborder="0"  src="' + url + '" style="width:100%;height:100%;"></iframe>';
    return c;
}
function removeAccordion() {
    $(_menus).each(function (i, n) {
        $('#nav').accordion('remove', n.text);
    });
}
function getSelectedTab() {
    var currTab = $('#tabs').tabs('getSelected');
    return currTab.panel('options');
}

function getTab(title) {
    var currTab = $('#tabs').tabs('getTab', title);
    //return currTab.panel('options');
    return currTab;
}
function childCloseTab(title) {
    $('#tabs').tabs('close', title);
}
function refreshTab(title) {
    var currTab = $('#tabs').tabs('getTab', title);
    if (currTab == null) return;
    $('#tabs').tabs('select', title);
    var id = currTab.panel('options').id;
    var url = currTab.panel('options').url;
    var urlType = currTab.panel('options').urlType;
    if (urlType == 'load') {
        $('#tabs').tabs('update', {
            tab: currTab,
            options: { href: createContent(id, url, urlType) }
        });
    } else {
        $('#tabs').tabs('update', {
            tab: currTab,
            options: { content: createContent(id, url, urlType) }
        });
    }
}
function tabClose() {
    /*双击关闭TAB选项卡*/
    $(".tabs-inner").dblclick(function () {
        var subtitle = $(this).children(".tabs-closable").text();
        $('#tabs').tabs('close', subtitle);
    })
    /*为选项卡绑定右键*/
    $(".tabs-inner").bind('contextmenu', function (e) {
        $('#mm').menu('show', {
            left: e.pageX,
            top: e.pageY
        });
        var subtitle = $(this).children(".tabs-closable").text();
        $('#mm').data("currtab", subtitle);
        $('#tabs').tabs('select', subtitle);
        return false;
    });
}
//绑定右键菜单事件
function tabCloseEven() {
    //刷新
    $('#mm-tabupdate').click(function () {
        var currTab = $('#tabs').tabs('getSelected');
        var id = currTab.panel('options').id;
        var url = currTab.panel('options').url;
        var urlType = currTab.panel('options').urlType;
        if (url) {
            if (urlType == 'load') {
                $('#tabs').tabs('update', {
                    tab: currTab,
                    options: { href: createContent(id, url, urlType) }
                });
            } else {
                $('#tabs').tabs('update', {
                    tab: currTab,
                    options: { content: createContent(id, url, urlType) }
                });
            }
        }
    })
    //关闭当前
    $('#mm-tabclose').click(function () {
        var currtab_title = $('#mm').data("currtab");
        $('#tabs').tabs('close', currtab_title);
    })
    //全部关闭
    $('#mm-tabcloseall').click(function () {
        $('.tabs-inner .tabs-title.tabs-closable').each(function (i, n) {
            var t = $(n).text();
            $('#tabs').tabs('close', t);
        });
    });
    //关闭除当前之外的TAB
    $('#mm-tabcloseother').click(function () {
        $('#mm-tabcloseright').click();
        $('#mm-tabcloseleft').click();
    });
    //关闭当前右侧的TAB
    $('#mm-tabcloseright').click(function () {
        var nextall = $('.tabs-selected').nextAll();
        if (nextall.length == 0) {
            showMsg(jslang.Tips, jslang.NothingRightTab, true, null, 'error');
            return false;
        }
        nextall.each(function (i, n) {
            var t = $('a:eq(0) .tabs-title.tabs-closable', $(n)).text();
            $('#tabs').tabs('close', t);
        });
        return false;
    });
    //关闭当前左侧的TAB
    $('#mm-tabcloseleft').click(function () {
        var prevall = $('.tabs-selected').prevAll();
        if (prevall.length == 0) {
            showMsg(jslang.Tips, jslang.NothingLeftTab, true, null, 'error');
            return false;
        }
        prevall.each(function (i, n) {
            var t = $('a:eq(0) .tabs-title.tabs-closable', $(n)).text();
            $('#tabs').tabs('close', t);
        });
        return false;
    });
    //退出
    $("#mm-exit").click(function () {
        $('#mm').menu('hide');
    })
}
