<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageItems.aspx.cs" Inherits="ProductTracker.Web.ManageItems" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
    <head runat="server">
        <title>Product Tracker</title>
        <link href="Stylesheet.css" type="text/css" rel="Stylesheet"/>
    </head>
    <body>
        <form id="formManageItems" runat="server">
            <div id="divManageItems">
                <div id="divManageItemsHead">
                    <asp:HyperLink id="hyperLinkManageItemsHeadMain" runat="server" NavigateUrl="~/Default.aspx">Main</asp:HyperLink>
                </div>
                <div id="divManageItemsBodyItemTypes">
                    <div id="divManageItemsBodyItemTypesBody">
                        <asp:Label id="labelManageItemsBodyItemTypes" runat="server" Text="Item Types"></asp:Label>
                        <asp:TextBox id="textBoxManageItemsBodyItemTypes" runat="server"></asp:TextBox>
                    </div>
                    <div>
                        <asp:LinkButton id="linkButtonManageItemsBodyItemTypesSubmit" runat="server" 
                            onclick="LinkButtonItemTypesSubmit_Click">Submit New Item Type</asp:LinkButton>
                    </div>
                </div>
                <div id="divManageItemsBodyItemsSelect">
                    <div>
                        <asp:Label id="labelManageItemsBodyItemsSelect" runat="server" Text="Items"></asp:Label>
                        <asp:DropDownList id="dropDownListManageItemsBodyItemsSelect" runat="server" DataTextField="Name" DataValueField="Id">
                        </asp:DropDownList>
                    </div>
                    <div>
                        <asp:LinkButton id="linkButtonManageItemsBodyItemsSelect" runat="server" onclick="LinkButtonItemsSelect_Click">Select</asp:LinkButton>
                        <asp:LinkButton id="linkButtonManageItemsBodyItemsAddNew" runat="server" onclick="LinkButtonItemsAddNew_Click">Add</asp:LinkButton>
                    </div>
                </div>
                <div id="divManageItemsBodyItemsSubmit">
                    <div>
                        <asp:Label id="labelManageItemsBodyItemsSubmitItemId" runat="server" Text="Id"></asp:Label>
                        <asp:TextBox id="textBoxManageItemsBodyItemsSubmitItemId" runat="server"></asp:TextBox>
                    </div>
                    <div>
                        <asp:Label id="labelManageItemsBodyItemsSubmitItemName" runat="server" Text="Name"></asp:Label>
                        <asp:TextBox id="textBoxManageItemsBodyItemsSubmitItemName" runat="server"></asp:TextBox>
                    </div>
                    <div>
                        <asp:Label id="labelManageItemsBodyItemsSubmitItemNote" runat="server" Text="Notes"></asp:Label>
                        <asp:TextBox id="textBoxManageItemsBodyItemsSubmitNote" runat="server"></asp:TextBox>
                    </div>
                    <div>
                        <asp:Label id="labelManageItemsBodyItemsSubmitItemType" runat="server" Text="Type"></asp:Label>
                        <asp:DropDownList id="dropDownListManageItemsBodyItemsSubmitItemType" runat="server" 
                            DataTextField="Name" DataValueField="Id">
                        </asp:DropDownList>
                    </div>
                    <div>
                        <asp:LinkButton id="linkButtonManageItemsBodyItemsSubmit" runat="server" onclick="LinkButtonMiddleBodySubmit_Click">Submit</asp:LinkButton>
                        <asp:LinkButton id="linkButtonManageItemsBodyItemsUpdate" runat="server" onclick="LinkButtonMiddleBodyUpdate_Click">Update</asp:LinkButton>
                        <asp:LinkButton id="linkButtonManageItemsBodyItemsDelete" runat="server" onclick="LinkButtonMiddleItemTypesDelete_Click">Delete</asp:LinkButton>
                    </div>
                </div>
            </div>
        </form>
    </body>
</html>
