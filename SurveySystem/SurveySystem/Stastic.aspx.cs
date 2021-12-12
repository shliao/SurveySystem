using Microsoft.Build.Tasks.Deployment.Bootstrapper;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SurveySystem.DBsource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace SurveySystem
{
    public partial class Stastic : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["ID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }

            string questionnaireidtxt = this.Request.QueryString["ID"];
            int questionnaireid = int.Parse(questionnaireidtxt);

            var reptQ = ListManager.GetQuestionnaireDetails(questionnaireid);

            this.Repeater1.DataSource = reptQ;
            this.Repeater1.DataBind();

        }

        public string OptionData()
        {
            if (Request.QueryString["ID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }

            string questionnaireidtxt = this.Request.QueryString["ID"];
            int questionnaireid = int.Parse(questionnaireidtxt);

            var reptQ = ListManager.GetQuestionnaireDetails(questionnaireid);
            var anser = ListManager.GetSurveyDetails(questionnaireid);

            var productArray = new List<String>();

            foreach (var item in reptQ)
            {
                if (item.QuestionType == "單選題")
                {
                    foreach (string o in item.QOption.Split(';'))
                    {
                        Option product = new Option();
                        product.name = o;
                        product.y = (100 / anser.Count);
                        productArray.Add(JsonConvert.SerializeObject(product));
                    }
                }
                else if (item.QuestionType == "複選題")
                {
                    foreach (string o in item.QOption.Split(';'))
                    {
                        Option product = new Option();
                        product.name = o;
                        product.y = (100 / anser.Count);
                        productArray.Add(JsonConvert.SerializeObject(product));
                    }
                }
                else if (item.QuestionType == "文字")
                {
                    Option product = new Option();
                    product.name = "-";
                    product.y = 100;
                    productArray.Add(JsonConvert.SerializeObject(product));
                }
            }

            string result = "";
            for (int i = 0; i < productArray.Count; i++)
            {
                result += productArray[i];
                if (i < productArray.Count - 1)
                {
                    result += ",";
                }
            }

            return result;
        }

        public class Option
        {
            public string name { get; set; }
            public int y { get; set; }
        };
    }
}