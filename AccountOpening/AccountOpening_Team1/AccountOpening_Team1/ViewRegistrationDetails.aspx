<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewRegistrationDetails.aspx.cs" Inherits="AccountOpening_Team1.ViewRegistrationDetails" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style5
        {
            width: 144px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    
    <table>
    
    
    <tr><th colspan="3">View Registered Customer<br /><br /></th></tr>
    
   
     <tr><td valign="top" class="style5"> <asp:Label ID="lblRequestDate" runat="server" Text=" Submit Request Date"></asp:Label>
    </td>
    <td><asp:TextBox ID="txtrequestdate" runat="server"></asp:TextBox>
  
        <asp:CalendarExtender ID="CalendarExtender1" runat="server" 
            TargetControlID="txtrequestdate" >
        </asp:CalendarExtender>
 
            </td>
            <td valign="top">    
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="txtrequestdate" Display="Dynamic" 
                    ErrorMessage="Please Enter Request Date" ForeColor="Red" 
                    SetFocusOnError="True" ValidationGroup="submitgroup"></asp:RequiredFieldValidator>
                <asp:RangeValidator ID="RangeValidator1" runat="server" 
                    ControlToValidate="txtrequestdate" Display="Dynamic" ForeColor="Red" 
                    MaximumValue="DateTime.Today.ToShortDateString()" 
                    MinimumValue="DateTime.Today.AddYears(-110).ToShortDateString()" 
                    SetFocusOnError="True" Type="Date" ValidationGroup="submitgroup"></asp:RangeValidator>
         </td></tr>
    
    <tr><td class="style5" colspan="3">&nbsp;</td></tr>
    <tr><td class="style5">  </td>
       <td>
        <asp:Button ID="btnsubmit" runat="server" Text="Submit" 
               onclick="btnsubmit_Click" ValidationGroup="submitgroup" /> 
            
    </td><td></td>
        </tr>
        <tr><td class="style5" colspan="3">&nbsp;</td></tr>
        <tr><td colspan="3" align="center" style="color:Blue; font-size:larger;">
            <asp:Label ID="lblShowMessage" runat="server" Font-Bold="True" 
                Font-Size="Larger"></asp:Label></td></tr>
    </table>
    </div>
    <asp:GridView ID="grdviewcustomerdetails" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="CustomerName" HeaderText="Name" ReadOnly="True" 
                SortExpression="CustomerName" />
            <asp:BoundField DataField="DateOfBirth" HeaderText="DOB" ReadOnly="True" 
                SortExpression="DateOfBirth" DataFormatString="{0:MMMM d, yyyy}" />
            <asp:BoundField DataField="Gender" HeaderText="Gender" ReadOnly="True" 
                SortExpression="Gender" />
            <asp:BoundField DataField="CommunicationAddress" 
                HeaderText="Communication Address" ReadOnly="True" 
                SortExpression="CommunicationAddress" />
            <asp:BoundField DataField="NomineeName" HeaderText="Nominee Name" 
                ReadOnly="True" SortExpression="NomineeName" />
            <asp:BoundField DataField="NomineeAddress" HeaderText="Nominee Address" 
                ReadOnly="True" SortExpression="NomineeAddress" />
            <asp:BoundField DataField="IDProofStatus" HeaderText="ID Proof Status" 
                ReadOnly="True" SortExpression="IDProofStatus" />
            <asp:BoundField DataField="AddressProofStatus" 
                HeaderText="Address Proof Status" ReadOnly="True" 
                SortExpression="AddressProofStatus" />
        </Columns>
    </asp:GridView>
   
</asp:Content>
