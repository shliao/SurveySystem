using SurveySystem.DBsource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SurveySystem.SystemAdmin
{
    public partial class SurveyDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["ID"] == null)
            {
                Response.Redirect("SystemAdmin/Detail.aspx");
            }

            string userinfoidtxt = this.Request.QueryString["ID"];
            Guid userinfoid = Guid.Parse(userinfoidtxt);

            var survey = ListManager.GetSurveyID(userinfoid);

            this.txtName.Text = survey.Name;
            this.txtMobile.Text = survey.MobilePhone;
            this.txtEmail.Text = survey.Email;
            this.txtAge.Text = survey.Age;
            this.ltlCreatDate.Text = survey.CreatDate.ToString("yyyy-MM-dd");

            var QuestID = survey.QuestionnaireID;

            var reptQ = ListManager.GetSurvey(QuestID, userinfoid);

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
                        if (item.Answer != null)
                        {
                            if (i == Convert.ToInt32(item.QDID))
                                this.PlaceHolder1.Controls.Add(new LiteralControl(item.Answer + "<br />"));
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
                        if (item.Answer != null)
                        {
                            if (i == Convert.ToInt32(item.QDID))
                                this.PlaceHolder1.Controls.Add(new LiteralControl(item.Answer + "<br />"));
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
                        if (item.Answer != null)
                        {
                            if (i == Convert.ToInt32(item.QDID))
                                this.PlaceHolder1.Controls.Add(new LiteralControl(item.Answer + "<br />"));
                        }
                        else
                            continue;
                    }

                    this.PlaceHolder1.Controls.Add(new LiteralControl("<br />"));
                }

                this.ltlAmount.Text = $"共{reptQ.Count}個問題";
            }
        }
    }
}