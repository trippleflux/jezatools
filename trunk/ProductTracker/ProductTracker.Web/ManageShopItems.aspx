<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageShopItems.aspx.cs" Inherits="ProductTracker.Web.ManageShopItems" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
    <head runat="server">
        <title>Product Tracker</title>
        <link href="Stylesheet.css" type="text/css" rel="Stylesheet"/>
    </head>
    <body>
        <form id="formManageShopItems" runat="server">
            <div id="divManageShopItems" class="divManageShopItems">
                <div id="divManageShopItemsHead" class="divManageShopItemsHead">
                    <asp:Panel id="PanelHead" runat="server">
                        <table id="tableHead">
                            <tr>
                                <td>
                                    <asp:HyperLink id="hyperLinkManageShopItemsMain" runat="server" 
                                        NavigateUrl="~/Default.aspx" CssClass="hyperLinkManageShopItemsMain">Main</asp:HyperLink>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </div>
                <div id="divManageShopItemsBodyInput" class="divManageShopItemsBodyInput">
                    <asp:Panel id="panelManageShopItemsBodyInput" CssClass="panelManageShopItemsBodyInput" runat="server">
                        <table id="tableManageShopItemsBodyInput" class="tableManageShopItemsBodyInput">
                            <tr>
                                <td>
                                    <asp:Label id="labelManageShopItemsBodyInputItems" CssClass="labelManageShopItemsBodyInputItems" runat="server" Text="Items"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label id="labelManageShopItemsBodyInputShops" CssClass="labelManageShopItemsBodyInputShops" runat="server" Text="Shops"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label id="labelManageShopItemsBodyInputPriceGross" CssClass="labelManageShopItemsBodyInputPriceGross" runat="server" Text="Price Gross"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label id="labelManageShopItemsBodyInputPriceNet" CssClass="labelManageShopItemsBodyInputPriceNet" runat="server" Text="Price Net"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label id="labelManageShopItemsBodyInputNumberOfItems" CssClass="labelManageShopItemsBodyInputNumberOfItems" runat="server" Text="Number Of Items"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:DropDownList id="dropDownListManageShopItemsBodyInputItems" CssClass="dropDownListManageShopItemsBodyInputItems" runat="server" DataTextField="Name" DataValueField="UniqueId">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:DropDownList id="dropDownListManageShopItemsBodyInputShops" CssClass="dropDownListManageShopItemsBodyInputShops" runat="server" DataTextField="Name" DataValueField="Id">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:TextBox id="textBoxManageShopItemsBodyInputPriceGross" CssClass="textBoxManageShopItemsBodyInputPriceGross" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox id="textBoxManageShopItemsBodyInputPriceNet" CssClass="textBoxManageShopItemsBodyInputPriceNet" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox id="textBoxManageShopItemsBodyInputNumberOfItems" CssClass="textBoxManageShopItemsBodyInputNumberOfItems" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:LinkButton id="linkButtonManageShopItemsBodyInputAdd" CssClass="linkButtonManageShopItemsBodyInputAdd" runat="server" 
                                        onclick="LinkButtonAddItemToShopClick">Add Item To Shop</asp:LinkButton>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </div>
                <div id="divManageShopItemsBodyList" class="divManageShopItemsBodyList">
                    <asp:GridView id="gridViewManageShopItemsBodyList" 
                        CssClass="gridViewManageShopItemsBodyList" runat="server" 
                        onrowdeleted="GridViewShopItems_RowDeleted" 
                        onrowdeleting="GridViewShopItems_RowDeleting" AutoGenerateColumns="False">
                        <Columns>
                            <asp:BoundField DataField="DateTime" HeaderText="Date" />
                            <asp:BoundField DataField="NumberOfItems" HeaderText="Count" />
                            <asp:BoundField DataField="PriceGross" HeaderText="Price Gross" />
                            <asp:BoundField DataField="PriceNet" HeaderText="Price Net" />
                            <asp:BoundField DataField="Item" HeaderText="Item" />
                            <asp:BoundField DataField="Shop" HeaderText="Shop" />
                            <asp:CommandField ShowDeleteButton="True" />
                        </Columns>
                    </asp:GridView>
                </div>
                <div id="divManageShopItemsBodyFoot" class="divManageShopItemsBodyFoot">
                    <asp:Label id="labelManageShopItemsStatus" CssClass="labelManageShopItemsStatus" runat="server" Text=""></asp:Label>
                </div>
            </div>
        </form>
    </body>
</html>
