<%@ Page Title="" Language="C#" MasterPageFile="~/SystemAdmin/Admin.Master" AutoEventWireup="true" CodeBehind="FAQList.aspx.cs" Inherits="SurveySystem.SystemAdmin.FAQList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Button ID="btnDelete" runat="server" Text="刪除" OnClick="btnDelete_Click" />
    <asp:Button ID="btnCreat" runat="server" Text="新增" OnClick="btnCreat_Click" />
    <br />
    <asp:GridView ID="grvFAQ" runat="server" AutoGenerateColumns="false">
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:CheckBox runat="server" ID="cbxDelete"></asp:CheckBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="CustomName" HeaderText="名稱" />
            <asp:BoundField DataField="FAQType" HeaderText="類型" />
            <asp:BoundField DataField="Question" HeaderText="問題" />
            <asp:BoundField DataField="FOption" HeaderText="選項" />
            <asp:TemplateField>
                <ItemTemplate>
                    <a href="/SystemAdmin/FAQEadit.aspx?ID=<%# Eval("CustomName") %>">編輯</a>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
