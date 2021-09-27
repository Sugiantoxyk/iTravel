<%@ Page Title="" Language="C#" MasterPageFile="~/Views/master.Master" AutoEventWireup="true" CodeBehind="PEMViewSurveyResults.aspx.cs" Inherits="iTravel.Views.PEMViewSurveyResults" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
        <h1><asp:Label ID="Label2" runat="server" Text="Immersion Trip Survey Results 
            "></asp:Label></h1>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource4" Width="684px" DataKeyNames="Id" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
            <EmptyDataTemplate>No surveys for Immersion Trips</EmptyDataTemplate>
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="Survey No" InsertVisible="False" ReadOnly="True" SortExpression="Id" />
                <asp:BoundField DataField="tripName" HeaderText="Trip Location" SortExpression="tripName" />
                <asp:BoundField DataField="tripType" HeaderText="Type" SortExpression="tripType" />
                <asp:BoundField DataField="diploma" HeaderText="Diploma" SortExpression="diploma" />
                <asp:BoundField DataField="PEMGroup" HeaderText="PEM Group" SortExpression="PEMGroup" />
                <asp:BoundField DataField="PEMNote" HeaderText="PEM's Note" SortExpression="PEMNote" />
                <asp:BoundField DataField="adminNo" HeaderText="Admin No" SortExpression="adminNo" />
                <asp:BoundField DataField="fullName" HeaderText="Name" SortExpression="fullName" />
                <asp:CommandField SelectText="Add Note" ShowSelectButton="True" HeaderText="Options" />
            </Columns>
        </asp:GridView>
       
        <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:iTravelDBConnectionString %>" SelectCommand="SELECT DISTINCT [tripName], [tripType], [diploma], [PEMGroup], [PEMNote], [adminNo], [fullName], [Id] FROM [surveyResults] WHERE (([tripType] = @tripType) AND ([PEMGroup] = @PEMGroup)) ORDER BY [Id] DESC">
            <SelectParameters>
                <asp:Parameter DefaultValue="Immersion" Name="tripType" Type="String" />
                <asp:SessionParameter Name="PEMGroup" SessionField="pemgroup" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
       <h1> <asp:Label ID="Label1" runat="server" Text="Study Trip Survey Results"></asp:Label></h1>
         
        
        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" DataSourceID="SqlDataSource8" Width="686px" OnSelectedIndexChanged="GridView2_SelectedIndexChanged">
             <EmptyDataTemplate>No surveys for Study Trips</EmptyDataTemplate>
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="False" ReadOnly="True" SortExpression="Id" />
                <asp:BoundField DataField="tripName" HeaderText="tripName" SortExpression="tripName" />
                <asp:BoundField DataField="tripType" HeaderText="tripType" SortExpression="tripType" />
                <asp:BoundField DataField="diploma" HeaderText="diploma" SortExpression="diploma" />
                <asp:BoundField DataField="PEMGroup" HeaderText="PEMGroup" SortExpression="PEMGroup" />
                <asp:BoundField DataField="adminNo" HeaderText="adminNo" SortExpression="adminNo" />
                <asp:BoundField DataField="fullName" HeaderText="fullName" SortExpression="fullName" />
                <asp:CommandField SelectText="Add Note" ShowSelectButton="True" HeaderText="Options" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource8" runat="server" ConnectionString="<%$ ConnectionStrings:iTravelDBConnectionString %>" SelectCommand="SELECT [Id], [tripName], [tripType], [diploma], [PEMGroup], [adminNo], [fullName] FROM [surveyResults] WHERE (([PEMGroup] = @PEMGroup) AND ([tripType] = @tripType))">
            <SelectParameters>
                <asp:SessionParameter Name="PEMGroup" SessionField="pemgroup" Type="String" />
                <asp:Parameter DefaultValue="Study Trip" Name="tripType" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
         
        
        <br />
    </form>
    <style>

.mydatagrid
{

    width: 80%;

    border: solid 2px black;

    min-width: 80%;

}

.header

{

    background-color: #000;

    font-family: Arial;

    color: White;

    height: 25px;

    text-align: center;

    font-size: 16px;

}

 

.rows

{

    background-color: #fff;

    font-family: Arial;

    font-size: 14px;

    color: #000;

    min-height: 25px;

    text-align: left;

}

.rows:hover

{

    background-color: #5badff;

    color: #fff;

}

 

.mydatagrid a /** FOR THE PAGING ICONS  **/

{

    background-color: Transparent;

    padding: 5px 5px 5px 5px;

    color: #fff;

    text-decoration: none;

    font-weight: bold;

}


.mydatagrid a:hover /** FOR THE PAGING ICONS  HOVER STYLES**/

{

    background-color: #000;

    color: #fff;

}

.mydatagrid span /** FOR THE PAGING ICONS CURRENT PAGE INDICATOR **/

{

    background-color: #fff;

    color: #000;

    padding: 5px 5px 5px 5px;

}

.pager

{

    background-color: #5badff;

    font-family: Arial;

    color: White;

    height: 30px;

    text-align: left;

}

 

.mydatagrid td

{

    padding: 5px;

}

.mydatagrid th

{

    padding: 5px;

}

    </style>
    <br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br />
</asp:Content>
