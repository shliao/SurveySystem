using SurveySystem.DBsource;
using SurveySystem.ORM.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SurveySystem.SystemAdmin
{
    public partial class FAQEadit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string customname = this.Request.QueryString["ID"];
                var name = ListManager.GetFAQ(customname);

                this.txbCustomName.Text = name.CustomName.ToString();
                this.ddlFAQType.SelectedValue = name.FAQType.ToString();
                this.txbQuestion.Text = name.Question.ToString();
                this.txbFOption.Text = name.FOption.ToString();
            }
        }

        protected void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("/SystemAdmin/FAQList.aspx");
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            List<string> msgList = new List<string>();
            if (!this.CheckQuestInput(out msgList))
            {
                this.ltlMsg.Text = string.Join("<br/>", msgList);
                return;
            }

            string customname = this.Request.QueryString["ID"];

            FAQ faq = new FAQ();

            faq.CustomName = this.txbCustomName.Text;
            faq.FAQType = this.ddlFAQType.SelectedValue;
            faq.Question = this.txbQuestion.Text;
            faq.FOption = this.txbFOption.Text;

            ListManager.UpdateFAQ(customname, faq);

            Response.Redirect("/SystemAdmin/FAQList.aspx");
        }
        private bool CheckQuestInput(out List<string> errorMsgList)
        {
            List<string> msglist = new List<string>();
            Regex rx = new Regex(@"[\d\u4E00-\u9FA5A-Za-z-/u3002/uff1b/uff0c/uff1a/u201c/u201d/uff08/uff09/u3001/uff1f/u300a/u300b]");

            if (string.IsNullOrWhiteSpace(this.txbCustomName.Text) || string.IsNullOrEmpty(this.txbCustomName.Text))
                msglist.Add("<span style='color:red'>請輸入名稱</span>");

            else if (string.IsNullOrWhiteSpace(this.txbQuestion.Text) || string.IsNullOrEmpty(this.txbQuestion.Text))
                msglist.Add("<span style='color:red'>請輸入問題</span>");

            else if (string.IsNullOrWhiteSpace(this.txbFOption.Text) || string.IsNullOrEmpty(this.txbFOption.Text))
                msglist.Add("<span style='color:red'>請輸入選項</span>");

            else if (!rx.IsMatch(txbCustomName.Text))                                                  //正則表達式排除特殊字元
                msglist.Add("<span style='color:red'>問題不能為特殊字元,請重新輸入</span>");

            else if (!rx.IsMatch(txbQuestion.Text))
                msglist.Add("<span style='color:red'>選項不能為特殊字元,請重新輸入</span>");

            else if (!rx.IsMatch(txbFOption.Text))
                msglist.Add("<span style='color:red'>選項不能為特殊字元,請重新輸入</span>");

            errorMsgList = msglist;

            if (msglist.Count == 0)
                return true;
            else
                return false;
        }
    }
}