<%@ Page Title="Manage Appointments" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ManageAppointments.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>



<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h3> Manage Appointments </h3>   
    <hr />
    <div style="margin: 1em 0em -1em 2em; ">
    <table>
       <tr>
          <td style="width: 5%;">
             <h5> Week : </h5>
          </td>
          <td style="text-align: left;">
             <asp:DropDownList ID="ddlWeek" runat="server" OnSelectedIndexChanged="ddlWeek_SelectedIndexChanged" AutoPostBack="true" >
                 <asp:ListItem>Previous</asp:ListItem>
                 <asp:ListItem>Current</asp:ListItem>
                 <asp:ListItem>Next</asp:ListItem>
             </asp:DropDownList>
          </td>
          <td style="width: 5%;">
          <a onServerClick="displayWalkin" ID="walkingCon" runat="server" class="pic" >
                <table style=" margin: -4% 0% 0% 0%;">
                   <tr>
                       <td style="text-align:center;">
                           <img src="assets/img/add.png"/>
                       </td>
                   </tr>
                   <tr>
                       <td style="text-align:center;">
                           <a onclick="div_show()" style="cursor: pointer; margin-left: -8%;/*white-space: nowrap; overflow: hidden;*/"> Walk-In</a>
                       </td>
                   </tr>
                </table>
            </a>
          </td>
       </tr>
    </table>
    
    
    
        </div>
    <br /><br />
    <!-- Time table with student numbers inside -->
    <table style="width: 95%; margin: -1% 1em 0em 1.5em;" class="timeTable" id="schedule" runat="server">
    <tbody>
        <tr class="timeTableHeader">
            <th style="width: 11%;">       </th>
            <th>Monday</th>
            <th>Tuesday</th>
            <th>Wednesday</th>
            <th>Thursday</th>
            <th>Friday</th>
            <th>Saturday</th>
        </tr>
        <tr runat="server">
            <td> 07:30 - 09:00 </td>
            <td> <asp:LinkButton Font-Underline="false" ID="A1" runat="server" Text="---" OnClick="LinkButtons_Click"></asp:LinkButton> </td>
            <td> <asp:LinkButton Font-Underline="false" ID="A2" runat="server" Text="---" OnClick="LinkButtons_Click"></asp:LinkButton> </td>
            <td> <asp:LinkButton Font-Underline="false" ID="A3" runat="server" Text="---" OnClick="LinkButtons_Click"></asp:LinkButton> </td>
            <td> <asp:LinkButton Font-Underline="false" ID="A4" runat="server" Text="---" OnClick="LinkButtons_Click"></asp:LinkButton> </td>
            <td> <asp:LinkButton Font-Underline="false" ID="A5" runat="server" Text="---" OnClick="LinkButtons_Click"></asp:LinkButton> </td>
            <td> <asp:LinkButton Font-Underline="false" ID="A6" runat="server" Text="---" OnClick="LinkButtons_Click"></asp:LinkButton> </td>
        </tr>
        <tr>
            <td> 09:00 - 10:30</td>
            <td> <asp:LinkButton Font-Underline="false" ID="B1" runat="server" Text="---" OnClick="LinkButtons_Click"></asp:LinkButton> </td>
            <td> <asp:LinkButton Font-Underline="false" ID="B2" runat="server" Text="---" OnClick="LinkButtons_Click"></asp:LinkButton> </td>
            <td> <asp:LinkButton Font-Underline="false" ID="B3" runat="server" Text="---" OnClick="LinkButtons_Click"></asp:LinkButton> </td>
            <td> <asp:LinkButton Font-Underline="false" ID="B4" runat="server" Text="---" OnClick="LinkButtons_Click"></asp:LinkButton> </td>
            <td> <asp:LinkButton Font-Underline="false" ID="B5" runat="server" Text="---" OnClick="LinkButtons_Click"></asp:LinkButton> </td>
            <td> <asp:LinkButton Font-Underline="false" ID="B6" runat="server" Text="---" OnClick="LinkButtons_Click"></asp:LinkButton> </td>
        </tr>
        <tr>
            <td> 10:30 - 12:00</td>
            <td> <asp:LinkButton Font-Underline="false" ID="C1" runat="server" Text="---" OnClick="LinkButtons_Click"></asp:LinkButton> </td>
            <td> <asp:LinkButton Font-Underline="false" ID="C2" runat="server" Text="---" OnClick="LinkButtons_Click"></asp:LinkButton> </td>
            <td> <asp:LinkButton Font-Underline="false" ID="C3" runat="server" Text="---" OnClick="LinkButtons_Click"></asp:LinkButton> </td>
            <td> <asp:LinkButton Font-Underline="false" ID="C4" runat="server" Text="---" OnClick="LinkButtons_Click"></asp:LinkButton> </td>
            <td> <asp:LinkButton Font-Underline="false" ID="C5" runat="server" Text="---" OnClick="LinkButtons_Click"></asp:LinkButton> </td>
            <td> <asp:LinkButton Font-Underline="false" ID="C6" runat="server" Text="---" OnClick="LinkButtons_Click"></asp:LinkButton> </td>
        </tr>
        <tr>
            <td> 12:00 - 13:30</td>
            <td> <asp:LinkButton Font-Underline="false" ID="D1" runat="server" Text="---" OnClick="LinkButtons_Click"></asp:LinkButton> </td>
            <td> <asp:LinkButton Font-Underline="false" ID="D2" runat="server" Text="---" OnClick="LinkButtons_Click"></asp:LinkButton> </td>
            <td> <asp:LinkButton Font-Underline="false" ID="D3" runat="server" Text="---" OnClick="LinkButtons_Click"></asp:LinkButton> </td>
            <td> <asp:LinkButton Font-Underline="false" ID="D4" runat="server" Text="---" OnClick="LinkButtons_Click"></asp:LinkButton> </td>
            <td> <asp:LinkButton Font-Underline="false" ID="D5" runat="server" Text="---" OnClick="LinkButtons_Click"></asp:LinkButton> </td>
            <td> <asp:LinkButton Font-Underline="false" ID="D6" runat="server" Text="---" OnClick="LinkButtons_Click"></asp:LinkButton> </td>
        </tr>
        <tr>
            <td> 13:30 - 15:00</td>
            <td> <asp:LinkButton Font-Underline="false" ID="E1" runat="server" Text="---" OnClick="LinkButtons_Click"></asp:LinkButton> </td>
            <td> <asp:LinkButton Font-Underline="false" ID="E2" runat="server" Text="---" OnClick="LinkButtons_Click"></asp:LinkButton> </td>
            <td> <asp:LinkButton Font-Underline="false" ID="E3" runat="server" Text="---" OnClick="LinkButtons_Click"></asp:LinkButton> </td>
            <td> <asp:LinkButton Font-Underline="false" ID="E4" runat="server" Text="---" OnClick="LinkButtons_Click"></asp:LinkButton> </td>
            <td> <asp:LinkButton Font-Underline="false" ID="E5" runat="server" Text="---" OnClick="LinkButtons_Click"></asp:LinkButton> </td>
            <td> <asp:LinkButton Font-Underline="false" ID="E6" runat="server" Text="---" OnClick="LinkButtons_Click"></asp:LinkButton> </td>
        </tr>
        <tr>
            <td> 15:00 - 16:30</td>
            <td> <asp:LinkButton Font-Underline="false" ID="F1" runat="server" Text="---" OnClick="LinkButtons_Click"></asp:LinkButton> </td>
            <td> <asp:LinkButton Font-Underline="false" ID="F2" runat="server" Text="---" OnClick="LinkButtons_Click"></asp:LinkButton> </td>
            <td> <asp:LinkButton Font-Underline="false" ID="F3" runat="server" Text="---" OnClick="LinkButtons_Click"></asp:LinkButton> </td>
            <td> <asp:LinkButton Font-Underline="false" ID="F4" runat="server" Text="---" OnClick="LinkButtons_Click"></asp:LinkButton> </td>
            <td> <asp:LinkButton Font-Underline="false" ID="F5" runat="server" Text="---" OnClick="LinkButtons_Click"></asp:LinkButton> </td>
            <td> <asp:LinkButton Font-Underline="false" ID="F6" runat="server" Text="---" OnClick="LinkButtons_Click"></asp:LinkButton> </td>
        </tr>
        <tr>
            <td> 16:30 - 18:00</td>
            <td> <asp:LinkButton Font-Underline="false" ID="G1" runat="server" Text="---" OnClick="LinkButtons_Click"></asp:LinkButton> </td>
            <td> <asp:LinkButton Font-Underline="false" ID="G2" runat="server" Text="---" OnClick="LinkButtons_Click"></asp:LinkButton> </td>
            <td> <asp:LinkButton Font-Underline="false" ID="G3" runat="server" Text="---" OnClick="LinkButtons_Click"></asp:LinkButton> </td>
            <td> <asp:LinkButton Font-Underline="false" ID="G4" runat="server" Text="---" OnClick="LinkButtons_Click"></asp:LinkButton> </td>
            <td> <asp:LinkButton Font-Underline="false" ID="G5" runat="server" Text="---" OnClick="LinkButtons_Click"></asp:LinkButton> </td>
            <td> <asp:LinkButton Font-Underline="false" ID="G6" runat="server" Text="---" OnClick="LinkButtons_Click"></asp:LinkButton> </td>
        </tr>
    </table>

    <center>
    <div id="popupDiv" >
        <div id="popupInner" style="width: 30%; margin-top: 2%; margin-left: -15%;">
            <div id="popupForm">
                <img id="close" src="assets/img/close.png" onclick ="div_hide()" >
                
                <div runat="server" id="walkin">
                    <h2>Walk-In Session</h2>
                <hr>
                <table style="width: 100%;">
                <tr>
                    <td>
                        <b> Student Number : </b>
                    </td>
                    <td>
                        <asp:DropDownList class="popup95" ID="ddlStudNum" placeholder="Student Number" runat="server" OnSelectedIndexChanged="btnSearchStudent_Click" AutoPostBack="true"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td style="width : 5%;">
                        <b> Name : </b>
                    </td>
                    <td>
                        <asp:TextBox style="width: 95%;" Enabled="false" id="studentName" placeholder="Student Name" runat="server" ></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <b> Program : </b>
                    </td>
                    <td>
                        <asp:TextBox style="width: 95%;"  Enabled="false" id="studentProgram" placeholder="Project Title" runat="server" ></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <b> Subject Type : </b>
                    </td>
                    <td>
                        <asp:DropDownList class="popup95" ID="ddlSubjType" runat="server" OnSelectedIndexChanged="fillCCode" AutoPostBack="true">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <b> Course Code : </b>
                    </td>
                    <td>
                        <asp:DropDownList class="popup95" ID="ddlCourseCode" runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <b> Peer Adviser : </b>
                    </td>
                    <td>
                        <asp:DropDownList class="popup95" ID="ddlPeerAdviser" runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td colspan="2"> <asp:Button style="margin-left: 35%; margin-top: 2%;" ID="btnAddSession" OnClick="addWalkin" runat="server"  Text="ADD CONSULTATION"/> </td>
                </tr>
            </table>
            </div>

            <div runat="server" id="students" Visible="false" style="margin-top: 5em; margin-bottom: 5em;">
                <asp:Label ID="Label1" runat="server" Text="STUDENTS"></asp:Label>
               <asp:DropDownList ID="ddlStudents" runat="server"></asp:DropDownList>
                <asp:Button ID="btnViewAppt" runat="server" Text="VIEW APPOINTMENT" OnClick="btnViewAppt_Click"></asp:Button>
            </div>

    <asp:Literal ID="Literal1" runat="server"></asp:Literal>
    </div>
    </div>
    </div>
    </center>

    

</asp:Content>



