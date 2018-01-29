<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="StudentPeerAppointment.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>



<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h3> Make a Peer Advising Appointment </h3>   
    <hr />   
    <table style="margin-left: 5%;">
        <tr>
            <td style=" width: 10%;">
                <h5>Subject Type : &nbsp; </h5>  
            </td>
            <td>
                <asp:DropDownList  style="width: 20%;" ID="ddlSubjType" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlSubjType_SelectedIndexChanged"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                <h5>Course Code : &nbsp; </h5>  
            </td>
            <td>
                <asp:DropDownList style="width: 20%;" ID="ddlCCode" runat="server"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                <h5>Peer Adviser : &nbsp; </h5> 
            </td>
            <td>
                 <asp:DropDownList style="width: 20%;" ID="ddlPeerAdviser" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlPeerAdviser_SelectedIndexChanged"></asp:DropDownList>
            </td>
        </tr>
    </table>
    <br /><br />  
    
                        
     <table style="width: 95%; margin-top: -1%;" class="timeTable">
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
         <tr style="border-bottom-style: none;">
            <td colspan="9" style="background-color: white; border-style: none; border-top-style: solid;">
                <asp:Button style="float: right" ID="btnAppt" runat="server" Text="Make Appointment" OnClick="addAppointment"/>
            </td>
        </tr>
    </table>
    <asp:Literal ID="Literal1" runat="server"></asp:Literal>
</asp:Content>
