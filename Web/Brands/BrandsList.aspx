﻿<%@ Page Title="" Language="C#" MasterPageFile="~/List.Master" AutoEventWireup="true"
    CodeBehind="BrandsList.aspx.cs" Inherits="Web.Brands.BrandsList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="navigation">
    </div>
    <div class="tools_box">
        <div class="tools_bar">
            <div class="search_box">
                <asp:TextBox ID="txtKeywords" runat="server" CssClass="txtInput"></asp:TextBox>
                <asp:Button ID="btnSearch" runat="server" Text="搜 索" CssClass="btnSearch" OnClick="btnSearch_Click" />
            </div>
            <a href="javascript:void(0);" onclick="checkAll(this);" class="tools_btn"><span><b
                class="all">全选</b></span> </a><a href="BrandsEdit.aspx?action=Add" class="tools_btn">
                    <span><b class="add">添加数据</b></span></a>
            <asp:LinkButton ID="btnDelete" runat="server" CssClass="tools_btn" OnClientClick="return ExePostBack('ctl00$ContentPlaceHolder1$btnDelete');"
                OnClick="btnDelete_Click"><span><b class="delete">批量删除</b></span>
            </asp:LinkButton>
            <asp:LinkButton ID="btnSaveSort" runat="server" CssClass="tools_btn" OnClientClick="return ExePostBack('ctl00$ContentPlaceHolder1$btnSaveSort','要保存排序么？');"
                OnClick="btnSaveSort_Click"><span><b class="delete">保存排序</b></span>
            </asp:LinkButton>
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
                    <th style="width: 1%; text-align: center">
                        选择
                    </th>
                    <th style="width: 1%; text-align: center">
                        ID
                    </th>
                    <th width="7%">
                        品牌名称
                    </th>
                    <th width="4%">
                        排序
                    </th>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td align="center">
                    <asp:CheckBox ID="chkId" CssClass="checkall" runat="server" />
                    <asp:HiddenField ID="hidId" Value='<%#Eval("BrandsID")%>' runat="server" />
                </td>
                <td align="center">
                    <%#Eval("BrandsID")%>
                </td>
                <td>
                    <a name='m_<%#Eval("BrandsID") %>' href="BrandsEdit.aspx?action=Edit&id=<%#Eval("BrandsID")%>">
                        <%#Eval("BrandsName")%>
                    </a>
                </td>
                <td>
                    <asp:TextBox ID="txtSortId" runat="server" Text='<%#Eval("SortIndex")%>' CssClass="txtInput2 small2"
                        onkeyup="value=this.value.replace(/\D+/g,'')" />
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            <%#rptList.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"4\">暂无记录</td></tr>" : ""%>
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
