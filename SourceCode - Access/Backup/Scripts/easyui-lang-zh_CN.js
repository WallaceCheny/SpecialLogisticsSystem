if ($.fn.panel){
    $.fn.panel.defaults.titleShow = '温馨提示';
}
if ($.fn.datagrid){
    $.fn.datagrid.defaults.searchbarSubmitText = '查询';
}
if ($.fn.pagination){
	$.fn.pagination.defaults.beforePageText = '第';
	$.fn.pagination.defaults.afterPageText = '共{pages}页';
	$.fn.pagination.defaults.displayMsg = '显示{from}到{to},共{total}记录';
}
if ($.fn.treegrid && $.fn.datagrid){
	$.fn.treegrid.defaults.loadMsg = $.fn.datagrid.defaults.loadMsg;
}
if ($.messager){
	$.messager.defaults.ok = '确定';
	$.messager.defaults.cancel = '取消';
}
if ($.fn.validatebox){
	$.fn.validatebox.defaults.missingMessage = '该输入项为必输项';
	$.fn.validatebox.defaults.rules.email.message = '请输入有效的电子邮件地址';
	$.fn.validatebox.defaults.rules.url.message = '请输入有效的URL地址';
	$.fn.validatebox.defaults.rules.length.message = '输入内容长度必须介于{0}和{1}之间';
	$.fn.validatebox.defaults.rules.remote.message = '请修正该字段';
//	$.fn.validatebox.defaults.rules.CHS.message = '请输入汉字';
//	$.fn.validatebox.defaults.rules.ZIP.message = '邮政编码不存在';
//	$.fn.validatebox.defaults.rules.QQ.message = 'QQ号码不正确';
//	$.fn.validatebox.defaults.rules.mobile.message = '手机号码不正确';
//	$.fn.validatebox.defaults.rules.loginName.message = '登录名称只允许汉字、英文字母、数字及下划线';
//	$.fn.validatebox.defaults.rules.safepass.message = '密码由字母和数字组成，至少6位';
//	$.fn.validatebox.defaults.rules.equalTo.message = '两次输入的字符不一至';
//	$.fn.validatebox.defaults.rules.number.message = '请输入数字';
}
if ($.fn.numberbox){
	$.fn.numberbox.defaults.missingMessage = '该输入项为必输项';
}
if ($.fn.combobox){
	$.fn.combobox.defaults.missingMessage = '该输入项为必输项';
}
if ($.fn.combotree){
	$.fn.combotree.defaults.missingMessage = '该输入项为必输项';
}
if ($.fn.combogrid){
	$.fn.combogrid.defaults.missingMessage = '该输入项为必输项';
}
if ($.fn.calendar){
	$.fn.calendar.defaults.weeks = ['日','一','二','三','四','五','六'];
	$.fn.calendar.defaults.months = ['一月','二月','三月','四月','五月','六月','七月','八月','九月','十月','十一月','十二月'];
}
if ($.fn.datebox){
	$.fn.datebox.defaults.currentText = '今天';
	$.fn.datebox.defaults.closeText = '关闭';
	$.fn.datebox.defaults.okText = '确定';
	$.fn.datebox.defaults.missingMessage = '该输入项为必输项';
	$.fn.datebox.defaults.formatter = function(date){
		var y = date.getFullYear();
		var m = date.getMonth()+1;
		var d = date.getDate();
		return y+'-'+(m<10?('0'+m):m)+'-'+(d<10?('0'+d):d);
	};
	$.fn.datebox.defaults.parser = function(s){
		if (!s) return new Date();
		var ss = s.split('-');
		var y = parseInt(ss[0],10);
		var m = parseInt(ss[1],10);
		var d = parseInt(ss[2],10);
		if (!isNaN(y) && !isNaN(m) && !isNaN(d)){
			return new Date(y,m-1,d);
		} else {
			return new Date();
		}
	};
}
if ($.fn.combodialoggrid) {
    $.fn.combodialoggrid.defaults.selectAll = '全选';
    $.fn.combodialoggrid.defaults.unselectAll = '取消所选';
    $.fn.combodialoggrid.defaults.deleteAll = '清空';
    $.fn.combodialoggrid.defaults.closeText = '关闭';
}
if ($.fn.customdialog) {
    $.fn.customdialog.defaults.saveText = '保存';
    $.fn.customdialog.defaults.closeText = '取消';
    $.fn.customdialog.defaults.tips = '温馨提示';
    $.fn.customdialog.defaults.publishData = '正在提交数据...';
    $.fn.customdialog.defaults.publishFail = '由于网络或服务器太忙，提交失败，请重试!';
}
if ($.fn.datetimebox && $.fn.datebox){
	$.extend($.fn.datetimebox.defaults,{
		currentText: $.fn.datebox.defaults.currentText,
		closeText: $.fn.datebox.defaults.closeText,
		okText: $.fn.datebox.defaults.okText,
		missingMessage: $.fn.datebox.defaults.missingMessage
	});
}
var jslang = {};
jslang.Save = '保存';
jslang.Cancel = '取消';
jslang.Delete = '删除';
jslang.Yes = '是';
jslang.No = '否';
jslang.Fail = '失败';
jslang.Tips = '温馨提示';
jslang.Loading = '正在加载数据，请稍等片刻......';
jslang.PublishData = '正在提交数据...';
jslang.PublishFail = '由于网络或服务器太忙，提交失败，请重试！';
jslang.ChooseOneItem = '请选择一条记录进行操作!';
jslang.YouChooseMoreItem = '您选择了多条记录,只能选择一条记录进行操作!';
jslang.YouConfirm = '您确认要{0}吗?';
jslang.PleaseChooseItem = '请先选择要{0}的记录';
jslang.SetLangLabel = '设置语言标签';
jslang.NothingRightTab = '左边没有选项卡';
jslang.NothingLeftTab = '右边没有选项卡';
jslang.ConfirmLogout = '您确定要退出本次登录吗?';
jslang.ccbmsg = '必须选择下拉项';
jslang.hour1 = '凌晨好！';
jslang.hour2 = '早上好！';
jslang.hour3 = '上午好！';
jslang.hour4 = '中午好！';
jslang.hour5 = '下午好！';
jslang.hour6 = '傍晚好！';
jslang.hour7 = '晚上好！';
jslang.hour8 = '夜深了，注意休息！';