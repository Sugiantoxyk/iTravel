<%@ Page Title="" Language="C#" MasterPageFile="~/Views/master.Master" AutoEventWireup="true" CodeBehind="StudentPayment.aspx.cs" Inherits="iTravel.Views.StudentPayment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
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
        <h1> Payment Details for Trip</h1>
        <h4>    
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;    
        <asp:Label ID="lbMsg" runat="server"></asp:Label>
         </h4>
        <h4>    
        <asp:Label ID="lbFirstName" runat="server" Text="First Name: "></asp:Label> 
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="tbFirstName" ErrorMessage="Please Enter First Name" ForeColor="Red">*</asp:RequiredFieldValidator>
         </h4>
        <asp:TextBox ID="tbFirstName" CssClass="tbStyle" runat="server"></asp:TextBox>
        <br />
        <h4>
        <asp:Label ID="lbText" runat="server" Height="21px" Visible="False" Width="150px"></asp:Label>
            </h4>
        <br />
        <h4>
        <asp:Label ID="lbLastName" runat="server" Text="Last Name: "></asp:Label>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="tbLastName" ErrorMessage="Please Enter Last Name" ForeColor="Red">*</asp:RequiredFieldValidator>
        </h4>
            <br />
        <asp:TextBox ID="tbLastName" CssClass="tbStyle" runat="server"></asp:TextBox>
        <br />
        <br />
        <h4>
        <asp:Label ID="lbAdminNumber" runat="server" Text="Admin Number:"></asp:Label>
        </h4>
        <br />
        <h4>
        <asp:Label ID="tbAdminNo" runat="server"></asp:Label>
         </h4>
        <br/>
        <h4>
        <asp:Label ID="lbEmail" runat="server" Text="Email Address: "></asp:Label></h4>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tbEmail" ErrorMessage="Please Enter Email" ForeColor="Red">*</asp:RequiredFieldValidator>
        <asp:Button ID="Button1" CssClass="button"  runat="server" OnClick="Button1_Click" Text="Back" Visible="False" Width="101px" />
        <br />
        <asp:TextBox ID="tbEmail" CssClass="tbStyle" runat="server"></asp:TextBox>
        &nbsp;<br />
        <br />
        <h4>
        <asp:Label ID="lbCreditCardNumber" runat="server" Text="Credit Card Number: "></asp:Label></h4>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="tbCreditCardNumber" ErrorMessage="Please Enter Credit Card Number" ForeColor="Red">*</asp:RequiredFieldValidator>
        <br />
        <asp:TextBox ID="tbCreditCardNumber" CssClass="tbStyle" runat="server"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;
        <h4>&nbsp;</h4>
        <br />
        <h4>
        <asp:Label ID="lbExpiryDate" runat="server" Text="Expiry Date: (MM/YY)"></asp:Label></h4>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="tbExpiryDate" ErrorMessage="Please Enter Expiry Date" ForeColor="Red">*</asp:RequiredFieldValidator>
        <br />
        <asp:TextBox ID="tbExpiryDate" CssClass="tbStyle" runat="server"></asp:TextBox>
        <br />
        <br />
        <h4><asp:Label ID="lbCCV" runat="server" Text="CCV"></asp:Label></h4>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="tbCCV" ErrorMessage="Please enter CCV" ForeColor="Red">*</asp:RequiredFieldValidator>
        <br />
        
        <asp:TextBox ID="tbCCV" CssClass="tbStyle" runat="server"></asp:TextBox>
        
        <br />
        <br />
        <h4>
        <asp:Label ID="lbCardholderName" runat="server" Text="Cardholder Name: "></asp:Label></h4>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="tbCardHolderName" ErrorMessage="Please Enter Name of CardHolder" ForeColor="Red">*</asp:RequiredFieldValidator>
        <br />
        <asp:TextBox ID="tbCardHolderName" CssClass="tbStyle" runat="server"></asp:TextBox>
        <br />
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" />
        <br />
        <asp:Button ID="btnSubmit" CssClass="button" runat="server" OnClick="btnSubmit_Click" Text="Submit" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnCancel" CssClass="button" runat="server" Text="Cancel" OnClick="btnCancel_Click" CausesValidation="False" />
            
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="lbBack" CssClass="button" runat="server" Height="40px" OnClick="lbBack_Click" Text="Back" Visible="False" Width="100px" />
            
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />

    </form>
</asp:Content>
