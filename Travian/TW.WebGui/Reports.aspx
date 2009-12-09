<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Reports.aspx.cs" Inherits="Reports" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title>Reports</title>
        <link type="text/css" rel="Stylesheet" href="WebGuiStyle.css" />
    </head>
    <body>
        <form id="FormReports" runat="server">
            <div>
                <div>
                    <asp:LinkButton ID="LinkButtonPopulate" runat="server" 
                        onclick="LinkButtonPopulate_Click">populate</asp:LinkButton>
                </div>
                <div>
                    <asp:Label ID="LabelStatus" runat="server" Text=""></asp:Label>
                </div>
                <div>
                    <asp:GridView ID="GridViewReports" runat="server" AllowPaging="True" 
                        AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" 
                        GridLines="None" onpageindexchanging="GridViewReports_PageIndexChanging" 
                        PageSize="20">
                        <RowStyle BackColor="#E3EAEB" />
                        <Columns>
                            <asp:BoundField DataField="ReportDate" DataFormatString="{0}" 
                                HeaderText="Date" />
                            <asp:HyperLinkField DataNavigateUrlFields="ReportLink" 
                                DataNavigateUrlFormatString="{0}" DataTextField="ReportText" 
                                DataTextFormatString="{0}" HeaderText="Report" />
                        </Columns>
                        <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                        <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                        <EditRowStyle BackColor="#7C6F57" />
                        <AlternatingRowStyle BackColor="White" />
                    </asp:GridView>
                </div>
            </div>
        </form>
    </body>
</html>
