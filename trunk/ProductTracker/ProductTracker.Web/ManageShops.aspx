<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageShops.aspx.cs" Inherits="ProductTracker.Web.ManageShops" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
    <head runat="server">
        <title>Product Tracker</title>
        <link href="Stylesheet.css" type="text/css" rel="Stylesheet" />
    </head>
    <body>
        <form id="formManageShops" runat="server">
            <div id="divManageShops" class="divManageShops">
                <div id="divManageShopsHead" class="divManageShopsHead">
                    <asp:Panel id="panelManageShopsHead" CssClass="panelManageShopsHead" runat="server">
                        <table id="tableManageShopsHead" class="tableManageShopsHead">
                            <tr>
                                <td>
                                    <asp:HyperLink id="hyperLinkMangeShopsHeadMain" runat="server" 
                                        NavigateUrl="~/Default.aspx" CssClass="hyperLinkMangeShopsHeadMain">Main</asp:HyperLink>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </div>
                <div id="divManageShopsList" class="divManageShopsList">
                    <asp:Panel id="panelManageShopsList" CssClass="panelManageShopsList" runat="server">
                        <div id="divManageShopsListHead" class="divManageShopsListHead">
                            
                        </div>
                        <div id="divManageShopsListBody" class="divManageShopsListBody">
                            <table id="tableManageShopsListBody" class="tableManageShopsListBody">
                                <tr>
                                    <td>
                                        <asp:Label id="labelManageShopsListBody" CssClass="labelManageShopsListBody" runat="server" Text="Shops"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList id="dropDownListManageShopsListBody" CssClass="dropDownListManageShopsListBody" runat="server" DataTextField="Name">
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:LinkButton id="linkButtonManageShopsListBodySelect" CssClass="linkButtonManageShopsListBodySelect" runat="server" 
                                            onclick="LinkButtonShopList_Click">Select</asp:LinkButton>
                                    </td>
                                    <td>
                                        <asp:LinkButton id="linkButtonManageShopsListBodyAdd" CssClass="linkButtonManageShopsListBodyAdd" runat="server" onclick="LinkButtonAdd_Click">Add</asp:LinkButton>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </asp:Panel>
                </div>
                <div id="divManageShopsInput" class="divManageShopsInput">
                    <asp:Panel id="panelManageShopsInput" CssClass="panelManageShopsInput" runat="server">
                        <div id="divManageShopsInputHead" class="divManageShopsInputHead">
                            
                        </div>
                        <div id="divManageShopsInputBody" class="divManageShopsInputBody">
                            <table id="tableManageShopsInputBody" class="tableManageShopsInputBody">
                                <tr>
                                    <td>
                                        <asp:Label id="labelManageShopsInputBodyName" CssClass="labelManageShopsInputBodyName" runat="server" Text="Name"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label id="labelManageShopsInputBodyAddress" CssClass="labelManageShopsInputBodyAddress" runat="server" Text="Address"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label id="labelManageShopsInputBodyOwner" CssClass="labelManageShopsInputBodyOwner" runat="server" Text="Owner"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label id="labelManageShopsInputBodyPostalCode" CssClass="labelManageShopsInputBodyPostalCode" runat="server" Text="PostalCode"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label id="labelManageShopsInputBodyCity" CssClass="labelManageShopsInputBodyCity" runat="server" Text="City"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label id="labelManageShopsInputBodyIsCompany" CssClass="labelManageShopsInputBodyIsCompany" runat="server" Text="IsCompany"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:TextBox id="textBoxManageShopsInputBodyName" CssClass="textBoxManageShopsInputBodyName" runat="server"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox id="textBoxManageShopsInputBodyAddress" CssClass="textBoxManageShopsInputBodyAddress" runat="server"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox id="textBoxManageShopsInputBodyOwner" CssClass="textBoxManageShopsInputBodyOwner" runat="server"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox id="textBoxManageShopsInputBodyPostalCode" CssClass="textBoxManageShopsInputBodyPostalCode" runat="server"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox id="textBoxManageShopsInputBodyCity" CssClass="textBoxManageShopsInputBodyCity" runat="server"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:CheckBox id="checkBoxManageShopsInputBodyIsCompany" CssClass="checkBoxManageShopsInputBodyIsCompany" runat="server" />
                                    </td>
                                    <td>
                                        <asp:LinkButton id="linkButtonManageShopsInputBodySubmit" CssClass="linkButtonManageShopsInputBodySubmit" runat="server" 
                                            onclick="LinkButtonBodyShopsSubmit_Click">Submit</asp:LinkButton>
                                    </td>
                                    <td>
                                        <asp:LinkButton id="linkButtonManageShopsInputBodyUpdate" CssClass="linkButtonManageShopsInputBodyUpdate" runat="server" onclick="LinkButtonBodyShopsUpdate_Click" 
                                            >Update</asp:LinkButton>
                                    </td>
                                    <td>
                                        <asp:LinkButton id="linkButtonManageShopsInputBodyDelete" CssClass="linkButtonManageShopsInputBodyDelete" runat="server" 
                                            onclick="LinkButtonBodyShopsDelete_Click">Delete</asp:LinkButton>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </asp:Panel>
                </div>
                <div id="divManageShopsFoot" class="divManageShopsFoot">
                    <asp:Label id="labelManageShopsStatus" CssClass="labelManageShopsStatus" runat="server" Text=""></asp:Label>
                </div>
            </div>
        </form>
    </body>
</html>
