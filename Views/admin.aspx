<%@ Page Title="" Language="C#" MasterPageFile="~/Views/master.Master" AutoEventWireup="true" CodeBehind="admin.aspx.cs" Inherits="iTravel.Views.admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>iTravel - Admin</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br /><br />
    <form id="form1" runat="server">
        <h1>List of Blogs</h1>
        <asp:DropDownList ID="ddlCat" runat="server" OnSelectedIndexChanged="ddlCat_SelectedIndexChanged" AutoPostBack="True" CssClass="form-control">
            <asp:ListItem Selected="True">--Select--</asp:ListItem>
            <asp:ListItem>All Blogs</asp:ListItem>
            <asp:ListItem>Posted Blogs</asp:ListItem>
            <asp:ListItem>Reported Blogs</asp:ListItem>
            <asp:ListItem>Archived Blogs</asp:ListItem>
        </asp:DropDownList>
        <br /><br />
        <h2 style="text-align: center;"><asp:Label ID="LbMsg" runat="server" Visible="False"></asp:Label></h2>
        <div class="blogs">
            <asp:GridView ID="GridView_AllBlog" runat="server" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="blogID" DataSourceID="AllBlogs" CssClass="table table-striped" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="blogID" HeaderText="blogID" InsertVisible="False" ReadOnly="True" SortExpression="blogID" />
                    <asp:BoundField DataField="blogTitle" HeaderText="blogTitle" SortExpression="blogTitle" />
                    <asp:BoundField DataField="blogLocation" HeaderText="blogLocation" SortExpression="blogLocation" />
                    <asp:BoundField DataField="blogDateTime" HeaderText="blogDateTime" SortExpression="blogDateTime" />
                    <asp:BoundField DataField="blogUser" HeaderText="blogUser" SortExpression="blogUser" />
                    <asp:BoundField DataField="blogReports" HeaderText="blogReports" SortExpression="blogReports" />
                    <asp:BoundField DataField="blogStatus" HeaderText="blogStatus" SortExpression="blogStatus" />
                </Columns>
                <EditRowStyle BackColor="#2461BF" />
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#EFF3FB" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                <SortedDescendingHeaderStyle BackColor="#4870BE" />

            </asp:GridView>

            <asp:SqlDataSource ID="AllBlogs" runat="server" ConnectionString="<%$ ConnectionStrings:iTravelDBConnectionString %>" SelectCommand="SELECT [blogID], [blogTitle], [blogLocation], [blogDateTime], [blogUser], [blogReports], [blogStatus] FROM [Blog]"></asp:SqlDataSource>


            <asp:GridView ID="GridView_Reported" runat="server" AutoGenerateColumns="False" DataKeyNames="blogID" DataSourceID="ReportedBlogs" CssClass="table table-striped" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowCommand="GridView_Reported_RowCommand">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="blogID" HeaderText="blogID" InsertVisible="False" ReadOnly="True" SortExpression="blogID" />
                    <asp:BoundField DataField="blogTitle" HeaderText="blogTitle" SortExpression="blogTitle" />
                    <asp:BoundField DataField="blogLocation" HeaderText="blogLocation" SortExpression="blogLocation" />
                    <asp:BoundField DataField="blogDateTime" HeaderText="blogDateTime" SortExpression="blogDateTime" />
                    <asp:BoundField DataField="blogUser" HeaderText="blogUser" SortExpression="blogUser" />
                    <asp:BoundField DataField="blogReports" HeaderText="blogReports" SortExpression="blogReports" />
                    <asp:BoundField DataField="blogStatus" HeaderText="blogStatus" SortExpression="blogStatus" />
                    <asp:ButtonField CommandName="Archive" HeaderText="Arhive" Text="Archive" />
                </Columns>
                <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                <SortedAscendingCellStyle BackColor="#FDF5AC" />
                <SortedAscendingHeaderStyle BackColor="#4D0000" />
                <SortedDescendingCellStyle BackColor="#FCF6C0" />
                <SortedDescendingHeaderStyle BackColor="#820000" />
            </asp:GridView>

            <asp:SqlDataSource ID="ReportedBlogs" runat="server" ConnectionString="<%$ ConnectionStrings:iTravelDBConnectionString %>" SelectCommand="SELECT [blogID], [blogTitle], [blogLocation], [blogDateTime], [blogUser], [blogReports], [blogStatus] FROM [Blog] WHERE ([blogReports] &gt; @blogReports) ORDER BY [blogReports] DESC">
                <SelectParameters>
                    <asp:Parameter DefaultValue="0" Name="blogReports" Type="Int32" />
                </SelectParameters>
            </asp:SqlDataSource>


            <asp:GridView ID="GridView_Blog" runat="server" AutoGenerateColumns="False" DataSourceID="PostedBlogs" CssClass="table table-striped" OnRowCommand="GridView_Blog_RowCommand" CellPadding="4" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="blogID" HeaderText="Blog ID" />
                    <asp:BoundField DataField="blogTitle" HeaderText="Title" />
                    <asp:BoundField DataField="blogLocation" HeaderText="Location" />
                    <asp:BoundField DataField="blogDateTime" HeaderText="DateTime" />
                    <asp:BoundField DataField="blogUser" HeaderText="User " />
                    <asp:BoundField DataField="blogReports" HeaderText="No. of Reports" />
                    <asp:ButtonField CommandName="Archive" HeaderText="Archive" Text="Archive" />
                </Columns>

                <EditRowStyle BackColor="#7C6F57" />
                <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#E3EAEB" />
                <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F8FAFA" />
                <SortedAscendingHeaderStyle BackColor="#246B61" />
                <SortedDescendingCellStyle BackColor="#D4DFE1" />
                <SortedDescendingHeaderStyle BackColor="#15524A" />

            </asp:GridView>
            <asp:SqlDataSource ID="PostedBlogs" runat="server" ConnectionString="<%$ ConnectionStrings:iTravelDBConnectionString %>" SelectCommand="SELECT [blogID], [blogTitle], [blogLocation], [blogUser], [blogDateTime], [blogLocation], [blogReports], [blogStatus] FROM [Blog] WHERE ([blogStatus] = @blogStatus) ORDER BY [blogID]">
                <SelectParameters>
                    <asp:Parameter DefaultValue="Posted" Name="blogStatus" Type="String" />
                </SelectParameters>
            </asp:SqlDataSource>


            <asp:GridView ID="GridView_Archived" runat="server" AutoGenerateColumns="False" CssClass="table table-striped" DataSourceID="ArchivedBlogs" OnRowCommand="GridView_Archived_RowCommand" CellPadding="4" ForeColor="Black" GridLines="Vertical" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="blogID" HeaderText="Blog ID" />
                    <asp:BoundField DataField="blogTitle" HeaderText="Title" />
                    <asp:BoundField DataField="blogLocation" HeaderText="Location" />
                    <asp:BoundField DataField="blogDateTime" HeaderText="DateTime" />
                    <asp:BoundField DataField="blogUser" HeaderText="User " />
                    <asp:BoundField DataField="blogReports" HeaderText="No. of Reports" />
                    <asp:ButtonField CommandName="Undo Archive" HeaderText="Undo Archive" Text="Undo Archive" />
                    <asp:ButtonField CommandName="Delete" HeaderText="Delete" Text="Delete"/>
                </Columns>
                <FooterStyle BackColor="#CCCC99" />
                <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                <RowStyle BackColor="#F7F7DE" />
                <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#FBFBF2" />
                <SortedAscendingHeaderStyle BackColor="#848384" />
                <SortedDescendingCellStyle BackColor="#EAEAD3" />
                <SortedDescendingHeaderStyle BackColor="#575357" />
            </asp:GridView>
            <asp:SqlDataSource ID="ArchivedBlogs" runat="server" ConnectionString="<%$ ConnectionStrings:iTravelDBConnectionString %>" SelectCommand="SELECT [blogID], [blogTitle], [blogLocation], [blogUser], [blogDateTime], [blogLocation], [blogReports], [blogStatus] FROM [Blog] WHERE ([blogStatus] = @blogStatus) ORDER BY [blogID]">
                <SelectParameters>
                    <asp:Parameter DefaultValue="Archived" Name="blogStatus" Type="String" />
                </SelectParameters>
            </asp:SqlDataSource>
        </div>
    </form>
    <br /><br /><br />
    <br /><br /><br />
    <br /><br /><br />
</asp:Content>
