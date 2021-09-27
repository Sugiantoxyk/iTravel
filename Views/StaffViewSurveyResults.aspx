<%@ Page Title="" Language="C#" MasterPageFile="~/Views/master.Master" AutoEventWireup="true" CodeBehind="StaffViewSurveyResults.aspx.cs" Inherits="iTravel.Views.StaffViewSurveyResults" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
        <h1><asp:Label ID="Label2" runat="server" Text="Immersion Trip Survey Results
            "></asp:Label></h1>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" DataSourceID="SqlDataSource1" Width="684px" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
            <EmptyDataTemplate>No surveys for Immersion Trips</EmptyDataTemplate>
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="False" ReadOnly="True" SortExpression="Id" />
                <asp:BoundField DataField="tripName" HeaderText="Trip Name" SortExpression="tripName" />
                <asp:BoundField DataField="diploma" HeaderText="Diploma" SortExpression="diploma" />
                <asp:BoundField DataField="adminNo" HeaderText="Admin Number" SortExpression="adminNo" />
                <asp:BoundField DataField="PEMGroup" HeaderText="PEM Group" SortExpression="PEMGroup" />
                <asp:BoundField DataField="fullName" HeaderText="Name" SortExpression="fullName" />
                <asp:BoundField DataField="tripType" HeaderText="Trip Type" SortExpression="tripType" />
                <asp:BoundField DataField="PEMNote" HeaderText="PEM Note" SortExpression="PEMNote" />
                <asp:CommandField HeaderText="Options" ShowSelectButton="True" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:iTravelDBConnectionString %>" SelectCommand="SELECT [Id], [tripName], [diploma], [PEMGroup], [PEMNote], [adminNo], [fullName], [tripType] FROM [surveyResults] WHERE ([tripType] = @tripType)" OldValuesParameterFormatString="original_{0}">
            <SelectParameters>
                <asp:Parameter DefaultValue="Immersion" Name="tripType" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
       <h1> <asp:Label ID="Label1" runat="server" Text="Study Trip Survey Results"></asp:Label></h1>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:iTravelDBConnectionString %>" SelectCommand="SELECT [Id], [tripName], [tripType], [diploma], [adminNo], [gender], [GPA], [fullName] FROM [surveyResults] WHERE ([tripType] = @tripType) ORDER BY [tripName] DESC" ConflictDetection="CompareAllValues" DeleteCommand="DELETE FROM [surveyResults] WHERE [Id] = @original_Id AND (([tripName] = @original_tripName) OR ([tripName] IS NULL AND @original_tripName IS NULL)) AND (([tripType] = @original_tripType) OR ([tripType] IS NULL AND @original_tripType IS NULL)) AND (([diploma] = @original_diploma) OR ([diploma] IS NULL AND @original_diploma IS NULL)) AND (([adminNo] = @original_adminNo) OR ([adminNo] IS NULL AND @original_adminNo IS NULL)) AND (([gender] = @original_gender) OR ([gender] IS NULL AND @original_gender IS NULL)) AND (([GPA] = @original_GPA) OR ([GPA] IS NULL AND @original_GPA IS NULL)) AND (([fullName] = @original_fullName) OR ([fullName] IS NULL AND @original_fullName IS NULL))" InsertCommand="INSERT INTO [surveyResults] ([tripName], [tripType], [diploma], [adminNo], [gender], [GPA], [fullName]) VALUES (@tripName, @tripType, @diploma, @adminNo, @gender, @GPA, @fullName)" OldValuesParameterFormatString="original_{0}" UpdateCommand="UPDATE [surveyResults] SET [tripName] = @tripName, [tripType] = @tripType, [diploma] = @diploma, [adminNo] = @adminNo, [gender] = @gender, [GPA] = @GPA, [fullName] = @fullName WHERE [Id] = @original_Id AND (([tripName] = @original_tripName) OR ([tripName] IS NULL AND @original_tripName IS NULL)) AND (([tripType] = @original_tripType) OR ([tripType] IS NULL AND @original_tripType IS NULL)) AND (([diploma] = @original_diploma) OR ([diploma] IS NULL AND @original_diploma IS NULL)) AND (([adminNo] = @original_adminNo) OR ([adminNo] IS NULL AND @original_adminNo IS NULL)) AND (([gender] = @original_gender) OR ([gender] IS NULL AND @original_gender IS NULL)) AND (([GPA] = @original_GPA) OR ([GPA] IS NULL AND @original_GPA IS NULL)) AND (([fullName] = @original_fullName) OR ([fullName] IS NULL AND @original_fullName IS NULL))">
            <DeleteParameters>
                <asp:Parameter Name="original_Id" Type="Int32" />
                <asp:Parameter Name="original_tripName" Type="String" />
                <asp:Parameter Name="original_tripType" Type="String" />
                <asp:Parameter Name="original_diploma" Type="String" />
                <asp:Parameter Name="original_adminNo" Type="String" />
                <asp:Parameter Name="original_gender" Type="String" />
                <asp:Parameter Name="original_GPA" Type="String" />
                <asp:Parameter Name="original_fullName" Type="String" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="tripName" Type="String" />
                <asp:Parameter Name="tripType" Type="String" />
                <asp:Parameter Name="diploma" Type="String" />
                <asp:Parameter Name="adminNo" Type="String" />
                <asp:Parameter Name="gender" Type="String" />
                <asp:Parameter Name="GPA" Type="String" />
                <asp:Parameter Name="fullName" Type="String" />
            </InsertParameters>
            <SelectParameters>
                <asp:Parameter DefaultValue="Study" Name="tripType" Type="String" />
            </SelectParameters>
            <UpdateParameters>
                <asp:Parameter Name="tripName" Type="String" />
                <asp:Parameter Name="tripType" Type="String" />
                <asp:Parameter Name="diploma" Type="String" />
                <asp:Parameter Name="adminNo" Type="String" />
                <asp:Parameter Name="gender" Type="String" />
                <asp:Parameter Name="GPA" Type="String" />
                <asp:Parameter Name="fullName" Type="String" />
                <asp:Parameter Name="original_Id" Type="Int32" />
                <asp:Parameter Name="original_tripName" Type="String" />
                <asp:Parameter Name="original_tripType" Type="String" />
                <asp:Parameter Name="original_diploma" Type="String" />
                <asp:Parameter Name="original_adminNo" Type="String" />
                <asp:Parameter Name="original_gender" Type="String" />
                <asp:Parameter Name="original_GPA" Type="String" />
                <asp:Parameter Name="original_fullName" Type="String" />
            </UpdateParameters>
        </asp:SqlDataSource>
        
        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" DataSourceID="SqlDataSource3" OnSelectedIndexChanged="GridView2_SelectedIndexChanged" Width="694px">
             <EmptyDataTemplate>No surveys for Study Trips</EmptyDataTemplate>
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="False" ReadOnly="True" SortExpression="Id" />
                <asp:BoundField DataField="tripName" HeaderText="Trip Name" SortExpression="tripName" />
                <asp:BoundField DataField="diploma" HeaderText="Diploma" SortExpression="diploma" />
                <asp:BoundField DataField="adminNo" HeaderText="Admin Number" SortExpression="adminNo" />
                <asp:BoundField DataField="PEMGroup" HeaderText="PEM Group" SortExpression="PEMGroup" />
                <asp:BoundField DataField="fullName" HeaderText="Name" SortExpression="fullName" />
                <asp:BoundField DataField="tripType" HeaderText="Trip Type" SortExpression="tripType" />
                <asp:BoundField DataField="PEMNote" HeaderText="PEM Note" SortExpression="PEMNote" />
                <asp:CommandField ShowSelectButton="True" HeaderText="Options" />
            </Columns>
        </asp:GridView>
        
        <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:iTravelDBConnectionString %>" SelectCommand="SELECT [Id], [tripName], [diploma], [adminNo], [PEMGroup], [PEMNote], [fullName], [tripType] FROM [surveyResults] WHERE ([tripType] = @tripType)">
            <SelectParameters>
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
   <br /><br /><br /><br /><br /><br /><br /><br /><br />
</asp:Content>
