using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace HR_Salaries.Pages.ExtNo
{
    public partial class ExtNo : System.Web.UI.Page
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
                    //search
                    MDirMaster.FillCombo("BranchID", "BranchDescAR", "BranchsTBL", ddlSBranch, true, lblMessage);
                    MDirMaster.FillCombo("DepartmentID", "DepartmentDescAR", "DepartmentTBL", ddlSDep, true, lblMessage);
                    MDirMaster.FillCombo("SectionID", "SectionDescAR", "SectionTBL", ddlSection, true, lblMessage);
                    MDirMaster.FillCombo("EmpID", "FirstNameAR] + ' ' + [MidNameAR] + ' '+ [LastNameAR", "EmployeesTBL", ddlNameAR, true, lblMessage);
                    MDirMaster.FillCombo("EmpID", "FirstNameEN] + ' ' + [MidNameEN] + ' '+ [LastNameEN", "EmployeesTBL", ddlNameEN, true, lblMessage);

                }
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/Default.aspx");
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand();
            string Query;
            cmd.Parameters.Add("@ExtNo", SqlDbType.NVarChar, 4);
            cmd.Parameters.Add("@ExtID", SqlDbType.Int);
            cmd.Parameters.AddWithValue("@BranchID", ddlSBranch.SelectedValue);
            cmd.Parameters.AddWithValue("@DepID", ddlSDep.SelectedValue);
            cmd.Parameters.AddWithValue("@SectionID", ddlSection.SelectedValue);
            if (txtExtNo.Text != string.Empty)
            {

                if (Convert.ToInt32(hfExtID.Value) > 0)
                {
                    //EDIT
                    Query = @"UPDATE [dbo].[ExtTBL]
                                SET  [ExtNo] = @ExtNo, [BranchID] = @BranchID, [DepID] = @DepID, SectionID = @SectionID
                              WHERE  [ExtID] = @ExtID";
                    cmd.Parameters["@ExtID"].Value = hfExtID.Value;
                }
                else
                {
                    //NEW
                    Query = @"INSERT INTO [dbo].[ExtTBL]
                                          ([ExtNo], [BranchID], [DepID], [SectionID])
                                   VALUES (@ExtNo, @BranchID, @DepID, @SectionID)";
                    cmd.Parameters["@ExtID"].Value = 0;
                }
                cmd.CommandText = Query;
                cmd.Parameters["@ExtNo"].Value = txtExtNo.Text;
                if (MDirMaster.Execute(cmd, lblMessage, HttpContext.Current.Request.Path))
                {
                    txtExtNo.Text = string.Empty;
                    //
                }
            }
            if (txtOtherExtNo.Text != string.Empty)
            {

                if (Convert.ToInt32(hfOtherExtID.Value) > 0)
                {
                    //EDIT
                    Query = @"UPDATE [dbo].[ExtTBL]
                                SET  [ExtNo] = @ExtNo, [BranchID] = @BranchID, [DepID] = @DepID, SectionID = @SectionID
                              WHERE  [ExtID] = @ExtID";
                    cmd.Parameters["@ExtID"].Value = hfOtherExtID.Value;
                }
                else
                {
                    //NEW
                    Query = @"INSERT INTO [dbo].[ExtTBL]
                                          ([ExtNo], [BranchID], [DepID], [SectionID])
                                   VALUES (@ExtNo, @BranchID, @DepID, @SectionID)";
                }
                cmd.Parameters["@ExtNo"].Value = txtOtherExtNo.Text;
                cmd.CommandText = Query;
                if (MDirMaster.Execute(cmd, lblMessage, HttpContext.Current.Request.Path))
                {
                    txtOtherExtNo.Text = string.Empty;
                    //
                }
            }
            ddlNameAR.SelectedValue = "0";
        }

        protected void ddlName_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddl = sender as DropDownList;
            if (ddl != null)
            {
                string SenderID = ddl.SelectedValue;
                hfEmpID.Value = ddlNameEN.SelectedValue = ddlNameAR.SelectedValue = SenderID;
                DataTable dt = MDirMaster.GetBranchDep(Convert.ToInt32(SenderID), lblMessage);
                ddlSBranch.SelectedValue = dt.Rows[0]["BranchID"].ToString();
                ddlSDep.SelectedValue = dt.Rows[0]["DepartmentID"].ToString();
                ddlSection.SelectedValue = dt.Rows[0]["SectionID"].ToString();
                txtExtNo.Text = string.Empty;
                txtOtherExtNo.Text = string.Empty;
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"SELECT [ExtNo], [ExtID]
                                    FROM   [dbo].[ExtTBL]
                                    WHERE  [BranchID]= @BranchID AND [DepID]= @DepID AND [SectionID] =@SectionID";
                cmd.Parameters.AddWithValue("@BranchID", ddlSBranch.SelectedValue);
                cmd.Parameters.AddWithValue("@DepID", ddlSDep.SelectedValue);
                cmd.Parameters.AddWithValue("@SectionID", ddlSection.SelectedValue);
                DataTable dt2 = MDirMaster.GetData(cmd, lblMessage);
                if (dt2.Rows.Count > 0)
                {
                    txtExtNo.Text = dt2.Rows[0]["ExtNo"].ToString();
                    hfExtID.Value = dt2.Rows[0]["ExtID"].ToString();
                }
                if (dt2.Rows.Count == 2)
                {
                    txtOtherExtNo.Text = dt2.Rows[1]["ExtNo"].ToString();
                    hfOtherExtID.Value = dt2.Rows[1]["ExtID"].ToString();
                    //
                }
            }
        }

        protected void ddlSBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Condition = "";
            hfExtID.Value = hfOtherExtID.Value = "0";
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
    }
}