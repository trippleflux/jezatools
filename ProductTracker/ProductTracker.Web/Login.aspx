<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ProductTracker.Web.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
    <head runat="server">
        <title>Product Tracker</title>
        <link href="Stylesheet.css" type="text/css" rel="Stylesheet"/>
    </head>
    <body>
        <form id="formLogin" runat="server">
            <div id="divLogin" class="divLogin">
                <div id="divLoginHead" class="divLoginHead">
                    <asp:Login 
                        id="loginControlLoginHead" 
                        CssClass="loginControlLoginHead" 
                        runat="server" 
                        Height="86px" 
                        Width="292px" 
                        onauthenticate="Login_Authenticate" 
                        VisibleWhenLoggedIn="False" DestinationPageUrl="Default.aspx">
                    </asp:Login>
                </div>
            </div>
        </form>
    </body>
</html>
