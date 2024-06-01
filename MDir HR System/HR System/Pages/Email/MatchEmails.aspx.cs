using HR_Salaries;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MDir_DMS.Pages.Email
{
    public partial class MatchEmails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            if (!IsPostBack)
            {

                string url = HttpContext.Current.Request.Path;
                if (!MDirMaster.HasPrivilage(url, lblMessage))
                {
                    Session["msg"] = "9";
                    Response.Redirect("~/Pages/Default.aspx");
                }
                else
                {
                    MDirMaster.FillCombo("EmpID", "FirstNameAR] + ' ' + [MidNameAR] + ' '+ [LastNameAR", "EmployeesTBL", ddlNameAR, lblMessage);
                    MDirMaster.FillCombo("EmpID", "FirstNameEN] + ' ' + [MidNameEN] + ' '+ [LastNameEN", "EmployeesTBL", ddlNameEN, lblMessage);
                    MDirMaster.FillCombo("EmailTypeID", "EmailTypeDesc", "EmailTypeTBL", ddlEmailType, true, lblMessage);
                    MDirMaster.FillCombo("EmailID", "EmailName", "EmailsTBL", ddlEmail, "EmpID = 80", lblMessage);
                    ddlEmailType.SelectedValue = "1";
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (ddlEmail.SelectedIndex > 0 && ddlNameAR.SelectedIndex > 0 && ddlEmailType.SelectedIndex > 0)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"UPDATE EmailsTBL SET EmpID= @EmpID, IsActive=1
                                WHERE  EmailID = @EmailID";
                cmd.Parameters.AddWithValue("@EmailID", hfEmailID.Value);
                cmd.Parameters.AddWithValue("@EmpID", hfEmpID.Value);
                if (MDirMaster.Execute(cmd, lblMessage, HttpContext.Current.Request.Path))
                {
                    MDirMaster.FillCombo("EmailID", "EmailName", "EmailsTBL", ddlEmail, "EmpID = 80", lblMessage);
                    ddlEmailType.SelectedValue = "1";
                }
            }
            else
            {
                MDirMaster.Messages(lblMessage, "الرجاء اختيار البريد الألكتروني، و اسم الموظف");
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/Default.aspx");
        }

        protected void ddlName_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddl = sender as DropDownList;
            if (ddl != null)
            {
                string SenderID = ddl.SelectedValue;
                hfEmpID.Value = ddlNameEN.SelectedValue = ddlNameAR.SelectedValue = SenderID;
            }
        }

        protected void ddlEmail_SelectedIndexChanged(object sender, EventArgs e)
        {
            hfEmailID.Value = ddlEmail.SelectedValue;
        }
    }
}