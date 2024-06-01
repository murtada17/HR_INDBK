using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HR_Salaries.Pages.Employee
{
    public partial class EmpBlock : System.Web.UI.Page
    {
        public static int EmpID = 0;
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
                    //    Response.Redirect("~/Pages/Default.aspx");
                    //}
                    MDirMaster.FillCombo("BranchID", "BranchDescAR", "BranchsTBL", ddlSBranch, true, lblMessage);
                    MDirMaster.FillCombo("DepartmentID", "DepartmentDescAR", "DepartmentTBL", ddlSDep, true, lblMessage);
                    MDirMaster.FillCombo("EmpID", "FirstNameAR] + ' ' + [MidNameAR] + ' '+ [LastNameAR", "EmployeesTBL", ddlNameAR, true, lblMessage);
                    MDirMaster.FillCombo("EmpID", "FirstNameEN] + ' ' + [MidNameEN] + ' '+ [LastNameEN", "EmployeesTBL", ddlNameEN, true, lblMessage);
                }
            }
        }

        protected void ddlName_SelectedIndexChanged(object sender, EventArgs e)
        {
            WebControl MyWebControl = sender as WebControl;
            if (MyWebControl != null)
            {
                string SenderID = MyWebControl.ID.ToString();
                if (SenderID == "ddlNameAR")
                {
                    ddlNameEN.SelectedValue = ddlNameAR.SelectedValue;
                }
                else if (SenderID == "ddlNameEN")
                {
                    ddlNameAR.SelectedValue = ddlNameEN.SelectedValue;
                }
                EmpID = Convert.ToInt32(ddlNameAR.SelectedValue);
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (EmpID > 0)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"Update EmployeesTBL SET IsBlocked=1
                                        WHERE EmpID= @EmpID";
                cmd.Parameters.AddWithValue("@EmpID", EmpID);
                MDirMaster.Execute(cmd, lblMessage, HttpContext.Current.Request.Path);
            }
            else
            {
                lblMessage.Text = "الرجاء أختيار موظف";
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/Default.aspx", false);
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

                MDirMaster.FillCombo("EmpID", "FirstNameAR] + ' ' + [MidNameAR] + ' '+ [LastNameAR", "EmployeesTBL", ddlNameAR, Condition, lblMessage);
                MDirMaster.FillCombo("EmpID", "FirstNameEN] + ' ' + [MidNameEN] + ' '+ [LastNameEN", "EmployeesTBL", ddlNameEN, Condition, lblMessage);
            }
            else
            {
                MDirMaster.FillCombo("EmpID", "FirstNameAR] + ' ' + [MidNameAR] + ' '+ [LastNameAR", "EmployeesTBL", ddlNameAR, lblMessage);
                MDirMaster.FillCombo("EmpID", "FirstNameEN] + ' ' + [MidNameEN] + ' '+ [LastNameEN", "EmployeesTBL", ddlNameEN, lblMessage);
            }
        }
    }
}