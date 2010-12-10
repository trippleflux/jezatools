<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageShopItems.aspx.cs" Inherits="ProductTracker.Web.ManageShopItems" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
    <head runat="server">
        <title>Product Tracker</title>
        <link href="Stylesheet.css" type="text/css" rel="Stylesheet"/>
    </head>
    <body>
        <form id="formManageShopItems" runat="server">
            <div id="divManageShopItems">
                <div id="divManageShopItemsHead">
                    <asp:HyperLink id="hyperLinkManageShopItemsMain" runat="server" NavigateUrl="~/Default.aspx">Main</asp:HyperLink>
                </div>
                <div id="divManageShopItemsBodyInput">
                    <div>
                        <asp:Label id="labelManageShopItemsBodyInputItems" runat="server" Text="Items"></asp:Label>
                        <asp:DropDownList id="dropDownListManageShopItemsBodyInputItems" runat="server" DataTextField="Name" DataValueField="UniqueId">
                        </asp:DropDownList>
                    </div>
                    <div>
                        <asp:Label id="labelManageShopItemsBodyInputShops" runat="server" Text="Shops"></asp:Label>
                        <asp:DropDownList id="dropDownListManageShopItemsBodyInputShops" runat="server" DataTextField="Name" DataValueField="Id">
                        </asp:DropDownList>
                    </div>
                    <div>
                        <asp:Label id="labelManageShopItemsBodyInputPriceGross" runat="server" Text="Price Gross"></asp:Label>
                        <asp:TextBox id="textBoxManageShopItemsBodyInputPriceGross" runat="server"></asp:TextBox>
                    </div>
                    <div>
                        <asp:Label id="labelManageShopItemsBodyInputPriceNet" runat="server" Text="Price Net"></asp:Label>
                        <asp:TextBox id="textBoxManageShopItemsBodyInputPriceNet" runat="server"></asp:TextBox>
                    </div>
                    <div>
                        <asp:Label id="labelManageShopItemsBodyInputNumberOfItems" runat="server" Text="Number Of Items"></asp:Label>
                        <asp:TextBox id="textBoxManageShopItemsBodyInputNumberOfItems" runat="server"></asp:TextBox>
                    </div>
                    <div>
                        <asp:LinkButton id="linkButtonManageShopItemsBodyInputAdd" runat="server" onclick="LinkButtonAddItemToShopClick">Add Item To Shop</asp:LinkButton>
                    </div>
                </div>
                <div id="divManageShopItemsBodyTrackers">
                    <div id="divManageShopItemsBodyTrackersInput">
                        <div>
                            <asp:Label ID="labelManageShopItemsBodyTrackersInputShopItem" runat="server" Text="Shop item"></asp:Label>
                            <asp:TextBox ID="textBoxManageShopItemsBodyTrackersInputShopItem" runat="server" ReadOnly="True"></asp:TextBox>
                        </div>
                        <div>
                            <asp:Label ID="labelManageShopItemsBodyTrackersInputDateTime" runat="server" Text="DateTime"></asp:Label>
                            <asp:TextBox ID="textBoxManageShopItemsBodyTrackersInputDateTime" runat="server"></asp:TextBox>
                        </div>
                        <div>
                            <asp:Label ID="labelManageShopItemsBodyTrackersInputSoldCount" runat="server" Text="Sold count"></asp:Label>
                            <asp:TextBox ID="textBoxManageShopItemsBodyTrackersInputSoldCount" runat="server"></asp:TextBox>
                        </div>
                        <div>
                            <asp:LinkButton ID="linkButtonManageShopItemsBodyTrackersInputAdd" runat="server" onclick="LinkButtonManageShopItemsBodyTrackersInputAddClick">Add</asp:LinkButton>
                        </div>
                    </div>
                    <div id="divManageShopItemsBodyTrackersList">
                        <asp:GridView ID="gridViewManageShopItemsBodyTrackersList" runat="server" AutoGenerateColumns="false">
                            <Columns>
                                <asp:BoundField DataField="DateTime" HeaderText="DateTime" />
                                <asp:BoundField DataField="SoldCount" HeaderText="Count" />
                            </Columns>
                        </asp:GridView>
                    </div>
                    <div id="divManageShopItemsBodyTrackersListStats">
                        <div class="divManageShopItemsBodyTrackersListStats">
                            <asp:Label ID="labelManageShopItemsBodyTrackersStatsTotal" runat="server" Text="Total Items"></asp:Label>
                            <asp:Label ID="labelManageShopItemsBodyTrackersStatsTotalNumber" runat="server" Text="0"></asp:Label>
                        </div>
                        <div class="divManageShopItemsBodyTrackersListStats">
                            <asp:Label ID="labelManageShopItemsBodyTrackersStatsSold" runat="server" Text="Total Sold"></asp:Label>
                            <asp:Label ID="labelManageShopItemsBodyTrackersStatsSoldNumber" runat="server" Text="0"></asp:Label>
                        </div>
                        <div class="divManageShopItemsBodyTrackersListStats">
                            <asp:Label ID="labelManageShopItemsBodyTrackersStatsGrossReceived" runat="server" Text="Gross Received"></asp:Label>
                            <asp:Label ID="labelManageShopItemsBodyTrackersStatsGrossReceivedNumber" runat="server" Text="0"></asp:Label>
                        </div>
                        <div class="divManageShopItemsBodyTrackersListStats">
                            <asp:Label ID="labelManageShopItemsBodyTrackersStatsNetReceived" runat="server" Text="Net Received"></asp:Label>
                            <asp:Label ID="labelManageShopItemsBodyTrackersStatsNetReceivedNumber" runat="server" Text="0"></asp:Label>
                        </div>
                    </div>
                </div>
                <div id="divManageShopItemsBodyList">
                    <asp:GridView id="gridViewManageShopItemsBodyList" 
                            runat="server" 
                            onrowdeleted="GridViewShopItems_RowDeleted" 
                            onrowdeleting="GridViewShopItems_RowDeleting" AutoGenerateColumns="False" 
                            onselectedindexchanging="gridViewManageShopItemsBodyList_SelectedIndexChanging">
                      <Columns>
                        <asp:BoundField DataField="DateTime" HeaderText="Date" />
                        <asp:BoundField DataField="NumberOfItems" HeaderText="Count" />
                        <asp:BoundField DataField="PriceGross" HeaderText="Price Gross" />
                        <asp:BoundField DataField="PriceNet" HeaderText="Price Net" />
                        <asp:BoundField DataField="Item" HeaderText="Item" />
                        <asp:BoundField DataField="Shop" HeaderText="Shop" />
                      </Columns>
                    </asp:GridView>
                </div>
                <div id="divManageShopItemsBodyFoot">
                    <asp:Label id="labelManageShopItemsStatus" runat="server" Text=""></asp:Label>
                </div>
            </div>
        </form>
    </body>
</html>
