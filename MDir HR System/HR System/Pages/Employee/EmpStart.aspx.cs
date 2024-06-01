using HR_Salaries;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI.WebControls;

namespace HR_Salaries.Pages.Employee
{
    public partial class EmpStart : System.Web.UI.Page
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
                    gvEmpVications.Visible = false;
                    //ddlSBranch_SelectedIndexChanged(null, null);
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
                if (rbVication.Checked)
                {
                    GetGrid();
                    gvEmpVications.Visible = true;
                }
                else
                {
                    gvEmpVications.Visible = false;
                }
                DataTable dt = MDirMaster.GetBranchDep(Convert.ToInt32(hfEmpID.Value), lblMessage);
                ddlSBranch.SelectedValue = dt.Rows[0]["BranchID"].ToString();
                ddlSDep.SelectedValue = dt.Rows[0]["DepartmentID"].ToString();
            }
        }

        private void GetGrid()
        {
            int EmpID = Convert.ToInt32(hfEmpID.Value);
            if (EmpID > 0)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"SELECT       dbo.VicationsTBL.VicationID, dbo.EmployeesTBL.FirstNameAR + ' ' + dbo.EmployeesTBL.MidNameAR + ' ' + dbo.EmployeesTBL.LastNameAR AS الأسم, 
                                                 dbo.VicationTypesTBL.VicationDesc AS [نوع الإجازة], 
                                                 CASE WHEN dbo.VicationTypesTBL.VicationTypeID != 8 THEN dbo.VicationsTBL.VicationInterval / 7 WHEN dbo.VicationTypesTBL.VicationTypeID = 8 THEN dbo.VicationsTBL.VicationInterval
                                                 END AS [مدة الإجازة], dbo.VicationsTBL.StartDate AS [ابتدءاً من], dbo.VicationsTBL.EndDate AS [انتهاءاً], dbo.VicationsTBL.SubmitDate AS [تاريخ الإدخال], dbo.VicationsTBL.Note AS ملاحظات
                                    FROM         dbo.EmployeesTBL INNER JOIN
                                                 dbo.VicationsTBL ON dbo.EmployeesTBL.EmpID = dbo.VicationsTBL.EmpID INNER JOIN
                                                 dbo.VicationTypesTBL ON dbo.VicationsTBL.VicationTypeID = dbo.VicationTypesTBL.VicationTypeID
                                    WHERE        (dbo.VicationsTBL.IsActive = 1) AND (dbo.EmployeesTBL.EmpID = @EmpID)
                                    ORDER BY dbo.VicationsTBL.SubmitDate DESC, dbo.VicationsTBL.StartDate DESC";
                cmd.Parameters.AddWithValue("@EmpID", EmpID);
                MDirMaster.FillGrid(cmd, gvEmpVications, lblMessage);
            }
        }

        protected void ddlSBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Condition = "", TransType = "";
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
            SqlCommand cmd = new SqlCommand();
            string Query = "";
            string queryAR = @"SELECT '0' AS [ID], N' يرجى الأختيار' AS [VALUE] UNION SELECT [ID], [VALUE] 
                              FROM (SELECT TOP (100) PERCENT EmpID AS [ID], [FirstNameAR] + ' ' + [MidNameAR] + ' '+ [LastNameAR] AS [VALUE] From ";
            string queryEN = @"SELECT '0' AS [ID], N' يرجى الأختيار' AS [VALUE] UNION SELECT [ID], [VALUE] 
                              FROM (SELECT TOP (100) PERCENT EmpID AS [ID], [FirstNameEN] + ' ' + [MidNameEN] + ' '+ [LastNameEN] AS [VALUE] From ";
            if (rbNewEmp.Checked)
            {// new employement
                Query += " EmployeesTBL ";
            }
            else if (rbTempTrans.Checked)
            { //temp transfare
                Query += " EmployeesTempTBL ";
                TransType = " TempTransfare =1 ";
            }
            else if (rbTransfare.Checked)
            {// transfare
                Query += " EmployeesTempTBL ";
                TransType = " TempTransfare !=1 ";

            }
            else if (rbVication.Checked)
            {
                queryAR = @"SELECT '0' AS [ID], N' يرجى الأختيار' AS [VALUE] UNION SELECT [ID], [VALUE] 
                              FROM (SELECT TOP (100) PERCENT dbo.EmployeesTBL.EmpID AS [ID], [FirstNameAR] + ' ' + [MidNameAR] + ' '+ [LastNameAR] AS [VALUE] From ";
                queryEN = @"SELECT '0' AS [ID], N' يرجى الأختيار' AS [VALUE] UNION SELECT [ID], [VALUE] 
                              FROM (SELECT TOP (100) PERCENT dbo.EmployeesTBL.EmpID AS [ID], [FirstNameEN] + ' ' + [MidNameEN] + ' '+ [LastNameEN] AS [VALUE] From ";
                Query += @" dbo.EmployeesTBL INNER JOIN
                            dbo.VicationsTBL ON dbo.EmployeesTBL.EmpID = dbo.VicationsTBL.EmpID
                            where(dbo.VicationsTBL.VicationTypeID in (2,4,6,7,10, 13) or ( VicationInterval>133))
                            and ((EndDate between DATEADD(day,-14, getdate()) and DATEADD(day, 14, getdate()) and dbo.VicationsTBL.IsActive=1) and
                            (StartedWork = 0 and EmployeesTBL.IsActive = 1 and  ";

                //" dbo.EmployeesTBL INNER JOIN
                //                       dbo.VicationsTBL ON dbo.EmployeesTBL.EmpID = dbo.VicationsTBL.EmpID
                //           where(dbo.VicationsTBL.VicationTypeID in (2,4,6,7,10) or ( VicationInterval>133))
                //                    and ((EndDate between DATEADD(day,-5, getdate()) and GETDATE() and dbo.VicationsTBL.IsActive=1) or
                //                    (StartedWork = 0 and EmployeesTBL.IsActive = 1 and CurrentLocation =1 and EndDate > GETDATE()))) as Foo ORDER BY VALUE ASC ";

                // MDirMaster.Messages(lblMessage, 10);
                //return;
            }
            else
            {
                //nothing selected
                MDirMaster.Messages(lblMessage, 3);
                return;
            }
            if (!rbVication.Checked)
            {
                Query += " WHERE ";
            }
            if (check)
            {
                Query += Condition + " AND ";
            }
            if (TransType.Length > 2)
            {
                TransType += " AND ";
            }

            if (rbVication.Checked)
            {
                Query += " CurrentLocation =1 ))) as Foo ORDER BY VALUE ASC";
            }
            else if (rbNewEmp.Checked)
            {
                Query += " EmployementStartDate IS NULL AND ResignReasonID IS NULL ) AS Foo ORDER BY VALUE ASC ";
            }
            else
            {
                Query += TransType + " CurrentLocation=1 AND IsActive=1 AND StartedWork=0 ) AS Foo ORDER BY VALUE ASC ";
            }

            cmd.CommandText = queryAR + Query;
            DataTable dt = MDirMaster.GetData(cmd, lblMessage);
            MDirMaster.Pop(dt, ddlNameAR);
            cmd.CommandText = queryEN + Query;
            dt.Clear();
            dt = MDirMaster.GetData(cmd, lblMessage);
            MDirMaster.Pop(dt, ddlNameEN);
            pnlForm.Visible = true;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            int EmpID = Convert.ToInt32(hfEmpID.Value);
            if (EmpID > 0)
            {
                System.Data.DataTable dtBranchDep = MDirMaster.GetBranchDep(EmpID, lblMessage);
                int BranchID = Convert.ToInt32(dtBranchDep.Rows[0]["BranchID"]);
                int DepartmentID = Convert.ToInt32(dtBranchDep.Rows[0]["DepartmentID"]);
                SqlCommand cmdSelect = new SqlCommand(@"SELECT     dbo.BranchsTBL.BranchDescAR, dbo.DepartmentTBL.DepartmentDescAR
                                                             FROM      dbo.EmployeesTempTBL INNER JOIN
                                                                       dbo.BranchsTBL ON dbo.EmployeesTempTBL.BranchID = dbo.BranchsTBL.BranchID INNER JOIN
                                                                       dbo.DepartmentTBL ON dbo.EmployeesTempTBL.DepartmentID = dbo.DepartmentTBL.DepartmentID
                                                             WHERE     (dbo.EmployeesTempTBL.EmpID = @EmpID) AND (dbo.EmployeesTempTBL.CurrentLocation = 1)
                                                             UNION SELECT     dbo.BranchsTBL.BranchDescAR, dbo.DepartmentTBL.DepartmentDescAR
                                                             FROM      dbo.EmployeesTBL INNER JOIN
                                                                       dbo.BranchsTBL ON dbo.EmployeesTBL.BranchID = dbo.BranchsTBL.BranchID INNER JOIN
                                                                       dbo.DepartmentTBL ON dbo.EmployeesTBL.DepartmentID = dbo.DepartmentTBL.DepartmentID
                                                             WHERE     (dbo.EmployeesTBL.EmpID = @EmpID) AND (dbo.EmployeesTBL.CurrentLocation = 1) ");
                cmdSelect.Parameters.AddWithValue("@EmpID", EmpID);
                DataTable dt = MDirMaster.GetData(cmdSelect, lblMessage);
                string Dep = dt.Rows[0]["DepartmentDescAR"].ToString();
                string Branch = dt.Rows[0]["BranchDescAR"].ToString();
                string WorkTable = " EmployeesTBL ";
                if (rbTransfare.Checked)
                {
                    // transfare
                    // update the branch and department in the EmployeesTBL from the EmployeesTempTBL
                    // Set table name for WorkStarted=1 update
                    WorkTable = " EmployeesTBL ";
                    string Query = @"UPDATE EmployeesTBL set DepartmentID = (SELECT DepartmentID FROM dbo.EmployeesTempTBL WHERE  (EmpID = @EmpID AND  [CurrentLocation] = 1)),
	                                        BranchID = (SELECT BranchID FROM dbo.EmployeesTempTBL WHERE  (EmpID = @EmpID AND  [CurrentLocation] = 1)),
                                            SectionID = (SELECT SectionID FROM dbo.EmployeesTempTBL WHERE  (EmpID = @EmpID AND  [CurrentLocation] = 1)),
                                            CurrentLocation=1, LocationStartDate =@StartDate, LastModification= GETDATE ( )
                                      WHERE EmpID=@EmpID and CurrentLocation = 0;
                                     UPDATE EmployeesTempTBL set CurrentLocation = 0
                                      WHERE EmpID=@EmpID and CurrentLocation = 1;";
                    SqlCommand cmd = new SqlCommand(Query);
                    cmd.Parameters.AddWithValue("@EmpID", EmpID);
                    cmd.Parameters.Add("@StartDate", System.Data.SqlDbType.Date);
                    cmd.Parameters["@StartDate"].Value = (txtStartDate.Text);
                    if (!MDirMaster.Execute(cmd, lblMessage, HttpContext.Current.Request.Path))
                    {
                        return;
                    }
                }
                else if (rbNewEmp.Checked)
                {
                    //new employee
                    WorkTable = " EmployeesTBL ";
                    string EmpQuery = " UPDATE " + WorkTable + @" SET EmployementStartDate = @StartDate, MaturityDate =  @StartDate
                                        WHERE EmpID = @EmpID AND CurrentLocation = 1 AND StartedWork = 0 ";
                    SqlCommand cmdEmp = new SqlCommand(EmpQuery);
                    cmdEmp.Parameters.AddWithValue("@EmpID", EmpID);
                    cmdEmp.Parameters.Add("@StartDate", SqlDbType.DateTime);
                    cmdEmp.Parameters["@StartDate"].Value = txtStartDate.Text;
                    if (!MDirMaster.Execute(cmdEmp, lblMessage, HttpContext.Current.Request.Path))
                    {
                        return;
                    }
                }
                else if (rbTempTrans.Checked)
                {
                    //temp transfare
                    WorkTable = " EmployeesTempTBL ";
                    string EmpQuery = " UPDATE " + WorkTable + @" SET LocationStartDate = @StartDate
                                        WHERE EmpID = @EmpID AND CurrentLocation = 1 AND StartedWork = 0 ";
                    SqlCommand cmdEmp = new SqlCommand(EmpQuery);
                    cmdEmp.Parameters.AddWithValue("@EmpID", EmpID);
                    cmdEmp.Parameters.Add("@StartDate", SqlDbType.DateTime);
                    cmdEmp.Parameters["@StartDate"].Value = txtStartDate.Text;
                    if (!MDirMaster.Execute(cmdEmp, lblMessage, HttpContext.Current.Request.Path))
                    {
                        return;
                    }
                }

                else if (rbVication.Checked)
                {
                    //vication
                    //  Set table name for WorkStarted=1 update
                    WorkTable = " EmployeesTBL ";
                    //MDirMaster.Messages(lblMessage, 10);
                    //return;
                }
                else
                {
                    //nothing selected
                    MDirMaster.Messages(lblMessage, 3);
                    return;
                }

                string WorkQuery = " UPDATE " + WorkTable + @" SET StartedWork = 1 
                                     WHERE EmpID = @EmpID AND CurrentLocation = 1 AND StartedWork = 0";
                SqlCommand cmdWork = new SqlCommand(WorkQuery);
                cmdWork.Parameters.AddWithValue("@EmpID", EmpID);
                if (MDirMaster.Execute(cmdWork, lblMessage, HttpContext.Current.Request.Path))
                {
                    if ((rbVication.Checked && !String.IsNullOrEmpty(txtAdminOrderNo.Text)) || (!rbVication.Checked))
                    {
                        string OrderDesc = " باشر في فرع " + Branch + "، قسم " + Dep;
                        if (MDirMaster.AdminOrderAdd(EmpID, BranchID, DepartmentID, OrderDesc, txtAdminOrderNo.Text, txtOrderDate.Text, 5, lblMessage))
                        {
                            ddlSBranch_SelectedIndexChanged(sender, e);
                        }
                        else
                        {
                            MDirMaster.Messages(lblMessage, -1);
                            return;
                        }
                    }
                }
                else
                {
                    MDirMaster.Messages(lblMessage, -1);
                    return;
                }
            }
            else
            {
                MDirMaster.Messages(lblMessage, 3);
                return;
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

        protected void VicationType_CheckedChanged(object sender, EventArgs e)
        {
            gvEmpVications.Visible = false;
            ddlSDep.SelectedIndex = 0;
            ddlSBranch.SelectedIndex = 0;
            ddlSBranch_SelectedIndexChanged(sender, e);
        }
    }
}