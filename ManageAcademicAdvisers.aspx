<%@ Page Title="Manage Academic Advisers" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ManageAcademicAdvisers.aspx.cs" Inherits="_Default" %>

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
				<asp:ImageButton ToolTip="Move to Archive" ImageUrl="assets/img/remove.png" OnClick="moveToArchive" OnClientClick = "Confirm()" runat="server" ID="rem" style="width: 3.5em; height: 3.5em; margin-top: -5%" class="pic" />
			</td>
			<td>
				<a onserverclick="closePopup" title="Add New" runat="server" ID="walkingCon" style=" cursor: pointer; " class="pic">
					<img src="assets/img/add.png" style="margin-bottom: 6%; width: 4.15em; height: 4.15em;"/>
				</a>
			</td>
			
			<td>
			    <a onserverclick="showArchive" title="View Archive" runat="server" ID="archive" style="cursor: pointer;" class="pic">
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
                                <asp:LinkButton ID="aAdvisingView" runat="server" CommandArgument='<%# Eval("AAdviserId") %>' CommandName="ViewAcademic">
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
    <asp:DataPager ID="pgrLV" PagedControlID="ListViewAAdvisers" QueryStringField="page" runat="server" PageSize="5" style="margin-top: 5px; text-align: center; width: 100%;">
    <Fields>
	 <asp:NextPreviousPagerField ButtonType="Link" FirstPageText="<<" ShowFirstPageButton="True" ShowNextPageButton="false"/>   
        <asp:NumericPagerField ButtonCount="5" />
         <asp:NextPreviousPagerField ButtonType="Link" LastPageText=">>" ShowLastPageButton="True" ShowPreviousPageButton="false"/>
    </Fields>
    </asp:DataPager>
    <center>
    <div id="popupDiv">
        <div id="popupInner" style="width: 25%; margin-top: 1%; margin-left: -13%;">
            <div id="popupForm" >
                <img id="close" src="assets/img/close.png" onclick="div_hide()">
                
                <div id="popAdd" runat="server">
		<h2>Manage Academic Adviser</h2>
                <hr>
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
                        <asp:Button style="margin-left: 30%; margin-top: 2%;" ID="btnAddAcademicAdviser" runat="server"  Text="ADD ADVISER" OnClick="btnAddAcademicAdvisers_Click"/>
                    </td>
                </tr>
            </table>
    </div>
		    
	<div runat="server" id="students" Visible="false" style="margin-top: 5em; margin-bottom: 5em;">
		<h2>View Students Assigned</h2>
                <hr>
	      	Assigned Students Count : 
		<asp:Label runat="server" id="sCount" Text="0"/>
  	      <asp:GridView CssClass="GridHeader" Visible="true" ID="GridViewAS" runat="server" emptydatatext="No data available." allowpaging="true"  AutoGenerateColumns = "false" Font-Names = "Arial" Font-Size = "8pt" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" OnPageIndexChanging="grdData_PageIndexChanging" PageSize="5">
		   <Columns>
		    <asp:BoundField ItemStyle-Width = "150px" DataField = "StudentNumber" HeaderText = "Student #"/>
		    <asp:BoundField ItemStyle-Width = "150px" DataField = "StudentName" HeaderText = "Student Name" />
		    <asp:BoundField ItemStyle-Width = "150px" DataField = "Program" HeaderText = "Program"/>
		   </Columns>
		      <pagersettings mode="Numeric"
          position="Bottom"           
          pagebuttoncount="10"/>

        <pagerstyle backcolor="LightBlue"
          height="30px"
          verticalalign="Bottom"
          horizontalalign="Center"/>
	      </asp:GridView>
	</div>
    <asp:Literal ID="Literal1" runat="server"></asp:Literal>
    
    </div>
    </div>
    </div>
    </center>


</asp:Content>








