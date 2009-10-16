<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Login.aspx.cs" Inherits="Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
</head>
<body>
    <form id="formLogin" runat="server">
        <div>
            <div>
                <table>
                    <tr>
                        <td>
                            <asp:Label ID="labelUsername" runat="server" Text="Username"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="textBoxUsername" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="labelPassword" runat="server" Text="Password"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="textBoxPassword" runat="server" TextMode="Password"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                            <asp:LinkButton ID="linkLogin" runat="server" onclick="LinkLogin_Click">Login</asp:LinkButton>
                        </td>
                    </tr>
                </table>
            </div>
            <div>
                <asp:Label ID="labelStatus" runat="server" Text=""></asp:Label>
            </div>
        </div>
    </form>
</body>
</html>
