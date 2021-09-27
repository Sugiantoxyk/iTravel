<%@ Page Title="" Language="C#" MasterPageFile="~/Views/master.Master" AutoEventWireup="true" CodeBehind="createInternship.aspx.cs" Inherits="iTravel.Views.createInternship" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../StyleSheets/createInternship.css" rel="stylesheet" />
    <title>iTravel - Internship Survey</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form runat="server">
        <br />
        <label>
        <h3>Company Logo</h3>
            <asp:FileUpload ID="fuLogo" runat="server" />
        </label>
        <br/>
        <label>
        <h3>Job Title</h3>
        <asp:TextBox ID="tbJobTitle" class="form-control" width="200px" runat="server"></asp:TextBox>
        </label>
        <br />
        <label>
        <h3>Country</h3>
        <asp:TextBox ID="tbCountry" class="form-control" width="200px" runat="server"></asp:TextBox>
        </label>
        <br />
        <label>
        <h3>Salary</h3>
        <span class="details">Per Month</span>
        <asp:TextBox ID="tbSalary" class="form-control" width="200px" runat="server"></asp:TextBox>
        </label>
        <br />
        <label>
        <h3>Company Website</h3>
        <asp:TextBox ID="tbWebsite" class="form-control" width="400px" runat="server" TextMode="Url"></asp:TextBox>
        </label>
        <br />
        <label>
        <h3>Company Contact</h3>
        <asp:TextBox ID="tbContact" class="form-control" width="200px" runat="server" TextMode="Phone"></asp:TextBox>
        </label>
        <br />
        <label>
        <h3>Company Email</h3>
        <asp:TextBox ID="tbEmail" class="form-control" width="300px" runat="server" TextMode="Email"></asp:TextBox>
        </label>
        <br />
        <label>
        <h3>Working Duration (In Months) </h3>
        <asp:TextBox ID="tbDuration" class="form-control" width="100px" runat="server" TextMode="Number"></asp:TextBox>
        </label>
        <br />
        <label>
        <h3>Industry</h3>
        <asp:TextBox ID="tbIndustry" class="form-control" width="300px" runat="server"></asp:TextBox>
        </label>
        <br />
        <label>
        <h3>Regular Working Hours</h3>
        <span class="details">(E.g. Monday to Friday, 9AM to 6PM) </span>
        <asp:TextBox ID="tbWorkingHrs" class="form-control" width="300px" runat="server"></asp:TextBox>
        </label>
        <br />
        <label>
        <h3>Company Name</h3>
        <asp:TextBox ID="tbCompany" class="form-control" width="300px" runat="server"></asp:TextBox>
        </label>
        <br />
        <label>
        <h3>Overview</h3>
        <asp:TextBox ID="tbOverview" class="form-control" width="500px" height="200px" runat="server" TextMode="MultiLine"></asp:TextBox>
        </label>
        <br />
        <label>
        <h3>Job Scope</h3>
        <asp:TextBox ID="tbJobScope" class="form-control" width="500px" height="200px" runat="server" TextMode="MultiLine"></asp:TextBox>
        </label>
        <br />
        <label>
        <h3>Eligibility</h3>
        <asp:TextBox ID="tbEligibility" class="form-control" width="500px" height="200px" runat="server" TextMode="MultiLine"></asp:TextBox>
        </label>
        <br/>
        <label>
        <h3>Enter a question for the students applying for this internship.</h3>
        <span class="details"></span>
        <asp:TextBox ID="tbSpecialQn" class="form-control" width="400px" runat="server"></asp:TextBox>
        </label>
        <br />
        <br />
        <asp:Button ID="createInternBtn" runat="server" Text="Submit" CssClass="btn btn-primary" OnClick="createInternBtn_Click" />
        &nbsp;
        <input type="reset" value="Clear" class="btn btn-default">
        <br/>
        <asp:Label ID="lblResult" runat="server"></asp:Label>
        <asp:Label ID="lblUploadImage" runat="server"></asp:Label>
    </form>


    <div style="padding:250px">&nbsp;</div>
</asp:Content>
