<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageUsers.aspx.cs" Inherits="ProductTracker.Web.ManageUsers" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
    <head runat="server">
        <title>Users</title>
        <link href="Stylesheet.css" type="text/css" rel="Stylesheet" />
    </head>
    <body>
        <form id="formManageUsers" runat="server">
            <div>
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
                <div id="divManage">
                    <table id="tableUsersHead">
                        <tr>
                            <td>
                                <asp:Label ID="LabelUserName" runat="server" Text="Username"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBoxUserName" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="LabelPassword" runat="server" Text="Password"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBoxPassword" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="LabelLevel" runat="server" Text="Level"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="DropDownListLevel" runat="server">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:LinkButton ID="LinkButtonAddUser" runat="server" 
                                    onclick="LinkButtonAddUser_Click">Add</asp:LinkButton>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="LabelStatus" runat="server" Text=""></asp:Label>
                            </td>
                            <td>
                            </td>
                        </tr>
                    </table>
                </div>
                <div id="List">
                    <asp:GridView ID="GridViewUsers" runat="server">
                        
                    </asp:GridView>
                </div>
            </div>
        </form>
    </body>
</html>
