<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ManageStudents.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h3> Manage Students</h3>   
    <hr />
  

<asp:Panel ID="Panel1" runat="server">
<table style="width: 25%;">
    <tr style="padding-bottom: 2%;">
        <td>
            Import Type : 
            <asp:DropDownList ID="ddlTable" runat="server" AutoPostBack="true" style="margin: 0% 0% 0% 0%;">
                 <asp:ListItem>GRADES</asp:ListItem>
                 <asp:ListItem>STATUS</asp:ListItem>
                 <asp:ListItem>STUDENT</asp:ListItem>
            </asp:DropDownList>
        </td>
     </tr>
    <tr style="padding-bottom: 2%;">
        <td style="width: 10%;">
            <asp:FileUpload ID="FileUpload1" runat="server" />
        </td>
    </tr>
    <tr style="padding-bottom: 2%;">
        <td style="width: 10%;">
            <asp:Button ID="btnUpload" runat="server" Text="Upload" OnClick="btnUpload_Click" style="width: 69%;"/>
        </td>
    </tr>
</table>
    <br />
     
    <asp:Label ID="Label1" runat="server" Text="" />
 </asp:Panel>

<asp:Panel ID="Panel2" runat="server" Visible = "false" >
    <asp:Label ID="Label5" runat="server" Text="Filu Name"/>
    <br />

    <br />

    <br />
    <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
    <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />       

 </asp:Panel>

</asp:Content>

