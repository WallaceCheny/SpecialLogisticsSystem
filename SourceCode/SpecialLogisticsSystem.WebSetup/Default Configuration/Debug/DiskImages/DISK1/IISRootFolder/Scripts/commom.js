if (typeof (window['SpecialLogisticsSystem']) === 'undefined') {
    window.SpecialLogisticsSystem = {};
}

if (typeof (window.SpecialLogisticsSystem['Util']) === 'undefined') {
    window.SpecialLogisticsSystem.Util = {};
}

/**
*/
SpecialLogisticsSystem.Util = {
    'Namespace': function (ns) {
        var nsParts = ns.split(".");
        var root = window;

        for (var i = 0; i < nsParts.length; i++) {
            if (typeof root[nsParts[i]] == "undefined")
                root[nsParts[i]] = new Object();

            root = root[nsParts[i]];
        }
    },
    'IsObject': function (name) {
        var result = false;
        try {
            if (typeof (eval(name)) == "object") {
                result = true;
            }
        } catch (e) {
            result = false;
        }
        return result;
    },
    'IsFunction': function (name) {
        var result = false;
        try {
            if (typeof (eval(name)) == "function") {
                result = true;
            }
        } catch (e) {
            result = false;
        }
        return result;
    },
    // false: not int format
    //Matches 0,+12,12,-12
    "IsInteger": function (str) {
        return str.match(/^0$|^[+-]?[1-9][0-9]*$/ig) != null;
    },
    'ReLocation': function () {
        var url = location.href; //把当前页面的地址赋给变量 url 
        var times = url.split("?"); //分切变量 url 分隔符号为 "?" 
        if (times[1] != 2) { //如果?后的值不等于1表示没有刷新 -- 库存管理后面还要刷新 
            if (times.length < 2) url += "?1"; //把变量 url 的值加入 ?1 
            self.location.replace(url); //刷新页面
        }
    },
    'Help': function () {
        var url = location.href; //把当前页面的地址赋给变量 url 
//        var parament = url.split("?"); //分切变量 url 分隔符号为 "?"
//        if (parament.length > 0) {
//            var detailparament = parament[1].split("&");
//            var menuname = "";
//            var menuid = "";
//            for (var i = 0; i < detailparament.length; i++) {
//                var result = detailparament[i].split("=");
//                if (result[0] == "menu_id") {
//                    menuid = detailparament[i];
//                }
//                else if (result[0] == "menu_name") {
//                    menuname = result[1];
//                }
//            }

//        }
        addTab("", '帮助', '/Cm/Help.aspx?url=' + url, 'frame', 'help');
    }
};
