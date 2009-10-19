<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Administration.aspx.cs" Inherits="Administration" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
	<head runat="server">
		<title>Administration</title>
		<link type="text/css" rel="Stylesheet" href="CoordinatorStyle.css" />
	</head>
	<body>
		<form id="formAdministration" runat="server">
			<div>
				<div>
					<table>
						<tr>
							<td class="Navigation">
								<asp:LinkButton ID="linkButtonLogout" runat="server" onclick="LinkButtonLogout_Click">Logout</asp:LinkButton>
							</td>
							<td class="Navigation">
								<asp:HyperLink ID="HyperLinkMain" runat="server" NavigateUrl="Main.aspx">Main</asp:HyperLink>
							</td>
						</tr>
					</table>
				</div>
				<div>
					<asp:GridView ID="GridViewUsers" runat="server" AllowPaging="True" 
						CellPadding="4" ForeColor="#333333" GridLines="None">
						<RowStyle BackColor="#E3EAEB" />
						<FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
						<PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
						<SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
						<HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
						<EditRowStyle BackColor="#7C6F57" />
						<AlternatingRowStyle BackColor="White" />
					</asp:GridView>
				</div>
				<div>
					<asp:Label ID="LabelStatus" runat="server" Text=""></asp:Label>
				</div>
			</div>
		</form>
	</body>
</html>
