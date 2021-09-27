<%@ Page Title="" Language="C#" MasterPageFile="~/Views/master.Master" AutoEventWireup="true" CodeBehind="DecisionSurveyResults.aspx.cs" Inherits="iTravel.Views.DecisionSurveyResults" %>
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
    </style>


  <link rel="stylesheet" href="../StyleSheets/profile.css">
    <title>iTravel - Survey Results</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form runat="server">
        <asp:ScriptManager ID="ScriptManagerProfile" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanelProfile" runat="server">
            <ContentTemplate>

                <!-- Main Profile Container -->
                <div class="container-fluid mainProfileCont well">
         <asp:Label ID="lbSucess" runat="server" Text="Label" Visible="false"></asp:Label></p>
                    
                    <p id="profileMainName" class="profileMainName" runat="server">
                        <asp:Label ID="Label25" runat="server" Text="Label"></asp:Label></p>

                </div>

                <!-- Profile Tab -->
                <div class="container myProfileCont">

                    <!-- Trip Status -->
                    <div class="row">
                        <asp:Label class="inputs disabled" ID="Label26" runat="server" placeholder="Name" autocomplete="off" disabled="disabled" Visible="false"></asp:Label>
                            <br />
                        <asp:Label class="inputs disabled" ID="Label27" runat="server" placeholder="Name" autocomplete="off" disabled="disabled" Visible="false"></asp:Label>
                            <br />

                        </div>
                    </div>

                    <hr />

                    <!-- Profile -->
                    <div class="row">
                        <div class="col-md-3 shiftLeft">
                            <h4>A-D</h4>
                        </div>
                        <div class="col-md-8 col-md-offset-1">
                            <br />
                            <p class="inputName">Admin Number</p>
                            <asp:Label class="inputs disabled" ID="Label1" runat="server" placeholder="Name" autocomplete="off" disabled="disabled"></asp:Label>
                            <br />
                            <br />
                             <p class="inputName">Allergies</p>
                            <asp:Label class="inputs disabled" ID="Label2" runat="server" placeholder="Name" autocomplete="off" disabled="disabled"></asp:Label>
                            <br />
                            <br />
                              <p class="inputName">Address</p>
                            <asp:Label class="inputs disabled" ID="Label3" runat="server" placeholder="Name" autocomplete="off" disabled="disabled"></asp:Label>
                            <br />
                            <br />
                              <p class="inputName">Buddy</p>
                            <asp:Label class="inputs disabled" ID="Label4" runat="server" placeholder="Name" autocomplete="off" disabled="disabled"></asp:Label>
                            <br />
                            <br />
                              <p class="inputName">CCA</p>
                            <asp:Label class="inputs disabled" ID="Label5" runat="server" placeholder="Name" autocomplete="off" disabled="disabled"></asp:Label>
                            <br />
                            <br />
                              <p class="inputName">Citizenship</p>
                            <asp:Label class="inputs disabled" ID="Label6" runat="server" placeholder="Name" autocomplete="off" disabled="disabled"></asp:Label>
                            <br />
                            <br />
                              <p class="inputName">Contact</p>
                            <asp:Label class="inputs disabled" ID="Label7" runat="server" placeholder="Name" autocomplete="off" disabled="disabled"></asp:Label>
                            <br />
                            <br />
                              <p class="inputName">Diploma</p>
                            <asp:Label class="inputs disabled" ID="Label8" runat="server" placeholder="Name" autocomplete="off" disabled="disabled"></asp:Label>
                            <br />
                            <br />
                            <br />

                            

                        </div>
                    </div>

                    <hr />

                    <!-- Personal Information -->
                    <div class="row">
                        <div class="col-md-3 shiftLeft">
                            <h4>D-W</h4>
                        </div>
                        <div class="col-md-8 col-md-offset-1">
                            <br />                   
                             <p class="inputName">Date Of Birth</p>
                            <asp:Label class="inputs disabled" ID="Label9" runat="server" placeholder="Name" autocomplete="off" disabled="disabled"></asp:Label>
                            <br />
                            <br />     
                              <p class="inputName">FAS Applied </p>
                            <asp:Label class="inputs disabled" ID="Label10" runat="server" placeholder="Name" autocomplete="off" disabled="disabled"></asp:Label>
                            <br />
                            <br />
                             <p class="inputName">FAS History</p>
                            <asp:Label class="inputs disabled" ID="Label11" runat="server" placeholder="Name" autocomplete="off" disabled="disabled"></asp:Label>
                            <br />
                            <br />
                              <p class="inputName">Full Name</p>
                            <asp:Label class="inputs disabled" ID="Label12" runat="server" placeholder="Name" autocomplete="off" disabled="disabled"></asp:Label>
                            <br />
                            <br />
                             <p class="inputName">Gender</p>
                            <asp:Label class="inputs disabled" ID="Label13" runat="server" placeholder="Name" autocomplete="off" disabled="disabled"></asp:Label>
                            <br />
                            <br />
                            <p class="inputName">GPA</p>
                            <asp:Label class="inputs disabled" ID="Label14" runat="server" placeholder="Name" autocomplete="off" disabled="disabled"></asp:Label>
                            <br />
                            <br />
                           
                              <p class="inputName">Leadership</p>
                            <asp:Label class="inputs disabled" ID="Label15" runat="server" placeholder="Name" autocomplete="off" disabled="disabled"></asp:Label>
                            <br />
                            <br />
                              <p class="inputName">Medical Condition</p>
                            <asp:Label class="inputs disabled" ID="Label16" runat="server" placeholder="Name" autocomplete="off" disabled="disabled"></asp:Label>
                            <br />
                            <br />
                              <p class="inputName">Medication</p>
                            <asp:Label class="inputs disabled" ID="Label17" runat="server" placeholder="Name" autocomplete="off" disabled="disabled"></asp:Label>
                            <br />
                            <br />
                              <p class="inputName">Offences Commited</p>
                            <asp:Label class="inputs disabled" ID="Label18" runat="server" placeholder="Name" autocomplete="off" disabled="disabled"></asp:Label>
                            <br />
                            <br />
                              <p class="inputName">Passport Expiry</p>
                            <asp:Label class="inputs disabled" ID="Label19" runat="server" placeholder="Name" autocomplete="off" disabled="disabled"></asp:Label>
                            <br />
                            <br />
                              <p class="inputName">Passport Number</p>
                            <asp:Label class="inputs disabled" ID="Label20" runat="server" placeholder="Name" autocomplete="off" disabled="disabled"></asp:Label>
                            <br />
                            <br />
                              <p class="inputName">PEM Group</p>
                            <asp:Label class="inputs disabled" ID="Label21" runat="server" placeholder="Name" autocomplete="off" disabled="disabled"></asp:Label>
                            <br />
                            <br />
                              <p class="inputName">PEM Note</p>
                            <asp:Label class="inputs disabled" ID="Label22" runat="server" placeholder="Name" autocomplete="off" disabled="disabled"></asp:Label>
                            <br />
                            <br />
                              
                          
                            </br>
                             <asp:Button class="editBtns" ID="editProfileBtn" runat="server" Text="Return" OnClick="btnBack_Click" />
                            <asp:Button class="cancelUpdateBtns" ID="cancelProfileBtn" runat="server" Text="Accept" Visible="True" OnClick="btnUpdate_Click" />
                            <asp:Button class="cancelUpdateBtns" ID="updateProfileBtn" runat="server" Text="Decline" Visible="True" OnClick="btnDecline_Click" />
                        </div>
                    </div>

                    <hr />

                    <!-- Trip History -->
                    
                    <hr />

                    <!-- Change Password -->
                    
                </div>

                <hr />

            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</asp:Content>

