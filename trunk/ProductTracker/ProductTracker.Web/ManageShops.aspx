<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageShops.aspx.cs" Inherits="ProductTracker.Web.ManageShops" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
    <head runat="server">
        <title>Shops</title>
    </head>
    <body>
        <form id="formManageShops" runat="server">
            <div id="divMain">
                <div id="divHead">
                    <asp:Panel ID="PanelHead" runat="server">
                        <table id="tableHead">
                            <tr>
                                <td>
                                    <asp:HyperLink ID="HyperLinkManageItems" runat="server" 
                                        NavigateUrl="~/Default.aspx">Main</asp:HyperLink>

                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </div>
            </div>
        </form>
    </body>
</html>
