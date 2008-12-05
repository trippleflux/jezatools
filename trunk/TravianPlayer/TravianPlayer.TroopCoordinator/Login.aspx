<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TravianPlayer.TroopCoordinator.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Login</title>
</head>
<body>
    <form id="formLogin" runat="server">
        <div>
        
            <asp:Label ID="labelUsername" runat="server" Text="Username"></asp:Label>
            <asp:TextBox ID="textBoxUsername" runat="server"></asp:TextBox>
            <asp:Label ID="labelPassword" runat="server" Text="Password"></asp:Label>
            <asp:TextBox ID="textBoxPassword" runat="server"></asp:TextBox>
        
        </div>
    </form>
</body>
</html>
