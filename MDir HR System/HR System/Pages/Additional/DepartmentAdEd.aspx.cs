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
    public partial class DepartmentAdEd : System.Web.UI.Page
    {
        public static int DepID = 0;
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
                }
            }
            else
            {
                lblMessage.Text = string.Empty;
            }
        }

        public void GetGrid()
        {
            string Query = @"SELECT [DepartmentID], [DepartmentDescAR] AS [أسم القسم (عربي)], [DepartmentDescEN] AS [أسم القسم (أنكليزي)], [IsActive] AS [فعال؟]
                               FROM [HR].[dbo].[DepartmentTBL]
                           ORDER BY [DepartmentDescAR]";
            SqlCommand cmd = new SqlCommand(Query);
            MDirMaster.FillGrid(cmd, gvDepartment, lblMessage);
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@DepartmentDescEN", txtNameEN.Text);
            cmd.Parameters.AddWithValue("@DepartmentDescAR", txtNameAR.Text);
            cmd.Parameters.AddWithValue("@IsActive", chbActive.Checked);
            if (DepID > 0)
            {
                //Edit
                cmd.Parameters.AddWithValue("@DepartmentID", DepID);
                cmd.CommandText = @"UPDATE [HR].[dbo].[DepartmentTBL] SET [DepartmentDescAR] = @DepartmentDescAR, [DepartmentDescEN] = @DepartmentDescEN, [IsActive] = @IsActive
                                     WHERE [DepartmentID] = @DepartmentID";
                MDirMaster.Execute(cmd, lblMessage, HttpContext.Current.Request.Path);
                DepID = 0;
                MDirMaster.ClearControls(pnlControls);
            }
            else
            {
                //Insert
                cmd.CommandText = @" INSERT INTO [HR].[dbo].[DepartmentTBL] ([DepartmentDescAR], [DepartmentDescEN], [IsActive])
                                                                VALUES      (@DepartmentDescAR,  @DepartmentDescEN,  @IsActive) ";
                MDirMaster.Execute(cmd, lblMessage, HttpContext.Current.Request.Path);
                GetGrid();
                MDirMaster.ClearControls(pnlControls);
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            if (DepID > 0)
            {
                DepID = 0;
                MDirMaster.ClearControls(pnlControls);
            }
            else
            {
                Response.Redirect("~/Pages/Default.aspx", false);
            }
        }

        protected void gvBranch_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView gv = sender as GridView;
            gv.PageIndex = e.NewPageIndex;
            gv.SelectedIndex = -1;
            MDirMaster.ClearControls(pnlControls);
            GetGrid();
        }

        protected void gvBranch_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            int index = e.NewSelectedIndex;
            GridView gv = sender as GridView;
            DepID = Convert.ToInt32(gv.Rows[index].Cells[1].Text);
            string Query = @" SELECT [DepartmentDescAR], [DepartmentDescEN], [IsActive]
                                FROM [HR].[dbo].[DepartmentTBL]
                               WHERE [DepartmentID] = @DepartmentID";
            SqlCommand cmd = new SqlCommand(Query);
            cmd.Parameters.AddWithValue("@DepartmentID", DepID);
            DataTable dt = MDirMaster.GetData(cmd, lblMessage);
            txtNameEN.Text = dt.Rows[0]["DepartmentDescEN"].ToString();
            txtNameAR.Text = dt.Rows[0]["DepartmentDescAR"].ToString();
            chbActive.Checked = (bool)dt.Rows[0]["IsActive"];
        }
    }
}