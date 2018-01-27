<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="StaffDashboard.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h3> Peer Advising Consultations </h3>   
    <hr />  
        <table class="sdTable">
            <tr>
                <asp:DropDownList id="ddlType" AutoPostBack="True" OnSelectedIndexChanged="Type_Change" runat="server">
                  <asp:ListItem Selected="True" Value="All"> All </asp:ListItem>
                  <asp:ListItem Value="Appointment"> Appointment </asp:ListItem>
                  <asp:ListItem Value="Walk-in"> Walk-in </asp:ListItem>
               </asp:DropDownList>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnToday" runat="server" AutoPostBack="true" OnClick="Btn_Click" Text="Button" CssClass="apptCount" style="background-color: red; color: white; "/>
                </td>
                <td>
                    <asp:Button ID="btnWeek" runat="server" Text="Button" AutoPostBack="true" OnClick="Btn_Click" CssClass="apptCount" style="background-color: blue; color: white;"/>
                </td>
                <td>
                    <asp:Button ID="btnMonth" runat="server" Text="Button" AutoPostBack="true" OnClick="Btn_Click" CssClass="apptCount" style="background-color: darkgreen; "/>
                </td>
            </tr>
            <tr>
                <td>
                    <h4> Today </h4>
                </td>
                <td>
                    <h4> This Week </h4>
                </td>
                <td>
                    <h4> This Month </h4>
                </td>
            </tr>      
        </table>
        <br />
        <div style="margin-top: -5%;">  
        <script type="text/javascript" src="https://www.google.com/jsapi"></script>  
        <br />  
        <br />  
        <asp:Literal ID="ltScripts" runat="server"></asp:Literal>  
        <div id="piechart_3d" style="width: 540px; height: 300px;">
            <asp:GridView ID="gvData" runat="server" Visible="false">  
        </asp:GridView>
        </div>  
    </div>              
</asp:Content>
