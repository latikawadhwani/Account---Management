<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewTransactionDetails.aspx.cs" Inherits="AccountOpening_Team1.ViewTransactionDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <table><tr><td>View Transaction Details</td></tr>
<tr><td>select Account ID</td><td><asp:TextBox ID="txtAccountID" runat="server" 
        Enabled="False"></asp:TextBox></td></tr><tr><td><asp:Button ID="btnSubmit" runat="server" Text="Submit" 
            onclick="btnSubmit_Click" /></td></tr></table><table><tr><td>
        <asp:Label ID="lblMessage" runat="server"></asp:Label>
        </td></tr><tr><td>
<div style="overflow-x:auto;width:600px">
    <asp:GridView ID="grdTransaction" runat="server">
    <Columns>
        <asp:BoundField DataField="TransactionID" HeaderText="TransactionID" />
        <asp:BoundField DataField="AccountID" HeaderText="AccountID" />
        <asp:BoundField DataField="StartDate" HeaderText="StartDate" />
        <asp:BoundField DataField="Credit" HeaderText="Credit" />
        <asp:BoundField DataField="Debit" HeaderText="Debit" />
        <asp:BoundField DataField="Balance" HeaderText="Balance" />
    </Columns>
    </asp:GridView></div>
    </td></tr><tr><td></td></tr></table>
  
</asp:Content>
