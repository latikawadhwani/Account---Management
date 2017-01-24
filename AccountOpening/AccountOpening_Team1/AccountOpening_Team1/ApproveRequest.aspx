<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="ApproveRequest.aspx.cs" Inherits="AccountOpening_Team1.ApproveRequest" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server"><div style="overflow-x:auto;width:600px">
      <asp:GridView ID="grdApproveRequest" runat="server" AutoGenerateColumns="False" Width="189%"
            style="margin-left: 0px"            
            onrowcommand="grdApproveRequest_RowCommand" 
            >
            <Columns>
                <asp:ButtonField CommandName="ApproveCust" Text="Approve" />
                <asp:ButtonField CommandName="RejectCust" Text="Reject" />
                <asp:BoundField DataField="RegistrationID" HeaderText="id" />
                <asp:BoundField DataField="CustomerName" HeaderText="Name" />
                <asp:BoundField DataField="DateOfBirth" HeaderText="Date of Birth" 
                    DataFormatString="{0:MMMM d, yyyy}" />
                <asp:BoundField DataField="Gender" HeaderText="Gender" />
                <asp:BoundField DataField="CommunicationAddress" 
                    HeaderText="CommunicationAddress" />
                <asp:BoundField DataField="NomineeName" HeaderText="NomineeName" />
                <asp:BoundField DataField="NomineeAddress" HeaderText="NomineeAddress" />
                <asp:BoundField DataField="IDProofStatus" HeaderText="IDProofStatus" />
                <asp:BoundField DataField="AddressProofStatus" 
                    HeaderText="AddressProofStatus" />
            </Columns>
        </asp:GridView></div>
      <asp:Label ID="lblMessage" runat="server"></asp:Label>
</asp:Content>
