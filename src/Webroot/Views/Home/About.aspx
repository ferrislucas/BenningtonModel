<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="aboutContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>About</h2>
    <p>
        This is the About Action of HomeContoller.
    </p>

    <p><%=Html.ActionLink("Link to example controller About view", "About", "Home") %></p>
    <p><%=Html.ActionLink("Link to example controller Index view", "Index", "Home") %></p>
</asp:Content>
