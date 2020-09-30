<%@ Page Title="Login Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="MoviesPVR.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Login</h1>

    <asp:Literal ID="LiteralError" runat="server"></asp:Literal>
    <div class="form-group">
        <asp:Label ID="Label1" runat="server" Text="Enter User ID:"></asp:Label>
        <asp:TextBox ID="TxtUserID" runat="server" CssClass="form-control"></asp:TextBox>
    </div>
    <div class="form-group">
        <asp:Label ID="Label4" runat="server" Text="Enter Password:"></asp:Label>
        <asp:TextBox TextMode="Password" ID="TxtPassword" runat="server" CssClass="form-control"></asp:TextBox>
    </div>    
    <asp:Button ID="BtnLogin" Text="Login..." runat="server" OnClick="BtnLogin_Click" CssClass="btn btn-primary btn-block" />
</asp:Content>
