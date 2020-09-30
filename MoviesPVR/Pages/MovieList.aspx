<%@ Page Title="Movies" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MovieList.aspx.cs" Inherits="MoviesPVR.MovieList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <section>
        <div>
            <hgroup>
                <h2>Running Movies</h2>
            </hgroup>
            <asp:ListView ID="movieList" runat="server" DataKeyNames="MovieID"
                GroupItemCount="3" ItemType="MoviesPVR.Models.Movie" SelectMethod="GetMovies">
                <EmptyDataTemplate>
                    <table>
                        <tr>
                            <td>No data was returned.</td>
                        </tr>
                    </table>
                </EmptyDataTemplate>
                <EmptyItemTemplate>
                    <td />
                </EmptyItemTemplate>
                <GroupTemplate>
                    <tr id="itemPlaceholderContainer" runat="server">
                        <td id="itemPlaceholder" runat="server"></td>
                    </tr>
                </GroupTemplate>
                <ItemTemplate>
                    <td runat="server">
                        <table>
                            <tr>
                                <td>
                                    <a href="MovieDetails.aspx?movieID=<%#:Item.MovieID%>">
                                    <img src="/Posters/<%#:Item.ImagePath%>" width="300" height="200" 
                                        style="border: solid" /></a>                                 
                                    
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <a href="MovieDetails.aspx?movieID=<%#:Item.MovieID%>">
                                        <span style="font-size:30px"><%#:Item.MovieName%></span>
                                    </a>
                                    <br />
                                    
                                   
                                </td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                            </tr>
                        </table>
                        </p>                     </td>
                </ItemTemplate>
                <LayoutTemplate>
                    <table style="width: 100%;">
                        <tbody>
                            <tr>
                                <td>
                                    <table id="groupPlaceholderContainer" runat="server" style="width: 100%">
                                        <tr id="groupPlaceholder"></tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                            </tr>
                            <tr></tr>
                        </tbody>
                    </table>
                </LayoutTemplate>
            </asp:ListView>
        </div>
    </section>
</asp:Content>
