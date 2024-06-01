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
    public partial class EmployeeNotes : System.Web.UI.Page
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
                    // if (result == 0 || result2 == 0 )
                    //|| UserID != "1143" || UserID != "1016"
                    depID = Session["depID"].ToString();
                    UserID = Session["UserID"].ToString();


                    if (Session["msg"] != null)
                    {
                        int msg = Convert.ToInt32(Session["msg"]);

                        TBIMaster.Messages(lblMessage, msg);
                        Session["msg"] = null;
                    }
                    GetGrid();


                }

                //Session["msg"] = "9";
                //Response.Redirect("~/Pages/Default.aspx");


            }
            lblMessage.Text = "";
        }

        public void GetGrid()
        {
            try
            {
                BranchID = Session["BranchID"].ToString();
                depID = Session["depID"].ToString();
                UserID = Session["UserID"].ToString();
                IsManager = Session["IsManager"].ToString();
                IsCEO = Session["IsCEO"].ToString();
                IsCEOAssist = Session["IsCEOAssist"].ToString();
                EmpID = Session["EmpID"].ToString();
            }
            catch
            {
                TBIMaster.Messages(lblMessage, 0);
                return;
            }

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = @"
  SELECT [EmpID]  as [رقم الموظف] ,[FullName] as [اسم الموظف]
            , isLess6Months as [اقل من 6 اشهر], hasNotice as [يوجد تنبيه],hasWarning as [يوجد انذار], hasOffwithout as [مجاز بدون راتب], hasAbsence as [غياب]
                                   FROM [HR].[dbo].[EmployeeRatingTempTBL]
                                left join hr.dbo.EmpRateDegreeTBL on [HR].[dbo].[EmployeeRatingTempTBL].[rateDegree] = hr.dbo.EmpRateDegreeTBL.degreeID
								where isLess6Months =1 or hasNotice =1 or hasWarning =1 or hasOffwithout =1 or hasAbsence =1";
            DataTable dt1 = new DataTable();
            dt1 = TBIMaster.GetData(cmd, lblMessage);
            GridView1.Columns.Clear();
            TBIMaster.AddColumnsToGridView(GridView1, dt1);
            GridView1.DataSource = dt1;
            GridView1.DataBind();
            if (GridView1.Rows.Count == 0)
            {
                lblMessage.Text = "لاتوجد ملاحظات";
            }



        }

        protected void GridView1_PageIndexChanged(object sender, EventArgs e)
        {
            GetGrid();
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
        }
        public override void VerifyRenderingInServerForm(System.Web.UI.Control control)
        {
            /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
               server control at run time. */
        }
        
        protected void btnExcel_Click(object sender, EventArgs e)
        {
            GetGrid();
            Response.Clear();

            Response.AddHeader("content-disposition", "attachment;filename=Report " + DateTime.Now.ToString("yyyy-MM-dd") + ".xls");
            Response.Charset = "";
            this.EnableViewState = false;
            Response.ContentType = "application/vnd.ms-excel";


            System.IO.StringWriter stringWrite = new System.IO.StringWriter();

            System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
            ////Turn OFF paging and bind the data back to Gridview
            GridView1.AllowPaging = false;
            GridView1.DataBind(); //change method which you are using to bind your gridview

            // Read Style file (css) here and add to response 
            FileInfo fi = new FileInfo(HttpContext.Current.Server.MapPath("~/CSS/Main.css"));
            StringBuilder sb = new StringBuilder();
            StreamReader sr = fi.OpenText();
            while (sr.Peek() >= 0)
            {
                sb.Append(sr.ReadLine());
            }
            sr.Close();

            GridView1.RenderControl(htmlWrite);
            GridView1.HeaderStyle.Font.Bold = true;
            Response.Write("<html dir='rtl'><head><style type='text/css'>" + sb.ToString() + "</style></head><body align='center'>" + stringWrite.ToString() + "</body></html>");
            Response.End();
            ////Turn ON paging and bind the data back to Gridview
            GridView1.AllowPaging = true;
            GridView1.DataBind();
        }
        
    }

        
 
}