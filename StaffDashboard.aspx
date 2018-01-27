<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="StaffDashboard.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h3> Peer Advising Appointments </h3>   
    <hr />  
        <table class="sdTable">
            <tr>
                <td>
                    <asp:Button ID="btnToday" runat="server" Text="Button" CssClass="apptCount" style="background-color: red; color: white; "/>
                </td>
                <td>
                    <asp:Button ID="btnWeek" runat="server" Text="Button" CssClass="apptCount" style="background-color: blue; color: white;"/>
                </td>
                <td>
                    <asp:Button ID="btnMonth" runat="server" Text="Button" CssClass="apptCount" style="background-color: darkgreen; "/>
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
    <!--
    <table>
        <tr>
            <td>
                <asp:Chart ID="Chart1" runat="server">
                    <Series>
                        <asp:Series Name="Series1" XValueMember="Status" YValueMembers="Count"></asp:Series>
                    </Series>
                           <ChartAreas>
                            <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
                     </ChartAreas>
                    </asp:Chart>
            </td>
            <td>
                 <asp:ListView ID="test1" runat="server" OnItemDataBound="test1_ItemDataBound"> 
            <EmptyDataTemplate>
                <td>
                    fuck
                </td>
            </EmptyDataTemplate>
            <ItemTemplate>
                <tr>
                    
                </tr>
            </ItemTemplate>
            <LayoutTemplate>
            <div>
                <tr runat="server">
                    <td runat="server">
                        <table id="itemPlaceholderContainer" runat="server" class="viewTable" cellspacing="12">
                            <center>
                            <tr>
                                <th width="100px"> Subject </th>
                                <th width="100px"> Adviser ID </th>
                                <th width="100px"> Student Number </th>
                                <th width="100px"> Full Name </th>
                                <th width="100px"> Organization </th>
                                <th width="100px"> Status </th>
                                <th width="100px"> Date Registered </th>
                                <th width="100px"> Contact </th>
                                <th width="200px"> Edit </th>
                                <th width="200px"> Remove </th>
                            </tr>
                            </center>
                            <tr id="itemPlaceholder" runat="server">
                            </tr>
                        </table>
                    </td>
                </tr>  
            </div>
            </LayoutTemplate>
    </asp:ListView>
        </td>
    </tr>
    </table>-->
    <br />
                        
    <!-- Time Table for the Week clickable student numbers on the table -->
                        
</asp:Content>