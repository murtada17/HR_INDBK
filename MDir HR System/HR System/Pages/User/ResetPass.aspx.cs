using System;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Web;

namespace HR_Salaries.Pages.User
{
    public partial class ResetPass : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string url = HttpContext.Current.Request.Path;
                if (!MDirMaster.HasPrivilage(url, lblMessage))
                {
                    Session["msg"] = "9";
                    Response.Redirect("~/Pages/Default.aspx", false);
                }
                else
                {
                    lblMessage.Text = null;
                    MDirMaster.FillCombo("UserID", "UserName", "UsersTBL", ddlUserName, true, lblMessage);
                }
            }
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(ddlUserName.SelectedItem.Value) > 0)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "UPDATE UsersTBL SET Password=@Pass, LastUpdate=GETDATE() WHERE UserID = @UserID";
                using (MD5 md5Hash = MD5.Create())
                {
                    cmd.Parameters.AddWithValue("@Pass", MDirMaster.GetMd5Hash(md5Hash, MDirMaster.DefaultPass));
                }
                cmd.Parameters.AddWithValue("@UserID", ddlUserName.SelectedValue);
                if (MDirMaster.Execute(cmd, lblMessage, HttpContext.Current.Request.Path))
                {
                    MDirMaster.Messages(lblMessage, 1);
                }
                else
                {
                    MDirMaster.Messages(lblMessage, 0);
                }
            }
            else
            {
                MDirMaster.Messages(lblMessage, 3);
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/Default.aspx", false);
        }

    }
}
