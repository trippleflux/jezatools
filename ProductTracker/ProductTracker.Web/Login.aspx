<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ProductTracker.Web.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
    <head runat="server">
        <title>Login</title>
    </head>
    <body>
        <form id="FormLogin" runat="server">
            <div>
                <div>
                    <asp:Login 
                        ID="LoginControl" 
                        runat="server" 
                        BackColor="#EFF3FB" 
                        BorderColor="#B5C7DE" 
                        BorderPadding="4" 
                        BorderStyle="Solid" 
                        BorderWidth="1px" 
                        Font-Names="Verdana" 
                        Font-Size="0.8em" 
                        ForeColor="#333333" 
                        Height="86px" 
                        Width="292px" 
                        onauthenticate="Login_Authenticate" 
                        VisibleWhenLoggedIn="False" DestinationPageUrl="Default.aspx">
                        <TextBoxStyle 
                            Font-Size="0.8em" />
                        <LoginButtonStyle 
                            BackColor="White" 
                            BorderColor="#507CD1" 
                            BorderStyle="Solid" 
                            BorderWidth="1px" 
                            Font-Names="Verdana" 
                            Font-Size="0.8em" 
                            ForeColor="#284E98" />
                        <InstructionTextStyle 
                            Font-Italic="True" 
                            ForeColor="Black" />
                        <TitleTextStyle 
                            BackColor="#507CD1" 
                            Font-Bold="True" 
                            Font-Size="0.9em" 
                            ForeColor="White" />
                    </asp:Login>
                </div>
            </div>
        </form>
    </body>
</html>
