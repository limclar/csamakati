<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ManageStaff.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>



<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h3> Manage Staff </h3>   
    <hr />   
    <div  style="margin-left: 2.5%;">
    <table stlye="width: 95%;">
    <tr>
        <td>
            <a runat="server" ID="rem" style=" cursor: pointer; " class="pic">
                <img src="assets/img/remove.png" style="width: 3.4em; height: 3.3em; margin-top: -17%">
            </a>
        </td>
        <td>
            <a onclick="div_show()" runat="server" ID="walkingCon" style=" cursor: pointer; " class="pic">
                <img src="assets/img/add.png" style="margin-bottom: 8%"/>
            </a>
        </td>
        <td>
            <a onserverclick="showArchive" runat="server" ID="archive" AutoPostBack="true" style="cursor: pointer;" class="pic">
                <img src="assets/img/archive.png" style="margin-bottom: 8%"/>
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
                                <th width="200px"> Full Name </th>
                                <th style="width: 5%;"> Status </th>
                                <th style="width: 5%;"> Date Registered </th>
                                <%--<th style="width: 5%;"> Remove </th>--%>
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
                            <%-- 
                            <td>
                                <asp:Label runat="server" Text='<%# Eval("StaffId") %>' />
                            </td>
                            --%>
                            <td>
                                <asp:Label ID="Proj_NameLabel" runat="server" Text='<%# Eval("FullName") %>' />
                            </td>
                            <td>
                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("Status") %>' />
                            </td>
                            <td>
                                <asp:Label ID="Label3" runat="server" Text='<%# Eval("DateRegistered").ToString().Split(Convert.ToChar(" "))[0] %>' />
                            </td>
<%--
                            <td class="pic">
                                <asp:LinkButton ID="aAdvisingDelete" runat="server" CommandArgument='<%# Eval("StaffId") %>' CommandName="DeleteStaff" >
                                    <img src="assets/img/closeIcon.png" />
                                </asp:LinkButton>
                            </td>
--%>
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
                                <th width="200px"> Full Name </th>
                                <th style="width: 5%;"> Status </th>
                                <th style="width: 5%;"> Date Registered </th>
                                <%--<th style="width: 5%;"> Remove </th>--%>
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
        <div id="popupInner" style="width: 20%;">
            <div id="popupForm" style="margin: 0em 0em 0em 0em;">
                <img id="close" src="assets/img/close.png" onclick ="div_hide()" >
                <h2>Add Staff</h2>
                <hr>
                <div>
                <table style="width: 80%;">
                <tr>
                    <td class="">
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
                <tr>
                    <td>
                        <b> Status : </b>
                    </td>
                    <td>
                        <asp:DropDownList style="width: 85%;" ID="ddlStatus" runat="server"><asp:ListItem>ACTIVE</asp:ListItem><asp:ListItem>INACTIVE</asp:ListItem></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Button style="margin-left: 9em;" ID="btnAddStaff" runat="server"  Text="ADD NEW STAFF" CssClass="btn" OnClick="btnAddStaff_Click"/>
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
