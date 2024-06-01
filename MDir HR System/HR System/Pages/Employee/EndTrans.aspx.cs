using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HR_Salaries;
using System.Data.SqlClient;
using System.Data;

namespace HR_Salaries.Pages.Employee
{
    public partial class EndTrans : System.Web.UI.Page
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
                    Response.Redirect("~/Pages/Default.aspx", false);
                }
                else
                {
                    MDirMaster.FillCombo("BranchID", "BranchDescAR", "BranchsTBL", ddlSBranch, true, lblMessage);
                    MDirMaster.FillCombo("DepartmentID", "DepartmentDescAR", "DepartmentTBL", ddlSDep, true, lblMessage);
                    ddlSBranch_SelectedIndexChanged(null, null);
                    //rbTempTrans_CheckedChanged(null, null);
                }
            }
        }

        protected void ddlName_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddl = sender as DropDownList;
            if (ddl != null)
            {
                string SenderID = ddl.SelectedValue;
                hfEmpID.Value = ddlNameEN.SelectedValue = ddlNameAR.SelectedValue = SenderID;
                GetGrid((Convert.ToInt32(ddl.SelectedValue)));
            }
        }

        protected void ddlSBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string Condition = "";
            //bool check = false;
            //if (Convert.ToInt32(ddlSBranch.SelectedValue) > 0)
            //{
            //    Condition += " BranchID = " + ddlSBranch.SelectedValue;
            //    check = true;
            //}
            //if (Convert.ToInt32(ddlSDep.SelectedValue) > 0)
            //{
            //    if (check)
            //    {
            //        Condition += " AND ";
            //    }
            //    Condition += " DepartmentID = " + ddlSDep.SelectedValue;
            //    check = true;
            //}
            //if (check)
            //{
            //    MDirMaster.FillCombo("EmpID", "FirstNameAR] + ' ' + [MidNameAR] + ' '+ [LastNameAR", "EmployeesTempTBL", ddlNameAR, Condition + " AND CurrentLocation=1 AND TempTransfare =1", lblMessage);
            //    MDirMaster.FillCombo("EmpID", "FirstNameEN] + ' ' + [MidNameEN] + ' '+ [LastNameEN", "EmployeesTempTBL", ddlNameEN, Condition + " AND CurrentLocation=1 AND TempTransfare =1", lblMessage);
            //    GetGrid(0);
            //}
            //else
            //{
            //    MDirMaster.FillCombo("EmpID", "FirstNameAR] + ' ' + [MidNameAR] + ' '+ [LastNameAR", "EmployeesTempTBL", ddlNameAR, " CurrentLocation=1 AND TempTransfare =1", lblMessage); // AND LocationStartDate IS NULL
            //    MDirMaster.FillCombo("EmpID", "FirstNameEN] + ' ' + [MidNameEN] + ' '+ [LastNameEN", "EmployeesTempTBL", ddlNameEN, " CurrentLocation=1 AND TempTransfare =1", lblMessage); // AND LocationStartDate IS NULL
            //    GetGrid(0);
            //}
            GetGrid(0);
        }

        private void GetGrid(int EmpID)
        {
            int BranchID = Convert.ToInt32(ddlSBranch.SelectedValue);
            int DepID = Convert.ToInt32(ddlSDep.SelectedValue);
            SqlCommand cmd = new SqlCommand();
            string Query = @"SELECT        dbo.EmployeesTBL.EmpID, dbo.EmployeesTBL.FirstNameEN + ' ' + dbo.EmployeesTBL.MidNameEN + ' ' + dbo.EmployeesTBL.LastNameEN AS [الاسم انكليزي], dbo.EmployeesTBL.FirstNameAR + ' ' + dbo.EmployeesTBL.MidNameAR + ' ' + dbo.EmployeesTBL.LastNameAR AS [الاسم], dbo.BranchsTBL.BranchDescAR AS الفرع, 
                                              dbo.DepartmentTBL.DepartmentDescAR AS القسم, dbo.EmployeesTBL.TempTransfare AS [تنسيب؟], BranchsTBL_1.BranchDescAR AS [إلى فرع], DepartmentTBL_1.DepartmentDescAR AS [إلى قسم]
                                FROM          dbo.EmployeesTBL INNER JOIN
                                              dbo.BranchsTBL ON dbo.EmployeesTBL.BranchID = dbo.BranchsTBL.BranchID INNER JOIN
                                              dbo.DepartmentTBL ON dbo.EmployeesTBL.DepartmentID = dbo.DepartmentTBL.DepartmentID INNER JOIN
                                              dbo.EmployeesTempTBL ON dbo.EmployeesTBL.EmpID = dbo.EmployeesTempTBL.EmpID INNER JOIN
                                              dbo.BranchsTBL AS BranchsTBL_1 ON dbo.EmployeesTempTBL.BranchID = BranchsTBL_1.BranchID INNER JOIN
                                              dbo.DepartmentTBL AS DepartmentTBL_1 ON dbo.EmployeesTempTBL.DepartmentID = DepartmentTBL_1.DepartmentID";

            string condition = "";
            string order = " ORDER BY      [الاسم]";

            if (rbTempTrans.Checked)
            {
                condition = @" WHERE         ((dbo.EmployeesTempTBL.TempTransfare = 1) AND (dbo.EmployeesTempTBL.CurrentLocation = 1) AND (dbo.EmployeesTempTBL.IsActive = 1) AND (dbo.EmployeesTempTBL.StartedWork = 1))";
            }
            else if (rbTransfare.Checked)
            {
                condition = @" WHERE         ((dbo.EmployeesTempTBL.TempTransfare <> 1) AND (dbo.EmployeesTempTBL.CurrentLocation = 1) AND (dbo.EmployeesTempTBL.IsActive = 1) AND (dbo.EmployeesTempTBL.StartedWork = 0)) ";
            }
            else
            {
                condition = @" WHERE         (((dbo.EmployeesTempTBL.TempTransfare <> 1) AND (dbo.EmployeesTempTBL.CurrentLocation = 1) AND (dbo.EmployeesTempTBL.IsActive = 1) AND (dbo.EmployeesTempTBL.StartedWork = 0)) OR
                                             ((dbo.EmployeesTempTBL.TempTransfare = 1) AND (dbo.EmployeesTempTBL.CurrentLocation = 1) AND (dbo.EmployeesTempTBL.IsActive = 1) AND (dbo.EmployeesTempTBL.StartedWork = 1)))";
            }

            if (EmpID > 0)
            {
                condition += @" AND (dbo.EmployeesTempTBL.EmpID = @EmpID) ";
                cmd.Parameters.AddWithValue("@EmpID", EmpID);
            }
            else
            {
                if (BranchID > 0)
                {
                    condition += @" AND (dbo.BranchsTBL.BranchID = @BranchID) ";
                    cmd.Parameters.AddWithValue("@BranchID", BranchID);
                }
                if (DepID > 0)
                {
                    condition += @" AND (dbo.DepartmentTBL.DepartmentID = @DepID) ";
                    cmd.Parameters.AddWithValue("@DepID", DepID);
                }
            }
            cmd.CommandText = Query + condition + order;
            DataTable dt = MDirMaster.GetData(cmd, lblMessage);
            MDirMaster.AddColumnsToGridView(gvTransformation, dt);
            gvTransformation.DataSource = dt;
            gvTransformation.DataBind();
            if (gvTransformation.Rows.Count > 0)
            {
                gvTransformation.Columns[0].Visible = false;
                gvTransformation.Columns[1].Visible = false;
            }
            if (EmpID == 0)
            {
                DataRow row = dt.NewRow();
                dt.Rows.Add(row);
                DataView dv = dt.DefaultView;
                dv.Sort = "الاسم";
                DataTable sortedDT = dv.ToTable();
                dt.Columns["الاسم"].ColumnName = "VALUE";
                dt.Columns["EmpID"].ColumnName = "ID";
                MDirMaster.Pop(dt, ddlNameAR);
                dt.Columns["VALUE"].ColumnName = "الاسم";
                dt.Columns["الاسم انكليزي"].ColumnName = "VALUE";
                MDirMaster.Pop(dt, ddlNameEN);
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            int EmpID = Convert.ToInt32(hfEmpID.Value);
            if (EmpID > 0)
            {
                Button btn = sender as Button;
                string id = btn.ID;
                string Query = "", OrderDesc = "";
                System.Data.DataTable dtBranchDep = MDirMaster.GetBranchDep(EmpID, lblMessage);
                int BranchID = Convert.ToInt32(dtBranchDep.Rows[0]["BranchID"]);
                int DepartmentID = Convert.ToInt32(dtBranchDep.Rows[0]["DepartmentID"]);
                string Department = dtBranchDep.Rows[0]["DepartmentDescAR"].ToString();
                string Branch = dtBranchDep.Rows[0]["BranchDescAR"].ToString();
                Query = @"UPDATE EmployeesTBL set CurrentLocation=1, LastModification= GETDATE ( ), StartedWork = 1
                                      WHERE EmpID = @EmpID and CurrentLocation = 0;
                                 UPDATE EmployeesTempTBL set CurrentLocation = 0
                                      WHERE EmpID = @EmpID and CurrentLocation = 1;";
                SqlCommand cmd = new SqlCommand(Query);
                cmd.Parameters.AddWithValue("@EmpID", EmpID);
                if (MDirMaster.Execute(cmd, lblMessage, HttpContext.Current.Request.Path))
                {
                    if (id == "btnEndTempTrans")
                    {
                        OrderDesc = @"باشر في فرع " + Branch + " قسم " + Department + " بعد انتهاء تنسيبه.";
                        if (MDirMaster.AdminOrderAdd(EmpID, BranchID, DepartmentID, OrderDesc, txtAdminOrderNo.Text, txtOrderDate.Text, 8, lblMessage))
                        {
                            ddlSBranch_SelectedIndexChanged(sender, e);
                        }
                    }
                    else if (id == "btnEndTrans")
                    {
                        OrderDesc = @"إلغاء نقله إلى فرع " + Branch + " قسم " + Department + ".";
                        if (MDirMaster.AdminOrderAdd(EmpID, BranchID, DepartmentID, OrderDesc, txtAdminOrderNo.Text, txtOrderDate.Text, 21, lblMessage))
                        {
                            ddlSBranch_SelectedIndexChanged(sender, e);
                        }
                    }
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

        protected void txtOrderDate_TextChanged(object sender, EventArgs e)
        {
            WebControl MyWebControl = sender as WebControl;
            if (MyWebControl != null)
            {
                lblMessage.Text = "";
                TextBox txt = (TextBox)MyWebControl;
                try
                {
                    DateTime date = Convert.ToDateTime(txt.Text);
                }
                catch
                {
                    lblMessage.Text = "الرجاء ادخال التاريخ بصورة صحيحة يوم/شهر/سنة او يوم-شهر-سنة";
                    txt.Focus();
                }
            }
        }

        protected void rbTempTrans_CheckedChanged(object sender, EventArgs e)
        {
            ddlSBranch_SelectedIndexChanged(null, null);
            if (rbTempTrans.Checked)
            {
                btnEndTempTrans.Enabled = true;
                btnEndTrans.Enabled = false;
            }
            else if (rbTransfare.Checked)
            {
                btnEndTempTrans.Enabled = false;
                btnEndTrans.Enabled = true;
            }
            else
            {
                btnEndTempTrans.Enabled = false;
                btnEndTrans.Enabled = false;
            }
        }

        protected void gvTransformation_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }
    }
}