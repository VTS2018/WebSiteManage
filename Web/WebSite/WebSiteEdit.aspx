<%@ Page Title="" Language="C#" MasterPageFile="~/Edit.Master" AutoEventWireup="true"
    CodeBehind="WebSiteEdit.aspx.cs" Inherits="Web.WebSite.WebSiteEdit" %>

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
            <%--<asp:Button ID="btnExcel" runat="server" Text="批量导入" CssClass="btnSubmit" OnClick="btnExcel_Click" />--%>
        </div>
        <ul class="tab_nav">
            <li class="selected"><a onclick="tabs('#contentTab',0);" href="javascript:;">基本信息</a></li>
            <li class="selected"><a onclick="tabs('#contentTab',1);" href="javascript:;">模板信息</a></li>
            <%--<li class="selected"><a onclick="tabs('#contentTab',2);" href="javascript:;">扩展信息</a></li>--%>
        </ul>
        <div class="tab_con" style="display: block;">
            <table class="form_table">
                <col width="150px">
                <col>
                <tbody>
                    <tr>
                        <th>
                            网站ID ：
                        </th>
                        <td>
                            <asp:Label ID="lblWebSiteID" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            网站域名 ：
                        </th>
                        <td>
                            <asp:TextBox ID="txtWebSiteName" CssClass="txtInput normal required" runat="server"
                                Width="200px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            网站状态 ：
                        </th>
                        <td>
                            <asp:DropDownList ID="ddlWebStatus" CssClass="select2 required" runat="server" Width="211px">
                            </asp:DropDownList>
                            <span style="font-weight: bold">合作伙伴 ：</span>
                            <asp:DropDownList ID="ddlPartner" CssClass="select2 required" runat="server" Width="211px">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            网站类型 ：
                        </th>
                        <td>
                            <asp:DropDownList ID="ddlWebSiteType" CssClass="select2 required" runat="server"
                                Width="211px">
                            </asp:DropDownList>
                            <span style="font-weight: bold">产品类型 ：</span>
                            <asp:DropDownList ID="ddBrands" CssClass="select2 required  " runat="server" Width="211px">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            所属后台 ：
                        </th>
                        <td>
                            <asp:TextBox ID="txtBackground" CssClass="txtInput normal" runat="server" Width="200px"></asp:TextBox>
                            <span style="font-weight: bold">网站语言 ：</span>
                            <asp:TextBox ID="txtLanguage" CssClass="txtInput normal" runat="server" Width="200px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            网站所属 ：
                        </th>
                        <td>
                            <asp:RadioButtonList ID="txtOwner" runat="server" RepeatLayout="Flow">
                                <asp:ListItem Value="0">公司</asp:ListItem>
                                <asp:ListItem Value="1">客户</asp:ListItem>
                            </asp:RadioButtonList>
                            <%--<asp:TextBox ID="txtOwner" CssClass="txtInput normal" runat="server" Width="200px"></asp:TextBox>--%>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            所在服务器 ：
                        </th>
                        <td>
                            <asp:TextBox ID="txtServer" CssClass="txtInput normal" runat="server" Width="200px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            IP地址 ：
                        </th>
                        <td>
                            <asp:TextBox ID="txtIPAddress" CssClass="txtInput normal" runat="server" Width="200px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            付款方式 ：
                        </th>
                        <td>
                            <textarea id="txtPayment" cols="80" rows="7" runat="server">
                            </textarea>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
        <div class="tab_con">
            <table class="form_table">
                <col width="150px">
                <col>
                <tbody>
                    <tr>
                        <th>
                            模板类型 ：
                        </th>
                        <td>
                            <asp:TextBox ID="txtTemplate" CssClass="txtInput normal" runat="server" Width="200px"></asp:TextBox>
                            程序类型 ：
                            <asp:TextBox ID="txtProgramsType" CssClass="txtInput normal" runat="server" Width="200px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            模板预览图 ：
                        </th>
                        <td>
                            <asp:TextBox ID="txtTemplatePic" CssClass="txtInput normal" runat="server" Width="200px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            接入时间 ：
                        </th>
                        <td>
                            <asp:TextBox ID="txtAddDate" runat="server" Width="200px" CssClass="txtInput normal date"></asp:TextBox>
                            <span style="color: Red">*:格式如：2014/3/4 00:00:00</span>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            下线时间 ：
                        </th>
                        <td>
                            <asp:TextBox ID="txtOfflineDate" runat="server" Width="200px" CssClass="txtInput normal date"></asp:TextBox>
                            <span style="color: Red">*:格式如：2014/3/4 00:00:00</span>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            备注信息 ：
                        </th>
                        <td>
                            <textarea id="txtRemark" cols="80" rows="10" runat="server">
                            </textarea>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
        <%--<div class="tab_con">
            <table class="form_table">
                <col width="150px">
                <col>
                <tbody>
                    <tr>
                        <th>
                            是否有效 ：
                        </th>
                        <td>
                            <asp:TextBox ID="txtIseffective" CssClass="txtInput normal" runat="server" Width="200px"></asp:TextBox>
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
                            是否隐藏 ：
                        </th>
                        <td>
                            <asp:TextBox ID="txtIshidden" CssClass="txtInput normal" runat="server" Width="200px"></asp:TextBox>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>--%>
    </div>
</asp:Content>
