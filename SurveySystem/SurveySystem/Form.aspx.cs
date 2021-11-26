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

        public object RadioButton1 { get; private set; }

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

            this.reptQuestionnaire.DataSource = reptQ;
            this.reptQuestionnaire.DataBind();

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

            Session["Name"] = this.txbName.Text;
            Session["MobilePhone"] = this.txbMobilePhone.Text;
            Session["Email"] = this.txbEmail.Text;
            Session["Age"] = this.txbAge.Text;

            string questionnaireidtxt = this.Request.QueryString["ID"];
            int questionnaireid = int.Parse(questionnaireidtxt);
            var reptQ = ListManager.GetQuestionnaireDetails(questionnaireid);

            if (Request.Form["radioQDID"] != null)
            {
                //string aaa = Request.Form[].ToString();
                //System.Diagnostics.Debug.WriteLine(aaa);

            }


            //System.Diagnostics.Debug.WriteLine(); Console 輸出，檢查值
            foreach (var item in reptQ)
            {
                System.Diagnostics.Debug.WriteLine(item.Question);
                if (item.QuestionType == "單選題")
                {
                    //System.Diagnostics.Debug.WriteLine(item.QOption);
                    foreach (string o in item.QOption.Split(';'))
                    {

                        var encode = String.Format("{0}-{1}", item.Question, o);
                        //System.Diagnostics.Debug.WriteLine(item.Question + "-"+o);
                        System.Diagnostics.Debug.WriteLine(encode);
                        //var formInput = Request.Form[encode];
                        //if (formInput != null) {
                        //    //Session[encode] = formInput;

                        //}
                    }
                }
                else if (item.QuestionType == "複選題")
                {
                    foreach (string o in item.QOption.Split(';'))
                    {
                        var encode = String.Format("{0}-{1}", item.Question, o);
                        System.Diagnostics.Debug.WriteLine(encode);
                    }
                }
                else if (item.QuestionType == "文字")
                {
                    foreach (var o in item.QOption)
                    {
                        var encode = String.Format("{0}-{1}", item.Question, o);
                        System.Diagnostics.Debug.WriteLine(encode);
                    }
                }

            }

            Response.Redirect("ConfirmPage.aspx");
        }

        public string getRadio(string Qid)
        {
            string Qcid = "radio" + Qid;
            return Qcid;
        }
        public string getCheck(string Qid)
        {
            string Qcid = "ckcbox" + Qid;
            return Qcid;
        }
        public string getText(string Qid)
        {
            string Qcid = "txtbox" + Qid;
            return Qcid;
        }


        protected void reptQuestionnaire_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                QuestionnaireDetails MyRow = (QuestionnaireDetails)e.Item.DataItem;

                Repeater reptQOption1 = e.Item.FindControl("reptQOption1") as Repeater;
                if (reptQOption1 != null && MyRow.QuestionType == "單選題")
                {
                    reptQOption1.DataSource = MyRow.QOption.Split(';');
                    reptQOption1.DataBind();
                }
                Repeater reptQOption2 = e.Item.FindControl("reptQOption2") as Repeater;
                if (reptQOption2 != null && MyRow.QuestionType == "複選題")
                {
                    reptQOption2.DataSource = MyRow.QOption.Split(';');
                    reptQOption2.DataBind();
                }
                Repeater reptQOption3 = e.Item.FindControl("reptQOption3") as Repeater;
                if (reptQOption3 != null && MyRow.QuestionType == "文字")
                {
                    if (MyRow.QuestionType == "文字" && MyRow.QOption == "")
                    {
                        reptQOption3.DataSource = new List<string> { "請輸入內容" };
                        reptQOption3.DataBind();
                    }
                }
            }
        }
    }
}