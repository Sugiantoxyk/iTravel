<%@ Page Title="" Language="C#" MasterPageFile="~/Views/master.Master" AutoEventWireup="true" CodeBehind="studentViewTrip.aspx.cs" Inherits="iTravel.Views.StudentViewTrip" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">  
    <form id="form1" runat="server">
        <meta charset="UTF-8">
 
     <meta http-equiv="X-UA-Compatible" content="IE=edge">

  <link rel="shortcut icon" href="assets/images/logo4.png" type="image/x-icon">
  <meta name="description" content="">
  <title>Home</title>
  <link rel="stylesheet" href="assets/tether/tether.min.css">
  
  <link rel="stylesheet" href="assets/bootstrap/css/bootstrap-grid.min.css">
 
  <link rel="stylesheet" href="assets/theme/css/style.css">
  <link rel="stylesheet" href="assets/mobirise/css/mbr-additional.css" type="text/css">
  <section class="header14 cid-rfeYS8N9HO mbr-fullscreen" id="header14-5">

    

    

    <div class="container">
        <div class="media-container-row">

            <div class="mbr-figure" style="width: 155%;">
                &nbsp;<asp:Image ID="lbImg" runat="server" />
                <asp:Label ID="lbGetImg" runat="server" Text="Label" Visible="False"></asp:Label>
            </div>

            <div class="media-content">
                <h1 class="mbr-section-title pb-3 align-left mbr-white mbr-fonts-style display-1"> <asp:Label ID="Labelname" runat="server" Text="Label" Visible="true"></asp:Label></h1>
                
                <div class="mbr-section-text  pb-3 ">
                    <p class="mbr-text align-left mbr-white mbr-fonts-style display-5">Start Date: <asp:Label ID="LbStartDate" runat="server" Text="Label"></asp:Label>
                        <br>End Date: <asp:Label ID="LbEndDate" runat="server" Text="Label"></asp:Label>
                        <br>Cost:&nbsp;$<asp:Label ID="LbCost" runat="server" Text="Label"></asp:Label>
                        <br>Location: &nbsp;<asp:Label ID="LbLocation" runat="server" Text="Label"></asp:Label>
                        <br>Description: <asp:Label ID="LbDesc" runat="server" Text="Label"></asp:Label>
                         <asp:Label ID="Lbtrip" runat="server" Text="Label" Visible="false"></asp:Label>
                        <asp:Label ID="Lbtripname" runat="server" Text="Label" Visible="false"></asp:Label>
                        <asp:Label ID="Lbtriptype" runat="server" Text="Label" Visible="false"></asp:Label>
                        <br><br><br><br>&nbsp;</p>
                </div>

                <div class="media-container-column" data-form-type="formoid">
                    <div data-form-alert="" hidden="">Thanks for filling out the form!</div>
                        <input type="hidden" value="4jZYXtUEmWt+QANjOvzqV1EwT5YviQRosNvv7QQJw4Xe2YJIbg4yFjet2EBKZH7IEwwDtUh1hNI0Q+znaohVXFRxl4C/Og9ZhgCsjuKHH1PPK5ueu8WpF2YQiCqzJqtO" data-form-email="true">
                        
                        <div class="buttons-wrap">
                            <asp:Button class="btn btn-primary display-4" ID="surveyBtn" runat="server" Text="Survey Submission" Visible="True" OnClick="surveyBtn_Click" />
                        </div>
                </div>
            </div>
        </div>
    </div>
</section>


  <section class="engine"><a href="https://mobirise.info/v">free html templates</a></section><script src="assets/web/assets/jquery/jquery.min.js"></script>
  <script src="assets/popper/popper.min.js"></script>
  <script src="assets/tether/tether.min.js"></script>
  <script src="assets/bootstrap/js/bootstrap.min.js"></script>
  <script src="assets/smoothscroll/smooth-scroll.js"></script>
  <script src="assets/theme/js/script.js"></script>
  <script src="assets/formoid/formoid.min.js"></script>
  
    </form>
</asp:Content>
