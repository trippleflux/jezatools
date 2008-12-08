<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TravianPlayer.TroopCoordinator._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Troop Coordinator</title>
</head>
<body>
    <form id="formMain" runat="server">

        <div>

			<asp:LinkButton ID="LinkButtonViewTroops" runat="server" 
				style="position: absolute; top: 60px; left: 20px;" PostBackUrl="Default.aspx">View Troops</asp:LinkButton>
			<asp:LinkButton ID="LinkButtonInsertTroops" runat="server" 
				style="position: absolute; top: 80px; left: 20px;" PostBackUrl="EditOwnTroops.aspx">Edit Troops</asp:LinkButton>
			<asp:LinkButton ID="LinkButtonLogOut" runat="server" 
				style="position: absolute; top: 100px; left: 20px;" onclick="LinkButtonLogOut_Click">Logout</asp:LinkButton>
				
       	</div>

       	<div>

			<asp:GridView ID="GridViewTroops" runat="server" 
				
				style="z-index: 1; left: 200px; top: 60px; position: absolute; height: 50px; width: 500px" 
				AutoGenerateColumns="False" DataSourceID="TCSqlDataSource">
				<Columns>
					<asp:BoundField DataField="TroopId" HeaderText="TroopId" 
						SortExpression="TroopId" />
					<asp:BoundField DataField="TroopCount" HeaderText="TroopCount" 
						SortExpression="TroopCount" />
				</Columns>
			</asp:GridView>

       		<asp:SqlDataSource ID="TCSqlDataSource" runat="server" 
				ConnectionString="<%$ ConnectionStrings:TroopCoordinatorConnectionString %>" 
				SelectCommand="SELECT [TroopId], [TroopCount] FROM [Troops] ORDER BY [TroopId]">
			</asp:SqlDataSource>

       	</div>

    </form>
</body>
</html>
