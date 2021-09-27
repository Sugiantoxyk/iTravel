<%@ Page Title="" Language="C#" MasterPageFile="~/Views/master.Master" AutoEventWireup="true" CodeBehind="CreateTrip.aspx.cs" Inherits="iTravel.Views.CreateTrip" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 99%;
            height: 410px;
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
    
        &nbsp;Create a trip<br />
        <asp:Label ID="lbMsg" runat="server"></asp:Label>
        <br />
        <table class="auto-style1">
            <tr>
                <td >
                    <asp:Label ID="lbTripName"  width="200px" runat="server" Text="Trip Name:" Height="20px"></asp:Label>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please Enter a Trip Name" ControlToValidate="tbTrip" ForeColor="Red">*</asp:RequiredFieldValidator>
                </td>
                <td >
                    <asp:TextBox ID="tbTrip"  cssClass="tbStyle" width="200px" runat="server"></asp:TextBox>
                    <br />
                    <br />
                </td>
                &nbsp;
            </tr>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
            <tr>
                <td >
                    <asp:Label ID="lbStaffNo"  width="200px" runat="server" Text="Enter Your Staff No:"></asp:Label>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please Enter a valid Staff No" ControlToValidate="tbStaff" ForeColor="Red">*</asp:RequiredFieldValidator>

                </td>
                <td>
                    <asp:TextBox ID="tbStaff" cssClass="tbStyle" width="200px"  runat="server"></asp:TextBox>
                    <br />
                    <br />
                </td>
            </tr>
            <tr>
                <td >
                    <asp:Label ID="lbLocation"  width="200px"  runat="server" Text="Location"></asp:Label>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Enter a Location" ControlToValidate="tbLocation" ForeColor="Red">*</asp:RequiredFieldValidator>

                </td>
                <td>
                    <asp:TextBox ID="tbLocation" cssClass="tbStyle" width="200px"  runat="server"></asp:TextBox>
                    <br />
                    <br />
                </td>
            </tr>
            <tr>
                <td >
                    <asp:Label ID="lbDescription"  width="200px"  runat="server" Text="Description Of Country"></asp:Label>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Enter a description" ControlToValidate="tbDescription" ForeColor="Red">*</asp:RequiredFieldValidator>

                </td>
                <td>
                    <asp:TextBox ID="tbDescription" cssClass="tbStyle" width="200px"  runat="server" TextMode="MultiLine"></asp:TextBox>
                    
                    <br />
                    <br />
                    
                </td>
            </tr>
            <tr>
                <td >
                    <asp:Label ID="lbTripImg"  width="200px"  runat="server" Text="Trip IMG:"></asp:Label>
                </td>
                <td>
                   <asp:FileUpload id="FileUploadControl" runat="server" />
                    
                    <br />
                    <asp:Label runat="server" id="StatusLabel" text="Upload status: " />
                    <br />
                </td>
            </tr>
            <tr>
                <td >
                    <asp:Label ID="lbCost"  width="200px" runat="server" Text="Cost:"></asp:Label>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Enter Cost" ControlToValidate="tbCost" ForeColor="Red">*</asp:RequiredFieldValidator>

                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="tbCost" ErrorMessage="Number must be &gt; than 0!" ForeColor="Red" ValidationExpression="^[1-9][0-9]*$">*</asp:RegularExpressionValidator>

                </td>
                <td>
                    <asp:TextBox ID="tbCost" cssClass="tbStyle" width="200px"  runat="server" TextMode="Number"></asp:TextBox>
                    <br />
                    <br />
                </td>
            </tr>
            <tr>
                <td >
                    <asp:Label ID="lbStartDate"  width="200px"  runat="server" Text="Start Date:"></asp:Label>

                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="tbStartDate" ErrorMessage="Date Cannot be Less than tor equal to oday!" ForeColor="Red" Operator="GreaterThan" Type="date" Display="Dynamic"  >*</asp:CompareValidator>

                    <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="tbStartDate" ErrorMessage="Enter Date" ForeColor="Red">*</asp:RequiredFieldValidator>

                </td>
                <td>
                    <asp:TextBox ID="tbStartDate"  cssClass="tbStyle" width="200px" runat="server" TextMode="Date"></asp:TextBox>
                    <br />
                    <br />
                </td>
            </tr>
            <tr>
                <td >
                   <asp:Label ID="lbEndDate"  width="200px"  runat="server" Text="End Date:"></asp:Label>

                    <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToCompare="tbStartDate" ControlToValidate="tbEndDate" ErrorMessage="Date cannot be earlier than start date!" ForeColor="Red" Operator="GreaterThan" Type="date" Display="Dynamic">*</asp:CompareValidator>

                    <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="tbEndDate" ErrorMessage="Enter Date" ForeColor="Red">*</asp:RequiredFieldValidator>

                </td>
                <td>
                    <asp:TextBox ID="tbEndDate" cssClass="tbStyle" width="200px"  runat="server" TextMode="Date"></asp:TextBox>
                    <br />
                    <br />
                </td>
            </tr>
            <tr>
                <td >
                    <asp:Label ID="lbTripSummary"  width="200px"  runat="server" Text="Trip Summary"></asp:Label>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="Enter a Summary" ControlToValidate="tbTripSummary" ForeColor="Red">*</asp:RequiredFieldValidator>

                </td>
                <td>
                    <asp:TextBox ID="tbTripSummary" cssClass="tbStyle" width="200px"  runat="server" TextMode="MultiLine"></asp:TextBox>
                   
                    <br />
                    <br />
                   
                </td>
            <tr>
                <td >
                    <asp:Label ID="lbTripAirline" width="200px"  runat="server" Text="Airline"></asp:Label>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="Enter a Airline" ControlToValidate="tbTripAirline" ForeColor="Red">*</asp:RequiredFieldValidator>

                </td>
                <td>
                    <asp:TextBox ID="tbTripAirline" cssClass="tbStyle" width="200px"  runat="server"></asp:TextBox>
                    <br />
                    <br />
                </td>
            </tr>
                <tr>
                <td >
                    <asp:Label ID="lbTripItinerary"  width="200px"  runat="server" Text="Itinerary"></asp:Label>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="Enter a Itinerary" ControlToValidate="tbTripItinerary" ForeColor="Red">*</asp:RequiredFieldValidator>

                </td>
                <td>
                    <asp:TextBox ID="tbTripItinerary" cssClass="tbStyle" width="200px"  runat="server" TextMode="MultiLine"></asp:TextBox>
                    <br />
                    <br />
                </td>
            </tr>
                <tr>
                <td >
                    <asp:Label ID="lbTripSelection"  width="200px"  runat="server" Text="Selection Criteria"></asp:Label>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ErrorMessage="Enter criteria" ControlToValidate="tbTripSelection" ForeColor="Red">*</asp:RequiredFieldValidator>

                </td>
                <td>
                    <asp:TextBox ID="tbTripSelection" cssClass="tbStyle" width="200px"  runat="server"></asp:TextBox>
                    <br />
                    <br />
                </td>
            </tr>
                <td >
                    <asp:Label ID="lbType" width="200px"  runat="server" Text="Type of immersion program:"></asp:Label>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="Choose a Program" ControlToValidate="tbDdl" ForeColor="Red">*</asp:RequiredFieldValidator>

                </td>
                <td>
                    <asp:DropDownList ID="tbDdl" cssClass="tbStyle" width="200px" runat="server">
                        <asp:ListItem Selected="True">--Select Immersion Program--</asp:ListItem>
                        <asp:ListItem>Study Trip</asp:ListItem>
                        <asp:ListItem>Immersion</asp:ListItem>
                    </asp:DropDownList>
        <asp:Label ID="lbImgName" runat="server"></asp:Label>
                    <br />
                </td>
            </tr>
        </table>

        <asp:ValidationSummary ID="ValidationSummary1" width="365px" runat="server" ForeColor="Red" />

        <br />
        <asp:Button ID="btnSubmit" cssClass="button" Width="200px" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
        <br />
        <br />
        <br />

        </div>

    </form>
</asp:Content>


