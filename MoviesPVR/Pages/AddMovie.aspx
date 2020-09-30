<%@ Page Title="Add Movie" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddMovie.aspx.cs" Inherits="MoviesPVR.AddMovie" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Administration</h1>
    <hr />
    <h3>Add New Movie:</h3>
    <asp:Literal ID="LiteralError" runat="server"></asp:Literal>
    <div class="form-group">
        <asp:Label ID="Label3" AssociatedControlID="DropDownGenre" runat="server" Text="Choose Genre:"></asp:Label>
        <asp:DropDownList ID="DropDownGenre" CssClass="form-control"
            runat="server" ItemType="MoviesPVR.Models.Genre"
            SelectMethod="GetGenres" DataTextField="GenreName" DataValueField="GenreID">
        </asp:DropDownList>
    </div>
    <div class="form-group">
        <asp:Label ID="Label1" AssociatedControlID="TxtMovieName" runat="server" Text="Enter Movie Name:"></asp:Label>
        <asp:TextBox ID="TxtMovieName" runat="server" CssClass="form-control"></asp:TextBox>
    </div>
    <div class="form-group">
        <asp:Label ID="Label2" AssociatedControlID="TxtDescription" runat="server" Text="Enter Movie Description:"></asp:Label>
        <asp:TextBox TextMode="MultiLine" ID="TxtDescription" runat="server" CssClass="form-control"></asp:TextBox>
    </div>
    <div class="form-group">
        <asp:Label ID="Label4" AssociatedControlID="PosterImage" runat="server" Text="Choose Movie Poster:"></asp:Label>
        <asp:FileUpload ID="PosterImage" runat="server"  CssClass="form-control" />
    </div>
    <div class="form-group">
        <asp:Label ID="Label5" AssociatedControlID="DropDownRunningStatus" runat="server" Text="Choose Movie Running Status:"></asp:Label>
        <asp:DropDownList ID="DropDownRunningStatus" CssClass="form-control" runat="server">
            <asp:ListItem Value="true">YES</asp:ListItem>
            <asp:ListItem Value="false">NO</asp:ListItem>
        </asp:DropDownList>
    </div>
    <asp:Button ID="BtnNewMovie" Text="Add New Movie" runat="server" OnClick="BtnNewMovie_Click" CssClass="btn btn-primary btn-block" />
    
</asp:Content>
