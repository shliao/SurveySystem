using SurveySystem.DBsource;
using SurveySystem.ORM.DBModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SurveySystem.SystemAdmin
{
    public partial class Detail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var faqlist = ListManager.GetFAQSeleteItem();

                this.ddlFAQ.DataSource = faqlist;
                this.ddlFAQ.DataTextField = "CustomName";
                this.ddlFAQ.DataValueField = "CustomName";
                this.ddlFAQ.DataBind();
                this.ddlFAQ.Items.Insert(0, "<-- 自訂問題 -->");

                if (this.Request.QueryString["ID"] == null)
                {
                    //新增問卷
                }
                else
                {
                    //編輯問卷

                    //tabs-1
                    string questionnaireidtxt = this.Request.QueryString["ID"];
                    int questionnaireid = int.Parse(questionnaireidtxt);

                    var questionnaire_View = ListManager.GetQuestionnaireID(questionnaireid);

                    this.txbCaption.Text = questionnaire_View.Caption;
                    this.txbContent.Text = questionnaire_View.QContent;
                    this.txbStartDate.Text = questionnaire_View.StartDate.ToString("yyyy-MM-dd");
                    this.txbEndDate.Text = questionnaire_View.EndDate?.ToString("yyyy-MM-dd");
                    if (questionnaire_View.Status == "啟用")
                    {
                        this.CheckBox1.Checked = true;
                    }
                    else
                    {
                        this.CheckBox1.Checked = false;
                    }

                    //tabs-2

                    this.gvQuestionnaireDetails.DataSource = ListManager.GetQuestionnaireDetails(questionnaireid);
                    this.gvQuestionnaireDetails.DataBind();


                    //tabs-3
                    var userInfoSurvey = ListManager.GetSurveyUser(questionnaireid);

                    if (userInfoSurvey != null)
                    {
                        DataTable Record = new DataTable();
                        Record.Columns.Add("UserInfoID");
                        Record.Columns.Add("ltlName");
                        Record.Columns.Add("CreatDate");

                        DataRow dr = Record.NewRow();
                        dr["UserInfoID"] = userInfoSurvey.UserInfoID;
                        dr["ltlName"] = userInfoSurvey.Name;
                        dr["CreatDate"] = userInfoSurvey.CreatDate;

                        Record.Rows.Add(dr);
                        this.GridView1.DataSource = Record;
                        this.GridView1.DataBind();                                             

                    }

                    //tabs-4


                }
            }
        }
        private bool CheckInput(out List<string> errorMsgList)
        {
            List<string> msglist = new List<string>();
            Regex rx = new Regex(@"[\d\u4E00-\u9FA5A-Za-z-/u3002/uff1b/uff0c/uff1a/u201c/u201d/uff08/uff09/u3001/uff1f/u300a/u300b]");

            if (string.IsNullOrWhiteSpace(this.txbCaption.Text) || string.IsNullOrEmpty(this.txbCaption.Text))
                msglist.Add("<span style='color:red'>請輸入問卷名稱</span>");

            else if (string.IsNullOrWhiteSpace(this.txbContent.Text) || string.IsNullOrEmpty(this.txbContent.Text))
                msglist.Add("<span style='color:red'>請輸入描述內容</span>");

            else if (!rx.IsMatch(txbCaption.Text))                                                  //正則表達式排除特殊字元
                msglist.Add("<span style='color:red'>問卷名稱不能為特殊字元,請重新輸入</span>");

            else if (!rx.IsMatch(txbContent.Text))
                msglist.Add("<span style='color:red'>描述內容不能為特殊字元,請重新輸入</span>");

            errorMsgList = msglist;

            if (msglist.Count == 0)
                return true;
            else
                return false;
        }
        private bool CheckQuestInput(out List<string> errorMsgList)
        {
            List<string> msglist = new List<string>();
            Regex rx = new Regex(@"[\d\u4E00-\u9FA5A-Za-z-/u3002/uff1b/uff0c/uff1a/u201c/u201d/uff08/uff09/u3001/uff1f/u300a/u300b]");

            if (string.IsNullOrWhiteSpace(this.txbQuestionnaire.Text) || string.IsNullOrEmpty(this.txbCaption.Text))
                msglist.Add("<span style='color:red'>請輸入問題</span>");

            else if (string.IsNullOrWhiteSpace(this.txbQOption.Text) || string.IsNullOrEmpty(this.txbContent.Text))
                msglist.Add("<span style='color:red'>請輸入選項</span>");

            else if (!rx.IsMatch(txbCaption.Text))                                                  //正則表達式排除特殊字元
                msglist.Add("<span style='color:red'>問題不能為特殊字元,請重新輸入</span>");

            else if (!rx.IsMatch(txbContent.Text))
                msglist.Add("<span style='color:red'>選項不能為特殊字元,請重新輸入</span>");

            errorMsgList = msglist;

            if (msglist.Count == 0)
                return true;
            else
                return false;
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            List<string> msgList = new List<string>();
            if (!this.CheckInput(out msgList))
            {
                this.ltlMsg.Text = string.Join("<br/>", msgList);
                return;
            }
                       
            string QID = this.Request.QueryString["ID"];

            if(QID == null)
            {
                //是新增
                Questionnaire creatQID = new Questionnaire();

                creatQID.QuestionnaireID = new int();
                creatQID.Caption = txbCaption.Text;
                creatQID.QContent = txbContent.Text;
                creatQID.StartDate = DateTime.Now;

                if (txbEndDate.Text == "")
                {
                    creatQID.EndDate = null;
                }
                else
                {
                    creatQID.EndDate = Convert.ToDateTime(txbEndDate.Text);
                }

                if (CheckBox1.Checked)
                {
                    creatQID.Status = "啟用";
                }
                else
                {
                    creatQID.Status = "關閉";
                }
                ListManager.CreatQuestionnaire(creatQID);      
                Response.Redirect("List.aspx");

            }
            else
            {
                string questionnaireidtxt = this.Request.QueryString["ID"];
                int questionnaireid = int.Parse(questionnaireidtxt);

                //是編輯
                Questionnaire questionnaire = new Questionnaire()
                {
                    Caption = txbCaption.Text,
                    QContent = txbContent.Text,
                    StartDate = Convert.ToDateTime(txbStartDate.Text),
                    Status = CheckBox1.Text
                };

                if (txbEndDate.Text == "")
                {
                    questionnaire.EndDate = null;
                }
                else
                {
                    questionnaire.EndDate = Convert.ToDateTime(txbEndDate.Text);
                }

                ListManager.UpdateQuestionnaire(questionnaireid, questionnaire);
                Response.Redirect("List.aspx");
            }
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("List.aspx");
        }
        protected void btnQuestionnaire_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            // 取得按下按鈕的那一列
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;

            if (this.ltlGvbID.Text != Convert.ToString(gvr.RowIndex + 1))
            {
                //編輯行數不同時先初始化
                this.ltlGvbID.Text = String.Empty;
                this.txbQuestionnaire.Text = String.Empty;
                this.ddlType.SelectedValue = String.Empty;
                this.CheckBox2.Checked = false;
                this.txbQOption.Text = String.Empty;

                //取得編輯行數
                this.ltlGvbID.Text = Convert.ToString(gvr.RowIndex + 1);
                int qdid = int.Parse(this.ltlGvbID.Text);

                var QuestDetailsID_View = ListManager.GetQuestDetailsID(qdid);

                this.txbQuestionnaire.Text = QuestDetailsID_View.Question;
                this.ddlType.SelectedValue = QuestDetailsID_View.QuestionType;
                if (QuestDetailsID_View.Required == "0")
                {
                    this.CheckBox2.Checked = true;
                }
                else
                {
                    this.CheckBox2.Checked = false;
                }
                this.txbQOption.Text = QuestDetailsID_View.QOption;
            }
        }
        protected void ddlFAQ_SelectedIndexChanged(object sender, EventArgs e)
        {
                var ddlitem = this.ddlFAQ.SelectedValue;
                var customname = ListManager.GetFAQ(ddlitem);

                if (customname != null)
                {
                    this.ddlType.SelectedValue = customname.FAQType;
                    this.txbQuestionnaire.Text = customname.Question;
                    this.txbQOption.Text = customname.FOption;
                }        
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            //取得題號
            var ckd = this.ltlGvbID.Text;
            int ckdID = int.Parse(ckd);
            var ckdID_namber = ListManager.GetQuestDetailsID(ckdID);

            List<string> msgList = new List<string>();
            if (!this.CheckQuestInput(out msgList))
            {
                this.ltlMsg2.Text = string.Join("<br/>", msgList);
                return;
            }

            if (ckdID_namber == null)
            {
                //沒找到，是新增
                string questionnaireidtxt = this.Request.QueryString["ID"];
                int questionnaireid = int.Parse(questionnaireidtxt);

                QuestionnaireDetails newQest = new QuestionnaireDetails();

                newQest.QDID = new int();
                newQest.QuestionnaireID = questionnaireid;
                newQest.QuestionType = ddlType.SelectedValue;
                newQest.Question = txbQuestionnaire.Text;
                newQest.QOption = txbQOption.Text;
                if (CheckBox2.Checked)
                {
                    newQest.Required = "0";
                }
                else
                {
                    newQest.Required = "1";
                }

                ListManager.AddQuestionnaireDetails(newQest);
            }
            else
            {
                //有找到，是編輯
                QuestionnaireDetails questdtl = new QuestionnaireDetails()
                {
                    QuestionType = ddlType.SelectedValue,
                    Question = txbQuestionnaire.Text,
                    QOption = txbQOption.Text
                };
                if (CheckBox2.Checked)
                {
                    questdtl.Required = "0";
                }
                else
                {
                    questdtl.Required = "1";
                }
                ListManager.UpdateQuestionnaireDetails(ckdID, questdtl);
            }

            this.ltlGvbID.Text = String.Empty;
            this.txbQuestionnaire.Text = String.Empty;
            this.CheckBox2.Checked = false;
            this.txbQOption.Text = String.Empty;

            Response.Redirect("List.aspx");
        }
        protected void btnDel_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow row in gvQuestionnaireDetails.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    CheckBox ckb = (row.Cells[0].FindControl("cbxDelete") as CheckBox);
                    if (ckb.Checked)
                    {
                        int qdid = int.Parse(row.Cells[1].Text);
                        ListManager.DeleteQuestionnaireDetails(qdid);
                    }
                }
            }
            Response.Redirect("List.aspx");
        }
        protected void btnCancel1_Click(object sender, EventArgs e)
        {
            Response.Redirect("List.aspx");
        }

        protected void btnSave2_Click(object sender, EventArgs e)
        {
            Response.Redirect("List.aspx");
        }
        protected void btnOutput_Click(object sender, EventArgs e)
        {

        }
    }
}