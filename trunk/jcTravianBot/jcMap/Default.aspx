<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Travian Map</title>
</head>
<body>
    <form id="jcMap" runat="server">
    <div>
    
		<asp:LinkButton ID="linkButtonRefreshMap" runat="server" 
			Style="z-index: 100; left: 20px; position: absolute; top: 20px" OnClick="linkButtonRefreshMap_Click" Width="90px">Refresh Map</asp:LinkButton>
        <asp:DropDownList ID="dropDownListServers" runat="server" 
            Style="z-index: 101; left: 20px; position: absolute; top: 50px" Width="90px">
            <asp:ListItem Selected="True">si_s6</asp:ListItem>
        </asp:DropDownList>
		<asp:LinkButton ID="linkButtonImportData" runat="server" 
			Style="z-index: 102; left: 20px; position: absolute; top: 80px" OnClick="linkButtonImportData_Click" Enabled="False" Width="90px" Visible="False">Import Data</asp:LinkButton>
        <asp:TextBox ID="textBoxUnits" runat="server" 
            Style="z-index: 103; left: 20px; position: absolute; top: 110px" Width="260px" Visible="False">25,0,0,0,0,0,0,0,0,0,0,0|?newdid=0</asp:TextBox>
		
		<asp:Label ID="labelX" runat="server" 
			Style="z-index: 104; left: 140px; position: absolute; top: 20px" 
			Text="CoordinateX" Width="90px"></asp:Label>
		<asp:TextBox ID="textBoxX" runat="server" 
			Style="z-index: 105; left: 240px; position: absolute; top: 20px" Width="40px">-22</asp:TextBox>
		<asp:Label ID="labelY" runat="server" 
			Style="z-index: 106; left: 140px; position: absolute; top: 50px" 
			Text="CoordinateY" Width="90px"></asp:Label>
		<asp:TextBox ID="textBoxY" runat="server" 
			Style="z-index: 107; left: 240px; position: absolute; top: 50px" Width="40px">-95</asp:TextBox>
		<asp:Label ID="labelDistance" runat="server" 
			Style="z-index: 108; left: 140px; position: absolute; top: 80px" 
			Text="Distance" Width="90px"></asp:Label>
		<asp:TextBox ID="textBoxDistance" runat="server" 
			Style="z-index: 109; left: 240px; position: absolute; top: 80px" Width="40px">20</asp:TextBox>
        
        <asp:Label ID="LabelAlly" runat="server" 
            Style="z-index: 110; left: 300px; position: absolute; top: 20px" 
            Text="Ally" Width="50px" BackColor="Orange"></asp:Label>
        <asp:TextBox ID="TextBoxAlly" runat="server" 
            Style="z-index: 111; left: 360px; position: absolute; top: 20px" Width="400px">Tolovaj,OnLine™,Tolovaj+</asp:TextBox>
        <asp:Label ID="LabelNap" runat="server" 
            Style="z-index: 112; left: 300px; position: absolute; top: 50px" 
            Text="Nap" Width="50px" BackColor="Yellow"></asp:Label>
        <asp:TextBox ID="TextBoxNap" runat="server" 
            Style="z-index: 113; left: 360px; position: absolute; top: 50px" Width="400px"></asp:TextBox>
        <asp:Label ID="LabelWar" runat="server" 
            Style="z-index: 114; left: 300px; position: absolute; top: 80px" 
            Text="War" Width="50px" BackColor="Red"></asp:Label>
        <asp:TextBox ID="TextBoxWar" runat="server" 
            Style="z-index: 115; left: 360px; position: absolute; top: 80px" Width="400px"></asp:TextBox>
        <asp:Label ID="LabelAliance" runat="server" 
            Style="z-index: 116; left: 300px; position: absolute; top: 110px" 
            Text="Aliance" Width="50px" BackColor="Green"></asp:Label>
        <asp:TextBox ID="textBoxAliance" runat="server" 
            Style="z-index: 117; left: 360px; position: absolute; top: 110px" Width="400px">Tolovaj*</asp:TextBox>

		<asp:Label ID="labelErrorMSG" runat="server" 
			Style="z-index: 118; left: 20px; position: absolute; top: 140px" 
			Text=""></asp:Label>
		<asp:Table ID="tableMap" runat="server" 
			Style="z-index: 121; left: 20px; position: absolute; top: 170px;" OnDataBinding="linkButtonRefreshMap_Click">
		</asp:Table>
		<asp:TextBox ID="TextBoxResults" runat="server" Height="408px" TextMode="MultiLine" Width="1500px" 
			Style="z-index: 119; left: 20px; position: absolute; top: 2000px"></asp:TextBox>

    </div>
    </form>
</body>
</html>
