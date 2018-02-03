<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ReportGeneration.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h3> Reports Generation </h3>   
    <hr />
    <form runat="server">
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
    
<asp:GridView Visible="false" ID="GridViewEE" runat="server" AutoGenerateColumns = "false" Font-Names = "Arial" Font-Size = "11pt" HeaderStyle-BackColor = "#FFDAB9" AllowPaging ="false" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
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

<asp:Button style="margin-left: 9em;" ID="btnExportToExcel" runat="server"  Text="Export to Excel" CssClass="btn" OnClick="btnExportToExcel_Click"/>
    </form>
        </asp:Content>
