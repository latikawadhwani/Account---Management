<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CustomerRegistration.aspx.cs" Inherits="AccountOpening_Team1.CustomerRegistration" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>


   <div>
        &nbsp;
        <table class=".tablebg">
            <tr>
                <th colspan="3">
                    Customer Registration
                    <br />
                    <br />
                </th>
            </tr>
            <tr>
                <td class="style7">
                    <asp:Label ID="lblName" runat="server" Text="Name"></asp:Label>
                </td>
                <td class="style6">
                    <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                </td>
                <td >
                    <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtName"
                        Display="Dynamic" ErrorMessage="Name Can't Be Left Blank " ForeColor="Red" 
                        SetFocusOnError="True" ValidationGroup="validationsubmit"></asp:RequiredFieldValidator><br />
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtName"
                        Display="Dynamic" 
                        
                        ErrorMessage="Please Enter Full Name in Standard Format(eg. pankaj gupta)" ForeColor="Red"
                        SetFocusOnError="True" 
                        ValidationExpression="[ ]{0}[a-z]{2,20}[ ][a-z]{2,20}[ ]{0,1}[a-z]{2,20}" 
                        ValidationGroup="validationsubmit"></asp:RegularExpressionValidator>
                    
                </td><td></td>
            </tr>
            <tr>
                <td class="style7">
                    <asp:Label ID="lblDob" runat="server" Text="Date of Birth"></asp:Label>
                </td>
                <td class="style6">
                    <asp:TextBox ID="txtDob" runat="server"></asp:TextBox><asp:CalendarExtender
                        ID="CalendarExtender1" runat="server" TargetControlID="txtDob" PopupButtonID="btncalender">

                    </asp:CalendarExtender>
                    <asp:Button ID="btnCalender" runat="server" Text="..." Font-Size="X-Small" />

                    <br />
                </td>
                <td class="style5">
                    <asp:RequiredFieldValidator ID="rfvDob" runat="server" 
                        ControlToValidate="txtDob" Display="Dynamic" 
                        ErrorMessage="Date Of Birth Can't be Blank" ForeColor="Red" 
                        SetFocusOnError="True" ValidationGroup="validationsubmit"></asp:RequiredFieldValidator>
                    <asp:RangeValidator ID="RangeValidator1" runat="server" 
                        ControlToValidate="txtDob" Display="Dynamic" ForeColor="Red" 
                        MaximumValue="DateTime.Today.ToShortDateString()" 
                        MinimumValue="DateTime.Today.AddYears(-110).ToShortDateString()" 
                        SetFocusOnError="True" Type="Date" ValidationGroup="validationsubmit"></asp:RangeValidator>
                  </td>
            </tr>
            
            <tr>
                <td class="style7">
                    <asp:Label ID="lblFatherName" runat="server" Text="Father's Name/Spouse Name">
                    </asp:Label>
                </td>
                <td class="style6">
                    <asp:TextBox ID="txtFatherName" runat="server"></asp:TextBox>
                </td>
                <td class="style5">
                    <asp:RequiredFieldValidator ID="rfvFatherName" runat="server" ControlToValidate="txtFatherName"
                        Display="Dynamic" ErrorMessage="Father Name Can't be Blank" 
                        ForeColor="Red" SetFocusOnError="True" ValidationGroup="validationsubmit"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="rfvFather" runat="server" ControlToValidate="txtFatherName"
                        Display="Dynamic" 
                        ErrorMessage="Please Enter Father Name in Standard Formate " ForeColor="Red"
                        SetFocusOnError="True" 
                        ValidationExpression="[ ]{0}[a-z]{2,20}[ ][a-z]{2,20}[ ]{0,1}[a-z]{2,20}" 
                        ValidationGroup="validationsubmit"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td class="style7">
                    <asp:Label ID="lblGender" runat="server" Text="Gender">
                    </asp:Label>
                </td>
                <td class="style6">
                    <asp:RadioButtonList ID="rdbGender" runat="server">
                        <asp:ListItem>Male</asp:ListItem>
                        <asp:ListItem>Female</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
                <td class="style5">
                    <asp:RequiredFieldValidator ID="rfvGender" runat="server" ControlToValidate="rdbGender"
                        Display="Dynamic" ErrorMessage="Please Select One Option For Gender" ForeColor="Red" 
                        SetFocusOnError="True" ValidationGroup="validationsubmit"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style7">
                    <asp:Label ID="lblMaritalStatus" runat="server" Text="Marital Status">
                    </asp:Label>
                </td>
                <td class="style6">
                    <asp:DropDownList ID="ddlMaritalStatus" runat="server">
                        <asp:ListItem>Select</asp:ListItem>
                        <asp:ListItem>Single</asp:ListItem>
                        <asp:ListItem>Married</asp:ListItem>
                        <asp:ListItem>Widow</asp:ListItem>
                        <asp:ListItem>Divorced</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td class="style5">
                    <asp:RequiredFieldValidator ID="rfvMarital" runat="server" 
                        ControlToValidate="ddlMaritalStatus" Display="Dynamic" 
                        ErrorMessage="Please Select One Option For Marital Status" ForeColor="Red" InitialValue="Select" 
                        SetFocusOnError="True" ValidationGroup="validationsubmit"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style7">
                    <asp:Label ID="lblCommunicationAddress" runat="server" Text="Communication Address">
                    </asp:Label>
                </td>
                <td class="style6">
                    <asp:TextBox ID="txtCommunicationAddress" runat="server" TextMode="MultiLine"></asp:TextBox>
                </td>
                <td class="style5">
                    <asp:RequiredFieldValidator ID="rfvAddress" runat="server" ControlToValidate="txtCommunicationAddress"
                        Display="Dynamic" ErrorMessage="Communication Address Can't be Blank " ForeColor="Red" 
                        SetFocusOnError="True" InitialValue=" " ValidationGroup="validationsubmit"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" 
                        ControlToValidate="txtCommunicationAddress" Display="Dynamic" 
                        ErrorMessage="Invalid Communication Address" ForeColor="Red" 
                        SetFocusOnError="True" 
                        ValidationExpression="[ ]{0}[0-9,A-Z,a-z]{1}[0-9,a-z,A-Z,/,,,-, ]{0,40}" 
                        ValidationGroup="validationsubmit"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td class="style7">
                    <asp:Label ID="lblContactDetails" runat="server" Text="Contact details">
                    </asp:Label>
                </td>
                <td class="style6">
                    &nbsp;<asp:Label ID="Label1" runat="server" Text="+91"></asp:Label>
                    <asp:TextBox ID="txtContactDetails" runat="server"></asp:TextBox>
                </td>
                <td class="style5">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtContactDetails"
                        Display="Dynamic" ErrorMessage="Contact no can't be Blank" ForeColor="Red" 
                        SetFocusOnError="True" ValidationGroup="validationsubmit"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtContactDetails"
                        Display="Dynamic" ErrorMessage="Invalid Contact Number" ForeColor="Red"
                        SetFocusOnError="True" ValidationExpression="[7-9]{1}[0-9]{9}" 
                        ValidationGroup="validationsubmit"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td class="style7">
                    <asp:Label ID="lblNomineeName" runat="server" Text="Nominee Name">
                    </asp:Label>
                </td>
                <td class="style6">
                    <asp:TextBox ID="txtNomineeName" runat="server"></asp:TextBox>
                </td>
                <td class="style5">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtNomineeName"
                        Display="Dynamic" ErrorMessage="Nominee Name Can't be Blank " ForeColor="Red" 
                        SetFocusOnError="True" ValidationGroup="validationsubmit"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtNomineeName"
                        Display="Dynamic" 
                        ErrorMessage="Please Enter Nominee Name  in Standard Format" ForeColor="Red"
                        SetFocusOnError="True" 
                        ValidationExpression="[ ]{0}[a-z]{2,20}[ ][a-z]{2,20}[ ]{0,1}[a-z]{2,20}" 
                        ValidationGroup="validationsubmit"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td class="style7">
                    <asp:Label ID="lblNomineeAddress" runat="server" Text="Nominee Address">
                    </asp:Label>
                </td>
                <td class="style6">
                    <asp:TextBox ID="txtNomineeAddress" runat="server" TextMode="MultiLine"></asp:TextBox>
                </td>
                <td class="style5">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtNomineeAddress"
                        Display="Dynamic" ErrorMessage="Nominee Address Can't be Blank " ForeColor="Red" 
                        SetFocusOnError="True" ValidationGroup="validationsubmit"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" 
                        ControlToValidate="txtNomineeAddress" Display="Dynamic" 
                        ErrorMessage="Invalid Nominee Address" ForeColor="Red" SetFocusOnError="True" 
                        ValidationExpression="[ ]{0}[0-9,A-Z,a-z]{1}[0-9,a-z,A-Z,/,,,-, ]{0,40}" 
                        ValidationGroup="validationsubmit"></asp:RegularExpressionValidator>
                </td>
            </tr>
            
            <tr>
                <td class="style7" >
                    ID Proof Document
                </td>
                <td id=" " class="style6" >
                    <asp:FileUpload ID="fileupload1" runat="server"/>
      
                     <br />
                    <asp:Label ID="lblIdProofMessage" runat="server"></asp:Label>
      
                     <br />
      
                        </td>

                <td class="style5" >
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" 
                        ControlToValidate="FileUpload1" Display="Dynamic" 
                        ErrorMessage="Please Upload Id Proof Document" ForeColor="Red" 
                        SetFocusOnError="True" ValidationGroup="validationsubmit"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style7">
                    Status of ID Proof
                </td>
                <td class="style6">

                    <asp:DropDownList ID="ddlStatusOfIdProof" runat="server" Enabled="False">
                        <asp:ListItem Selected="True">Not Uploaded</asp:ListItem>
                        <asp:ListItem>Pending</asp:ListItem>
                    </asp:DropDownList>
                    <br />
                </td>
                <td class="style5">
                    &nbsp;</td>
            </tr>
           
            <tr>
                <td class="style7">
                    Address proof document
                </td>
                <td class="style6">
                    <asp:FileUpload ID="FileUpload2" runat="server" />
                    <br />
                    <asp:Label ID="lblAddProofMessage" runat="server"></asp:Label>
                </td>
                <td class="style5">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" 
                        ControlToValidate="FileUpload2" Display="Dynamic" 
                        ErrorMessage="Please Upload Address Proof Document" ForeColor="Red" 
                        SetFocusOnError="True" ValidationGroup="validationsubmit"></asp:RequiredFieldValidator>
                </td>
            </tr>
             <tr>
                <td class="style7">
                    Status of address proof
                </td>
                <td class="style6">
                    <asp:DropDownList ID="ddlStatusOfAddressProof" runat="server" Enabled="False">
                        <asp:ListItem>Not Uploaded</asp:ListItem>
                        <asp:ListItem>Pending</asp:ListItem>
                    </asp:DropDownList>
                    <br />
                </td>
                <td class="style5">
                    &nbsp;</td>
            </tr>
            <tr>
                <td align="center" class="style7">
                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" 
                        OnClick="btnSubmit_Click" ValidationGroup="validationsubmit" />
                </td>
                <td align="center" class="style6">
                    <asp:Button ID="btnreset" runat="server" OnClick="btnreset_Click" Text="Reset" />
                </td>
            </tr>
        </table>
        </div>
  
</asp:Content>
