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
    <asp:Repeater ID="reptQuestionnaire" runat="server" OnItemDataBound="reptQuestionnaire_ItemDataBound">
        <ItemTemplate>
            <%# Container.ItemIndex + 1 + "." %>
            <asp:Literal ID="ltlQuestion" runat="server" Text='<%# Eval("Question") %>'></asp:Literal><br />
            <asp:Repeater ID="reptQOption1" runat="server">
                <ItemTemplate>
                    <input type="radio" name='rdobtn' value='<%# Container.DataItem %>' />
                    <lable><%# Container.DataItem %></lable>
                </ItemTemplate>
                <SeparatorTemplate>
                    <br />
                </SeparatorTemplate>
            </asp:Repeater>
            <asp:Repeater ID="reptQOption2" runat="server">
                <ItemTemplate>
                    <input type="checkbox" name='chkbox' value='<%# Container.DataItem %>' />
                    <lable><%# Container.DataItem %></lable>
                </ItemTemplate>
                <SeparatorTemplate>
                    <br />
                </SeparatorTemplate>
            </asp:Repeater>
            <asp:Repeater ID="reptQOption3" runat="server">
                <ItemTemplate>
                    <textarea name='txtbox' value='<%# Container.DataItem %>'></textarea>
                </ItemTemplate>
            </asp:Repeater>
        </ItemTemplate>
        <SeparatorTemplate>
            <hr />
        </SeparatorTemplate>
    </asp:Repeater>
    <br />
    <asp:Button ID="btnCancel" runat="server" Text="取消" OnClick="btnCancel_Click" />
    <asp:Button ID="btnSave" runat="server" Text="送出" OnClick="btnSave_Click" />
</asp:Content>
