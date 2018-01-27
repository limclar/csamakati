<%@ Page Language="C#" AutoEventWireup="true" CodeFile="In.aspx.cs" Inherits="In" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>CSA Login Page</title>
    <link rel="stylesheet" href="assets/css/login.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
	         <center>
                 <img src="assets/img/logocsa.png" style="height: 50%; width: 50%"/>
	         </center>
        </div>

        <div class="logocsa">
   
        </div>
        <div class="form">
            <div class="thumbnail"></div>
            <asp:TextBox ID="txtUsername" runat="server" placeholder="Username"></asp:TextBox>
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" placeholder="Password"></asp:TextBox>
            <asp:Button ID="btnLogin" runat="server" Text="Sign In" OnClick="btnLogin_Click" />
            <asp:Literal ID="literalMsg" runat="server"> </asp:Literal>
        </div>
    </form>
</body>
</html>
    