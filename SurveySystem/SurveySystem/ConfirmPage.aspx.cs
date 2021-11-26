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
            string aaa = Request.Form["getName(((RepeaterItem)Container.Parent.Parent).DataItem.ToString(), Container.DataItem.ToString())"];
            System.Diagnostics.Debug.WriteLine(aaa);
        }
    }
}