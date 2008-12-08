<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="TravianPlayer.TroopCoordinator.Admin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Admin</title>
</head>
<body>
    <form id="formAdmin" runat="server">

        <div>

			<asp:LinkButton ID="LinkButtonViewTroops" runat="server" 
				style="position: absolute; top: 60px; left: 20px;" PostBackUrl="Default.aspx">View Troops</asp:LinkButton>
			<asp:LinkButton ID="LinkButtonInsertTroops" runat="server" 
				style="position: absolute; top: 80px; left: 20px;" PostBackUrl="EditOwnTroops.aspx">Edit Troops</asp:LinkButton>
			<asp:LinkButton ID="LinkButtonLogOut" runat="server" 
				style="position: absolute; top: 100px; left: 20px;" onclick="LinkButtonLogOut_Click">Logout</asp:LinkButton>
				
       	</div>

    </form>
</body>
</html>
