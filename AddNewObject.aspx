<%@ Page Title="AddNewObject" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="AddNewObject.aspx.cs" Inherits="AddNewObject" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server" ViewStateMode="Inherit">
    <h2 class="text-center">New object</h2>
    <hr />

    <div class="row" style="padding: 20px">
        <div>
            <section id="Insert data">
                <div style="padding-bottom: 20px">
                    <asp:Label Text="Manor name" runat="server" Width="150px"></asp:Label>
                    <asp:TextBox ID="ManorName" runat="server"></asp:TextBox>
                </div>
                <div style="padding-bottom: 20px">
                    <asp:Label Text="Google maps address" runat="server" Width="150px"></asp:Label>
                    <asp:TextBox ID="MapsURL" runat="server" Width="600px"></asp:TextBox>
                </div>
                <div style="padding-bottom: 20px">
                    <asp:Label Text="Info:" runat="server" Width="150px"></asp:Label>
                    <div>
                        <asp:TextBox ID="Information" runat="server" TextMode="MultiLine" Width="100%" Height ="400px"></asp:TextBox>
                    </div>
                </div>

                <div style="padding-bottom: 20px">
                    <asp:Label Text="Notes:" runat="server" Width="150px"></asp:Label>
                    <div>
                        <asp:TextBox ID="Notes" runat="server" TextMode="MultiLine" Width="50%" Height ="100px"></asp:TextBox>
                    </div>
                </div>
                <div>
                <div class="col-md-3">
                    <section id="MapsPhoto">
                        <asp:Label runat="server" Text="Maps photo"></asp:Label>
                        <asp:FileUpload ID="MapsPhotoUp" runat="server" />
                    </section>
                </div>
                <div class="col-md-3">
                    <section id ="SatellitePhotoSec">
                        <asp:Label runat="server" Text="Satellite photo"></asp:Label>
                        <asp:FileUpload ID="SatellitePhoto" runat="server" />
                    </section>
                </div>
                <div class="col-md-3">
                    <section id="TopoPhotoSec">
                        <asp:Label runat="server" Text="Topographic photo"></asp:Label>
                        <asp:FileUpload ID="TopoPhoto" runat="server" />
                    </section>
                </div>
                <div class="col-md-3">
                    <section id="Photos">
                        <asp:Label runat="server" Text="Manor photos"></asp:Label>
                        <asp:FileUpload ID="ManorPhotos" runat="server" AllowMultiple="true" />
                    </section>
                </div>
                <div class="col-md-3">
                    <section id="StreetView">
                        <asp:Label runat="server" Text="Street view photos"></asp:Label>
                        <asp:FileUpload ID="StreetPhotos" runat="server" AllowMultiple="true" />
                    </section>
                </div>
                </div>

                <div class="col-md-8" style="padding-top: 20px">
                    <asp:Button ID="SubmitButton" Text="Submit" OnClick="SubmitData" runat="server"/>
                </div>

            </section>
        </div>
    </div>
</asp:Content>
