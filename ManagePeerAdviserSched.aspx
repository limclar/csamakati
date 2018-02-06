<%@ Page Title="Peer Adviser Schedule" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ManagePeerAdviserSched.aspx.cs" Inherits="_Default" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h3> Manage Peer Adviser's Schedule </h3>   
    <hr />

    <table style="margin-left: 2%; width: 95%;">
        <tr>
           <td style="width: 10%">
              <h5> Peer Adviser : </h5>
           </td>
           <td>
              <asp:DropDownList  ID="ddl" runat="server" OnSelectedIndexChanged="ddl_SelectedIndexChanged" OnTextChanged="ddl_TextChanged" AutoPostBack="True" ></asp:DropDownList>
           </td>
        </tr>
    </table>

    <!-- Time table with AVAILABILITY INSIDE THE CELLS -->

    <table style="width: 95%; margin: 1% 1em 0em 1.5em;" class="timeTable" id="schedule" runat="server">
    <tbody style="border-style: none;">
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
        </tbody>
    </table>
    <table style="margin-left: 2%; width: 95%;">
        <tr style="text-align: right;">
            <td>
                <asp:Button ID="btnFinalizeSched" runat="server" Text="Finalize Schedule" style="float: right;" OnClick="btnFinalizeSched_Click"></asp:Button> 
            </td>
        </tr>
    </table>

    <center>
    <div id="popupDiv">
        <div id="popupInner" style="width: 26.5%;">
            <div id="popupForm">
                <img id="close" src="assets/img/close.png" onclick ="div_hide()" >
                <h2>Set Availability</h2>
                <hr>
                <div>
                <table style="width: 100%; margin-left: -5.5em;">
                <tr>
                    <td>
                        <asp:RadioButtonList ID="RadioButtonList1" runat="server" CellPadding="10" CellSpacing="10" RepeatDirection="Horizontal" RepeatLayout="Flow">
                            <asp:ListItem style="margin-right: 5em;"> AVAILABLE </asp:ListItem>
                            <asp:ListItem> UNAVAILABLE </asp:ListItem>
                    </asp:RadioButtonList>
                    </td>
                </tr>
            
            </table>
    </div>
    <asp:Literal ID="Literal1" runat="server"></asp:Literal>
    </div>
    </div>
    </div>
    </center>
</asp:Content>
