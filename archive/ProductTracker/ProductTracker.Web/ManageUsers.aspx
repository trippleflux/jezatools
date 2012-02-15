<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageUsers.aspx.cs" Inherits="ProductTracker.Web.ManageUsers" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
    <head runat="server">
        <title>Product Tracker</title>
        <link href="Stylesheet.css" type="text/css" rel="Stylesheet" />
    </head>
    <body>
        <form id="formManageUsers" runat="server">
            <div id="divManageUsers">
                <div id="divManageUsersHead">
                    <asp:HyperLink id="hyperManageUsersHeadMain" runat="server" NavigateUrl="~/Default.aspx">Main</asp:HyperLink>
                </div>
                <div id="divManageUsersBody">
                    <div id="divManageUsersBodyInput">
                        <div>
                            <asp:Label id="labelManageUsersBodyInputUserName" runat="server" Text="Username"></asp:Label>
                            <asp:TextBox id="textBoxManageUsersBodyInputUserName" runat="server"></asp:TextBox>
                        </div>
                        <div>
                            <asp:Label id="labelManageUsersBodyInputPassword" runat="server" Text="Password"></asp:Label>
                            <asp:TextBox id="textBoxManageUsersBodyInputPassword" runat="server"></asp:TextBox>
                        </div>
                        <div>
                            <asp:Label id="labelManageUsersBodyInputLevel" runat="server" Text="Level"></asp:Label>
                            <asp:DropDownList id="dropDownListManageUsersBodyInputLevel" runat="server">
                            </asp:DropDownList>
                        </div>
                        <div>
                            <asp:LinkButton id="linkButtonManageUsersBodyInputAddUser" runat="server" 
                                onclick="LinkButtonAddUser_Click">Add</asp:LinkButton>
                        </div>
                    </div>
                </div>
                <div id="divManageUsersBodyInputStatus">
                    <asp:Label id="labelManageUsersBodyInputStatus" runat="server" Text=""></asp:Label>
                </div>
                <div id="divManageUsersBodyList">
                    <asp:GridView id="gridViewManageUsersBodyList" runat="server">                        
                    </asp:GridView>
                </div>
            </div>
        </form>
    </body>
</html>
