<%@ Page Title="Dashboard" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="FacultyDashboard.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h3> Your Appointments</h3>
    <hr />
    <table style=" width: 100%; margin-left: 3%;">
        <tr>
            <td style="width: 0.5%; text-align: right;">
               <h5>Week :  </h5>
            </td>
            <td style="width: 15%; text-align: left;">
               <asp:DropDownList ID="ddlWeek" runat="server" OnSelectedIndexChanged="ddlWeek_SelectedIndexChanged" AutoPostBack="true" style="margin-left: 1%;">
                   <asp:ListItem>Previous</asp:ListItem>
                   <asp:ListItem>Current</asp:ListItem>
                   <asp:ListItem>Next</asp:ListItem>
               </asp:DropDownList>
            </td>
</tr>
<%--
            <td>
                <asp:Button ID="btnToday" runat="server" Text="0" CssClass="apptCount" style="background-color: black; color: white; margin-left:87.2%;"/>
            </td> 
       </tr>

       <tr>
            <td colspan="3">
                <h4 style=" margin-left: 90%;"> Today </h4>
            </td> 
        </tr> 
--%>
    </table>
     
    <table style="width: 95%; margin-top: 2%;" class="timeTable" id="schedule" runat="server">
    <tbody>
        <tr class="timeTableHeader">
            <th>Days</th>
            <th>Monday</th>
            <th>Tuesday</th>
            <th>Wednesday</th>
            <th>Thursday</th>
            <th>Friday</th>
            <th>Saturday</th>
        </tr>
        <tr runat="server">
            <td>07:30 - 09:00</td>
            <td> <asp:LinkButton Font-Underline="false" ID="A1" runat="server" Text="---"  ></asp:LinkButton> </td>
            <td> <asp:LinkButton Font-Underline="false" ID="A2" runat="server" Text="---"  ></asp:LinkButton> </td>
            <td> <asp:LinkButton Font-Underline="false" ID="A3" runat="server" Text="---"  ></asp:LinkButton> </td>
            <td> <asp:LinkButton Font-Underline="false" ID="A4" runat="server" Text="---"  ></asp:LinkButton> </td>
            <td> <asp:LinkButton Font-Underline="false" ID="A5" runat="server" Text="---"  ></asp:LinkButton> </td>
            <td> <asp:LinkButton Font-Underline="false" ID="A6" runat="server" Text="---"  ></asp:LinkButton> </td>
        </tr>
        <tr>
            <td>09:00 - 10:30</td>
            <td> <asp:LinkButton Font-Underline="false" ID="B1" runat="server" Text="---"  ></asp:LinkButton> </td>
            <td> <asp:LinkButton Font-Underline="false" ID="B2" runat="server" Text="---"  ></asp:LinkButton> </td>
            <td> <asp:LinkButton Font-Underline="false" ID="B3" runat="server" Text="---"  ></asp:LinkButton> </td>
            <td> <asp:LinkButton Font-Underline="false" ID="B4" runat="server" Text="---"  ></asp:LinkButton> </td>
            <td> <asp:LinkButton Font-Underline="false" ID="B5" runat="server" Text="---"  ></asp:LinkButton> </td>
            <td> <asp:LinkButton Font-Underline="false" ID="B6" runat="server" Text="---"  ></asp:LinkButton> </td>
        </tr>
        <tr>
            <td>10:30 - 12:00</td>
            <td> <asp:LinkButton Font-Underline="false" ID="C1" runat="server" Text="---"  ></asp:LinkButton> </td>
            <td> <asp:LinkButton Font-Underline="false" ID="C2" runat="server" Text="---"  ></asp:LinkButton> </td>
            <td> <asp:LinkButton Font-Underline="false" ID="C3" runat="server" Text="---"  ></asp:LinkButton> </td>
            <td> <asp:LinkButton Font-Underline="false" ID="C4" runat="server" Text="---"  ></asp:LinkButton> </td>
            <td> <asp:LinkButton Font-Underline="false" ID="C5" runat="server" Text="---"  ></asp:LinkButton> </td>
            <td> <asp:LinkButton Font-Underline="false" ID="C6" runat="server" Text="---"  ></asp:LinkButton> </td>
        </tr>
        <tr>
            <td>12:00 - 13:30</td>
            <td> <asp:LinkButton Font-Underline="false" ID="D1" runat="server" Text="---"  ></asp:LinkButton> </td>
            <td> <asp:LinkButton Font-Underline="false" ID="D2" runat="server" Text="---"  ></asp:LinkButton> </td>
            <td> <asp:LinkButton Font-Underline="false" ID="D3" runat="server" Text="---"  ></asp:LinkButton> </td>
            <td> <asp:LinkButton Font-Underline="false" ID="D4" runat="server" Text="---"  ></asp:LinkButton> </td>
            <td> <asp:LinkButton Font-Underline="false" ID="D5" runat="server" Text="---"  ></asp:LinkButton> </td>
            <td> <asp:LinkButton Font-Underline="false" ID="D6" runat="server" Text="---"  ></asp:LinkButton> </td>
        </tr>
        <tr>
            <td>13:30 - 15:00</td>
            <td> <asp:LinkButton Font-Underline="false" ID="E1" runat="server" Text="---"  ></asp:LinkButton> </td>
            <td> <asp:LinkButton Font-Underline="false" ID="E2" runat="server" Text="---"  ></asp:LinkButton> </td>
            <td> <asp:LinkButton Font-Underline="false" ID="E3" runat="server" Text="---"  ></asp:LinkButton> </td>
            <td> <asp:LinkButton Font-Underline="false" ID="E4" runat="server" Text="---"  ></asp:LinkButton> </td>
            <td> <asp:LinkButton Font-Underline="false" ID="E5" runat="server" Text="---"  ></asp:LinkButton> </td>
            <td> <asp:LinkButton Font-Underline="false" ID="E6" runat="server" Text="---"  ></asp:LinkButton> </td>
        </tr>
        <tr>
            <td>15:00 - 16:30</td>
            <td> <asp:LinkButton Font-Underline="false" ID="F1" runat="server" Text="---"  ></asp:LinkButton> </td>
            <td> <asp:LinkButton Font-Underline="false" ID="F2" runat="server" Text="---"  ></asp:LinkButton> </td>
            <td> <asp:LinkButton Font-Underline="false" ID="F3" runat="server" Text="---"  ></asp:LinkButton> </td>
            <td> <asp:LinkButton Font-Underline="false" ID="F4" runat="server" Text="---"  ></asp:LinkButton> </td>
            <td> <asp:LinkButton Font-Underline="false" ID="F5" runat="server" Text="---"  ></asp:LinkButton> </td>
            <td> <asp:LinkButton Font-Underline="false" ID="F6" runat="server" Text="---"  ></asp:LinkButton> </td>
        </tr>
        <tr>
            <td>16:30 - 18:00</td>
            <td> <asp:LinkButton Font-Underline="false" ID="G1" runat="server" Text="---"  ></asp:LinkButton> </td>
            <td> <asp:LinkButton Font-Underline="false" ID="G2" runat="server" Text="---"  ></asp:LinkButton> </td>
            <td> <asp:LinkButton Font-Underline="false" ID="G3" runat="server" Text="---"  ></asp:LinkButton> </td>
            <td> <asp:LinkButton Font-Underline="false" ID="G4" runat="server" Text="---"  ></asp:LinkButton> </td>
            <td> <asp:LinkButton Font-Underline="false" ID="G5" runat="server" Text="---"  ></asp:LinkButton> </td>
            <td> <asp:LinkButton Font-Underline="false" ID="G6" runat="server" Text="---"  ></asp:LinkButton> </td>
        </tr>
        <tr>
            <td>18:00 - 19:30</td>
            <td> <asp:LinkButton Font-Underline="false" ID="H1" runat="server" Text="---"  ></asp:LinkButton> </td>
            <td> <asp:LinkButton Font-Underline="false" ID="H2" runat="server" Text="---"  ></asp:LinkButton> </td>
            <td> <asp:LinkButton Font-Underline="false" ID="H3" runat="server" Text="---"  ></asp:LinkButton> </td>
            <td> <asp:LinkButton Font-Underline="false" ID="H4" runat="server" Text="---"  ></asp:LinkButton> </td>
            <td> <asp:LinkButton Font-Underline="false" ID="H5" runat="server" Text="---"  ></asp:LinkButton> </td>
            <td> <asp:LinkButton Font-Underline="false" ID="H6" runat="server" Text="---"  ></asp:LinkButton> </td>
        </tr>
        <tr>
            <td>19:30 - 21:00</td>
            <td> <asp:LinkButton Font-Underline="false" ID="I1" runat="server" Text="---"  ></asp:LinkButton> </td>
            <td> <asp:LinkButton Font-Underline="false" ID="I2" runat="server" Text="---"  ></asp:LinkButton> </td>
            <td> <asp:LinkButton Font-Underline="false" ID="I3" runat="server" Text="---"  ></asp:LinkButton> </td>
            <td> <asp:LinkButton Font-Underline="false" ID="I4" runat="server" Text="---"  ></asp:LinkButton> </td>
            <td> <asp:LinkButton Font-Underline="false" ID="I5" runat="server" Text="---"  ></asp:LinkButton> </td>
            <td> <asp:LinkButton Font-Underline="false" ID="I6" runat="server" Text="---"  ></asp:LinkButton> </td>
        </tr>
    </tbody>
    </table>
    <br />
                        
    <!-- Time table with Student Number Cells -->
                        
</asp:Content>

