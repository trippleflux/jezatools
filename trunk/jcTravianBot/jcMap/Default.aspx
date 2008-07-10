<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Travian Map</title>
</head>
<body>
    <form id="jcMap" runat="server">
    <div>
    
		<asp:LinkButton ID="linkButtonImportData" runat="server" 
			Style="z-index: 110; left: 20px; position: absolute; top: 20px" OnClick="linkButtonImportData_Click" Enabled="False">Import Data</asp:LinkButton>
		<asp:LinkButton ID="linkButtonRefreshMap" runat="server" 
			Style="z-index: 111; left: 20px; position: absolute; top: 50px" OnClick="linkButtonRefreshMap_Click">Refresh Map</asp:LinkButton>
    
		<asp:Label ID="labelX" runat="server" 
			Style="z-index: 100; left: 140px; position: absolute; top: 20px" 
			Text="CoordinateX" Width="90px"></asp:Label>
		<asp:TextBox ID="textBoxX" runat="server" 
			Style="z-index: 102; left: 240px; position: absolute; top: 20px" Width="40px">-130</asp:TextBox>
		<asp:Label ID="labelY" runat="server" 
			Style="z-index: 103; left: 140px; position: absolute; top: 50px" 
			Text="CoordinateY" Width="90px"></asp:Label>
		<asp:TextBox ID="textBoxY" runat="server" 
			Style="z-index: 104; left: 240px; position: absolute; top: 50px" Width="40px">-3</asp:TextBox>
		<asp:Label ID="labelDistance" runat="server" 
			Style="z-index: 105; left: 140px; position: absolute; top: 80px" 
			Text="Distance" Width="90px"></asp:Label>
		<asp:TextBox ID="textBoxDistance" runat="server" 
			Style="z-index: 109; left: 240px; position: absolute; top: 80px" Width="40px">10</asp:TextBox>
        
        <asp:Label ID="LabelAlly" runat="server" 
            Style="z-index: 106; left: 360px; position: absolute; top: 24px" 
            Text="Ally" Width="90px"></asp:Label>
        <asp:TextBox ID="TextBoxAlly" runat="server" 
            Style="z-index: 113; left: 480px; position: absolute; top: 24px" Width="400px"></asp:TextBox>
        <asp:Label ID="LabelNap" runat="server" 
            Style="z-index: 107; left: 360px; position: absolute; top: 48px" 
            Text="Nap" Width="90px"></asp:Label>
        <asp:TextBox ID="TextBoxNap" runat="server" 
            Style="z-index: 114; left: 480px; position: absolute; top: 48px" Width="400px"></asp:TextBox>
        <asp:Label ID="LabelWar" runat="server" 
            Style="z-index: 108; left: 360px; position: absolute; top: 80px" 
            Text="War" Width="90px"></asp:Label>
        <asp:TextBox ID="TextBoxWar" runat="server" 
            Style="z-index: 116; left: 480px; position: absolute; top: 80px" Width="400px"></asp:TextBox>

		<asp:Label ID="labelErrorMSG" runat="server" 
			Style="z-index: 101; left: 20px; position: absolute; top: 110px" 
			Text=""></asp:Label>

		<asp:Table ID="tableMap" runat="server" 
			Style="z-index: 112; left: 20px; position: absolute; top: 140px" OnDataBinding="linkButtonRefreshMap_Click">
		</asp:Table>
		
    </div>
    </form>
</body>
</html>
