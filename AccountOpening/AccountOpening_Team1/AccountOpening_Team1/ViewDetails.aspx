<%@ Page Title="View Details" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="ViewDetails.aspx.cs" Inherits="AccountOpening_Team1.ViewDetails" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div>
        <table align="center">
            <tr>
                <td>
                    Select Details
                </td>
                <td>
                    <asp:RadioButtonList ID="rdbDate" runat="server" RepeatDirection="Horizontal" AutoPostBack="True"
                        OnSelectedIndexChanged="rdbDateSelectedIndexChanged">
                        <asp:ListItem>View by Date</asp:ListItem>
                        <asp:ListItem>View All</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
        </table>
    </div>
    <asp:MultiView ID="multBMDetails" runat="server">

     <asp:View ID="ViewByDate" runat="server">
                <table>
                    <tr>
                        <td>
                            Select date <asp:TextBox ID="txtDate" runat="server"></asp:TextBox> 
                            <asp:Button ID="btnDate" runat="server" Text="..."/>
                            
                            <asp:RequiredFieldValidator ID="rfvDob" runat="server" 
                        ControlToValidate="txtDate" Display="Dynamic" 
                        ErrorMessage="Date Of Birth Can't be Blank" ForeColor="Red" 
                        SetFocusOnError="True" ValidationGroup="validationsubmit"></asp:RequiredFieldValidator>
                            
                            <asp:CalendarExtender ID="CalendarExtender1" runat="server" PopupButtonID="btnDate" TargetControlID="txtDate">
                            </asp:CalendarExtender>
                            <%--<asp:Panel ID="Panel1" runat="server" Visible="False">
                            </asp:Panel>--%>
                        </td>
                      
                    </tr>
                    <tr>
                        <td>
                            Account type
                       
                       
                            <asp:DropDownList ID="ddlAccType" runat="server">
                                <asp:ListItem>Saving</asp:ListItem>
                            </asp:DropDownList> </td>
                     
                    </tr>
                    <tr>
                        <td>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button
                                ID="btnSubmit" runat="server" Text="Submit" onclick="btnSubmit_Click"  ValidationGroup="validationsubmit"/>
                        </td>
                    </tr>
                </table>
            </asp:View>

            <asp:View ID="ViewAllDetails" runat="server">
 
    <div>
        <asp:GridView ID="grdViewDetails" runat="server" AutoGenerateColumns="False">
            <columns>
            <asp:BoundField DataField="RegistrationID" HeaderText="ID" ReadOnly="True" 
                SortExpression="ID" />
            <asp:BoundField DataField="CustomerName" HeaderText="Name" ReadOnly="True" 
                SortExpression="Name"></asp:BoundField>
            <asp:BoundField DataField="DateOfBirth" HeaderText="Date of Birth" 
                ReadOnly="True" SortExpression="Date of Birth"></asp:BoundField>
            <asp:BoundField DataField="Gender" HeaderText="Gender" ReadOnly="True" 
                SortExpression="Gender"></asp:BoundField>
            <asp:BoundField DataField="currentDate" 
                HeaderText="Account Opening Date" ReadOnly="True" 
                SortExpression="Account Opening Date"></asp:BoundField>
            <asp:BoundField DataField="CommunicationAddress" HeaderText="Address" ReadOnly="True" 
                SortExpression="Address"></asp:BoundField>
            <asp:BoundField DataField="AccountType" HeaderText="Account Type" 
                ReadOnly="True" SortExpression="Account Type"></asp:BoundField>
            <asp:BoundField DataField="Balance" HeaderText="Available Amount" 
                ReadOnly="True" SortExpression="Available Amount"></asp:BoundField>
        </columns>
        </asp:GridView>
        </div>
                
    </asp:View> 
    </asp:MultiView>
</asp:Content>
