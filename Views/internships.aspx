<%@ Page Title="" Language="C#" MasterPageFile="~/Views/master.Master" AutoEventWireup="true" CodeBehind="internships.aspx.cs" Inherits="iTravel.Views.internships" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../StyleSheets/internships.css" rel="stylesheet" />
    <title>iTravel - Internship</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Available Internships</h1>
    <hr />
    <div id="jobTitle" runat="server"></div>
    <br/>
    <div style="padding:250px">&nbsp;</div>
</asp:Content>
