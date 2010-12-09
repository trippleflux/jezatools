<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageShops.aspx.cs" Inherits="ProductTracker.Web.ManageShops" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
    <head runat="server">
        <title>Product Tracker</title>
        <link href="Stylesheet.css" type="text/css" rel="Stylesheet" />
    </head>
    <body>
        <form id="formManageShops" runat="server">
            <div id="divManageShops">
                <div id="divManageShopsHead">
                    <asp:HyperLink id="hyperLinkMangeShopsHeadMain" runat="server" NavigateUrl="~/Default.aspx">Main</asp:HyperLink>
                </div>
                <div id="divManageShopsList">
                    <div>
                        <asp:Label id="labelManageShopsListBody" runat="server" Text="Shops"></asp:Label>
                        <asp:DropDownList id="dropDownListManageShopsListBody" runat="server" DataTextField="Name">
                        </asp:DropDownList>
                    </div>
                    <div>
                        <asp:LinkButton id="linkButtonManageShopsListBodySelect" runat="server" onclick="LinkButtonShopList_Click">Select</asp:LinkButton>
                        <asp:LinkButton id="linkButtonManageShopsListBodyAdd" runat="server" onclick="LinkButtonAdd_Click">Add</asp:LinkButton>
                    </div>
                </div>
                <div id="divManageShopsInput">
                    <div>
                        <asp:Label id="labelManageShopsInputBodyName" runat="server" Text="Name"></asp:Label>
                        <asp:TextBox id="textBoxManageShopsInputBodyName" runat="server"></asp:TextBox>
                    </div>
                    <div>
                        <asp:Label id="labelManageShopsInputBodyAddress" runat="server" Text="Address"></asp:Label>
                        <asp:TextBox id="textBoxManageShopsInputBodyAddress" runat="server"></asp:TextBox>
                    </div>
                    <div>
                        <asp:Label id="labelManageShopsInputBodyOwner" runat="server" Text="Owner"></asp:Label>
                        <asp:TextBox id="textBoxManageShopsInputBodyOwner" runat="server"></asp:TextBox>
                    </div>
                    <div>
                        <asp:Label id="labelManageShopsInputBodyPostalCode" runat="server" Text="PostalCode"></asp:Label>
                        <asp:TextBox id="textBoxManageShopsInputBodyPostalCode" runat="server"></asp:TextBox>
                    </div>
                    <div>
                        <asp:Label id="labelManageShopsInputBodyCity" runat="server" Text="City"></asp:Label>
                        <asp:TextBox id="textBoxManageShopsInputBodyCity" runat="server"></asp:TextBox>
                    </div>
                    <div>
                        <asp:Label id="labelManageShopsInputBodyIsCompany" runat="server" Text="IsCompany"></asp:Label>
                        <asp:CheckBox id="checkBoxManageShopsInputBodyIsCompany" runat="server" />
                    </div>
                    <div>
                        <asp:LinkButton id="linkButtonManageShopsInputBodySubmit" runat="server" onclick="LinkButtonBodyShopsSubmit_Click">Submit</asp:LinkButton>
                        <asp:LinkButton id="linkButtonManageShopsInputBodyUpdate" runat="server" onclick="LinkButtonBodyShopsUpdate_Click">Update</asp:LinkButton>
                        <asp:LinkButton id="linkButtonManageShopsInputBodyDelete" runat="server" onclick="LinkButtonBodyShopsDelete_Click">Delete</asp:LinkButton>
                    </div>
                </div>
                <div id="divManageShopsFoot">
                    <asp:Label id="labelManageShopsStatus" runat="server" Text=""></asp:Label>
                </div>
            </div>
        </form>
    </body>
</html>
