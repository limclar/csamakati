<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ReportGeneration.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h3> Reports Generation </h3>   
    <hr />
     <table style="margin-bottom: 2%;">
            <tr>
                <td style="text-align: left; width: 15%;">
                     Type :
                </td>
                <td style="text-align: left; padding-left: 2%;">
                    <asp:DropDownList id="ddlRep" AutoPostBack="True" OnSelectedIndexChanged="GV_Change" runat="server">
                      <asp:ListItem Selected="True"> Report for Z </asp:ListItem>
                      <asp:ListItem> Peer Advisees Assisted - EE </asp:ListItem>
                      <asp:ListItem> Peer Adviser's Rank Report - FF </asp:ListItem>
                      <asp:ListItem> Evaluation Survey Report - GG  </asp:ListItem>
                      <asp:ListItem> List of Peer Advisers - R  </asp:ListItem>
                      <asp:ListItem> List of Academic Adviser Assignment - S  </asp:ListItem>
                      <asp:ListItem> Academic Advisers Slip per Adviser - X  </asp:ListItem>
                      <asp:ListItem> Academic Advisers Slip  per Department  - Y  </asp:ListItem>
                   </asp:DropDownList>
                </td>
                <td style="text-align: left; width: 15%;">
                    Report Type :
                </td>
                <td style="text-align: left; padding-left: 2%;">
                    <asp:DropDownList id="ddlType" AutoPostBack="True" OnSelectedIndexChanged="Type_Change" runat="server">
                      <asp:ListItem Selected="True" Value="1"> PEER </asp:ListItem>
                      <asp:ListItem Value="2"> EWP </asp:ListItem>
                      <asp:ListItem Value="3"> CARE </asp:ListItem>
                      <asp:ListItem Value="4"> PLAN AHEAD </asp:ListItem>
                   </asp:DropDownList>
                </td>
            </tr>
    </table>
<asp:GridView  ID="GridViewZ" runat="server" AutoGenerateColumns = "false" Font-Names = "Arial" Font-Size = "11pt" HeaderStyle-BackColor = "#FFDAB9" AllowPaging ="false" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
    <Columns>
    <asp:BoundField ItemStyle-Width = "150px" DataField = "StudentNumber" HeaderText = "Student Number"/>
    <asp:BoundField ItemStyle-Width = "150px" DataField = "StudentName" HeaderText = "Student Name" />
    <asp:BoundField ItemStyle-Width = "150px" DataField = "Count" HeaderText = "Number of Session"/>
    <asp:BoundField ItemStyle-Width = "150px" DataField = "Program" HeaderText = "Program"/>
    <asp:BoundField ItemStyle-Width = "150px" DataField = "ConsultationDate" HeaderText = "Date"/>
    <asp:BoundField ItemStyle-Width = "150px" DataField = "TimeStart" HeaderText = "Time Start"/>
    <asp:BoundField ItemStyle-Width = "150px" DataField = "TimeEnd" HeaderText = "Time End"/>
    <asp:BoundField ItemStyle-Width = "150px" DataField = "CourseCode" HeaderText = "Subject"/>
    <asp:BoundField ItemStyle-Width = "150px" DataField = "Grade" HeaderText = "Grade"/>
    <asp:BoundField ItemStyle-Width = "150px" DataField = "Remarks" HeaderText = "Remarks" SortExpression="Remarks"/>
    <asp:BoundField ItemStyle-Width = "150px" DataField = "SYTerm" HeaderText = "SYTerm"/>
    <asp:BoundField ItemStyle-Width = "150px" DataField = "AcademicStatus" HeaderText = "Academic Status"/>
    <asp:BoundField ItemStyle-Width = "150px" DataField = "PAdviserId" HeaderText = "Peer Adviser"/>
   </Columns>
</asp:GridView>
    
<asp:GridView  ID="GridViewEE" Visible="false" runat="server" AutoGenerateColumns = "false" Font-Names = "Arial" Font-Size = "11pt" HeaderStyle-BackColor = "#FFDAB9" AllowPaging ="false" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
    <Columns>
    <asp:BoundField ItemStyle-Width = "150px" DataField = "Adviser" HeaderText = "Adviser"/>
    <asp:BoundField ItemStyle-Width = "150px" DataField = "Sessions" HeaderText = "Sessions" />
    <asp:BoundField ItemStyle-Width = "150px" DataField = "Advisees" HeaderText = "Advisees"/>
    <asp:BoundField ItemStyle-Width = "150px" DataField = "Sessions (70%)" HeaderText = "Sessions (70%)"/>
    <asp:BoundField ItemStyle-Width = "150px" DataField = "Advisees (30%)" HeaderText = "Advisees (30%)"/>
    <asp:BoundField ItemStyle-Width = "150px" DataField = "Total (100%)" HeaderText = "Total (100%)"/>
    <asp:BoundField ItemStyle-Width = "150px" DataField = "Number of Advisees Assisted (30%)" HeaderText = "Number of Advisees Assisted (30%)"/>
    <asp:BoundField ItemStyle-Width = "150px" DataField = "Actual" HeaderText = "Actual"/>
   </Columns>
</asp:GridView>
    
