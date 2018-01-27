<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="EWPRefusal.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="landing-page"><div class="form-ewp"><div class="wpcf7" id="wpcf7-f560-p590-o1">
        <table style="margin-left: 7em;">
                <tr>
                    <td>
                        <h4>Please be informed that I am not interested in Early Warning Program due to the ff. reason/s:</h4>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:RadioButtonList ID="CheckBoxList1" runat="server" OnSelectedIndexChanged="CheckBoxList1_SelectedIndexChanged" AutoPostBack="true">
                            <asp:ListItem>I can handle courses on my own</asp:ListItem>
                            <asp:ListItem>I am not satisfied with the advisers</asp:ListItem>
                            <asp:ListItem>I have my own support group</asp:ListItem>
                            <asp:ListItem>I am not comfortable with the environment/study area</asp:ListItem>
                            <asp:ListItem>I plan to transfer to another school</asp:ListItem>
                            <asp:ListItem>My schedule does not fit with the Early Warning Program (EWP)</asp:ListItem>
                            <asp:ListItem>Others (specify):</asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox Enabled="false" id="txtOthers" placeholder="Please Specify " runat="server" TextMode="MultiLine" Rows="5" Columns="44"></asp:TextBox>
                    </td>
                </tr>
                <tr> 
                    <td colspan="2"> <asp:Button style="margin-left: 12em;"  ID="btnsubmitEWP" runat="server"  Text="SUBMIT" CssClass="btn" OnClick="btnsubmitEWP_Click"/> </td>
                </tr>
            </table>
       </div></div></div>
</asp:Content>