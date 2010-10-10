<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageItems.aspx.cs" Inherits="ProductTracker.Web.ManageItems" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
    <head runat="server">
        <title>Items</title>
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
                                        NavigateUrl="~/Default.aspx">Main</asp:HyperLink>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </div>
                <div id="divItemTypes">
                    <table id="tableItemTypes">
                        <tr>
                            <td>
                                <asp:Label ID="LabelItemTypes" runat="server" Text="Item Types"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBoxItemTypes" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                <asp:LinkButton ID="LinkButtonItemTypesSubmit" runat="server" 
                                    onclick="LinkButtonItemTypesSubmit_Click">Submit New Item Type</asp:LinkButton>
                            </td>
                        </tr>
                    </table>
                </div>
                <div id="divMiddle">
                    <div id="divMiddleHead">
                        <asp:Label ID="LabelItemsSelect" runat="server" Text="Items"></asp:Label>
                        <asp:DropDownList ID="DropDownListItemsSelect" runat="server" 
                            DataTextField="Name" DataValueField="UniqueId">
                        </asp:DropDownList>
                        <asp:LinkButton ID="LinkButtonItemsSelect" runat="server" 
                            onclick="LinkButtonItemsSelect_Click">Select</asp:LinkButton>
                    </div>
                    <div id="divMiddleBody">
                        <table id="tableMiddleBody">
                            <tr>
                                <td>
                                    <asp:Label ID="LabelItemId" runat="server" Text="Id"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="LabelItemName" runat="server" Text="Name"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="LabelItemNote" runat="server" Text="Notes"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="LabelItemItemType" runat="server" Text="Type"></asp:Label>
                                </td>
                                <td>
                                    
                                </td>
                                <td>
                                    
                                </td>
                                <td>
                                    
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:TextBox ID="TextBoxMiddleBodyId" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBoxMiddleBodyName" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBoxMiddleBodyNotes" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:DropDownList ID="DropDownListMiddleBodyItemType" runat="server" 
                                        DataTextField="Name" DataValueField="Id">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBoxMiddleBodyUniqueId" runat="server" ReadOnly="True" 
                                        Visible="False"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:LinkButton ID="LinkButtonMiddleBodySubmit" runat="server" 
                                        onclick="LinkButtonMiddleBodySubmit_Click">Submit</asp:LinkButton>
                                </td>
                                <td>
                                    <asp:LinkButton ID="LinkButtonMiddleItemTypesDelete" runat="server" 
                                        onclick="LinkButtonMiddleItemTypesDelete_Click">Delete</asp:LinkButton>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>
        </form>
    </body>
</html>
