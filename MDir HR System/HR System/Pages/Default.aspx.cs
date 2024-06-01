using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;

namespace HR_Salaries.Pages
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["msg"] != null)
            {
                int msg = Convert.ToInt32(Session["msg"]);

                MDirMaster.Messages(lblMessage, msg);
                Session["msg"] = null;
            }
            lblVersion.Text = String.Format("النسخة: {0}<br>بتاريـــــخ: {1}",
    System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString(),
    System.IO.File.GetLastWriteTime(System.Reflection.Assembly.GetExecutingAssembly().Location).ToString("yyyy/MM/dd"));
        }
    }
}
