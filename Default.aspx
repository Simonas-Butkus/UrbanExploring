<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">   

    <div class="row" style="padding: 20px">
        <div>
            <h3>Search</h3>
            <div style="padding-top: 10px">
                <div>
                    <asp:Panel ID="Panel1" runat="server" DefaultButton="SearchButton">
                        <asp:TextBox ID="SearchTB" runat="server" placeholder="Object name"></asp:TextBox>
                        <asp:Button ID="SearchButton" runat="server" OnClick="SearchButton_Click" Text="Search" />
                        <asp:Button runat="server" Visible="false" Text="Edit" ID="EditCurrent" OnClick="EditCurrent_Click" Style="position: relative" />
                    </asp:Panel>
                </div>
                <div>
                    <asp:ListView runat="server" ID="SearchLV" Visible ="false" OnItemCommand="SearchLV_ItemCommand">
                        <ItemTemplate>
                            <asp:LinkButton ID="SearchFromList" runat="server" CommandName='<%#Eval("Name") %>'>
                                <p>
                                    <%#Eval("Name") %>
                                </p>
                            </asp:LinkButton>
                        </ItemTemplate>
                    </asp:ListView>
                </div>
            </div>
        </div>
    </div>

    <div id="ContentBlock" runat="server" visible="false" style="padding-top: 30px; position: relative;">
        <hr />
        <div>
            <center>
                    <p><asp:Label ID="ObjectName" runat="server" Font-Size="30"></asp:Label></p>
                    <asp:HyperLink ID="MapsURL" Target="_blank" runat="server"></asp:HyperLink>
                </center>
            <hr />
        </div>
        <div>
            <div style="padding-top: 100px">
                <div class="col-md-6">
                    <asp:Image ID="Photo1" runat="server" Width="100%" />
                </div>
                <div class="col-md-6">
                    <asp:Image ID="Photo2" runat="server" Width="100%" />
                </div>
            </div>
            <div>
                <div class="col-md-6">
                    <asp:Image ID="Photo3" runat="server" Width="100%" />
                </div>
                <div class="col-md-6">
                    <asp:Image ID="Photo4" runat="server" Width="100%" />
                </div>
            </div>
            <div class="col-md-6">
                <asp:Image ID="Photo5" runat="server" Width="100%" />
            </div>
        </div>
        <div>
            <div>
                <asp:Label ID="InfoLabel" runat="server"></asp:Label>
            </div>

            <div style="padding-top: 100px">
                <asp:Label ID="NotesLabel" runat="server"></asp:Label>
            </div>

            <div style="padding-top: 100px">
                <center>
                 <asp:Image ID="MapsIMG" runat="server" Width="75%"/>
                 <asp:Image ID="SatelliteIMG" runat="server" Width="75%"/>
                 <asp:Image ID="TopoIMG" runat="server" Width="75%"/>
                </center>
            </div>
        </div>


    </div>
</asp:Content>
