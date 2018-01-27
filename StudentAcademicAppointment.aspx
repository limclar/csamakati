<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="StudentAcademicAppointment.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>



<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h3> Make a Academic Advising Appointment </h3>   
    <hr />   
    <br />
                        
    <table style="margin-left: 5%; margin-top: -2%; width: 100%;">
        <tr >
            <td style="width: 10%; text-align: right;">
                <h4> Department : </h4> 
            </td>
            <td style="width: 10%; padding-right: 50%;">
                <asp:DropDownList ID="ddlDepartment" runat="server" OnSelectedIndexChanged="ddlDepartment_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
            </td>
            <td >
                <h4 style="margin-left: 10%; text-align: right;"> Student : </h4> 
            </td>
            <td>
                <asp:DropDownList ID="ddlAddStudent" runat="server" OnSelectedIndexChanged="ddlDepartment_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
            </td>
            <td>
                <asp:Button ID="btnAddToGroupd" runat="server" Text="Add to Group" OnClick="btnAddToGroupd_Click" />
            </td>
        </tr>
        <tr>
            <td style="width: 10%; text-align: right;">
                <h4> Faculty : </h4> 
            </td>
            <td style="width: 10%; padding-right: 50%;">
                <asp:DropDownList style="min-width: 150px;" ID="ddlFaculty" runat="server" OnSelectedIndexChanged="ddlFaculty_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
            </td>
            <td>
                <h4 style="margin-left: 10%; text-align: right;"> Group Members : </h4> 
            </td>
            <td>
                <asp:DropDownList ID="ddlGroup" runat="server" OnSelectedIndexChanged="ddlDepartment_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
            </td>
        </tr>
    </table>

     <table style="margin-top: 1em; border-width: 0.5px ; width: 95%;" class="timeTable">
        <tr class="timeTableHeader">
            <th>Days</th>
            <th>Monday</th>
            <th>Tuesday</th>
            <th>Wednesday</th>
            <th>Thursday</th>
            <th>Friday</th>
            <th>Saturday</th>
        </tr>
        <tr>
            <td class="A">7:30 - 9:00</td>
            <td> <asp:LinkButton Font-Underline="false" ID="A1" runat="server" Text="---" OnClick="LinkButtons_Click"></asp:LinkButton> </td>
            <td> <asp:LinkButton Font-Underline="false" ID="A2" runat="server" Text="---" OnClick="LinkButtons_Click"></asp:LinkButton> </td>
            <td> <asp:LinkButton Font-Underline="false" ID="A3" runat="server" Text="---" OnClick="LinkButtons_Click"></asp:LinkButton> </td>
            <td> <asp:LinkButton Font-Underline="false" ID="A4" runat="server" Text="---" OnClick="LinkButtons_Click"></asp:LinkButton> </td>
            <td> <asp:LinkButton Font-Underline="false" ID="A5" runat="server" Text="---" OnClick="LinkButtons_Click"></asp:LinkButton> </td>
            <td> <asp:LinkButton Font-Underline="false" ID="A6" runat="server" Text="---" OnClick="LinkButtons_Click"></asp:LinkButton> </td>
        </tr>
        <tr>
            <td>9:00 - 10:30</td>
            <td> <asp:LinkButton Font-Underline="false" ID="B1" runat="server" Text="---" OnClick="LinkButtons_Click"></asp:LinkButton> </td>
            <td> <asp:LinkButton Font-Underline="false" ID="B2" runat="server" Text="---" OnClick="LinkButtons_Click"></asp:LinkButton> </td>
            <td> <asp:LinkButton Font-Underline="false" ID="B3" runat="server" Text="---" OnClick="LinkButtons_Click"></asp:LinkButton> </td>
            <td> <asp:LinkButton Font-Underline="false" ID="B4" runat="server" Text="---" OnClick="LinkButtons_Click"></asp:LinkButton> </td>
            <td> <asp:LinkButton Font-Underline="false" ID="B5" runat="server" Text="---" OnClick="LinkButtons_Click"></asp:LinkButton> </td>
            <td> <asp:LinkButton Font-Underline="false" ID="B6" runat="server" Text="---" OnClick="LinkButtons_Click"></asp:LinkButton> </td>
        </tr>
        <tr>
            <td>10:30 - 12:00</td>
            <td> <asp:LinkButton Font-Underline="false" ID="C1" runat="server" Text="---" OnClick="LinkButtons_Click"></asp:LinkButton> </td>
            <td> <asp:LinkButton Font-Underline="false" ID="C2" runat="server" Text="---" OnClick="LinkButtons_Click"></asp:LinkButton> </td>
            <td> <asp:LinkButton Font-Underline="false" ID="C3" runat="server" Text="---" OnClick="LinkButtons_Click"></asp:LinkButton> </td>
            <td> <asp:LinkButton Font-Underline="false" ID="C4" runat="server" Text="---" OnClick="LinkButtons_Click"></asp:LinkButton> </td>
            <td> <asp:LinkButton Font-Underline="false" ID="C5" runat="server" Text="---" OnClick="LinkButtons_Click"></asp:LinkButton> </td>
            <td> <asp:LinkButton Font-Underline="false" ID="C6" runat="server" Text="---" OnClick="LinkButtons_Click"></asp:LinkButton> </td>
        </tr>
        <tr>
            <td>12:00 - 1:30</td>
            <td> <asp:LinkButton Font-Underline="false" ID="D1" runat="server" Text="---" OnClick="LinkButtons_Click"></asp:LinkButton> </td>
            <td> <asp:LinkButton Font-Underline="false" ID="D2" runat="server" Text="---" OnClick="LinkButtons_Click"></asp:LinkButton> </td>
            <td> <asp:LinkButton Font-Underline="false" ID="D3" runat="server" Text="---" OnClick="LinkButtons_Click"></asp:LinkButton> </td>
            <td> <asp:LinkButton Font-Underline="false" ID="D4" runat="server" Text="---" OnClick="LinkButtons_Click"></asp:LinkButton> </td>
            <td> <asp:LinkButton Font-Underline="false" ID="D5" runat="server" Text="---" OnClick="LinkButtons_Click"></asp:LinkButton> </td>
            <td> <asp:LinkButton Font-Underline="false" ID="D6" runat="server" Text="---" OnClick="LinkButtons_Click"></asp:LinkButton> </td>
        </tr>
        <tr>
            <td>1:30 - 3:00</td>
            <td> <asp:LinkButton Font-Underline="false" ID="E1" runat="server" Text="---" OnClick="LinkButtons_Click"></asp:LinkButton> </td>
            <td> <asp:LinkButton Font-Underline="false" ID="E2" runat="server" Text="---" OnClick="LinkButtons_Click"></asp:LinkButton> </td>
            <td> <asp:LinkButton Font-Underline="false" ID="E3" runat="server" Text="---" OnClick="LinkButtons_Click"></asp:LinkButton> </td>
            <td> <asp:LinkButton Font-Underline="false" ID="E4" runat="server" Text="---" OnClick="LinkButtons_Click"></asp:LinkButton> </td>
            <td> <asp:LinkButton Font-Underline="false" ID="E5" runat="server" Text="---" OnClick="LinkButtons_Click"></asp:LinkButton> </td>
            <td> <asp:LinkButton Font-Underline="false" ID="E6" runat="server" Text="---" OnClick="LinkButtons_Click"></asp:LinkButton> </td>
        </tr>
        <tr>
            <td>3:00 - 4:30</td>
            <td> <asp:LinkButton Font-Underline="false" ID="F1" runat="server" Text="---" OnClick="LinkButtons_Click"></asp:LinkButton> </td>
            <td> <asp:LinkButton Font-Underline="false" ID="F2" runat="server" Text="---" OnClick="LinkButtons_Click"></asp:LinkButton> </td>
            <td> <asp:LinkButton Font-Underline="false" ID="F3" runat="server" Text="---" OnClick="LinkButtons_Click"></asp:LinkButton> </td>
            <td> <asp:LinkButton Font-Underline="false" ID="F4" runat="server" Text="---" OnClick="LinkButtons_Click"></asp:LinkButton> </td>
            <td> <asp:LinkButton Font-Underline="false" ID="F5" runat="server" Text="---" OnClick="LinkButtons_Click"></asp:LinkButton> </td>
            <td> <asp:LinkButton Font-Underline="false" ID="F6" runat="server" Text="---" OnClick="LinkButtons_Click"></asp:LinkButton> </td>
        </tr>
        <tr>
            <td>4:30 - 6:00</td>
            <td> <asp:LinkButton Font-Underline="false" ID="G1" runat="server" Text="---" OnClick="LinkButtons_Click"></asp:LinkButton> </td>
            <td> <asp:LinkButton Font-Underline="false" ID="G2" runat="server" Text="---" OnClick="LinkButtons_Click"></asp:LinkButton> </td>
            <td> <asp:LinkButton Font-Underline="false" ID="G3" runat="server" Text="---" OnClick="LinkButtons_Click"></asp:LinkButton> </td>
            <td> <asp:LinkButton Font-Underline="false" ID="G4" runat="server" Text="---" OnClick="LinkButtons_Click"></asp:LinkButton> </td>
            <td> <asp:LinkButton Font-Underline="false" ID="G5" runat="server" Text="---" OnClick="LinkButtons_Click"></asp:LinkButton> </td>
            <td> <asp:LinkButton Font-Underline="false" ID="G6" runat="server" Text="---" OnClick="LinkButtons_Click"></asp:LinkButton> </td>
        </tr>
        <tr>
            <td>6:00 - 7:30</td>
            <td> <asp:LinkButton Font-Underline="false" ID="H1" runat="server" Text="---" OnClick="LinkButtons_Click"></asp:LinkButton> </td>
            <td> <asp:LinkButton Font-Underline="false" ID="H2" runat="server" Text="---" OnClick="LinkButtons_Click"></asp:LinkButton> </td>
            <td> <asp:LinkButton Font-Underline="false" ID="H3" runat="server" Text="---" OnClick="LinkButtons_Click"></asp:LinkButton> </td>
            <td> <asp:LinkButton Font-Underline="false" ID="H4" runat="server" Text="---" OnClick="LinkButtons_Click"></asp:LinkButton> </td>
            <td> <asp:LinkButton Font-Underline="false" ID="H5" runat="server" Text="---" OnClick="LinkButtons_Click"></asp:LinkButton> </td>
            <td> <asp:LinkButton Font-Underline="false" ID="H6" runat="server" Text="---" OnClick="LinkButtons_Click"></asp:LinkButton> </td>
        </tr>
        <tr >
            <td>7:30 - 9:00</td>
            <td> <asp:LinkButton Font-Underline="false" ID="I1" runat="server" Text="---" OnClick="LinkButtons_Click"></asp:LinkButton> </td>
            <td> <asp:LinkButton Font-Underline="false" ID="I2" runat="server" Text="---" OnClick="LinkButtons_Click"></asp:LinkButton> </td>
            <td> <asp:LinkButton Font-Underline="false" ID="I3" runat="server" Text="---" OnClick="LinkButtons_Click"></asp:LinkButton> </td>
            <td> <asp:LinkButton Font-Underline="false" ID="I4" runat="server" Text="---" OnClick="LinkButtons_Click"></asp:LinkButton> </td>
            <td> <asp:LinkButton Font-Underline="false" ID="I5" runat="server" Text="---" OnClick="LinkButtons_Click"></asp:LinkButton> </td>
            <td> <asp:LinkButton Font-Underline="false" ID="I6" runat="server" Text="---" OnClick="LinkButtons_Click"></asp:LinkButton> </td>
        </tr>
    </table>

    <center>
    <div id="popupDiv">
        <div id="popupInner" style="width: 26.5%;">
            <div id="popupForm">
                <img id="close" src="assets/img/close.png" onclick ="div_hide()" >
                <h2><%=Session["ConsultationDate"]%></h2>
                <hr>    
                <div>
                <table style="">
                    <tr>
                        <td>
                            Nature of Advising:
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td class="">
                            <asp:DropDownList ID="ddlNature" runat="server" CellPadding="10" CellSpacing="10" OnSelectedIndexChanged="ddlNature_SelectedIndexChanged" AutoPostBack="true">
                                <asp:ListItem>Thesis/Design Subject Concerns</asp:ListItem>
                                <asp:ListItem>Mentoring/Clarification on the Topic of the Subjects Enrolled</asp:ListItem>
                                <asp:ListItem>Requirements in Courses Enrolled</asp:ListItem>
                                <asp:ListItem>Concerns about Electives/Track in the Curriculum</asp:ListItem>
                                <asp:ListItem>Concerns on Internship/OJT Matters</asp:ListItem>
                                <asp:ListItem>Concerns regarding Placement Employment Opportunities</asp:ListItem>
                                <asp:ListItem>Concerns regarding Personal/Family etc.</asp:ListItem>
                                <asp:ListItem>Others: </asp:ListItem>
                        </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="">
                            <asp:TextBox Enabled="false" id="txtOthers" placeholder="Please Specify " runat="server" TextMode="MultiLine" Rows="5" Columns="44"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <span> Consultation Code:  <asp:Label ID="lblConCode" runat="server" Text=""></asp:Label></span>
                        </td>
                    </tr>
            </table>
    </div>
    <asp:Literal ID="Literal1" runat="server"></asp:Literal>
    <asp:Button  ID="btnFinalize" runat="server"  Text="Make Appointment" CssClass="btn" OnClick="addAppointment"/>
    </div>
    </div>
    </div>
    </center>


</asp:Content>
