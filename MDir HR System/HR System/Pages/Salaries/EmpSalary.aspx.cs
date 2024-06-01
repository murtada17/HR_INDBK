using System;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI.WebControls;

namespace HR_Salaries.Pages.Allowances
{
    public partial class Allowances : System.Web.UI.Page
    {
        //public static int EmpID = 0, EmpD_AID = 0, ValueID = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            lblMessage.Text = string.Empty;
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
                    MDirMaster.FillCombo("EmpID", "FirstNameAR] + ' ' + [MidNameAR] + ' '+ [LastNameAR", "EmployeesTBL", ddlNameAR, lblMessage);
                    MDirMaster.FillCombo("EmpID", "FirstNameEN] + ' ' + [MidNameEN] + ' '+ [LastNameEN", "EmployeesTBL", ddlNameEN, lblMessage);
                    MDirMaster.FillCombo("ValueID", "TitleAR", "ValuesTBL", ddlValues, "(IsActive = 1) AND (ParentID = 0)", lblMessage);
                }
            }
        }

        public bool GetData(int EmpID)
        {
            bool result = false;

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = @"SELECT        BasicSalary, OldBasicSalary, [IsSuposeNoWork]
                            FROM            dbo.EmployeesTBL
                            WHERE        (EmpID = @EmpID)";
            cmd.Parameters.AddWithValue("@EmpID", EmpID);
            DataTable dt = MDirMaster.GetData(cmd, lblMessage);
            if (dt.Rows.Count == 1)
            {
                txtBasicSalary.Text = dt.Rows[0]["BasicSalary"].ToString();
                txtOldBasicSalary.Text = dt.Rows[0]["OldBasicSalary"].ToString();
                chbSpouseNoWork.Checked = Convert.ToBoolean(dt.Rows[0]["IsSuposeNoWork"]);
                GetGrid();
                GetAllowances();
                result = true;
            }
            else
            {
                MDirMaster.Messages(lblMessage, 0);
            }
            return result;
        }

        public void GetGrid()
        {
            int EmpID = Convert.ToInt32(ddlNameAR.SelectedValue);
            SqlCommand cmd = new SqlCommand(@"SELECT        dbo.EmpD_ATBL.EmpD_AID, dbo.ValuesTBL.TitleAR AS [نوع المخصص], ValuesTBL_1.TitleAR AS المخصص, ValuesTBL_1.Value AS [النسبة او المبلغ], 
                                         ValuesTBL_1.IsPercentage AS [نسبة؟], dbo.EmpD_ATBL.IsActive
                        FROM            dbo.EmployeesTBL INNER JOIN
                                        dbo.EmpD_ATBL ON dbo.EmployeesTBL.EmpID = dbo.EmpD_ATBL.EmpID LEFT OUTER JOIN
                                        dbo.ValuesTBL INNER JOIN
                                        dbo.ValuesTBL AS ValuesTBL_1 ON dbo.ValuesTBL.ValueID = ValuesTBL_1.ParentID ON dbo.EmpD_ATBL.ValueID = ValuesTBL_1.ValueID
                        WHERE           dbo.EmployeesTBL.EmpID= @EmpID
                        ORDER BY        dbo.EmpD_ATBL.IsActive DESC");
            cmd.Parameters.AddWithValue("@EmpID", EmpID);
            MDirMaster.FillGrid(cmd, gvValues, lblMessage);
        }

        public void GetList(int AllowanceID)
        {
            string str = @"SELECT        ValueID AS ID, TitleAR AS VALUE
                    FROM            dbo.ValuesTBL
                    WHERE        (IsActive = 1) AND (ParentID = @AllowanceID)";
            SqlCommand cmd = new SqlCommand(str);
            cmd.Parameters.AddWithValue("@AllowanceID", AllowanceID);
            DataTable dt = MDirMaster.GetData(cmd, lblMessage);
            MDirMaster.Pop(dt, chblAllowance);
        }

        public void GetAllowances()
        {
            string str = @"SELECT '0' AS [ID], N' يرجى الأختيار' AS [VALUE] FROM dbo.ValuesTBL UNION SELECT        ValueID AS ID, TitleAR AS VALUE
                            FROM            dbo.ValuesTBL
                            WHERE        (IsActive = 1) AND (ParentID = 0)";
            SqlCommand cmd = new SqlCommand(str);
            DataTable dt = MDirMaster.GetData(cmd, lblMessage);
            MDirMaster.Pop(dt, ddlValues);

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

        protected void ddlName_SelectedIndexChanged(object sender, EventArgs e)
        {
            pnlData.Enabled = false;

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
                //EmpID = Convert.ToInt32(ddlNameAR.SelectedValue);
            }
        }

        protected void ddlValues_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(ddlValues.SelectedValue) > 0)
            {
                // ValueID = 0;
                GetList(Convert.ToInt32(ddlValues.SelectedValue));
                // if (ValueID > 0)
                {
                    //    chblAllowance.SelectedValue = ValueID.ToString();
                }
            }
        }

        protected void btnGetInfo_Click(object sender, EventArgs e)
        {
            int EmpID = Convert.ToInt32(ddlNameAR.SelectedValue);
            if (EmpID > 0)
            {
                if (GetData(EmpID))
                {
                    pnlData.Enabled = true;
                    pSearch.Enabled = false;
                }
            }
            else
            {
                MDirMaster.Messages(lblMessage, 3);
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            int EmpID = Convert.ToInt32(ddlNameAR.SelectedValue);
            if (EmpID > 0)
            {
                lblMessage.Text = "";
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "UPDATE EmployeesTBL SET [OldBasicSalary] = BasicSalary, BasicSalary = @BasicSalary, IsSuposeNoWork = @IsSuposeNoWork WHERE EmpID= @EmpID";
                cmd.Parameters.AddWithValue("@BasicSalary", txtBasicSalary.Text);
                cmd.Parameters.AddWithValue("@EmpID", EmpID);
                cmd.Parameters.AddWithValue("@IsSuposeNoWork", chbSpouseNoWork.Checked);
                if (MDirMaster.Execute(cmd, lblMessage, HttpContext.Current.Request.Path))
                {
                    string Message = lblMessage.Text;
                    cmd.Dispose();
                    try
                    {
                        cmd.CommandText = @"";


                        pnlData.Enabled = false;
                        pSearch.Enabled = true;
                    }
                    catch (Exception ex)
                    {
                        lblMessage.Text = ex.Message;
                    }
                }
                else
                {
                    MDirMaster.Messages(lblMessage, 0);
                }
            }
            else
            {
                MDirMaster.Messages(lblMessage, 0);
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            pnlData.Enabled = false;
            pSearch.Enabled = true;
        }

        protected void gvValues_RowEditing(object sender, GridViewEditEventArgs e)
        {
            int index = e.NewEditIndex;

            int EmpD_AID = Convert.ToInt32(gvValues.Rows[index].Cells[1].Text);
            string query = @"SELECT        dbo.EmpD_ATBL.EmpD_AID, ValuesTBL_1.ValueID, ValuesTBL_1.ParentID
                            FROM            dbo.EmpD_ATBL LEFT OUTER JOIN
                                            dbo.ValuesTBL AS ValuesTBL_1 ON dbo.EmpD_ATBL.ValueID = ValuesTBL_1.ValueID
                            WHERE        (dbo.EmpD_ATBL.EmpD_AID = @EmpD_AID)";
            SqlCommand cmd = new SqlCommand(query);
            cmd.Parameters.AddWithValue("@EmpD_AID", EmpD_AID);
            DataTable dt = MDirMaster.GetData(cmd, lblMessage);
            // ValueID = Convert.ToInt32(dt.Rows[0][1]);
            ddlValues.SelectedValue = dt.Rows[0][2].ToString();
            ddlValues_SelectedIndexChanged(sender, e);
        }

        protected void gvValues_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int index = e.RowIndex;
            int EmpD_AID = Convert.ToInt32(gvValues.Rows[index].Cells[1].Text);
            SqlCommand cmd = new SqlCommand("UPDATE EmpD_ATBL SET IsActive = 0 WHERE (EmpD_AID = @EmpD_AID)");
            cmd.Parameters.AddWithValue("@EmpD_AID", EmpD_AID);
            MDirMaster.Execute(cmd, lblMessage, HttpContext.Current.Request.Path);
            GetGrid();
        }

        protected void btnDeduction_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"SpecialDeduction ";
                cmd.Parameters.AddWithValue("@EmpID", ddlNameAR.SelectedValue);
                cmd.Parameters.AddWithValue("@Amount", txtOtherDeduction.Text);
                cmd.CommandType = CommandType.StoredProcedure;
                MDirMaster.Execute(cmd, lblMessage, HttpContext.Current.Request.Path);
                GetGrid();
            }
            catch
            {
                lblMessage.Text = "الرجاء التأكد من ملىء جميع الحقول";
            }
        }

        protected void btnAddAllwoance_Click(object sender, EventArgs e)
        {
            try
            {
                int EmpID = Convert.ToInt32(ddlNameAR.SelectedValue);
                int ValueID = Convert.ToInt32(chblAllowance.SelectedValue);
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"INSERT INTO EmpD_ATBL (EmpID, ValueID, Date, IsActive)
                                            VALUES    (@EmpID, @ValueID, GETDATE(), 1)";
                cmd.Parameters.AddWithValue("@EmpID", EmpID);
                cmd.Parameters.AddWithValue("@ValueID", ValueID);
                MDirMaster.Execute(cmd, lblMessage, HttpContext.Current.Request.Path);
                GetGrid();
            }
            catch
            {
                lblMessage.Text = "الرجاء التأكد من ملىء جميع الحقول";
            }

        }

        protected void gvValues_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {

            int index = e.NewSelectedIndex;

            int EmpD_AID = Convert.ToInt32(gvValues.Rows[index].Cells[1].Text);
            string query = @"SELECT        dbo.EmpD_ATBL.EmpD_AID, ValuesTBL_1.ValueID, ValuesTBL_1.ParentID
                            FROM            dbo.EmpD_ATBL LEFT OUTER JOIN
                                            dbo.ValuesTBL AS ValuesTBL_1 ON dbo.EmpD_ATBL.ValueID = ValuesTBL_1.ValueID
                            WHERE        (dbo.EmpD_ATBL.EmpD_AID = @EmpD_AID)";
            SqlCommand cmd = new SqlCommand(query);
            cmd.Parameters.AddWithValue("@EmpD_AID", EmpD_AID);
            DataTable dt = MDirMaster.GetData(cmd, lblMessage);
            //ValueID = Convert.ToInt32(dt.Rows[0][1]);
            ddlValues.SelectedValue = dt.Rows[0][2].ToString();
            ddlValues_SelectedIndexChanged(sender, e);
        }

    }
}