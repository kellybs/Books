// 加载这个文件前，需要先加载jquery.js
var bookModule = {
    //ajax 分页 ，替换原来的
    ajaxPage: function (url, page, className) {


        className = className || "showContents"; //默认className名称
        var loading = '<div style="position:relative;width:100%;"><div style="margin:0 auto;width:142px;height:172px;"><img src="/img/common/loadingAnimation.gif" style="display:block"/><div style="width:142px;height:30px;text-align:center;line-height:30px;color:#fff;font-size:14px;">正在加载中</div><div></div>';
        var isId = undefined;
        if (isId = className.substr(0, 1) === "#") {

            $(className).html(loading);
        } else {
            $("." + className).html(loading);
        }

        $.get(url, { pageIndex: page }, function (data) {
            if (isId) {
                $(className).html(data);
            } else {
                $("." + className).html(data);
            }
        });
    },


    saveResult: function (e) {
        var form = "formSave";

        var url = $("#" + form).attr("action");

        $(e).attr("disabled", "disabled");

        var that = e;

        console.log("hahaha")
        $.post(url, $('#' + form).serialize(), function (data) {

            console.log(data);

            if (data.code == 0) {

                $(that).addClass("buttonEnable");

              
                setTimeout(function () {
                    window.location.href = data.url;
                }, 1000);

              

            }
            else {
                $(that).removeAttr("disabled");
                alert(data.msg);
            }

        });
    }

};