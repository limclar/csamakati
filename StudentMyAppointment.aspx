<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="StudentMyAppointment.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>



<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h3> My Appointments </h3>   
    <hr />
    <table style="margin-left: 5%;">
    	<tr>
			<td style="width: 20%;">
				<h5> Advising Type : </h5>
			</td>
			<td style="text-align:left;"> 
			<asp:DropDownList ID="ddlType" runat="server" AutoPostBack="True" onselectedindexchanged="conType">
				<asp:ListItem>Peer Advising</asp:ListItem><asp:ListItem>Academic Advising</asp:ListItem>
			</asp:DropDownList>
			</td>
		</tr>
    </table>
    <br /><br />
                        
        <asp:ListView ID="ListViewPAdvising" runat="server" OnItemCommand="ListViewPAdvising_ItemCommand" OnItemDataBound="ListViewPAdvising_ItemDataBound" style="margin-top: -2%;">
            <EmptyDataTemplate>
                <center>
                    <table id="itemPlaceholderContainer" runat="server" class="viewTable" cellspacing="12" style="margin-top: -2%;">
                        <tr>
                            <th style="width: 5%;"> Status </th>
                            <th style="width: 5%;"> Date </th>
                            <th style="width: 5%;"> Time Start </th>
                            <th style="width: 5%;"> Appt. Type </th>
                            <th style="width: 5%;"> Course Code </th>
                            <th style="width: 5%;"> Peer Adviser </th>
                            <th style="width: 0.5%;"> Cancel </th>
                        </tr>
                        <tr id="itemPlaceholder" runat="server">
                        </tr>
                    </table>
                </center>
            </EmptyDataTemplate>
            <ItemTemplate>
                        <tr runat="server">
                            <td runat="server" ID="StatusTb">
                                <asp:Label ID="StatusLabel" runat="server" Text='<%# Eval("Status") %>' />
                            </td>
                            <td>
                                <asp:Label  runat="server" Text='<%# Eval("ConsultationDate") %>' />
                            </td>
                            <td>
                                <asp:Label runat="server" Text='<%# Eval("TimeStart") %>' />
                            </td>
                            <td>
                                <asp:Label runat="server" Text='<%# Eval("ConsultationType") %>' />
                            </td>
                            <td>
                                <asp:Label runat="server" Text='<%# Eval("CourseCode") %>' />
                            </td>                 
                            <td>    
                                <asp:Label runat="server" Text='<%#Class2.getSingleData("SELECT Student.StudentName FROM Student JOIN PeerAdviser ON Student.StudentNumber = PeerAdviser.StudentNumber WHERE PAdviserId = " + Eval("PeerAdvisers")) %>' />
                            </td>
                            <td class="pic" ID="pcancel" runat="server" style="text-align: center;">
                                <asp:LinkButton ID="pAdvisingDelete" runat="server" CommandArgument='<%# Eval("PConsultationId") %>' CommandName="CancelAppt">
                                    <img src="assets/img/closeIcon.png" />
                                </asp:LinkButton>
                            </td>
                        </tr>   
            </ItemTemplate>
            <LayoutTemplate>
                <center>
                    <table id="itemPlaceholderContainer" runat="server" class="viewTable" cellspacing="12" style="margin-top: -2%;">
                        <tr>
                            <th style="width: 5%;"> Status </th>
                            <th style="width: 5%;"> Date </th>
                            <th style="width: 5%;"> Time Start</th>
                            <th style="width: 5%;"> Appt. Type </th>
                            <th style="width: 5%;"> Course Code </th>
                            <th style="width: 5%;"> Peer Adviser </th>
                            <th style="width: 0.5%;"> Cancel </th>
                        </tr>
                        <tr id="itemPlaceholder" runat="server">
                        </tr>
                    </table>
                </center>
            </LayoutTemplate>
    </asp:ListView>
    <!-- 2 -->
    <asp:ListView ID="ListViewAAdvising" runat="server" OnItemCommand="ListViewAAdvising_ItemCommand">
            <EmptyDataTemplate>
            <div>
                <tr runat="server">
                    <td runat="server">
                        <table id="itemPlaceholderContainer" runat="server" class="viewTable" cellspacing="12" style="margin-top: -2%;">
                            <center>
                            <tr>
                                <th> Date and Time</th>
                                <th> Consultation Code </th>
                                <th> Nature of Advising </th>
                                <th> Academic Adviser </th>
                                <th style="width: 0.5%;"> Cancel </th>
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
                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("NatureOfAdvising") %>' />
                            </td>
                            <td>
                                <asp:Label ID="Label2" runat="server" Text='<%# Eval("AdviserName") %>' />
                            </td>
                            <td class="pic" style="text-align: center;">
                                <asp:LinkButton ID="aAdvisingDelete" runat="server" CommandArgument='<%# Eval("AConsultationId") %>' CommandName="aCancelAppt">
                                    <img src="assets/img/closeIcon.png" />
                                </asp:LinkButton>
                            </td>
                        </tr>
            </ItemTemplate>
            <LayoutTemplate>
            <div>
                <tr runat="server">
                    <td runat="server">
                        <table id="itemPlaceholderContainer" runat="server" class="viewTable" cellspacing="12" style="width: 95%; margin-top: -2%;">
                            <center>
                            <tr>
                                <th> Date and Time</th>
                                <th>Consultation Code</th>
                                <th>Nature of Advising</th>
                                <th> Academic Adviser</th>
                                <th style="width: 0.5%;"> Cancel </th>
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
    <asp:DataPager ID="pgrLV" PagedControlID="ListViewPAdvising" QueryStringField="page" runat="server" PageSize="5" style="margin-top: 5px; text-align: center; width: 100%;">
    <Fields>
	 <asp:NextPreviousPagerField ButtonType="Link" FirstPageText="<<" ShowFirstPageButton="True" ShowNextPageButton="false"/>   
        <asp:NumericPagerField ButtonCount="5" />
         <asp:NextPreviousPagerField ButtonType="Link" LastPageText=">>" ShowLastPageButton="True" ShowPreviousPageButton="false"/>
    </Fields>
    </asp:DataPager>

    <center>
    <div id="popupDiv">
        <div id="popupInner">
            <div id="popupForm">
                <img id="close" src="assets/img/close.png" onclick ="div_hide()" >
                <h2>Walk-In Session</h2>
                <hr>
                    <div>
        <table style="width: 100%;">
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
