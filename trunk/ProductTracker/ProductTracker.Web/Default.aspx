<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ProductTracker.Web.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
    <head runat="server">
        <title>Product Tracker</title>
        <link href="Stylesheet.css" type="text/css" rel="Stylesheet"/>
    </head>
    <body>
        <form id="FormDefault" runat="server">
            <div id="divMain">
                <div id="divHead">
                    <asp:Panel ID="PanelHead" runat="server">
                        <table id="tableHead">
                            <tr>
                                <td>
                                    <asp:LinkButton ID="LinkButtonShops" runat="server" 
                                        onclick="LinkButtonShops_Click" CssClass="linkButton">Shops</asp:LinkButton>
                                </td>
                                <td>
                                    <asp:LinkButton ID="LinkButtonItems" runat="server" 
                                        onclick="LinkButtonItems_Click" CssClass="linkButton">Items</asp:LinkButton>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </div>
                <div id="divMiddle">
                    <asp:Panel ID="PanelMiddle" runat="server">
                        <div id="divMiddleHead">
                        </div>
                        <div id="divMiddleGridView">
                            <asp:Panel ID="PanelMiddleGridView" runat="server">
                                <table id="tableMiddleGridView">
                                    <tr>
                                        <td>
                                            <asp:GridView ID="GridViewItems" runat="server">
                                            </asp:GridView>
                                            <asp:GridView ID="GridViewShops" runat="server">
                                            </asp:GridView>
                                            <asp:SqlDataSource ID="SqlDataSource" runat="server" 
                                                ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
                                                ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>">
                                            </asp:SqlDataSource>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </div>
                    </asp:Panel>
                </div>
                <div id="divFoot">
                    <asp:Panel ID="PanelFoot" runat="server">
                        <table id="tableFoot">
                            <tr>
                                <td>
                                    <asp:HyperLink ID="HyperLinkManageItems" runat="server" 
                                        NavigateUrl="~/ManageItems.aspx" CssClass="hyperLink">Manage Items</asp:HyperLink>    
                                    <asp:HyperLink ID="HyperLinkManageShops" runat="server" 
                                        NavigateUrl="~/ManageShops.aspx" CssClass="hyperLink">Manage Shops</asp:HyperLink>    
                                    <asp:HyperLink ID="HyperLinkManageShopItems" runat="server" 
                                        NavigateUrl="~/ManageShopItems.aspx" CssClass="hyperLink">Manage Shop Items</asp:HyperLink>    
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </div>
            </div>
        </form>
    </body>
</html>
