<%@ Page Title="" Language="C#" MasterPageFile="~/Views/master.Master" AutoEventWireup="true" CodeBehind="ViewTripDetails.aspx.cs" Inherits="iTravel.Views.ViewTripDetials" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style2 {
            width: 303px;
            height: 20px;
        }
        .auto-style3 {
            height: 20px;
        }
        .auto-style4 {
            width: 303px
        }
        .lbGetImg{
            max-height:500px;
            max-width:500px;
            height:auto;
            width:auto;
        }
         .button {
            font-size: 16px;
            color: white;
            line-height: 1.2;
            padding: 0 20px;
            min-width: 150px;
            height: 50px;
            background-color: #333333;
            border-radius: 27px;
            border: none;
            font-weight: bold;
            outline: none;
            transition: all .2s ease-in-out;
        }
        .button:hover {
            background-color: cornflowerblue;
            transition: all .2s ease-in-out;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <form id="form1" runat="server">
        <table class="nav-justified">
            <tr>
                <h3><td class="auto-style4"><h3>Trip Name:</h3></td></h3>
                <td>
                    <h3><asp:Label ID="lbGetTripName" runat="server"></asp:Label></h3>
                </td>
            </tr>
            <tr>
                <td class="auto-style4"><h3>Staff Number:</h3></td>
                <td>
                    <h3><asp:Label ID="lbGetStaffNo" runat="server"></asp:Label></h3>
                </td>
            </tr>
            <tr>
                <td class="auto-style4"><h3>Location</h3></td>
                <td>
                    <h3><asp:Label ID="lbGetLocation" runat="server"></asp:Label></h3>
                </td>
            </tr>
            <tr>
                <td class="auto-style4"><h3>Description</h3></td>
                <td>
                    <h3><asp:Label ID="lbGetDescription" runat="server"></asp:Label></h3>
                </td>
            </tr>
            <tr>
                <td class="auto-style4"><h3>Start Date:</h3></td>
                <td>
                    <h3><asp:Label ID="lbGetStartDate" runat="server"></asp:Label></h3>
                </td>
            </tr>
            <tr>
                <td class="auto-style4"><h3>End Date:</h3></td>
                <td>
                    <h3><asp:Label ID="lbGetEndDate" runat="server"></asp:Label></h3>
                </td>
            </tr>
            <tr>
                <td class="auto-style4"><h3>Total Cost</h3></td>
                <td>
                    <h3><asp:Label ID="lbGetTotalCost" runat="server"></asp:Label></h3>
                </td>
            </tr>
            <tr>
                <td class="auto-style4"><h3>Type Of Trip</h3></td>
                <td>
                    <h3><asp:Label ID="lbGetTypeOfTrip" runat="server"></asp:Label></h3>
                </td>
            </tr>
            <tr>
                <td class="auto-style4"><h3>Trip Summary</h3></td>
                <td>
                   <h3> <asp:Label ID="lbGetTripSummary" runat="server"></asp:Label></h3>
                </td>
            </tr>
            <tr>
                <td class="auto-style4"><h3>Trip Airline</h3></td>
                <td>
                    <h3><asp:Label ID="lbGetTripAirline" runat="server"></asp:Label></h3>
                </td>
            </tr>
            <tr>
                <td class="auto-style4"><h3>Trip Itinerary</h3></td>
                <td>
                    <h3><asp:Label ID="lbGetTripItinerary" runat="server"></asp:Label></h3>
                </td>
            </tr>
            <tr>
                <td class="auto-style2"><h3>Selection Critera</h3></td>
                <td class="auto-style3">
                    <h3><asp:Label ID="lbGetTripSelection" runat="server"></asp:Label></h3>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <asp:Image ID="lbGetImg" runat="server" width="300px"/>
            </tr>
            <tr>
                <td class="auto-style4">
                    <asp:Button ID="btnUpdate" CssClass="button" runat="server" OnClick="btnUpdate_Click" Text="Edit Information" />
                    <br />
                    <br />
                </td>
                <td>
                    <h3><asp:Label ID="lbId" runat="server" Visible="False"></asp:Label></h3>
                    
                </td>
            </tr>
        </table>
    </form>

</asp:Content>
