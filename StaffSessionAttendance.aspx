<%@ Page Title="Session Attendance" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="StaffSessionAttendance.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>



<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script type = "text/javascript">
        function Confirm() {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            if (confirm("EWP Session done. Do you want to schedule again for next week?")) {
                confirm_value.value = "Yes";
            } else {
                confirm_value.value = "No";
            }
            document.forms[0].appendChild(confirm_value);
        }
    </script>
    <h2> Session Attendance </h2>   
    <hr />   
    <br /><br />
    <!-- Sorted table for each department prof View/Edit/Delete -->
        <asp:ListView ID="ListViewSAttendance" runat="server" OnItemDataBound="ListViewSAttendance_ItemDataBound" OnItemCommand="ListViewSAttendance_ItemCommand">
            <EmptyDataTemplate>
            <div>
                <tr runat="server">
                    <td runat="server">
                        <table id="itemPlaceholderContainer" runat="server" class="viewTable" cellspacing="12">
                            <center>
                            <tr>
                                <th style="width: 15%;"> Student Name </th>
                                <th style="width: 5%;">  Consultation Type </th>
                                <th style="width: 5%;">  Course Code </th>
                                <th style="width: 5%;">  Peer Adviser </th>
                                <th style="width: 5%;">  Peer Adviser 2 </th>
                                <th style="width: 5%;">  Peer Adviser 3 </th>
                                <th style="width: 5%;">  Time Start </th>
                                <th style="width: 0.1%;"> Start </th>
                                <th style="width: 0.1%;"> End </th>
                                <th style="width: 0.1%;">Edit </th>
                                <th style="width: 0.1%;"> Cancel </th>
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
                                
                            </td>
                        </tr>
                     </table>
                </center>
            </InsertItemTemplate>
            <ItemTemplate>
                        <tr runat="server">
                            <td>
                                <asp:Label ID="StudName" runat="server" Text='<%# Class2.getSingleData("SELECT dbo.Student.StudentName FROM [Student] WHERE dbo.Student.StudentNumber = " + Eval("StudentNumber")) %>' />
                            </td> 
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
                            <td class="pic" style="text-align: center;">    
                                <asp:LinkButton AutoPostBack="true" ID="btnUpdateTimeStart" runat="server" CommandName="TimeStart" CommandArgument='<%# Eval("PConsultationId") %>'>
                                    <img src="assets/img/go.png" />
                                </asp:LinkButton>
                            </td>
                            <td ID="noEWP" runat="server" class="pic" style="text-align: center;">
                                <asp:LinkButton AutoPostBack="true" ID="btnUpdateTimeEnd" runat="server" OnClientClick="Confirm()" CommandName="TimeEnd" CommandArgument='<%# Eval("PConsultationId") %>'>
                                    <img src="assets/img/end.png" style="width: 3.5em; height: 3.5em"/>
                                </asp:LinkButton>
                            </td>
                            <td class="pic" style="text-align: center;">    
                                <asp:LinkButton onclientclick="div_show()" ID="btnUpdateSession" runat="server" CommandName="UpdateCon" CommandArgument='<%#Eval("PConsultationId") %>'>
                                    <img src="assets/img/viewIcon.png" style="width: 4em; height: 4.25em" onclick="div_show()"/>
                                </asp:LinkButton>
                            </td>
                            <td class="pic" style="text-align: center;">
                                <asp:LinkButton AutoPostBack="true" ID="btnCancelSession" runat="server" OnClientClick="return alert('Consultation has been cancelled.');" CommandName="CancelCon" CommandArgument='<%# Eval("PConsultationId") %>'>
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
                                <th style="width: 15%;"> Student Name </th>
                                <th style="width: 5%;">  Consultation Type </th>
                                <th style="width: 5%;">  Course Code </th>
                                <th style="width: 5%;">  Peer Adviser </th>
                                <th style="width: 5%;">  Peer Adviser 2 </th>
                                <th style="width: 5%;">  Peer Adviser 3 </th>
                                <th style="width: 5%;">  Time Start </th>
                                <th style="width: 0.1%;"> Start </th>
                                <th style="width: 0.1%;"> End </th>
                                <th style="width: 0.1%;"> Edit </th>
                                <th style="width: 0.1%;"> Cancel </th>
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
                    <asp:TextBox runat="server" ID="txtPA1" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <b> Peer Adviser 2 : </b>
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtPA2" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <b> Peer Adviser 3 : </b>
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtPA3" />
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







