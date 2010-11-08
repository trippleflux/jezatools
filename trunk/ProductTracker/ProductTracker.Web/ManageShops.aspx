<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageShops.aspx.cs" Inherits="ProductTracker.Web.ManageShops" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
    <head runat="server">
        <title>Shops</title>
        <link href="Stylesheet.css" type="text/css" rel="Stylesheet" />
    </head>
    <body>
        <form id="formManageShops" runat="server">
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
                <div id="divShopList">
                    <asp:Panel ID="PanelShopList" runat="server">
                        <div id="divShopListText">
                            
                        </div>
                        <div id="divShopListBodz">
                            <table id="tableShopList">
                                <tr>
                                    <td>
                                        <asp:Label ID="LabelShopList" runat="server" Text="Shops"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="DropDownListShopList" runat="server" DataTextField="Name">
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:LinkButton ID="LinkButtonShopList" runat="server" 
                                            onclick="LinkButtonShopList_Click">Select</asp:LinkButton>
                                    </td>
                                    <td>
                                        <asp:LinkButton ID="LinkButtonAdd" runat="server" onclick="LinkButtonAdd_Click">Add</asp:LinkButton>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </asp:Panel>
                </div>
                <div id="divBody">
                    <asp:Panel ID="PanelBody" runat="server">
                        <div id="divBodyText">
                            
                        </div>
                        <div id="divBodyShops">
                            <table id="tableBody">
                                <tr>
                                    <td>
                                        <asp:Label ID="LabelBodyShopsName" runat="server" Text="Name"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="LabelBodyShopsAddress" runat="server" Text="Address"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="LabelBodyShopsOwner" runat="server" Text="Owner"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="LabelBodyShopsPostalCode" runat="server" Text="PostalCode"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="LabelBodyShopsCity" runat="server" Text="City"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="LabelBodyShopsIsCompany" runat="server" Text="IsCompany"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:TextBox ID="TextBoxBodyShopsName" runat="server"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TextBoxBodyShopsAddress" runat="server"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TextBoxBodyShopsOwner" runat="server"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TextBoxBodyShopsPostalCode" runat="server"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TextBoxBodyShopsCity" runat="server"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="CheckBoxBodyShopsIsCompany" runat="server" />
                                    </td>
                                    <td>
                                        <asp:LinkButton ID="LinkButtonBodyShopsSubmit" runat="server" 
                                            onclick="LinkButtonBodyShopsSubmit_Click">Submit</asp:LinkButton>
                                    </td>
                                    <td>
                                        <asp:LinkButton ID="LinkButtonBodyShopsUpdate" runat="server" onclick="LinkButtonBodyShopsUpdate_Click" 
                                            >Update</asp:LinkButton>
                                    </td>
                                    <td>
                                        <asp:LinkButton ID="LinkButtonBodyShopsDelete" runat="server" 
                                            onclick="LinkButtonBodyShopsDelete_Click">Delete</asp:LinkButton>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </asp:Panel>
                </div>
                <div id="divStatus">
                    <asp:Label ID="LabelStatus" runat="server" Text=""></asp:Label>
                </div>
            </div>
        </form>
    </body>
</html>
