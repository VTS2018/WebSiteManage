<%@ Page Title="" Language="C#" MasterPageFile="~/Edit.Master" AutoEventWireup="true"
    CodeBehind="PartnerEdit.aspx.cs" Inherits="Web.Partner.PartnerEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="navigation">
        <a href="javascript:history.go(-1);" class="back">后退</a>首页 &gt; 合作伙伴管理 &gt; 编辑信息
    </div>
    <div id="contentTab">
        <div>
            <asp:Button ID="btnSubmit" runat="server" Text="提交保存" CssClass="btnSubmit" OnClick="btnSubmit_Click" />
            &nbsp;
            <asp:Button ID="btnMutil" runat="server" Text="批量添加" CssClass="btnSubmit" 
                onclick="btnMutil_Click" />
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
                            合作伙伴ID ：
                        </th>
                        <td>
                            <asp:Label ID="lblPartnerID" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            合作伙伴 ：
                        </th>
                        <td>
                            <asp:TextBox ID="txtPartnername" CssClass="txtInput normal required" runat="server"
                                Width="200px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            等级 ：
                        </th>
                        <td>
                            <asp:TextBox ID="txtStarLevel" CssClass="txtInput normal digits" runat="server" Width="200px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            等级图标 ：
                        </th>
                        <td>
                            <asp:TextBox ID="txtStarICO" CssClass="txtInput normal" runat="server" Width="200px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            备注 ：
                        </th>
                        <td>
                            
                            <textarea id="txtRemark"  runat="server" cols="80" rows="10"></textarea>
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
