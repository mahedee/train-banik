<%@ Page Title="Home Page" Language="C#" Trace="true" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SQLiDemo._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <br />

    <table>
        <tr>
            <td>
                <asp:TextBox ID="txtSearch" runat="server" Width="432px"></asp:TextBox></td>
            <td>
                <asp:Button ID="btnSearchBad" runat="server" Text="Search Bad" OnClick="btnSearchBad_Click" /></td>
             <td>
                <asp:Button ID="btnSearchBetter" runat="server" Text="Search Better" OnClick="btnSearchBetter_Click"/></td>
             <td>
                <asp:Button ID="btnSerachBest" runat="server" Text="Search Best" OnClick="btnSerachBest_Click"/></td>
        </tr>
    </table>
    <hr />
    <asp:GridView ID="gvProducts" runat="server"></asp:GridView>
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
</asp:Content>
