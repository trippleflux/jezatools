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
            <table>
                <tr>
                    <td class="Navigation"  >
                        <asp:LinkButton ID="linkButtonFarms" runat="server" 
                            onclick="LinkButtonFarms_Click">Farms</asp:LinkButton>
                    </td>
                    <td class="Navigation"  >
                        <asp:LinkButton ID="linkButtonVillages" runat="server">Villages</asp:LinkButton>
                    </td>
                    <td class="Navigation"  >
                        <asp:LinkButton ID="linkButtonNotes" runat="server">Notes</asp:LinkButton>
                    </td>
                </tr>
            </table>
        </div>
        <div style="background-color: #CCFFCC">
            <div>
                <asp:Label ID="labelCoordinatesStart" runat="server" Text="Coordinates: ("></asp:Label>
                <asp:TextBox ID="textBoxCoordsX" runat="server" CssClass="Coordinates"></asp:TextBox>
                <asp:Label ID="labelCoordinatesMidle" runat="server" Text=")|("></asp:Label>
                <asp:TextBox ID="textBoxCoordsY" runat="server" CssClass="Coordinates"></asp:TextBox>
                <asp:Label ID="labelCoordinatesEnd" runat="server" Text=")"></asp:Label>
            </div>
            <div>
                <asp:LinkButton ID="linkButtonGetFarms" runat="server" 
                    onclick="LinkButtonGetFarms_Click" >GetFarms</asp:LinkButton>
            </div>
            <div>
                <asp:GridView ID="gridViewFarms" runat="server">
                </asp:GridView>
            </div>
        </div>
    </form>
</body>
</html>
