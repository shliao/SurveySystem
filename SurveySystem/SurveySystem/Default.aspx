<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SurveySystem.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="Panel1" runat="server" BorderWidth="1">
        <asp:Literal ID="Literal1" runat="server">問卷標題</asp:Literal>
        <asp:TextBox ID="txtIpt" runat="server"></asp:TextBox><br />
        <asp:Literal ID="Literal2" runat="server">開始 / 結束</asp:Literal>
        <asp:TextBox ID="txbStr" runat="server" TextMode="Date"></asp:TextBox>
        <asp:TextBox ID="txbEnd" runat="server" TextMode="Date"></asp:TextBox>
        <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" Text="搜尋" />
        <asp:Literal ID="ltlMsg" runat="server"></asp:Literal>
    </asp:Panel>
    <br />
    <asp:GridView ID="gv_list" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="QuestionnaireID" HeaderText="#" />
            <asp:HyperLinkField
                DataNavigateUrlFields="QuestionnaireID"
                DataNavigateUrlFormatString="Form.aspx?ID={0}"
                DataTextField="Caption"
                HeaderText="問卷"
                SortExpression="Caption" />
            <asp:BoundField DataField="Status" HeaderText="狀態" />
            <asp:BoundField DataField="StartDate" HeaderText="開始時間" DataFormatString="{0:yyyy/MM/dd}" />
            <asp:BoundField DataField="EndDate" HeaderText="結束時間" DataFormatString="{0:yyyy/MM/dd}" />
            <asp:TemplateField HeaderText="觀看統計">
                <ItemTemplate>
                    <a href="Stastic.aspx?ID=<%# Eval("QuestionnaireID")%>">
                    <p>前往</p>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
