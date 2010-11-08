<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageItems.aspx.cs" Inherits="ProductTracker.Web.ManageItems" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
    <head runat="server">
        <title>Items</title>
        <link href="Stylesheet.css" type="text/css" rel="Stylesheet"/>
    </head>
    <body>
        <form id="formManageItems" runat="server">
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
                <div id="divItemTypes">
                    <asp:Panel ID="PanelItemTypes" runat="server">
                        <div id="divItemTypesText">
                            
                        </div>
                        <table id="tableItemTypes">
                            <tr>
                                <td>
                                    <asp:Label ID="LabelItemTypes" runat="server" Text="Item Types" CssClass="labelManageItems"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBoxItemTypes" runat="server" CssClass="textBoxManageItems"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:LinkButton ID="LinkButtonItemTypesSubmit" runat="server" 
                                        onclick="LinkButtonItemTypesSubmit_Click" CssClass="linkButton">Submit New Item Type</asp:LinkButton>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </div>
                <div id="divItems">
                    <asp:Panel ID="PanelItems" runat="server">
                        <div id="divItemsText">
                            
                        </div>
                        <div id="divItemsHead">
                            <table id="tableItemsHead">
                                <tr>
                                    <td>
                                        <asp:Label ID="LabelItemsSelect" runat="server" Text="Items" CssClass="labelManageItems"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="DropDownListItemsSelect" runat="server" 
                                            DataTextField="Name" DataValueField="Id" 
                                            CssClass="dropDownManageItems">
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:LinkButton ID="LinkButtonItemsSelect" runat="server" 
                                            onclick="LinkButtonItemsSelect_Click" CssClass="linkButton">Select</asp:LinkButton>
                                    </td>
                                    <td>
                                        <asp:LinkButton ID="LinkButtonItemsAddNew" runat="server" 
                                            CssClass="linkButton" onclick="LinkButtonItemsAddNew_Click">Add</asp:LinkButton>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div id="divItemsBody">
                            <table id="tableItemsBody">
                                <tr>
                                    <td>
                                        <asp:Label ID="LabelItemId" runat="server" Text="Id" CssClass="labelManageItems"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="LabelItemName" runat="server" Text="Name" CssClass="labelManageItems"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="LabelItemNote" runat="server" Text="Notes" CssClass="labelManageItems"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="LabelItemItemType" runat="server" Text="Type" CssClass="labelManageItems"></asp:Label>
                                    </td>
                                    <td>
                                        
                                    </td>
                                    <td>
                                        
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:TextBox ID="TextBoxMiddleBodyId" runat="server" CssClass="textBoxManageItems"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TextBoxMiddleBodyName" runat="server" CssClass="textBoxManageItems"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TextBoxMiddleBodyNotes" runat="server" CssClass="textBoxManageItems"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="DropDownListMiddleBodyItemType" runat="server" 
                                            DataTextField="Name" DataValueField="Id" CssClass="dropDownManageItems">
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:LinkButton ID="LinkButtonMiddleBodySubmit" runat="server" 
                                            onclick="LinkButtonMiddleBodySubmit_Click" CssClass="linkButton">Submit</asp:LinkButton>
                                    </td>
                                    <td>
                                        <asp:LinkButton ID="LinkButtonMiddleBodyUpdate" runat="server" 
                                            CssClass="linkButton" onclick="LinkButtonMiddleBodyUpdate_Click">Update</asp:LinkButton>
                                    </td>
                                    <td>
                                        <asp:LinkButton ID="LinkButtonMiddleItemTypesDelete" runat="server" 
                                            onclick="LinkButtonMiddleItemTypesDelete_Click" CssClass="linkButton">Delete</asp:LinkButton>
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
