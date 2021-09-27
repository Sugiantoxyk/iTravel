<%@ Page Title="" Language="C#" MasterPageFile="~/Views/master.Master" AutoEventWireup="true" CodeBehind="immersionTrips.aspx.cs" Inherits="iTravel.Views.immersionTrips" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <link href="../StyleSheets/internships.css" rel="stylesheet" />
    <title>iTravel - Trips</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>

    </style>
    <h1>Immersion Trips</h1>

    <br/>
    <br/>
    <asp:placeholder runat="server" ID="immersionTripe"></asp:placeholder>
    <br/>
    <div style="padding:250px">&nbsp;</div>
</asp:Content>
