<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Home.ascx.cs" Inherits="Widgets_Home" %>


<br />
<h2 style="margin-left: 2%;">Home </h2>
<div style="margin-left: 40px">


    <asp:ListView ID="ListView1" runat="server" DataKeyNames="ProjectId" OnItemDataBound="ListView1_ItemDataBound" >
        <EmptyDataTemplate>
            <table style="float: right;" runat="server" >
                <tr>
                    <td>No Project is found.</td>
                </tr>
            </table>
        </EmptyDataTemplate>
        <ItemTemplate>

            <a href="#">
            <tr onclick="location.href='Default.aspx?page=Episode&Eid=<%# Eval("ProjectId") %>'">
                <td ID="StatusTb1" runat="server" >
                    <asp:Label ID="ClassLabel" runat="server" Text='<%# Eval("Class") %>' />
                </td>
                <td ID="StatusTb2" runat="server" >
                    <asp:Label ID="Proj_NameLabel" runat="server" Text='<%# Eval("Proj_Name") %>' />
                </td>
                <td ID="StatusTb" runat="server" >
                    <asp:Label ID="StatusLabel" runat="server" Text='<%# Eval("Status") %>' />
                </td>
            </tr>
                </a>
        </ItemTemplate>
        <LayoutTemplate>
            <table id="itemPlaceholderContainer" runat="server" class="container" cellspacing="12">
                <tr id="itemPlaceholder" runat="server">
                </tr>
            </table>
        </LayoutTemplate>
    </asp:ListView>
</div>




<!-- Float Button -->

 <a onclick="div_show()" href="#" class="float">
<i class="fa fa-envelope my-float" onclick="div_show()"><p style="margin-top: 15px">+</p></i>
</a>

  
<!-- PopUp -->

<center>
<div id="abc">
  <div id="popupContact">
<!-- Contact Us Form -->
<div id="form">
<img id="close" src="img/close.png" onclick ="div_hide()" >

<h2>Add Project</h2>
<hr>

<div>
        <table style="width: 100%;">
            <tr>
                <td class="auto-style1">
                    <b> Project Title : </b>
                    <asp:TextBox  name="projTitle" id="projTitle" placeholder="Project Title" runat="server" ></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <b> Class :  </b>
                    <asp:RadioButtonList ID="projClass" runat="server" Height="16px" Width="103px" RepeatDirection="Horizontal" RepeatLayout="Flow" style="margin-left: -54%;">
                        <asp:ListItem>2D</asp:ListItem> <asp:ListItem>3D</asp:ListItem>
                    </asp:RadioButtonList>
                   
                </td>
            </tr>
            <tr>
                <td>
                    <b> Client :</b> <asp:TextBox ID="projClient" runat="server"></asp:TextBox>            
                </td>
            </tr>
        </table>
</div>



<asp:Literal ID="Literal1" runat="server"></asp:Literal>
<asp:Button  ID="btnAddProject" runat="server" OnClick="btnAddProject_Click" Text="ADD" CssClass="btn"/>
</div>
<!-- Popup Div Ends Here -->





</div>
</div>
</center>

