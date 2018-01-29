<%@ Page Title="Change Password" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ChangePassword.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
    
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h3> Change Password </h3>   
    <hr />
    <div style="background-color: #f2f2f2; width: 40%; margin-left: 30%; border: 2px solid #999;">
    <table style="width: 100%; margin-left: 0%; text-align: center;">
                <tr>
                     <td>
                          <br />
                      </td>
                </tr>
                <tr>
                    <td style="text-align:right;">
                        <h5> Current Password : </h5>
                    </td>
                    <td style="text-align:left;">
                        <asp:TextBox style="margin-left: 5%;" TextMode="password" id="tboxOPass" placeholder="Old Password" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="text-align:right;">
                        <h5> New Password : </h5>
                    </td>
                    <td style="text-align:left;">
                        <asp:TextBox style="margin-left: 5%;" TextMode="password" id="tboxNPass" placeholder="New Password" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="text-align:right;">
                        <h5> Retype New : </h5>
                    </td>
                    <td style="text-align:left;">
                        <asp:TextBox style="margin-left: 5%;" TextMode="password" id="tboxRPass" placeholder="Retype Password" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr > 
                    <td colspan="2" style="text-align:center;"> <asp:Button style="text-align: center;"  ID="btnChangePass" runat="server"  Text="Save Changes" OnClick="btnChangePass_Click"/> </td>
                   
                </tr>
       </table>
       </div>
       <asp:Literal ID="literal1" runat="server"></asp:Literal>
</asp:Content>
