<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SurveySystem.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <asp:Label ID="Label3" runat="server" Text="登入"></asp:Label>
        <br />
        <asp:Label ID="Label1" runat="server" Text="帳號："></asp:Label>
        <asp:TextBox ID="txtAccount" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label2" runat="server" Text="密碼："></asp:Label>
        <asp:TextBox ID="txtPWD" runat="server" TextMode="Password"></asp:TextBox>
        <br />
        <asp:Literal ID="ltlMsg" runat="server"></asp:Literal>
        <br />
        <asp:Button ID="btnLogin" runat="server" Text="登入" OnClick="btnLogin_Click" />
        <asp:Button ID="btnCancel" runat="server" Text="取消" OnClick="btnCancel_Click" />
    </div>
</asp:Content>
