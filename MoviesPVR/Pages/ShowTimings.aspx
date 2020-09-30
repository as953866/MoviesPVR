<%@ Page Title="Show Timings" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ShowTimings.aspx.cs" Inherits="MoviesPVR.ShowTimings" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:FormView ID="movieDetail" runat="server" ItemType="MoviesPVR.Models.Movie"
        SelectMethod="GetMovie" RenderOuterTable="false">
        <ItemTemplate>
            <div>
                <h1><%#:Item.MovieName %></h1>
            </div>
            <br />
            <table>
                <tr>
                    <td>
                        <img src="/Posters/<%#:Item.ImagePath %>" style="border: solid; height: 200px"
                            alt="<%#:Item.MovieName %>" />
                    </td>
                    <td>&nbsp;</td>
                    <td style="vertical-align: top; text-align: left;"><b>Description:</b><br />
                        <p style="font-size: 18px; text-align: justify;"><%#:Item.Description %></p>
                    </td>
                </tr>
            </table>
        </ItemTemplate>
    </asp:FormView>
    <h3>Book Tickets:</h3>
    <asp:Literal ID="LiteralError" runat="server" Text=""></asp:Literal>
    <table class="table table-responsive">
        <tr>
            <td>
                <asp:Label ID="Label4" runat="server">Enter First Name:</asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TxtFirstName" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label5" runat="server">Enter Last Name:</asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TxtLastName" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label" runat="server">Choose Movie Date:</asp:Label></td>
            <asp:Label ID="LabelMovieID" runat="server" Visible="false"></asp:Label>
            <td>
                <asp:DropDownList ID="DropDownMovieDate" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownMovieDate_SelectedIndexChanged"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label2" runat="server">Total Available Seats for Movie Show:</asp:Label></td>
            <td>
                <asp:Label ID="LabelTotalSeats" runat="server">0</asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="LabelMovieTime" runat="server">Choose Movie Time:</asp:Label></td>
            <td>
                <asp:DropDownList ID="DropDownMovieTime" AutoPostBack="true" OnSelectedIndexChanged="DropDownMovieTime_SelectedIndexChanged" runat="server"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server">Choose Ticket Category:</asp:Label></td>
            <td>
                <asp:DropDownList ID="DropDownMovieTicketCategory" runat="server"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label3" runat="server">Choose Number of Ticket:</asp:Label></td>
            <td>
                <asp:DropDownList ID="DropDownNumberOfTicket" runat="server">
                    <asp:ListItem Value="0">Choose Number of Ticket</asp:ListItem>
                    <asp:ListItem Value="1">1</asp:ListItem>
                    <asp:ListItem Value="2">2</asp:ListItem>
                    <asp:ListItem Value="3">3</asp:ListItem>
                    <asp:ListItem Value="4">4</asp:ListItem>
                    <asp:ListItem Value="5">5</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td colspan="2" align="center">
                <asp:Button ID="BtnProcess" Text="Process The Booking" runat="server" OnClick="BtnProcess_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
