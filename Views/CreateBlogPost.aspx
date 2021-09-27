<%@ Page Title="" Language="C#" MasterPageFile="~/Views/master.Master" AutoEventWireup="true" CodeBehind="CreateBlogPost.aspx.cs" Inherits="iTravel.Views.CreateBlog" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title> iTravel - New Blog Post </title>
    <link href="../StyleSheets/blogCreate.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <form runat="server" class="blogBG">
        <div>
            <h3>New Blog Post ✈️</h3>
            <br />
            <h3>Location: <asp:label runat="server" ID="lbBlogLocation"></asp:label></h3>
            <br />
            <table width="100%">
                <tr class="form-group">
                    <td>
                        <asp:label runat="server" ID="lbBlogTitle">Title</asp:label><br />
                        <asp:textbox runat="server" ID="tbBlogTitle" Cssclass="title form-control" required></asp:textbox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <br />
                    </td>
                </tr>
                <tr class="form-group">
                    <td class="auto-style1">
                        <asp:label runat="server" ID="lbBlogDesc">What's Happening?</asp:label>
                        <asp:textbox runat="server" ID="tbBlogDesc" width="100%" Rows="6" Cssclass="desc form-control" TextMode="MultiLine" required></asp:textbox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <br />
                    </td>
                </tr>
                <tr class="form-group">
                    <td>
                        <asp:Label ID="lbAddImg" runat="server" Text="Add an Image: "></asp:Label><asp:FileUpload ID="blogImage" runat="server" />
                    </td>
                </tr>
            </table>
            <br />
            <br />
            <asp:Button ID="btnPostBlog" runat="server" Text="Post" OnClick="btnPostBlog_Click" Cssclass="btn btn-info" style="width: 80px;"/>
        </div>
    </form>
    <br /><br /><br />
</asp:Content>