<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SetSecretQuestion.aspx.cs" Inherits="AccountOpening_Team1.SetSecretQuestion" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div><table><tr><td colspan="2">Set Secret Question</td></tr><tr><td>Select Secret Question</td><td>
    <asp:DropDownList ID="ddlSelectSecretQuestion" runat="server">
        <asp:ListItem>Your Favourite Colour</asp:ListItem>
        <asp:ListItem>Birth City</asp:ListItem>
        <asp:ListItem>Favourite Movie</asp:ListItem>
        <asp:ListItem>Mother&#39;s Maiden Name</asp:ListItem>
        <asp:ListItem>First School</asp:ListItem>
        <asp:ListItem>Other</asp:ListItem>
    </asp:DropDownList></td></tr>
    <tr><td>Answer</td><td><asp:TextBox ID="txtAnswer" runat="server"></asp:TextBox></td></tr>
    <tr><td><asp:Button ID="btnSubmit" runat="server" Text="Submit" 
            onclick="btnSubmit_Click" /></td><td><asp:Button ID="btnCancel" runat="server" 
                Text="Cancel" onclick="btnCancel_Click" /></td></tr></table>
    </div>
    </form>
</body>
</html>
