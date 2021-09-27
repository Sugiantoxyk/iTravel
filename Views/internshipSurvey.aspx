<%@ Page Title="" Language="C#" MasterPageFile="~/Views/master.Master" AutoEventWireup="true" CodeBehind="internshipSurvey.aspx.cs" Inherits="iTravel.Views.internshipSurvey" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>iTravel - Internship Survey</title>
    <link href="../StyleSheets/internshipSurvey.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server" method="post" class="wholeSector">
        <h1><asp:Label ID="lbTitle" runat="server" Text="Label"></asp:Label> Internship Survey</h1>
        <h4 style="color:red">You may only submit this survey once. Any mispelling or mistyping of particulars will not be accounted for.</h4>
        <br>
        <div>
            <div class="col-md-6">
            <asp:TextBox ID="tbIntId" runat="server" Visible="false"></asp:TextBox>
                <asp:Button ID="btnAutoFill" runat="server" Text="AutoFill" class="btn btn-default" OnClick="btnAutoFill_Click" style="height: 37px" CausesValidation="False"/>
                <br/>
            <label>
            <h3>Diploma</h3>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please choose a Diploma" ControlToValidate="ddlDiploma" Text="*"></asp:RequiredFieldValidator>
                <asp:DropDownList ID="ddlDiploma" width="115px" class="form-control" runat="server">
                <asp:ListItem disabled Selected="True">--Select--</asp:ListItem>
                <asp:ListItem>DBI</asp:ListItem>
                <asp:ListItem>DBT</asp:ListItem>
                <asp:ListItem>DEI</asp:ListItem>
                <asp:ListItem>DCS</asp:ListItem>
                <asp:ListItem>DIT</asp:ListItem>
                <asp:ListItem>DSF</asp:ListItem>
                <asp:ListItem>DFI</asp:ListItem>
                <asp:ListItem>DIS</asp:ListItem>
            </asp:DropDownList>
            </label>
            <br />
            <br />
            <label>
            <h3>PEM Group<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please enter a PEMGroup" ControlToValidate="tbPEMGroup" Text="*" ForeColor="Red"></asp:RequiredFieldValidator></h3>
            <asp:TextBox ID="tbPEMGroup" class="form-control" width="200px" runat="server"></asp:TextBox>
            </label>
            <br />
            <label>
            <h3>Admin Number<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Please enter an Admin Number" ControlToValidate="tbAdminNo" Text="*" ForeColor="Red"></asp:RequiredFieldValidator></h3>
            <asp:TextBox ID="tbAdminNo" class="form-control" width="200px" runat="server"></asp:TextBox>
            </label>
            <br />
            <label>
            <h3>Full Name<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Please enter your full name." ControlToValidate="tbFullName" Text="*" ForeColor="Red"></asp:RequiredFieldValidator></h3>
            <span class="details">Your name spelled exactly as in your Passport</span><br />
            <asp:TextBox ID="tbFullName" class="form-control" width="400px" runat="server"></asp:TextBox>
            </label>
            <br />
            <label>
            <h3>Gender</h3>
            <asp:RadioButtonList ID="rblGender" runat="server">
                <asp:ListItem Value="M">&nbsp; Male</asp:ListItem>
                <asp:ListItem Value="F">&nbsp; Female</asp:ListItem>
            </asp:RadioButtonList>
            </label>
            <br />
            <label>
            <h3>Date of Birth<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Please enter your date of birth" ControlToValidate="tbDOB" Text="*" ForeColor="#FF3300"></asp:RequiredFieldValidator></h3>
            <asp:TextBox ID="tbDOB" class="form-control" width="200px" runat="server" TextMode="Date"></asp:TextBox>
            </label>
            <br />
            <label>
            <h3>Mobile Contact Number<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Please enter your contact number" ControlToValidate="tbContact" Text="*" ForeColor="Red"></asp:RequiredFieldValidator></h3>
            <asp:TextBox ID="tbContact" type="phone" class="form-control" width="200px" runat="server"></asp:TextBox>
            </label>
            <br />
            <label>
            <h3>Address<asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="Please enter your address" ControlToValidate="tbAddress" Text="*" ForeColor="Red"></asp:RequiredFieldValidator></h3>
            <span class="details">Your residential address in Singapore</span><br />
            <asp:TextBox ID="tbAddress" class="form-control" width="400px" runat="server"></asp:TextBox>
            </label>
            <br />
            <label>
            <h3>Citizenship</h3>
            <asp:DropDownList ID="ddlCitizenship" class="form-control" width="200px" runat="server">
                <asp:ListItem disabled Selected="True" Value="">--Select--</asp:ListItem>
                <asp:ListItem Value="Singapore">Singapore</asp:ListItem>
                <asp:ListItem Value="Permanent Resident">Permanent Resident</asp:ListItem>
                <asp:ListItem Value="Malaysia">Malaysia</asp:ListItem>
                <asp:ListItem Value="Indonesia">Indonesia</asp:ListItem>
                <asp:ListItem Value="China">China</asp:ListItem>
                <asp:ListItem Value="India">India</asp:ListItem>
                <asp:ListItem>Other</asp:ListItem>
            </asp:DropDownList>
            </label>
            <br />
            <label>
            <h3>Passport Number<asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="Pleaser enter your passport no." ControlToValidate="tbPassportNo" Text="*" ForeColor="Red"></asp:RequiredFieldValidator></h3>
            <span class="details">Your passport must have a validity of at least 6 months from date of departure, leave empty if you do not have a passport or your passport has expired.</span><br />
            <asp:TextBox ID="tbPassportNo" class="form-control" width="200px" runat="server"></asp:TextBox>
            </label>
            <br />
            <label>
            <h3>Passport Expiry Date<asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="Please enter your passport expiry date" ControlToValidate="tbPassportExp" Text="*" ForeColor="Red"></asp:RequiredFieldValidator></h3>
            <asp:TextBox ID="tbPassportExp" class="form-control" width="200px" runat="server" TextMode="Date"></asp:TextBox>
            </label>
            <br />
            <label>
            <h3>Willing to be on wait list?</h3>
            <span class="details">In the event of over subscription and you are not selected, are you willing to be on wait list?</span><br />
            <asp:RadioButtonList ID="rblWaitList" runat="server">
                <asp:ListItem>&nbsp; Yes</asp:ListItem>
                <asp:ListItem>&nbsp; No</asp:ListItem>
            </asp:RadioButtonList>
            </label>
            <br />
            <label>
            <h3>GPA<asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="Please enter your GPA" ControlToValidate="tbGPA" Text="*" ForeColor="Red"></asp:RequiredFieldValidator></h3>
            <asp:TextBox ID="tbGPA" class="form-control" width="100px" runat="server"></asp:TextBox>
            </label>
            <br />
            <label>
            <h3>CCA @ NYP</h3>
            <span class="details">List the CCA you have participated in NYP. Do not enter anything if you do not participate in any CCA.</span><br />

            <asp:TextBox ID="tbCCA" class="form-control" width="300px" runat="server"></asp:TextBox>
            </label><br /><br /><br />
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" />
                </div>
                <div class="col-md-6 rightSector">
            <br />
            <label>
            <h3>Leader @ NYP</h3>
            <span class="details">List the leadership roles you have ever held in NYP, e.g. class rep, club exco, project lead, OGL, event organizer.</span><br />
            <asp:TextBox ID="tbLeadership" class="form-control" width="300px" runat="server"></asp:TextBox>
            </label>
            <br />
            <label>
            <h3>Declare any warning or discipline offence committed in NYP.</h3>
            <span class="details">Exclude attendance warning. Leave empty if not applicable</span><br />
            <asp:TextBox ID="tbOffence" class="form-control" width="300px" runat="server"></asp:TextBox>
            </label>
            <br />
            <label>
            <h3>PSEA Balance $</h3>
            <span class="details">Your PSEA account balance (call MOE auto answer line 62600777). Leave empty if you do not have a PSEA account<span class="details"><br />
            <asp:TextBox ID="tbPSEABalance" class="form-control" width="200px" runat="server"></asp:TextBox>
            </label>
            <br />
            <label>
            <h3>Which funding scheme or scholarship (for overseas internship) you have been awarded?</h3>
            <asp:RadioButtonList ID="rblFundingScheme" runat="server">
                <asp:ListItem>iPREP</asp:ListItem>
                <asp:ListItem>Infocomm Polytechnic Scholarship</asp:ListItem>
            </asp:RadioButtonList>
            </label>
            <label>
            <h3>Have you ever been awarded financial assistance (FASOP or KTPIOP) for your past overseas trip?</h3>
            <asp:RadioButtonList ID="rblFasopHist" runat="server">
                <asp:ListItem>&nbsp; Yes</asp:ListItem>
                <asp:ListItem>&nbsp; No</asp:ListItem>
            </asp:RadioButtonList>
            </label>
            <br />
            <label>
            <h3>Do you have any medical condition?</h3>
            <span class="details">Please state the condition (e.g. asthmatic, dislocation, dyslexia, walking aid etc.) Leave empty if you do not have any medical condition.</span><br />
            <asp:TextBox ID="tbMedCondition" class="form-control" width="200px" runat="server"></asp:TextBox>
            </label>
            <br />
            <label>
            <h3>Are you on medication?</h3>
            <span class="details">If you are taking any medication for more than 1 month and now still taking it. Leave empty if you are not taking any medication.</span><br />
            <asp:TextBox ID="tbMedication" class="form-control" width="200px" runat="server"></asp:TextBox>
            </label>
            <br />
            <label>
            <h3>What's the longest period you stayed overseas without a guardian's company?</h3>
            <asp:DropDownList ID="ddlOverseasStay" width="150px" class="form-control" runat="server">
                <asp:ListItem disabled Selected="True">--Select--</asp:ListItem>
                <asp:ListItem>Never</asp:ListItem>
                <asp:ListItem>Half a day</asp:ListItem>
                <asp:ListItem>Less than a week</asp:ListItem>
                <asp:ListItem>More than a week</asp:ListItem>
            </asp:DropDownList>
            </label>
            <br />
            <label>
            <h3>Describe all your Part Time Experience.</h3>
            <span class="details">Details, Job Title, Scope, Company. Leave empty if you have no part time experiecne.</span><br />
            <asp:TextBox ID="tbPartTimeExp" class="form-control" width="300px" Height="100px" runat="server" TextMode="MultiLine"></asp:TextBox>
            </label>
            <br/>
            <label>
            <h3>Describe to us how independant are you?</h3>
            <span class="details">This will help us to gauge how suitable/independent for you living and working overseas.</span><br />
            <asp:TextBox ID="tbIndependence" class="form-control" width="300px" Height="100px" runat="server" TextMode="MultiLine"></asp:TextBox>
            </label>
            <br/>
            <label>
            <h3><asp:Label ID="lbSpecialQn" runat="server" Text="Label"></asp:Label></h3><br />
            <asp:TextBox ID="tbSpecialAns" class="form-control" width="300px" Height="100px" runat="server" TextMode="MultiLine"></asp:TextBox>
            </label>
            <br />
            <label>
            <h3>Upload your resume</h3>
            <span class="details">Your resume must be in a word document. Click here to </span><br />
            <asp:FileUpload ID="fuResume" runat="server" />
            </label>
            <br />
            <asp:Button ID="btnSubmit" class="btn btn-primary" runat="server" Text="Submit" OnClick="submitSurveyBtn" />
            <input type="reset" class="btn btn-default" value="Clear">
            <br />
            <asp:Label ID="lblResult" runat="server"></asp:Label>
            <asp:Label ID="lblFile" runat="server"></asp:Label>
            </div>
        </div>
        <div style="padding:250px">&nbsp;</div>
    </form>
                </label>
</asp:Content>
