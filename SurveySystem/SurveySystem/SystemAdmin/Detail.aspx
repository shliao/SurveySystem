<%@ Page Title="" Language="C#" MasterPageFile="~/SystemAdmin/Admin.Master" AutoEventWireup="true" CodeBehind="Detail.aspx.cs" Inherits="SurveySystem.SystemAdmin.Detail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="tabs">
        <ul>
            <li><a href="#tabs-1">問卷</a></li>
            <li><a href="#tabs-2">問題</a></li>
            <li><a href="#tabs-3">填寫資料</a></li>
            <li><a href="#tabs-4">統計</a></li>
        </ul>
        <div id="tabs-1">
            <asp:Literal ID="Literal1" runat="server">問卷名稱</asp:Literal>
            <asp:TextBox ID="txbCaption" runat="server"></asp:TextBox>
            <br />
            <asp:Literal ID="Literal2" runat="server">描述內容</asp:Literal>
            <asp:TextBox ID="txbContent" runat="server"></asp:TextBox>
            <br />
            <asp:Literal ID="Literal3" runat="server">開始時間</asp:Literal>
            <asp:TextBox ID="txbStartDate" runat="server" TextMode="Date"></asp:TextBox>
            <asp:Literal ID="Literal4" runat="server">結束時間</asp:Literal>
            <asp:TextBox ID="txbEndDate" runat="server" TextMode="Date"></asp:TextBox>
            <br />
            <asp:CheckBox ID="CheckBox1" runat="server" />
            <asp:Literal ID="Literal5" runat="server">啟用</asp:Literal>
            <br />
            <asp:Button ID="btnCancel" runat="server" Text="取消" OnClick="btnCancel_Click" />
            <asp:Button ID="btnSave" runat="server" Text="送出" OnClick="btnSave_Click" />
        </div>
        <div id="tabs-2">
            <asp:Literal ID="Literal6" runat="server">種類</asp:Literal>
            <asp:DropDownList ID="DropDownList1" runat="server"></asp:DropDownList>
            <br />
            <asp:Literal ID="Literal7" runat="server">問題</asp:Literal>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <asp:DropDownList ID="DropDownList2" runat="server"></asp:DropDownList>
            <asp:CheckBox ID="CheckBox2" runat="server" />
            <asp:Literal ID="Literal8" runat="server">必填</asp:Literal>
            <br />
            <asp:Literal ID="Literal9" runat="server">回答</asp:Literal>
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            <asp:Literal ID="Literal10" runat="server"></asp:Literal>
            <asp:Button ID="btnAdd" runat="server" Text="加入" OnClick="btnAdd_Click" />
            <br />
            <asp:GridView ID="GridView1" runat="server">
            </asp:GridView>
            <br />
            <asp:Button ID="btnCancel1" runat="server" Text="取消" />
            <asp:Button ID="btnSave2" runat="server" Text="送出" />
        </div>
        <div id="tabs-3">
            <asp:Literal ID="Literal11" runat="server">姓名</asp:Literal>
            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
            <asp:Literal ID="Literal12" runat="server">手機</asp:Literal>
            <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
            <br />
            <asp:Literal ID="Literal13" runat="server">Email</asp:Literal>
            <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
            <asp:Literal ID="Literal14" runat="server">年齡</asp:Literal>
            <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
            <br />
            <asp:Literal ID="Literal15" runat="server">填寫時間</asp:Literal>
        </div>
        <div id="tabs-4">
            
        </div>
    </div>
</asp:Content>
