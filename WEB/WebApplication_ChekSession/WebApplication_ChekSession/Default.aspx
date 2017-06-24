<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="WebApplication_ChekSession._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div><h2>
        Ingrese un identificador de contacto </h2></div>
        <h2>
        <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
    </h2>
    <p>
        
    </p>
    <p>
        <asp:Button ID="Button1" runat="server" Text="Registrar (Id Contacto)" 
            onclick="Button1_Click" />
      <asp:Label
            ID="Label1" runat="server" Font-Bold="True" ForeColor="#CC0000"></asp:Label>
    </p>
    <div>
       <asp:Button ID="Button2" runat="server" Text="Check logued user" 
            onclick="Button2_Click" />
    </div>
</asp:Content>
