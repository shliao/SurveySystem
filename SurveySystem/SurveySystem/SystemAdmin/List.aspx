<%@ Page Title="" Language="C#" MasterPageFile="~/SystemAdmin/Admin.Master" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="SurveySystem.SystemAdmin.List" %>

<%@ Register Src="~/UserControls/ucPager.ascx" TagPrefix="uc1" TagName="ucPager" %>


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
    <asp:Button ID="btnDelete" runat="server" Text="刪除問卷" OnClick="btnDelete_Click" />
    <asp:Button ID="btnAdd" runat="server" Text="新增問卷" OnClick="btnAdd_Click" />
    <asp:GridView ID="gv_list" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:CheckBox runat="server" ID="cbxDeleteList"></asp:CheckBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="QuestionnaireID" HeaderText="#" />
            <asp:HyperLinkField
                DataNavigateUrlFields="QuestionnaireID"
                DataNavigateUrlFormatString="Detail.aspx?ID={0}"
                DataTextField="Caption"
                HeaderText="問卷"
                SortExpression="Caption" />
            <asp:TemplateField HeaderText="狀態">
                <ItemTemplate>
                    <%# ((string)Eval("Status") == "啟用") ? "啟用" : "關閉"%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="StartDate" HeaderText="開始時間" DataFormatString="{0:d}" />
            <asp:BoundField DataField="EndDate" HeaderText="結束時間" DataFormatString="{0:d}" />
            <asp:TemplateField HeaderText="觀看統計">
                <ItemTemplate>
                    <a href="../Stastic.aspx?ID=<%# Eval("QuestionnaireID")%>">
                        <p>前往</p>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <uc1:ucPager runat="server" ID="ucPager" PageSize="10" CurrentPage="1" TotalSize="10" Url="Default.aspx" />
</asp:Content>
