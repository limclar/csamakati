<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="StudentSessionEvaluation.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h2> Session Evaluation </h2>   
    <hr />
<div style="background-color: #f2f2f2; width: 80%; margin-left: 10%; border: 2px solid black;">
    <table style="margin-left: 5%; margin-top: 2%;">
        <tr style="">
           <td style="width: 30%; text-align: right;">
               Peer Advisee: 
           </td>
           <td style="width: 30%; text-align: left;">
               <asp:Label ID="Label1" runat="server" style="margin-left: 5%;" Text='' />
           </td>
        </tr>
        <tr>
            <td style="width: 30%; text-align: right;">
               Peer Adviser: 
           </td>
           <td style="width: 30%; text-align: left;">
               <asp:Label ID="Label2" runat="server" style="margin-left: 5%;" Text=''/>
           </td>
        </tr>
        <tr style="height: 2em;">
           <td>
              <p> </p>
           </td>
        </tr>
        <tr>
            <td style="width: 30%;">
                   
            </td>
           <td>
                   &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                   1 - lowest
                   &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                   5 - highest
            </td>
        </tr>
        <tr>
            <td colspan = 2>
                   <hr  style="border-top: 1px solid black; margin-left: -5%;" />
            </td>
        </tr>
        <tr style="margin-bottom: -1%;">
             <td style="width: 30%;">
                
            </td>
            <td>
                  <table style="width: 90%; margin-left: 10%;">
                        <tbody>
                               <tr>
                                   <td style="width: 10%;">
                                          1
                                    </td>
                                    <td style="width: 10%;">
                                          2
                                     </td>
                                     <td style="width: 10%;">
                                          3
                                     </td>
                                     <td style="width: 10%;">
                                          4
                                     </td>
                                     <td style="width: 10%;">
                                          5
                                     </td>
                               </tr>
                        </tbody>
                  </table>
             </td>
        </tr>
        <tr>
            <td style="width: 30%;">
                Mastery
            </td>
            <td style="width: 50%;">
                <asp:RadioButtonList ID="rdbtnMaster" runat="server" RepeatDirection="Horizontal" style="width: 90%; margin-left: 10%;">
                    <asp:ListItem Value="1"> <blank /> </asp:ListItem>
                    <asp:ListItem Value="2"> <blank /> </asp:ListItem>
                    <asp:ListItem Value="3"> <blank /> </asp:ListItem>
                    <asp:ListItem Value="4"> <blank /> </asp:ListItem>
                    <asp:ListItem Value="5"> <blank /> </asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td style="width: 30%;">
                Respect  
            </td>
            <td style="width: 50%; ">
                <asp:RadioButtonList ID="rdbtnRespect" runat="server" RepeatDirection="Horizontal" style="width: 90%; margin-left: 10%;">
                <asp:ListItem Value="1"> <blank /> </asp:ListItem>
                <asp:ListItem Value="2"> <blank /> </asp:ListItem>
                <asp:ListItem Value="3"> <blank /> </asp:ListItem>
                <asp:ListItem Value="4"> <blank /> </asp:ListItem>
                <asp:ListItem Value="5"> <blank /> </asp:ListItem> </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td style="width: 30%;">
                Encourage Advisee
            </td>
            <td style="width: 50%; margin-left: 10%;">
                <asp:RadioButtonList ID="rdbtnEncourage" runat="server" RepeatDirection="Horizontal" style="width: 90%; margin-left: 10%;">
                    <asp:ListItem Value="1"> <blank /> </asp:ListItem>
                    <asp:ListItem Value="2"> <blank /> </asp:ListItem>
                    <asp:ListItem Value="3"> <blank /> </asp:ListItem>
                    <asp:ListItem Value="4"> <blank /> </asp:ListItem>
                    <asp:ListItem Value="5"> <blank /> </asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td style="width: 30%;">
                Manages Advisee's Records Properly
            </td>
            <td style="width: 50%;">
                <asp:RadioButtonList ID="rdbtnManage" runat="server" RepeatDirection="Horizontal" style="width: 90%; margin-left: 10%;">
                    <asp:ListItem Value="1"> <blank /> </asp:ListItem>
                    <asp:ListItem Value="2"> <blank /> </asp:ListItem>
                    <asp:ListItem Value="3"> <blank /> </asp:ListItem>
                    <asp:ListItem Value="4"> <blank /> </asp:ListItem>
                    <asp:ListItem Value="5"> <blank /> </asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td style="width: 30%;">
                Shares Learning Techniques Unselfishly
            </td>
            <td style="width: 50%;">
                <asp:RadioButtonList ID="rdbtnLearning" runat="server" RepeatDirection="Horizontal" style="width: 90%; margin-left: 10%;">
                    <asp:ListItem Value="1"> <blank /> </asp:ListItem>
                    <asp:ListItem Value="2"> <blank /> </asp:ListItem>
                    <asp:ListItem Value="3"> <blank /> </asp:ListItem>
                    <asp:ListItem Value="4"> <blank /> </asp:ListItem>
                    <asp:ListItem Value="5"> <blank /> </asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td colspan=2 style="text-align: right;">
                <asp:Literal ID="Literal1" runat="server"></asp:Literal>
                <asp:Button ID="btnSubmitEval" runat="server" Text="Submit" style="all: none; margin-right: 9%;" OnClick="btnAddEval_Click"/>
            </td>
        </tr>
    </table>
        </div>
    
                        
                        
</asp:Content>
