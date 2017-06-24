<%@ Page Title="USuarios logueados Us" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="ActiveSessionsPage.aspx.cs" Inherits="WebApplication_ChekSession.ActiveSessionsPage" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
         Active users  <%= count %>
    </h2>
    <p>
        <%= LIST %>
    </p>
    
</asp:Content>
