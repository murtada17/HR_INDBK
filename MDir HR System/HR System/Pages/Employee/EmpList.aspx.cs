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
    public partial class HREmpRating : System.Web.UI.Page
    {
        string BranchID = "0";
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

                    TBIMaster.FillCombo("EmpID", "FullName", "EmpCurrentLocationVW", ddlRateManager, "IsManager = 1 or IsCEO=1 or IsCEOAssist=1", lblMessage);
                    TBIMaster.FillCombo("RateTypeID", "RateType", "RateTypeTBL", ddlRateType, lblMessage);
                   
                 
                }


            }
            lblMessage.Text = "";
        }
        public string condAND(string cond)
        {
            if (cond.Length > 2)
            {
                cond += " AND ";
            }
            return cond;
        }

        public void GetGrid()
        {
            try
            {
                //BranchID = Session["BranchID"].ToString();
                //depID = Session["depID"].ToString();
                //UserID = Session["UserID"].ToString();
                //IsManager = Session["IsManager"].ToString();
                //IsCEO = Session["IsCEO"].ToString();
                //IsCEOAssist = Session["IsCEOAssist"].ToString();
                //EmpID = Session["EmpID"].ToString();
            }
            catch
            {
                TBIMaster.Messages(lblMessage, 0);
                return;
            }
            SqlCommand cmdCheck = new SqlCommand(@"SELECT        dbo.EmpCurrentLocationVW.BranchID, dbo.EmpCurrentLocationVW.DepartmentID, [HR].[dbo].[EmpCurrentLocationVW].IsManager, [HR].[dbo].[EmpCurrentLocationVW].IsCEO , [HR].[dbo].[EmpCurrentLocationVW].IsCEOAssist,dbo.EmpCurrentLocationVW.EmpID
                    FROM   [HR].[dbo].[EmpCurrentLocationVW] INNER JOIN
                         dbo.UsersVW ON dbo.EmpCurrentLocationVW.EmpID = dbo.UsersVW.EmpID 
                    WHERE  [HR].[dbo].[EmpCurrentLocationVW].EmpID = @EmpID and (dbo.UsersVW.ApplicationID = 1)");
            cmdCheck.Parameters.AddWithValue("@EmpID", ddlRateManager.SelectedValue);

            DataTable dt = new DataTable();

            dt = TBIMaster.GetData(cmdCheck, lblMessage);

            BranchID = dt.Rows[0]["BranchID"].ToString();
            IsManager = dt.Rows[0]["IsManager"].ToString();
            depID = dt.Rows[0]["DepartmentID"].ToString();
            IsCEO = dt.Rows[0]["IsCEO"].ToString();
            IsCEOAssist = dt.Rows[0]["IsCEOAssist"].ToString();
            EmpID = dt.Rows[0]["EmpID"].ToString();

            if (dt.Rows.Count <= 0)
            {

            }
            else
            {
                if (ddlRateType.SelectedValue == "1")
                {

                    string cond = "";
                    string CmdText = @"SELECT [EmpID]  as [رقم الموظف] ,[FullName] as [اسم الموظف], [rateNotes] as [ملاحظات],  hr.dbo.EmpRateDegreeTBL.degreeDesc as[درجة التقييم]
            , isLess6Months as [اقل من 6 اشهر], hasNotice as [يوجد تنبيه],hasWarning as [يوجد انذار], hasOffwithout as [مجاز بدون راتب], hasAbsence as [غياب]
                                   FROM [HR].[dbo].[EmployeeRatingTempTBL]
                                left join hr.dbo.EmpRateDegreeTBL on [HR].[dbo].[EmployeeRatingTempTBL].[rateDegree] = hr.dbo.EmpRateDegreeTBL.degreeID";
                    SqlCommand cmd = new SqlCommand();

                    if (BranchID == "1" & IsManager == "True" & depID != "69")
                    {
                        cond = condAND(cond);
                        cond += " DepartmentID = @depID and IsManager = 0";
                        cmd.Parameters.AddWithValue("@depID", depID);


                    }

                    else if ((IsCEO == "True") || (depID == "69" & IsManager == "True"))
                    {//ceo for branches manager and related deps
                        cond = condAND(cond);
                        cond += @" DepartmentID in(69, 53)  and EmpID <> 2598 union 
select [EmpID]  as [رقم الموظف] ,[FullName] as [اسم الموظف], '' as [ملاحظات],hr.dbo.EmpRateDegreeTBL.degreeDesc as[درجة التقييم]
, isLess6Months as [اقل من 6 اشهر], hasNotice as [يوجد تنبيه],hasWarning as [يوجد انذار], hasOffwithout as [مجاز بدون راتب], hasAbsence as [غياب]
FROM [HR].[dbo].[EmployeeRatingTempTBL]
left join hr.dbo.EmpRateDegreeTBL on [HR].[dbo].[EmployeeRatingTempTBL].[rateDegree] = hr.dbo.EmpRateDegreeTBL.degreeID
where isactive = 1  and IsManager=1 and EmpID <> @EmpID 
and DepartmentID in (select [DepartmentID] from [HR].[dbo].[DepartmentTBL] where CEOAssetID = 2598 ) 
union select [EmpID]  as [رقم الموظف] ,[FullName] as [اسم الموظف],'' as [ملاحظات],hr.dbo.EmpRateDegreeTBL.degreeDesc as[درجة التقييم]
, isLess6Months as [اقل من 6 اشهر], hasNotice as [يوجد تنبيه],hasWarning as [يوجد انذار], hasOffwithout as [مجاز بدون راتب], hasAbsence as [غياب]
FROM [HR].[dbo].[EmployeeRatingTempTBL] 
left join hr.dbo.EmpRateDegreeTBL on [HR].[dbo].[EmployeeRatingTempTBL].[rateDegree] = hr.dbo.EmpRateDegreeTBL.degreeID
where   isactive = 1 and IsCEOAssist = 1 ";
                        cmd.Parameters.AddWithValue("@EmpID", EmpID);

                    }
                    else if (IsCEOAssist == "True")
                    {//ceo assis for related depts
                        cond = condAND(cond);
                        cond += @" branchID = 1 and DepartmentID in
(select [DepartmentID] from [HR].[dbo].[DepartmentTBL] where CEOAssetID = @EmpID and isManager = 1) 
union select [EmpID]  as [رقم الموظف] ,[FullName] as [اسم الموظف], '' as [ملاحظات],hr.dbo.EmpRateDegreeTBL.degreeDesc as[درجة التقييم]
, isLess6Months as [اقل من 6 اشهر], hasNotice as [يوجد تنبيه],hasWarning as [يوجد انذار], hasOffwithout as [مجاز بدون راتب], hasAbsence as [غياب]
from [HR].[dbo].[EmployeeRatingTempTBL] 
left join hr.dbo.EmpRateDegreeTBL on [HR].[dbo].[EmployeeRatingTempTBL].[rateDegree] = hr.dbo.EmpRateDegreeTBL.degreeID
where isactive=1 and DepartmentID = @depID  and EmpID <> @EmpID";
                        cmd.Parameters.AddWithValue("@EmpID", EmpID);
                        cmd.Parameters.AddWithValue("@depID", depID);

                    }
                    else if (BranchID != "1" & IsManager == "True")
                    {//branches managers
                        cond = condAND(cond);
                        cond += " branchID = @branchID and IsManager = 0";
                        cmd.Parameters.AddWithValue("@branchID", BranchID);

                    }

                    string Order;

                    Order = @" ORDER BY [FullName] ";
                    cmd.CommandText = CmdText + " WHERE IsActive = 1 AND" + cond + Order;
                    cmd.CommandText += " ";
                    //AND EmployeeRatingTempTBL.rateDegree<=0 
                    DataTable dt1 = new DataTable();
                    dt1 = TBIMaster.GetData(cmd, lblMessage);
                    int ID = Convert.ToInt32(dt1.Rows.Count);
                    hfCount.Value = ID.ToString();
                    //for displaying total no.
                    Lbltotal.Text = hfCount.Value;
                    string empCount = (Math.Ceiling(Convert.ToDouble(hfCount.Value) * 0.25)).ToString();
                    lblExc.Text = empCount;
                    //DataColumn column;
                    //column = new DataColumn();
                    //column.DataType = System.Type.GetType("System.Int32");
                    //column.ColumnName = "القدرة على تنفيذ الاعمال وتحمل المسؤولية 30";
                    //dt1.Columns.Add(column);
                    GridView1.Columns.Clear();
                    TBIMaster.AddColumnsToGridView(GridView1, dt1);
                    GridView1.DataSource = dt1;
                    GridView1.DataBind();


                    if (GridView1.Columns.Count > 0)
                    {
                        //GridView1.Columns[1].ItemStyle.Width = 200;
                        //GridView1.Columns[1].ItemStyle.Height = 50;
                        GridView1.Columns[0].Visible = false;
                        //for (int i = 2; i < GridView1.Columns.Count; i++)
                        //{
                        //    //GridView1.Columns[i].ItemStyle.Width = 50;
                        //}
                        //foreach (GridViewRow row in GridView1.Rows)
                        //{
                        //    LinkButton lb = (LinkButton)row.Cells[0].Controls[0];

                        //    //lb.Text = "اختيار";
                        //    lb.ForeColor = System.Drawing.Color.DarkSlateGray;
                        //    //lb.BackColor = System.Drawing.Color.Honeydew;
                        //    //lb.BorderColor = System.Drawing.Color.Aquamarine;
                        //    lb.Font.Size = FontUnit.XLarge;
                        //    lb.Font.Italic = true;
                        //    //lb.BorderWidth = 2;
                        //}

                    }
                    else
                    {
                        lblMessage.Text = "لم يتم العثور على موظفين.";
                    }
                }
                else if (ddlRateType.SelectedValue == "2")
                {
                    string cond = "";
                    string CmdText = @"SELECT [EmpID]  as [رقم الموظف] ,[FullName] as [اسم الموظف], [rateNotes] as [ملاحظات],  hr.dbo.EmpRateDegreeTBL.degreeDesc as[درجة التقييم]
                                   FROM [HR].[dbo].[EmployeeRatingTempTBL]
                                left join hr.dbo.EmpRateDegreeTBL on [HR].[dbo].[EmployeeRatingTempTBL].[rate16Degree] = hr.dbo.EmpRateDegreeTBL.degreeID";
                    SqlCommand cmd = new SqlCommand();

                    if (BranchID == "1" & IsManager == "True" & depID != "69")
                    {// for dept managers
                        cond = condAND(cond);
                        cond += " DepartmentID = @depID and IsManager = 0 and EmployementStartDate <='2017-09-30'";
                        //EmployementStartDate <= dateadd(month, -5, getdate())
                        cmd.Parameters.AddWithValue("@depID", depID);
                    }

                    else if ((IsCEO == "True") || (depID == "69" & IsManager == "True"))
                    {//ceo for branches manager and related deps
                        cond = condAND(cond);
                        cond += @" DepartmentID in(69, 53)  and EmployementStartDate <='2017-09-30' and EmpID <> 2598 union 
select [EmpID]  as [رقم الموظف] ,[FullName] as [اسم الموظف], '' as [ملاحظات],hr.dbo.EmpRateDegreeTBL.degreeDesc as[درجة التقييم]
FROM [HR].[dbo].[EmployeeRatingTempTBL]
left join hr.dbo.EmpRateDegreeTBL on [HR].[dbo].[EmployeeRatingTempTBL].[rate16Degree] = hr.dbo.EmpRateDegreeTBL.degreeID
where isactive = 1  and IsManager=1 and EmpID <> @EmpID 
and DepartmentID in (select [DepartmentID] from [HR].[dbo].[DepartmentTBL] where CEOAssetID = 2598 ) 
union select [EmpID]  as [رقم الموظف] ,[FullName] as [اسم الموظف],'' as [ملاحظات],hr.dbo.EmpRateDegreeTBL.degreeDesc as[درجة التقييم]
FROM [HR].[dbo].[EmployeeRatingTempTBL] 
left join hr.dbo.EmpRateDegreeTBL on [HR].[dbo].[EmployeeRatingTempTBL].[rate16Degree] = hr.dbo.EmpRateDegreeTBL.degreeID
where   isactive = 1 and IsCEOAssist = 1 ";
                        // EmployementStartDate <= dateadd(month, -5, getdate())
                        cmd.Parameters.AddWithValue("@EmpID", EmpID);
                    }
                    else if (IsCEOAssist == "True")
                    {//ceo assis for related depts
                        cond = condAND(cond);
                        cond += @" branchID = 1 and EmployementStartDate <='2017-09-30' and DepartmentID in
(select [DepartmentID] from [HR].[dbo].[DepartmentTBL] where CEOAssetID = @EmpID and isManager = 1) 
union select [EmpID]  as [رقم الموظف] ,[FullName] as [اسم الموظف], '' as [ملاحظات],hr.dbo.EmpRateDegreeTBL.degreeDesc as[درجة التقييم]
from [HR].[dbo].[EmployeeRatingTempTBL] 
left join hr.dbo.EmpRateDegreeTBL on [HR].[dbo].[EmployeeRatingTempTBL].[rate16Degree] = hr.dbo.EmpRateDegreeTBL.degreeID
where isactive=1 and DepartmentID = @depID  and EmpID <> @EmpID";
                        //EmployementStartDate <= dateadd(month, -5, getdate())
                        cmd.Parameters.AddWithValue("@EmpID", EmpID);
                        cmd.Parameters.AddWithValue("@depID", depID);
                    }
                    else if (BranchID != "1" & IsManager == "True")
                    {//branches managers
                        cond = condAND(cond);
                        cond += " branchID = @branchID and IsManager = 0 and EmployementStartDate <='2017-09-30'";
                        cmd.Parameters.AddWithValue("@branchID", BranchID);
                        //EmployementStartDate <= dateadd(month, -5, getdate())
                    }

                    string Order;

                    Order = @" ORDER BY [FullName] ";
                    cmd.CommandText = CmdText + " WHERE IsActive = 1 AND" + cond + Order;
                    cmd.CommandText += " ";

                    DataTable dt1 = new DataTable();
                    dt1 = TBIMaster.GetData(cmd, lblMessage);
                    int ID = Convert.ToInt32(dt1.Rows.Count);
                    hfCount.Value = ID.ToString();
                    //for displaying total no.
                    Lbltotal.Text = hfCount.Value;
                    string empCount = (Math.Ceiling(Convert.ToDouble(hfCount.Value) * 0.25)).ToString();
                    string emp35Count = (Math.Ceiling(Convert.ToDouble(hfCount.Value) * 0.35)).ToString();
                    string emp25Count = (Math.Ceiling(Convert.ToDouble(hfCount.Value) * 0.25)).ToString();
                    string emp15Count = (Math.Ceiling(Convert.ToDouble(hfCount.Value) * 0.15)).ToString();
                    //(Math.Round(Convert.ToInt64(hfCount.Value) * 0.15)).ToString();
                    lblExc.Text = empCount;
                    lblVery.Text = emp35Count;
                    lblGood.Text = emp25Count;
                    lblInter.Text = emp15Count;
                    //end of display
                    GridView1.Columns.Clear();
                    TBIMaster.AddColumnsToGridView(GridView1, dt1);
                    GridView1.DataSource = dt1;
                    GridView1.DataBind();


                    if (GridView1.Columns.Count > 0)
                    {
                        //GridView1.Columns[1].ItemStyle.Width = 200;
                        //GridView1.Columns[1].ItemStyle.Height = 50;
                        GridView1.Columns[0].Visible = false;
                    }
                    else
                    {
                        lblMessage.Text = "لم يتم العثور على موظفين.";
                    }
                }
            }

        }
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void GridView1_PageIndexChanged(object sender, EventArgs e)
        {
            GetGrid();
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
        }

    

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            GetGrid();
        }

        protected void BtnCancel_Click(object sender, EventArgs e)
        {

        }



        public override void VerifyRenderingInServerForm(System.Web.UI.Control control)
        {
            /* Verifies that the control is rendered */
        }
        protected void btnPrint_Click(object sender, EventArgs e)
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

            // for print only without excel
            //GridView1.AllowPaging = false;

            //GridView1.DataBind();

            //StringWriter sw = new StringWriter();

            //HtmlTextWriter hw = new HtmlTextWriter(sw);

            //GridView1.RenderControl(hw);

            //string gridHTML = sw.ToString().Replace("\"", "'")

            //    .Replace(System.Environment.NewLine, "");

            //StringBuilder sb = new StringBuilder();

            //sb.Append("<script type = 'text/javascript'>");

            //sb.Append("window.onload = new function(){");

            //sb.Append("var printWin = window.open('', '', 'left=0");

            //sb.Append(",top=0,width=1000,height=600,status=0');");

            //sb.Append("printWin.document.write(\"");

            //sb.Append(gridHTML);

            //sb.Append("\");");

            //sb.Append("printWin.document.close();");

            //sb.Append("printWin.focus();");

            //sb.Append("printWin.print();");

            //sb.Append("printWin.close();};");

            //sb.Append("</script>");

            //ClientScript.RegisterStartupScript(this.GetType(), "GridPrint", sb.ToString());


            //GridView1.AllowPaging = true;

            //GridView1.DataBind();

        }

    }
}