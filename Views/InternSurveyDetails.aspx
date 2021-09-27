<%@ Page Title="" Language="C#" MasterPageFile="~/Views/master.Master" AutoEventWireup="true" CodeBehind="InternSurveyDetails.aspx.cs" Inherits="iTravel.Views.InternSurveyDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>iTravel - Internship Survey Details</title>
    <style type="text/css">
        .auto-style1 {
            width: 240px
        }
        .auto-style2 {
            width: 240px;
            height: 21px;
        }
        .auto-style3 {
            height: 21px;
        }
        .auto-style4 {
            width: 240px;
            height: 20px;
        }
        .auto-style5 {
            height: 20px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
        <br />
        <br />
        <br />
        <h1><asp:Label ID="lbTitle" runat="server" ></asp:Label>'s Survey Results</h1>
        <br />
    <table style="width: 100%;">
        <tr>
            <td class="auto-style2">Student Name :</td>
            <td class="auto-style3">
                <asp:Label ID="lbFullName" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">Admin No. :</td>
            <td>
                <asp:Label ID="lbAdminNo" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">Diploma :</td>
            <td>
                <asp:Label ID="lbDiploma" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">PEM Group :</td>
            <td>
                <asp:Label ID="lbPEMGroup" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">Gender :</td>
            <td>
                <asp:Label ID="lbGender" runat="server" ></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">Date of Birth :</td>
            <td>
                <asp:Label ID="lbDOB" runat="server" ></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">Contact :</td>
            <td>
                <asp:Label ID="lbContact" runat="server" ></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">Home Address :</td>
            <td>
                <asp:Label ID="lbAddress" runat="server" ></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">Citizenship :</td>
            <td>
                <asp:Label ID="lbCitizenship" runat="server" ></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">Passport No. :</td>
            <td>
                <asp:Label ID="lbPassportNo" runat="server" ></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">Passport Expiry Date</td>
            <td>
                <asp:Label ID="lbPassportExp" runat="server" ></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">Wait List :</td>
            <td>
                <asp:Label ID="lbWaitList" runat="server" ></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">GPA :</td>
            <td>
                <asp:Label ID="lbGPA" runat="server" ></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">CCA :</td>
            <td>
                <asp:Label ID="lbCCA" runat="server" ></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style4">Leadership Quality :</td>
            <td class="auto-style5">
                <asp:Label ID="lbLeadership" runat="server" ></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style4">Past Offences Committed :</td>
            <td class="auto-style5">
                <asp:Label ID="lbOffence" runat="server" ></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">PSEA Balance :</td>
            <td>
                <asp:Label ID="lbPSEABalance" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style4">Funding Scheme:</td>
            <td class="auto-style5">
                <asp:Label ID="lbFundingScheme" runat="server" ></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style4">Past FASOP :</td>
            <td class="auto-style5">
                <asp:Label ID="lbFasopHist" runat="server" ></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">Medical Condition :</td>
            <td>
                <asp:Label ID="lbMedCondition" runat="server" ></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style4">Part Time Experiences :</td>
            <td class="auto-style5">
                <asp:Label ID="lbPartTimeExp" runat="server" ></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">Past Overseas Trips :</td>
            <td>
                <asp:Label ID="lbOverseasStay" runat="server" ></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">Independence Description :</td>
            <td>
                <asp:Label ID="lbIndependence" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">
                <asp:Label ID="lbSpecialQn" runat="server"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lbSpecialAns" runat="server" ></asp:Label>
            </td>
        </tr>
    </table>
    <div style="padding:250px">&nbsp;</div>
    </form>
</asp:Content>
