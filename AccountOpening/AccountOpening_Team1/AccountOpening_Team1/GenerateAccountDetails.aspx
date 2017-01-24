<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GenerateAccountDetails.aspx.cs" Inherits="AccountOpening_Team1.GenerateAccountDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
 
    <div>
    <table>
    <tr>
       <td>Name</td>
       <td><asp:TextBox ID="txtName" runat="server" ReadOnly="True"></asp:TextBox></td>
    </tr>

    <tr>
       <td>Date of Birth</td>
       <td><asp:TextBox ID ="txtDOB" runat="server" ReadOnly="True"></asp:TextBox></td>
    </tr>
    <tr>
       <td>Father Name/Spouse Name</td>
       <td><asp:TextBox ID="txtFSName" runat="server" ReadOnly="True"></asp:TextBox></td></tr>
    <tr>
       <td>Gender</td>
       <td><asp:TextBox ID="txtGender" runat="server" 
                ReadOnly="True"></asp:TextBox></td></tr>
    <tr>
       <td>Marital Status</td>
       <td><asp:TextBox ID="txtMstatus" runat="server" ReadOnly="True"></asp:TextBox></td></tr>
    <tr>
       <td>Contact Details</td>
       <td><asp:TextBox ID="txtContDetails" runat="server" ReadOnly="True"></asp:TextBox></td></tr>
    <tr>
       <td>Nominee Name</td>
       <td><asp:TextBox ID="txtNomiName" runat="server" ReadOnly="True"></asp:TextBox></td></tr>
    <tr>
       <td>Nominee Address</td>
       <td><asp:TextBox ID="txtNomiAddress" runat="server" ReadOnly="True"></asp:TextBox></td></tr>
    <tr>
       <td>Account Type</td>
       <td><asp:TextBox ID="txtAcctype" runat="server" ReadOnly="True">Savings</asp:TextBox></td></tr>
    <tr>
       <td>Initial Amount</td>
       <td><asp:TextBox ID="txtInitialAmt" runat="server" ReadOnly="True">1200</asp:TextBox></td></tr>
       <tr>
       <td colspan="2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label 
               ID="lblMessage" runat="server"></asp:Label>
           &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                    &nbsp;<asp:Button ID="btnGenPwdSub" runat="server" 
               Text="Generate Account ID And Password" onclick="btnGenPwdSub_Click"/></td></tr>
    </table>
    
    </div>
    
</asp:Content>
