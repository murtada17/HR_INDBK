using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Services;
using System.Windows.Forms;
using System.IO;
using System.Text;
using System.Web.UI.HtmlControls;

namespace HR_Salaries.Pages.Employee
{
    public partial class EmpsNotRated : System.Web.UI.Page
    {
        string BranchID = "0", x = "0", y = "0";
        string depID = "0";
        string UserID = "0";
        string IsManager = "0";
        string IsCEO = "0";
        string IsCEOAssist = "0";
        string EmpID = "0";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                string url = HttpContext.Current.Request.Path;
                if (!TBIMaster.HasPrivilage(url, lblMessage))
                {
                    Session["msg"] = "9";
                    Response.Redirect("~/Pages/Default.aspx");
                }
                else
                {
                    depID = Session["depID"].ToString();
                    UserID = Session["UserID"].ToString();
                    

                    if (Session["msg"] != null)
                    {
                        int msg = Convert.ToInt32(Session["msg"]);

                        TBIMaster.Messages(lblMessage, msg);
                        Session["msg"] = null;
                    }
                    if (depID == "41" || UserID == "1143")
                    {//hr
                        
                        divName.Attributes["style"] = "display: inlineblock";
                    }

                }
            }
            lblMessage.Text = "";
        }
        protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView2.PageIndex = e.NewPageIndex;
        }
        protected void GridView2_PageIndexChanged(object sender, EventArgs e)
        {
            GetNotGrid();
        }

        private void GetNotGrid()
        {
            if (chk.Checked)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"  SELECT HR.dbo.BranchsTBL.BranchDescAR as [الفرع], HR.dbo.DepartmentTBL.DepartmentDescAR as [القسم], [FullName] as [اسم الموظف] FROM [HR].[dbo].[EmployeeRatingTempTBL]
	  LEFT JOIN HR.dbo.BranchsTBL ON [HR].[dbo].[EmployeeRatingTempTBL].branchID = HR.dbo.BranchsTBL.BranchID 
	  LEFT JOIN HR.dbo.DepartmentTBL ON [HR].[dbo].[EmployeeRatingTempTBL].departmentID = HR.dbo.DepartmentTBL.DepartmentID
	   where rateDegree=0  order by HR.dbo.EmployeeRatingTempTBL.BranchID, HR.dbo.EmployeeRatingTempTBL.DepartmentID";
                DataTable dt1 = new DataTable();
                dt1 = TBIMaster.GetData(cmd, lblMessage);
                GridView2.Columns.Clear();
                TBIMaster.AddColumnsToGridView(GridView2, dt1);
                GridView2.DataSource = dt1;
                GridView2.DataBind();
                if (GridView2.Rows.Count == 0)
                {
                    lblMessage.Text = "تم تقييم جميع الموظفين";
                }
            }
            else
            {

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"SELECT HR.dbo.BranchsTBL.BranchDescAR as [الفرع], HR.dbo.DepartmentTBL.DepartmentDescAR as [القسم], [FullName] as [اسم الموظف],[sum] as [مجموع التقييم 100],R.degreeDesc as [درجة التقييم]
       ,Ceo.degreeDesc as [درجة التقييم],[responsibility] as [القدرة على تنفيذ الاعمال وتحمل المسؤولية 30],[confidentiality] as [المحافظة على سرية المعلومات 20],[instructions] as [الالتزام بالتوجيهات والتعليمات 15]
      ,[seriousness] as [الاهتمام والجدية في العمل 15],[relationships] as [العلاقة مع زملائه ورئيسه المباشر 10],[commitment] as [الالتزام بالدوام الرسمي 10]  
        , HR.dbo.EmployeesVW.Name	as [اسم المدير],[submitDate] as [تاريخ الادخال] FROM [HR].[dbo].[EmpRatingTBL]
	  LEFT JOIN HR.dbo.BranchsTBL ON [HR].[dbo].[EmpRatingTBL].branchID = HR.dbo.BranchsTBL.BranchID 
	  LEFT JOIN HR.dbo.DepartmentTBL ON [HR].[dbo].[EmpRatingTBL].departmentID = HR.dbo.DepartmentTBL.DepartmentID
	  LEFT JOIN [HR].[dbo].[EmpRateDegreeTBL] as R ON [HR].[dbo].[EmpRatingTBL].rateDegree = R.degreeID
	  LEFT JOIN [HR].[dbo].EmployeesVW on [HR].[dbo].[EmpRatingTBL].managerEmpID = [HR].[dbo].EmployeesVW.EmpID
      LEFT JOIN [HR].[dbo].[EmpRateDegreeTBL] as Ceo ON [HR].[dbo].[EmpRatingTBL].rateDegreeCeoID = [Ceo].degreeID  where DATEDIFF(day, submitdate    , GETDATE()) <= 30 order by HR.dbo.EmpRatingTBL.branchID, HR.dbo.EmpRatingTBL.departmentID";
                DataTable dt1 = new DataTable();
                dt1 = TBIMaster.GetData(cmd, lblMessage);
                GridView2.Columns.Clear();
                TBIMaster.AddColumnsToGridView(GridView2, dt1);
                GridView2.DataSource = dt1;
                GridView2.DataBind();
                if (GridView2.Rows.Count == 0)
                {
                    lblMessage.Text = "لم يتم العثور على نتائج";
                }
            }
        }

        protected void chkNot_CheckedChanged(object sender, EventArgs e)
        {

            GetNotGrid();

        }
        public override void VerifyRenderingInServerForm(System.Web.UI.Control control)
        {
            /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
               server control at run time. */
        }
        protected void btnNotRated_Click(object sender, EventArgs e)
        {
            GetNotGrid();
            Response.Clear();

            Response.AddHeader("content-disposition", "attachment;filename=Report " + DateTime.Now.ToString("yyyy-MM-dd") + ".xls");
            Response.Charset = "";
            this.EnableViewState = false;
            Response.ContentType = "application/vnd.ms-excel";


            System.IO.StringWriter stringWrite = new System.IO.StringWriter();

            System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
            ////Turn OFF paging and bind the data back to Gridview
            GridView2.AllowPaging = false;
            GridView2.DataBind(); //change method which you are using to bind your gridview

            // Read Style file (css) here and add to response 
            FileInfo fi = new FileInfo(HttpContext.Current.Server.MapPath("~/CSS/Main.css"));
            StringBuilder sb = new StringBuilder();
            StreamReader sr = fi.OpenText();
            while (sr.Peek() >= 0)
            {
                sb.Append(sr.ReadLine());
            }
            sr.Close();

            GridView2.RenderControl(htmlWrite);
            GridView2.HeaderStyle.Font.Bold = true;
            Response.Write("<html dir='rtl'><head><style type='text/css'>" + sb.ToString() + "</style></head><body align='center'>" + stringWrite.ToString() + "</body></html>");
            Response.End();
            ////Turn ON paging and bind the data back to Gridview
            GridView2.AllowPaging = true;
            GridView2.DataBind();
        }

    }
}