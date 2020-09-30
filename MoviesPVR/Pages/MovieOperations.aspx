<%@ Page Title="Movie Operations" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MovieOperations.aspx.cs" Inherits="MoviesPVR.MovieOperations" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Administration</h1>
    <hr />
    <h3>Movie Details:</h3>
    <asp:Literal ID="LiteralError" runat="server"></asp:Literal>
    <div class="form-group">
        <asp:Label ID="Label6" AssociatedControlID="DropDownMovie" runat="server" Text="Choose Movie:"></asp:Label>
        <asp:DropDownList ID="DropDownMovie"  CssClass="form-control"
            runat="server" ItemType="MoviesPVR.Models.Movie"
            SelectMethod="GetMovies" DataTextField="MovieName" DataValueField="MovieID">
        </asp:DropDownList>
    </div>
    <asp:Button ID="BtnView" Text="View Movie Details" runat="server" OnClick="BtnView_Click" CssClass="btn btn-primary btn-block" />
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
        <asp:Label ID="Label5" AssociatedControlID="DropDownRunningStatus" runat="server" Text="Choose Movie Running Status:"></asp:Label>
        <asp:DropDownList ID="DropDownRunningStatus" CssClass="form-control" runat="server">
            <asp:ListItem Value="true">YES</asp:ListItem>
            <asp:ListItem Value="false">NO</asp:ListItem>
        </asp:DropDownList>
    </div>
    <asp:Button ID="BtnUpdateMovie" Text="Update Movie Details" runat="server" OnClick="BtnUpdateMovie_Click" CssClass="btn btn-primary btn-block" />
    <asp:Button ID="BtnDeleteMovie" Text="Delete Movie Details" runat="server" OnClick="BtnDeleteMovie_Click" CssClass="btn btn-danger btn-block" />
</asp:Content>
