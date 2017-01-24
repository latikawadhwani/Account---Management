<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RequestCheckbook.aspx.cs" Inherits="AccountOpening_Team1.RequestCheckbook" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table><tr><th>Request Checkbook</th></tr>
<tr><td>select Account ID</td><td><asp:TextBox ID="txtAccountID" runat="server" 
        ReadOnly="True"></asp:TextBox></td></tr><tr><td>
    &nbsp;</td></tr><tr><td>
<asp:LinkButton ID="lnkRequest" runat="server" Text="Request Checkbook" 
        onclick="lnkRequest_Click"></asp:LinkButton></td>
        <td>
            <asp:LinkButton ID="lnkViewRequest" runat="server" 
                onclick="lnkViewRequest_Click">View Request</asp:LinkButton>
        </td></tr>
</table>



<asp:GridView ID="grdViewCheckBookStatus" runat="server" 
    AutoGenerateColumns="False">
    <Columns>
        <asp:BoundField DataField="RequestID" HeaderText="RequestID" ReadOnly="True" 
            SortExpression="RequestID" />
        <asp:BoundField DataField="AccountID" HeaderText="AccountID" ReadOnly="True" 
            SortExpression="AccountID" />
        <asp:BoundField DataField="RequestDate" HeaderText="RequestDate" 
            ReadOnly="True" SortExpression="RequestDate" 
            DataFormatString="{0:MMMM d, yyyy}" />
        <asp:BoundField DataField="Status" HeaderText="Status" ReadOnly="True" 
            SortExpression="Status" />
    </Columns>
    </asp:GridView>
</asp:Content>
