<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ProductTracker.Web.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
    <head runat="server">
        <title>Product Tracker</title>
        <link href="Stylesheet.css" type="text/css" rel="Stylesheet"/>
    </head>
    <body>
        <form id="formDefault" runat="server">
            <div id="divDefault">
                <div id="divDefaultHead">
                    <asp:LinkButton id="linkButtonShops" runat="server" 
                        onclick="LinkButtonShops_Click">Shops</asp:LinkButton>
                    <asp:LinkButton id="linkButtonItems" runat="server" 
                        onclick="LinkButtonItems_Click">Items</asp:LinkButton>
                </div>
                <div id="divDefaultNavigation">
                    <asp:HyperLink id="hyperLinkDefaultManageItems" runat="server" 
                        NavigateUrl="~/ManageItems.aspx">Manage Items</asp:HyperLink>    
                    <asp:HyperLink id="hyperLinkDefaultManageShops" runat="server" 
                        NavigateUrl="~/ManageShops.aspx">Manage Shops</asp:HyperLink>    
                    <asp:HyperLink id="hyperLinkDefaultManageShopItems" runat="server" 
                        NavigateUrl="~/ManageShopItems.aspx">Manage Shop Items</asp:HyperLink>    
                </div>
                <div id="divDefaultBody">
                    <div id="divDefaultBodyGridView">
                        <asp:GridView id="gridViewDefaultBodyItems"
                            runat="server" AutoGenerateColumns="False" 
                            AllowPaging="True" onpageindexchanging="GridViewItems_PageIndexChanging">
                            <Columns>
                                <asp:BoundField DataField="Id" HeaderText="Id" />
                                <asp:BoundField DataField="Name" HeaderText="Name" />
                                <asp:BoundField DataField="ItemTypeName" HeaderText="Type" />
                                <asp:BoundField DataField="Notes" HeaderText="Notes" />
                            </Columns>
                        </asp:GridView>
                        <asp:GridView id="gridViewDefaultBodyShops" 
                            runat="server" AutoGenerateColumns="False" 
                            AllowPaging="True" onpageindexchanging="GridViewShops_PageIndexChanging">
                            <Columns>
                                <asp:BoundField DataField="Name" HeaderText="Name" />
                                <asp:BoundField DataField="Address" HeaderText="Address" />
                                <asp:BoundField DataField="Owner" HeaderText="Owner" />
                                <asp:BoundField DataField="PostalCode" HeaderText="PostalCode" />
                                <asp:BoundField DataField="City" HeaderText="City" />
                                <asp:CheckBoxField DataField="IsCompany" HeaderText="IsCompany" />
                            </Columns>
                        </asp:GridView>
                        <asp:SqlDataSource ID="SqlDataSource" runat="server" 
                            ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
                            ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>">
                        </asp:SqlDataSource>
                    </div>
                </div>
            </div>
        </form>
    </body>
</html>
