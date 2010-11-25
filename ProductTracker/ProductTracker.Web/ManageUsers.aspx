<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageUsers.aspx.cs" Inherits="ProductTracker.Web.ManageUsers" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
    <head runat="server">
        <title>Product Tracker</title>
        <link href="Stylesheet.css" type="text/css" rel="Stylesheet" />
    </head>
    <body>
        <form id="formManageUsers" runat="server">
            <div id="divManageUsers" class="divManageUsers">
                <div id="divManageUsersHead" class="divManageUsersHead">
                    <asp:Panel id="panelManageUsersHead" CssClass="panelManageUsersHead" runat="server">
                        <table id="tableManageUsersHead" class="tableManageUsersHead">
                            <tr>
                                <td>
                                    <asp:HyperLink id="hyperManageUsersHeadMain" CssClass="hyperManageUsersHeadMain" runat="server" 
                                        NavigateUrl="~/Default.aspx">Main</asp:HyperLink>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </div>
                <div id="divManageUsersBodyInput" class="divManageUsersBodyInput">
                    <table id="tableManageUsersBodyInput" class="tableManageUsersBodyInput">
                        <tr>
                            <td>
                                <asp:Label id="labelManageUsersBodyInputUserName" CssClass="labelManageUsersBodyInputUserName" runat="server" Text="Username"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox id="textBoxManageUsersBodyInputUserName" CssClass="textBoxManageUsersBodyInputUserName" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label id="labelManageUsersBodyInputPassword" CssClass="labelManageUsersBodyInputPassword" runat="server" Text="Password"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox id="textBoxManageUsersBodyInputPassword" CssClass="textBoxManageUsersBodyInputPassword" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label id="labelManageUsersBodyInputLevel" CssClass="labelManageUsersBodyInputLevel" runat="server" Text="Level"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList id="dropDownListManageUsersBodyInputLevel" CssClass="dropDownListManageUsersBodyInputLevel" runat="server">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:LinkButton id="linkButtonManageUsersBodyInputAddUser" CssClass="linkButtonManageUsersBodyInputAddUser" runat="server" 
                                    onclick="LinkButtonAddUser_Click">Add</asp:LinkButton>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label id="labelManageUsersBodyInputStatus" CssClass="labelManageUsersBodyInputStatus" runat="server" Text=""></asp:Label>
                            </td>
                            <td>
                            </td>
                        </tr>
                    </table>
                </div>
                <div id="divManageUsersBodyList" class="divManageUsersBodyList">
                    <asp:GridView id="gridViewManageUsersBodyList" 
                        CssClass="gridViewManageUsersBodyList" runat="server">
                        
                    </asp:GridView>
                </div>
            </div>
        </form>
    </body>
</html>
