<%@ Page Title="" Language="C#" MasterPageFile="~/Views/master.Master" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="iTravel.Views.home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="/StyleSheets/home.css">
    <title>iTravel - Home</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div runat="server" id="homeForStudent" visible="false">

        <asp:Panel ID="pNotifyIntern" runat="server" Visible="false">
            <h1>Important Notification</h1>
            <p style="color:red;">You have been shortlisted for the Overseas Internship Programme you have applied for. Details for the interview are as stated below.</p>
            <hr/>
            <table class="auto-style2">
                <tr>
                    <td class="auto-style1">Interviewer : </td>
                    <td>
                        <asp:Label ID="lbStaffName" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">Interviewer Contact No. :</td>
                    <td>
                        <asp:Label ID="lbStaffHP" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">Meeting Date : </td>
                    <td>
                        <asp:Label ID="lbMeetDate" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">Meeting Time : </td>
                    <td>
                        <asp:Label ID="lbMeetTime" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">Location : </td>
                    <td>
                        <asp:Label ID="lbLocation" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">Additional Information : </td>
                    <td>
                        <asp:Label ID="lbAdditionalInfo" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <asp:Panel ID="pNotifyIntern2" runat="server" Visible="false">
            <h1>Important Notification</h1>
            <p><asp:Label ID="lbGratz" runat="server"></asp:Label></p>
        </asp:Panel>
    </div>

    <form runat="server" method="post">
        <asp:ScriptManager ID="ScriptManagerProfile" runat="server"></asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanelProfile" runat="server">
                <ContentTemplate>
                    <div runat="server" id="homeForStudentInTrip" visible="false">
        

                    <%--trips information maybe?--%>

                    <!-- Outing List Appear Here -->
                    <p class="outingHeader">In-Trip Outings</p>
                    <div runat="server" id="organizerEvent" class="organizerEvent container">
                        
                    </div>
                        <!-- AMMO -->
                    <div runat="server" id="ammoBtn" visible="false">
                        
                    </div>

                    <hr />
        
                    <!-- Trip Organizer -->
                    <p class="outingHeader">Trip Organizer</p>
                    <div id="createOrgSuccess" class="yayDiv" runat="server" visible="false">

                    </div>
                    <div id="createOrgFailed" class="errorDiv" runat="server" visible="false">

                    </div>

                    <div runat="server" ID="createOrganizer" class="createOrganizer container" visible="false">

                        <div class="form-group">
                            <p><b>Title:</b></p>
                            <asp:TextBox runat="server" ID="orgTitle" class="form-control" placeholder="Enter Title"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <p><b>Description:</b></p>
                            <asp:TextBox class="form-control inputBig" id="orgDesc" runat="server" placeholder="Enter Description" TextMode="MultiLine"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <p><b>Location:</b></p>
                            <asp:TextBox runat="server" ID="orgLocation" class="form-control" placeholder="Enter Location"></asp:TextBox>
                        </div>
                        <div class="form-group col-sm-6 noPaddingLeft">
                            <p><b>Date:</b></p>
                            <asp:TextBox runat="server" ID="orgDate" class="form-control" placeholder="Enter Date" TextMode="Date"></asp:TextBox>
                        </div>
                        <div class="form-group col-sm-6 noPaddingLeft">
                            <p><b>Time:</b></p>
                            <asp:TextBox runat="server" ID="orgTime" class="form-control" placeholder="Enter Time" TextMode="Time"></asp:TextBox>
                        </div>
                        
                    </div>

                    <!-- Button to Open Trip Organizer -->
                    <asp:Button class="openOrganizer" ID="openOrganizer" runat="server" text="Create Outings" OnClick="openOrganizer_Click" AutoPostBack="true"/>
                    
                    <!-- Button to Cancel or Create Trip Organizer -->
                    <asp:Button class="cancelOrganizerBtn" ID="cancelOrganizerBtn" runat="server" text="Cancel" OnClick="cancelOrganizer_Click" Visible="false"/>
                    <asp:Button class="createOrganizerBtn" ID="createOrganizerBtn" runat="server" text="Create" OnClick="createOrganizer_Click" Visible="false"/>

                    <hr />

                    <!-- Curfew Checker -->
                    <p class="curfewTitle">Curfew Check-In</p>
                    <p class="redText">Click on both eyelids to sleep!</p>
                    <p class="goodText" id="goodTextEye" runat="server" visible="false">Goodnight...</p>
                    <p class="badText" id="badTextEye" runat="server" visible="false">Something happen! Please try again!</p>
                    <div runat="server" id="curfewDiv" class="curfewDiv container">


                        <div class="eyeEye">
                            <div class="eyeShut">
                                <asp:button runat="server" ID="eyeLid" class="eyePupil" OnClick="eyeLid_Click"></asp:button>
                            </div>
                            <div class="eyeBall">

                            </div>
                        </div>

                        <div class="eyeEye2">
                            <div class="eyeShut2">
                                <asp:button runat="server" ID="eyeLid2" class="eyePupil2" OnClick="eyeLid2_Click"></asp:button>
                            </div>
                            <div class="eyeBall2">

                            </div>
                        </div>

                        
                    </div>
                
                </div>

                <div runat="server" id="homeForStaff" visible="false">
                    <div>
                        <a href="../Views/CreateTrip.aspx">
                        <div class="col-md-4 inTheShadow" style="background-color: #ffd8d8">
                            Create New Trip
                        </div>
                        </a>

                        <a href="../Views/createInternship.aspx">
                        <div class="col-md-4 inTheShadow" style="background-color: #cdcaff">
                            Create Internship
                        </div>
                        </a>

                        <a href="PEMViewSurveyResults.aspx">
                        <div class="col-md-4 inTheShadow" style="background-color: #e4c6ff">
                            PEM Survey Results
                        </div>
                        </a>

                        <a href="../Views/ViewTrip.aspx">
                        <div class="col-md-4 inTheShadow" style="background-color: #ffe7cb">
                            View Current Trips
                        </div>
                        </a>

                        <a href="../Views/staffViewInternSurvey.aspx">
                        <div class="col-md-4 inTheShadow" style="background-color: #d8ffdb">
                            View Intern Surveys
                        </div>
                        </a>

                        <a href="ViewPastTrips.aspx">
                        <div class="col-md-4 inTheShadow" style="background-color: #cdfbff">
                            View Past Trips
                        </div>
                        </a>

                        <br /><br /><br />
                    </div>
                </div>

                <div runat="server" id="homeForStaffInTrip" visible="false">

                    <!-- Curfew Check -->
                    <p class="outingHeader">Student List</p>

                    <table class="table studentListTable">
                        <thead class="thead-dark">
                            <tr>
                                <th>Admin No</th>
                                <th>Name</th>
                                <th>Mobile No.</th>
                                <th>Last Curfew Check-In</th>
                            </tr>
                        </thead>
                        <tbody runat="server" id="staffInTripTable">
                            <tr>
                                <td colspan="4" class="fullTableColspan">Table is empty</td>
                            </tr>
                        </tbody>
                    </table>

                    <!-- Write note to parent -->
                    <p class="notesHeader">Write Notes to Parent</p>

                    <div id="noteToParentYay" class="yayDiv" runat="server" visible="false">
                        
                    </div>
                    <div id="noteToParentErr" class="errorDiv" runat="server" visible="false">
                        Please check student Admin No is correct.
                    </div>
                    <div class="form-group">
                        <p><b>Admin Number of Student:</b></p>
                        <asp:TextBox runat="server" ID="tbAdminNo" class="form-control" placeholder="Enter Admin Number"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <p><b>Description:</b></p>
                        <asp:TextBox class="form-control inputBig" id="tbDesc" runat="server" placeholder="Enter Description" TextMode="MultiLine"></asp:TextBox>
                    </div>
                    
                    <asp:Button class="sendNotes" ID="sendNotesBtn" runat="server" text="Send Notes" OnClick="sendNotesBtn_click" AutoPostBack="true"/>

                </div>

            </ContentTemplate>
         </asp:UpdatePanel>
    </form>

    <div runat="server" id="homeForAdmin" visible="false">
        <h1>This will be ur conten </h1>
        <h1>Kaya</h1>
        <h1>This will be ur content</h1>
        <h1>This will be ur content</h1>
        <h1>This will be ur content</h1>
        <h1>This will be ur content</h1>
        <h1>This will be ur content</h1>
        <h1>This will be ur content</h1>
        <h1>This will be ur content</h1>
        <h1>This will be ur content</h1>
        <h1>This will be ur content</h1>
        <h1>This will be ur content</h1>
        <h1>This will be ur content</h1>
        <h1>This will be ur content</h1>
        <h1>This will be ur content</h1>
        <h1>This will be ur content</h1>
    </div>


    <!-- FOR PARENT --> 
    <div runat="server" id="homeForParent" class="container" visible="false">

        
        
    </div>

</asp:Content>
