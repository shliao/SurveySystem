<%@ Page Title="" Language="C#" MasterPageFile="~/SystemAdmin/Admin.Master" AutoEventWireup="true" CodeBehind="SurveyDetail.aspx.cs" Inherits="SurveySystem.SystemAdmin.SurveyDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="tabs">
        <ul>
            <li><a href="#tabs-1" id="tab-label-1">填寫資料</a></li>
        </ul>
        <div id="tabs-1">
            <asp:Literal ID="Literal1" runat="server">姓名：</asp:Literal>
            <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
            <asp:Literal ID="Literal2" runat="server">手機：</asp:Literal>
            <asp:TextBox ID="txtMobile" runat="server"></asp:TextBox>
            <br />
            <asp:Literal ID="Literal3" runat="server">Email：</asp:Literal>
            <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
            <asp:Literal ID="Literal4" runat="server">年齡：</asp:Literal>
            <asp:TextBox ID="txtAge" runat="server"></asp:TextBox>
            <img src="../Photo/Working.jpg" />
            <br />
            <asp:Literal ID="ltlCreatDate" runat="server">填寫時間：</asp:Literal>
            <br />

        </div>
    </div>
</asp:Content>
