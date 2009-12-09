<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="Default" %>
<%@ Register TagPrefix="zgw" Namespace="ZedGraph.Web" Assembly="ZedGraph.Web" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title>Main</title>
        <link type="text/css" rel="Stylesheet" href="WebGuiStyle.css" />
    </head>
    <body>
        <form id="FormMain" runat="server">
            <div>
                <div>
                    <table id="tableHeader">
                        <tr>
                            <td>
                                <asp:Label ID="LabelCoordinateX" runat="server" Text="CoordinateX" CssClass="labelStyle"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBoxCoordinateX" runat="server" CssClass="textBoxStyle"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Label ID="LabelExcludedPlayers" runat="server" Text="Excluded Players" CssClass="labelStyle"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="DropDownListExcludedPlayers" runat="server" 
                                    AutoPostBack="True" DataTextField="PlayerName" DataValueField="PlayerId">
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:LinkButton ID="LinkButtonRemoveExcludedPlayer" runat="server" 
                                    onclick="LinkButtonRemoveExcludedPlayer_Click">remove</asp:LinkButton>
                            </td>
                            <td>
                            </td>
                            <td>
                                <asp:Label ID="LabelAddExcludedPlayerId" runat="server" Text="Player Id" CssClass="labelStyle"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBoxAddExcludedPlayerId" runat="server" CssClass="textBoxStyle"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Label ID="LabelAddExcludedPlayerName" runat="server" Text="Player Name" CssClass="labelStyle"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBoxAddExcludedPlayerName" runat="server" CssClass="textBoxStyle"></asp:TextBox>
                            </td>
                            <td>
                                <asp:LinkButton ID="LinkButtonAddExcludedPlayer" runat="server" onclick="LinkButtonAddExcludedPlayer_Click">add</asp:LinkButton>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="LabelCoordinateY" runat="server" Text="CoordinateY" CssClass="labelStyle"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBoxCoordinateY" runat="server" CssClass="textBoxStyle"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Label ID="LabelAlly" runat="server" Text="Ally" CssClass="labelStyle"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="DropDownListAlly" runat="server" 
                                    AutoPostBack="True" DataTextField="AllianceName" DataValueField="AllianceId">
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:LinkButton ID="LinkButtonRemoveAlly" runat="server" 
                                    onclick="LinkButtonRemoveAlly_Click">remove</asp:LinkButton>
                            </td>
                            <td>
                            </td>
                            <td>
                                <asp:Label ID="LabelAddAllyId" runat="server" Text="Alliance Id" CssClass="labelStyle"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBoxAddAllyId" runat="server" CssClass="textBoxStyle"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Label ID="LabelAddAllyName" runat="server" Text="Alliance Name" CssClass="labelStyle"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBoxAddAllyName" runat="server" CssClass="textBoxStyle"></asp:TextBox>
                            </td>
                            <td>
                                <asp:LinkButton ID="LinkButtonAddAlly" runat="server" 
                                    onclick="LinkButtonAddAlly_Click">add</asp:LinkButton>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="LabelDistanceX" runat="server" Text="DistanceX" CssClass="labelStyle"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBoxDistanceX" runat="server" CssClass="textBoxStyle"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Label ID="LabelNap" runat="server" Text="Nap" CssClass="labelStyle"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="DropDownListNap" runat="server" 
                                    AutoPostBack="True" DataTextField="AllianceName" DataValueField="AllianceId">
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:LinkButton ID="LinkButtonRemoveNap" runat="server" 
                                    onclick="LinkButtonRemoveNap_Click">remove</asp:LinkButton>
                            </td>
                            <td>
                            </td>
                            <td>
                                <asp:Label ID="LabelAddNapId" runat="server" Text="Alliance Id" CssClass="labelStyle"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBoxAddNapId" runat="server" CssClass="textBoxStyle"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Label ID="LabelAddNapName" runat="server" Text="Alliance Name" CssClass="labelStyle"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBoxAddNapName" runat="server" CssClass="textBoxStyle"></asp:TextBox>
                            </td>
                            <td>
                                <asp:LinkButton ID="LinkButtonAddNap" runat="server" 
                                    onclick="LinkButtonAddNap_Click">add</asp:LinkButton>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="LabelDistanceY" runat="server" Text="DistanceY" CssClass="labelStyle"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBoxDistanceY" runat="server" CssClass="textBoxStyle"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Label ID="LabelAllyFriends" runat="server" Text="Ally Friends" CssClass="labelStyle"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="DropDownListAllyFriends" runat="server" 
                                    AutoPostBack="True" DataTextField="AllianceName" DataValueField="AllianceId">
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:LinkButton ID="LinkButtonRemoveAllyFriends" runat="server" 
                                    onclick="LinkButtonRemoveAllyFriends_Click">remove</asp:LinkButton>
                            </td>
                            <td>
                            </td>
                            <td>
                                <asp:Label ID="LabelAddFriendsId" runat="server" Text="Alliance Id" CssClass="labelStyle"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBoxAddFriendsId" runat="server" CssClass="textBoxStyle"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Label ID="LabelAddFriendsName" runat="server" Text="Alliance Name" CssClass="labelStyle"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBoxAddFriendsName" runat="server" CssClass="textBoxStyle"></asp:TextBox>
                            </td>
                            <td>
                                <asp:LinkButton ID="LinkButtonAddFriends" runat="server" 
                                    onclick="LinkButtonAddFriends_Click">add</asp:LinkButton>
                            </td>
                        </tr>
                    </table>
                </div>
                <div>
                    <table id="tableNextFarm">
                        <tr>
                            <td>
                                <asp:Label ID="LabelNextFarm" runat="server" Text="NextFarm" CssClass="labelStyle"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBoxNextFarm" runat="server" CssClass="textBoxNextFarm"></asp:TextBox>
                            </td>
                            <td>
                                <asp:LinkButton ID="LinkButtonSave" runat="server" onclick="LinkButtonSave_Click">save</asp:LinkButton>
                            </td>
                        </tr>
                    </table>
                </div>
                <div>
                    <asp:LinkButton ID="LinkButtonPopulate" runat="server" 
                        onclick="LinkButtonPopulate_Click">populate</asp:LinkButton>
                </div>
                <div>
                    <asp:Label ID="LabelStatus" runat="server" Text=""></asp:Label>
                </div>
                <div>
                    <asp:GridView ID="GridViewVillages" runat="server" 
		                AllowPaging="True" 
		                onpageindexchanging="GridViewVillages_PageIndexChanging" CellPadding="4" ForeColor="#333333" 
		                GridLines="None" AutoGenerateColumns="False" PageSize="15" 
		                onrowcancelingedit="GridViewVillages_RowCancelingEdit" 
		                onrowediting="GridViewVillages_RowEditing" 
		                onrowupdating="GridViewVillages_RowUpdating" 
                        onselectedindexchanged="GridViewVillages_SelectedIndexChanged" 
                        onselectedindexchanging="GridViewVillages_SelectedIndexChanging">
		                <RowStyle BackColor="#E3EAEB" />
		                <Columns>
			                <asp:BoundField DataField="VillageId" HeaderText="Coordinates" >
				                <HeaderStyle HorizontalAlign="Left" />
			                </asp:BoundField>
			                <asp:HyperLinkField DataNavigateUrlFields="UserLink" 
				                DataNavigateUrlFormatString="{0}" 
				                DataTextField="UserName" HeaderText="Player" >
				                <HeaderStyle HorizontalAlign="Left" />
			                </asp:HyperLinkField>
			                <asp:HyperLinkField DataNavigateUrlFields="AllianceLink" 
				                DataNavigateUrlFormatString="{0}" 
				                DataTextField="AllianceName" HeaderText="Aliance" >
				                <HeaderStyle HorizontalAlign="Left" />
			                </asp:HyperLinkField>
			                <asp:HyperLinkField DataNavigateUrlFields="VillageLink" 
				                DataNavigateUrlFormatString="{0}" 
				                DataTextField="VillageName" HeaderText="Village" >
				                <HeaderStyle HorizontalAlign="Left" />
			                </asp:HyperLinkField>
			                <asp:BoundField DataField="TribeName" HeaderText="Tribe" ReadOnly="True" >
				                <HeaderStyle HorizontalAlign="Left" />
			                </asp:BoundField>
			                <asp:BoundField DataField="Population" HeaderText="Population" 
				                ReadOnly="True" >
				                <HeaderStyle HorizontalAlign="Left" />
			                </asp:BoundField>
			                <asp:BoundField DataField="Distance" HeaderText="Distance" ReadOnly="True" >
				                <HeaderStyle HorizontalAlign="Left" />
			                </asp:BoundField>
			                <asp:HyperLinkField DataNavigateUrlFields="PlayerStatusLink" 
                                DataNavigateUrlFormatString="{0}" DataTextField="PlayerStatus" 
                                HeaderText="Status" />
			                <asp:BoundField DataField="Notes" HeaderText="Notes" >
				                <HeaderStyle HorizontalAlign="Left" />
			                </asp:BoundField>
			                <asp:CommandField ShowEditButton="True" />
		                    <asp:CommandField ShowSelectButton="True" />
		                </Columns>
		                <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
		                <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
		                <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
		                <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
		                <EditRowStyle BackColor="#7C6F57" />
		                <AlternatingRowStyle BackColor="White" />
	                </asp:GridView>
                </div>
                <div>
                    <asp:Panel ID="PanelGraphs" runat="server">
	                    <ZGW:ZEDGRAPHWEB id="VillagePie" runat="server" RenderMode="ImageTag">
                        </ZGW:ZEDGRAPHWEB>
	                    <ZGW:ZEDGRAPHWEB id="GoodsDate" runat="server" RenderMode="ImageTag">
                        </ZGW:ZEDGRAPHWEB>
                    </asp:Panel>
                </div>
            </div>
        </form>
    </body>
</html>
