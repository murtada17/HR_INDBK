using System;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Web;

namespace HR_Salaries.Pages.User
{
    public partial class CreateUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            lblMessage.Text = null;
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
                    //if (MDirMaster.UserP != 1)
                    //{
                    //    Response.Redirect("~/Pages/Default.aspx", false);
                    //}
                    string cond = @" IsActive =1 and (EmpID not in (SELECT [EmpID]
                                                                         FROM (SELECT [EmpID] from UsersTBL where UserID in (select UserID from .[dbo].[UserPrivilegesTBL] 
                                                                         Where [ApplicationID] = " + MDirMaster.ApplicationID + "))as fo)) ";
                    MDirMaster.FillCombo("PrivilegeID", "PrivilegeDescAR", "PrivilegesTBL", ddlUserType, true, lblMessage);
                    MDirMaster.FillCombo("BranchID", "BranchDescAR", "BranchsTBL", ddlSBranch, true, lblMessage);
                    MDirMaster.FillCombo("DepartmentID", "DepartmentDescAR", "DepartmentTBL", ddlSDep, true, lblMessage);
                    MDirMaster.FillCombo("EmpID", "FirstNameAR] + ' ' + [MidNameAR] + ' '+ [LastNameAR", "EmployeesTBL", ddlEmployee, cond, lblMessage);
                }
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/Default.aspx", false);
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            if ((Convert.ToInt32(ddlEmployee.SelectedValue) != 0) && !String.IsNullOrEmpty(txtAccountName.Text)
                && (Convert.ToInt16(ddlUserType.SelectedItem.Value) != 0))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"SELECT COUNT(*) FROM UsersTBL
                                    WHERE UserName = @User";
                cmd.Parameters.AddWithValue("@User", txtAccountName.Text);
                if ((int)MDirMaster.ExecuteScaler(cmd, lblMessage, "") == 0)
                {
                    cmd.CommandText = @"INSERT INTO UsersTBL 
                                    (EmpID, UserName, Password, IsActive, CreationDate)
                             VALUES ( @EmpID, @UserName, @Pass, @Active, GETDATE())
                                SELECT SCOPE_IDENTITY()";
                    cmd.Parameters.AddWithValue("@EmpID", ddlEmployee.SelectedValue);
                    cmd.Parameters.AddWithValue("@UserName", txtAccountName.Text);
                    using (MD5 md5Hash = MD5.Create())
                    {
                        cmd.Parameters.AddWithValue("@Pass", MDirMaster.GetMd5Hash(md5Hash, MDirMaster.DefaultPass));
                    }
                    cmd.Parameters.AddWithValue("@Active", true);
                    MDirMaster.ExecuteScaler(cmd, lblMessage, "");
                }

                SqlCommand cmdcheck = new SqlCommand(@"SELECT UserID FROM UsersTBL
                                    WHERE UserName = @User");
                cmdcheck.Parameters.AddWithValue("@User", txtAccountName.Text);
                int UserID = Convert.ToInt32(MDirMaster.ExecuteScaler(cmdcheck, lblMessage, ""));
                if (UserID > 1)
                {
                    cmd.Parameters.Clear();
                    cmd.CommandText = @"INSERT INTO UserPrivilegesTBL (UserID, ApplicationID, PrivilegeID)
                                                                   VALUES (@UserID, @ApplicationID, @PrivilegeID);";
                    if (MDirMaster.ApplicationID == 12)
                    {
                        cmd.CommandText += @"INSERT INTO [dbo].[UserPagesTBL]    ([UserID],[PageID],[ApplicationID])
                                                                    VALUES (@UserID, 191, @ApplicationID);
                                             INSERT INTO [dbo].[UserPagesTBL]    ([UserID],[PageID],[ApplicationID])
                                                                    VALUES (@UserID, 187, @ApplicationID);
                                             INSERT INTO [dbo].[UserPagesTBL]    ([UserID],[PageID],[ApplicationID])
                                                                    VALUES (@UserID, 11, @ApplicationID);";
                    }
                    cmd.Parameters.AddWithValue("@UserID", UserID);
                    cmd.Parameters.AddWithValue("@PrivilegeID", ddlUserType.SelectedValue);
                    cmd.Parameters.AddWithValue("@ApplicationID", MDirMaster.ApplicationID);
                    if (MDirMaster.Execute(cmd, lblMessage, ""))
                    {

                        Response.Redirect("~/Pages/User/UserPages.aspx?UID=" + UserID, false);
                    }
                    else
                    {
                        MDirMaster.Messages(lblMessage, "User created with ERROR, privilages must be set. Please contact us");
                    }
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

        protected void ddlEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT [EmailName] FROM [HR].[dbo].[EmailsTBL]  WHERE IsActive=1 AND IsPrimary =1 AND EmpID = " + ddlEmployee.SelectedValue;
            string email = Convert.ToString(MDirMaster.ExecuteScaler(cmd, lblMessage, HttpContext.Current.Request.Path));
            int index = email.IndexOf("@");
            if (index > 0)
            {
                email = email.Substring(0, index);
            }
            txtAccountName.Text = email;
        }

        protected void ddlSBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Condition = @" IsActive =1 and (EmpID not in (SELECT [EmpID]
                                                                FROM (SELECT [EmpID] from UsersTBL where UserID in (select UserID from .[dbo].[UserPrivilegesTBL] 
                                                                Where [ApplicationID] = " + MDirMaster.ApplicationID + "))as fo)) ";
            if (Convert.ToInt32(ddlSBranch.SelectedValue) > 0)
            {
                Condition += " AND BranchID = " + ddlSBranch.SelectedValue;
            }
            if (Convert.ToInt32(ddlSDep.SelectedValue) > 0)
            {
                Condition += " AND DepartmentID = " + ddlSDep.SelectedValue;
            }

            MDirMaster.FillCombo("EmpID", "FirstNameAR] + ' ' + [MidNameAR] + ' '+ [LastNameAR", "EmployeesTBL", ddlEmployee, Condition, lblMessage);
        }

    }
}
