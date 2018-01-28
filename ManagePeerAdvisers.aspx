<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ManagePeerAdvisers.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>



<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	<script type = "text/javascript">
        function Confirm() {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            if (confirm("Do you really want to move the adviser(s) to archive?")) {
                confirm_value.value = "Yes";
            } else {
                confirm_value.value = "No";
            }
            document.forms[0].appendChild(confirm_value);
        }
    </script>
    <h3> Manage Peer Advisers </h3>   
    <hr />   
        <!-- For sorting the table -->
    <div  style="margin-left: 2.5%;">
    <table stlye="width: 95%;">
    <tr>
    	<td>
        	<h5> Search By : </h5>
        </td>
        <td style="width: 25%;"> 
        	<asp:DropDownList ID="ddlSubj" runat="server" AutoPostBack="True" onselectedindexchanged="sortBySubj">
				<asp:ListItem Value="1">ALL</asp:ListItem><asp:ListItem Value="2">Subject</asp:ListItem><asp:ListItem Value="3">Student Number</asp:ListItem><asp:ListItem Value="4">Student Name</asp:ListItem><asp:ListItem Value="5">Organization</asp:ListItem><asp:ListItem Value="6">Contact Number</asp:ListItem>
			</asp:DropDownList>
        </td>
        <td>
        	<h5> Search Key : </h5>
        </td>
        <td style="width: 25%;"> 
        	<asp:TextBox style="width: 95%" id="tboxSKey" AutoPostBack="True" ontextchanged="searchKey" runat="server" ></asp:TextBox>
        </td>
        <td>
        	<asp:ImageButton ImageUrl="assets/img/remove.png" OnClick="moveToArchive" OnClientClick = "Confirm()" runat="server" ID="rem" style="width: 3.5em; height: 3.5em; margin-top: -5%" class="pic" />
        </td>
        <td>
            <a onserverclick="openPopup" runat="server" ID="walkingCon" style=" cursor: pointer; " class="pic">
            	<img src="assets/img/add.png" style="margin-bottom: 6%; width: 4.15em; height: 4.15em;"/>
            </a>
        </td>
		<td>
            <a onserverclick="showArchive" runat="server" ID="archive" style="cursor: pointer;" class="pic">
            	<img src="assets/img/archive.png" style="margin-bottom: 14%; width: 3.5em; height: 3.75em;"/>
            </a>
        </td>
    </tr>
    </table>
    </div>

    <!-- List of Peer Advisers View/Edit/Delete -->

    <br /><br />
                        
        <asp:ListView ID="ListViewPAdvisers" runat="server" OnItemCommand="ListViewPAdvisers_ItemCommand">
            <EmptyDataTemplate>
            <div style="margin-top: -4%;">
                <tr runat="server">
                    <td runat="server">
                        <table id="itemPlaceholderContainer" runat="server" class="viewTable"  style="width: 95%; margin: 4% 1em 0em 1.5em;" >
                            <center>
                            <tr>
								<th style="width: 5%;"> Subject </th>
								<th style="width: 5%;"> Student Number </th>
								<th style=""> Full Name </th>
								<th style="width: 5%;"> Organization </th>
								<th style="width: 5%;"> Status </th>
								<th style="width: 5%;"> Contact </th>
								<th style="width: 5%;"> Edit </th>
								<th style="width: 5%;"> </th>
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
			    <td Visible="false">
                                <asp:Label ID="lblPId" runat="server" Text='<%# Eval("PAdviserId") %>' />
                            </td>
                            <td>
                                <asp:Label runat="server" Text='<%# Eval("TeachingSubject") %>' />
                            </td>
                            <td>
                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("StudentNumber") %>' />
                            </td>
                            <td>
                                <asp:Label ID="Label2" runat="server" Text='<%# Eval("StudentName") %>' />
                            </td>
                            <td>
                                <asp:Label ID="Label3" runat="server" Text='<%# Class2.getSingleData("SELECT OrganizationName FROM [dbo].[Organization] WHERE OrganizationId =" + Eval("OrganizationId")) %>' />
                            </td>
                            <td>
                                <asp:Label ID="Label4" runat="server" Text='<%# Eval("Status") %>' />
                            </td>
                            <td>
                                <asp:Label ID="Label6" runat="server" Text='<%# Class2.getSingleData("SELECT [contact] from [student] where [studentnumber] = " + Eval("StudentNumber")) %>' />
                            </td>
                            <td class="pic">    
                                <asp:LinkButton ID="aAdvisingUpdate" runat="server" CommandName="UpdatePeer" CommandArgument='<%# Eval("PAdviserId") %>'>
                                    <img src="assets/img/edit.png" />
                                </asp:LinkButton>
                           </td>
                            <td style="text-align:center;">
                                <asp:CheckBox ID="chkSelect" runat="server" />
                            </td>
                        </tr>   
            </ItemTemplate>
            <LayoutTemplate>
            <div style="margin-top: -4%;">
                <tr runat="server">
                    <td runat="server">
                        <table id="itemPlaceholderContainer" runat="server" class="viewTable"  style="width: 95%; margin: 4% 1em 0em 1.5em;" >
                            <center>
                            <tr>
								<th style="width: 5%;"> Subject </th>
								<th style="width: 5%;"> Student Number </th>
								<th style=""> Full Name </th>
								<th style="width: 5%;"> Organization </th>
								<th style="width: 5%;"> Status </th>
								<th style="width: 5%;"> Contact </th>
								<th style="width: 5%;"> Edit </th>
								<th style="width: 5%;"> </th>
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

    <center>
    <div id="popupDiv">
        <div id="popupInner" style="width: 20%;">
            <div id="popupForm">
                <img id="close" src="assets/img/close.png" onclick ="div_hide()" >
                <h2>Add Peer Adviser</h2>
                <hr>
                    <div>
        <table style="width: 85%;">
                <tr>
                    <td>
                        <b> Teaching Subject : </b>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlTeachSubject" runat="server" style="width: 75%;"><asp:ListItem>Professional Course IT</asp:ListItem><asp:ListItem>ETY</asp:ListItem><asp:ListItem>Math</asp:ListItem><asp:ListItem>Physics</asp:ListItem><asp:ListItem>Professional Course BA</asp:ListItem><asp:ListItem>Professional Course ENT</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr id="trSNum" runat="server">
                    <td>
                        <b> Student Number : </b>
                    </td>
                    <td>
                        <asp:DropDownList  style="width: 75%;" ID="ddlStudNum"  runat="server"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <b> Organization: </b>
                    </td>
                    <td>
                        <asp:DropDownList style="width: 75%;" ID="ddlOrg" runat="server"></asp:DropDownList>
                    </td>
                </tr>
                <tr id="popStatus" runat="server">
                    <td>
                        <b> Status : </b>
                    </td>
                    <td>
                        <asp:DropDownList style="width: 75%;" ID="ddlStatus" runat="server"><asp:ListItem>ACTIVE</asp:ListItem><asp:ListItem>INACTIVE</asp:ListItem></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <b> Mobile Number : </b>
                    </td>
                    <td>
                        <asp:TextBox style="width: 95%" id="tboxCNum" placeholder="Mobile Number" runat="server" ></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Button style="margin-left: 9em;" ID="btnAddPeerAdviser" runat="server"  Text="ADD ADVISER" CssClass="btn" OnClick="btnAddPeerAdvisers_Click"/>
                    </td>
                </tr>
            </table>
    </div>
    <asp:Literal ID="Literal1" runat="server"></asp:Literal>
    
    </div>
    </div>
    </div>
    </center>


</asp:Content>







