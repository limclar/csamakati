<%@ Page Title="Manage Staff" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ManageStaff.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>



<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script type = "text/javascript">
        function Confirm() {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            if (confirm("Do you really want to move the user(s) to archive?")) {
                confirm_value.value = "Yes";
            } else {
                confirm_value.value = "No";
            }
            document.forms[0].appendChild(confirm_value);
        }
    </script>
    <h3> Manage Staff </h3>   
    <hr />   
    <div  style="margin-left: 82%;">
    <table stlye="width: 95%;">
    <tr>
        <td>
            <asp:ImageButton ImageUrl="assets/img/remove.png" OnClick="moveToArchive" OnClientClick = "Confirm()" ToolTip="Move to Archive" runat="server" ID="rem" style="width: 3.5em; height: 3.5em; margin-top: -5%" class="pic" />
        </td>
        <td>
            <a onserverclick="openPopup" runat="server" ID="walkingCon" style=" cursor: pointer; " class="pic" title="Add New">
            	<img src="assets/img/add.png" style="margin-bottom: 6%; width: 4.15em; height: 4.15em;"/>
            </a>
        </td>
        <td>
            <a onserverclick="showArchive" runat="server" ID="archive" style="cursor: pointer;" class="pic" title="View Archive">
                <img src="assets/img/archive.png" style="margin-bottom: 14%; width: 3.5em; height: 3.75em;"/>
            </a>
        </td>
    </tr>
    </table>
    </div>
    <br /><br />           
        <asp:ListView ID="ListViewStaff" runat="server" OnItemCommand="ListViewStaff_ItemCommand">
            <EmptyDataTemplate>
            <div style="margin-top: -7%;">
                <tr runat="server">
                    <td runat="server">
                        <table id="itemPlaceholderContainer" runat="server" class="viewTable" style="width: 95%; margin: 4% 1em 0em 1.5em;">
                            <center>
                            <tr>
                                <th style="width: 15%"> Staff ID </th>
                                <th width="200px"> Full Name </th>
                                <th style="width: 5%;"> Status </th>
                                <th style="width: 5%;"> Date Registered </th>
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
                            <td Visible="true" style="text-align: center;">
                                <asp:Label ID="lblSId" runat="server" Text='<%# Eval("StaffId") %>' />
                            </td>
                            <td>
                                <asp:Label ID="Proj_NameLabel" runat="server" Text='<%# Eval("FullName") %>' />
                            </td>
                            <td>
                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("Status") %>' />
                            </td>
                            <td>
                                <asp:Label ID="Label3" runat="server" Text='<%# Eval("DateRegistered").ToString().Split(Convert.ToChar(" "))[0] %>' />
                            </td>
                            <td class="pic">    
                                <asp:LinkButton ID="staffUpdate" runat="server" CommandName="UpdateStaff" CommandArgument='<%# Eval("StaffId") %>'>
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
                        <table id="itemPlaceholderContainer" runat="server" class="viewTable" style="width: 95%; margin: 4% 1em 0em 1.5em;">
                            <center>
                            <tr>
                                <th style="width: 15%"> Staff ID </th>
                                <th width="200px"> Full Name </th>
                                <th style="width: 5%;"> Status </th>
                                <th style="width: 5%;"> Date Registered </th>
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
        <div id="popupInner" style="width: 25%; margin-top: 1%; margin-left: -13%;">
            <div id="popupForm" style="margin: 0em 0em 0em 0em;">
                <img id="close" src="assets/img/close.png" onclick ="div_hide()" >
                <h2>Manage Staff</h2>
                <hr>
                <div>
                <table style="width: 80%;">
                <tr  id="popUname" runat="server">
                    <td>
                        <b> Username : </b>
                    </td>
                    <td>
                        <asp:TextBox style="width: 85%;" id="tboxUsername" placeholder="Username" runat="server" ></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <b> Last Name : </b>
                    </td>
                    <td>
                        <asp:TextBox style="width: 85%;" id="tboxLName" placeholder="Last Name" runat="server" ></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <b> First Name : </b>
                    </td>
                    <td>
                        <asp:TextBox style="width: 85%;" id="tboxFName" placeholder="First Name" runat="server" ></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <b> Middle Name : </b>
                    </td>
                    <td>
                        <asp:TextBox style="width: 85%;" id="tboxMName" placeholder="Middle Name" runat="server" ></asp:TextBox>
                    </td>
                </tr>
                <tr id="popStat" runat="server">
                    <td>
                        <b> Status : </b>
                    </td>
                    <td>
                        <asp:DropDownList style="width: 85%;" ID="ddlStatus" runat="server"><asp:ListItem>ACTIVE</asp:ListItem><asp:ListItem>INACTIVE</asp:ListItem></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Button style="margin-left: 35%; margin-top: 2%;" ID="btnAddStaff" runat="server"  Text="ADD NEW STAFF" OnClick="btnAddStaff_Click"/>
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
