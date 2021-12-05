<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ConfirmPage.aspx.cs" Inherits="SurveySystem.ConfirmPage" %>

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
    <asp:Literal ID="ltlGID" runat="server" Visible="false"></asp:Literal>
    <asp:Literal ID="ltlName" runat="server">姓名</asp:Literal>
    <asp:TextBox ID="txbName" runat="server" ReadOnly="true"></asp:TextBox>
    <br />
    <asp:Literal ID="ltlMobilePhone" runat="server">手機</asp:Literal>
    <asp:TextBox ID="txbMobilePhone" runat="server" ReadOnly="True"></asp:TextBox>
    <br />
    <asp:Literal ID="ltlEmail" runat="server">Email</asp:Literal>
    <asp:TextBox ID="txbEmail" runat="server" ReadOnly="True"></asp:TextBox>
    <br />
    <asp:Literal ID="ltlAge" runat="server">年齡</asp:Literal>
    <asp:TextBox ID="txbAge" runat="server" ReadOnly="True"></asp:TextBox>
    <br />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
    <br />
    <asp:Literal ID="ltlAmount" runat="server"></asp:Literal>
    <br />
    <asp:Button ID="btnCancel" runat="server" Text="取消" OnClick="btnCancel_Click" OnClientClick="history.back(-1);event.returnValue=false;" />
    <asp:Button ID="btnSave" runat="server" Text="送出" OnClick="btnSave_Click" />
    <br />
    <asp:Literal ID="Literal1" runat="server" Visible="false"></asp:Literal>
</asp:Content>
