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
    public partial class EmpRatingResult : System.Web.UI.Page
    {
        string BranchID = "0",x="0" , y="0";
        string depID = "0";
        string UserID = "0";
        string IsManager = "0";
        string IsCEO = "0";
        string IsCEOAssist = "0";
        string EmpID = "0";

        protected void Page_Load(object sender, EventArgs e)
        {
            //string date1 = DateTime.Now.ToString("yyyy/MM/dd");
            //string date2 = "2018/03/06";
            //string date3 = "2018/03/13";
            //int result = string.Compare(date1, date2);
            //int result2 = string.Compare(date1, date3);
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
                        divName.Attributes["style"] = "display: inlineblock";
                    }
               
                }
  
                    //Session["msg"] = "9";
                    //Response.Redirect("~/Pages/Default.aspx");

 
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
            if (depID != "41" & UserID !="1143")
            {
                ddlIBranchs.SelectedValue = BranchID;
                ddlIDepartment.SelectedValue = depID;
            }
            //else
            //    if ((ddlIBranchs.SelectedIndex == 0 & ddlIDepartment.SelectedIndex == 0) || (ddlIBranchs.SelectedIndex == 1 & ddlIDepartment.SelectedIndex == 0))
            //    {
            //        lblMessage.Text = "يرجى اختيار الفرع/القسم";
            //    }




            //if ((string.IsNullOrEmpty(txtStartDate.Text)) || (string.IsNullOrEmpty(txtEndDate.Text)))
            //{
            //    lblMessage.Text ="يرجى اختيار الفترة الزمنية";
            //}else 
            {
               
                
                SqlCommand cmd = new SqlCommand();
                DataTable dt1 = new DataTable();
                SqlCommand cmd2 = new SqlCommand();
                cmd2.CommandText = "select [DepartmentID] from [HR].[dbo].[DepartmentTBL] where CEOAssetID in (681, 2598, 883, 4066, 2601) and isActive = 1";
                DataTable dt2 = new DataTable();
                dt2 = TBIMaster.GetData(cmd2, lblMessage);
                //List<int> depList = (from row in dt2.AsEnumerable() select Convert.ToInt32(row["DepartmentID"])).ToList();
                SqlCommand cmd3 = new SqlCommand();
                cmd3.CommandText = "select [managerEmpID] from [HR].[dbo].[EmpRatingTBL] where [managerEmpID] in (681, 2598, 883, 4066, 2601, 2676)";
                DataTable dt3 = new DataTable();
                dt3 = TBIMaster.GetData(cmd3, lblMessage);

                if (depID == "41" || UserID=="1143")
                {//hr
                    

                    //                    for (int i = 0; i <= dt2.Rows.Count; i++)
                    //                    {
                    //                        if (ddlIDepartment.SelectedValue == dt2.Rows[i]["DepartmentID"].ToString())
                    //                        {
                    //                            cmd.CommandText = @"SELECT HR.dbo.BranchsTBL.BranchDescAR as [الفرع], HR.dbo.DepartmentTBL.DepartmentDescAR as [القسم], [FullName] as [الاسم الكامل],
                    //                                                Ceo.degreeDesc as [درجة الموظف]  
                    //        , HR.dbo.EmployeesVW.Name	as [اسم المدير]  ,[submitDate] as [تاريخ الادخال] FROM [HR].[dbo].[EmpRatingTBL]
                    //	  LEFT JOIN HR.dbo.BranchsTBL ON [HR].[dbo].[EmpRatingTBL].branchID = HR.dbo.BranchsTBL.BranchID 
                    //	  LEFT JOIN HR.dbo.DepartmentTBL ON [HR].[dbo].[EmpRatingTBL].departmentID = HR.dbo.DepartmentTBL.DepartmentID
                    //	  LEFT JOIN [HR].[dbo].[EmpRateDegreeTBL] as Ceo ON [HR].[dbo].[EmpRatingTBL].rateDegreeCeoID = [Ceo].degreeID
                    //	  LEFT JOIN [HR].[dbo].EmployeesVW on [HR].[dbo].[EmpRatingTBL].managerEmpID = [HR].[dbo].EmployeesVW.EmpID
                    //	   where [HR].[dbo].[EmpRatingTBL].[departmentID] = @departmentID and [HR].[dbo].[EmpRatingTBL].[branchID] = @branchID and submitDate between @startDate and @EndDate";
                    //                            cmd.Parameters.AddWithValue("@departmentID", ddlIDepartment.SelectedValue);
                    //                            cmd.Parameters.AddWithValue("@branchID", ddlIBranchs.SelectedValue);
                    //                            cmd.Parameters.AddWithValue("@startDate", txtStartDate.Text);
                    //                            cmd.Parameters.AddWithValue("@EndDate", txtEndDate.Text);
                    //                            dt1 = TBIMaster.GetData(cmd, lblMessage);
                    //                            GridView1.Columns.Clear();
                    //                            TBIMaster.AddColumnsToGridView(GridView1, dt1);
                    //                            GridView1.DataSource = dt1;
                    //                            GridView1.DataBind();
                    //    x = "1";
                    //    break;
                    //}

                    //if (x == "0")
                    //{
                    SqlCommand cmdCheck = new SqlCommand();
                    var query = new StringBuilder();
                    query.Append(@"SELECT [doneID]
      ,[branchID]
      ,[DepartmentID]
      ,[isDone]
      ,[isRating]
      ,[is16Rating]
      ,[submitUser]
      ,[submitDate]
  FROM [HR].[dbo].[RatingDone] where isdone =1 and israting = 1");
                    if (ddlIBranchs.SelectedValue != "0")
                    {
                        query.Append(" and [branchID] = @branchID");
                        
                        cmdCheck.Parameters.AddWithValue("@branchID", ddlIBranchs.SelectedValue);
                    
                       
                    }
                    if (ddlIDepartment.SelectedValue != "0")
                    {
                        query.Append(" and [DepartmentID]=@departmentID");
                        if (ddlIBranchs.SelectedValue == "1")
                        {
                            cmdCheck.Parameters.AddWithValue("@departmentID", ddlIDepartment.SelectedValue);
                        }
                        else
                        {
                            cmdCheck.Parameters.AddWithValue("@departmentID", "71");
                        }
                    }

                    if ((!string.IsNullOrEmpty(txtStartDate.Text)) || (!string.IsNullOrEmpty(txtEndDate.Text)))
                    {
                        query.Append(" and CAST(submitDate AS DATE) between @startDate and @EndDate");
                        cmdCheck.Parameters.AddWithValue("@startDate", txtStartDate.Text);
                        cmdCheck.Parameters.AddWithValue("@EndDate", txtEndDate.Text);
                    }



                    cmdCheck.CommandText = query.ToString();

                    DataTable dt = new DataTable();

                    dt = TBIMaster.GetData(cmdCheck, lblMessage);

                    if (dt.Rows.Count <= 0)
                    {
                        lblMessage.Text = "التقييمات الخاصة بهذا القسم/الفرع غير كاملة لحد الان";
                        GridView1.Visible = false;

                    }



//                    SqlCommand cmdCheck = new SqlCommand(@"SELECT [doneID]
//      ,[branchID]
//      ,[DepartmentID]
//      ,[isDone]
//      ,[isRating]
//      ,[is16Rating]
//      ,[submitUser]
//      ,[submitDate]
//  FROM [HR].[dbo].[RatingDone] where [branchID]=@branchID and [DepartmentID]=@departmentID and israting = 1 and isdone =1 and CAST(submitDate AS DATE) between @startDate and @EndDate");
//                    //cmdCheck.Parameters.AddWithValue("@userID",UserID);
//                    if (ddlIBranchs.SelectedValue == "1")
//                    {
//                        cmdCheck.Parameters.AddWithValue("@departmentID", ddlIDepartment.SelectedValue);
//                    }
//                    else
//                    {
//                        cmdCheck.Parameters.AddWithValue("@departmentID", "71");
//                    }
//                    cmdCheck.Parameters.AddWithValue("@branchID", ddlIBranchs.SelectedValue);
//                    cmdCheck.Parameters.AddWithValue("@startDate", txtStartDate.Text);
//                    cmdCheck.Parameters.AddWithValue("@EndDate", txtEndDate.Text);

//                    DataTable dt = new DataTable();

//                    dt = TBIMaster.GetData(cmdCheck, lblMessage);

//                    if (dt.Rows.Count <= 0)
//                    {
//                        lblMessage.Text = "التقييمات الخاصة بهذا القسم/الفرع غير كاملة لحد الان";
//                        GridView1.Visible = false;

//                    }
                    else
                    {
                        GridView1.Visible = true;
                        SqlCommand cmd6 = new SqlCommand();
                        cmd6.CommandText = @"  select count(rateDegree)
	                               from [HR].[dbo].[EmpRatingTBL]
	                               where rateDegree = 1 and  CAST(submitDate AS DATE) between @startDate and @EndDate
                                    and [HR].[dbo].[EmpRatingTBL].[departmentID] = @departmentID and [HR].[dbo].[EmpRatingTBL].[branchID] = @branchID";

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

                        SqlCommand cmd7 = new SqlCommand();
                        cmd7.CommandText = @"  select count(rateDegree)
	                               from [HR].[dbo].[EmpRatingTBL]
	                               where rateDegree = 2 and CAST(submitDate AS DATE) between @startDate and @EndDate
                                    and [HR].[dbo].[EmpRatingTBL].[departmentID] = @departmentID and [HR].[dbo].[EmpRatingTBL].[branchID] = @branchID";

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
                        cmd4.CommandText = @"  select count(rateDegree)
	                               from [HR].[dbo].[EmpRatingTBL]
	                               where rateDegree = 3 and CAST(submitDate AS DATE) between @startDate and @EndDate
                                     and [HR].[dbo].[EmpRatingTBL].[departmentID] = @departmentID and [HR].[dbo].[EmpRatingTBL].[branchID] = @branchID";

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
                        cmd5.CommandText = @"  select count(rateDegree)
	                               from [HR].[dbo].[EmpRatingTBL]
	                               where rateDegree = 4 and CAST(submitDate AS DATE) between @startDate and @EndDate
                                     and [HR].[dbo].[EmpRatingTBL].[departmentID] = @departmentID and [HR].[dbo].[EmpRatingTBL].[branchID] = @branchID";

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
                        cmd8.CommandText = @"  select count(rateDegree)
	                               from [HR].[dbo].[EmpRatingTBL]
	                               where rateDegree = 5 and CAST(submitDate AS DATE) between @startDate and @EndDate
                                     and [HR].[dbo].[EmpRatingTBL].[departmentID] = @departmentID and [HR].[dbo].[EmpRatingTBL].[branchID] = @branchID";
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




                        var query1 = new StringBuilder();
                        query1.Append(@"SELECT HR.dbo.BranchsTBL.BranchDescAR as [الفرع], HR.dbo.DepartmentTBL.DepartmentDescAR as [القسم], [FullName] as [اسم الموظف],[submitDate] as [تاريخ الادخال],[sum] as [مجموع التقييم 100],R.degreeDesc as [درجة التقييم]
       ,Ceo.degreeDesc as [درجة التقييم],[responsibility] as [القدرة على تنفيذ الاعمال وتحمل المسؤولية 30],[confidentiality] as [المحافظة على سرية المعلومات 20],[instructions] as [الالتزام بالتوجيهات والتعليمات 15]
      ,[seriousness] as [الاهتمام والجدية في العمل 15],[relationships] as [العلاقة مع زملائه ورئيسه المباشر 10],[commitment] as [الالتزام بالدوام الرسمي 10]  
        , HR.dbo.EmployeesVW.Name	as [اسم المدير] FROM [HR].[dbo].[EmpRatingTBL]
	  LEFT JOIN HR.dbo.BranchsTBL ON [HR].[dbo].[EmpRatingTBL].branchID = HR.dbo.BranchsTBL.BranchID 
	  LEFT JOIN HR.dbo.DepartmentTBL ON [HR].[dbo].[EmpRatingTBL].departmentID = HR.dbo.DepartmentTBL.DepartmentID
	  LEFT JOIN [HR].[dbo].[EmpRateDegreeTBL] as R ON [HR].[dbo].[EmpRatingTBL].rateDegree = R.degreeID
	  LEFT JOIN [HR].[dbo].EmployeesVW on [HR].[dbo].[EmpRatingTBL].managerEmpID = [HR].[dbo].EmployeesVW.EmpID
      LEFT JOIN [HR].[dbo].[EmpRateDegreeTBL] as Ceo ON [HR].[dbo].[EmpRatingTBL].rateDegreeCeoID = [Ceo].degreeID where [HR].[dbo].[EmpRatingTBL].[FullName] like  '%' + @FullName + '%'");
                      
                        if (ddlIBranchs.SelectedValue != "0")
                        {
                            query1.Append(" and [HR].[dbo].[EmpRatingTBL].[branchID] = @branchID");

                            cmd.Parameters.AddWithValue("@branchID", ddlIBranchs.SelectedValue);


                        }
                        if (ddlIDepartment.SelectedValue != "0")
                        {
                            query1.Append(" and [HR].[dbo].[EmpRatingTBL].[departmentID]=@departmentID");
                            if (ddlIBranchs.SelectedValue == "1")
                            {
                                cmd.Parameters.AddWithValue("@departmentID", ddlIDepartment.SelectedValue);
                            }
                            else
                            {
                                cmd.Parameters.AddWithValue("@departmentID", "71");
                            }
                        }

                        if ((!string.IsNullOrEmpty(txtStartDate.Text)) || (!string.IsNullOrEmpty(txtEndDate.Text)))
                        {
                            query1.Append(" and CAST(submitDate AS DATE) between @startDate and @EndDate");
                            cmd.Parameters.AddWithValue("@startDate", txtStartDate.Text);
                            cmd.Parameters.AddWithValue("@EndDate", txtEndDate.Text);
                        }

                        cmd.Parameters.AddWithValue("@FullName", txtNameSearch.Text);
                        query1.Append(" order by [HR].[dbo].[EmpRatingTBL].[branchID],[HR].[dbo].[EmpRatingTBL].departmentID");
                        cmd.CommandText = query1.ToString();







//                        cmd.CommandText = @"SELECT HR.dbo.BranchsTBL.BranchDescAR as [الفرع], HR.dbo.DepartmentTBL.DepartmentDescAR as [القسم], [FullName] as [اسم الموظف],[submitDate] as [تاريخ الادخال],[sum] as [مجموع التقييم 100],R.degreeDesc as [درجة التقييم]
//       ,Ceo.degreeDesc as [درجة التقييم],[responsibility] as [القدرة على تنفيذ الاعمال وتحمل المسؤولية 30],[confidentiality] as [المحافظة على سرية المعلومات 20],[instructions] as [الالتزام بالتوجيهات والتعليمات 15]
//      ,[seriousness] as [الاهتمام والجدية في العمل 15],[relationships] as [العلاقة مع زملائه ورئيسه المباشر 10],[commitment] as [الالتزام بالدوام الرسمي 10]  
//        , HR.dbo.EmployeesVW.Name	as [اسم المدير] FROM [HR].[dbo].[EmpRatingTBL]
//	  LEFT JOIN HR.dbo.BranchsTBL ON [HR].[dbo].[EmpRatingTBL].branchID = HR.dbo.BranchsTBL.BranchID 
//	  LEFT JOIN HR.dbo.DepartmentTBL ON [HR].[dbo].[EmpRatingTBL].departmentID = HR.dbo.DepartmentTBL.DepartmentID
//	  LEFT JOIN [HR].[dbo].[EmpRateDegreeTBL] as R ON [HR].[dbo].[EmpRatingTBL].rateDegree = R.degreeID
//	  LEFT JOIN [HR].[dbo].EmployeesVW on [HR].[dbo].[EmpRatingTBL].managerEmpID = [HR].[dbo].EmployeesVW.EmpID
//      LEFT JOIN [HR].[dbo].[EmpRateDegreeTBL] as Ceo ON [HR].[dbo].[EmpRatingTBL].rateDegreeCeoID = [Ceo].degreeID
//
//	   where [HR].[dbo].[EmpRatingTBL].[departmentID] = @departmentID and [HR].[dbo].[EmpRatingTBL].[branchID] = @branchID and CAST(submitDate AS DATE) between @startDate and @EndDate and [HR].[dbo].[EmpRatingTBL].[FullName] like  '%' + @FullName + '%'";

//                        if ((ddlIBranchs.SelectedIndex == 0) & (ddlIDepartment.SelectedIndex == 0) & (string.IsNullOrEmpty(txtStartDate.Text)) & (string.IsNullOrEmpty(txtEndDate.Text)))
//                        {
//                            cmd.CommandText = "";
//                            cmd.CommandText = @"SELECT HR.dbo.BranchsTBL.BranchDescAR as [الفرع], HR.dbo.DepartmentTBL.DepartmentDescAR as [القسم], [FullName] as [اسم الموظف],[submitDate] as [تاريخ الادخال],[sum] as [مجموع التقييم 100],R.degreeDesc as [درجة التقييم]
//       ,Ceo.degreeDesc as [درجة التقييم],[responsibility] as [القدرة على تنفيذ الاعمال وتحمل المسؤولية 30],[confidentiality] as [المحافظة على سرية المعلومات 20],[instructions] as [الالتزام بالتوجيهات والتعليمات 15]
//      ,[seriousness] as [الاهتمام والجدية في العمل 15],[relationships] as [العلاقة مع زملائه ورئيسه المباشر 10],[commitment] as [الالتزام بالدوام الرسمي 10]  
//        , HR.dbo.EmployeesVW.Name	as [اسم المدير] FROM [HR].[dbo].[EmpRatingTBL]
//	  LEFT JOIN HR.dbo.BranchsTBL ON [HR].[dbo].[EmpRatingTBL].branchID = HR.dbo.BranchsTBL.BranchID 
//	  LEFT JOIN HR.dbo.DepartmentTBL ON [HR].[dbo].[EmpRatingTBL].departmentID = HR.dbo.DepartmentTBL.DepartmentID
//	  LEFT JOIN [HR].[dbo].[EmpRateDegreeTBL] as R ON [HR].[dbo].[EmpRatingTBL].rateDegree = R.degreeID
//	  LEFT JOIN [HR].[dbo].EmployeesVW on [HR].[dbo].[EmpRatingTBL].managerEmpID = [HR].[dbo].EmployeesVW.EmpID
//      LEFT JOIN [HR].[dbo].[EmpRateDegreeTBL] as Ceo ON [HR].[dbo].[EmpRatingTBL].rateDegreeCeoID = [Ceo].degreeID
//
//	   where  [HR].[dbo].[EmpRatingTBL].[FullName] like  '%' + @FullName + '%' order by [HR].[dbo].[EmpRatingTBL].[branchID],[HR].[dbo].[EmpRatingTBL].departmentID";


//                            cmd.Parameters.AddWithValue("@FullName", txtNameSearch.Text);
//                        }
//                        else
//                            if (ddlIBranchs.SelectedValue == "1")
//                            {
//                                cmd.Parameters.AddWithValue("@departmentID", ddlIDepartment.SelectedValue);
//                                cmd.Parameters.AddWithValue("@branchID", ddlIBranchs.SelectedValue);
//                                cmd.Parameters.AddWithValue("@startDate", txtStartDate.Text);
//                                cmd.Parameters.AddWithValue("@EndDate", txtEndDate.Text);
//                                cmd.Parameters.AddWithValue("@FullName", txtNameSearch.Text);
//                            }
//                            else
//                            {
//                                cmd.Parameters.AddWithValue("@departmentID", "71");
//                                cmd.Parameters.AddWithValue("@branchID", ddlIBranchs.SelectedValue);
//                                cmd.Parameters.AddWithValue("@startDate", txtStartDate.Text);
//                                cmd.Parameters.AddWithValue("@EndDate", txtEndDate.Text);
//                                cmd.Parameters.AddWithValue("@FullName", txtNameSearch.Text);
//                            }

                        dt1 = TBIMaster.GetData(cmd, lblMessage);
                        GridView1.Columns.Clear();
                        TBIMaster.AddColumnsToGridView(GridView1, dt1);
                        GridView1.DataSource = dt1;
                        GridView1.DataBind();

                        GridView1.Columns[3].ItemStyle.Width = 20;
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
                //    }

                //}
                else if (depID != "41")
                {
                    if ((string.IsNullOrEmpty(txtStartDate.Text)) || (string.IsNullOrEmpty(txtEndDate.Text)))
                    {
                        lblMessage.Text = "يرجى اختيار الفترة الزمنية";
                    }
                    else {
                    for (int i = 0; i < dt3.Rows.Count; i++)
                    {
                        if (EmpID == dt3.Rows[i]["managerEmpID"].ToString())
                        {
                            cmd.CommandText = @"SELECT HR.dbo.BranchsTBL.BranchDescAR as [الفرع], HR.dbo.DepartmentTBL.DepartmentDescAR as [القسم], [FullName] as [اسم الموظف],
                                                Ceo.degreeDesc as [درجة التقييم]  
        , HR.dbo.EmployeesVW.Name	as [اسم المدير]  ,[submitDate] as [تاريخ الادخال]  FROM [HR].[dbo].[EmpRatingTBL]
	  LEFT JOIN HR.dbo.BranchsTBL ON [HR].[dbo].[EmpRatingTBL].branchID = HR.dbo.BranchsTBL.BranchID 
	  LEFT JOIN HR.dbo.DepartmentTBL ON [HR].[dbo].[EmpRatingTBL].departmentID = HR.dbo.DepartmentTBL.DepartmentID
	  LEFT JOIN [HR].[dbo].[EmpRateDegreeTBL] as Ceo ON [HR].[dbo].[EmpRatingTBL].rateDegreeCeoID = [Ceo].degreeID
	  LEFT JOIN [HR].[dbo].EmployeesVW on [HR].[dbo].[EmpRatingTBL].managerEmpID = [HR].[dbo].EmployeesVW.EmpID
	   where [HR].[dbo].[EmpRatingTBL].[departmentID] = @departmentID and [HR].[dbo].[EmpRatingTBL].[branchID] = @branchID and CAST(submitDate AS DATE) between @startDate and @EndDate";
                            cmd.Parameters.AddWithValue("@departmentID", depID);
                            cmd.Parameters.AddWithValue("@branchID", BranchID);
                            cmd.Parameters.AddWithValue("@startDate", txtStartDate.Text);
                            cmd.Parameters.AddWithValue("@EndDate", txtEndDate.Text);
                            dt1 = TBIMaster.GetData(cmd, lblMessage);
                            GridView1.Columns.Clear();
                            TBIMaster.AddColumnsToGridView(GridView1, dt1);
                            GridView1.DataSource = dt1;
                            GridView1.DataBind();
                            if (GridView1.Rows.Count == 0)
                            {
                                lblMessage.Text = "لم يتم العثور على نتائج";
                            }
                            y = "1";
                            break;
                           


                        }
                    }

                        //                        else if (EmpID != dt3.Rows[i]["managerEmpID"].ToString())
                        //                        {
                        //                            cmd.CommandText = @"SELECT HR.dbo.BranchsTBL.BranchDescAR as [الفرع], HR.dbo.DepartmentTBL.DepartmentDescAR as [القسم], [FullName] as [اسم الموظف],[responsibility] as [القدرة على تنفيذ الاعمال وتحمل المسؤولية 30],[confidentiality] as [المحافظة على سرية المعلومات 20],[instructions] as [الالتزام بالتوجيهات والتعليمات 15]
                        //      ,[seriousness] as [الاهتمام والجدية في العمل 15],[relationships] as [العلاقة مع زملائه ورئيسه المباشر 10],[commitment] as [الالتزام بالدوام الرسمي 10],[sum] as [مجموع التقييم 100],R.degreeDesc as [درجة التقييم]
                        //      ,HR.dbo.EmployeesVW.Name	 as [اسم المدير] ,[submitDate] as [تاريخ الادخال] FROM [HR].[dbo].[EmpRatingTBL]
                        //	  LEFT JOIN HR.dbo.BranchsTBL ON [HR].[dbo].[EmpRatingTBL].branchID = HR.dbo.BranchsTBL.BranchID 
                        //	  LEFT JOIN HR.dbo.DepartmentTBL ON [HR].[dbo].[EmpRatingTBL].departmentID = HR.dbo.DepartmentTBL.DepartmentID
                        //	  LEFT JOIN [HR].[dbo].[EmpRateDegreeTBL] as R ON [HR].[dbo].[EmpRatingTBL].rateDegree = R.degreeID
                        //	  LEFT JOIN [HR].[dbo].EmployeesVW on [HR].[dbo].[EmpRatingTBL].managerEmpID = [HR].[dbo].EmployeesVW.EmpID
                        //	   where [HR].[dbo].[EmpRatingTBL].[departmentID] = @departmentID and [HR].[dbo].[EmpRatingTBL].[branchID] = @branchID and submitDate between @startDate and @EndDate";
                        //                            cmd.Parameters.AddWithValue("@departmentID", ddlIDepartment.SelectedValue);
                        //                            cmd.Parameters.AddWithValue("@branchID", ddlIBranchs.SelectedValue);
                        //                            cmd.Parameters.AddWithValue("@startDate", txtStartDate.Text);
                        //                            cmd.Parameters.AddWithValue("@EndDate", txtEndDate.Text);
                        //                            dt1 = TBIMaster.GetData(cmd, lblMessage);
                        //                            GridView1.Columns.Clear();
                        //                            TBIMaster.AddColumnsToGridView(GridView1, dt1);
                        //                            GridView1.DataSource = dt1;
                        //                            GridView1.DataBind();
                        //                            y = "1";
                        //                            break;
                        //                        }

                        if (y == "0")
                        {
                            cmd.CommandText = @"SELECT HR.dbo.BranchsTBL.BranchDescAR as [الفرع], HR.dbo.DepartmentTBL.DepartmentDescAR as [القسم], [FullName] as [اسم الموظف],[sum] as [مجموع التقييم 100],R.degreeDesc as [درجة التقييم],[responsibility] as [القدرة على تنفيذ الاعمال وتحمل المسؤولية 30],[confidentiality] as [المحافظة على سرية المعلومات 20],[instructions] as [الالتزام بالتوجيهات والتعليمات 15]
      ,[seriousness] as [الاهتمام والجدية في العمل 15],[relationships] as [العلاقة مع زملائه ورئيسه المباشر 10],[commitment] as [الالتزام بالدوام الرسمي 10]
      ,HR.dbo.EmployeesVW.Name	 as [اسم المدير] ,[submitDate] as [تاريخ الادخال] FROM [HR].[dbo].[EmpRatingTBL]
	  LEFT JOIN HR.dbo.BranchsTBL ON [HR].[dbo].[EmpRatingTBL].branchID = HR.dbo.BranchsTBL.BranchID 
	  LEFT JOIN HR.dbo.DepartmentTBL ON [HR].[dbo].[EmpRatingTBL].departmentID = HR.dbo.DepartmentTBL.DepartmentID
	  LEFT JOIN [HR].[dbo].[EmpRateDegreeTBL] as R ON [HR].[dbo].[EmpRatingTBL].rateDegree = R.degreeID
	  LEFT JOIN [HR].[dbo].EmployeesVW on [HR].[dbo].[EmpRatingTBL].managerEmpID = [HR].[dbo].EmployeesVW.EmpID
	   where [HR].[dbo].[EmpRatingTBL].[departmentID] = @departmentID and [HR].[dbo].[EmpRatingTBL].[branchID] = @branchID and CAST(submitDate AS DATE) between @startDate and @EndDate";
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
                                GridView1.Columns[1].Visible=false;
                            }
                            if (GridView1.Rows.Count == 0)
                            {
                                lblMessage.Text = "لم يتم العثور على نتائج";
                            }

                 
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
        //protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
        //{
        //    GridView2.PageIndex = e.NewPageIndex;
        //}

//        protected void GridView2_PageIndexChanged(object sender, EventArgs e)
//        {
//            GetNotGrid();
//        }

//        private void GetNotGrid()
//        {
//            if (chk.Checked)
//            {
//                SqlCommand cmd = new SqlCommand();
//                cmd.CommandText = @"  SELECT HR.dbo.BranchsTBL.BranchDescAR as [الفرع], HR.dbo.DepartmentTBL.DepartmentDescAR as [القسم], [FullName] as [اسم الموظف] FROM [HR].[dbo].[EmployeeRatingTempTBL]
//	  LEFT JOIN HR.dbo.BranchsTBL ON [HR].[dbo].[EmployeeRatingTempTBL].branchID = HR.dbo.BranchsTBL.BranchID 
//	  LEFT JOIN HR.dbo.DepartmentTBL ON [HR].[dbo].[EmployeeRatingTempTBL].departmentID = HR.dbo.DepartmentTBL.DepartmentID
//	   where rateDegree=0 order by [FullName]";
//                DataTable dt1 = new DataTable();
//                dt1 = TBIMaster.GetData(cmd, lblMessage);
//                GridView2.Columns.Clear();
//                TBIMaster.AddColumnsToGridView(GridView2, dt1);
//                GridView2.DataSource = dt1;
//                GridView2.DataBind();
//                if (GridView2.Rows.Count == 0)
//                {
//                    lblMessage.Text = "تم تقييم جميع الموظفين";
//                }
//            }
//            else
//            {

//                SqlCommand cmd = new SqlCommand();
//                cmd.CommandText = @"SELECT HR.dbo.BranchsTBL.BranchDescAR as [الفرع], HR.dbo.DepartmentTBL.DepartmentDescAR as [القسم], [FullName] as [اسم الموظف],[sum] as [مجموع التقييم 100],R.degreeDesc as [درجة التقييم]
//       ,Ceo.degreeDesc as [درجة التقييم],[responsibility] as [القدرة على تنفيذ الاعمال وتحمل المسؤولية 30],[confidentiality] as [المحافظة على سرية المعلومات 20],[instructions] as [الالتزام بالتوجيهات والتعليمات 15]
//      ,[seriousness] as [الاهتمام والجدية في العمل 15],[relationships] as [العلاقة مع زملائه ورئيسه المباشر 10],[commitment] as [الالتزام بالدوام الرسمي 10]  
//        , HR.dbo.EmployeesVW.Name	as [اسم المدير],[submitDate] as [تاريخ الادخال] FROM [HR].[dbo].[EmpRatingTBL]
//	  LEFT JOIN HR.dbo.BranchsTBL ON [HR].[dbo].[EmpRatingTBL].branchID = HR.dbo.BranchsTBL.BranchID 
//	  LEFT JOIN HR.dbo.DepartmentTBL ON [HR].[dbo].[EmpRatingTBL].departmentID = HR.dbo.DepartmentTBL.DepartmentID
//	  LEFT JOIN [HR].[dbo].[EmpRateDegreeTBL] as R ON [HR].[dbo].[EmpRatingTBL].rateDegree = R.degreeID
//	  LEFT JOIN [HR].[dbo].EmployeesVW on [HR].[dbo].[EmpRatingTBL].managerEmpID = [HR].[dbo].EmployeesVW.EmpID
//      LEFT JOIN [HR].[dbo].[EmpRateDegreeTBL] as Ceo ON [HR].[dbo].[EmpRatingTBL].rateDegreeCeoID = [Ceo].degreeID order by [FullName]";
//                DataTable dt1 = new DataTable();
//                dt1 = TBIMaster.GetData(cmd, lblMessage);
//                GridView2.Columns.Clear();
//                TBIMaster.AddColumnsToGridView(GridView2, dt1);
//                GridView2.DataSource = dt1;
//                GridView2.DataBind();
//                if (GridView2.Rows.Count == 0)
//                {
//                    lblMessage.Text = "dd";
//                }
//            }
//        }

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

        //protected void chkNot_CheckedChanged(object sender, EventArgs e)
        //{
           
        //        GetNotGrid();
          
        //}

        //protected void btnNotRated_Click(object sender, EventArgs e)
        //{
        //    GetNotGrid();
        //    Response.Clear();

        //    Response.AddHeader("content-disposition", "attachment;filename=Report " + DateTime.Now.ToString("yyyy-MM-dd") + ".xls");
        //    Response.Charset = "";
        //    this.EnableViewState = false;
        //    Response.ContentType = "application/vnd.ms-excel";


        //    System.IO.StringWriter stringWrite = new System.IO.StringWriter();

        //    System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
        //    ////Turn OFF paging and bind the data back to Gridview
        //    GridView2.AllowPaging = false;
        //    GridView2.DataBind(); //change method which you are using to bind your gridview

        //    // Read Style file (css) here and add to response 
        //    FileInfo fi = new FileInfo(HttpContext.Current.Server.MapPath("~/CSS/Main.css"));
        //    StringBuilder sb = new StringBuilder();
        //    StreamReader sr = fi.OpenText();
        //    while (sr.Peek() >= 0)
        //    {
        //        sb.Append(sr.ReadLine());
        //    }
        //    sr.Close();

        //    GridView2.RenderControl(htmlWrite);
        //    GridView2.HeaderStyle.Font.Bold = true;
        //    Response.Write("<html dir='rtl'><head><style type='text/css'>" + sb.ToString() + "</style></head><body align='center'>" + stringWrite.ToString() + "</body></html>");
        //    Response.End();
        //    ////Turn ON paging and bind the data back to Gridview
        //    GridView2.AllowPaging = true;
        //    GridView2.DataBind();
        //}

       
    }
}