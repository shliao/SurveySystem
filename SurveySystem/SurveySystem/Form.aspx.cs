using SurveySystem.DBsource;
using System;
using System.Collections.Generic;
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

            var list = ListManager.GetQuestionnaireDetails(questionnaireid);
            var count = list.Count();
            Table1.Rows.Clear();

            for(int i = 0; i < count; i++)
            {
                for (int j = 0; j < count; j++)
                {
                    TableRow row = new TableRow();
                    TableCell cell = new TableCell();
                    row.Cells.Add(cell);
                    Table1.Rows.Add(row);

                    RadioButton btn2 = new RadioButton();
                    btn2.ID = "rbn" + i; //需要加入ID才不會第一次按鈕無反應
                    btn2.Text = "rbn" + i;

                    cell = new TableCell();
                    cell.Controls.Add(btn2);//在此欄加入按鈕
                    row.Cells.Add(cell);
                    Table1.Rows.Add(row);
                }
            }
        }
    }
}