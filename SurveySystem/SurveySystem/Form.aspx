<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Form.aspx.cs" Inherits="SurveySystem.Form" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Literal ID="ltlStatus" runat="server"></asp:Literal>
    <br />
    <asp:Literal ID="ltlStartDate" runat="server">~</asp:Literal>
    <asp:Literal ID="ltlEndDate" runat="server"></asp:Literal>
    <br />
    <asp:Literal ID="ltlCaption" runat="server"></asp:Literal>
    <br />
    <asp:Literal ID="ltlQContent" runat="server"></asp:Literal>
    <br />
    <asp:Literal ID="ltlName" runat="server">姓名</asp:Literal>
    <asp:TextBox ID="txbName" runat="server"></asp:TextBox>
    <br />
    <asp:Literal ID="ltlMobilePhone" runat="server">手機</asp:Literal>
    <asp:TextBox ID="txbMobilePhone" runat="server"></asp:TextBox>
    <br />
    <asp:Literal ID="ltlEmail" runat="server">Email</asp:Literal>
    <asp:TextBox ID="txbEmail" runat="server"></asp:TextBox>
    <br />
    <asp:Literal ID="ltlAge" runat="server">年齡</asp:Literal>
    <asp:TextBox ID="txbAge" runat="server"></asp:TextBox>
    <br />
    <asp:Table ID="Table1" runat="server"></asp:Table>
</asp:Content>
