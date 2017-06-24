<%@ Page Title="USuarios logueados Us" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="History.aspx.cs" Inherits="WebApplication_ChekSession.History" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Session history list
    </h2>
    <p>
        <%= LIST %>
    </p>
    
</asp:Content>
