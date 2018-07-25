//*作者：超级管理中心
function al() {
    alert("This is a test!");
}
//=============================切换验证码======================================
function ToggleCode(obj, codeurl) {
    $(obj).attr("src", codeurl + "?time=" + Math.random());
}

//表格隔行变色
$(function () {
    $(".msgtable tr:nth-child(odd)").addClass("tr_odd_bg"); //隔行变色
    $(".msgtable tr").hover(
			    function () {
			        $(this).addClass("tr_hover_col");
			    },
			    function () {
			        $(this).removeClass("tr_hover_col");
			    }
		    );
});
//==========================页面加载时JS函数结束===============================

//===========================系统管理JS函数开始================================

//Tab控制函数
function tabs(tabId, tabNum) {
    //设置点击后的切换样式
    $(tabId + " .tab_nav li").removeClass("selected");
    $(tabId + " .tab_nav li").eq(tabNum).addClass("selected");
    //根据参数决定显示内容
    $(tabId + " .tab_con").hide();
    $(tabId + " .tab_con").eq(tabNum).show();
}

//可以自动关闭的提示
function jsprint(msgtitle, url, msgcss, callback) {
    $("#msgprint").remove();
    var cssname = "";
    switch (msgcss) {
        case "Success":
            cssname = "pcent success";
            break;
        case "Error":
            cssname = "pcent error";
            break;
        default:
            cssname = "pcent warning";
            break;
    }
    var str = "<div id=\"msgprint\" class=\"" + cssname + "\">" + msgtitle + "</div>";
    $("body").append(str);
    $("#msgprint").show();
    var itemiframe = "#framecenter .l-tab-content .l-tab-content-item";
    var curriframe = "";
    $(itemiframe).each(function () {
        if ($(this).css("display") != "none") {
            curriframe = $(itemiframe).index($(this));
            return false;
        }
    });
    if (url == "back" && curriframe != "") {
        frames[curriframe].history.back(-1);
    } else if (url != "" && curriframe != "") {
        frames[curriframe].location.href = url;
    }
    //3秒后清除提示
    setTimeout(function () {
        $("#msgprint").fadeOut(500);
        //如果动画结束则删除节点
        if (!$("#msgprint").is(":animated")) {
            $("#msgprint").remove();
        }
    }, 3000);
    //执行回调函数
    if (typeof (callback) == "function") callback();
}
function jsAlert(msg) {
    alert(window.parent.frames.length);
    alert(msg);
}

//全选取消按钮函数，调用样式如：
function checkAll(chkobj) {
    if ($(chkobj).find("span b").text() == "全选") {
        $(chkobj).find("span b").text("取消");
        $(".checkall input").attr("checked", true);
        //我们要获取全部的隐藏字段的值 并写入 到另一个字段
        //        var result = '';
        //        $('input[name="pid[]"]').each(function () {
        //            result = result + $(this).val() + "|";
        //        });
        //        alert(result);
        //        SetVal(result);
    } else {
        $(chkobj).find("span b").text("全选");
        $(".checkall input").attr("checked", false);
    }
}

//执行回传函数
function ExePostBack(objId, objmsg) {
    if ($(".checkall input:checked").size() < 1) {
        $.ligerDialog.warn("对不起，请选中您要操作的记录！"); ;
        return false;
    }
    var msg = "删除记录后不可恢复，您确定吗？";
    if (arguments.length == 2) {
        msg = objmsg;
    }
    $.ligerDialog.confirm(msg, "提示信息", function (result) {
        if (result) {
            //result：表示对话框返回的结果 是一个bool值 为true 执行 函数 否则不执行
            //alert('ok');
            //alert(result);
            __doPostBack(objId, '');
        }
    });
    return false;
}

//关闭提示窗口
function CloseTip(objId) {
    $("#" + objId).hide();
}

//===========================系统管理JS函数结束================================

