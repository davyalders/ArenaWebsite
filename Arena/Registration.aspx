<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="Arena.Registration" MasterPageFile="MasterPage.Master" %>


 <asp:Content ID="content1" ContentPlaceHolderId="ContentPlaceHolder1" runat="server">
     <link href="Main.css" rel="stylesheet" type="text/css" />
     <div id="reg1">
    
        <table class="auto-style1">
            <tr>
                <td class="auto-style5">Username:</td>
                <td class="auto-style6">
                    <asp:TextBox ID="tbUsername" runat="server" CssClass="auto-style8" Width="240px"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RFVUsername" runat="server" ControlToValidate="tbUsername" ErrorMessage="Enter a valid username " ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style5">E-mail:</td>
                <td class="auto-style6">
                    <asp:TextBox ID="tbEmail" runat="server" TextMode="Email" Width="240px"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RFVEmail" runat="server" ControlToValidate="tbEmail" ErrorMessage="Enter a valid E-mail" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style5">Password:</td>
                <td class="auto-style6">
                    <asp:TextBox ID="tbPassword" runat="server" TextMode="Password" Width="240px"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RFVPassword" runat="server" ControlToValidate="tbPassword" ErrorMessage="Enter a valid password" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style5">Confirm Password:</td>
                <td class="auto-style6">
                    <asp:TextBox ID="tbConfirm" runat="server" TextMode="Password" Width="240px"></asp:TextBox>
                </td>
                <td>
                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="tbPassword" ControlToValidate="tbConfirm" ErrorMessage="Passwords do not match" ForeColor="Red"></asp:CompareValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style5">&nbsp;</td>
                <td class="auto-style6">
                    <asp:Button ID="btSubmit" runat="server" OnClick="btSubmit_Click" Text="Submit" />
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style6">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style6">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
    
    </div>
          

       </asp:Content>
