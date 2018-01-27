<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="StaffSessionAttendance.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>



<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h2> Session Attendance </h2>   
    <hr />   
    <br /><br />
    <!-- Sorted table for each department prof View/Edit/Delete -->
        <asp:ListView ID="ListViewSAttendance" runat="server">
            <EmptyDataTemplate>
            <div>
                <tr runat="server">
                    <td runat="server">
                        <table id="itemPlaceholderContainer" runat="server" class="viewTable" cellspacing="12">
                            <center>
                            <tr>
                                <th width="200px"> Appointment Type </th>
                                <th width="200px"> Course Code </th>
                                <th width="200px"> Peer Adviser </th>
                                <th width="200px"> Peer Adviser 2 </th>
                                <th width="200px"> Peer Adviser 3 </th>
                                <th width="200px"> Time Start </th>
                                <th width="200px"> Time End </th>
                                <th width="200px" colspan="2"> Start / End </th>
                                <th width="200px" colspan="2"> Edit / Cancel </th>
                            </tr>
                            </center>
                            <tr id="itemPlaceholder" runat="server">
                            </tr>
                        </table>
                    </td>
                </tr>  
            </div>
            </EmptyDataTemplate>
            <InsertItemTemplate>
                <center>
                    <table>
                        <tr>
                            <td>
                                Queenteka
                            </td>
                        </tr>
                     </table>
                </center>
            </InsertItemTemplate>
            <ItemTemplate>
                        <tr runat="server">
                            <td>
                                <asp:Label runat="server" Text='<%# Eval("ConsultationType") %>' />
                            </td>
                            <td>
                                <asp:Label ID="Proj_NameLabel" runat="server" Text='<%# Eval("CourseCode") %>' />
                            </td>
                            <td>
                                <asp:Label ID="Label1" runat="server" Text='<%#Class2.getSingleData("SELECT dbo.Student.StudentName FROM dbo.PeerAdviser INNER JOIN dbo.Student ON dbo.PeerAdviser.StudentNumber = dbo.Student.StudentNumber where dbo.PeerAdviser.PAdviserId = "+Eval("PAdviserId")) %>' />
                            </td>
                            <td>
                                <asp:Label ID="Label2" runat="server" Text='<%# Class2.getSingleData("SELECT dbo.Student.StudentName FROM dbo.PeerAdviser INNER JOIN dbo.Student ON dbo.PeerAdviser.StudentNumber = dbo.Student.StudentNumber where dbo.PeerAdviser.PAdviserId = "+Eval("PeerAdviser2")) %>' />
                            </td>
                            <td>
                                <asp:Label ID="Label3" runat="server" Text='<%# Class2.getSingleData("SELECT dbo.Student.StudentName FROM dbo.PeerAdviser INNER JOIN dbo.Student ON dbo.PeerAdviser.StudentNumber = dbo.Student.StudentNumber where dbo.PeerAdviser.PAdviserId = "+Eval("PeerAdviser3")) %>' />
                            </td>
                            <td>
                                <asp:Label ID="Label4" runat="server" Text='<%# Eval("TimeStart") %>' />
                            </td>
                            <td>
                                <asp:Label ID="Label5" runat="server" Text='<%# Eval("TimeEnd") %>' />
                            </td>

                            

                            <td class="pic">    
                                <asp:LinkButton ID="btnUpdateTimeStart" runat="server" OnClick="btnUpdateTimeStart_Click">
                                    <img src="assets/img/start.png" />
                                </asp:LinkButton>
                            </td>
                            <td class="pic">
                                <asp:LinkButton ID="btnUpdateTimeEnd" runat="server" OnClick="btnUpdateTimeEnd_Click">
                                    <img src="assets/img/stop.png" />
                                </asp:LinkButton>
                            </td>

                            

                            <td class="pic">    
                                <asp:LinkButton ID="btnUpdateSession" runat="server" OnClick="btnUpdateSession_Click">
                                    <img src="assets/img/viewIcon.png" onclick="div_show()"/>
                                </asp:LinkButton>
                            </td>
                            <td class="pic">
                                <asp:HyperLink runat="server" NavigateUrl="hhtp://isms.com.my/isms_send.php?un=xxxx&pwd=xxxx&dstno=xxxx&msg=xxxxx&type=1&sendid=xxxx">

                                </asp:HyperLink>
                                <asp:LinkButton ID="btnCancelSession" runat="server" OnClick="btnCancelSession_Click">
                                    <img src="assets/img/closeIcon.png" />
                                </asp:LinkButton>
                            </td>
                        </tr>     
            </ItemTemplate>
            <LayoutTemplate>
            <div>
                <tr runat="server">
                    <td runat="server">
                        <table id="itemPlaceholderContainer" runat="server" class="viewTable" cellspacing="12">
                            <center>
                            <tr>
                                <th width="200px"> Appointment Type </th>
                                <th width="200px"> Course Code </th>
                                <th width="200px"> Peer Adviser </th>
                                <th width="200px"> Peer Adviser 2 </th>
                                <th width="200px"> Peer Adviser 3 </th>
                                <th width="200px"> Time Start </th>
                                <th width="200px"> Time End </th>
                                <th width="200px" colspan="2"> Start / End </th>
                                <th width="200px" colspan="2"> Edit / Cancel </th>
                            </tr>
                            </center>
                            <tr id="itemPlaceholder" runat="server">
                            </tr>
                        </table>
                    </td>
                </tr>  
            </div>
            </LayoutTemplate>
            <SelectedItemTemplate>
                <center>
                    <table>
                        <tr>
                            <td>
                                Queenteka
                            </td>
                        </tr>
                     </table>
                </center>
            </SelectedItemTemplate>
    </asp:ListView>

    <center>
    <div id="popupDiv">
        <div id="popupInner" style="width: 30%; margin-left:-15%;">
            <div id="popupForm">
                <img id="close" src="assets/img/close.png" onclick ="div_hide()" >
                <h3>Update Peer Adviser</h3>
                <hr>
                <div>
                <table style="width: 85%; margin-left: 5%;">
                <tr>
                    <td>
                        <b> Peer Adviser 1 : </b>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlPA1" runat="server" CssClass="ddl" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <b> Peer Adviser 2 : </b>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlPA2" runat="server" CssClass="ddl" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <b> Peer Adviser 3 : </b>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlPA3" runat="server" CssClass="ddl" />
                    </td>
                </tr>
            </table>
    </div>
    <asp:Literal ID="Literal1" runat="server"></asp:Literal>
    <asp:Button  ID="btnUpdateAdvisers" runat="server"  Text="UPDATE" CssClass="btn" OnClick="btnUpdateAdvisers_Click"/>
    </div>
    </div>
    </div>
    </center>


</asp:Content>





