using SurveySystem.DBsource;
using SurveySystem.ORM.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SurveySystem.SystemAdmin
{
    public partial class FAQList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.grvFAQ.DataSource = ListManager.GetFAQSeleteItem();
                this.grvFAQ.DataBind();
            }            
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow row in grvFAQ.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    CheckBox ckb = (row.Cells[0].FindControl("cbxDelete") as CheckBox);
                    if (ckb.Checked)
                    {
                        string name = row.Cells[1].Text;
                        ListManager.DeleteFAQ(name);
                    }
                }
            }
            Response.Redirect("/SystemAdmin/FAQList.aspx");
        }

        protected void btnCreat_Click(object sender, EventArgs e)
        {
            Response.Redirect("/SystemAdmin/FAQCreat.aspx");
        }
    }
}