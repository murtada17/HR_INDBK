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
    public partial class Emp16RatingResult : System.Web.UI.Page
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
                    TBIMaster.FillCombo("BranchID", "BranchDescAR", "BranchsTBL", ddlIBranchs, true, lblMessage);
                    TBIMaster.FillCombo("DepartmentID", "DepartmentDescAR", "DepartmentTBL", ddlIDepartment, true, lblMessage);

                    if (Session["msg"] != null)
                    {
                        int msg = Convert.ToInt32(Session["msg"]);

                        TBIMaster.Messages(lblMessage, msg);
                        Session["msg"] = null;
                    }
                    if (depID == "41" || UserID == "1143")
                    {//hr
                        divddl.Attributes["style"] = "display: inlineblock";
                        divtxt.Attributes["style"] = "display: none";
                    }

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
            if (depID != "41" & UserID != "1143")
            {
                ddlIBranchs.SelectedValue = BranchID;
                ddlIDepartment.SelectedValue = depID;
            }
            else
                if ((ddlIBranchs.SelectedIndex == 0 & ddlIDepartment.SelectedIndex == 0) || (ddlIBranchs.SelectedIndex == 1 & ddlIDepartment.SelectedIndex == 0))
                {
                    lblMessage.Text = "يرجى اختيار الفرع/القسم";
                }
            if ((string.IsNullOrEmpty(txtStartDate.Text)) || (string.IsNullOrEmpty(txtEndDate.Text)))
            {
                lblMessage.Text = "يرجى اختيار الفترة الزمنية";
            }
            else
            {


                SqlCommand cmd = new SqlCommand();
                DataTable dt1 = new DataTable();
                SqlCommand cmd2 = new SqlCommand();
                cmd2.CommandText = "select [DepartmentID] from [HR].[dbo].[DepartmentTBL] where CEOAssetID in (681, 2598, 883, 4066, 2601) and isActive = 1";
                DataTable dt2 = new DataTable();
                dt2 = TBIMaster.GetData(cmd2, lblMessage);
                //List<int> depList = (from row in dt2.AsEnumerable() select Convert.ToInt32(row["DepartmentID"])).ToList();
                SqlCommand cmd3 = new SqlCommand();
                cmd3.CommandText = "select [managerEmpID16] from [HR].[dbo].[Emp16RatingTBL] where [managerEmpID16] in (681, 2598, 883, 4066, 2601, 2676)";
                DataTable dt3 = new DataTable();
                dt3 = TBIMaster.GetData(cmd3, lblMessage);

                if (depID == "41" || UserID == "1143")
                {//hr

                    SqlCommand cmdCheck = new SqlCommand(@"SELECT [doneID]
      ,[branchID]
      ,[DepartmentID]
      ,[isDone]
      ,[isRating]
      ,[is16Rating]
      ,[submitUser]
      ,[submitDate]
  FROM [HR].[dbo].[RatingDone] where [branchID]=@branchID and [DepartmentID]=@departmentID and is16rating = 1 and isdone =1 and CAST(submitDate AS DATE) between @startDate and @EndDate");
                    //cmdCheck.Parameters.AddWithValue("@userID",UserID);
                    if (ddlIBranchs.SelectedValue == "1")
                    {
                        cmdCheck.Parameters.AddWithValue("@departmentID", ddlIDepartment.SelectedValue);
                    }
                    else
                    {
                        cmdCheck.Parameters.AddWithValue("@departmentID", "71");
                    }
                    cmdCheck.Parameters.AddWithValue("@branchID", ddlIBranchs.SelectedValue);
                    cmdCheck.Parameters.AddWithValue("@startDate", txtStartDate.Text);
                    cmdCheck.Parameters.AddWithValue("@EndDate", txtEndDate.Text);

                    DataTable dt = new DataTable();

                    dt = TBIMaster.GetData(cmdCheck, lblMessage);

                    if (dt.Rows.Count <= 0)
                    {
                        lblMessage.Text = "التقييمات الخاصة بهذا القسم/الفرع غير كاملة لحد الان";
                        GridView1.Visible = false;

                    }
                    else
                    {
                        GridView1.Visible = true;
                        SqlCommand cmd6 = new SqlCommand();
                        cmd6.CommandText = @"  select count(rateDegree16)
	                               from [HR].[dbo].[Emp16RatingTBL]
	                               where rateDegree16 = 1 and  CAST(submitDate AS DATE) between @startDate and @EndDate
                                    and [HR].[dbo].[Emp16RatingTBL].[departmentID16] = @departmentID and [HR].[dbo].[Emp16RatingTBL].[branchID16] = @branchID";
                        
                        if (ddlIBranchs.SelectedValue == "1")
                        {
                            cmd6.Parameters.AddWithValue("@departmentID", ddlIDepartment.SelectedValue);
                        }
                        else
                        {
                            cmd6.Parameters.AddWithValue("@departmentID", "71");
                        }
                        cmd6.Parameters.AddWithValue("@branchID", ddlIBranchs.SelectedValue);
                        cmd6.Parameters.AddWithValue("@startDate", txtStartDate.Text);
                        cmd6.Parameters.AddWithValue("@EndDate", txtEndDate.Text);
                        int ratecount = Convert.ToInt32(TBIMaster.ExecuteScaler(cmd6, lblMessage, HttpContext.Current.Request.Path));
                        lblExc.Text = ratecount.ToString();

                        SqlCommand cmd7= new SqlCommand();
                        cmd7.CommandText = @"  select count(rateDegree16)
	                               from [HR].[dbo].[Emp16RatingTBL]
	                               where rateDegree16 = 2 and CAST(submitDate AS DATE) between @startDate and @EndDate
                                    and [HR].[dbo].[Emp16RatingTBL].[departmentID16] = @departmentID and [HR].[dbo].[Emp16RatingTBL].[branchID16] = @branchID";
                        
                        if (ddlIBranchs.SelectedValue == "1")
                        {
                            cmd7.Parameters.AddWithValue("@departmentID", ddlIDepartment.SelectedValue);
                        }
                        else
                        {
                            cmd7.Parameters.AddWithValue("@departmentID", "71");
                        }
                        cmd7.Parameters.AddWithValue("@branchID", ddlIBranchs.SelectedValue);
                        cmd7.Parameters.AddWithValue("@startDate", txtStartDate.Text);
                        cmd7.Parameters.AddWithValue("@EndDate", txtEndDate.Text);
                        int rate35count = Convert.ToInt32(TBIMaster.ExecuteScaler(cmd7, lblMessage, HttpContext.Current.Request.Path));
                        lblVery.Text = rate35count.ToString();
                        SqlCommand cmd4 = new SqlCommand();
                        cmd4.CommandText = @"  select count(rateDegree16)
	                               from [HR].[dbo].[Emp16RatingTBL]
	                               where rateDegree16 = 3 and CAST(submitDate AS DATE) between @startDate and @EndDate
                                     and [HR].[dbo].[Emp16RatingTBL].[departmentID16] = @departmentID and [HR].[dbo].[Emp16RatingTBL].[branchID16] = @branchID";
                       
                        if (ddlIBranchs.SelectedValue == "1")
                        {
                            cmd4.Parameters.AddWithValue("@departmentID", ddlIDepartment.SelectedValue);
                        }
                        else
                        {
                            cmd4.Parameters.AddWithValue("@departmentID", "71");
                        }
                        cmd4.Parameters.AddWithValue("@branchID", ddlIBranchs.SelectedValue);
                        cmd4.Parameters.AddWithValue("@startDate", txtStartDate.Text);
                        cmd4.Parameters.AddWithValue("@EndDate", txtEndDate.Text);
                        int rate25count = Convert.ToInt32(TBIMaster.ExecuteScaler(cmd4, lblMessage, HttpContext.Current.Request.Path));
                        lblGood.Text = rate25count.ToString();

                        SqlCommand cmd5 = new SqlCommand();
                        cmd5.CommandText = @"  select count(rateDegree16)
	                               from [HR].[dbo].[Emp16RatingTBL]
	                               where rateDegree16 = 4 and CAST(submitDate AS DATE) between @startDate and @EndDate
                                     and [HR].[dbo].[Emp16RatingTBL].[departmentID16] = @departmentID and [HR].[dbo].[Emp16RatingTBL].[branchID16] = @branchID";
                       
                        if (ddlIBranchs.SelectedValue == "1")
                        {
                            cmd5.Parameters.AddWithValue("@departmentID", ddlIDepartment.SelectedValue);
                        }
                        else
                        {
                            cmd5.Parameters.AddWithValue("@departmentID", "71");
                        }
                        cmd5.Parameters.AddWithValue("@branchID", ddlIBranchs.SelectedValue);
                        cmd5.Parameters.AddWithValue("@startDate", txtStartDate.Text);
                        cmd5.Parameters.AddWithValue("@EndDate", txtEndDate.Text);
                        int rate15count = Convert.ToInt32(TBIMaster.ExecuteScaler(cmd5, lblMessage, HttpContext.Current.Request.Path));
                        lblInter.Text = rate15count.ToString();
                        SqlCommand cmd8 = new SqlCommand();
                        cmd8.CommandText = @"  select count(rateDegree16)
	                               from [HR].[dbo].[Emp16RatingTBL]
	                               where rateDegree16 = 5 and CAST(submitDate AS DATE) between @startDate and @EndDate
                                     and [HR].[dbo].[Emp16RatingTBL].[departmentID16] = @departmentID and [HR].[dbo].[Emp16RatingTBL].[branchID16] = @branchID";
                        cmd8.Parameters.AddWithValue("@EmpID", EmpID);
                        if (ddlIBranchs.SelectedValue == "1")
                        {
                            cmd8.Parameters.AddWithValue("@departmentID", ddlIDepartment.SelectedValue);
                        }
                        else
                        {
                            cmd8.Parameters.AddWithValue("@departmentID", "71");
                        }
                        cmd8.Parameters.AddWithValue("@branchID", ddlIBranchs.SelectedValue);
                        cmd8.Parameters.AddWithValue("@startDate", txtStartDate.Text);
                        cmd8.Parameters.AddWithValue("@EndDate", txtEndDate.Text);
                        int rateOKcount = Convert.ToInt32(TBIMaster.ExecuteScaler(cmd8, lblMessage, HttpContext.Current.Request.Path));
                        lblOK.Text = rateOKcount.ToString();


                        //Grid
                        cmd.CommandText = @"SELECT HR.dbo.BranchsTBL.BranchDescAR as [الفرع], HR.dbo.DepartmentTBL.DepartmentDescAR as [القسم],
   [FullName16] as [اسم الموظف],R.degreeDesc as [درجة التقييم]  
        , HR.dbo.EmployeesVW.Name	as [اسم المدير],[submitDate] as [تاريخ الادخال] 
		FROM [HR].[dbo].[Emp16RatingTBL]
	  LEFT JOIN HR.dbo.BranchsTBL ON [HR].[dbo].[Emp16RatingTBL].branchID16 = HR.dbo.BranchsTBL.BranchID 
	  LEFT JOIN HR.dbo.DepartmentTBL ON [HR].[dbo].[Emp16RatingTBL].departmentID16 = HR.dbo.DepartmentTBL.DepartmentID
	  LEFT JOIN [HR].[dbo].[EmpRateDegreeTBL] as R ON [HR].[dbo].[Emp16RatingTBL].rateDegree16 = R.degreeID
	  LEFT JOIN [HR].[dbo].EmployeesVW on [HR].[dbo].[Emp16RatingTBL].managerEmpID16 = [HR].[dbo].EmployeesVW.EmpID


	   where [HR].[dbo].[Emp16RatingTBL].[departmentID16] = @departmentID and [HR].[dbo].[Emp16RatingTBL].[branchID16] = @branchID and CAST(submitDate AS DATE) between @startDate and @EndDate";
                        if (ddlIBranchs.SelectedValue == "1")
                        {
                            cmd.Parameters.AddWithValue("@departmentID", ddlIDepartment.SelectedValue);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@departmentID", "71");
                        }
                        cmd.Parameters.AddWithValue("@branchID", ddlIBranchs.SelectedValue);
                        cmd.Parameters.AddWithValue("@startDate", txtStartDate.Text);
                        cmd.Parameters.AddWithValue("@EndDate", txtEndDate.Text);
                        dt1 = TBIMaster.GetData(cmd, lblMessage);
                        GridView1.Columns.Clear();
                        TBIMaster.AddColumnsToGridView(GridView1, dt1);
                        GridView1.DataSource = dt1;
                        GridView1.DataBind();
                        if (ddlIBranchs.SelectedValue != "1")
                        {
                            GridView1.Columns[1].Visible = false;
                        }
                        if (GridView1.Rows.Count == 0)
                        {
                            lblMessage.Text = "لم يتم العثور على نتائج";
                        }

                    }
                }

                else if (depID != "41" || UserID =="1143")
                {
                    for (int i = 0; i < dt3.Rows.Count; i++)
                    {
                        if (EmpID == dt3.Rows[i]["managerEmpID16"].ToString())
                        {
                            SqlCommand cmd6 = new SqlCommand();
                            cmd6.CommandText = @"  select count(rateDegree16)
	                               from [HR].[dbo].[Emp16RatingTBL]
	                               where rateDegree16 = 1 and  CAST(submitDate AS DATE) between @startDate and @EndDate
                                    and [HR].[dbo].[Emp16RatingTBL].[departmentID16] = @departmentID and [HR].[dbo].[Emp16RatingTBL].[branchID16] = @branchID";
                            
                            cmd6.Parameters.AddWithValue("@departmentID", depID);
                            cmd6.Parameters.AddWithValue("@branchID", BranchID);
                            cmd6.Parameters.AddWithValue("@startDate", txtStartDate.Text);
                            cmd6.Parameters.AddWithValue("@EndDate", txtEndDate.Text);
                            int ratecount = Convert.ToInt32(TBIMaster.ExecuteScaler(cmd6, lblMessage, HttpContext.Current.Request.Path));
                            lblExc.Text = ratecount.ToString();

                            SqlCommand cmd7 = new SqlCommand();
                            cmd7.CommandText = @"  select count(rateDegree16)
	                               from [HR].[dbo].[Emp16RatingTBL]
	                               where rateDegree16 = 2 and CAST(submitDate AS DATE) between @startDate and @EndDate
                                    and [HR].[dbo].[Emp16RatingTBL].[departmentID16] = @departmentID and [HR].[dbo].[Emp16RatingTBL].[branchID16] = @branchID";
                            cmd7.Parameters.AddWithValue("@departmentID", depID);
                            cmd7.Parameters.AddWithValue("@branchID", BranchID);
                            cmd7.Parameters.AddWithValue("@startDate", txtStartDate.Text);
                            cmd7.Parameters.AddWithValue("@EndDate", txtEndDate.Text);
                            int rate35count = Convert.ToInt32(TBIMaster.ExecuteScaler(cmd7, lblMessage, HttpContext.Current.Request.Path));
                            lblVery.Text = rate35count.ToString();
                            SqlCommand cmd4 = new SqlCommand();
                            cmd4.CommandText = @"  select count(rateDegree16)
	                               from [HR].[dbo].[Emp16RatingTBL]
	                               where rateDegree16 = 3 and CAST(submitDate AS DATE) between @startDate and @EndDate
                                     and [HR].[dbo].[Emp16RatingTBL].[departmentID16] = @departmentID and [HR].[dbo].[Emp16RatingTBL].[branchID16] = @branchID";
                            cmd4.Parameters.AddWithValue("@departmentID", depID);
                            cmd4.Parameters.AddWithValue("@branchID", BranchID);
                            cmd4.Parameters.AddWithValue("@startDate", txtStartDate.Text);
                            cmd4.Parameters.AddWithValue("@EndDate", txtEndDate.Text);
                            int rate25count = Convert.ToInt32(TBIMaster.ExecuteScaler(cmd4, lblMessage, HttpContext.Current.Request.Path));
                            lblGood.Text = rate25count.ToString();

                            SqlCommand cmd5 = new SqlCommand();
                            cmd5.CommandText = @"  select count(rateDegree16)
	                               from [HR].[dbo].[Emp16RatingTBL]
	                               where rateDegree16 = 4 and CAST(submitDate AS DATE) between @startDate and @EndDate
                                     and [HR].[dbo].[Emp16RatingTBL].[departmentID16] = @departmentID and [HR].[dbo].[Emp16RatingTBL].[branchID16] = @branchID";
                            cmd5.Parameters.AddWithValue("@departmentID", depID);
                            cmd5.Parameters.AddWithValue("@branchID", BranchID);
                            cmd5.Parameters.AddWithValue("@startDate", txtStartDate.Text);
                            cmd5.Parameters.AddWithValue("@EndDate", txtEndDate.Text);
                            int rate15count = Convert.ToInt32(TBIMaster.ExecuteScaler(cmd5, lblMessage, HttpContext.Current.Request.Path));
                            lblInter.Text = rate15count.ToString();
                            SqlCommand cmd8 = new SqlCommand();
                            cmd8.CommandText = @"  select count(rateDegree16)
	                               from [HR].[dbo].[Emp16RatingTBL]
	                               where rateDegree16 = 5 and CAST(submitDate AS DATE) between @startDate and @EndDate
                                     and [HR].[dbo].[Emp16RatingTBL].[departmentID16] = @departmentID and [HR].[dbo].[Emp16RatingTBL].[branchID16] = @branchID";
                            cmd8.Parameters.AddWithValue("@departmentID", depID);
                            cmd8.Parameters.AddWithValue("@branchID", BranchID);
                            cmd8.Parameters.AddWithValue("@startDate", txtStartDate.Text);
                            cmd8.Parameters.AddWithValue("@EndDate", txtEndDate.Text);
                            int rateOKcount = Convert.ToInt32(TBIMaster.ExecuteScaler(cmd8, lblMessage, HttpContext.Current.Request.Path));
                            lblOK.Text = rateOKcount.ToString();

                            cmd.CommandText = @"SELECT HR.dbo.BranchsTBL.BranchDescAR as [الفرع], HR.dbo.DepartmentTBL.DepartmentDescAR as [القسم],
   [FullName16] as [اسم الموظف],R.degreeDesc as [درجة التقييم]  
        , HR.dbo.EmployeesVW.Name	as [اسم المدير],[submitDate] as [تاريخ الادخال] 
		FROM [HR].[dbo].[Emp16RatingTBL]
	  LEFT JOIN HR.dbo.BranchsTBL ON [HR].[dbo].[Emp16RatingTBL].branchID16 = HR.dbo.BranchsTBL.BranchID 
	  LEFT JOIN HR.dbo.DepartmentTBL ON [HR].[dbo].[Emp16RatingTBL].departmentID16 = HR.dbo.DepartmentTBL.DepartmentID
	  LEFT JOIN [HR].[dbo].[EmpRateDegreeTBL] as R ON [HR].[dbo].[Emp16RatingTBL].rateDegree16 = R.degreeID
	  LEFT JOIN [HR].[dbo].EmployeesVW on [HR].[dbo].[Emp16RatingTBL].managerEmpID16 = [HR].[dbo].EmployeesVW.EmpID


	   where [HR].[dbo].[Emp16RatingTBL].[departmentID16] = @departmentID and [HR].[dbo].[Emp16RatingTBL].[branchID16] = @branchID and CAST(submitDate AS DATE) between @startDate and @EndDate";
                            cmd.Parameters.AddWithValue("@departmentID", depID);
                            cmd.Parameters.AddWithValue("@branchID", BranchID);
                            cmd.Parameters.AddWithValue("@startDate", txtStartDate.Text);
                            cmd.Parameters.AddWithValue("@EndDate", txtEndDate.Text);
                            dt1 = TBIMaster.GetData(cmd, lblMessage);
                            GridView1.Columns.Clear();
                            TBIMaster.AddColumnsToGridView(GridView1, dt1);
                            GridView1.DataSource = dt1;
                            GridView1.DataBind();
                            y = "1";
                            if (GridView1.Rows.Count == 0)
                            {
                                lblMessage.Text = "لم يتم العثور على نتائج";
                            }
                            break;


                        }
                    }

                    if (y == "0")
                    {
                        SqlCommand cmd6 = new SqlCommand();
                        cmd6.CommandText = @"  select count(rateDegree16)
	                               from [HR].[dbo].[Emp16RatingTBL]
	                               where rateDegree16 = 1 and  CAST(submitDate AS DATE) between @startDate and @EndDate
                                    and [HR].[dbo].[Emp16RatingTBL].[departmentID16] = @departmentID and [HR].[dbo].[Emp16RatingTBL].[branchID16] = @branchID";

                        cmd6.Parameters.AddWithValue("@departmentID", depID);
                        cmd6.Parameters.AddWithValue("@branchID", BranchID);
                        cmd6.Parameters.AddWithValue("@startDate", txtStartDate.Text);
                        cmd6.Parameters.AddWithValue("@EndDate", txtEndDate.Text);
                        int ratecount = Convert.ToInt32(TBIMaster.ExecuteScaler(cmd6, lblMessage, HttpContext.Current.Request.Path));
                        lblExc.Text = ratecount.ToString();

                        SqlCommand cmd7 = new SqlCommand();
                        cmd7.CommandText = @"  select count(rateDegree16)
	                               from [HR].[dbo].[Emp16RatingTBL]
	                               where rateDegree16 = 2 and CAST(submitDate AS DATE) between @startDate and @EndDate
                                    and [HR].[dbo].[Emp16RatingTBL].[departmentID16] = @departmentID and [HR].[dbo].[Emp16RatingTBL].[branchID16] = @branchID";
                        cmd7.Parameters.AddWithValue("@departmentID", depID);
                        cmd7.Parameters.AddWithValue("@branchID", BranchID);
                        cmd7.Parameters.AddWithValue("@startDate", txtStartDate.Text);
                        cmd7.Parameters.AddWithValue("@EndDate", txtEndDate.Text);
                        int rate35count = Convert.ToInt32(TBIMaster.ExecuteScaler(cmd7, lblMessage, HttpContext.Current.Request.Path));
                        lblVery.Text = rate35count.ToString();
                        SqlCommand cmd4 = new SqlCommand();
                        cmd4.CommandText = @"  select count(rateDegree16)
	                               from [HR].[dbo].[Emp16RatingTBL]
	                               where rateDegree16 = 3 and CAST(submitDate AS DATE) between @startDate and @EndDate
                                     and [HR].[dbo].[Emp16RatingTBL].[departmentID16] = @departmentID and [HR].[dbo].[Emp16RatingTBL].[branchID16] = @branchID";
                        cmd4.Parameters.AddWithValue("@departmentID", depID);
                        cmd4.Parameters.AddWithValue("@branchID", BranchID);
                        cmd4.Parameters.AddWithValue("@startDate", txtStartDate.Text);
                        cmd4.Parameters.AddWithValue("@EndDate", txtEndDate.Text);
                        int rate25count = Convert.ToInt32(TBIMaster.ExecuteScaler(cmd4, lblMessage, HttpContext.Current.Request.Path));
                        lblGood.Text = rate25count.ToString();

                        SqlCommand cmd5 = new SqlCommand();
                        cmd5.CommandText = @"  select count(rateDegree16)
	                               from [HR].[dbo].[Emp16RatingTBL]
	                               where rateDegree16 = 4 and CAST(submitDate AS DATE) between @startDate and @EndDate
                                     and [HR].[dbo].[Emp16RatingTBL].[departmentID16] = @departmentID and [HR].[dbo].[Emp16RatingTBL].[branchID16] = @branchID";
                        cmd5.Parameters.AddWithValue("@departmentID", depID);
                        cmd5.Parameters.AddWithValue("@branchID", BranchID);
                        cmd5.Parameters.AddWithValue("@startDate", txtStartDate.Text);
                        cmd5.Parameters.AddWithValue("@EndDate", txtEndDate.Text);
                        int rate15count = Convert.ToInt32(TBIMaster.ExecuteScaler(cmd5, lblMessage, HttpContext.Current.Request.Path));
                        lblInter.Text = rate15count.ToString();
                        SqlCommand cmd8 = new SqlCommand();
                        cmd8.CommandText = @"  select count(rateDegree16)
	                               from [HR].[dbo].[Emp16RatingTBL]
	                               where rateDegree16 = 5 and CAST(submitDate AS DATE) between @startDate and @EndDate
                                     and [HR].[dbo].[Emp16RatingTBL].[departmentID16] = @departmentID and [HR].[dbo].[Emp16RatingTBL].[branchID16] = @branchID";
                        cmd8.Parameters.AddWithValue("@departmentID", depID);
                        cmd8.Parameters.AddWithValue("@branchID", BranchID);
                        cmd8.Parameters.AddWithValue("@startDate", txtStartDate.Text);
                        cmd8.Parameters.AddWithValue("@EndDate", txtEndDate.Text);
                        int rateOKcount = Convert.ToInt32(TBIMaster.ExecuteScaler(cmd8, lblMessage, HttpContext.Current.Request.Path));
                        lblOK.Text = rateOKcount.ToString();

                        cmd.CommandText = @"SELECT HR.dbo.BranchsTBL.BranchDescAR as [الفرع], HR.dbo.DepartmentTBL.DepartmentDescAR as [القسم],
   [FullName16] as [اسم الموظف],R.degreeDesc as [درجة التقييم]  
        , HR.dbo.EmployeesVW.Name	as [اسم المدير],[submitDate] as [تاريخ الادخال] 
		FROM [HR].[dbo].[Emp16RatingTBL]
	  LEFT JOIN HR.dbo.BranchsTBL ON [HR].[dbo].[Emp16RatingTBL].branchID16 = HR.dbo.BranchsTBL.BranchID 
	  LEFT JOIN HR.dbo.DepartmentTBL ON [HR].[dbo].[Emp16RatingTBL].departmentID16 = HR.dbo.DepartmentTBL.DepartmentID
	  LEFT JOIN [HR].[dbo].[EmpRateDegreeTBL] as R ON [HR].[dbo].[Emp16RatingTBL].rateDegree16 = R.degreeID
	  LEFT JOIN [HR].[dbo].EmployeesVW on [HR].[dbo].[Emp16RatingTBL].managerEmpID16 = [HR].[dbo].EmployeesVW.EmpID


	   where [HR].[dbo].[Emp16RatingTBL].[departmentID16] = @departmentID and [HR].[dbo].[Emp16RatingTBL].[branchID16] = @branchID and CAST(submitDate AS DATE) between @startDate and @EndDate";
                        cmd.Parameters.AddWithValue("@departmentID", depID);
                        cmd.Parameters.AddWithValue("@branchID", BranchID);
                        cmd.Parameters.AddWithValue("@startDate", txtStartDate.Text);
                        cmd.Parameters.AddWithValue("@EndDate", txtEndDate.Text);
                        dt1 = TBIMaster.GetData(cmd, lblMessage);
                        GridView1.Columns.Clear();
                        TBIMaster.AddColumnsToGridView(GridView1, dt1);
                        GridView1.DataSource = dt1;
                        GridView1.DataBind();
                        if (BranchID != "1")
                        {
                            GridView1.Columns[1].Visible = false;
                        }
                        if (GridView1.Rows.Count == 0)
                        {
                            lblMessage.Text = "لم يتم العثور على نتائج";
                        }

                    }


                }
                else
                {
                    lblMessage.Text = "لم يتم العثور على نتائج";
                }
            }
        }



        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
        }

        protected void GridView1_PageIndexChanged(object sender, EventArgs e)
        {
            GetGrid();
        }

        protected void txtJoinDate_TextChanged(object sender, EventArgs e)
        {
            WebControl MyWebControl = sender as WebControl;
            if (MyWebControl != null)
            {
                lblMessage.Text = "";
                System.Web.UI.WebControls.TextBox txt = (System.Web.UI.WebControls.TextBox)MyWebControl;
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
        protected void ddlbranchs_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            GetGrid();
        }

        protected void BtnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/Employee/EmpRatingResult.aspx");
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
        }
    }
}