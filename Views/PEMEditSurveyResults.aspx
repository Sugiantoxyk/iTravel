<%@ Page Title="" Language="C#" MasterPageFile="~/Views/master.Master" AutoEventWireup="true" CodeBehind="PEMEditSurveyResults.aspx.cs" Inherits="iTravel.Views.PEMEditSurveyResults" %>
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
                    

                    <hr />

                    <!-- Profile -->
                    <div class="row">
                        <div class="col-md-3 shiftLeft">
                           
                        </div>
                        <div class="col-md-8 col-md-offset-1">
                            <br />
                            <p class="inputName">Add PEM Note</p>
                            <br />
                            <asp:Textbox class="inputs disabled" ID="tbUpdTrip" runat="server" placeholder="Add a note for your student" autocomplete="off" ></asp:Textbox>
                            <br />
                            <br />
                            
                             <asp:Button class="editBtns" ID="editProfileBtn" runat="server" Text="Return" OnClick="btnBack_Click" />
                            <asp:Button class="cancelUpdateBtns" ID="cancelProfileBtn" runat="server" Text="Update" Visible="True" OnClick="btnUpdate_Click" />
                           
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
    <br /><br /><br /><br />
</asp:Content>
