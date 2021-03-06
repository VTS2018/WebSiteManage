﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Edit.Master" AutoEventWireup="true"
    CodeBehind="LabEdit.aspx.cs" Inherits="Web.Weblabel.LabEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="navigation">
        <a href="javascript:history.go(-1);" class="back">后退</a>首页 &gt; 网站标签管理 &gt; 编辑信息
    </div>
    <div id="contentTab">
        <div>
            <asp:Button ID="btnSubmit" runat="server" Text="提交保存" CssClass="btnSubmit" OnClick="btnSubmit_Click" />
            &nbsp;
            <input name="重置" type="reset" class="btnSubmit" value="重 置" />
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
                            标签ID ：
                        </th>
                        <td height="25" width="*" align="left">
                            <asp:Label ID="lblWebAttitudesID" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            标签名 ：
                        </th>
                        <td height="25" width="*" align="left">
                            <asp:TextBox ID="txtTitle" CssClass="txtInput normal required" runat="server" Width="200px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            颜色 ：
                        </th>
                        <td height="25" width="*" align="left">
                            <asp:TextBox ID="txtColor" CssClass="txtInput normal" runat="server" Width="200px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            添加时间 ：
                        </th>
                        <td height="25" width="*" align="left">
                            <asp:TextBox ID="txtAddDate" CssClass="txtInput normal date" runat="server" Width="200px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            备注信息 ：
                        </th>
                        <td height="25" width="*" align="left">
                            <asp:TextBox ID="txtRemark" CssClass="txtInput normal" runat="server" Width="200px"></asp:TextBox>
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
