<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageShopItems.aspx.cs" Inherits="ProductTracker.Web.ManageShopItems" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
    <head runat="server">
        <title>Shop Items</title>
        <link href="Stylesheet.css" type="text/css" rel="Stylesheet"/>
    </head>
    <body>
        <form id="formManageShopItems" runat="server">
            <div id="divMain">
                <div id="divHead">
                    <asp:Panel ID="PanelHead" runat="server">
                        <table id="tableHead">
                            <tr>
                                <td>
                                    <asp:HyperLink ID="HyperLinkMain" runat="server" 
                                        NavigateUrl="~/Default.aspx" CssClass="hyperLink">Main</asp:HyperLink>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </div>
                <div id="divAddShopItem">
                    <asp:Panel ID="PanelShopItem" runat="server">
                        <table id="tableShopItem">
                            <tr>
                                <td>
                                    <asp:Label ID="LabelItems" runat="server" Text="Items"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="DropDownListItems" runat="server" DataTextField="Name" DataValueField="UniqueId">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:Label ID="LabelShops" runat="server" Text="Shops"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="DropDownListShops" runat="server" DataTextField="Name" DataValueField="Id">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:Label ID="LabelPriceGross" runat="server" Text="Price Gross"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBoxPriceGross" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Label ID="LabelPriceNet" runat="server" Text="Price Net"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBoxPriceNet" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Label ID="LabelNumberOfItems" runat="server" Text="Number Of Items"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBoxNumberOfItems" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:LinkButton ID="LinkButtonAddItemToShop" runat="server" 
                                        onclick="LinkButtonAddItemToShopClick">Add Item To Shop</asp:LinkButton>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </div>
                <div id="divShopItems">
                    <asp:GridView ID="GridViewShopItems" runat="server">
                    </asp:GridView>
                </div>
            </div>
        </form>
    </body>
</html>
