<%@ Page Title="" Language="C#" MasterPageFile="~/List.Master" AutoEventWireup="true"
    CodeBehind="WebSiteList.aspx.cs" Inherits="Web.WebSite.WebSiteList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="tools_box">
        <div class="tools_bar">
            <div class="search_box">
                <asp:TextBox ID="txtKeywords" runat="server" CssClass="txtInput"></asp:TextBox>
                <asp:Button ID="btnSearch" runat="server" Text="搜 索" CssClass="btnSearch" OnClick="btnSearch_Click" />
            </div>
            <a href="javascript:void(0);" onclick="checkAll(this);" class="tools_btn"><span><b
                class="all">全选</b></span></a> <a href="WebSiteEdit.aspx?id=<%=this.id %>&action=Add"
                    class="tools_btn"><span><b class="add">添加数据</b></span></a>
            <asp:LinkButton ID="btnDelete" runat="server" CssClass="tools_btn" OnClientClick="return ExePostBack('ctl00$ContentPlaceHolder1$btnDelete');"
                OnClick="btnDelete_Click">
                <span><b class="delete">批量删除</b></span>
            </asp:LinkButton>
            <asp:LinkButton ID="btnSaveSort" runat="server" CssClass="tools_btn" OnClientClick="return ExePostBack('ctl00$ContentPlaceHolder1$btnSaveSort','要保存排序么？');"
                OnClick="btnSaveSort_Click"><span><b class="common">保存排序</b></span>
            </asp:LinkButton>

             <asp:LinkButton ID="btnSetLab" runat="server" CssClass="tools_btn" OnClientClick="return Setlab('../Weblabel/dialoglabList.aspx');"
                OnClick="btnSetLab_Click"><span><b class="combine">设置标签</b></span>
            </asp:LinkButton>

        </div>
        <div class="select_box">
            请选择：
            <asp:DropDownList ID="ddlWebStatus" runat="server" CssClass="select2" AutoPostBack="True"
                OnSelectedIndexChanged="ddlWebStatus_SelectedIndexChanged">
            </asp:DropDownList>
            <asp:DropDownList ID="ddlPartner" runat="server" CssClass="select2" AutoPostBack="True"
                OnSelectedIndexChanged="ddlPartner_SelectedIndexChanged">
            </asp:DropDownList>
            <asp:DropDownList ID="ddlWebSiteType" runat="server" CssClass="select2" AutoPostBack="True"
                OnSelectedIndexChanged="ddlWebSiteType_SelectedIndexChanged">
            </asp:DropDownList>
            <asp:DropDownList ID="ddBrands" runat="server" CssClass="select2" AutoPostBack="True"
                OnSelectedIndexChanged="ddBrands_SelectedIndexChanged">
            </asp:DropDownList>
            <asp:DropDownList ID="ddlProperty" runat="server" CssClass="select2" AutoPostBack="True"
                OnSelectedIndexChanged="ddlProperty_SelectedIndexChanged">
                <asp:ListItem Value="" Selected="True">所有属性</asp:ListItem>
                <asp:ListItem Value="show">查看显示</asp:ListItem>
                <asp:ListItem Value="hidden">查看隐藏</asp:ListItem>
            </asp:DropDownList>
        </div>
    </div>
    <div id="PageContent2" runat="server" class="flickr right toppage">
    </div>
    <div class="clear">
    </div>
    <!--列表展示.开始-->
    <%--<div style="width: 1289; display: block; overflow: scroll;">--%>
    <asp:Repeater ID="rptList" runat="server">
        <HeaderTemplate>
            <table style="display: block;" border="0" cellspacing="0" cellpadding="0" class="msgtable">
                <tr>
                    <th>
                        选择
                    </th>
                    <th align="left">
                        ID
                    </th>
                    <th align="left">
                        网站域名
                    </th>
                    <th align="left">
                        网站状态
                    </th>
                    <th align="left">
                        合作伙伴
                    </th>
                    <th align="left">
                        网站类型
                    </th>
                    <th>
                        所属后台
                    </th>
                    <th>
                        产品类型
                    </th>
                    <th>
                        语系
                    </th>
                    <th>
                        网站所属
                    </th>
                    <th>
                        服务器
                    </th>
                    <th>
                        IP
                    </th>
                    <th>
                        付款方式
                    </th>
                    <th>
                        是否有效
                    </th>
                    <th>
                        排序
                    </th>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td align="center">
                    <asp:CheckBox ID="chkId" CssClass="checkall" runat="server" />
                    <asp:HiddenField ID="hidId" Value='<%#Eval("WebSiteID")%>' runat="server" />
                </td>
                <td>
                    <%#Eval("WebSiteID")%>
                </td>
                <td>
                    <a title="<%#Eval("WebSiteName")%>" name='w_<%#Eval("WebSiteID") %>' href="javascript:top.f_addTab('w_<%#Eval("WebSiteID")%>','<%#Eval("WebSiteName")%>','WebSite/WebSiteEdit.aspx?action=Edit&id=<%#Eval("WebSiteID")%>')">
                        <%#Eval("WebSiteName")%>
                    </a>
                </td>
                <td>
                    <%# RetutnStatusHTML(Convert.ToInt32(Eval("WebStatusID")))%>
                </td>
                <td>
                    <span>
                        <%# new WebSiteData.Partner().GetTitle(Convert.ToInt32(Eval("PartnerID")))%>
                    </span>
                </td>
                <td>
                    <span>
                        <%#Eval("WebSiteType")%>
                    </span>
                </td>
                <td>
                    <span>
                        <%#Eval("Background")%>
                    </span>
                </td>
                <td>
                    <span>
                        <%#new WebSiteData.Brands().GetTitle(Convert.ToInt32(Eval("BrandsID")))%>
                    </span>
                </td>
                <td>
                    <span>
                        <%#Eval("Language")%>
                    </span>
                </td>
                <td>
                    <%#RetutnOwerHTML(Convert.ToInt32(Eval("Owner")))%>
                </td>
                <td>
                    <span>
                        <%#Eval("Server")%>
                    </span>
                </td>
                <td>
                    <span>
                        <%#Eval("IPAddress")%>
                    </span>
                </td>
                <td>
                    <span>
                        <%#Eval("Payment")%>
                    </span>
                </td>
                <td>
                    <span>
                        <%# RetutnIseffectiveHTML(Convert.ToInt32( Eval("Iseffective")))%>
                    </span>
                </td>
                <td align="center">
                    <asp:TextBox ID="txtSortId" runat="server" Text='<%#Eval("SortIndex")%>' CssClass="txtInput2 small2"
                        onkeyup="value=this.value.replace(/\D+/g,'')" />
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            <%#rptList.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"15\">暂无记录</td></tr>" : ""%>
            </table>
        </FooterTemplate>
    </asp:Repeater>
    <%--</div>--%>
    <!--列表展示.结束-->
    <div class="line15">
    </div>
    <div class="page_box">
        <div id="PageContent" runat="server" class="flickr right">
        </div>
        <div class="left">
            显示
            <asp:TextBox ID="txtPageNum" runat="server" CssClass="txtInput2 small2" onkeypress="return (/[\d]/.test(String.fromCharCode(event.keyCode)));"
                OnTextChanged="txtPageNum_TextChanged" AutoPostBack="True">
            </asp:TextBox>条/页 共<asp:Literal ID="litCount" runat="server"></asp:Literal>条数据
        </div>
    </div>
    <div class="line10">
    </div>
</asp:Content>
