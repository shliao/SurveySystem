using SurveySystem.DBsource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SurveySystem.SystemAdmin
{
    public partial class List : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.gv_list.DataSource = ListManager.GetQuestionnaire();
                this.gv_list.DataBind();
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.txbStr.Text) || string.IsNullOrEmpty(this.txbEnd.Text)) // 檢查有無輸入日期
            {
                this.ltlMsg.Visible = true;
                this.ltlMsg.Text = "<span style='color:red'>搜尋日期有錯誤,請重新選取日期</span>";
            }

            string start = this.txbStr.Text;
            string end = this.txbEnd.Text;
            try                                // 檢查是否符合DateTime格式(例外輸入狀況:年份五位數)
            {
                DateTime.Parse(start);
                DateTime.Parse(end);
            }
            catch (Exception)
            {
                this.gv_list.Visible = false;
                this.ltlMsg.Visible = true;
                this.ltlMsg.Text = "<span style='color:red'>搜尋日期有錯誤,請重新選取日期</span>";
                return;
            }
            DateTime startTime = Convert.ToDateTime(start);
            DateTime endTime = Convert.ToDateTime(end);
            var list = ListManager.GetQuestionnaireByDate(startTime, endTime);

            if (list.Count > 0)  // 檢查有無資料
            {
                this.gv_list.Visible = true;
                this.gv_list.DataSource = ListManager.GetQuestionnaireByDate(startTime, endTime);
                this.gv_list.DataBind();
            }
            else
            {
                this.gv_list.Visible = false;
                this.ltlMsg.Visible = true;
                this.ltlMsg.Text = "<span style='color:red'>搜尋日期有錯誤,請重新選取日期</span>";
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow row in gv_list.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    CheckBox ckb = (row.Cells[0].FindControl("cbxDeleteList") as CheckBox);
                    if (ckb.Checked)
                    {
                        int qdid = int.Parse(row.Cells[1].Text);
                        ListManager.DeleteQuestionnaire(qdid);
                    }
                }
            }
            Response.Redirect("List.aspx");
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {

            Response.Redirect("Detail.aspx");
        }
    }
}