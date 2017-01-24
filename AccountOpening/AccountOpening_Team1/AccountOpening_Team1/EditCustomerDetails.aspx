<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="EditCustomerDetails.aspx.cs" Inherits="AccountOpening_Team1.EditCustomerDetails" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <!--Sutrishna-->
    <div>
        <asp:MultiView ID="mtv1" runat="server">
            <asp:View ID="view1" runat="server">
                <table align="center">
                    <tr align="center">
                        <th colspan="2">
                            Edit Registered Customer
                            <br />
                            <br />
                        </th>
                    </tr>
                    <tr>
                        <td valign="top">
                            <asp:Label ID="lblRequestDate" runat="server" Text=" Submit Request Date"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtcalenderreq" runat="server" 
                               ValidationGroup="validationsubmit"></asp:TextBox>
                       
                            <asp:CalendarExtender ID="CalendarExtender2" runat="server" 
                                TargetControlID="txtcalenderreq" PopupButtonID="btncalender">
                            </asp:CalendarExtender>
                            <asp:Button ID="btncalender" runat="server" Text="..." Font-Size="X-Small" />

                    <br />
                        </td>
                        <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" 
                        ControlToValidate="txtdob" Display="Dynamic" 
                        ErrorMessage="Date Of Birth Can't be Blank" ForeColor="Red" 
                        SetFocusOnError="True" ValidationGroup="validationsubmit"></asp:RequiredFieldValidator>
                </td>
                       
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                            <asp:Button ID="btnsubmit" runat="server" Text="Submit"
                            OnClick="btnsubmit_Click" ValidationGroup="validationsubmit" />
                        </td>
                    </tr>
                </table>
                <asp:GridView ID="grdeditcustomerdetails" runat="server" 
                    AutoGenerateColumns="False" 
                        onrowediting="grdeditcustomerdetails_RowEditing"
                    >
                    <Columns>
                        <asp:ButtonField CommandName="Edit" HeaderText="Edit" Text="Edit" />
                        <asp:BoundField DataField="RegistrationID" HeaderText="RegistrationID" 
                            ReadOnly="True" />
                        <asp:BoundField DataField="CustomerName" HeaderText="Name" ReadOnly="True" SortExpression="CustomerName" />
                        <asp:BoundField DataField="DateOfBirth" HeaderText="DOB" ReadOnly="True" 
                            SortExpression="DateOfBirth" DataFormatString="{0:MMMM d, yyyy}" />
                        <asp:BoundField DataField="FatherName" HeaderText="FatherName" ReadOnly="True" SortExpression="FatherName" />
                        <asp:BoundField DataField="Gender" HeaderText="Gender" ReadOnly="True" SortExpression="Gender" />
                        <asp:BoundField DataField="MaritalStatus" HeaderText="MaritalStatus" ReadOnly="True"
                            SortExpression="MaritalStatus" />
                        <asp:BoundField DataField="CommunicationAddress" HeaderText="CommunicationAddress"
                            ReadOnly="True" SortExpression="CommunicationAddress" />
                        <asp:BoundField DataField="ContactDetails" HeaderText="ContactDetails " ReadOnly="True"
                            SortExpression="ContactDetails " />
                        <asp:BoundField DataField="NomineeName" HeaderText="Nominee Name" ReadOnly="True"
                            SortExpression="NomineeName" />
                        <asp:BoundField DataField="NomineeAddress" HeaderText="NomineeAddress" ReadOnly="True"
                            SortExpression="NomineeAddress" />
                        
                        <asp:BoundField DataField="IDProofStatus" HeaderText="IDProofStatus" ReadOnly="True"
                            SortExpression="IDProofStatus" />
                       
                        <asp:BoundField DataField="AddressProofStatus" HeaderText="AddressProofStatus " ReadOnly="True"
                            SortExpression="AddressProofStatus " />
                    </Columns>
                </asp:GridView> 
                <asp:Label ID="lblMessage" runat="server"></asp:Label>
            </asp:View>
            <asp:View ID="view2" runat="server">
                <table align="center">
                    <tr>
                        <th colspan="2">
                            Edit Customer Personal Details
                            <br />
                            <br />
                        </th>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblname" runat="server" Text="Name"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                        </td><td >
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
                        <td>
                            <asp:Label ID="lbldob" runat="server" Text="Date of Birth"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtdob" runat="server"></asp:TextBox>
                        </td>
                         <td class="style5">
                    <asp:RequiredFieldValidator ID="rfvDob" runat="server" 
                        ControlToValidate="txtDob" Display="Dynamic" 
                        ErrorMessage="Date Of Birth Can't be Blank" ForeColor="Red" 
                        SetFocusOnError="True" ValidationGroup="validationsubmit"></asp:RequiredFieldValidator>
                  </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                            <asp:CalendarExtender ID="CalendarExtender1" runat="server" 
                                TargetControlID="txtdob">
                            </asp:CalendarExtender>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblfathername" runat="server" Text="Father's Name/Spouse Name">
                            </asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtFatherName" runat="server"></asp:TextBox>
                        </td> <td class="style5">
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
                        <td>
                            <asp:Label ID="lblgender" runat="server" Text="Gender">
                            </asp:Label>
                        </td>
                        <td>
                            <asp:RadioButtonList ID="rdbGender" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem>Male</asp:ListItem>
                                <asp:ListItem>Female</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>  <td class="style5">
                    <asp:RequiredFieldValidator ID="rfvGender" runat="server" ControlToValidate="rdbGender"
                        Display="Dynamic" ErrorMessage="Please Select One Option For Gender" ForeColor="Red" 
                        SetFocusOnError="True" ValidationGroup="validationsubmit"></asp:RequiredFieldValidator>
                </td>
            
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblmaritalstatus" runat="server" Text="Marital Status">
                            </asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlMaritalStatus" runat="server">
                                <asp:ListItem>Single</asp:ListItem>
                                <asp:ListItem>Married</asp:ListItem>
                                <asp:ListItem>Widow</asp:ListItem>
                                <asp:ListItem>Divorced</asp:ListItem>
                            </asp:DropDownList>
                        </td><td class="style5">
                    <asp:RequiredFieldValidator ID="rfvMarital" runat="server" 
                        ControlToValidate="ddlMaritalStatus" Display="Dynamic" 
                        ErrorMessage="Please Select One Option For Marital Status" ForeColor="Red" InitialValue="Select" 
                        SetFocusOnError="True" ValidationGroup="validationsubmit"></asp:RequiredFieldValidator>
                </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblcommunicationaddress" runat="server" Text="Communication Address">
                            </asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtCommunicationAddress" runat="server"></asp:TextBox>
                        </td><td class="style5">
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
                        <td>
                            <asp:Label ID="lblcontactdetails" runat="server" Text="Contact details">
                            </asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtContactDetails" runat="server"></asp:TextBox>
                        </td><td class="style5">
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
                        <td>
                            Nominee Name</td>
                        <td>
                            <asp:TextBox ID="txtNomineeName" runat="server"></asp:TextBox>
                        </td> <td class="style5">
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
                        <td>
                            Nominee Address</td>
                        <td>
                            <asp:TextBox ID="txtNomineeAddress" runat="server"></asp:TextBox>
                        </td> <td class="style5">
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
                        <td>
                            Status of ID Proof
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlstatusofidproof" runat="server" Enabled="False">
                               
                                <asp:ListItem>Approved</asp:ListItem>
                                <asp:ListItem>Pending</asp:ListItem>
                                <asp:ListItem>Rejected</asp:ListItem>
                            </asp:DropDownList>
                            <br />
                        </td>
                    </tr>
                   
                    <tr>
                        <td>
                            Status of address proof
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlstatusofaddressproof" runat="server" Enabled="False">
                               
                                <asp:ListItem>Approved</asp:ListItem>
                                <asp:ListItem>Pending</asp:ListItem>
                                <asp:ListItem>Rejected</asp:ListItem>
                            </asp:DropDownList>
                            <br />
                        </td>
                    </tr>
                    
                    <tr>
                        <td align="right">
                            <asp:Button ID="btnupdatesubmit" runat="server" Text="Submit" onclick="btnupdatesubmit_Click" 
                                 />
                        </td>
                        <td>
                        <asp:Button ID="btncancel" runat="server" Text="Cancel" />
                        </td>
                    </tr>
                </table>
            </asp:View>
        </asp:MultiView>
    </div>
    <div>
        <br />
    </div>
</asp:Content>