//================上传文件JS函数开始，需和jquery.form.js一起使用===============
//文件上传
//参数：执行的函数，
function Upload(action, repath, uppath, iswater, isthumbnail, filepath) {

    var sendUrl = "../tools/Uploadajax.ashx?action=" + action + "&ReFilePath=" + repath + "&UpFilePath=" + uppath;
    //判断是否打水印
    if (arguments.length == 4) {
        sendUrl = "../tools/Uploadajax.ashx?action=" + action + "&ReFilePath=" + repath + "&UpFilePath=" + uppath + "&IsWater=" + iswater;
    }
    //判断是否生成宿略图
    if (arguments.length == 5) {
        sendUrl = "../tools/Uploadajax.ashx?action=" + action + "&ReFilePath=" + repath + "&UpFilePath=" + uppath + "&IsWater=" + iswater + "&IsThumbnail=" + isthumbnail;
    }
    //自定义上传路径
    if (arguments.length == 6) {
        sendUrl = filepath + "tools/upload_ajax.ashx?action=" + action + "&ReFilePath=" + repath + "&UpFilePath=" + uppath + "&IsWater=" + iswater + "&IsThumbnail=" + isthumbnail;
    }
    //开始提交
    $("#form1").ajaxSubmit({
        beforeSubmit: function (formData, jqForm, options) {
            //隐藏上传按钮
            $("#" + repath).nextAll(".files").eq(0).hide();

            //显示LOADING图片
            $("#" + repath).nextAll(".uploading").eq(0).show();
        },
        success: function (data, textStatus) {
            if (data.msg == 1) {
                $("#" + repath).val(data.msbox);
            } else {
                alert(data.msbox);
            }
            $("#" + repath).nextAll(".files").eq(0).show();
            $("#" + repath).nextAll(".uploading").eq(0).hide();
        },
        error: function (data, status, e) {
            alert("上传失败，错误信息：" + e);
            $("#" + repath).nextAll(".files").eq(0).show();
            $("#" + repath).nextAll(".uploading").eq(0).hide();
        },
        url: sendUrl,
        type: "post",
        dataType: "json",
        timeout: 600000
    });
};

//附件上传
function AttachUpload(repath, uppath) {
    //alert("ok");
    var submitUrl = "../tools/Uploadajax.ashx?action=AttachFile&UpFilePath=" + uppath;

    //开始提交
    $("#aspnetForm").ajaxSubmit({
        beforeSubmit: function (formData, jqForm, options) {
            //隐藏上传按钮
            $("#" + uppath).parent().hide();
            //显示LOADING图片
            $("#" + uppath).parent().nextAll(".uploading").eq(0).show();
        },
        success: function (data, textStatus) {
            if (data.msg == 1) {
                var listBox = $("#" + repath + " ul");
                var newLi = '<li>'
                + '<input name="hidFileName" type="hidden" value="0|' + data.mstitle + "|" + data.msbox + '" />'
                + '<b title="删除" onclick="DelAttachLi(this);"></b>附件：' + data.mstitle
                + '</li>';
                listBox.append(newLi);
                //alert(data.mstitle);
            } else {
                alert(data.msbox);
            }
            $("#" + uppath).parent().show();
            $("#" + uppath).parent().nextAll(".uploading").eq(0).hide();
        },
        error: function (data, status, e) {
            alert("上传失败，错误信息：" + e);
            $("#" + uppath).parent().show();
            $("#" + uppath).parent().nextAll(".uploading").eq(0).hide();
        },
        url: submitUrl,
        type: "post",
        dataType: "json",
        timeout: 600000
    });
};

//===========================上传文件JS函数结束================================

//===========================自己测试的函数====================================
/*播放对话框*/
function f_openPlay(url) {
    $.ligerDialog.open({ url: url, width: 770, height: 500, modal: false, isResize: true });
}
function f_openPlay2(url, objID) {
    var spanV = document.getElementById(objID);
    alert(spanV.innerHTML);
    $.ligerDialog.open({ url: url + "?id=" + spanV.innerHTML, width: 770, height: 500, modal: false, isResize: true });
}

function Setlab(url) {
    if ($(".checkall input:checked").size() < 1) {
        $.ligerDialog.warn("对不起，请选中您要操作的记录！"); ;
        return false;
    }
    if ($(".checkall input:checked").size() > 1) {
        $.ligerDialog.warn("对不起，只能选择一个操作！"); ;
        return false;
    }
    var val = $(".checkall input:checked").parent().siblings().val();
    if (val != 0) {
        $.ligerDialog.open({ url: url + "?id=" + val, width: 770, height: 500, modal: false, isResize: true });
    }
    else {
        $.ligerDialog.warn("该元素没有值存在！"); ;
    }
    return false;
}
function SetVal(v) {
    document.getElementById("hiddeleID").value = v;
}

function GetMid() {
    var h = document.getElementById("hiddeleID");

    //如果该对象不为空 并且 它的值不为空 返回true  否则 false
    //alert(h);//此时弹出的是一个对象
    //alert(!h); //返回false  也就是说 一个对象存在的话 为true 否则的 就会 false【这句话的意思是“如果该对象不存在”】

    if (h && h.value != "") { //如果该对象存在 并且该对象的值不为空，我们就返回true
        alert(h.value);
        //return true;
    }
    else {
        $.ligerDialog.warn("请选中想要移动的数据啊！");
        return false;
    }
}