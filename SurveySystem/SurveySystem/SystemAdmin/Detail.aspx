<%@ Page Title="" Language="C#" MasterPageFile="~/SystemAdmin/Admin.Master" AutoEventWireup="true" CodeBehind="Detail.aspx.cs" Inherits="SurveySystem.SystemAdmin.Detail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="tabs">
        <ul>
            <li><a href="#tabs-1" id="tab-label-1">問卷</a></li>
            <li><a href="#tabs-2" id="tab-label-2">問題</a></li>
            <li><a href="#tabs-3" id="tab-label-3">填寫資料</a></li>
            <li><a href="#tabs-4" id="tab-label-4">統計</a></li>
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
            <br />
            <asp:Literal ID="Literal4" runat="server">結束時間</asp:Literal>
            <asp:TextBox ID="txbEndDate" runat="server" TextMode="Date"></asp:TextBox>
            <br />
            <asp:CheckBox ID="CheckBox1" runat="server" Text="已啟用" />
            <br />
            <asp:Literal ID="ltlMsg" runat="server"></asp:Literal>
            <br />
            <asp:Button ID="btnCancel" runat="server" Text="取消" OnClick="btnCancel_Click" />
            <asp:Button ID="btnSave" runat="server" Text="送出" OnClick="btnSave_Click" />
        </div>
        <div id="tabs-2">
            <asp:Literal ID="Literal6" runat="server">種類</asp:Literal>
            <asp:DropDownList ID="ddlFAQ" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlFAQ_SelectedIndexChanged"></asp:DropDownList>
            <br />
            <asp:Literal ID="Literal11" runat="server">#</asp:Literal>
            <asp:Literal ID="ltlGvbID" runat="server">0</asp:Literal>
            <br />
            <asp:Literal ID="Literal7" runat="server">問題</asp:Literal>
            <asp:TextBox ID="txbQuestionnaire" runat="server"></asp:TextBox>
            <asp:DropDownList ID="ddlType" runat="server">
                <asp:ListItem>單選題</asp:ListItem>
                <asp:ListItem>複選題</asp:ListItem>
                <asp:ListItem>文字</asp:ListItem>
            </asp:DropDownList>
            <asp:CheckBox ID="CheckBox2" runat="server" />
            <asp:Literal ID="Literal8" runat="server">必填</asp:Literal>
            <br />
            <asp:Literal ID="Literal9" runat="server">回答</asp:Literal>
            <asp:TextBox ID="txbQOption" runat="server"></asp:TextBox>
            <asp:Literal ID="Literal10" runat="server"></asp:Literal>
            <asp:Button ID="btnAdd" runat="server" Text="加入" OnClick="btnAdd_Click" />
            <br />
            <asp:Literal ID="ltlMsg2" runat="server"></asp:Literal>
            <br />
            <asp:Button ID="btnDel" runat="server" Text="刪除" OnClick="btnDel_Click" />
            <br />
            <asp:GridView ID="gvQuestionnaireDetails" runat="server" AutoGenerateColumns="false">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:CheckBox runat="server" ID="cbxDelete"></asp:CheckBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="QDID" HeaderText="#" />
                    <asp:BoundField DataField="Question" HeaderText="問題" />
                    <asp:BoundField DataField="QuestionType" HeaderText="種類" />
                    <asp:TemplateField HeaderText="必填">
                        <ItemTemplate>
                            <asp:CheckBox ID="ckbRequired" runat="server" Checked='<%# Eval("Required").ToString() == "0" ? true : false %>' Enabled="false" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button ID="btnQuestionnaire" runat="server" Text="編輯" OnClick="btnQuestionnaire_Click" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <br />
            <asp:Button ID="btnCancel1" runat="server" Text="取消" OnClick="btnCancel1_Click" />
            <asp:Button ID="btnSave2" runat="server" Text="送出" OnClick="btnSave2_Click" />
        </div>
        <div id="tabs-3">
            <asp:Button ID="btnOutput" runat="server" Text="匯出" OnClick="btnOutput_Click" />
            <br />
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField="Name" HeaderText="姓名" />
                    <%--<asp:BoundField DataField="CreatDate" HeaderText="填寫時間" DataFormatString="{0;yyyy/MM/dd}"/>--%>
                    <asp:TemplateField HeaderText="觀看細節">
                        <ItemTemplate>
                            <a href="Detail.aspx?ID=<%# Eval("UserInfoID") %>">前往</a>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        <div id="tabs-4">
            <img src="../Photo/Working.jpg" />
        </div>
    </div>
    <script type="text/javascript">
        /////////////手動觸發selectd的change事件////////////////
        $("#ddlFAQ").change(function () {
            var aaa = $("#ddlFAQ  option:selected").text();
            alert(aaa);
        });
        $("#ddlFAQ").trigger("change");
   /////////////手動觸發selectd的change事件////////////////
    </script>
</asp:Content>
