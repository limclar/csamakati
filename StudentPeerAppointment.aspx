<%@ Page Title="Schedule Peer Consultation" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="StudentPeerAppointment.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>



<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script type = "text/javascript">
        function Confirm() {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            if (confirm("Do you really want to schedule an appointment?")) {
                confirm_value.value = "Yes";
            } else {
                confirm_value.value = "No";
            }
            document.forms[0].appendChild(confirm_value);
        }
    </script>
    <h3> Make a Peer Advising Appointment </h3>   
    <hr />   
    <table style="margin-left: 5%; margin-top: -1%;">
        <tr>
            <td style=" width: 10%;">
                <h5>Subject Type : &nbsp; </h5>  
            </td>
            <td style=" width: 25%;">
                <asp:DropDownList  style="width: 60%;" ID="ddlSubjType" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlSubjType_SelectedIndexChanged"></asp:DropDownList>
            </td>
            <td style=" width: 25%; text-align: right;">
                <h5> Topic : </h5>
            </td>
            <td style=" width: 25%; padding-left: 2%;">
                <asp:TextBox Enabled="true" id="txtTopic" placeholder="Consultation Topic" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style=" width: 10%;">
                <h5>Course Code : &nbsp; </h5>  
            </td>
            <td style=" width: 25%;">
                <asp:DropDownList style="width: 60%;" ID="ddlCCode" runat="server"></asp:DropDownList>
            </td>
            <td colspan="2" style=" width: 50%;">
            </td>
        </tr>
        <tr>
            <td style=" width: 10%;">
                <h5>Peer Adviser : &nbsp; </h5> 
            </td>
            <td style=" width: 25%;">
                 <asp:DropDownList style="width: 60%;" ID="ddlPeerAdviser" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlPeerAdviser_SelectedIndexChanged"></asp:DropDownList>
            </td>
            <td colspan="2" style=" width: 50%;">
            </td>
        </tr>
    </table>
    <br /><br />  
    
                        
     <table style="width: 95%; margin-top: -3%;" class="timeTable">
        <tr class="timeTableHeader">
            <th> </th>
            <th>Monday</th>
            <th>Tuesday</th>
            <th>Wednesday</th>
            <th>Thursday</th>
            <th>Friday</th>
            <th>Saturday</th>
        </tr>
        <tr>
            <td class="A">07:30 - 09:00</td>
            <td> <asp:LinkButton Font-Underline="false" ID="A1" runat="server" Text="---" OnClick="LinkButtons_Click"></asp:LinkButton> </td>
            <td> <asp:LinkButton Font-Underline="false" ID="A2" runat="server" Text="---" OnClick="LinkButtons_Click"></asp:LinkButton> </td>
            <td> <asp:LinkButton Font-Underline="false" ID="A3" runat="server" Text="---" OnClick="LinkButtons_Click"></asp:LinkButton> </td>
            <td> <asp:LinkButton Font-Underline="false" ID="A4" runat="server" Text="---" OnClick="LinkButtons_Click"></asp:LinkButton> </td>
            <td> <asp:LinkButton Font-Underline="false" ID="A5" runat="server" Text="---" OnClick="LinkButtons_Click"></asp:LinkButton> </td>
            <td> <asp:LinkButton Font-Underline="false" ID="A6" runat="server" Text="---" OnClick="LinkButtons_Click"></asp:LinkButton> </td>
        </tr>
        <tr>
            <td>09:00 - 10:30</td>
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
            <td>12:00 - 13:30</td>
            <td> <asp:LinkButton Font-Underline="false" ID="D1" runat="server" Text="---" OnClick="LinkButtons_Click"></asp:LinkButton> </td>
            <td> <asp:LinkButton Font-Underline="false" ID="D2" runat="server" Text="---" OnClick="LinkButtons_Click"></asp:LinkButton> </td>
            <td> <asp:LinkButton Font-Underline="false" ID="D3" runat="server" Text="---" OnClick="LinkButtons_Click"></asp:LinkButton> </td>
            <td> <asp:LinkButton Font-Underline="false" ID="D4" runat="server" Text="---" OnClick="LinkButtons_Click"></asp:LinkButton> </td>
            <td> <asp:LinkButton Font-Underline="false" ID="D5" runat="server" Text="---" OnClick="LinkButtons_Click"></asp:LinkButton> </td>
            <td> <asp:LinkButton Font-Underline="false" ID="D6" runat="server" Text="---" OnClick="LinkButtons_Click"></asp:LinkButton> </td>
        </tr>
        <tr>
            <td>13:30 - 15:00</td>
            <td> <asp:LinkButton Font-Underline="false" ID="E1" runat="server" Text="---" OnClick="LinkButtons_Click"></asp:LinkButton> </td>
            <td> <asp:LinkButton Font-Underline="false" ID="E2" runat="server" Text="---" OnClick="LinkButtons_Click"></asp:LinkButton> </td>
            <td> <asp:LinkButton Font-Underline="false" ID="E3" runat="server" Text="---" OnClick="LinkButtons_Click"></asp:LinkButton> </td>
            <td> <asp:LinkButton Font-Underline="false" ID="E4" runat="server" Text="---" OnClick="LinkButtons_Click"></asp:LinkButton> </td>
            <td> <asp:LinkButton Font-Underline="false" ID="E5" runat="server" Text="---" OnClick="LinkButtons_Click"></asp:LinkButton> </td>
            <td> <asp:LinkButton Font-Underline="false" ID="E6" runat="server" Text="---" OnClick="LinkButtons_Click"></asp:LinkButton> </td>
        </tr>
        <tr>
            <td>15:00 - 16:30</td>
            <td> <asp:LinkButton Font-Underline="false" ID="F1" runat="server" Text="---" OnClick="LinkButtons_Click"></asp:LinkButton> </td>
            <td> <asp:LinkButton Font-Underline="false" ID="F2" runat="server" Text="---" OnClick="LinkButtons_Click"></asp:LinkButton> </td>
            <td> <asp:LinkButton Font-Underline="false" ID="F3" runat="server" Text="---" OnClick="LinkButtons_Click"></asp:LinkButton> </td>
            <td> <asp:LinkButton Font-Underline="false" ID="F4" runat="server" Text="---" OnClick="LinkButtons_Click"></asp:LinkButton> </td>
            <td> <asp:LinkButton Font-Underline="false" ID="F5" runat="server" Text="---" OnClick="LinkButtons_Click"></asp:LinkButton> </td>
            <td> <asp:LinkButton Font-Underline="false" ID="F6" runat="server" Text="---" OnClick="LinkButtons_Click"></asp:LinkButton> </td>
        </tr>
        <tr>
            <td>16:30 - 18:00</td>
            <td> <asp:LinkButton Font-Underline="false" ID="G1" runat="server" Text="---" OnClick="LinkButtons_Click"></asp:LinkButton> </td>
            <td> <asp:LinkButton Font-Underline="false" ID="G2" runat="server" Text="---" OnClick="LinkButtons_Click"></asp:LinkButton> </td>
            <td> <asp:LinkButton Font-Underline="false" ID="G3" runat="server" Text="---" OnClick="LinkButtons_Click"></asp:LinkButton> </td>
            <td> <asp:LinkButton Font-Underline="false" ID="G4" runat="server" Text="---" OnClick="LinkButtons_Click"></asp:LinkButton> </td>
            <td> <asp:LinkButton Font-Underline="false" ID="G5" runat="server" Text="---" OnClick="LinkButtons_Click"></asp:LinkButton> </td>
            <td> <asp:LinkButton Font-Underline="false" ID="G6" runat="server" Text="---" OnClick="LinkButtons_Click"></asp:LinkButton> </td>
        </tr>
         
    </table>
    <table style="margin-left: 2%; width: 97%; margin-top: -3%;">
        <tr style="text-align: right;">
            <td>
                <asp:Button ID="btnAppt" runat="server" Text="Make Appointment" OnClientClick = "Confirm()" OnClick="addAppointment"/>
            </td>
        </tr>
    </table>
    
    <asp:Literal ID="Literal1" runat="server"></asp:Literal>
</asp:Content>
