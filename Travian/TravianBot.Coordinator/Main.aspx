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
            <asp:LinkButton ID="linkButtonLogout" runat="server" 
                onclick="LinkButtonLogout_Click">Logout</asp:LinkButton>
        </div>
        <div>
            <div>
				<table>
					<tr>
						<td class="Navigation">
							<asp:Label ID="LabelVillages" runat="server" Text="Villages"></asp:Label>
						</td>
						<td class="Navigation">
							<asp:Label ID="LabelExludedUsers" runat="server" Text="Exluded Users"></asp:Label>
						</td>
						<td class="Navigation">
							<asp:Label ID="LabelExludedAliances" runat="server" Text="Exluded Aliances"></asp:Label>
						</td>
						<td class="Navigation">
							<asp:Label ID="LabelNextFarm" runat="server" Text="Next Farm"></asp:Label>
						</td>
					</tr>
					<tr>
						<td class="Navigation">
							<asp:DropDownList ID="DropDownListVillages" runat="server">
							</asp:DropDownList>
						</td>
						<td class="Navigation">
							<asp:DropDownList ID="DropDownListExcludedUsers" runat="server">
							</asp:DropDownList>
						</td>
						<td class="Navigation">
							<asp:DropDownList ID="DropDownListExcludedAliances" runat="server">
							</asp:DropDownList>
						</td>
						<td class="Navigation">
							<asp:LinkButton ID="linkButtonNextFarm" runat="server">[NOT SET]</asp:LinkButton>
						</td>
					</tr>
				</table>
            </div>
            <div>
                <asp:LinkButton ID="linkButtonGetFarms" runat="server" 
                    onclick="LinkButtonGetFarms_Click" >GetFarms</asp:LinkButton>
            </div>
            <div>
                <asp:GridView ID="gridViewFarms" runat="server" AllowPaging="True" 
					AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" 
					DataSourceID="SqlDataSourceCoordinator" ForeColor="#333333" GridLines="None" 
					PageSize="20">
					<RowStyle BackColor="#E3EAEB" />
					<Columns>
						<asp:BoundField DataField="PlayerName" HeaderText="PlayerName" 
							SortExpression="PlayerName" />
						<asp:BoundField DataField="AlianceName" HeaderText="AlianceName" 
							SortExpression="AlianceName" />
						<asp:BoundField DataField="VillageName" HeaderText="VillageName" 
							SortExpression="VillageName" />
						<asp:BoundField DataField="TribeId" HeaderText="TribeId" 
							SortExpression="TribeId" />
						<asp:BoundField DataField="Population" HeaderText="Population" 
							SortExpression="Population" />
						<asp:CommandField InsertVisible="False" 
							ShowEditButton="True" ShowSelectButton="True" />
					</Columns>
					<FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
					<PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
					<SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
					<HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
					<EditRowStyle BackColor="#7C6F57" />
					<AlternatingRowStyle BackColor="White" />
                </asp:GridView>
            	<asp:SqlDataSource ID="SqlDataSourceCoordinator" runat="server" 
					ConnectionString="<%$ ConnectionStrings:Coordinator %>" 
					ProviderName="<%$ ConnectionStrings:Coordinator.ProviderName %>" 
					SelectCommand="SELECT [PlayerName], [AlianceName], [VillageName], [TribeId], [Population] FROM [Map]">
				</asp:SqlDataSource>
            </div>
        </div>
    </form>
</body>
</html>
