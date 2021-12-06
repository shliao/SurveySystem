<%@ Page Title="" Language="C#" MasterPageFile="~/SystemAdmin/Admin.Master" AutoEventWireup="true" CodeBehind="FAQEadit.aspx.cs" Inherits="SurveySystem.SystemAdmin.FAQEadit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Literal ID="Literal1" runat="server">名稱：</asp:Literal>
    <asp:TextBox ID="txbCustomName" runat="server"></asp:TextBox>
    <br />
    <asp:Literal ID="Literal2" runat="server">類型：</asp:Literal>
    <asp:DropDownList ID="ddlFAQType" runat="server">
        <asp:ListItem>單選題</asp:ListItem>
        <asp:ListItem>複選題</asp:ListItem>
        <asp:ListItem>文字</asp:ListItem>
    </asp:DropDownList>
    <br />
    <asp:Literal ID="Literal3" runat="server">問題：</asp:Literal>
    <asp:TextBox ID="txbQuestion" runat="server"></asp:TextBox>
    <br />
    <asp:Literal ID="Literal4" runat="server">選項：</asp:Literal>
    <asp:TextBox ID="txbFOption" runat="server"></asp:TextBox>
    <br />
    <asp:Button ID="btnCancle" runat="server" Text="取消" OnClick="btnCancle_Click" />
    <asp:Button ID="btnSave" runat="server" Text="確定" OnClick="btnSave_Click" />
    <br />
    <asp:Literal ID="ltlMsg" runat="server"></asp:Literal>
</asp:Content>
