using SurveySystem.DBsource;
using SurveySystem.ORM.DBModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SurveySystem
{
    public partial class Form : System.Web.UI.Page
    {
        public ListManager questionnaire_View;
        public ListManager questionnaireDetails_View;

        //System.Diagnostics.Debug.WriteLine(); Console 輸出，檢查值。

        protected void Page_Load(object sender, EventArgs e)
        {
            string questionnaireidtxt = this.Request.QueryString["ID"];
            int questionnaireid = int.Parse(questionnaireidtxt);

            var questionnaire_View = ListManager.GetQuestionnaireID(questionnaireid);

            if (!IsPostBack)
            {
                this.ltlStatus.Text = questionnaire_View.Status.ToString();
                this.ltlStartDate.Text = questionnaire_View.StartDate.ToString("yyyy-MM-dd");
                this.ltlEndDate.Text = questionnaire_View.EndDate.ToString();
                this.ltlCaption.Text = questionnaire_View.Caption;
                this.ltlQContent.Text = questionnaire_View.QContent;
            }

            var reptQ = ListManager.GetQuestionnaireDetails(questionnaireid);

            if (reptQ.Count == 0)
            {
                Response.Write("<script>alert('問卷製作中,請稍後在試')</script>");
                Server.Transfer("/List.aspx");
                return;
            }

            foreach (var item in reptQ)
            {
                this.PlaceHolder1.Controls.Add(new LiteralControl(item.QDID + "."));
                Session["QDID"] = item.QDID;

                Literal ltquestionName = new Literal();
                ltquestionName.ID = "questionName" + item.QDID;
                ltquestionName.Text = item.Question.ToString();
                this.PlaceHolder1.Controls.Add(ltquestionName);
                this.PlaceHolder1.Controls.Add(new LiteralControl("<br />"));

                Literal ID = new Literal();
                ID.Text = item.QDID.ToString();

                if (item.QuestionType == "單選題")
                {
                    RadioButtonList radioList = new RadioButtonList();
                    radioList.ID = "radioList" + item.QDID;
                    this.PlaceHolder1.Controls.Add(radioList);

                    radioList.DataSource = item.QOption.Split(';');
                    radioList.DataBind();

                    this.PlaceHolder1.Controls.Add(new LiteralControl("<br />"));
                }
                else if (item.QuestionType == "複選題")
                {
                    CheckBoxList checkList = new CheckBoxList();
                    checkList.ID = "checkList" + item.QDID;
                    this.PlaceHolder1.Controls.Add(checkList);

                    checkList.DataSource = item.QOption.Split(';');
                    checkList.DataBind();

                    this.PlaceHolder1.Controls.Add(new LiteralControl("<br />"));
                }
                else if (item.QuestionType == "文字")
                {
                    TextBox txtBox = new TextBox();
                    txtBox.ID = "txtBox" + item.QDID;
                    this.PlaceHolder1.Controls.Add(txtBox);
                    this.PlaceHolder1.Controls.Add(new LiteralControl("<br />"));
                }

                this.ltlAmount.Text = $"共{reptQ.Count}個問題";
            }
        }

        //分裂字串用，已用不到
        //public string Split(string str)
        //{

        //    string[] param = str.Split(';');

        //    System.Text.StringBuilder sb = new System.Text.StringBuilder();

        //    for (int i = 0; i < param.Length; i++)
        //    {
        //        sb.Append(string.Format(param[i]));

        //        if (i != param.Length - 1)
        //        {
        //            sb.Append("<br>");
        //        }
        //    }
        //    return sb.ToString();
        //}

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txbName.Text) || string.IsNullOrEmpty(this.txbMobilePhone.Text) || string.IsNullOrEmpty(this.txbEmail.Text) || string.IsNullOrEmpty(this.txbAge.Text))
            {
                this.ltlMsg.Text = "請輸入個人基本資料";
                return;
            }
            else
                this.ltlMsg.Text = "";

            if (Convert.ToInt32(this.txbAge.Text) <= 0)
            {
                this.ltlMsg.Text = "請輸入正確年齡";
                return;
            }
            else
                this.ltlMsg.Text = "";

            Guid gid = Guid.NewGuid();

            UserInfo userinfo = new UserInfo();

            userinfo.UserInfoID = gid;
            userinfo.Name = this.txbName.Text;
            userinfo.MobilePhone = this.txbMobilePhone.Text;
            userinfo.Email = this.txbEmail.Text;
            userinfo.Age = this.txbAge.Text;

            ListManager.CreatUserInfo(userinfo);

            Session["GID"] = gid;
            Session["Name"] = this.txbName.Text;
            Session["MobilePhone"] = this.txbMobilePhone.Text;
            Session["Email"] = this.txbEmail.Text;
            Session["Age"] = this.txbAge.Text;

            string questionnaireidtxt = this.Request.QueryString["ID"];
            int questionnaireid = int.Parse(questionnaireidtxt);
            var reptQ = ListManager.GetQuestionnaireDetails(questionnaireid);

            for (int i = 1; i <= reptQ.Count; i++)
            {
                var getRadioValue = (RadioButtonList)this.PlaceHolder1.FindControl($"radioList{i}");

                if (getRadioValue != null)
                {
                    this.Literal2.Text = getRadioValue.SelectedValue;
                    this.Session[$"ResponseOfRadio{i}"] = this.Literal2.Text;

                    var getQuestionName = (Literal)this.PlaceHolder1.FindControl($"questionName{i}");
                    if (getQuestionName.Text.Contains("(必填)"))
                    {
                        if (string.IsNullOrEmpty(this.Literal2.Text))
                        {
                            this.ltlMsg2.Text = "請選擇'必填'欄位";
                            return;
                        }
                        else
                            this.ltlMsg2.Text = "";
                    }
                }
                else
                    continue;
            }

            for (int i = 1; i <= reptQ.Count; i++)
            {
                var getCheckValue = (CheckBoxList)this.PlaceHolder1.FindControl($"checkList{i}");

                if (getCheckValue != null)
                {
                    List<String> CheckedList = new List<string>();

                    foreach (ListItem item in getCheckValue.Items)
                    {
                        if (item.Selected)
                        {
                            CheckedList.Add(item.Value);
                        }
                    }

                    string Checked = string.Join(",", CheckedList.ToArray());

                    this.Session[$"ResponseOfCheck{i}"] = Checked;

                    var getQuestionName = (Literal)this.PlaceHolder1.FindControl($"questionName{i}");
                    if (getQuestionName.Text.Contains("(必填)"))
                    {
                        if (string.IsNullOrEmpty(Checked))
                        {
                            this.ltlMsg2.Text = "請選擇'必填'欄位";
                            return;
                        }
                        else
                            this.ltlMsg2.Text = "";
                    }
                }
                else
                    continue;
            }

            for (int i = 1; i <= reptQ.Count; i++)
            {
                var getTextValue = (TextBox)this.PlaceHolder1.FindControl($"txtBox{i}");

                if (getTextValue != null)
                {
                    this.Literal1.Text = getTextValue.Text;
                    this.Session[$"ResponseOfTest{i}"] = this.Literal1.Text;

                    var getQuestionName = (Literal)this.PlaceHolder1.FindControl($"questionName{i}");
                    if (getQuestionName.Text.Contains("(必填)"))
                    {
                        if (string.IsNullOrEmpty(getTextValue.Text))
                        {
                            this.ltlMsg1.Text = "請回答'必填'欄位";
                            return;
                        }
                        else
                            this.ltlMsg1.Text = "";
                    }
                }
                else
                    continue;
            }

            Response.Redirect($"/ConfirmPage.aspx?ID={questionnaireid}");

            //嘗試 Repeater 的作法未完善，評估後續需要花的時間太多了，先暫停此方法。
            //foreach (var item in reptQ)
            //{

            //    Session["QDID"] = Request.Form[item.QDID];
            //    //System.Diagnostics.Debug.WriteLine(item.Question);
            //    if (item.QuestionType == "單選題")
            //    {
            //        //System.Diagnostics.Debug.WriteLine(item.QOption);
            //        foreach (string o in item.QOption.Split(';'))
            //        {                       

            //            //var encode = String.Format("{0}-{1}", item.Question, o);
            //            //System.Diagnostics.Debug.WriteLine(item.Question + "-"+o);

            //            //System.Diagnostics.Debug.WriteLine(encode);
            //            //var formInput = Request.Form[encode];
            //            //if (formInput != null) {
            //            //    Session["Ans"] = formInput.ToString();
            //            //}
            //        }
            //    }
            //    else if (item.QuestionType == "複選題")
            //    {
            //        foreach (string o in item.QOption.Split(';'))
            //        {
            //            var encode = String.Format("{0}-{1}", item.Question, o);
            //            System.Diagnostics.Debug.WriteLine(encode);
            //        }
            //    }
            //    else if (item.QuestionType == "文字")
            //    {
            //        foreach (var o in item.QOption)
            //        {
            //            var encode = String.Format("{0}-{1}", item.Question, o);
            //            System.Diagnostics.Debug.WriteLine(encode);
            //        }
            //    }
            //}
        }

        //嘗試 Repeater 的作法未完善，評估後續需要花的時間太多了，先暫停此方法。
        //public string getRadio(string Qid)
        //{
        //    string Qcid = "radio" + Qid;
        //    return Qcid;
        //}
        //public string getCheck(string Qid)
        //{
        //    string Qcid = "ckcbox" + Qid;
        //    return Qcid;
        //}
        //public string getText(string Qid)
        //{
        //    string Qcid = "txtbox" + Qid;
        //    return Qcid;
        //}

        //嘗試 Repeater 的作法未完善，評估後續需要花的時間太多了，先暫停此方法。
        //protected void reptQuestionnaire_ItemDataBound(object sender, RepeaterItemEventArgs e)
        //{
        //    if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        //    {
        //        QuestionnaireDetails MyRow = (QuestionnaireDetails)e.Item.DataItem;

        //        Repeater reptQOption1 = e.Item.FindControl("reptQOption1") as Repeater;
        //        if (reptQOption1 != null && MyRow.QuestionType == "單選題")
        //        {
        //            reptQOption1.DataSource = MyRow.QOption.Split(';');
        //            reptQOption1.DataBind();
        //        }
        //        Repeater reptQOption2 = e.Item.FindControl("reptQOption2") as Repeater;
        //        if (reptQOption2 != null && MyRow.QuestionType == "複選題")
        //        {
        //            reptQOption2.DataSource = MyRow.QOption.Split(';');
        //            reptQOption2.DataBind();
        //        }
        //        Repeater reptQOption3 = e.Item.FindControl("reptQOption3") as Repeater;
        //        if (reptQOption3 != null && MyRow.QuestionType == "文字")
        //        {
        //            if (MyRow.QuestionType == "文字" && MyRow.QOption == "")
        //            {
        //                reptQOption3.DataSource = new List<string> { "請輸入內容" };
        //                reptQOption3.DataBind();
        //            }
        //        }
        //    }
        //}
    }
}