<%@ Page Title="" Language="C#" MasterPageFile="~/List.Master" AutoEventWireup="true"
    CodeBehind="dialoglabList.aspx.cs" Inherits="Web.Weblabel.dialoglabList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="navigation">
    </div>
    <div class="tools_box">
        <div class="tools_bar">
            <div class="search_box">
                <asp:TextBox ID="txtKeywords" runat="server" CssClass="txtInput"></asp:TextBox>
            </div>
            <a href="javascript:void(0);" onclick="checkAll(this);" class="tools_btn"><span><b
                class="all">全选</b></span></a> <a href="LabEdit.aspx?action=Add" class="tools_btn"><span>
                    <b class="add">添 加</b></span></a>
        </div>
    </div>
    <!--列表展示.开始-->
    <div id="PageContent2" runat="server" class="flickr right toppage">
    </div>
    <div class="clear">
    </div>
    <asp:Repeater ID="rptList" runat="server">
        <HeaderTemplate>
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="msgtable">
                <tr>
                    <th width="6%" style="text-align: center">
                        选择
                    </th>
                    <th width="6%" style="text-align: center">
                        ID
                    </th>
                    <th align="left">
                        标题
                    </th>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td align="center">
                    <asp:CheckBox ID="chkId" CssClass="checkall" runat="server" />
                    <asp:HiddenField ID="hidId" Value='<%#Eval("WebAttitudesID")%>' runat="server" />
                </td>
                <td align="center">
                    <%#Eval("WebAttitudesID")%>
                </td>
                <td style="word-break: break-all;">
                    <a style='color: <%#Eval("Color")%>' href="LabEdit.aspx?action=Edit&id=<%#Eval("WebAttitudesID")%>">
                        <%#Eval("Title")%>
                    </a>
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            <%#rptList.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"3\">暂无记录</td></tr>" : ""%>
            </table>
        </FooterTemplate>
    </asp:Repeater>
    <!--列表展示.结束-->
    <div class="line15">
    </div>
    <div class="page_box">
        <div id="PageContent" runat="server" class="flickr right">
        </div>
        <div class="left">
            显示
            <asp:TextBox ID="txtPageNum" runat="server" CssClass="txtInput2 small2" OnTextChanged="txtPageNum_TextChanged"
                AutoPostBack="True" onkeyup="value=this.value.replace(/\D+/g,'')">
            </asp:TextBox>条/页 共<asp:Literal ID="litCount" runat="server"></asp:Literal>条数据
        </div>
    </div>
    <div class="line10">
    </div>
</asp:Content>
