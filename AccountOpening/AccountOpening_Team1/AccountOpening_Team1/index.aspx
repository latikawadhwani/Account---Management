<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="index.aspx.cs" Inherits="AccountOpening_Team1.index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

    <style type="text/css">
        .style3
        {
            width: 121px;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server"><center><br /><br />
    <table>
        <tr>
            <td align="right"><table border="2"><tr><td><table><tr><td colspan="3" align="center">Login Area</td></tr><tr><td class="style3">User ID</td><td>
                <asp:TextBox ID="txtUser" runat="server" Width="184px"></asp:TextBox></td><td><asp:RequiredFieldValidator ID="rfvId" runat="server" ErrorMessage="User ID cannot be blank" ForeColor="Red" ControlToValidate="txtUser" ValidationGroup="m2"></asp:RequiredFieldValidator></td></tr>
    <tr><td class="style3">Password</td><td>
        <asp:TextBox ID="txtPassword" 
            runat="server" Width="185px" TextMode="Password"></asp:TextBox></td><td><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Password cannot be blank" ForeColor="Red" ControlToValidate="txtPassword" ValidationGroup="m2"></asp:RequiredFieldValidator></td></tr>
    <tr><td  align="center" colspan="3"><asp:Button ID="btnSubmit" runat="server" Text="Submit" ValidationGroup="m2"
            onclick="btnSubmit_Click" /></td></tr>
            <tr><td class="style3"><asp:Label ID="lblMessage" runat="server"></asp:Label></td><td colspan="2"><asp:HyperLink ID="hplForgot" runat="server" 
                    NavigateUrl="~/ForgotPassword.aspx">Forgot Password</asp:HyperLink></td></tr></table></td></tr></table> 
    
            </td>
            <td></td>
        </tr>
       </table></center>
  </asp:Content>
