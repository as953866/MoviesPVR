<%@ Page Title="Movie Details" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MovieDetails.aspx.cs" Inherits="MoviesPVR.MovieDetails" %>

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
                        <img src="/Posters/<%#:Item.ImagePath %>" style="border: solid; height: 300px"
                            alt="<%#:Item.MovieName %>" />
                    </td>
                    <td>&nbsp;</td>
                    <td style="vertical-align: top; text-align: left;"><b>Description:</b><br />
                        <%#:Item.Description %>
                        <br />
                        <br />
                        <a href="ShowTimings.aspx?movieID=<%#:Item.MovieID%>">
                            <img src="../Images/book_show.JPG" alt="Book Show" />
                        </a>
                    </td>
                </tr>
            </table>
        </ItemTemplate>
    </asp:FormView>
</asp:Content>
