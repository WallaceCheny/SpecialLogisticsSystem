function addTab(menuid, subtitle, url, urlType, icon, prefix_Title) {
    if (top != self)
        top.addTab(menuid, subtitle, url, urlType, icon, prefix_Title);
    else
        location.href = url;
}
function updateTab(menuid, subtitle, url, urlType) {
    if (top != self)
        top.updateTab(menuid, subtitle, url, urlType);
    else
        location.href = url;
}
function getSelectedTab(title) {
    if (top != self)
        return top.getSelectedTab();
    return '';
}
function getTab(title) {
    if (top != self)
        return top.getTab(title);
    return '';
}
function childCloseTab(title) {
    if (top != self)
        top.childCloseTab(title);
}
function refreshTab(title) {
    if (top != self)
        top.refreshTab(title);
}
function updateAccordion(menus) {
    if (top != self) {
        top.removeAccordion();
        top.initLeftMenu(menus);
    }
}
function setLangLabel(obj, type, module) {
    var lv = $(obj).prev().val();
    $('<div id="dialog_language" />').appendTo(window.document.body).customdialog({ title: jslang.SetLangLabel, width: 300, height: 200,
        href: '/sys/pageloading/languagedetail?item=' + lv + '&type=' + type + '&module=' + module,
        saveUrl: '/sys/languagesave', isFailBack: true, saveCallback: function (data) { if (!data.success) { showMsg(jslang.Tips, data.msg); } }
    });
    $('#dialog_language').customdialog('open');
}
function iframeSubmit(url) {
    var id = "easyui_frame_" + (new Date().getTime());
    var frame = $("<iframe id=" + id + " name=" + id + "></iframe>").attr('src', window.ActiveXObject ? "javascript:false" : "about:blank").css({ position: "absolute", top: -1000, left: -1000 });
    frame.appendTo("body");
    frame.bind('load', cb);
    $('#' + id).attr('src', url);
    var _expNum = 10;
    function cb() {
        frame.unbind();
        var body = $('#' + id).contents().find("body");
        var data = body.html();
        if (data == "") {
            if (--_expNum) {
                setTimeout(cb, 100);
                return;
            }
            return;
        }
        var ta = body.find(">textarea");
        if (ta.length) {
            data = ta.val();
        } else {
            var pre = body.find(">pre");
            if (pre.length) {
                data = pre.html();
            }
        }
        setTimeout(function () {
            frame.unbind();
            frame.remove();
        }, 100);
        data = $.parseJSON(data);
        showMsg({ msg: data.msg });
    }
}
//弹出框以及系统消息框
function showMsg(sets) {
    var settings = { title: jslang.Tips, msg: '', isAlert: null, callback: null, icon: 'info' };
    sets = sets || {};
    $.extend(settings, sets);
    if (settings.isAlert !== undefined && settings.isAlert) {
        top.$.messager.alert(settings.title, settings.msg, settings.icon, function () {
            if ($.isFunction(settings.callback))
                settings.callback.call();
        });
    } else {
        top.$.messager.show({ title: settings.title, msg: settings.msg, showType: 'show' });
    }
}
//提示框
function showConfirm(sets) {
    var settings = { title: jslang.Tips, msg: '', callback: null };
    sets = sets || {};
    $.extend(settings, sets);
    top.$.messager.confirm(settings.title, settings.msg, function (r) {
        if (r) {
            if ($.isFunction(settings.callback))
                settings.callback.call();
        }
    });
}
//进度框
function showProcess(sets) {
    var settings = { isOpen: null, title: jslang.Tips, msg: '' };
    sets = sets || {};
    $.extend(settings, sets);
    if (settings.isOpen) top.$.messager.progress({ title: settings.title, msg: settings.msg });
    else top.$.messager.progress('close');
}
//选择一条记录进行操作
function chooseItem(rows, callback, isItem) {
    if (isItem) {
        if (!rows) { showMsg({ msg: jslang.ChooseOneItem }); return; }
    }
    else {
        var num = rows.length;
        if (num == 0) { showMsg({ msg: jslang.ChooseOneItem }); return; }
        else if (num > 1) { showMsg({ msg: jslang.YouChooseMoreItem }); return; }
    }
    if ($.isFunction(callback)) {
        if (isItem) callback.call(this, rows); else callback.call(this, rows[0]);
    }
}
function chooseItems(rows, callback) {
    var num = rows.length;
    if (num == 0) { showMsg({ msg: jslang.ChooseOneItem }); return; }
    if ($.isFunction(callback))
        callback.call(this, rows);
}
//操作一条记录方法
function actionItem(sets) {
    var settings = { url: '', params: '', callback: function () { }, type: 'delete', row: {}, isMsg: false, isAlter: false, msg: jslang.Delete };
    sets = sets || {};
    $.extend(settings, sets);
    var isOK = false;
    if (settings.type == 'delete') isOK = settings.params.id.length > 0;
    else if (settings.type == 'deleteItem') isOK = settings.row != null;
    if (isOK) {
        showConfirm({
            msg: jslang.YouConfirm.format(settings.msg), callback: function () {
                showProcess({ isOpen: true, title: jslang.Tips, msg: jslang.PublishData })
                $.ajax({
                    url: settings.url, type: 'post', data: settings.params,
                    error: function () { showProcess({ isOpen: false }); showMsg({ msg: settings.msg + jslang.Fail }); },
                    success: function (data) {
                        showProcess({ isOpen: false });
                        if (settings.isMsg) {
                            if (settings.isAlter)
                                showMsg({
                                    msg: data.msg, isAlert: settings.isAlter, callback: function () {
                                        if (data.success) {
                                            if ($.isFunction(settings.callback))
                                                settings.callback.call(this, data);
                                        }
                                    }
                                });
                            else {
                                showMsg({ msg: data.msg, isAlert: settings.isAlter });
                                if (data.success) {
                                    if ($.isFunction(settings.callback))
                                        settings.callback.call(this, data);
                                }
                            }
                        } else {
                            if (data.success) {
                                if ($.isFunction(settings.callback))
                                    settings.callback.call(this, data);
                            }
                        }
                    }
                });
            }
        });
    } else showMsg({ msg: jslang.PleaseChooseItem.format(settings.msg) });
}
//提交一条记录方法
function ajaxItem(sets) {
    var settings = { url: '', params: '', callback: function () { }, isMsg: false, isAlter: false, msg: jslang.Save, isFailBack: false };
    sets = sets || {};
    $.extend(settings, sets);
    showProcess({ isOpen: true, title: jslang.Tips, msg: jslang.PublishData })
    $.ajax({
        url: settings.url, type: 'post', data: settings.params,
        error: function () { showProcess({ isOpen: false }); showMsg({ msg: settings.msg + jslang.Fail }); },
        success: function (data) {
            showProcess({ isOpen: false });
            if (settings.isMsg) {
                if (settings.isAlter)
                    showMsg({
                        msg: data.msg, isAlter: settings.isAlter, callback: function () {
                            if (data.success) {
                                if ($.isFunction(settings.callback))
                                    settings.callback.call(this, data);
                            } else if (!data.success && settings.isFailBack) {
                                if ($.isFunction(settings.callback))
                                    settings.callback.call(this, data);
                            }
                        }
                    });
                else {
                    showMsg({ msg: data.msg, isAlter: settings.isAlter });
                    if (data.success) {
                        if ($.isFunction(settings.callback))
                            settings.callback.call(this, data);
                    } else if (!data.success && settings.isFailBack) {
                        if ($.isFunction(settings.callback))
                            settings.callback.call(this, data);
                    }
                }
            } else {
                if (data.success) {
                    if ($.isFunction(settings.callback))
                        settings.callback.call(this, data);
                } else if (!data.success && settings.isFailBack) {
                    if ($.isFunction(settings.callback))
                        settings.callback.call(this, data);
                }
            }
        }
    });
}
//FORM提交方法
function submitForm(sets) {
    var settings = { formID: '', url: '', param: {}, callback: function () { }, isMsg: false, isAlter: false, isFailBack: false, beforeLoad: null };
    sets = sets || {};
    $.extend(settings, sets);
    settings.formID.form('submit', {
        url: settings.url,
        param: settings.param,
        onSubmit: function () {
            var flag = $(this).form('validate');
            if (flag) showProcess({ isOpen: true, title: jslang.Tips, msg: jslang.PublishData });
            return flag
        },
        onBeforeLoad: function (param) {
            if ($.isFunction(settings.beforeLoad))
                settings.beforeLoad.call(this, param);
        },
        onLoadError: function () {
            showProcess({ isOpen: false });
            showMsg({ msg: jslang.PublishFail });
        },
        success: function (data) {
            data = $.parseJSON(data);
            showProcess({ isOpen: false });
            if (settings.isMsg) {
                if (settings.isAlter)
                    showMsg({
                        msg: data.msg, isAlter: settings.isAlter, callback: function () {
                            if (data.success) {
                                if ($.isFunction(settings.callback))
                                    settings.callback.call(this, data);
                            } else if (!data.success && settings.isFailBack) {
                                if ($.isFunction(settings.callback))
                                    settings.callback.call(this, data);
                            }
                        }
                    });
                else {
                    showMsg({ msg: data.msg, isAlter: settings.isAlter });
                    if (data.success) {
                        if ($.isFunction(settings.callback))
                            settings.callback.call(this, data);
                    } else if (!data.success && settings.isFailBack) {
                        if ($.isFunction(settings.callback))
                            settings.callback.call(this, data);
                    }
                }
            } else {
                if (data.success) {
                    if ($.isFunction(settings.callback))
                        settings.callback.call(this, data);
                } else if (!data.success && settings.isFailBack) {
                    if ($.isFunction(settings.callback))
                        settings.callback.call(this, data);
                }
            }
        }
    });
}
function getUserCode() { if (top != self) return top.userCode; return ''; }
function formatCheckbox(value, row) { return value == true ? jslang.Yes : jslang.No; }
function formatCheckbox1(value, row) { return value == true ? jslang.Yes : ''; }
function baseCallback(sets) {
    var settings = { gridID: '', gridType: 'grid', formID: '', layout: 'body', region: 'south', collapsed: 'expand', state: 'new', row: {} };
    sets = sets || {};
    $.extend(settings, sets);
    switch (settings.state) {
        case 'new': case 'cancel':
            $(settings.formID).form('clear');
            break;
        case 'edit':
            $(settings.formID).form('load', settings.row);
            break;
        case 'refresh': case 'delete': case 'save':
            if (settings.formID)
                $(settings.formID).form('clear');
            if (settings.gridType == 'tree') {
                $(settings.gridID).treegrid('reload');
                $(settings.gridID).treegrid('unselectAll');
            } else {
                $(settings.gridID).datagrid('reload');
                $(settings.gridID).datagrid('unselectAll');
            }
            break;
    }
    var pl = $(settings.layout).layout('panel', settings.region).panel('options');
    if ((settings.collapsed == 'expand' && pl.collapsed) || (settings.collapsed == 'collapse' && !pl.collapsed))
        $(settings.layout).layout(settings.collapsed, settings.region);
}
$.extend($.fn.validatebox.defaults.rules, {
    ccb: {
        validator: function (value, param) {
            var v = null;
            switch (param[1]) {
                case 'combotree': v = $(param[0]).combotree('getValue'); break;
                default: v = $(param[0]).combobox('getValue'); break;
            }
            if (v == null || v == 0) {
                $.fn.validatebox.defaults.rules.ccb.message = jslang.ccbmsg;
                return false;
            }
            else {
                return true;
            }
        },
        message: ''
    }
});
/**
扩展自定义验证
<input id="txt_CustPhone" class="easyui-validatebox txtbox" required="true" 
validType="custom_reg['^\\d{10}','手机号码必须是11位数字！']" missingMessage="请输入客户电话！" /> 
*/
$.extend($.fn.validatebox.defaults.rules, {
    custom_reg: {
        validator: function (value, param) {
            var m_reg = new RegExp(param[0]); //传递过来的正则字符串中的"\"必须是"\\"             
            if (!m_reg.test(value)) {
                $.fn.validatebox.defaults.rules.custom_reg.message = param[1];
                return false;
            }
            else {
                return true;
            }
        },
        message: ''
    }
});
/**
远程效验（这块使用的是同步模式，使用异步会在服务器返回值之前返回校验的结果值）
<input id="txt_cardid" class="easyui-validatebox txtbox" required="true" missingMessage="请输入卡号！"
validType="custom_remote['member.ashx?method=check_cardid','cardid','输入的卡号已使用！']" />
*/
$.extend($.fn.validatebox.defaults.rules, {
    custom_remote: {
        validator: function (value, param) {
            var postdata = {};
            if (param[3]) {
                var oldValue = $('#' + param[3]).val();
                if (oldValue == value) return true;
            }
            postdata[param[1]] = value;
            var result = $.ajax({ type: "POST", //http请求方式
                url: param[0],    //服务器段url地址
                data: postdata,      //发送给服务器段的数据
                dataType: "type", //告诉JQuery返回的数据格式
                async: false
            }).responseText;
            if ($.parseJSON(result)) {
                $.fn.validatebox.defaults.rules.custom_remote.message = param[2];
                return false;
            }
            else {
                return true;
            }
        },
        message: ''
    }
});
/**
以下是前两个的结合，先用正则表达式本地验证，通过后在发送服务器验证;
<input id="txt_CustIdentity" class="easyui-validatebox txtbox" required="true"
validType="composite_validation['^\\d{14}(\\d{1}|\\d{4}|\\d{3}x),'身份证号码为15或18位数字！','member.ashx?method=check_Identityid','Identityid','该身份证号已办卡！']" missingMessage="请输入身份证号码！" />
*/
$.extend($.fn.validatebox.defaults.rules, {
    composite_validation: {
        validator: function (value, param) {
            var m_reg = new RegExp(param[0]); //传递过来的正则字符串中的"\"必须是"\\"
            if (!m_reg.test(value)) {
                $.fn.validatebox.defaults.rules.composite_validation.message = param[1];
                return false;
            }
            else {
                var postdata = {};
                if (param[5]) {
                    var oldValue = $('#' + param[5]).val();
                    if (oldValue == value) return true;
                }
                postdata[param[3]] = value;
                var result = $.ajax({
                    url: param[2],
                    data: postdata,
                    async: false,
                    type: "post"
                }).responseText;
                if ($.parseJSON(result)) {
                    $.fn.validatebox.defaults.rules.composite_validation.message = param[4];
                    return false;
                }
                else {
                    return true;
                }
            }
        },
        message: ''
    }
});