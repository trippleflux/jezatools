<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ProductTracker.Web.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
    <head runat="server">
        <title>Product Tracker</title>
        <link href="Stylesheet.css" type="text/css" rel="Stylesheet"/>
    </head>
    <body>
        <form id="formDefault" runat="server">
            <div id="divDefault" class="divDefault">
                <div id="divDefaultHead" class="divDefaultHead">
                    <asp:Panel id="panelDefaultHead" CssClass="panelDefaultHead" runat="server">
                        <table id="tableDefaultHead" class="tableDefaultHead">
                            <tr>
                                <td>
                                    <asp:LinkButton id="linkButtonShops" runat="server" 
                                        onclick="LinkButtonShops_Click" CssClass="linkButtonHead">Shops</asp:LinkButton>
                                </td>
                                <td>
                                    <asp:LinkButton id="linkButtonItems" runat="server" 
                                        onclick="LinkButtonItems_Click" CssClass="linkButtonHead">Items</asp:LinkButton>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </div>
                <div id="divDefaultBody" class="divDefaultBody">
                    <asp:Panel id="panelDefaultBody" CssClass="panelDefaultBody" runat="server">
                        <div id="divDefaultBodyHead" class="divDefaultBodyHead">
                        </div>
                        <div id="divDefaultBodyGridView" class="divDefaultBodyGridView">
                            <asp:Panel id="panelDefaultBodyGridView" CssClass="panelDefaultBodyGridView" runat="server">
                                <table id="tableDefaultBodyGridView" class="tableDefaultBodyGridView">
                                    <tr>
                                        <td>
                                            <asp:GridView id="gridViewDefaultBodyItems" CssClass="gridViewDefaultBodyItems" 
                                                runat="server" AutoGenerateColumns="False" 
                                                AllowPaging="True" onpageindexchanging="GridViewItems_PageIndexChanging">
                                                <Columns>
                                                    <asp:BoundField DataField="Id" HeaderText="Id" />
                                                    <asp:BoundField DataField="Name" HeaderText="Name" />
                                                    <asp:BoundField DataField="ItemTypeName" HeaderText="Type" />
                                                    <asp:BoundField DataField="Notes" HeaderText="Notes" />
                                                </Columns>
                                            </asp:GridView>
                                            <asp:GridView id="gridViewDefaultBodyShops" CssClass="gridViewDefaultBodyShops" 
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
                <div id="divDefaultFoot" class="divDefaultFoot">
                    <asp:Panel id="panelDefaultFoot" CssClass="panelDefaultFoot" runat="server">
                        <table id="tableDefaultFoot" class="tableDefaultFoot">
                            <tr>
                                <td>
                                    <asp:HyperLink id="hyperLinkDefaultManageItems" runat="server" 
                                        NavigateUrl="~/ManageItems.aspx" CssClass="hyperLinkDefaultManageItems">Manage Items</asp:HyperLink>    
                                    <asp:HyperLink id="hyperLinkDefaultManageShops" runat="server" 
                                        NavigateUrl="~/ManageShops.aspx" CssClass="hyperLinkDefaultManageShops">Manage Shops</asp:HyperLink>    
                                    <asp:HyperLink id="hyperLinkDefaultManageShopItems" runat="server" 
                                        NavigateUrl="~/ManageShopItems.aspx" CssClass="hyperLinkDefaultManageShopItems">Manage Shop Items</asp:HyperLink>    
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </div>
            </div>
        </form>
    </body>
</html>
