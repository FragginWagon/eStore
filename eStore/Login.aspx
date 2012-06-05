<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" MasterPageFile="~/MasterPage.master" Title="Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceholder1" Runat="Server">

    <div style="text-align:center">
        <br />
        <asp:Label ID="Label1" runat="server" Text="Enter Your Username"></asp:Label>
        <br />
        <br />
        <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label2" runat="server" Text="Enter Your Password"></asp:Label>
        <br />
        <br />
        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="cmdProcess" runat="server" Text="Click!" 
            onclick="cmdProcess_Click" style="height: 26px" />
        <br />
        <br />
        <br />
        <asp:Label ID="lblStatus" runat="server"></asp:Label>
        </div>
</asp:Content>