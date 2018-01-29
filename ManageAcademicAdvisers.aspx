<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ManageAcademicAdvisers.aspx.cs" Inherits="_Default" %>

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
    <h3> Manage Academic Advisers </h3>   
    <hr />  
    <div  style="margin-left: 2.5%; width: 94%;">
    <table stlye="width: 95%;">
    	<tr>
			<td style="width: 10%;">
				<h5> Search By : </h5>
			</td>
			<td style="width: 25%;"> 
				<asp:DropDownList ID="ddlDept" runat="server" AutoPostBack="True" onselectedindexchanged="sortByDepartment">
					<asp:ListItem Value="1">ALL</asp:ListItem><asp:ListItem Value="2">Department</asp:ListItem><asp:ListItem Value="3">Adviser Name</asp:ListItem>
				</asp:DropDownList>
			</td>
			<td style="width: 10%;">
				<h5> Search Key : </h5>
			</td>
			<td style="width: 50%; padding-right: 20%;"> 
				<asp:TextBox style="width: 95%" id="tboxSKey" AutoPostBack="True" ontextchanged="searchKey" runat="server" ></asp:TextBox>
			</td>
			<td>
				<asp:ImageButton ImageUrl="assets/img/remove.png" OnClick="moveToArchive" OnClientClick = "Confirm()" runat="server" ID="rem" style="width: 3.5em; height: 3.5em; margin-top: -5%" class="pic" />
			</td>
			<td>
				<a onserverclick="closePopup" title="Add New" runat="server" ID="walkingCon" style=" cursor: pointer; " class="pic">
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
    <br /><br />
    <!-- Sorted table for each department prof View/Edit/Delete -->
        <asp:ListView ID="ListViewAAdvisers" runat="server" OnItemCommand="ListViewAAdvisers_ItemCommand">
            <EmptyDataTemplate>
            <div style="margin-top: -7%;">
                <tr runat="server">
                    <td runat="server">
                        <table id="itemPlaceholderContainer" runat="server" class="viewTable" style="width: 95%; margin: 4% 1em 0em 1.5em;">
                            <center>
                            <tr>
							  <th style="width: 5%;"> Department </th>
							  <th style=""> Adviser Name </th>
							  <th style="width: 5%;"> Status </th>
							  <th style="width: 5%;"> View </th>
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
								<asp:Label ID="lblAId" runat="server" Text='<%# Eval("AAdviserId") %>' />
							</td>
                            <td>
                                <asp:Label runat="server" Text='<%# Eval("DeptName") %>' />
                            </td>
                            <td>
                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("FullName") %>' />
                            </td>
                            <td>
                                <asp:Label ID="Label2" runat="server" Text='<%# Eval("Status") %>' />
                            </td>
                            <td class="pic">    
                                <asp:LinkButton ID="aAdvisingView" runat="server" CommandArgument='<%# Eval("AAdviserId") %>' CommandName="">
                                    <img src="assets/img/viewIcon.png" />
                                </asp:LinkButton>
                           </td>
                            <td class="pic">    
                                <asp:LinkButton ID="aAdvisingUpdate" runat="server" CommandArgument='<%# Eval("AAdviserId") %>' CommandName="UpdateAcademic">
                                    <img src="assets/img/edit.png" />
                                </asp:LinkButton>
                           </td>
                            <td style="text-align:center;">
                                <asp:CheckBox ID="chkSelect" runat="server" />
                            </td>
                        </tr>     
            </ItemTemplate>
            <LayoutTemplate>
            <div style="margin-top: -7%;">
                <tr runat="server">
                    <td runat="server">
                        <table id="itemPlaceholderContainer" runat="server" class="viewTable" cellspacing="12" style="width: 95%; margin: 4% 1em 0em 1.5em;">
                            <center>
                            <tr>
							  <th style="width: 5%;"> Department </th>
							  <th style=""> Adviser Name </th>
							  <th style="width: 5%;"> Status </th>
                              <th style="width: 5%;"> View</th>
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
        <div id="popupInner" style="width: 20%; ">
            <div id="popupForm">
                <img id="close" src="assets/img/close.png" onclick="div_hide()">
                <h2>Manage Academic Adviser</h2>
                <hr>
                <div>
                <table>
                <tr id="trUname" runat="server">
                    <td>
                        <b> Username : </b>
                    </td>
                    <td>
                        <asp:TextBox style="width: 95%" id="tboxUsername" placeholder="Username" runat="server" ></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="">
                        <b> Department : </b>
                    </td>
                    <td>
                        <asp:DropDownList class="popup95" ID="ddlDepartment" runat="server"><asp:ListItem Value="1">ETY</asp:ListItem><asp:ListItem Value="2">Math</asp:ListItem><asp:ListItem Value="3">Physics</asp:ListItem><asp:ListItem Value="4">SLHS</asp:ListItem><asp:ListItem Value="5">SOIT</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <b> Last Name : </b>
                    </td>
                    <td>
                        <asp:TextBox style="width: 95%" id="tboxLName" placeholder="Last Name" runat="server" ></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <b> First Name : </b>
                    </td>
                    <td>
                        <asp:TextBox style="width: 95%" id="tboxFName" placeholder="First Name" runat="server" ></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <b> Middle Name : </b>
                    </td>
                    <td>
                        <asp:TextBox style="width: 95%" id="tboxMName" placeholder="Middle Name" runat="server" ></asp:TextBox>
                    </td>
                </tr>
                <tr id="popStatus" runat="server">
                    <td>
                        <b> Status : </b>
                    </td>
                    <td>
                        <asp:DropDownList class="popup95" ID="ddlStatus" runat="server"><asp:ListItem>ACTIVE</asp:ListItem><asp:ListItem>INACTIVE</asp:ListItem></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Button style="margin-left: 9em" ID="btnAddAcademicAdviser" runat="server"  Text="ADD ADVISER" CssClass="btn" OnClick="btnAddAcademicAdvisers_Click"/>
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








