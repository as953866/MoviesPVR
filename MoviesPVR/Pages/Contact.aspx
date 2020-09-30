<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="MoviesPVR.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Your contact page.</h3>
    <address>
        Movies PVR<br />
        Auckland , NewZealand<br />
        <abbr title="Phone">P:</abbr>
        09-914-4100
    </address>

    <address>
        <strong>Support:</strong>   <a href="mailto:Support@moviespvr.com">Support@moviespvr.com</a><br />
        <strong>Marketing:</strong> <a href="mailto:Marketing@moviespvr.com">Marketing@moviespvr.com</a>
    </address>
</asp:Content>
