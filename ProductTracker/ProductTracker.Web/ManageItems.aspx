<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageItems.aspx.cs" Inherits="ProductTracker.Web.ManageItems" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
    <head runat="server">
        <title>Product Tracker</title>
        <link href="Stylesheet.css" type="text/css" rel="Stylesheet"/>
    </head>
    <body>
        <form id="formManageItems" runat="server">
            <div id="divManageItems" class="divManageItems">
                <div id="divManageItemsHead" class="divManageItemsHead">
                    <asp:Panel id="panelManageItemsHead" CssClass="panelManageItemsHead" runat="server">
                        <table id="tableManageItemsHead" class="tableManageItemsHead">
                            <tr>
                                <td>
                                    <asp:HyperLink id="hyperLinkManageItemsHeadMain" runat="server" 
                                        NavigateUrl="~/Default.aspx" CssClass="hyperLinkManageItemsHeadMain">Main</asp:HyperLink>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </div>
                <div id="divManageItemsBodyItemTypes" class="divManageItemsBodyItemTypes">
                    <asp:Panel id="panelManageItemsBodyItemTypes" CssClass="panelManageItemsBodyItemTypes" runat="server">
                        <div id="divManageItemsBodyItemTypesHead" class="divManageItemsBodyItemTypesHead">
                            
                        </div>
                        <table id="tableManageItemsBodyItemTypes" class="tableManageItemsBodyItemTypes">
                            <tr>
                                <td>
                                    <asp:Label id="labelManageItemsBodyItemTypes" runat="server" Text="Item Types" CssClass="labelManageItemsBodyItemTypes"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox id="textBoxManageItemsBodyItemTypes" runat="server" CssClass="textBoxManageItemsBodyItemTypes"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:LinkButton id="linkButtonManageItemsBodyItemTypesSubmit" runat="server" 
                                        onclick="LinkButtonItemTypesSubmit_Click" CssClass="linkButtonManageItemsBodyItemTypesSubmit">Submit New Item Type</asp:LinkButton>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </div>
                <div id="divManageItemsBodyItems" class="divManageItemsBodyItems">
                    <asp:Panel id="panelManageItemsBodyItems" CssClass="panelManageItemsBodyItems" runat="server">
                        <div id="divManageItemsBodyItemsHead" class="divManageItemsBodyItemsHead">
                            
                        </div>
                        <div id="divManageItemsBodyItemsSelect" class="divManageItemsBodyItemsSelect">
                            <table id="tableManageItemsBodyItemsSelect" class="tableManageItemsBodyItemsSelect">
                                <tr>
                                    <td>
                                        <asp:Label id="labelManageItemsBodyItemsSelect" runat="server" Text="Items" CssClass="labelManageItemsBodyItemsSelect"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList id="dropDownListManageItemsBodyItemsSelect" runat="server" 
                                            DataTextField="Name" DataValueField="Id" 
                                            CssClass="dropDownListManageItemsBodyItemsSelect">
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:LinkButton id="linkButtonManageItemsBodyItemsSelect" runat="server" 
                                            onclick="LinkButtonItemsSelect_Click" CssClass="linkButtonManageItemsBodyItemsSelect">Select</asp:LinkButton>
                                    </td>
                                    <td>
                                        <asp:LinkButton id="linkButtonManageItemsBodyItemsAddNew" runat="server" 
                                            CssClass="linkButtonManageItemsBodyItemsAddNew" onclick="LinkButtonItemsAddNew_Click">Add</asp:LinkButton>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div id="divManageItemsBodyItemsSubmit" class="divManageItemsBodyItemsSubmit">
                            <table id="tableManageItemsBodyItemsSubmit" class="tableManageItemsBodyItemsSubmit">
                                <tr>
                                    <td>
                                        <asp:Label id="labelManageItemsBodyItemsSubmitItemId" runat="server" Text="Id" CssClass="labelManageItemsBodyItemsSubmitItemId"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label id="labelManageItemsBodyItemsSubmitItemName" runat="server" Text="Name" CssClass="labelManageItemsBodyItemsSubmitItemName"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label id="labelManageItemsBodyItemsSubmitItemNote" runat="server" Text="Notes" CssClass="labelManageItemsBodyItemsSubmitItemNote"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label id="labelManageItemsBodyItemsSubmitItemType" runat="server" Text="Type" CssClass="labelManageItemsBodyItemsSubmitItemType"></asp:Label>
                                    </td>
                                    <td>
                                        
                                    </td>
                                    <td>
                                        
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:TextBox id="textBoxManageItemsBodyItemsSubmitItemId" runat="server" CssClass="textBoxManageItemsBodyItemsSubmitItemId"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox id="textBoxManageItemsBodyItemsSubmitItemName" runat="server" CssClass="textBoxManageItemsBodyItemsSubmitItemName"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox id="textBoxManageItemsBodyItemsSubmitNote" runat="server" CssClass="textBoxManageItemsBodyItemsSubmitNote"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:DropDownList id="dropDownListManageItemsBodyItemsSubmitItemType" runat="server" 
                                            DataTextField="Name" DataValueField="Id" CssClass="dropDownListManageItemsBodyItemsSubmitItemType">
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:LinkButton id="linkButtonManageItemsBodyItemsSubmit" runat="server" 
                                            onclick="LinkButtonMiddleBodySubmit_Click" CssClass="linkButtonManageItemsBodyItemsSubmit">Submit</asp:LinkButton>
                                    </td>
                                    <td>
                                        <asp:LinkButton id="linkButtonManageItemsBodyItemsUpdate" runat="server" 
                                            CssClass="linkButtonManageItemsBodyItemsUpdate" onclick="LinkButtonMiddleBodyUpdate_Click">Update</asp:LinkButton>
                                    </td>
                                    <td>
                                        <asp:LinkButton id="linkButtonManageItemsBodyItemsDelete" runat="server" 
                                            onclick="LinkButtonMiddleItemTypesDelete_Click" CssClass="linkButtonManageItemsBodyItemsDelete">Delete</asp:LinkButton>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </asp:Panel>
                </div>
            </div>
        </form>
    </body>
</html>
