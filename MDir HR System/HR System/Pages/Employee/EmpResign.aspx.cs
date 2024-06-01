using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HR_Salaries.Pages.Employee
{
    public partial class EmpResign : System.Web.UI.Page
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
                    MDirMaster.FillCombo("ResonID", "ResonDescAR", "ResignResonsTBL", ddlResignReason, true, lblMessage);
                    MDirMaster.FillCombo("EmpID", "FirstNameAR] + ' ' + [MidNameAR] + ' '+ [LastNameAR", "EmployeesTBL", ddlEmployee, lblMessage);
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = @" SELECT [ID], [VALUE] 
                                        FROM (SELECT TOP (100) PERCENT [TypeID] AS [ID], [TypeDescAR] AS [VALUE] FROM AdminOrdersTypesTBL 
                                        WHERE IsActive = 1 and TypeID IN (1, 22, 23)  ) AS Foo ORDER BY VALUE ASC ";
                    DataTable dt = MDirMaster.GetData(cmd, lblMessage);
                    MDirMaster.Pop(dt, chbType);
                    txtLeaveDate.Text = txtOrderDate.Text = DateTime.Now.ToShortDateString();
                    ddlEmployee_SelectedIndexChanged(null, null);
                }
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/Default.aspx", false);
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            int EmpID = Convert.ToInt32(ddlEmployee.SelectedValue);
            if (EmpID > 0)
            {
                System.Data.DataTable dtBranchDep = MDirMaster.GetBranchDep(EmpID, lblMessage);
                int BranchID = Convert.ToInt32(dtBranchDep.Rows[0]["BranchID"]);
                int DepartmentID = Convert.ToInt32(dtBranchDep.Rows[0]["DepartmentID"]);
                if (chbType.Items.FindByValue("1").Selected)
                {
                    //استقالة
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = @"UPDATE EmployeesTBL SET ResignReasonID = @ResID WHERE EmpID=@EmpID;
                                    UPDATE EmployeesTempTBL SET ResignReasonID = @ResID WHERE EmpID=@EmpID";
                    cmd.Parameters.AddWithValue("@EmpID", EmpID);
                    cmd.Parameters.AddWithValue("@ResID", ddlResignReason.SelectedValue);
                    if (MDirMaster.Execute(cmd, lblMessage, HttpContext.Current.Request.Path))
                    {
                        MDirMaster.AdminOrderAdd(EmpID, BranchID, DepartmentID, txtOrderDesc.Text, txtOrderNo.Text, txtOrderDate.Text, 1, lblMessage);
                    }
                    else
                    {
                        MDirMaster.Messages(lblMessage, 1000);
                    }
                }
                if (chbType.Items.FindByValue("22").Selected)
                {
                    //انفكاك
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = @"UPDATE EmployeesTBL SET IsActive=0, LeaveDate = @LeaveDate WHERE EmpID = @EmpID;
                                    UPDATE EmployeesTempTBL SET IsActive=0, LeaveDate = @LeaveDate WHERE EmpID = @EmpID";
                    cmd.Parameters.AddWithValue("@EmpID", EmpID);
                    cmd.Parameters.Add("@LeaveDate", System.Data.SqlDbType.DateTime);
                    cmd.Parameters["@LeaveDate"].Value = txtLeaveDate.Text;
                    if (MDirMaster.Execute(cmd, lblMessage, HttpContext.Current.Request.Path))
                    {
                        MDirMaster.AdminOrderAdd(EmpID, BranchID, DepartmentID, txtOrderDesc.Text, txtOrderNo.Text, txtOrderDate.Text, 22, lblMessage);
                    }
                }
                if (chbType.Items.FindByValue("23").Selected)
                {
                    //برائة ذمة
                    MDirMaster.AdminOrderAdd(EmpID, BranchID, DepartmentID, txtOrderDesc.Text, txtOrderNo.Text, txtOrderDate.Text, 23, lblMessage);
                }
            }
            else
            {
                MDirMaster.Messages(lblMessage, 3);
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
                    ddlSBranch.SelectedValue = dt.Rows[0]["BranchID"].ToString();
                    ddlSDep.SelectedValue = dt.Rows[0]["DepartmentID"].ToString();
                }
                catch
                {

                }
                cmd.CommandText = @"SELECT   TOP (100) PERCENT dbo.AdminOrdersTBL.AdminOrderID, dbo.EmployeesTBL.EmpID, dbo.EmployeesTBL.FirstNameAR + ' ' + dbo.EmployeesTBL.MidNameAR + ' ' + dbo.EmployeesTBL.LastNameAR AS الاسم, 
                                             dbo.AdminOrdersTypesTBL.TypeDescAR AS [نوع الامر], dbo.EmployeesTBL.LeaveDate AS [تاريخ الانفكاك], dbo.AdminOrdersTBL.OrderNo AS [رقم الامر], dbo.AdminOrdersTBL.OrderDate AS [تاريخ الامر], 
                                             dbo.AdminOrdersTBL.OrderDesc AS ملاحظات, dbo.ResignResonsTBL.ResonDescAR AS [سبب الايقاف]
                                    FROM     dbo.ResignResonsTBL RIGHT OUTER JOIN
                                             dbo.EmployeesTBL ON dbo.ResignResonsTBL.ResonID = dbo.EmployeesTBL.ResignReasonID LEFT OUTER JOIN
                                             dbo.AdminOrdersTBL ON dbo.EmployeesTBL.EmpID = dbo.AdminOrdersTBL.EmpID RIGHT OUTER JOIN
                                             dbo.AdminOrdersTypesTBL ON dbo.AdminOrdersTBL.OrderTypeID = dbo.AdminOrdersTypesTBL.TypeID
									WHERE    (dbo.AdminOrdersTBL.IsActive = 1) AND (dbo.AdminOrdersTypesTBL.TypeID IN (1, 22, 23)) AND (dbo.AdminOrdersTBL.EmpID = @EmpID)
                                    ORDER BY [تاريخ الامر] desc";
                cmd.Parameters.AddWithValue("@EmpID", EmpID);
            }
            else
            {
                cmd.CommandText = @"SELECT  TOP (100) PERCENT dbo.AdminOrdersTBL.AdminOrderID, dbo.EmployeesTBL.EmpID, dbo.EmployeesTBL.FirstNameAR + ' ' + dbo.EmployeesTBL.MidNameAR + ' ' + dbo.EmployeesTBL.LastNameAR AS الاسم, 
                                            dbo.AdminOrdersTypesTBL.TypeDescAR AS [نوع الامر], dbo.EmployeesTBL.LeaveDate AS [تاريخ الانفكاك], dbo.AdminOrdersTBL.OrderNo AS [رقم الامر], dbo.AdminOrdersTBL.OrderDate AS [تاريخ الامر], 
                                            dbo.AdminOrdersTBL.OrderDesc AS ملاحظات, dbo.ResignResonsTBL.ResonDescAR AS [سبب الايقاف]
                                    FROM    dbo.ResignResonsTBL RIGHT OUTER JOIN
                                            dbo.EmployeesTBL ON dbo.ResignResonsTBL.ResonID = dbo.EmployeesTBL.ResignReasonID LEFT OUTER JOIN
                                            dbo.AdminOrdersTBL ON dbo.EmployeesTBL.EmpID = dbo.AdminOrdersTBL.EmpID RIGHT OUTER JOIN
                                            dbo.AdminOrdersTypesTBL ON dbo.AdminOrdersTBL.OrderTypeID = dbo.AdminOrdersTypesTBL.TypeID
                                    WHERE  (dbo.AdminOrdersTBL.IsActive = 1) AND (dbo.AdminOrdersTypesTBL.TypeID IN (1)) AND (dbo.EmployeesTBL.LeaveDate IS NULL) AND (dbo.EmployeesTBL.ResignReasonID IS NOT NULL)
                                    ORDER BY [تاريخ الامر] DESC";
            }
            MDirMaster.FillGrid(cmd, gvOrders, lblMessage);
            if (gvOrders.Rows.Count > 0)
            {
                gvOrders.Columns[1].Visible = false;
            }
        }

        protected void gvOrders_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView gv = sender as GridView;
            gv.PageIndex = e.NewPageIndex;
            gv.SelectedIndex = -1;
            ddlSBranch_SelectedIndexChanged(null, null);
        }

        protected void gvOrders_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int index = e.RowIndex;
            int AdminOrderID = Convert.ToInt32(gvOrders.Rows[index].Cells[1].Text);
            int EmpID = Convert.ToInt32(gvOrders.Rows[index].Cells[2].Text);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = @"UPDATE AdminOrdersTBL SET IsActive = 0 WHERE AdminOrderID= @AdminOrderID;
                                UPDATE EmployeesTBL SET ResignReasonID = NULL, LeaveDate = NULL WHERE EmpID = @EmpID";
            cmd.Parameters.AddWithValue("@AdminOrderID", AdminOrderID);
            cmd.Parameters.AddWithValue("@EmpID", EmpID);
            if (MDirMaster.Execute(cmd, lblMessage, HttpContext.Current.Request.Path))
            {
                ddlEmployee_SelectedIndexChanged(null, null);
            }
        }
    }
}