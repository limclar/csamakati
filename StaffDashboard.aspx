<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="StaffDashboard.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h3> Peer Advising Appointments </h3>   
    <hr />  
        <table class="sdTable">
            <tr>
                <td>
                    <asp:Button ID="btnToday" runat="server" Text="Button" CssClass="apptCount" style="background-color: red; color: white; "/>
                </td>
                <td>
                    <asp:Button ID="btnWeek" runat="server" Text="Button" CssClass="apptCount" style="background-color: blue; color: white;"/>
                </td>
                <td>
                    <asp:Button ID="btnMonth" runat="server" Text="Button" CssClass="apptCount" style="background-color: darkgreen; "/>
                </td>
            </tr>
            <tr>
                <td>
                    <h4> Today </h4>
                </td>
                <td>
                    <h4> This Week </h4>
                </td>
                <td>
                    <h4> This Month </h4>
                </td>
            </tr>
            <tr>
                <td>
                    <div id="piechart_3d" style="width: 900px; height: 500px;"> 
                </td>
            </tr>
        </table>
        <br />
        
                        
</asp:Content>
