<%@ Page Title="Dashboard" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="StaffDashboard.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h3> Peer Advising Consultations </h3>   
    <hr />  
        <table style="margin-bottom: 2%;">
            <tr>
                <td style="text-align: left; width: 15%;">
                    Consultation Type :
                </td>
                <td style="text-align: left; padding-left: 2%;">
                    <asp:DropDownList id="ddlType" AutoPostBack="True" OnSelectedIndexChanged="Type_Change" runat="server">
                      <asp:ListItem Selected="True" Value="All"> All </asp:ListItem>
                      <asp:ListItem Value="Appointment"> Appointment </asp:ListItem>
                      <asp:ListItem Value="Walk-in"> Walk-in </asp:ListItem>
                   </asp:DropDownList>
                </td>
            </tr>
        </table>
        <table class="sdTable">
            <tr>
                <td>
                    <asp:Button ID="btnToday" runat="server" AutoPostBack="true" OnClick="Btn_Click" Text="Button" CssClass="apptCount" style="background-color: red; color: white; "/>
                </td>
                <td>
                    <asp:Button ID="btnWeek" runat="server" Text="Button" AutoPostBack="true" OnClick="Btn_Click" CssClass="apptCount" style="background-color: blue; color: white;"/>
                </td>
                <td>
                    <asp:Button ID="btnMonth" runat="server" Text="Button" AutoPostBack="true" OnClick="Btn_Click" CssClass="apptCount" style="background-color: darkgreen; color: white; "/>
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
        <script type="text/javascript" src="https://www.google.com/jsapi"></script> 
        <table style="margin-top: -5%;">
            <tr>
                <td>
                    <asp:Literal ID="ltScripts" runat="server"></asp:Literal>  
                    <div id="piechart_3d" style="width: 540px; height: 300px;">
                    </div> 
                    <asp:GridView ID="gvData" runat="server" Visible="false">  
                    </asp:GridView>
                </td>
                <td>
                    <asp:Literal ID="ltScripts2" runat="server"></asp:Literal>  
                    <div id="chart_div" style="width: 540px; height: 350px; margin-top: 7%;"></div>
                    <asp:GridView ID="gvData2" runat="server" Visible="false">  
                    </asp:GridView> 
                </td>
            </tr>
        </table>
    </div>              
</asp:Content>
