<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="FacultyAppointmentHistory.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>



<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h3> Appointment History </h3>   
    <hr />   
    <a style="cursor: pointer; margin-right: 1em;"><asp:LinkButton OnClick="Page_Load" ID="lbtnAll" runat="server"> ALL </asp:LinkButton> </a>
    <a style="cursor: pointer; margin-right: 1em;"><asp:LinkButton OnClick="sortByFFU" ID="lbtnFFU" runat="server"> For Follow Up </asp:LinkButton> </a>
    <a style="cursor: pointer; margin-right: 1em;"><asp:LinkButton OnClick="sortByRef" ID="lbtnRef" runat="server"> Referred </asp:LinkButton> </a>
    <a style="cursor: pointer; margin-right: 1em;"><asp:LinkButton OnClick="sortByRes" ID="lbtnRes" runat="server"> Resolved </asp:LinkButton> </a>
    
    <br /><br />
                 <!-- sorted table  View only-->       
        <asp:ListView ID="ListViewAHistory" runat="server">
            <EmptyDataTemplate>
            <div>
                <tr runat="server">
                    <td runat="server">
                        <table id="itemPlaceholderContainer" runat="server" class="viewTable" cellspacing="12">
                            <center>
                            <tr>
                                <th width="200px"> Date and Time </th>
                                <th width="200px"> Consultation Code </th>
                                <th width="200px"> Nature of Advising </th>
                                <th width="200px"> Action Taken </th>
                                <th width="200px"> View </th>
                            </tr>
                            </center>
                            <tr id="itemPlaceholder" runat="server">
                            </tr>
                        </table>
                    </td>
                </tr>  
            </div> 
            </EmptyDataTemplate>
            <ItemTemplate>
                        <tr runat="server">
                            <td>
                                <asp:Label runat="server" Text='<%# Eval("ConsultationDateTime") %>' />
                            </td>
                            <td>
                                <asp:Label ID="Proj_NameLabel" runat="server" Text='<%# Eval("ConsultationCode") %>' />
                            </td>
                            <td>
                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("NatureofAdvising") %>' />
                            </td>
                            <td>
                                <asp:Label ID="Label3" runat="server" Text='<%# Eval("ActionTaken") %>' />
                            </td>
                            <td class="pic">    
                                <asp:LinkButton ID="aAdvisingUpdate" runat="server" >
                                    <img src="assets/img/viewIcon.png" />
                                </asp:LinkButton>
                           </td>
                        </tr>     
            </ItemTemplate>
            <LayoutTemplate>
            <div>
                <tr runat="server">
                    <td runat="server">
                        <table id="itemPlaceholderContainer" runat="server" class="viewTable" cellspacing="12" style="width: 95%;">
                            <center>
                            <tr>
                                <th width="200px"> Date and Time </th>
                                <th width="200px"> Consultation Code </th>
                                <th width="200px"> Nature of Advising </th>
                                <th width="200px"> Action Taken </th>
                                <th width="200px"> View </th>
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
        <div id="popupInner" style="width: 16.5%; margin-left: 30em;">
            <div id="popupForm">
                <img id="close" src="assets/img/close.png" onclick ="div_hide()" >
                <h2>Walk-In Session</h2>
                <hr>
                    <div>
        <table style="width: 100%; margin-left: -5.5em;">
                <tr>
                    <td class="">
                        <b> Student Number : </b>
                        <asp:TextBox id="studentNum" placeholder="Student Number" runat="server" ></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="">
                        <b> Name : </b>
                        <asp:TextBox id="studentName" placeholder="Student Name" runat="server" ></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <b> Program : </b>
                        <asp:TextBox id="studentProgram" placeholder="Project Title" runat="server" ></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <b> Subject Type : </b>
                        <asp:DropDownList ID="ddlSubjType" runat="server">
                            <asp:ListItem>MATH</asp:ListItem>
                            <asp:ListItem>PHYSICS</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <b> Course Code : </b>
                        <asp:DropDownList ID="ddlCourseCode" runat="server"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <b> Peer Adviser : </b>
                        <asp:DropDownList ID="ddlPeerAdviser" runat="server"></asp:DropDownList>
                    </td>
                </tr>
            </table>
    </div>
    <asp:Literal ID="Literal1" runat="server"></asp:Literal>
    <asp:Button  ID="btnAddSession" runat="server"  Text="ADD" CssClass="btn"/>
    </div>
    </div>
    </div>
    </center>


</asp:Content>