<%@ Page Title="Announcements" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="StudentAnnouncements.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h3> Announcements </h3>   
    <hr style="width: 100%;"/>   
    <span runat="server" visible="false" ID="ewpAnn"> <h4> Please answer the <a href="StudentPeerAppointment.aspx?aType=2"> EWP Participation Form </a> OR <a href="EWPRefusal.aspx"> EWP Refusal Form </a> </h4></span>
    <br />
                        
                        
</asp:Content>
