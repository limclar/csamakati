<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="FacultyVerifyAppointment.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <h3> Verify Appointment </h3>   
    <hr />   
    <br />
    <div>
    <table style="width: 100%; margin-left: 0em;">
        <tr ID="panSearch" runat="server">
            <td style="padding-bottom: 2%;">
                Consultation Code :
            </td>
            <td style="padding-bottom: 2%; text-align: left">
                <asp:Panel DefaultButton="btnSearchAppt">
                    <asp:TextBox ID="tboxConCode" runat="server" placeholder="Consultation Code" style="width: 50%; text-transform:uppercase; margin: 0em 0em 0em 0em;" />
                    <asp:Button ID="btnSearchCon" runat="server" Text="" Visible="true" OnClick="btnSearchCon_Click" style="float: left; background-color: #fcefef; cursor: default; height: 0.1px; width: 0.1px; margin: 0em;    "/>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td style="padding-bottom: 2%;">
                Student Number : 
            </td>
            <td style="padding-bottom: 2%;">
                <asp:TextBox style="width: 50%;" ID="tboxStudentNumber" runat="server" placeholder="STUDENT NUMBER" ></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="padding-bottom: 2%;">
                Student Name : 
            </td>
            <td style="padding-bottom: 2%;">
                <asp:TextBox style="width: 50%;" ID="tboxStudentName" runat="server" placeholder="STUDENT NAME" Enabled="false"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="padding-bottom: 2%;">
                Action Taken :
            </td>
            <td style="padding-bottom: 2%;">
                <asp:RadioButtonList ID="rbtnActTaken" runat="server" CellPadding="10" CellSpacing="10" RepeatDirection="Horizontal" RepeatLayout="Flow" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged" AutoPostBack="true">
                        <asp:ListItem>Resolved</asp:ListItem>
                        <asp:ListItem>For Follow Up</asp:ListItem>
                        <asp:ListItem>Referred to:</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td>
                Department :
            </td>
            <td style="padding-bottom: 2%;">
                <asp:DropDownList Enabled="false" ID="ddlDepartment" runat="server" OnSelectedIndexChanged="ddlDepartment_SelectedIndexChanged" AutoPostBack="true">
                    <asp:ListItem>Peer Advising</asp:ListItem>
                    <asp:ListItem>Counseling</asp:ListItem>
                    <asp:ListItem>Career Advising</asp:ListItem>
                    <asp:ListItem>Others : </asp:ListItem>
                </asp:DropDownList> 
                <asp:TextBox ID="tboxDeptOthers" Enabled="false" runat="server" style="width: 49%;"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="padding-bottom: 2%;">
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
            <td style="text-align: center;" colspan="3">
                <asp:Button ID="btnRecord"  style="width:35%;" runat="server" Text="Record" OnClick="btnRecord_Click"/>
            </td>
        </tr>
    </table>
    <asp:Literal ID="literalMsg" runat="server" />
</div>
</asp:Content>
