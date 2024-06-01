using System;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Web;

namespace HR_Salaries.Pages.User
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblMessage.Text = null;
            if (Convert.ToBoolean(Session["Logged"]))
                Response.Redirect("~/Pages/Default.aspx", false);
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtUserName.Text) && !string.IsNullOrEmpty(txtPassword.Text))
            {
                if (txtPassword.Text.Length >= 4)
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = @"SELECT        dbo.EmployeesTBL.BranchID, dbo.EmployeesTBL.DepartmentID, dbo.UsersTBL.UserID, dbo.UserPrivilegesTBL.PrivilegeID,
                                                      [FirstNameAR] +' ' + [MidNameAR] + ' ' + [LastNameAR] as FullName,DepartmentDescAR
                    FROM            dbo.EmployeesTBL INNER JOIN
                         dbo.UsersTBL ON dbo.EmployeesTBL.EmpID = dbo.UsersTBL.EmpID INNER JOIN
                         dbo.UserPrivilegesTBL ON dbo.UsersTBL.UserID = dbo.UserPrivilegesTBL.UserID
						 left join DepartmentTBL on DepartmentTBL.DepartmentID=EmployeesTBL.DepartmentID
                    WHERE        (dbo.UserPrivilegesTBL.ApplicationID = @ApplicationID) --AND (dbo.UsersTBL.Password = @Pass)
AND (dbo.UsersTBL.UserName = @USER) AND (dbo.UsersTBL.IsActive = 1)";
                    cmd.Parameters.AddWithValue("@ApplicationID", MDirMaster.ApplicationID);
                    cmd.Parameters.AddWithValue("@User", txtUserName.Text);
                    using (MD5 md5Hash = MD5.Create())
                    {
                        cmd.Parameters.AddWithValue("@Pass", MDirMaster.GetMd5Hash(md5Hash, txtPassword.Text));
                    }
                    int count = Convert.ToInt32(MDirMaster.ExecuteScaler(cmd, lblMessage, HttpContext.Current.Request.Path));
                    DataTable dt = MDirMaster.GetData(cmd, lblMessage);
                    int Count = dt.Rows.Count;
                    if (Count == 1)
                    {
                        Session["Logged"] = true;
                        Session["UserName"] = txtUserName.Text;
                        Session["BranchID"] = dt.Rows[0][0].ToString();
                        Session["depID"] = dt.Rows[0][1].ToString();
                        Session["UserID"] = dt.Rows[0][2].ToString();
                        Session["FullName"] = dt.Rows[0][4].ToString();
                        Session["DepartmentDescAR"] = dt.Rows[0][5].ToString();
                        //MDirMaster.UserP = Convert.ToInt32(dt.Rows[0][3].ToString());
                        if (txtPassword.Text == MDirMaster.DefaultPass)
                        {
                            Response.Redirect("~/Pages/User/ChangePassword.aspx", false);
                        }
                        else
                        {
                            if (Session["Handler"] != null)
                            {
                                Response.Redirect(Session["Handler"].ToString(), false);
                            }
                            Response.Redirect("~/Pages/Default.aspx", false);
                        }
                    }
                    else if (Count == -1)
                    {
                    }
                    else
                    {
                        cmd.CommandText = @"SELECT COUNT (*) FROM UsersTBL
                                    WHERE UserName =@User";
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@User", txtUserName.Text);
                        count = (int)MDirMaster.ExecuteScaler(cmd, lblMessage, HttpContext.Current.Request.Path);
                        if (count == 1)
                        {
                            MDirMaster.Messages(lblMessage, 4);
                        }
                        else if (count == -1)
                        {
                            MDirMaster.Messages(lblMessage, 0);
                        }
                        else
                        {
                            MDirMaster.Messages(lblMessage, 8);
                        }
                    }
                }
                else
                {
                    MDirMaster.Messages(lblMessage, 5);
                }
            }
            else
            {
                MDirMaster.Messages(lblMessage, 3);
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("http:// ", false);
        }
    }
}
