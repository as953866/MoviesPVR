<%@ Page Title="All Users" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AllUsers.aspx.cs" Inherits="MoviesPVR.AllUsers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>All Registered Users</h1>
    <section>
        <div>
            <hgroup>
                <h2><%: Page.Title %></h2>
            </hgroup>
            <asp:ListView ID="userList" runat="server" DataKeyNames="UserID"
                GroupItemCount="1" ItemType="MoviesPVR.Models.User" SelectMethod="GetUsers">
                <EmptyDataTemplate>
                    <div>
                        <h1>There is No Registered User</h1>
                    </div>
                </EmptyDataTemplate>
                <EmptyItemTemplate>
                </EmptyItemTemplate>
                <GroupTemplate>
                    <div id="itemPlaceholderContainer" runat="server">
                        <div id="itemPlaceholder" runat="server"></div>
                    </div>
                </GroupTemplate>
                <ItemTemplate>
                    <div style="border: 1px solid blue; padding: 5px; margin-bottom: 5px">
                        <h1>User ID : <%#:Item.UserID%></h1>
                        <h1>Account ID : <%#:Item.AccountID%></h1>
                        <h1>Person Name : <%#:Item.FirstName%> <%#:Item.LastName%> </h1>
                        <h1>Role Name : <%#:Item.RoleName%></h1>

                    </div>
                </ItemTemplate>
                <LayoutTemplate>
                    <div id="groupPlaceholderContainer" runat="server" style="width: 100%">
                        <div id="groupPlaceholder" runat="server"></div>
                    </div>
                </LayoutTemplate>
            </asp:ListView>
        </div>
    </section>
</asp:Content>
