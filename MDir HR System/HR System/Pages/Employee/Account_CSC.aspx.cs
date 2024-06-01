using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HR_Salaries.Pages.Employee
{
    public partial class Account_CSC : System.Web.UI.Page
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
                    MDirMaster.FillCombo("BranchID", "BranchDescAR", "BranchsTBL", ddlSBranch, true, lblMessage);
                    MDirMaster.FillCombo("DepartmentID", "DepartmentDescAR", "DepartmentTBL", ddlSDep, true, lblMessage);
                    MDirMaster.FillCombo("EmpID", "FirstNameAR] + ' ' + [MidNameAR] + ' '+ [LastNameAR", "EmployeesTBL", ddlEmployee, lblMessage);
                }
            }
        }

        protected void ddlSBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Condition = "";
            bool check = false;
            if (Convert.ToInt32(ddlSBranch.SelectedValue) > 0)
            {
                Condition += " BranchID = " + ddlSBranch.SelectedValue;
                check = true;
            }
            if (Convert.ToInt32(ddlSDep.SelectedValue) > 0)
            {
                if (check)
                {
                    Condition += " AND ";
                }
                Condition += " DepartmentID = " + ddlSDep.SelectedValue;
                check = true;
            }
            if (check)
            {
                Condition += " AND IsActive = 1 ";
                MDirMaster.FillCombo("EmpID", "FirstNameAR] + ' ' + [MidNameAR] + ' '+ [LastNameAR", "EmployeesTBL", ddlEmployee, Condition, lblMessage);
            }
            else
            {
                MDirMaster.FillCombo("EmpID", "FirstNameAR] + ' ' + [MidNameAR] + ' '+ [LastNameAR", "EmployeesTBL", ddlEmployee, true, lblMessage);
            }
        }

        protected void ddlEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand();
            int EmpID = Convert.ToInt32(ddlEmployee.SelectedValue);
            if (EmpID > 0)
            {
                DataTable dt = MDirMaster.GetBranchDep(EmpID, lblMessage);
                try
                {
                    hfEmpID.Value = EmpID.ToString();
                    ddlSBranch.SelectedValue = dt.Rows[0]["BranchID"].ToString();
                    ddlSDep.SelectedValue = dt.Rows[0]["DepartmentID"].ToString();
                    cmd.CommandText = @"SELECT Account_Number_CSC FROM EmployeesTBL WHERE EmpID = @EmpID";
                    cmd.Parameters.AddWithValue("@EmpID", hfEmpID.Value);
                    txtIdNo.Text = MDirMaster.ExecuteScaler(cmd, lblMessage, HttpContext.Current.Request.Path).ToString();

                }
                catch
                {

                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            if (Convert.ToInt32(hfEmpID.Value) > 0 && !string.IsNullOrEmpty(txtIdNo.Text))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "UPDATE EmployeesTBL SET Account_Number_CSC = @AccNumber WHERE EmpID = @EmpID";
                cmd.Parameters.AddWithValue("@AccNumber", txtIdNo.Text);
                cmd.Parameters.AddWithValue("@EmpID", hfEmpID.Value);
                if (!MDirMaster.Execute(cmd, lblMessage, HttpContext.Current.Request.Path))
                {

                }
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/Default.aspx", false);
        }

    }
}