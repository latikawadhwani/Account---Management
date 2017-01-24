<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewPersonalDetails.aspx.cs" Inherits="AccountOpening_Team1.ViewPersonalDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table>
    <tr>
       <td>Name</td>
       <td><asp:TextBox ID="txtName" runat="server" ReadOnly="true"></asp:TextBox></td>
    </tr>

    <tr>
       <td>Date of Birth</td>
       <td><asp:TextBox ID ="txtDOB" runat="server" ReadOnly="true"></asp:TextBox></td>
    </tr>
    <tr>
       <td>Father Name/Spouse Name</td>
       <td><asp:TextBox ID="txtFSName" runat="server" ReadOnly="true"></asp:TextBox></td></tr>
    <tr>
       <td>Gender</td>
       <td><asp:TextBox ID="txtGender" runat="server" ReadOnly="true"></asp:TextBox></td></tr>
    <tr>
       <td>Marital Status</td>
       <td><asp:DropDownList ID="ddlMStatus" runat ="server" Enabled="False">
           <asp:ListItem>Married</asp:ListItem>
           <asp:ListItem>Single</asp:ListItem>
           <asp:ListItem>Widow</asp:ListItem>
           <asp:ListItem>Divorced</asp:ListItem>
           </asp:DropDownList></td><td></td><td>
        <asp:LinkButton ID="LinkButton1" runat="server" 
            onclick="lnkEditMaritalStatus_Click">Edit</asp:LinkButton></td></tr>
    <tr>
       <td>Contact Details</td>
       <td><asp:TextBox ID="txtContDetails" runat="server" ReadOnly="true"></asp:TextBox></td></tr>
    <tr>
       <td>Nominee Name<asp:RequiredFieldValidator ID="rfvNominee" runat="server" ErrorMessage="*" 
            ForeColor="Red" ControlToValidate="txtNomiName" ValidationGroup="upd"></asp:RequiredFieldValidator></td>
       <td><asp:TextBox ID="txtNomiName" runat="server" ReadOnly="true"></asp:TextBox></td><td><asp:RegularExpressionValidator ID="revName" ErrorMessage="Invalid Name" 
                runat="server" ControlToValidate="txtName" Display="Dynamic" ForeColor="Red" 
                ValidationExpression="[ ]{0}[a-z]{2,20}[ ][a-z]{2,20}[ ]{0,1}[a-z]{2,20}" 
                ValidationGroup="upd"></asp:RegularExpressionValidator></td><td>
        <asp:LinkButton ID="lnkEditNomineeName" runat="server" 
            onclick="lnkEditNomineeName_Click">Edit</asp:LinkButton></td></tr>
    <tr>
       <td>Nominee Address<asp:RequiredFieldValidator ID="rfvAddress" runat="server" ErrorMessage="*" 
            ForeColor="Red" ControlToValidate="txtNomiAddress" ValidationGroup="upd"></asp:RequiredFieldValidator></td><td>
        
            <asp:TextBox ID="txtNomiAddress" runat="server" ReadOnly="true"></asp:TextBox>
        
</td>
       <td></td><td>
        <asp:LinkButton ID="lnkEditNomineeAddress" runat="server" 
            onclick="lnkEditNomineeAddress_Click">Edit</asp:LinkButton></td></tr>
   
       <tr>
       <td colspan="2" align="center">
           <asp:Button ID="btnUpdate" runat="server" 
               Text="Update" onclick="btnUpdate_Click" style="height: 26px" 
               ValidationGroup="upd"/></td></tr>
    </table>
    
</asp:Content>
