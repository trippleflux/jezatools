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
                <div id="divManageShopItemsBody" class="divManageShopItemsBody">
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
                </div>
                <div id="divManageShopItemsBodyList" class="divManageShopItemsBodyList">
                    <asp:GridView id="gridViewManageShopItemsBodyList" 
                        CssClass="gridViewManageShopItemsBodyList" runat="server" 
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
                <div id="divManageShopItemsBodyTrackers" class="divManageShopItemsBodyTrackers">
                    <div id="divManageShopItemsBodyTrackersInput" class="divManageShopItemsBodyTrackersInput">
                        <table id="tableManageShopItemsBodyTrackersInput" class="tableManageShopItemsBodyTrackersInput">
                            <tr>
                                <td>
                                    <asp:Label ID="labelManageShopItemsBodyTrackersInputShopItem" CssClass="labelManageShopItemsBodyTrackersInputShopItem" runat="server" Text="Shop item"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="labelManageShopItemsBodyTrackersInputDateTime" CssClass="labelManageShopItemsBodyTrackersInputDateTime" runat="server" Text="DateTime"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="labelManageShopItemsBodyTrackersInputSoldCount" CssClass="labelManageShopItemsBodyTrackersInputSoldCount" runat="server" Text="Sold count"></asp:Label>
                                </td>
                                <td>
                                    
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:TextBox ID="textBoxManageShopItemsBodyTrackersInputShopItem" 
                                        CssClass="textBoxManageShopItemsBodyTrackersInputShopItem" runat="server" 
                                        ReadOnly="True"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="textBoxManageShopItemsBodyTrackersInputDateTime" CssClass="textBoxManageShopItemsBodyTrackersInputDateTime" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="textBoxManageShopItemsBodyTrackersInputSoldCount" CssClass="textBoxManageShopItemsBodyTrackersInputSoldCount" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:LinkButton ID="linkButtonManageShopItemsBodyTrackersInputAdd" 
                                        CssClass="linkButtonManageShopItemsBodyTrackersInputAdd" runat="server" 
                                        onclick="linkButtonManageShopItemsBodyTrackersInputAdd_Click">Add</asp:LinkButton>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div id="divManageShopItemsBodyTrackersList" class="divManageShopItemsBodyTrackersList">
                        <table id="tableManageShopItemsBodyTrackersList" class="tableManageShopItemsBodyTrackersList">
                            <tr>
                                <td>
                                    <asp:GridView ID="gridViewManageShopItemsBodyTrackersList" CssClass="gridViewManageShopItemsBodyTrackersList" runat="server" AutoGenerateColumns="false">
                                        <Columns>
                                            <asp:BoundField DataField="DateTime" HeaderText="DateTime" />
                                            <asp:BoundField DataField="SoldCount" HeaderText="Count" />
                                        </Columns>
                                    </asp:GridView>
                                </td>
                                <td>
                                    <table id="tableManageShopItemsBodyTrackersStats" class="tableManageShopItemsBodyTrackersStats">
                                        <tr>
                                            <td>
                                                <asp:Label ID="labelManageShopItemsBodyTrackersStatsTotal" CssClass="labelManageShopItemsBodyTrackersStatsTotal" runat="server" Text="Total Items"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="labelManageShopItemsBodyTrackersStatsTotalNumber" CssClass="labelManageShopItemsBodyTrackersStatsTotalNumber" runat="server" Text="0"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="labelManageShopItemsBodyTrackersStatsSold" CssClass="labelManageShopItemsBodyTrackersStatsSold" runat="server" Text="Total Sold"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="labelManageShopItemsBodyTrackersStatsSoldNumber" CssClass="labelManageShopItemsBodyTrackersStatsSoldNumber" runat="server" Text="0"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="labelManageShopItemsBodyTrackersStatsGrossReceived" CssClass="labelManageShopItemsBodyTrackersStatsGrossReceived" runat="server" Text="Gross Received"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="labelManageShopItemsBodyTrackersStatsGrossReceivedNumber" CssClass="labelManageShopItemsBodyTrackersStatsGrossReceivedNumber" runat="server" Text="0"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="labelManageShopItemsBodyTrackersStatsNetReceived" CssClass="labelManageShopItemsBodyTrackersStatsNetReceived" runat="server" Text="Net Received"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="labelManageShopItemsBodyTrackersStatsNetReceivedNumber" CssClass="labelManageShopItemsBodyTrackersStatsNetReceivedNumber" runat="server" Text="0"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div id="divManageShopItemsBodyStats" class="divManageShopItemsBodyStats">
                        
                    </div>
                </div>
                <div id="divManageShopItemsBodyFoot" class="divManageShopItemsBodyFoot">
                    <asp:Label id="labelManageShopItemsStatus" CssClass="labelManageShopItemsStatus" runat="server" Text=""></asp:Label>
                </div>
            </div>
        </form>
    </body>
</html>
