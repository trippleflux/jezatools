<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Main.aspx.cs" Inherits="Main" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
	<head runat="server">
		<title>Coordinator</title>
		<link type="text/css" rel="Stylesheet" href="CoordinatorStyle.css" />
	</head>
	<body>
		<form id="formMain" runat="server">
			<div>
				<div>
					<asp:LinkButton ID="linkButtonLogout" runat="server" 
						onclick="LinkButtonLogout_Click">Logout</asp:LinkButton>
				</div>
				<div>
					<div>
						<table>
							<tr>
								<td>
									<asp:Label ID="labelCenterCoordinates" runat="server" Text="Center Coordinates : "></asp:Label>
								</td>
								<td class="TdExcludedList">
									<asp:Label ID="labelCoordinates" runat="server" Text="( -13 | 6 )"></asp:Label>
								</td>
							</tr>
							<tr>
								<td>
									<asp:Label ID="labelDistanceX" runat="server" Text="DistanceX : "></asp:Label>
								</td>
								<td class="TdExcludedList">
									<asp:TextBox ID="TextBoxDistanceX" runat="server" 
										CssClass="TextBoxExcludedList">30</asp:TextBox>
								</td>
							</tr>
							<tr>
								<td>
									<asp:Label ID="labelDistanceY" runat="server" Text="DistanceY : "></asp:Label>
								</td>
								<td class="TdExcludedList">
									<asp:TextBox ID="TextBoxDistanceY" runat="server" 
										CssClass="TextBoxExcludedList">30</asp:TextBox>
								</td>
							</tr>
							<tr>
								<td>
									<asp:Label ID="labelNextFarm" runat="server" Text="Next Farm : "></asp:Label>
								</td>
								<td class="TdExcludedList">
									<asp:TextBox ID="TextBoxNextFarm" runat="server" 
										CssClass="TextBoxExcludedList"></asp:TextBox>
								</td>
							</tr>
							<tr>
								<td>
									<asp:Label ID="labelAlly" runat="server" Text="Ally : "></asp:Label>
								</td>
								<td class="TdExcludedList">
									<asp:TextBox ID="TextBoxAlly" runat="server" 
										CssClass="TextBoxExcludedList">16,69,73,79,239</asp:TextBox>
								</td>
							</tr>
							<tr>
								<td>
									<asp:Label ID="labelNap" runat="server" Text="Nap : "></asp:Label>
								</td>
								<td class="TdExcludedList">
									<asp:TextBox ID="TextBoxNap" runat="server" 
										CssClass="TextBoxExcludedList">227,257</asp:TextBox>
								</td>
							</tr>
							<tr>
								<td>
									<asp:Label ID="labelExcludedPlayers" runat="server" Text="Excluded Players : "></asp:Label>
								</td>
								<td class="TdExcludedList">
									<asp:TextBox ID="TextBoxExcludedPlayers" runat="server" 
										CssClass="TextBoxExcludedList">4,155,954,3694</asp:TextBox>
								</td>
							</tr>
							<tr>
								<td>
									<asp:Label ID="labelExcludedAlliances" runat="server" Text="Excluded Alliances : "></asp:Label>
								</td>
								<td class="TdExcludedList">
									<asp:TextBox ID="TextBoxExcludedAlliances" runat="server" 
										CssClass="TextBoxExcludedList">1,38,67,78,90,183,200</asp:TextBox>
								</td>
							</tr>
						</table>
					</div>
					<div>
						<asp:LinkButton ID="LinkButtonUpdate" runat="server" 
							onclick="LinkButtonUpdate_Click">Update</asp:LinkButton>
					</div>
					<div>
						<asp:Label ID="LabelStatus" runat="server" Text=""></asp:Label>
					</div>
					<div>
						<asp:GridView ID="gridViewFarms" runat="server" 
						AllowPaging="True" 
						onpageindexchanging="gridViewFarms_PageIndexChanging" CellPadding="4" ForeColor="#333333" 
							GridLines="None" AutoGenerateColumns="False" PageSize="20" 
							onrowcancelingedit="gridViewFarms_RowCancelingEdit" 
							onrowediting="gridViewFarms_RowEditing" 
							onrowupdating="gridViewFarms_RowUpdating">
							<RowStyle BackColor="#E3EAEB" />
							<Columns>
								<asp:BoundField DataField="Id" HeaderText="Coordinates" >
									<HeaderStyle HorizontalAlign="Left" />
								</asp:BoundField>
								<asp:HyperLinkField DataNavigateUrlFields="UserId" 
									DataNavigateUrlFormatString="http://s1.travian.si/spieler.php?uid={0}" 
									DataTextField="UserName" HeaderText="Player" >
									<HeaderStyle HorizontalAlign="Left" />
								</asp:HyperLinkField>
								<asp:HyperLinkField DataNavigateUrlFields="AllianceId" 
									DataNavigateUrlFormatString="http://s1.travian.si/allianz.php?aid={0}" 
									DataTextField="AllianceName" HeaderText="Aliance" >
									<HeaderStyle HorizontalAlign="Left" />
								</asp:HyperLinkField>
								<asp:HyperLinkField DataNavigateUrlFields="Id" 
									DataNavigateUrlFormatString="http://s1.travian.si/a2b.php?z={0}" 
									DataTextField="VillageName" HeaderText="Village" >
									<HeaderStyle HorizontalAlign="Left" />
								</asp:HyperLinkField>
								<asp:BoundField DataField="Tribe" HeaderText="Tribe" ReadOnly="True" >
									<HeaderStyle HorizontalAlign="Left" />
								</asp:BoundField>
								<asp:BoundField DataField="Population" HeaderText="Population" 
									ReadOnly="True" >
									<HeaderStyle HorizontalAlign="Left" />
								</asp:BoundField>
								<asp:BoundField DataField="Distance" HeaderText="Distance" ReadOnly="True" >
									<HeaderStyle HorizontalAlign="Left" />
								</asp:BoundField>
								<asp:BoundField DataField="Notes" HeaderText="Notes" >
									<HeaderStyle HorizontalAlign="Left" />
								</asp:BoundField>
								<asp:CommandField ShowEditButton="True" />
							</Columns>
							<FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
							<PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
							<SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
							<HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
							<EditRowStyle BackColor="#7C6F57" />
							<AlternatingRowStyle BackColor="White" />
						</asp:GridView>
					</div>
				</div>
			</div>
		</form>
	</body>
</html>
