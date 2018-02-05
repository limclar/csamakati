<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ManageStudents.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h3> Manage Students</h3>   
    <hr />
  

<asp:Panel ID="Panel1" runat="server">
    <table style="width: 100%;">
    <tr>
    <td style="width: 50%;">
    <table style="margin-left: 15%; margin-top: -15%;">
        <tr>
        <td colspan = "2">
            Send SMS to Students
            <hr />
        <td>
        <tr>
        <tr>
            <td style="text-align: left; padding-bottom: 5%;">
                Student Number : 
            </td>
            <td style="text-align: left; padding-left: 2%; padding-bottom: 5%;">
                <asp:TextBox id="textStudNo" runat="server" OnTextChanged="AddStudent" AutoPostBack="true"/>
            </td>
        </tr>
        <tr>
            <td style="text-align: left; padding-bottom: 5%;">
                Message Recipients : 
            </td>
            <td style="text-align: left; padding-left: 2%; padding-bottom: 5%;">
                <asp:TextBox id="textTo" Enabled="false" placeholder="To: " runat="server" />
            </td>
        </tr>
        <tr>
            <td colspan="2" style="padding-bottom: 5%;">
                <asp:TextBox id="TextArea1" TextMode="multiline" Columns="50" Rows="5" runat="server" />
            </td>
        </tr>
        <tr>
            <td colspan="2" style="text-align: right; margin-top: 2%;">
               <asp:Button ID="btnSend" runat="server" Text="Send" OnClick="btnSend_Click" style="width: 35%;"/> 
            </td>
        </tr>
    </table>
    </td>
    <td>
        <div style="border-left:1px solid #000;height:500px"></div>
    </td>
    <td style="width: 50%;">
    <table style="margin-left: 15%; margin-top: -36%;">
    <tr>
        <td>
            Import Data to Database
            <hr />
        <td>
    <tr>
    <tr>
        <td style="padding-bottom: 7%;">
            Import Type : 
            <asp:DropDownList ID="ddlTable" runat="server" AutoPostBack="true" style="margin: 0% 0% 0% 0%;">
                 <asp:ListItem>GRADES</asp:ListItem>
                 <asp:ListItem>STATUS</asp:ListItem>
                 <asp:ListItem>STUDENT</asp:ListItem>
            </asp:DropDownList>
        </td>
     </tr>
    <tr>
        <td style="padding-bottom: 7%;">
            <asp:FileUpload ID="FileUpload1" runat="server" />
        </td>
    </tr>
    <tr>
        <td style="padding-bottom: 7%;">
            <asp:Button ID="btnUpload" runat="server" Text="Upload" OnClick="btnUpload_Click" style="width: 72%;"/>
        </td>
    </tr>
    </table>
    </td>
    </tr>
    </table>
    <br />
    <asp:GridView CssClass="GridHeader" Visible="true" ID="GridView1" runat="server" AutoGenerateColumns = "false" Font-Names = "Arial" Font-Size = "11pt" AllowPaging ="false" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
    <Columns>
   </Columns>
</asp:GridView>
     
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

