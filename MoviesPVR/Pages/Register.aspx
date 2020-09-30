<%@ Page Title="Register Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="MoviesPVR.Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Create Your Account </h1>

    <asp:Literal ID="LiteralError" runat="server"></asp:Literal>
    <div class="form-group">
        <asp:Label ID="Label1" runat="server" Text="Enter User ID:"></asp:Label>
        <asp:TextBox ID="TxtUserID" runat="server" CssClass="form-control"></asp:TextBox>
    </div>
    <div class="form-group">
        <asp:Label ID="Label2" runat="server" Text="Enter First Name:"></asp:Label>
        <asp:TextBox ID="TxtFirstName" runat="server" CssClass="form-control"></asp:TextBox>
    </div>
    
    <div class="form-group">
        <asp:Label ID="Label3" runat="server" Text="Enter Last Name:"></asp:Label>
        <asp:TextBox ID="TxtLastName" runat="server" CssClass="form-control"></asp:TextBox>
    </div>
    
    <div class="form-group">
        <asp:Label ID="Label4" runat="server" Text="Enter Password:"></asp:Label>
        <asp:TextBox TextMode="Password" ID="TxtPassword" runat="server" CssClass="form-control"></asp:TextBox>
    </div>
    
    <div class="form-group">
        <asp:Label ID="Label5" runat="server" Text="Confirm Password:"></asp:Label>
        <asp:TextBox TextMode="Password" ID="TxtConfirmPassword" runat="server" CssClass="form-control"></asp:TextBox>
    </div>
    <asp:Button ID="BtnCreate" Text="Create Account" runat="server" OnClick="BtnCreate_Click" CssClass="btn btn-primary btn-block" />
    
</asp:Content>