<asp:GridView Visible="false" ID="GridViewFF" runat="server" AutoGenerateColumns = "false" Font-Names = "Arial" Font-Size = "11pt" HeaderStyle-BackColor = "#FFDAB9" AllowPaging ="false" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
    <Columns>
    <asp:BoundField ItemStyle-Width = "150px" DataField = "Rank" HeaderText = "Rank"/>
    <asp:BoundField ItemStyle-Width = "150px" DataField = "StudentName" HeaderText = "Name" />
    <asp:BoundField ItemStyle-Width = "150px" DataField = "Organization" HeaderText = "Organization"/>
    <asp:BoundField ItemStyle-Width = "150px" DataField = "Subject" HeaderText = "Subject"/>
    <asp:BoundField ItemStyle-Width = "150px" DataField = "Attendance on Declared Schedule (30%)" HeaderText = "Attendance on Declared Schedule (30%)"/>
    <asp:BoundField ItemStyle-Width = "150px" DataField = "Evaluation of Peer Advisees (20%)" HeaderText = "Evaluation of Peer Advisees (20%)"/>
    <asp:BoundField ItemStyle-Width = "150px" DataField = "Participation in PA Activity (20%)" HeaderText = "Participation in PA Activity (20%)"/>
    <asp:BoundField ItemStyle-Width = "150px" DataField = "Number of Peer Advisees Assisted (30%)" HeaderText = "Number of Peer Advisees Assisted (30%)"/>
    <asp:BoundField ItemStyle-Width = "150px" DataField = "Total (100%)" HeaderText = "Total (100%)"/>
    </Columns>
</asp:GridView>
    
<asp:GridView Visible="false" ID="GridViewGG" runat="server" AutoGenerateColumns = "false" Font-Names = "Arial" Font-Size = "11pt" HeaderStyle-BackColor = "#FFDAB9" AllowPaging ="false" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
    <Columns>
    <asp:BoundField ItemStyle-Width = "150px" DataField = "Adviser" HeaderText = "Adviser"/>
    <asp:BoundField ItemStyle-Width = "150px" DataField = "Advisee" HeaderText = "Advisee" />
    <asp:BoundField ItemStyle-Width = "150px" DataField = "Mastery" HeaderText = "Mastery"/>
    <asp:BoundField ItemStyle-Width = "150px" DataField = "Respect" HeaderText = "Respect"/>
    <asp:BoundField ItemStyle-Width = "150px" DataField = "Encourage Advisee" HeaderText = "Encourage Advisee"/>
    <asp:BoundField ItemStyle-Width = "150px" DataField = "Manage Advisee's Records Properly" HeaderText = "Manage Advisee's Records Properly"/>
    <asp:BoundField ItemStyle-Width = "150px" DataField = "Shares Learning Techniques Unselfishly" HeaderText = "Shares Learning Techniques Unselfishly"/>
    <asp:BoundField ItemStyle-Width = "150px" DataField = "Total" HeaderText = "Total"/>
   </Columns>
</asp:GridView>
    
<asp:GridView Visible="false" ID="GridViewR" runat="server" AutoGenerateColumns = "false" Font-Names = "Arial" Font-Size = "11pt" HeaderStyle-BackColor = "#FFDAB9" AllowPaging ="false" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
    <Columns>
    <asp:BoundField ItemStyle-Width = "150px" DataField = "Name" HeaderText = "Name"/>
    <asp:BoundField ItemStyle-Width = "150px" DataField = "Subject Taught" HeaderText = "Subject Taught" />
    <asp:BoundField ItemStyle-Width = "150px" DataField = "Program" HeaderText = "Program"/>
    <asp:BoundField ItemStyle-Width = "150px" DataField = "Organization" HeaderText = "Organization"/>
   </Columns>
</asp:GridView>
    
<asp:GridView Visible="false" ID="GridViewS" runat="server" AutoGenerateColumns = "false" Font-Names = "Arial" Font-Size = "11pt" HeaderStyle-BackColor = "#FFDAB9" AllowPaging ="false" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
    <Columns>
    <asp:BoundField ItemStyle-Width = "150px" DataField = "StudentNumber" HeaderText = "Student #"/>
    <asp:BoundField ItemStyle-Width = "150px" DataField = "StudentName" HeaderText = "Student Name" />
    <asp:BoundField ItemStyle-Width = "150px" DataField = "Program" HeaderText = "Program"/>
    <asp:BoundField ItemStyle-Width = "150px" DataField = "AcademicAdviser" HeaderText = "Academic Adviser"/>
   </Columns>
</asp:GridView>
    
<asp:GridView Visible="false" ID="GridViewX" runat="server" AutoGenerateColumns = "false" Font-Names = "Arial" Font-Size = "11pt" HeaderStyle-BackColor = "#FFDAB9" AllowPaging ="false" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
    <Columns>
    <asp:BoundField ItemStyle-Width = "150px" DataField = "Date" HeaderText = "Student #"/>
    <asp:BoundField ItemStyle-Width = "150px" DataField = "StudentName" HeaderText = "Student Name" />
    <asp:BoundField ItemStyle-Width = "150px" DataField = "StudentNumber" HeaderText = "Student Number"/>
    <asp:BoundField ItemStyle-Width = "150px" DataField = "Program" HeaderText = "Program"/>
    <asp:BoundField ItemStyle-Width = "150px" DataField = "NatureOfAdvising" HeaderText = "Nature of Advising"/>
    <asp:BoundField ItemStyle-Width = "150px" DataField = "ActionTaken" HeaderText = "Action Taken"/>
    <asp:BoundField ItemStyle-Width = "150px" DataField = "Academic Adviser" HeaderText = "Academic Adviser"/>
   </Columns>
</asp:GridView>
<asp:Button style="margin-left: 9em;" ID="btnExportToExcel" runat="server"  Text="Export to Excel" CssClass="btn" OnClick="btnExportToExcel_Click"/>
        </asp:Content>
