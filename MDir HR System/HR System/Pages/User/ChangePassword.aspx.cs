using System;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Web;

namespace HR_Salaries.Pages.User
{
    public partial class ChangePassword : System.Web.UI.Page
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
                //else
                //{
                //if (MDirMaster.UserP != 1)
                //{
                //    Response.Redirect("~/Pages/Default.aspx");
                //}
                //lblMessage.Text = null;
                //}
            }
        }

        protected void btnChange_Click(object sender, EventArgs e)
        {
            if (!(String.IsNullOrEmpty(txtConfirmNewPassword.Text))
                && !(String.IsNullOrEmpty(txtNewPassword.Text))
                && !(String.IsNullOrEmpty(txtOldPassword.Text)))
            {
                if (txtNewPassword.Text == txtConfirmNewPassword.Text)
                {
                    if (txtNewPassword.Text.Length >= 4)
                    {
                        SqlCommand cmd = new SqlCommand();
                        cmd.CommandText = @"SELECT COUNT (*) FROM UsersTBL
                                    WHERE (UserName = @User)
                                      AND (Password = @Pass)";
                        cmd.Parameters.AddWithValue("@User", Session["UserName"].ToString());
                        using (MD5 md5Hash = MD5.Create())
                        {
                            cmd.Parameters.AddWithValue("@Pass", MDirMaster.GetMd5Hash(md5Hash, txtOldPassword.Text));
                        }
                        int count = (int)MDirMaster.ExecuteScaler(cmd, lblMessage, HttpContext.Current.Request.Path);
                        if (count == 1)
                        {
                            cmd.CommandText = @"UPDATE UsersTBL SET Password=@NewPass, LastUpdate=GETDATE()
                                    WHERE (UserName = @User)";
                            using (MD5 md5Hash = MD5.Create())
                            {
                                cmd.Parameters.AddWithValue("@NewPass", MDirMaster.GetMd5Hash(md5Hash, txtNewPassword.Text));
                            }
                            if (MDirMaster.Execute(cmd, lblMessage, HttpContext.Current.Request.Path))
                            {
                                Session["Logged"] = false;
                                Response.Redirect("~/Pages/Default.aspx", false);
                            }
                        }
                        else
                        {
                            MDirMaster.Messages(lblMessage, 4);
                        }
                    }
                    else
                    {
                        MDirMaster.Messages(lblMessage, 5);
                    }
                }
                else
                {
                    MDirMaster.Messages(lblMessage, 4);
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
