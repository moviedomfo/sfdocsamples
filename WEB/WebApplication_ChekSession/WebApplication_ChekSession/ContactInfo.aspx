<%@ Page Title="USuarios logueados Us" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="ContactInfo.aspx.cs" Inherits="WebApplication_ChekSession.ContactInfo" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2 style="font-family: 'Times New Roman', Times, serif; font-size: large">
        Informacion del Contacto logueado
    </h2>
    <p>
        <%= LIST2 %>
    </p>
</asp:Content>
