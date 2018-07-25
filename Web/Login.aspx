<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Web.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table cellpadding="10" cellspacing="0" style="display: block; width: 400px; margin: 110px auto">
            <tr>
                <td>
                    <label for="txtUser">
                        用户名：
                    </label>
                </td>
                <td>
                    <asp:TextBox ID="txtUser" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <label for="txtpwd">
                        密 码：
                    </label>
                </td>
                <td>
                    <asp:TextBox ID="txtpwd" runat="server" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button ID="btnLogin" runat="server" Text="登陆" OnClick="btnLogin_Click" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
