<%@ Page Title="" Language="C#" MasterPageFile="~/Views/master.Master" AutoEventWireup="true" CodeBehind="Blog.aspx.cs" Inherits="iTravel.Views.Blog" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>iTravel - Blog</title>
    <link href="../StyleSheets/blog.css" rel="stylesheet" />
    <link href="https://fonts.googleapis.com/css?family=Amatic+SC|Lobster" rel="stylesheet">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <form runat="server" class="blogBG">
        <table>
            <tr>
                <td class="col-md-11">
                    <asp:Label ID="lbLocTitle" runat="server" style="font-family: 'Amatic SC', cursive; font-size: 100px"></asp:Label>
                </td>
                <td class="col-md-1" style="vertical-align:bottom;">
                    <asp:Button ID="btnNew" runat="server" Text="New Post &nbsp;&nbsp; +" OnClick="btnNew_Click" class="btn btn-basic" style="background-color: #33bbff; color: white; font-size: 16px;"/>
                </td>
            </tr>
        </table>
        <hr />
        <br />
        <div>
            <asp:PlaceHolder ID="blogs" runat="server"></asp:PlaceHolder>
        </div>
        <br />
        <br />
    </form>
    <br />
    <br />
</asp:Content>
