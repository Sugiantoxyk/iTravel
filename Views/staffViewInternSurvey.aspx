<%@ Page Title="" Language="C#" MasterPageFile="~/Views/master.Master" AutoEventWireup="true" CodeBehind="staffViewInternSurvey.aspx.cs" Inherits="iTravel.Views.staffViewInternSurvey" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <a href="../Views/createInternship.aspx">Add new internship</a>
    <br />
    <form runat="server">
        <asp:DropDownList ID="ddlInternships" runat="server" CssClass="form-control col-md-6" Width="500px">
        </asp:DropDownList>
        &nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnViewResults" runat="server" Text="View Results" CssClass="btn btn-primary" OnClick="btnViewResults_Click" />
        <br/><br/>
        <asp:Panel ID="pResults" runat="server" Visible="false">
        <h1>Internship Applicants</h1>
        <asp:GridView ID="gvInternResults" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="gvInternResults_SelectedIndexChanged" Width="904px" OnRowCommand="gvInternResults_RowCommand" CellPadding="4" ForeColor="#333333" GridLines="None" >
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="isFullName" HeaderText="Student Name" />
                <asp:BoundField DataField="isContact" HeaderText="Phone no." />
                <asp:BoundField DataField="isAdminNo" HeaderText="Admin no." />
                <asp:BoundField DataField="isGender" HeaderText="Gender" />
                <asp:BoundField DataField="isDiploma" HeaderText="Course" />
                <asp:BoundField DataField="isGPA" DataFormatString="{0:F}" HeaderText="GPA" />
                <asp:ButtonField CommandName="accept" HeaderText="Accept" Text="Accept" ButtonType="Button" />
                <asp:ButtonField CommandName="decline" HeaderText="Decline" Text="Decline" ButtonType="Button" />
                <asp:CommandField HeaderText="Details" ShowSelectButton="True" />
                <asp:ButtonField CommandName="downloadResume" HeaderText="Resume" Text="Download" />
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
         <h1>Interview Applicants</h1>
            <asp:GridView ID="gvAccepted" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" Width="269px" OnRowCommand="gvAccepted_RowCommand">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="idAdminNo" HeaderText="Admin No" />
                    <asp:ButtonField CommandName="approve" HeaderText="Approve" Text="Approve" />
                    <asp:ButtonField CommandName="reject" HeaderText="Reject" Text="Reject" />
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

        </asp:Panel>
    </form>
    <div style="padding:250px">&nbsp;</div>
</asp:Content>
