<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ReportGeneration.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h3> Reports Generation </h3>   
    <hr />   
     <table style="margin-bottom: 2%;">
            <tr>
                <td style="text-align: left; width: 15%;">
                    Report Type :
                </td>
                <td style="text-align: left; padding-left: 2%;">
                    <asp:DropDownList id="ddlType" AutoPostBack="True" OnSelectedIndexChanged="Type_Change" runat="server">
                      <asp:ListItem Selected="True" Value="1"> One </asp:ListItem>
                      <asp:ListItem Value="2"> Two </asp:ListItem>
                      <asp:ListItem Value="3"> Three </asp:ListItem>
                   </asp:DropDownList>
                </td>
            </tr>
    </table>
    <asp:GridView  ID="GridView1" runat="server" AutoGenerateColumns = "false" Font-Names = "Arial" Font-Size = "11pt" HeaderStyle-BackColor = "#FFDAB9" AllowPaging ="true">

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

<asp:Button style="margin-left: 9em;" ID="btnExportToExcel" runat="server"  Text="Export to Excel" CssClass="btn" OnClick="btnExportToExcel_Click"/>
</asp:Content>
