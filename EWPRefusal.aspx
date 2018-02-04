<%@ Page Title="EWP Refusal Form" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="EWPRefusal.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <table style="margin-left: 7em; background-color: #f2f2f2; border: 2px solid #ccc;">
                <tr>
                    <td style="padding-left: 5%; padding-top: 5%;">
                        <h4>Please be informed that I am not interested in Early Warning Program due to the ff. reason/s:</h4>
                    </td>
                </tr>
                <tr>
                    <td style="padding-left: 5%;">
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
                    <td style="padding-left: 5%;">
                        <asp:TextBox Enabled="false" id="txtOthers" placeholder="Please Specify " runat="server" TextMode="MultiLine" Rows="5" Columns="100"></asp:TextBox>
                    </td style="padding-left: 5%;">
                </tr>
                <tr> 
                    <td colspan="2" style="padding-left: 5%; padding-top: 4%; text-align: center; padding-bottom: 5%;"> <asp:Button ID="btnsubmitEWP" runat="server"  Text="SUBMIT" OnClick="btnsubmitEWP_Click"/> </td>
                </tr>
            </table>
</asp:Content>
