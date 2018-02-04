<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="FacultyVerifyAppointment.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <h3> Verify Appointment </h3>   
    <hr />   
    <br />
    <div>
    <table style="width: 100%; background-color: #f2f2f2; border: 2px solid #ccc;">
        <tr ID="panSearch" runat="server">
            <td style="padding-bottom: 2%; width: 40%; text-align: right; padding-top: 3%; padding-right: 5%;">
                Consultation Code :
            </td>
            <td style="padding-bottom: 2%; text-align: left; padding-top: 3%;">
                    <asp:TextBox autocomplete="off" ID="tboxConCode" runat="server"  placeholder="Consultation Code" style="width: 63.25%; text-transform:uppercase; " />
            </td>
        </tr>
        <tr>
            <td style="padding-bottom: 2%; text-align: right; padding-right: 5%;">
                Student Number : 
            </td>
            <td style="padding-bottom: 2%;">
                <asp:TextBox autocomplete="off" style="width: 63.25%;" AutoPostBack="true" OnTextChanged="btnSearchCon_Click" ID="tboxStudentNumber" runat="server" placeholder="Student Number" ></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="padding-bottom: 2%; text-align: right; padding-right: 5%;">
                Student Full Name : 
            </td>
            <td style="padding-bottom: 2%;">
                <asp:TextBox style="width: 63.25%;" ID="tboxStudentName" runat="server" placeholder="Student Name" Enabled="false"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="padding-bottom: 2%; text-align: right; padding-right: 5%;">
                Action Taken :
            </td>
            <td style="padding-bottom: 2%;">
                <asp:RadioButtonList ID="rbtnActTaken" runat="server" CellPadding="10" CellSpacing="10" RepeatDirection="Horizontal" RepeatLayout="Flow" style="width: 100%;" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged" AutoPostBack="true">
                        <asp:ListItem style="margin-right: 5%;">Resolved</asp:ListItem>
                        <asp:ListItem style="margin-right: 5%;">For Follow Up</asp:ListItem>
                        <asp:ListItem style="margin-right: 5%;">Referred to:</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td style="padding-bottom: 2%; text-align: right; padding-right: 5%;">
               Referred To :
            </td>
            <td style="padding-bottom: 2%;">
                <asp:DropDownList Enabled="false" ID="ddlDepartment" runat="server" OnSelectedIndexChanged="ddlDepartment_SelectedIndexChanged" AutoPostBack="true">
                    <asp:ListItem>Peer Advising</asp:ListItem>
                    <asp:ListItem>Counseling</asp:ListItem>
                    <asp:ListItem>Career Advising</asp:ListItem>
                    <asp:ListItem>Others : </asp:ListItem>
                </asp:DropDownList> 
                <asp:TextBox ID="tboxDeptOthers" Enabled="false" runat="server" style="width: 42.5%;"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="padding-bottom: 2%; text-align: right; padding-right: 5%;">
                Nature of Advising : 
            </td>
            <td style="padding-bottom: 2%;">
                <asp:DropDownList ID="ddlNature" runat="server" CellPadding="10" CellSpacing="10" style=" margin: 0em 0em 0em 0em;">
                                <asp:ListItem>Thesis/Design Subject Concerns</asp:ListItem>
                                <asp:ListItem>Mentoring/Clarification on the Topic of the Subjects Enrolled</asp:ListItem>
                                <asp:ListItem>Requirements in Courses Enrolled</asp:ListItem>
                                <asp:ListItem>Concerns about Electives/Track in the Curriculum</asp:ListItem>
                                <asp:ListItem>Concerns on Internship/OJT Matters</asp:ListItem>
                                <asp:ListItem>Concerns regarding Placement/Employment Opportunities</asp:ListItem>
                                <asp:ListItem>Concerns regarding Personal/Family etc.</asp:ListItem>
                                <asp:ListItem>Others: </asp:ListItem>
                 </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="text-align: center; padding-bottom: 3%;" colspan="3">
                <asp:Button ID="btnRecord"  style="width:15%;" runat="server" Text="Record" OnClick="btnRecord_Click"/>
            </td>
        </tr>
    </table>
    <asp:Literal ID="literalMsg" runat="server" />
</div>
</asp:Content>
