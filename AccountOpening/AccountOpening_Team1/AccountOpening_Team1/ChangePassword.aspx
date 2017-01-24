<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="AccountOpening_Team1.ChangePassword" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>
    <style type="text/css">
      .VeryPoor
       {
         background-color:red;
         }

          .Weak
        {
         background-color:orange;
         }

          .Average
         {
          background-color: #A52A2A
         }
          .Excellent
         {
         background-color:yellow;
         }
          .Strong
         {
         background-color:green;
         }
          .border
         {
          border: medium solid #800000;
          width:500px;                
         }
      </style>


    </title>
</head>
<body><center>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
   <table><tr><td colspan="3">Change Password</td></tr>
<tr><td>Old Password</td><td><asp:TextBox ID="txtOldPassword" runat="server" 
        TextMode="Password"></asp:TextBox></td><td>
    <asp:RequiredFieldValidator ID="rfvOld" runat="server" 
        ErrorMessage="Please enter old password" 
        ControlToValidate="txtOldPassword" ValidationGroup="g1"></asp:RequiredFieldValidator></td></tr>
<tr><td>New Password</td><td><asp:TextBox ID="txtNewPassword" runat="server" 
        TextMode="Password"></asp:TextBox></td><td>
    <asp:RequiredFieldValidator ID="rfvNew" runat="server" 
        ControlToValidate="txtNewPassword" 
        ErrorMessage="Please enter new password" ValidationGroup="g1"></asp:RequiredFieldValidator></td><td>
    <asp:PasswordStrength ID="PasswordStrength1" runat="server" StrengthIndicatorType="BarIndicator" DisplayPosition="RightSide" TargetControlID="txtNewPassword" PrefixText="Stength:" Enabled="true"
RequiresUpperAndLowerCaseCharacters="true" MinimumLowerCaseCharacters="1"
 MinimumUpperCaseCharacters="1" MinimumSymbolCharacters="1"
MinimumNumericCharacters="1" PreferredPasswordLength="10"
 TextStrengthDescriptions="VeryPoor; Weak; Average; Strong; Excellent"
StrengthStyles="VeryPoor; Weak; Average; Excellent; Strong;"
 CalculationWeightings="25;25;15;35" BarBorderCssClass="border" HelpStatusLabelID="Label1">
    </asp:PasswordStrength></td><td>

    &nbsp;<asp:Label ID="Label1" runat="server" Font-Bold="true" Font-Size="Medium"
ForeColor="Brown"></asp:Label></td>

</tr>
<tr><td> Confirm New Password</td><td><asp:TextBox ID="txtConfirmPassword" 
        runat="server" TextMode="Password"></asp:TextBox></td><td>
    <asp:RequiredFieldValidator ID="rfvConfirm" runat="server" 
        ControlToValidate="txtConfirmPassword" 
        ErrorMessage="Please confirm new password" ValidationGroup="g1"></asp:RequiredFieldValidator></td><td>
    <asp:CompareValidator ID="cmpPass" runat="server" 
        ControlToCompare="txtNewPassword" ControlToValidate="txtConfirmPassword" 
        ErrorMessage="Passwords do not match" ValidationGroup="g1"></asp:CompareValidator></td></tr>
<tr><td>
    <asp:Button ID="btnSubmit" Text="Submit" runat="server" 
        onclick="btnSubmit_Click" ValidationGroup="g1" /></td><td>
        <asp:Button ID="btnCancel" Text="Cancel" runat="server" 
            onclick="btnCancel_Click" /></td></tr></table>

    </div>
    </form></center>
</body>
</html>
