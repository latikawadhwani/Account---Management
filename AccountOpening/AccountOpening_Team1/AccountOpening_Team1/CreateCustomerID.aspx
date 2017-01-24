<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="CreateCustomerID.aspx.cs" Inherits="AccountOpening_Team1.CreateCustomerID" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server"><div>
   <div>
        <table align="center">
            <tr align="center">
                <th colspan="2">
                    Add Customer To Bank
                    <br />
                    <br />
                </th>
            </tr>
            <tr>
                <td valign="top">
                    &nbsp;</td>
                <td align="center" valign="middle">
                    &nbsp;</td>
            </tr>
        </table>
    </div>
    <asp:GridView ID="grdAddCustomer" runat="server" AutoGenerateColumns="False" 
        onrowcommand="grdAddCustomer_RowCommandMethod"  
       >
        <Columns>
            
            <asp:ButtonField CommandName="AddCustomer" HeaderText="Add Customer To Bank" 
                Text="Add Customer To Bank" />
            
            <asp:BoundField DataField="RegistrationID" HeaderText="Registration ID" />
            
            <asp:BoundField DataField="CustomerName" HeaderText="Name" ReadOnly="True" SortExpression="name" />
            <asp:BoundField DataField="DateOfBirth" HeaderText="DOB" ReadOnly="True" SortExpression="dob" />
            <asp:BoundField DataField="Gender" HeaderText="Gender" ReadOnly="True" SortExpression="gender" />
            <asp:BoundField DataField="CommunicationAddress" HeaderText="Communication Address"
                ReadOnly="True" SortExpression="communication address" />
            <asp:BoundField DataField="NomineeName" HeaderText="Nominee Name" ReadOnly="True"
                SortExpression="nominee name" />
            <asp:BoundField DataField="NomineeAddress" HeaderText="Nominee Address" ReadOnly="True"
                SortExpression="nominee address" />
            <asp:BoundField DataField="IDProofStatus" HeaderText="ID Proof Status" />
            <asp:BoundField DataField="AddressProofStatus" HeaderText="Address Proof Status" />
            <asp:BoundField DataField="ContactDetails" HeaderText="Contact No." />
        </Columns>
    </asp:GridView>
</asp:Content>
