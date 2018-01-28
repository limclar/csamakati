<%@ Page Language="C#" AutoEventWireup="true" CodeFile="In.aspx.cs" Inherits="In" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>CSA Login Page</title>
	<link rel="stylesheet" href="assets/css/loginutil.css" />
	<link rel="stylesheet" href="assets/css/login.css" />
</head>
<body>
<div class="limiter">
		<div class="container-login100">
			<div class="login100-more" style="background-image: url('assets/img/fff.jpg');"></div>
			
			<div class="wrap-login100 p-l-50 p-r-50 p-t-72 p-b-50">
				<form id="form1" runat="server" class="login100-form validate-form">
					<span class="login100-form-title p-b-59">
					<img src="assets/img/logomapua.png"/> 
						<img src="assets/img/logocsa1.png"/> 
						
					</span>

                    <div class="wrap-input100">
                    <span class="label-input100">Username</span>
						<div class="input100"> 
                        <asp:TextBox class="input100" ID="txtUsername" runat="server" placeholder="Username..."></asp:TextBox>
						<span class="focus-input100"></span>
                        </div>
                        </div>

                    <div class="wrap-input100">
                    <span class="label-input100">Password</span>
                    <div class="input100"> 
						<asp:TextBox class="input100" ID="txtPassword" runat="server" TextMode="Password" placeholder="Password..."></asp:TextBox>
						<span class="focus-input100"></span>
                    </div>
                        </div>

						<div class="wrap-login100-form-btn">
							<div class="login100-form-bgbtn"></div>
							<div class="login100-form-btn">
								  <asp:Button class="login100-form-btn" BorderStyle="None" BackColor="#ed2551" ID="btnLogin" runat="server" Text="Sign In" OnClick="btnLogin_Click" />
							</div>
                            </div>
             </form>

                           </div>
                  <asp:Literal ID="literalMsg" runat="server"> </asp:Literal>
						
				
   
       
	
        </div>
     
	</div>
	
</body>
</html>
    
