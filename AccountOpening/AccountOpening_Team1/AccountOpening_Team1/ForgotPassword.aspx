<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ForgotPassword.aspx.cs" Inherits="AccountOpening_Team1.ForgotPassword" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div><center>
    <table><tr><th colspan="4">Reset Password</th></tr>
<tr><td>Enter Customer ID</td><td><asp:TextBox ID="txtUser" runat="server"></asp:TextBox></td><td>
    <asp:RequiredFieldValidator ID="rfvCustID" runat="server" 
        ControlToValidate="txtUser" ErrorMessage="Please Enter Customer ID" ></asp:RequiredFieldValidator></td></tr>
<tr><td>Answer to Secret Question</td><td><asp:TextBox ID="txtAnswer" runat="server"></asp:TextBox></td><td>
    <asp:RequiredFieldValidator ID="rfvSecret" runat="server" 
        ControlToValidate="txtAnswer" ErrorMessage="Please Answer Secret Question"></asp:RequiredFieldValidator></td></tr>
<tr><td>New Password</td><td><asp:TextBox ID="txtNewPassword" runat="server" 
        TextMode="Password"></asp:TextBox></td><td>
    <asp:RequiredFieldValidator ID="rfxNewPassword" runat="server" 
        ControlToValidate="txtNewPassword" ErrorMessage="Set New Password"></asp:RequiredFieldValidator></td><td>
            <asp:PasswordStrength ID="PasswordStrength1" runat="server" StrengthIndicatorType="BarIndicator" DisplayPosition="RightSide" TargetControlID="txtNewPassword" PrefixText="Stength:" Enabled="true"
RequiresUpperAndLowerCaseCharacters="true" MinimumLowerCaseCharacters="1"
 MinimumUpperCaseCharacters="1" MinimumSymbolCharacters="1"
MinimumNumericCharacters="1" PreferredPasswordLength="10"
 TextStrengthDescriptions="VeryPoor; Weak; Average; Strong; Excellent"
StrengthStyles="VeryPoor; Weak; Average; Excellent; Strong;"
 CalculationWeightings="25;25;15;35" BarBorderCssClass="border" HelpStatusLabelID="lblHelp">
            </asp:PasswordStrength><label id="lblHelp" runat="server"></label>
        </td></tr>
<tr><td>Confirm New Password</td><td><asp:TextBox ID="txtConfirmPassword" 
        runat="server" TextMode="Password"></asp:TextBox></td><td>
    <asp:RequiredFieldValidator ID="rfvConfirm" runat="server" 
        ControlToValidate="txtConfirmPassword" ErrorMessage="Please Confirm Password"></asp:RequiredFieldValidator></td><td>
        <asp:CompareValidator ID="rfvCompare" runat="server" 
            ControlToCompare="txtNewPassword" ControlToValidate="txtConfirmPassword" 
            ErrorMessage="Password Do Not Match" Display="Dynamic"></asp:CompareValidator></td></tr>
<tr><td colspan="2"><asp:Button ID="btnSubmit" runat="server" Text="Reset" 
        onclick="btnSubmit_Click" /></td><td><asp:Button ID="btnCancel" runat="server" 
            Text="Cancel" onclick="btnCancel_Click" /></td></tr>
</table></center>
    </div>
    </form>
</body>
</html>
