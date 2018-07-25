<%@ Page Language="C#" AutoEventWireup="true" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
   
    <link href="lib/ligerUI/skins/Aqua/css/ligerui-all.css" rel="stylesheet" type="text/css" />
    <link href="css/style.css" rel="stylesheet" type="text/css" />
    <script src="lib/jquery/jquery-1.3.2.min.js" type="text/javascript"></script>
    <script src="lib/ligerUI/js/ligerui.min.js" type="text/javascript"></script>
    <script src="indexdata.js" type="text/javascript"></script>
    <script src="/js/function.js" type="text/javascript"></script>
    <script type="text/javascript">
        var tab = null;
        var accordion = null;
        var tree = null;
        $(function () {
            //布局
            $("#layout1").ligerLayout({ leftWidth: 190, height: '100%', heightDiff: 0, space: 4, onHeightChanged: f_heightChanged });

            var height = $(".l-layout-center").height();

            //Tab
            $("#framecenter").ligerTab({ height: height });

            //面板
            $("#accordion1").ligerAccordion({ height: height - 24, speed: null });

            $(".l-link").hover(function () {
                $(this).addClass("l-link-over");
            }, function () {
                $(this).removeClass("l-link-over");
            });

            //树
            //            $("#tree1").ligerTree({
            //                data: indexdata,
            //                checkbox: false,
            //                slide: false,
            //                nodeWidth: 120,
            //                attribute: ['nodename', 'url'],
            //                onSelect: function (node) {
            //                    if (!node.data.url) return;
            //                    var tabid = $(node.target).attr("tabid");
            //                    if (!tabid) {
            //                        tabid = new Date().getTime();
            //                        $(node.target).attr("tabid", tabid)
            //                    }
            //                    f_addTab(tabid, node.data.text, node.data.url);
            //                }
            //            });

            tab = $("#framecenter").ligerGetTabManager();
            accordion = $("#accordion1").ligerGetAccordionManager();
            tree = $("#tree1").ligerGetTreeManager();
            $("#pageloading").hide();

        });
        function f_heightChanged(options) {
            if (tab)
                tab.addHeight(options.diff);
            if (accordion && options.middleHeight - 24 > 0)
                accordion.setHeight(options.middleHeight - 24);
        }
        function f_addTab(tabid, text, url) {
            tab.addTabItem({ tabid: tabid, text: text, url: url });
            //tab.selectTabItem("WebsiteManage");
        } 
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="pageloading">
        <%--这个暂时没有生效出来 生效的是tab的loading--%>
    </div>
    <div id="topmenu" class="l-topmenu">
        <div class="l-topmenu-logo">
            网站管理系统
        </div>
        <div class="l-topmenu-welcome">
            <a href="Brands/BrandsEdit.aspx"></a>
        </div>
    </div>
    <div id="layout1" style="width: 99.2%; margin: 0 auto; margin-top: 4px;">
        <div position="left" title="主要菜单" id="accordion1">
            <div title="功能列表" class="l-scroll">
                <ul id="tree1" style="margin-top: 3px;">
                    <li><a class="l-link" href="javascript:f_addTab('WebsiteManage','网站管理','WebSite/WebSiteList.aspx')">
                        网站管理</a></li>
                    <li><a class="l-link" href="javascript:f_addTab('WebsiteLab','网站标签','Weblabel/LabList.aspx')">
                        网站标签</a></li>
                    <li><a class="l-link" href="javascript:f_addTab('Brands','品牌管理','Brands/BrandsList.aspx')">
                        品牌管理</a></li>
                    <li><a class="l-link" href="javascript:f_addTab('WebStatus','网站状态管理','WebStatus/WebStatusList.aspx')">
                        网站状态管理</a></li>
                    <li><a class="l-link" href="javascript:f_addTab('DomainManage','网站域名信息管理','demos/case/listpage.htm')">
                        域名信息管理</a></li>
                    <li><a class="l-link" href="javascript:f_addTab('Partner','合作伙伴信息登记','Partner/PartnerList.aspx')">
                        合作伙伴信息管理</a></li>
                    <li><a class="l-link" href="javascript:f_addTab('WebsiteLoginManage','网站登录信息管理','demos/case/listpage.htm')">
                        网站登录信息管理</a></li>
                </ul>
            </div>
            <%--<div title="应用场景">
                <div style="height: 7px;">
                </div>
                <a class="l-link" href="javascript:f_addTab('listpage','列表页面','demos/case/listpage.htm')">
                    列表页面</a> <a class="l-link" href="javascript:f_addTab('listpage','列表页面','demos/case/listpage2.htm')">
                        列表页面2</a> <a class="l-link" href="demos/dialog/win7.htm" target="_blank">模拟Window桌面</a>
                <a class="l-link" href="javascript:f_addTab('week','工作日志','demos/case/week.htm')">工作日志</a>
            </div>
            <div title="实验室">
                <div style="height: 7px;">
                </div>
                <a class="l-link" href="lab/generate/index.htm" target="_blank">表格表单设计器</a> <a class="l-link"
                    href="lab/formdesign/index.htm" target="_blank">可视化表单设计</a>
            </div>--%>
        </div>
        <div position="center" id="framecenter">
            <div tabid="home" title="我的主页">
                <iframe frameborder="0" name="home" id="home" src="Center.aspx"></iframe>
            </div>
        </div>
    </div>
    <%--<div style="height: 32px; line-height: 32px; text-align: center;">
        Copyright © 2011-2013 www.ligerui.com
    </div>--%>
    </form>
</body>
</html>
