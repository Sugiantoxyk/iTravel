 <%@ Page Title="" Language="C#" MasterPageFile="~/Views/master.Master" AutoEventWireup="true" CodeBehind="ViewTrip.aspx.cs" Inherits="iTravel.Views.ViewTrip" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <title></title>
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
    <div>
    
        <h3>View Summary Of Current Trips<br /></h3>
        <br />
        
        <br />
        <br />
        
        <br />
        <a href="CreateTrip.aspx">Create Trip</a>
        
        <br />
        <asp:GridView ID="GridViewTD" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="GridViewTD_SelectedIndexChanged" DataKeyNames="Id" DataSourceID="SqlDataSource1" BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" CellPadding="2" ForeColor="Black" GridLines="None">
            <AlternatingRowStyle BackColor="PaleGoldenrod" />
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="Trip ID" InsertVisible="False" ReadOnly="True" SortExpression="Id" />
                <asp:BoundField DataField="tripName" HeaderText="Trip Name" SortExpression="tripName" />
                <asp:BoundField DataField="tripStaffNo" HeaderText="Staff No" SortExpression="tripStaffNo" />
                <asp:BoundField DataField="tripType" HeaderText="Type Of Trip" SortExpression="tripType" />
                <asp:BoundField DataField="tripLocation" HeaderText="Location" SortExpression="tripLocation" />
                <asp:BoundField DataField="tripCost" HeaderText="Cost" SortExpression="tripCost" />
                <asp:BoundField DataField="tripStartDate" HeaderText="Departure Date" SortExpression="tripStartDate" DataFormatString="{0:MM/dd/yy}" />
                <asp:BoundField DataField="tripEndDate" HeaderText="End Date" SortExpression="tripEndDate" DataFormatString="{0:MM/dd/yy}" />
                <asp:BoundField DataField="tripAirline" HeaderText="Trip Airline" />
                <asp:CommandField HeaderText="View" ShowHeader="True" ShowSelectButton="True" />
            </Columns>
            <FooterStyle BackColor="Tan" />
            <HeaderStyle BackColor="Tan" Font-Bold="True" />
            <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
            <SortedAscendingCellStyle BackColor="#FAFAE7" />
            <SortedAscendingHeaderStyle BackColor="#DAC09E" />
            <SortedDescendingCellStyle BackColor="#E1DB9C" />
            <SortedDescendingHeaderStyle BackColor="#C2A47B" />
        </asp:GridView>

        <br />
        <br />
        <br />
    
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:iTravelDBConnectionString %>" SelectCommand="SELECT * FROM [Trip] Where tripStartDate > GETDATE()"></asp:SqlDataSource>    
    </div>
    </form>
</asp:Content>
