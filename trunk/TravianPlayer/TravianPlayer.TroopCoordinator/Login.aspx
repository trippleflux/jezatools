<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TravianPlayer.TroopCoordinator.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Login</title>
	<link href="StyleSheetOverAll.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="formLogin" runat="server" style="position: absolute">

        <div>

       		<asp:Label ID="LabelUsername" runat="server" style="position: absolute; top: 60px; left: 20px;" Text="Username"></asp:Label>
			<asp:TextBox ID="TextBoxUsername" runat="server" style="position: absolute; top: 60px; left: 100px;"></asp:TextBox>
       		<asp:Label ID="LabelPassword" runat="server" style="position: absolute; top: 100px; left: 20px;" Text="Password" ></asp:Label>
			<asp:TextBox ID="TextBoxPassword" runat="server" style="position: absolute; top: 100px; left: 100px;"></asp:TextBox>
			<asp:LinkButton ID="LinkButtonRegister" runat="server" 
				style="position: absolute; top: 140px; left: 20px;" onclick="LinkButtonRegister_Click" 
				>Register</asp:LinkButton>
			<asp:LinkButton ID="LinkButtonLogin" runat="server" style="position: absolute; top: 140px; left: 100px;" 
				onclick="LinkButtonLogin_Click">Login</asp:LinkButton>
       	</div>

    </form>
</body>
</html>
