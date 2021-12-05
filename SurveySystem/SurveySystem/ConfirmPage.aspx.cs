using SurveySystem.DBsource;
using SurveySystem.ORM.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SurveySystem
{
    public partial class ConfirmPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["ID"] == null)
            {
                Response.Redirect("/List.aspx");
            }

            string questionnaireidtxt = this.Request.QueryString["ID"];
            int questionnaireid = int.Parse(questionnaireidtxt);

            var questionnaire_View = ListManager.GetQuestionnaireID(questionnaireid);

            this.ltlStatus.Text = questionnaire_View.Status.ToString();
            this.ltlStartDate.Text = questionnaire_View.StartDate.ToString("yyyy-MM-dd");
            this.ltlEndDate.Text = questionnaire_View.EndDate.ToString();
            this.ltlCaption.Text = questionnaire_View.Caption;
            this.ltlQContent.Text = questionnaire_View.QContent;

            this.ltlGID.Text = this.Session["GID"].ToString();
            this.txbName.Text = this.Session["Name"].ToString();
            this.txbMobilePhone.Text = this.Session["MobilePhone"].ToString();
            this.txbEmail.Text = this.Session["Email"].ToString();
            this.txbAge.Text = this.Session["Age"].ToString();

            var reptQ = ListManager.GetQuestionnaireDetails(questionnaireid);

            foreach (var item in reptQ)
            {
                this.PlaceHolder1.Controls.Add(new LiteralControl(item.QDID + "."));
                this.PlaceHolder1.Controls.Add(new LiteralControl(item.Question + "<br />"));

                Literal ID = new Literal();
                ID.Text = item.QDID.ToString();

                if (item.QuestionType == "單選題")
                {
                    for (int i = 1; i <= reptQ.Count; i++)
                    {
                        if (this.Session[$"ResponseOfRadio{i}"] != null)
                        {
                            if (i == Convert.ToInt32(item.QDID))
                                this.PlaceHolder1.Controls.Add(new LiteralControl(this.Session[$"ResponseOfRadio{i}"] + "<br />"));
                        }
                        else
                            continue;
                    }

                    this.PlaceHolder1.Controls.Add(new LiteralControl("<br />"));
                }
                else if (item.QuestionType == "複選題")
                {
                    for (int i = 1; i <= reptQ.Count; i++)
                    {
                        if (this.Session[$"ResponseOfCheck{i}"] != null)
                        {
                            if (i == Convert.ToInt32(item.QDID))
                                this.PlaceHolder1.Controls.Add(new LiteralControl(this.Session[$"ResponseOfCheck{i}"] + "<br />"));
                        }
                        else
                            continue;
                    }

                    this.PlaceHolder1.Controls.Add(new LiteralControl("<br />"));
                }
                else if (item.QuestionType == "文字")
                {
                    for (int i = 1; i <= reptQ.Count; i++)
                    {
                        if (this.Session[$"ResponseOfTest{i}"] != null)
                        {
                            if (i == Convert.ToInt32(item.QDID))
                                this.PlaceHolder1.Controls.Add(new LiteralControl(this.Session[$"ResponseOfTest{i}"] + "<br />"));
                        }
                        else
                            continue;
                    }

                    this.PlaceHolder1.Controls.Add(new LiteralControl("<br />"));
                }

                this.ltlAmount.Text = $"共{reptQ.Count}個問題";
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string questionnaireidtxt = this.Request.QueryString["ID"];
            int questionnaireid = int.Parse(questionnaireidtxt);

            var reptQ = ListManager.GetQuestionnaireDetails(questionnaireid);

            var gid = this.ltlGID.Text;

            for (int i = 1; i <= reptQ.Count; i++)
            {
                if (this.Session[$"ResponseOfRadio{i}"] != null)
                {
                    var answer = this.Session[$"ResponseOfRadio{i}"].ToString();

                    SurveyDetails surveyDetails = new SurveyDetails();

                    surveyDetails.UserInfoID = Guid.Parse(gid);
                    surveyDetails.QuestionnaireID = questionnaireid;
                    surveyDetails.Answer = answer;

                    ListManager.AddSurveyDetails(surveyDetails);
                }
                else
                    continue;
            }

            for (int i = 1; i <= reptQ.Count; i++)
            {
                if (this.Session[$"ResponseOfCheck{i}"] != null)
                {
                    var answer = this.Session[$"ResponseOfCheck{i}"].ToString();

                    SurveyDetails surveyDetails = new SurveyDetails();

                    surveyDetails.UserInfoID = Guid.Parse(gid);
                    surveyDetails.QuestionnaireID = questionnaireid;
                    surveyDetails.Answer = answer;

                    ListManager.AddSurveyDetails(surveyDetails);
                }
                else
                    continue;
            }

            for (int i = 1; i <= reptQ.Count; i++)
            {
                if (this.Session[$"ResponseOfTest{i}"] != null)
                {
                    var answer = this.Session[$"ResponseOfTest{i}"].ToString();

                    SurveyDetails surveyDetails = new SurveyDetails();

                    surveyDetails.UserInfoID = Guid.Parse(gid);
                    surveyDetails.QuestionnaireID = questionnaireid;
                    surveyDetails.Answer = answer;

                    ListManager.AddSurveyDetails(surveyDetails);
                }
                else
                    continue;
            }

            Survey survey = new Survey();

            survey.UserInfoID = Guid.Parse(gid);
            survey.QuestionnaireID = questionnaireid;
            survey.Caption = this.ltlCaption.Text;
            survey.CreatDate = DateTime.Now;

            ListManager.AddSurvey(survey);

            Response.Redirect("/Stastic.aspx");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {

        }
    }
}