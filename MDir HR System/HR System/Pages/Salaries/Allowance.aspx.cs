using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HR_Salaries.Pages.Allowances
{
    public partial class EmpAllowance : System.Web.UI.Page
    {
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
                    GetData();
                }
            }
        }

        public void GetData()
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand(@"SELECT ROW_NUMBER() OVER (ORDER BY ValueID) AS [ت], ValueID, [TitleEN] AS [العنوان (أنكليزي)], [TitleAR] AS [العنوان (عربي)],
                                                    [GlCode] AS [رمز الدليل المحاسبي], [IsActive] AS [فعال]
                            FROM [ValuesTBL]
                            WHERE ParentID =0 --AND IsActive =1");
            dt = MDirMaster.GetData(cmd, lblMessage);
            MDirMaster.AddColumnsToGridView(gvAllowances, dt);
            gvAllowances.DataSource = dt;
            gvAllowances.DataBind();
            gvAllowances.Columns[1].Visible = false;
        }

        protected void gvAllowances_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            int index = e.NewSelectedIndex;

            int ID = Convert.ToInt32(gvAllowances.Rows[index].Cells[2].Text);
            if (ID > 0)
            {
                Session["AllowanceID"] = ID;
                Response.Redirect("~/Pages/Salaries/AllowAdEd.aspx", false);
            }
        }

        protected void gvAllowances_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView gv = sender as GridView;
            gv.PageIndex = e.NewPageIndex;
            gv.SelectedIndex = -1;
            GetData();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Session["AllowanceID"] = 0;
            Response.Redirect("~/Pages/Salaries/AllowAdEd.aspx", false);
        }
    }
}