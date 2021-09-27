<%@ Page Title="" Language="C#" MasterPageFile="~/Views/master.Master" AutoEventWireup="true" CodeBehind="addInterview.aspx.cs" Inherits="iTravel.Views.addInterview" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:image runat="server" id="imgLogo" width="200px"></asp:image>
    <form runat="server">
    <label>
        <h3>Meetup Date</h3>
        <asp:textbox runat="server" ID="tbDateTime" width="200px" class="form-control" TextMode="Date"></asp:textbox>
    </label>
        <br/>
    <label>
        <h3>Meetup Time</h3>
        <asp:textbox runat="server" ID="tbTime" width="200px" class="form-control" TextMode="Time"></asp:textbox>
    </label>
        <br/>
    <label>
        <h3>Meetup Location</h3>
        <asp:textbox runat="server" ID="tbLocation" width="200px" class="form-control"></asp:textbox>
    </label>
        <br/>
    <label>
        <h3> Additional Information </h3>
        <asp:textbox runat="server" ID="tbMoreInfo" width="300px" height="100px" class="form-control" TextMode="MultiLine"></asp:textbox>
    </label>
        <br />
    <asp:label runat="server" ID="lbStaffName" Visible="False"></asp:label>
    <asp:label runat="server" ID="lbAdminNo" Visible="False"></asp:label>
    <asp:label runat="server" ID="lbStaffHP" Visible="False"></asp:label>
    <asp:label runat="server" ID="lbTripId" Visible="False"></asp:label>
        <br/>
        <asp:button runat="server" text="Submit" class="btn btn-primary" OnClick="btnSubmit"/>
        </form>
    <div style="padding: 250px"></div>
</asp:Content>
