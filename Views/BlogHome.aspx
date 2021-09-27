<%@ Page Title="" Language="C#" MasterPageFile="~/Views/master.Master" AutoEventWireup="true" CodeBehind="BlogHome.aspx.cs" Inherits="iTravel.Views.BlogHome" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>iTravel - Blog Home</title>
    <link href="../StyleSheets/blogHome.css" rel="stylesheet" />
    <link href="https://fonts.googleapis.com/css?family=Permanent+Marker" rel="stylesheet">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br /><br />
    <div class="container blogBG">
        <h1 style="text-align: center; font-family: 'Permanent Marker', cursive; font-size: 50px;">Welcome iTravel Bloggers</h1>
        <br />
        <br />
        <asp:placeholder runat="server" ID="blogPH"></asp:placeholder>
    </div>
    <br /><br /><br />
</asp:Content>