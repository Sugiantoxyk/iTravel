<%@ Page Title="" Language="C#" MasterPageFile="~/Views/master.Master" AutoEventWireup="true" CodeBehind="profile.aspx.cs" Inherits="iTravel.Views.profile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="../StyleSheets/profile.css">
    <title>iTravel - Profile</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form runat="server">
        <asp:ScriptManager ID="ScriptManagerProfile" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanelProfile" runat="server">
            <ContentTemplate>

                <!-- Main Profile Container -->
                <div class="container-fluid mainProfileCont well">
        
                    <p id="profileMainName" class="profileMainName" runat="server">This is my name</p>

                </div>

                <!-- Profile Tab -->
                <div class="container myProfileCont">

                    <!-- Trip Status -->
                    <div class="row" id="tripStatusDiv" runat="server">
                        <div class="col-md-3 shiftLeft">
                            <h4>Trip Status</h4>
                        </div>
                        <div class="col-md-8 col-md-offset-1">
                            <br />
                            <div>
                                <p runat="server" id="statusText" class="statusText">Not registered</p>

                                <table id="statusTable">
                                    <tr>
                                        <td runat="server" id="status1" BgColor="Red"></td>
                                        <td runat="server" id="status2"></td>
                                        <td runat="server" id="status3"></td>
                                        <td runat="server" id="status4"></td>
                                        <td runat="server" id="status5"></td>
                                        <td runat="server" id="status6"></td>
                                    </tr>
                                </table>

                                <br />
                                <br />

                                <a href="studyTrips.aspx" runat="server" id="statusBtn" class="statusBtn">View Trips</a>
                            </div>

                        </div>
                    </div>

                    <hr runat="server" id="hello1"/>

                    <!-- Profile -->
                    <div class="row">
                        <div class="col-md-3 shiftLeft">
                            <h4>Profile</h4>
                        </div>
                        <div class="col-md-8 col-md-offset-1">
                            <br />
                            <p class="inputName">Full Name</p>
                            <asp:TextBox class="inputs disabled" ID="profileName" runat="server" placeholder="Name" autocomplete="off" disabled="disabled"></asp:TextBox>

                            <p class="inputName">Gender</p>
                            <asp:TextBox class="inputs disabled" ID="profileGender" runat="server" placeholder="Gender" autocomplete="off" disabled="disabled"></asp:TextBox>

                            <p class="inputName">Date of Birth</p>
                            <asp:TextBox class="inputs disabled" ID="profileDOB" runat="server" TextMode="Date" autocomplete="off" disabled="disabled"></asp:TextBox>

                            <p class="inputName">Nationality</p>
                            <asp:TextBox class="inputs disabled" ID="profileNationality" runat="server" placeholder="Nationality" autocomplete="off" disabled="disabled"></asp:TextBox>

                            <p class="inputName">Course</p>
                            <asp:TextBox class="inputs disabled" ID="profileCourse" runat="server" placeholder="Course" autocomplete="off" disabled="disabled"></asp:TextBox>

                            <p class="inputName">PEM Group</p>
                            <asp:TextBox class="inputs disabled" ID="profilePEMGrp" runat="server" placeholder="IT1705" autocomplete="off" disabled="disabled"></asp:TextBox>

                            <p class="inputName">Mobile Number</p>
                            <asp:TextBox class="inputs disabled" ID="profileMobile" runat="server" TextMode="Phone" placeholder="91234567" autocomplete="off" disabled="disabled"></asp:TextBox>
                
                            <p class="inputName">Bio</p>
                            <asp:TextBox class="inputsBig disabled" ID="profileBio" runat="server" placeholder="Bio" TextMode="MultiLine" autocomplete="off" disabled="disabled"></asp:TextBox>
                
                            <br />

                            <asp:Button class="editBtns" ID="editProfileBtn" runat="server" Text="Edit" OnClick="editProfileBtn_Click" />
                            <asp:Button class="cancelUpdateBtns" ID="cancelProfileBtn" runat="server" Text="Cancel" Visible="False" OnClick="cancelProfileBtn_Click" />
                            <asp:Button class="cancelUpdateBtns" ID="updateProfileBtn" runat="server" Text="Update" Visible="False" OnClick="updateProfileBtn_Click" />

                        </div>
                    </div>

                    <hr runat="server" id="hello2"/>

                    <!-- Personal Information -->
                    <div class="row" id="personalInfoDiv" runat="server">
                        <div class="col-md-3 shiftLeft">
                            <h4>Personal Information</h4>
                        </div>
                        <div class="col-md-8 col-md-offset-1">
                            <br />                   
                            <p class="inputName">Admin Number</p>
                            <asp:TextBox class="inputs disabled" ID="profileAdminNo" runat="server" placeholder="Admin Number" autocomplete="off" disabled="disabled"></asp:TextBox>
                                     
                            <p class="inputName">Email</p>
                            <asp:TextBox class="inputs disabled" ID="personalEmail" runat="server" placeholder="Email" autocomplete="off" disabled="disabled" TextMode="Email"></asp:TextBox>

                            <p class="inputName">GPA</p>
                            <asp:TextBox class="inputs disabled" ID="personalGPA" runat="server" placeholder="GPA" autocomplete="off" disabled="disabled"></asp:TextBox>

                            <p class="inputName">IC Number</p>
                            <asp:TextBox class="inputs disabled" ID="personalIC" runat="server" placeholder="IC Number" autocomplete="off" disabled="disabled"></asp:TextBox>

                            <p class="inputName">Passport Number</p>
                            <asp:TextBox class="inputs disabled" ID="personalPassNum" runat="server" placeholder="Passport Number" autocomplete="off" disabled="disabled"></asp:TextBox>

                            <p class="inputName">Passport Expiry Date</p>
                            <asp:TextBox class="inputs disabled" ID="PersonalPassExp" runat="server" TextMode="Date" autocomplete="off" disabled="disabled"></asp:TextBox>

                            <br />

                            <asp:Button class="editBtns" ID="editPersonalBtn" runat="server" Text="Edit" OnClick="editPersonalBtn_Click" />
                            <asp:Button class="cancelUpdateBtns" ID="cancelPersonalBtn" runat="server" Text="Cancel" Visible="False" OnClick="cancelPersonalBtn_Click" />
                            <asp:Button class="cancelUpdateBtns" ID="updatePersonalBtn" runat="server" Text="Update" Visible="False" OnClick="updatePersonalBtn_Click" />

                        </div>
                    </div>

                    <hr />

                    <!-- Trip History -->
                    <div class="row">
                        <div class="col-md-3 shiftLeft">
                            <h4>Trip History</h4>
                        </div>
                        <div class="col-md-8 col-md-offset-1" runat="server" id="historyInfo">
                            
                        </div>
                    </div>

                    <hr runat="server" id="hello3"/>

                    <!-- Change Password -->
                    <div class="row" id="changePassDiv" runat="server">
                        <div class="col-md-3 shiftLeft">
                            <h4>My Password</h4>
                        </div>
                        <div class="col-md-8 col-md-offset-1">
                            <br />

                            <div id="changePasswordCont" runat="server" visible="false">
                                <div id="changePassSuccess" class="yayDiv" runat="server" hidden="hidden">

                                </div>
                                <div id="changePassError1" class="errorDiv" runat="server" hidden="hidden">

                                </div>
                                <p class="inputName">Current Password</p>
                                <asp:TextBox class="changePasswordInputs" ID="currentPasswordInput" runat="server" placeholder="enter current password" autocomplete="off" TextMode="Password"></asp:TextBox>
                                
                                <hr />

                                <div id="changePassError2" class="errorDiv" runat="server" hidden="hidden">

                                </div>
                                <p class="inputName">New Password</p>
                                <asp:TextBox class="changePasswordInputs" ID="newPasswordInput" runat="server" placeholder="enter new password" autocomplete="off" TextMode="Password"></asp:TextBox>
                                <p class="inputName">Confirm New Password</p>
                                <asp:TextBox class="changePasswordInputs" ID="confirmNewPasswordInput" runat="server" placeholder="enter new password again" autocomplete="off" TextMode="Password"></asp:TextBox>
                                
                                <br />
                                
                                <asp:Button class="cancelUpdateBtns" ID="cancelPasswordBtn" runat="server" Text="Cancel" OnClick="cancelPasswordBtn_Click"/>
                                <asp:Button class="cancelUpdateBtns" ID="updatePasswordBtn" runat="server" Text="Change Password" OnClick="updatePasswordBtn_Click" />

                            </div>

                            <asp:Button class="changePasswordBtn" ID="changePasswordBtn" runat="server" text="Change Password" OnClick="changePasswordBtn_Click"/>
                        </div>
                    </div>

                </div>

                <hr />

            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</asp:Content>
