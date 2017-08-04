if (typeof (window['SpecialLogisticsSystem']) === 'undefined') {
    window.SpecialLogisticsSystem = {};
}

if (typeof (window.SpecialLogisticsSystem['Util']) === 'undefined') {
    window.SpecialLogisticsSystem.Util = {};
}

/**
*/
//V1 method
String.prototype.format = function () {
    var args = arguments;
    return this.replace(/\{(\d+)\}/g,
        function (m, i) {
            return args[i];
        });
}
//V2 static
String.format = function () {
    if (arguments.length == 0)
        return null;

    var str = arguments[0];
    for (var i = 1; i < arguments.length; i++) {
        var re = new RegExp('\\{' + (i - 1) + '\\}', 'gm');
        str = str.replace(re, arguments[i]);
    }
    return str;
}
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
        self.location.replace(url); //刷新页面
    },
    'Help': function () {
        var url = location.pathname;
        $.ajax({
            type: "POST",
            url: "/UIHelpers/AjaxHelper.ashx",
            dataType: 'text',
            data: { method: 'getmenu', action: url },
            success: function (json) {
                if (json) {
                    var parament = json.split("?"); //分切变量 url 分隔符号为 "?"
                    if (parament.length > 0) {
                        var detailparament = parament[1].split("&");
                        var menuname = "";
                        var menuid = "";
                        for (var i = 0; i < detailparament.length; i++) {
                            var result = detailparament[i].split("=");
                            if (result[0] == "menu_id") {
                                menuid = detailparament[i];
                            }
                            else if (result[0] == "menu_name") {
                                menuname = result[1];
                            }
                        }
                        addTab("", unescape(menuname) + ' - 帮助', '/Cm/Help.aspx?' + menuid, 'frame', 'help');
                    }
                }
            }
        });
    },
    'InsertToDetail': function (production_ids, popupSelectedID) {
        $.ajax({
            type: "GET",
            url: "/UIHelpers/AjaxHelper.ashx",
            dataType: 'json',
            cache: false,
            async: true,
            data: { method: 'InsertToDetail', ids: production_ids.join(), typeName: gridConfig.popuSelectedTypeName },
            success: function (json) {
                if (json && json.IsSuccessfully) {
                    window[popupSelectedID].Hide();
                }
            }
        });
    },
    "toSerialize": function (obj) {
        var ransferCharForJavascript = function (s) {
            var newStr = s.replace(/[\x26\x27\x3C\x3E\x0D\x0A\x22\x2C\x5C\x00]/g,
                    function (c) {
                        ascii = c.charCodeAt(0)
                        return '\\u00' + (ascii < 16 ? '0' + ascii.toString(16) : ascii.toString(16))
                    }
              );
            return newStr;
        }
        if (obj == null) {
            return null
        }
        else if (obj.constructor == Array) {
            var builder = [];
            builder.push("[");
            for (var index in obj) {
                if (typeof obj[index] == "function") continue;
                if (index > 0) builder.push(",");
                builder.push(String.toSerialize(obj[index]));
            }
            builder.push("]");
            return builder.join("");
        }
        else if (obj.constructor == Object) {
            var builder = [];
            builder.push("{");
            var index = 0;
            for (var key in obj) {
                if (typeof obj[key] == "function") continue;
                if (index > 0) builder.push(",");
                builder.push(String.format("\"{0}\":{1}", key, String.toSerialize(obj[key])));
                index++;
            }
            builder.push("}");
            return builder.join("");
        }
        else if (obj.constructor == Boolean) {
            return obj.toString();
        }
        else if (obj.constructor == Number) {
            return obj.toString();
        }
        else if (obj.constructor == String) {
            return String.format('"{0}"', ransferCharForJavascript(obj));
        }
        else if (obj.constructor == Date) {
            return String.format('{"__DataType":"Date","__thisue":{0}}', obj.getTime() - (new Date(1970, 0, 1, 0, 0, 0)).getTime());
        }
        else if (this.toString != undefined) {
            return String.toSerialize(obj);
        }
    }
};
