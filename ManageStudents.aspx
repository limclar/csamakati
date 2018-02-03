<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ManageStudents.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h3> Manage Students</h3>   
    <hr />
  

<asp:Panel ID="Panel1" runat="server">
    <table style="width: 100%;">
        <tr>
            <td>
<table style="width: 25%; margin-top: -15%;">
    <tr>
        <td>
            Import Data to Database
            <hr />
        <td>
    <tr>
    <tr>
        <td style="padding-bottom: 5%;">
            Import Type : 
            <asp:DropDownList ID="ddlTable" runat="server" AutoPostBack="true" style="margin: 0% 0% 0% 0%;">
                 <asp:ListItem>GRADES</asp:ListItem>
                 <asp:ListItem>STATUS</asp:ListItem>
                 <asp:ListItem>STUDENT</asp:ListItem>
            </asp:DropDownList>
        </td>
     </tr>
    <tr>
        <td style="padding-bottom: 5%;">
            <asp:FileUpload ID="FileUpload1" runat="server" />
        </td>
    </tr>
    <tr>
        <td style="padding-bottom: 5%;">
            <asp:Button ID="btnUpload" runat="server" Text="Upload" OnClick="btnUpload_Click" style="width: 69%;"/>
        </td>
    </tr>
    </table>
    </td>
    <td>
        <div style="border-left:1px solid #000;height:500px"></div>
    </td>
    <td>
    <table>
        <tr>
        <td>
            Send SMS to Students
            <hr />
        <td>
        <tr>
        <tr>
            <td>
                Student Number : <asp:TextBox id="textStudNo" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                Message Recipients : <asp:TextBox id="textTo" placeholder="To: " runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:TextBox id="TextArea1" TextMode="multiline" Columns="50" Rows="5" runat="server" />
            </td>
        </tr>
        <tr>
            <td style="text-align: right;">
               <asp:Button ID="btnSend" runat="server" Text="Send" OnClick="btnSend_Click"/> 
            </td>
        </tr>
    </table>
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

