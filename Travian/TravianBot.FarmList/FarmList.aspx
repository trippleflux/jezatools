<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="FarmList.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>FarmList</title>
</head>
<body>
    <form id="formFarmList" runat="server">
		<div>
			<asp:GridView ID="GridViewFarmList" runat="server" AutoGenerateColumns="False" 
				DataSourceID="XmlDataSourceFarmList" CellPadding="4" ForeColor="#333333" 
				GridLines="None" AllowPaging="True" PageSize="28">
				<RowStyle BackColor="#E3EAEB" />
				<Columns>
					<asp:BoundField DataField="id" HeaderText="Id" SortExpression="id">
						<HeaderStyle HorizontalAlign="Left" />
					</asp:BoundField>
					<asp:HyperLinkField DataNavigateUrlFields="playerlink" 
						DataTextField="playername" HeaderText="Player" >
						<HeaderStyle HorizontalAlign="Left" />
					</asp:HyperLinkField>
					<asp:HyperLinkField DataNavigateUrlFields="aliancelink" DataTextField="aliance" 
						HeaderText="Aliance" >
						<HeaderStyle HorizontalAlign="Left" />
					</asp:HyperLinkField>
					<asp:HyperLinkField DataNavigateUrlFields="villagelink" 
						DataTextField="villagename" HeaderText="Village" >
						<HeaderStyle HorizontalAlign="Left" />
					</asp:HyperLinkField>
					<asp:BoundField DataField="population" HeaderText="Population" 
						SortExpression="population">
						<HeaderStyle HorizontalAlign="Left" />
					</asp:BoundField>
					<asp:BoundField DataField="comment" HeaderText="Comment" 
						SortExpression="comment">
						<HeaderStyle HorizontalAlign="Left" />
					</asp:BoundField>
					<asp:BoundField DataField="coordinateX" HeaderText="coordinateX" 
						SortExpression="coordinateX" >
						<HeaderStyle HorizontalAlign="Left" />
					</asp:BoundField>
					<asp:BoundField DataField="coordinateY" HeaderText="coordinateY" 
						SortExpression="coordinateY" >
						<HeaderStyle HorizontalAlign="Left" />
					</asp:BoundField>
				</Columns>
				<FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
				<PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
				<SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
				<HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
				<EditRowStyle BackColor="#7C6F57" />
				<AlternatingRowStyle BackColor="White" />
			</asp:GridView>
			<asp:XmlDataSource ID="XmlDataSourceFarmList" runat="server" 
				DataFile="~/FarmList.xml"></asp:XmlDataSource>
		</div>
    </form>
</body>
</html>
