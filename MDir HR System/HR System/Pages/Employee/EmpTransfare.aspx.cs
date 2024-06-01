using HR_Salaries;
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
    public partial class EmpTransfare : System.Web.UI.Page
    {
        //public int EmpID;
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
                    //search
                    MDirMaster.FillCombo("BranchID", "BranchDescAR", "BranchsTBL", ddlSBranch, true, lblMessage);
                    MDirMaster.FillCombo("DepartmentID", "DepartmentDescAR", "DepartmentTBL", ddlSDep, true, lblMessage);
                    MDirMaster.FillCombo("EmpID", "FirstNameAR] + ' ' + [MidNameAR] + ' '+ [LastNameAR", "EmployeesTBL", ddlNameAR, true, lblMessage);
                    MDirMaster.FillCombo("EmpID", "FirstNameEN] + ' ' + [MidNameEN] + ' '+ [LastNameEN", "EmployeesTBL", ddlNameEN, true, lblMessage);
                    //info
                    MDirMaster.FillCombo("BranchID", "BranchDescAR", "BranchsTBL", ddlIBranchs, true, lblMessage);
                    MDirMaster.FillCombo("DepartmentID", "DepartmentDescAR", "DepartmentTBL", ddlIDepartment, true, lblMessage);
                    MDirMaster.FillCombo("SectionID", "SectionDescAR", "SectionTBL", ddlSection, true, lblMessage);

                    GetGrid(0);
                }
            }
        }

        protected void ddlSBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Condition = " IsActive = 1 AND ";
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
                GetGrid(0);
            }
            else
            {
                MDirMaster.FillCombo("EmpID", "FirstNameAR] + ' ' + [MidNameAR] + ' '+ [LastNameAR", "EmployeesTBL", ddlNameAR, true, lblMessage);
                MDirMaster.FillCombo("EmpID", "FirstNameEN] + ' ' + [MidNameEN] + ' '+ [LastNameEN", "EmployeesTBL", ddlNameEN, true, lblMessage);
                GetGrid(0);
            }
        }

        protected void ddlName_SelectedIndexChanged(object sender, EventArgs e)
        {
            pEdit.Enabled = false;
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
                hfEmpID.Value = ddlNameAR.SelectedValue.ToString();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(ddlIBranchs.SelectedValue) > 0 && Convert.ToInt32(ddlIDepartment.SelectedValue) > 0)
            {
                Button btn = sender as Button;
                string id = btn.ID;
                string Query = "", OrderDesc = "";
                int EmpID = Convert.ToInt32(hfEmpID.Value), Type = 0;
                DataTable dtBranchDep = MDirMaster.GetBranchDep(EmpID, lblMessage);
                int BranchID = Convert.ToInt32(dtBranchDep.Rows[0]["BranchID"]);
                int DepartmentID = Convert.ToInt32(dtBranchDep.Rows[0]["DepartmentID"]);
                int SectionID = Convert.ToInt32(dtBranchDep.Rows[0]["SectionID"]);
                string Branch = dtBranchDep.Rows[0]["BranchDescAR"].ToString();
                string Dep = dtBranchDep.Rows[0]["DepartmentDescAR"].ToString();
                string Section = dtBranchDep.Rows[0]["SectionDescAR"].ToString();
                if (id == "btnTransfare")
                {
                    Query = @"INSERT INTO EmployeesTempTBL 
                                    SELECT * FROM EmployeesTBL
                                        WHERE EmpID = @EmpID
                              UPDATE EmployeesTBL set CurrentLocation = 0, TempTransfare = 0, EmailProcessed = 0, IsManager = 0, [IsManagerAssist] = 0, [IsCEO] = 0, [IsCEOAssist] = 0, [IsSectionManager] = 0, [IsActing] = 0 "//, StartedWork=0
                                  + @" WHERE EmpID = @EmpID and CurrentLocation = 1;
                              UPDATE EmployeesTempTBL set DepartmentID = @DepID, BranchID = @BranchID, SectionID = @SectionID, LastModification= GETDATE ( ), TempTransfare = 0, StartedWork=0
                                  WHERE EmpID=@EmpID and CurrentLocation = 1;";
                    Type = 3;
                    OrderDesc = "نقل من فرع " + Branch + " قسم " + Dep + " شعبة " + Section;
                }
                else if (id == "btnTempTran")
                {
                    Query = @"INSERT INTO EmployeesTempTBL 
                                  SELECT * FROM EmployeesTBL
                                      WHERE EmpID=@EmpID
                              UPDATE EmployeesTBL set CurrentLocation = 0, TempTransfare = 1"//, StartedWork=0 
                               + @"  WHERE EmpID=@EmpID and CurrentLocation = 1;
                              UPDATE EmployeesTempTBL set DepartmentID = @DepID, BranchID = @BranchID, SectionID = @SectionID, LastModification= GETDATE ( ), TempTransfare = 1, StartedWork=0 
                                  WHERE EmpID=@EmpID and CurrentLocation = 1;";
                    Type = 7;
                    OrderDesc = "تنسيب من فرع " + Branch + " قسم " + Dep;
                }
                SqlCommand cmd = new SqlCommand(Query);
                cmd.Parameters.AddWithValue("@EmpID", EmpID);
                cmd.Parameters.AddWithValue("@DepID", ddlIDepartment.SelectedValue);
                cmd.Parameters.AddWithValue("@BranchID", ddlIBranchs.SelectedValue);
                cmd.Parameters.AddWithValue("@SectionID", ddlSection.SelectedValue);

                if (MDirMaster.Execute(cmd, lblMessage, HttpContext.Current.Request.Path))
                {
                    MDirMaster.AdminOrderAdd(EmpID, BranchID, DepartmentID, OrderDesc, txtOrderNo.Text, txtOrderDate.Text, Type, lblMessage);
                }
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {

            FillData(getdata(-1));
            pEdit.Enabled = false;
            pSearch.Enabled = true;
        }

        protected void btnGetInfo_Click(object sender, EventArgs e)
        {
            int EmpID = Convert.ToInt32(hfEmpID.Value);
            if (EmpID > 0)
            {
                if (FillData(getdata(EmpID)))
                {
                    pEdit.Enabled = true;
                    pSearch.Enabled = false;
                    GetGrid(EmpID);
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

        private void GetGrid(int EmpID)
        {
            int BranchID = Convert.ToInt32(ddlSBranch.SelectedValue);
            int DepID = Convert.ToInt32(ddlSDep.SelectedValue);
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = @"SELECT        dbo.EmployeesTempTBL.EmpID, dbo.EmployeesTempTBL.FirstNameAR + ' ' + dbo.EmployeesTempTBL.MidNameAR + ' ' + dbo.EmployeesTempTBL.LastNameAR AS الاسم, dbo.BranchsTBL.BranchDescAR AS الفرع, 
                         dbo.DepartmentTBL.DepartmentDescAR AS القسم, 
                         dbo.EmployeesTempTBL.EmployementStartDate AS [تاريخ المباشرة], dbo.EmployeesTempTBL.TempTransfare AS [تنسيب؟]
FROM            dbo.EmployeesTempTBL INNER JOIN
                         dbo.BranchsTBL ON dbo.EmployeesTempTBL.BranchID = dbo.BranchsTBL.BranchID INNER JOIN
                         dbo.DepartmentTBL ON dbo.EmployeesTempTBL.DepartmentID = dbo.DepartmentTBL.DepartmentID
WHERE        ((dbo.EmployeesTempTBL.CurrentLocation = 1 AND dbo.EmployeesTempTBL.TempTransfare = 0)OR(TempTransfare =1  AND  CurrentLocation=1  AND StartedWork=0 ))  AND (dbo.EmployeesTempTBL.IsActive = 1)";
            if (EmpID > 0)
            {
                cmd.CommandText += @" AND (EmpID = @EmpID)";
                cmd.Parameters.AddWithValue("@EmpID", EmpID);
            }
            else
            {
                if (BranchID > 0)
                {
                    cmd.CommandText += @" AND (dbo.BranchsTBL.BranchID = @BranchID)";
                    cmd.Parameters.AddWithValue("@BranchID", BranchID);
                }
                if (DepID > 0)
                {
                    cmd.CommandText += @" AND (dbo.DepartmentTBL.DepartmentID = @DepID)";
                    cmd.Parameters.AddWithValue("@DepID", DepID);
                }
            }
            MDirMaster.FillGrid(cmd, gvTransformation, lblMessage);
        }

        public DataTable getdata(int ID)
        {
            DataTable dt = new DataTable();
            if (ID > 0)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"SELECT       EmpID, BranchID, DepartmentID, SectionID
                                        FROM            dbo.EmployeesTBL
                                        WHERE        (EmpID = @EmpID AND  [CurrentLocation] = 1)
                                    UNION SELECT  EmpID, BranchID, DepartmentID, SectionID
                                        FROM            dbo.EmployeesTEMPTBL
                                        WHERE        (EmpID = @EmpID AND  [CurrentLocation] = 1)";
                cmd.Parameters.AddWithValue("@EmpID", ID);
                dt = MDirMaster.GetData(cmd, lblMessage);
            }
            return dt;
        }

        public bool FillData(DataTable dt)
        {
            bool status = false;
            try
            {
                if (dt.Rows.Count == 1)
                {
                    int EmpID = (int)dt.Rows[0]["EmpID"];

                    ddlIBranchs.SelectedValue = dt.Rows[0]["BranchID"].ToString();
                    ddlIDepartment.SelectedValue = dt.Rows[0]["DepartmentID"].ToString();
                    ddlSection.SelectedValue = dt.Rows[0]["SectionID"].ToString();
                }
                else
                {
                    ddlIBranchs.SelectedValue = "0".ToString();
                    ddlIDepartment.SelectedValue = "0".ToString();
                    ddlSection.SelectedValue = "0".ToString();
                }
                status = true;

            }
            catch (Exception ex)
            {
                MDirMaster.Messages(lblMessage, ex.Message);
                status = false;
            }
            return status;
        }

        protected void gvTransformation_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView gv = sender as GridView;
            gv.PageIndex = e.NewPageIndex;
            gv.SelectedIndex = -1;
            ddlSBranch_SelectedIndexChanged(null, null);
        }

        protected void gvTransformation_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}