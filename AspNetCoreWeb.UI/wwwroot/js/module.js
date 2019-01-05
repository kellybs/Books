// 加载这个文件前，需要先加载jquery.js
var bookModule = {

    flag:0,

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

        var self = this;
       
        $.post(url, $('#' + form).serialize(), function (data) {

            console.log(data);

            if (data.code == self.flag) {

                $(that).addClass("buttonEnable");

              
                setTimeout(function () {
                    window.location.href = data.url;
                }, 100);

              

            }
            else {
                $(that).removeAttr("disabled");
                alert(data.msg);
            }

        });
    },

    deleteItem: function (url, id, e) {
        if (confirm("确认要删除?")) {

            var self = this;

            $.ajax({
                type: "post",

                url: url,
                data: { id: id },
                timeout: 30000, //超时时间：30秒

                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    alert("删除记录时出错了");
                },
                success: function (data) {
                    if (data.code == self.flag) {
                        $(e).parent().parent().fadeOut(500, function () {
                            $(e).parent().parent().remove();
                        })
                    }
                    else {
                        alert(data.msg);
                    }
                }
            });
        }
    },

    selectSubType: function (bigType, smallType) {
        var big = "#" + bigType;
        var small = "#" + smallType;
        var parent = $(big).val();
        $(small).empty();
        if (parent == 0 || parent == "") {

            return;
        }
        $.ajax({
            type: "post",

            url: "/Book/GetSub",
            data: { id: parent },
            dataType: "json",
            timeout: 30000, //超时时间：30秒

            error: function (XMLHttpRequest, textStatus, errorThrown) {
                alert("删除记录时出错了");
            },
            success: function (data) {
                $(small).append("<option value='0'>请选择</option>");
                if (data) {

                    for (var i = 0; i < data.length; i++) {
                        $(small).append("<option value='" + data[i].bookTypeId + "'>" + data[i].typeName + "</option>");
                    }

                }

            }
        });
    }

};