<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="iTravel.Views.login" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    <link rel="icon" href="/Images/iTravelBirdIcon.PNG">
    <link rel="stylesheet" href="../StyleSheets/login.css">
    <title>iTravel - Login</title>
</head>
<body>
    <form runat="server">

    <div class="loginContainer">
        <div class="loginBox">
            <div class="loginHeaderBox">
                <img class="loginLogo" src="../Images/iTravelBird.png" />
                <p class="loginTitle">ACCOUNT LOGIN</p>
            </div>
            <div id="errorDiv" class="errorDiv" runat="server">

            </div>
            <br />
            <p class="loginInputName">USERNAME</p>
            <asp:TextBox class="loginTextbox" ID="inputUsername" runat="server"></asp:TextBox>
            <br />
            <br />
            <p class="loginInputName">PASSWORD</p>
            <asp:TextBox class="loginTextbox" type="password" ID="inputPassword" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="buttonLogin" runat="server" Text="Login" OnClick="buttonLogin_Click" />
            <div id="tooltip">?
                <span id="tooltiptext">
                    <b>For Student:</b> Please use your Admin Number as Username. <br />
                    <b>For Parent:</b> Please use your child's Admin Number with a "P" infront as Username and their IC number as Password <br />
                    <b>For Staff:</b> Please use your Staff Number as Username.
                </span>
            </div>
        </div>
    </div>

    </form>
</body>
</html>
