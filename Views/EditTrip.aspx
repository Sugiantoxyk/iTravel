<%@ Page Title="" Language="C#" MasterPageFile="~/Views/master.Master" AutoEventWireup="true" CodeBehind="EditTrip.aspx.cs" Inherits="iTravel.Views.EditTrip" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 369px;
        }
        .auto-style3 {
            width: 369px;
            height: 23px;
        }
        .auto-style4 {
            height: 23px;
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
        #Button1{
            text-align: center;
        }
        .tbStyle{
            display: inline-block;
            -webkit-box-sizing: content-box;
            -moz-box-sizing: content-box;
            box-sizing: content-box;
            padding: 10px 20px;
            border: 2px solid rgba(124,121,121,0.66);
            -webkit-border-radius: 13px;
            border-radius: 13px;
            font: normal 16px/normal Arial, Helvetica, sans-serif;
            color: #000000
            -o-text-overflow: clip;
            text-overflow: clip;
            background: rgba(255,255,255,1);
            -webkit-box-shadow: 2px 2px 2px 0 rgba(0,0,0,0.2) inset;
            box-shadow: 2px 2px 2px 0 rgba(0,0,0,0.2) inset;
            text-shadow: 1px 1px 0 rgba(214,184,184,0.66) ;
            -webkit-transition: all 200ms cubic-bezier(0.42, 0, 0.58, 1);
            -moz-transition: all 200ms cubic-bezier(0.42, 0, 0.58, 1);
            -o-transition: all 200ms cubic-bezier(0.42, 0, 0.58, 1);
            transition: all 200ms cubic-bezier(0.42, 0, 0.58, 1);
        }
    
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
    <div>
    
        &nbsp;Edit a trip<br />
        <asp:Label ID="lbSucess" runat="server"></asp:Label>
        <asp:Label ID="lbMsg" runat="server"></asp:Label>
        <br />
        <table class="auto-style1">
            <tr>
                <td class="auto-style3">
                    <asp:Label ID="lbTripName"  width="200px" runat="server" Text="Trip Name:"></asp:Label>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Enter a Trip" ForeColor="Red" ControlToValidate="tbUpdTrip">*</asp:RequiredFieldValidator>
                </td>
                <td class="auto-style4">
                    <asp:TextBox ID="tbUpdTrip" cssClass="tbStyle" width="200px" runat="server"></asp:TextBox>
                    <br />
                    <br />
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="lbStaffNo"  width="200px" runat="server" Text="Enter Your Staff No:"></asp:Label>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="tbUpdStaff" ErrorMessage="Enter a Trip" ForeColor="Red">*</asp:RequiredFieldValidator>
                </td>
                <td>
                    <asp:TextBox ID="tbUpdStaff" cssClass="tbStyle" width="200px" runat="server"></asp:TextBox>
                    <br />
                    <br />
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="lbLocation"  width="200px" runat="server" Text="Location"></asp:Label>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="tbUpdLocation" ErrorMessage="Enter Location" ForeColor="Red">*</asp:RequiredFieldValidator>
                </td>
                <td>
                    <asp:TextBox ID="tbUpdLocation" cssClass="tbStyle" width="200px" runat="server"></asp:TextBox>
                    <br />
                    <br />
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="lbDescription"  width="200px" runat="server" Text="Description Of Country"></asp:Label>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="tbUpdDescription" ErrorMessage="Enter Description" ForeColor="Red">*</asp:RequiredFieldValidator>
                </td>
                <td>
                    <asp:TextBox ID="tbUpdDescription" cssClass="tbStyle" width="200px" runat="server" TextMode="MultiLine"></asp:TextBox>
                    
                    <br />
                    <br />
                    
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="lbTripImg"  width="200px" runat="server" Text="Trip IMG:"></asp:Label>
                </td>
                <td>
                    <asp:FileUpload id="FileUploadControl" runat="server" />
                    <br />
                    <asp:Label runat="server" id="StatusLabel" text="Upload status: " />
                    <br />
                    <br />
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="lbCost"  width="200px" runat="server" Text="Cost:"></asp:Label>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="Enter Cost" ForeColor="Red" ControlToValidate="tbUpdCost">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="tbUpdCost" ErrorMessage="Number must be &gt; than 0!" ForeColor="Red" ValidationExpression="^[1-9][0-9]*$">*</asp:RegularExpressionValidator>
                </td>
                <td>
                    <asp:TextBox ID="tbUpdCost" cssClass="tbStyle" width="200px" runat="server" TextMode="Number"></asp:TextBox>
                    <br />
                    <br />
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="lbStartDate" width="200px" runat="server" Text="Start Date:"></asp:Label>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="tbUpdStartDate" ErrorMessage="Enter a Date" ForeColor="Red">*</asp:RequiredFieldValidator>

                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="tbUpdStartDate" ErrorMessage="Date Cannot be Less than tor equal to oday!" ForeColor="Red" Operator="GreaterThan" Type="date" Display="Dynamic"  >*</asp:CompareValidator>

                </td>
                <td>
                    <asp:TextBox ID="tbUpdStartDate" cssClass="tbStyle" width="200px" runat="server" TextMode="Date"></asp:TextBox>

                    <br />
                    <br />

                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="lbEndDate"  width="200px" runat="server" Text="End Date:"></asp:Label>

                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="Date Not entered" ForeColor="Red" ControlToValidate="tbUpdEndDate">*</asp:RequiredFieldValidator>

                    <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToCompare="tbUpdStartDate" ControlToValidate="tbUpdEndDate" ErrorMessage="Date cannot be earlier than start date!" ForeColor="Red" Operator="GreaterThan" Type="date" Display="Dynamic">*</asp:CompareValidator>

                </td>
                <td>
                    <asp:TextBox ID="tbUpdEndDate" cssClass="tbStyle" width="200px" runat="server" TextMode="Date"></asp:TextBox>
                    <br />
                    <br />
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="lbTripSummary"  width="200px" runat="server" Text="Trip Summary"></asp:Label>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tbUpdTripSummary" ErrorMessage="Enter Trip Summary" ForeColor="Red">*</asp:RequiredFieldValidator>
                </td>
                <td>
                    <asp:TextBox ID="tbUpdTripSummary" cssClass="tbStyle" width="200px" runat="server"></asp:TextBox>
                    <br />
                    <br />
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="lbTripAirline"  width="200px" runat="server" Text="Airline"></asp:Label>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="tbUpdTripAirline" ErrorMessage="Enter Airline" ForeColor="Red">*</asp:RequiredFieldValidator>
                </td>
                <td>
                    <asp:TextBox ID="tbUpdTripAirline" cssClass="tbStyle" width="200px" runat="server"></asp:TextBox>
                    <br />
                    <br />
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="lbTripItinerary"  width="200px" runat="server" Text="Trip Itinerary"></asp:Label>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="tbUpdTripItinerary" ErrorMessage="Enter Trip Itinerary" ForeColor="Red">*</asp:RequiredFieldValidator>
                </td>
                <td>
                    <asp:TextBox ID="tbUpdTripItinerary" cssClass="tbStyle" width="200px" runat="server"></asp:TextBox>
                    <br />
                    <br />
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="lbTripSelection"  width="200px" runat="server" Text="Selction Criteria "></asp:Label>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="tbUpdTripSelection" ErrorMessage="Enter Trip Selection Criteria" ForeColor="Red">*</asp:RequiredFieldValidator>
                </td>
                <td>
                    <asp:TextBox ID="tbUpdTripSelection" cssClass="tbStyle" width="200px" runat="server" TextMode="MultiLine"></asp:TextBox>
                    <br />
                    <br />
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="lbType"  width="200px" runat="server" Text="Type of immersion program:"></asp:Label>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="tbUpdDdl" ErrorMessage="Choose a Program" ForeColor="Red">*</asp:RequiredFieldValidator>
                </td>
                <td>
                    <asp:DropDownList ID="tbUpdDdl" cssClass="tbStyle" width="200px" runat="server">
                        <asp:ListItem disabled>--Select Immersion Program--</asp:ListItem>
                        <asp:ListItem>Study Trip</asp:ListItem>
                        <asp:ListItem>Immersion</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
        </table>

        <br />
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" Width="696px" />

        <br />
        <asp:Button ID="btnUpdate" cssClass="button" width="200px" runat="server" OnClick="btnUpdate_Click" Text="Update" />

        <asp:Button ID="btnBack"  cssClass="button"  width="200px" runat="server" OnClick="btnBack_Click" Text="Back" CausesValidation="False" />

        <br />
        <br />

        </div>

    </form>
</asp:Content>

