<%@ Page Title="" Language="C#" MasterPageFile="~/Views/master.Master" AutoEventWireup="true" CodeBehind="allTrips.aspx.cs" Inherits="iTravel.Views.allTrips" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <link href="../StyleSheets/internships.css" rel="stylesheet" />
    <title>iTravel - Trips</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Trips</h1>
    <br/>
    <br/>
    <asp:placeholder runat="server" ID="allTrip"></asp:placeholder>
    <br/>
    <div style="padding:250px">&nbsp;</div>
</asp:Content>
