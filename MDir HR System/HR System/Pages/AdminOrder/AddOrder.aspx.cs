
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HR_Salaries.Pages.AdminOrder
{
    public partial class AddOrder : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
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
                    MDirMaster.FillCombo("BranchID", "BranchDescAR", "BranchsTBL", ddlSBranch, true, lblMessage);
                    MDirMaster.FillCombo("DepartmentID", "DepartmentDescAR", "DepartmentTBL", ddlSDep, true, lblMessage);
                    MDirMaster.FillCombo("TypeID", "TypeDescAR", "AdminOrdersTypesTBL", ddlOrderType, true, lblMessage);
                    MDirMaster.FillCombo("EmpID", "FirstNameAR] + ' ' + [MidNameAR] + ' '+ [LastNameAR", "EmployeesTBL", ddlNameAR, true, lblMessage);
                    MDirMaster.FillCombo("EmpID", "FirstNameEN] + ' ' + [MidNameEN] + ' '+ [LastNameEN", "EmployeesTBL", ddlNameEN, true, lblMessage);
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
            Condition += " AND IsActive = 1 ";
            if (check)
            {
                MDirMaster.FillCombo("EmpID", "FirstNameAR] + ' ' + [MidNameAR] + ' '+ [LastNameAR", "EmployeesTBL", ddlNameAR, Condition, lblMessage);
                MDirMaster.FillCombo("EmpID", "FirstNameEN] + ' ' + [MidNameEN] + ' '+ [LastNameEN", "EmployeesTBL", ddlNameEN, Condition, lblMessage);
            }
            else
            {
                MDirMaster.FillCombo("EmpID", "FirstNameAR] + ' ' + [MidNameAR] + ' '+ [LastNameAR", "EmployeesTBL", ddlNameAR, true, lblMessage);
                MDirMaster.FillCombo("EmpID", "FirstNameEN] + ' ' + [MidNameEN] + ' '+ [LastNameEN", "EmployeesTBL", ddlNameEN, true, lblMessage);
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
                hfEmpID.Value = ddlNameEN.SelectedValue;
                DataTable dt = MDirMaster.GetBranchDep(Convert.ToInt32(hfEmpID.Value), lblMessage);
                ddlSBranch.SelectedValue = dt.Rows[0]["BranchID"].ToString();
                ddlSDep.SelectedValue = dt.Rows[0]["DepartmentID"].ToString();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            int EmpID = Convert.ToInt32(hfEmpID.Value);
            if (EmpID > 0)
            {
                DataTable dt = MDirMaster.GetBranchDep(EmpID, lblMessage);
                int BranchID = Convert.ToInt32(dt.Rows[0]["BranchID"]);
                int DepID = Convert.ToInt32(dt.Rows[0]["DepartmentID"]);
                int OrderType = Convert.ToInt32(ddlOrderType.SelectedValue);
                MDirMaster.AdminOrderAdd(EmpID, BranchID, DepID, txtOrderDesc.Text, txtOrderNo.Text, txtOrderDate.Text, OrderType, lblMessage);
            }
            else
            {
                MDirMaster.Messages(lblMessage, 3);
            }
        }


        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/pages/default.aspx");
        }
    }
}