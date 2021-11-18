﻿using SurveySystem.DBsource;
using System;
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

        public string Split(string str)
        {

            string[] param = str.Split(';');

            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            for (int i = 0; i < param.Length; i++)
            {
                sb.Append(string.Format(param[i]));

                if (i != param.Length - 1)
                {
                    sb.Append("<br>");
                }
            }

            //if (QuestionType == "單選題")
            //{
            //    for (int i = 0; i < param.Length; i++)
            //    {
            //        sb.Append(string.Format("<input type='radio' name='QOption{1}' value={0}>{0}", param[i], QDID,i));

            //        if (i != param.Length - 1)
            //        {
            //            sb.Append("<br>");
            //        }
            //    }
            //}
            //else if (QuestionType == "複選題")
            //{
            //    for (int i = 0; i < param.Length; i++)
            //    {
            //        sb.Append(string.Format("<input type='radio' name='QOption{1}' value={0}>{0}", param[i], i));

            //        if (i != param.Length - 1)
            //        {
            //            sb.Append("<br>");
            //        }
            //    }
            //}
            //else if(QuestionType == "文字")
            //{
            //    for (int i = 0; i < param.Length; i++)
            //    {
            //        sb.Append(string.Format("<input type='text' name='Text' size='50' value={0}>{0}", param[i]));
            //    }
            //}

            return sb.ToString();
        }

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
            Control aaa = FindControl("aaa10");
            if (aaa != null)
            {


            }
            //= this.Request.QueryString["QOption0"];
            var ddd = Request.Form["fff"];
            Response.Redirect("ConfirmPage.aspx");
        }

        protected void reptQuestionnaire_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Repeater reptQOption = (Repeater)e.Item.FindControl("reptQOption");

               // DataRowView MyRow = (DataRowView)e.Item.DataItem;
              //  MyRow["ltlQDID"].ToString();


                //var sss = e.Item.FindControl("ltlQDID");
                //var eee = Convert.ToInt32(sss);

                //var rrr = ListManager.GetQuestDetailsID(eee);

                //if(rrr.QuestionType == "複選題")
                //{
                //    RadioButton radioButton = new RadioButton();
                //    radioButton.Text = rrr.QOption;
                //    radioButton.ID = "radio";

                //    reptQOption.DataSource = radioButton;
                //    reptQOption.DataBind();

                //}

            }
        }
    }
}