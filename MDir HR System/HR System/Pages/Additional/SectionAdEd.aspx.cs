using HR_Salaries;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HR_Salaries.Pages.Additional
{
    public partial class SectionAdEd : System.Web.UI.Page
    {

        public static int SecID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
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
                    GetGrid();
                    MDirMaster.FillCombo("DepartmentID", "DepartmentDescAR", "DepartmentTBL", ddlDepartment, true, lblMessage);
                }
            }
            else
            {
                lblMessage.Text = string.Empty;
            }
        }

        public void GetGrid()
        {
            string Query = @"SELECT     TOP (100) PERCENT dbo.SectionTBL.SectionID, dbo.DepartmentTBL.DepartmentDescAR AS [القسم (عربي)], dbo.DepartmentTBL.DepartmentDescEN AS [القسم (أنكليزي)], 
                                        dbo.SectionTBL.SectionDescAR AS [الأسم (عربي)], dbo.SectionTBL.SectionDescEN AS [الأسم (أنكليزي)], dbo.SectionTBL.IsActive AS [فعال؟]
                            FROM        dbo.SectionTBL INNER JOIN
                                        dbo.DepartmentTBL ON dbo.SectionTBL.DepartmentID = dbo.DepartmentTBL.DepartmentID
                            ORDER BY    [القسم (عربي)], [الأسم (عربي)]";
            SqlCommand cmd = new SqlCommand(Query);
            MDirMaster.FillGrid(cmd, gvSection, lblMessage);
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@DepartmentID", ddlDepartment.SelectedValue);
            cmd.Parameters.AddWithValue("@SectionDescEN", txtNameEN.Text);
            cmd.Parameters.AddWithValue("@SectionDescAR", txtNameAR.Text);
            cmd.Parameters.AddWithValue("@IsActive", chbActive.Checked);
            if (SecID > 0)
            {
                //Edit
                cmd.Parameters.AddWithValue("@SectionID", SecID);
                cmd.CommandText = @"UPDATE [HR].[dbo].[SectionTBL] SET [DepartmentID] = @DepartmentID, [SectionDescAR] = @SectionDescAR, [SectionDescEN] = @SectionDescEN, [IsActive] = @IsActive
                                     WHERE [SectionID] = @SectionID";
                MDirMaster.Execute(cmd, lblMessage, HttpContext.Current.Request.Path);
                SecID = 0;
                MDirMaster.ClearControls(pnlControls);
            }
            else
            {
                //Insert
                cmd.CommandText = @" INSERT INTO [HR].[dbo].[SectionTBL] ([DepartmentID], [SectionDescAR], [SectionDescEN], [IsActive])
                                                                VALUES   ( @DepartmentID,  @SectionDescAR,  @SectionDescEN,  @IsActive) ";
                MDirMaster.Execute(cmd, lblMessage, HttpContext.Current.Request.Path);
                GetGrid();
                MDirMaster.ClearControls(pnlControls);
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            if (SecID > 0)
            {
                SecID = 0;
                MDirMaster.ClearControls(pnlControls);
            }
            else
            {
                Response.Redirect("~/Pages/Default.aspx", false);
            }
        }

        protected void gvSection_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView gv = sender as GridView;
            gv.PageIndex = e.NewPageIndex;
            gv.SelectedIndex = -1;
            MDirMaster.ClearControls(pnlControls);
            GetGrid();
        }

        protected void gvSection_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            int index = e.NewSelectedIndex;
            GridView gv = sender as GridView;
            SecID = Convert.ToInt32(gv.Rows[index].Cells[1].Text);
            string Query = @" SELECT [DepartmentID], [SectionDescAR], [SectionDescEN], [IsActive]
                                FROM [HR].[dbo].[SectionTBL]
                               WHERE [SectionID] = @SectionID";
            SqlCommand cmd = new SqlCommand(Query);
            cmd.Parameters.AddWithValue("@SectionID", SecID);
            DataTable dt = MDirMaster.GetData(cmd, lblMessage);
            ddlDepartment.SelectedValue = dt.Rows[0]["DepartmentID"].ToString();
            txtNameEN.Text = dt.Rows[0]["SectionDescEN"].ToString();
            txtNameAR.Text = dt.Rows[0]["SectionDescAR"].ToString();
            chbActive.Checked = (bool)dt.Rows[0]["IsActive"];
        }
    }
}