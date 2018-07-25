<%@ Page Title="" Language="C#" MasterPageFile="~/Edit.Master" AutoEventWireup="true"
    CodeBehind="BrandsEdit.aspx.cs" Inherits="Web.Brands.BrandsEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="navigation">
        <a href="javascript:history.go(-1);" class="back">后退</a>首页 &gt; 品牌管理 &gt; 编辑信息
    </div>
    <div id="contentTab">
        <div>
            <asp:Button ID="btnSubmit" runat="server" Text="提交保存" CssClass="btnSubmit" OnClick="btnSubmit_Click" />
            &nbsp;
            <asp:Button ID="btnMutil" runat="server" Text="批量添加" onclick="btnMutil_Click" />
        </div>
        <ul class="tab_nav">
            <li class="selected"><a onclick="tabs('#contentTab',0);" href="javascript:;">基本信息</a></li>
        </ul>
        <div class="tab_con" style="display: block;">
            <table class="form_table">
                <col width="150px">
                <col>
                <tbody>
                    <tr>
                        <th>
                            品牌ID ：
                        </th>
                        <td>
                            <asp:Label ID="lblBrandsID" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            品牌名字 ：
                        </th>
                        <td>
                            <asp:TextBox ID="txtBrandsName" CssClass="txtInput normal required" runat="server"
                                Width="200px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            排序 ：
                        </th>
                        <td>
                            <asp:TextBox ID="txtSortIndex" CssClass="txtInput normal digits" runat="server" Width="200px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            备注 ：
                        </th>
                        <td>
                            <textarea id="txtRemark" cols="80" rows="10" runat="server"></textarea>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
        <div class="tab_con">
        </div>
        <div class="tab_con">
        </div>
    </div>
</asp:Content>
