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

namespace HR_Salaries.Pages.Employee
{
    public partial class Emp16Rating : System.Web.UI.Page
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
                    SqlCommand cmd5 = new SqlCommand();
                    cmd5.CommandText = @"select PageOpen from [EmployeeRatingTempTBL] where (IsManager = 1 or IsCEO=1 or IsCEOAssist=1) and page16Open=0";

                    DataTable dt = new DataTable();

                    dt = TBIMaster.GetData(cmd5, lblMessage);

                    if (dt.Rows.Count > 0)
                    {
                        Session["msg"] = "9";
                        Response.Redirect("~/Pages/Default.aspx");

                    }
                    else
                    {
                        TBIMaster.FillCombo("degreeID", "degreeDesc", "EmpRateDegreeTBL", ddlDegree, lblMessage);
                        GetGrid();
                    }
                }
                lblMessage.Text = "";
            }

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
            // and [submitDate] >= GETDATE() - 10
            //هاي الفوك مضيوفة بعد الquery
            // بس مسحتها علمود لايطلعلهم اي شي بالصفحة خلال السنة
            //من يجي شهر الثالث لازم اضيفها :D

            //هاي رجعتها لان حسويها عال pageOpen
             SqlCommand cmdCheck = new SqlCommand(@"SELECT [doneID]
      ,[branchID]
      ,[DepartmentID]
      ,[isDone]
      ,[isRating]
      ,[is16Rating]
      ,[submitUser]
      ,[submitDate]
  FROM [HR].[dbo].[RatingDone] where submitUser=@userID and is16rating = 1 and isdone =1 and [submitDate] >= GETDATE() - 10");
             cmdCheck.Parameters.AddWithValue("@userID",UserID);

            DataTable dt = new DataTable();

            dt = TBIMaster.GetData(cmdCheck, lblMessage);

            if (dt.Rows.Count > 0)
            {
                    Session["msg"] = "9";
                    Response.Redirect("~/Pages/Default.aspx");
                
            }
            else
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

        protected void BtnCancel_Click(object sender, EventArgs e)
        {
            //GridView1.SelectedIndex = -1;
            Response.Redirect("~/Pages/Employee/Emp16Rating.aspx");

        }

        protected void GridView1_PageIndexChanged(object sender, EventArgs e)
        {
            GetGrid();
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
        }

        protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            
            int index = e.NewSelectedIndex;
            int ID = Convert.ToInt32(GridView1.Rows[index].Cells[1].Text);
            hfEmpID.Value = ID.ToString();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = @"SELECT [EmpID]  ,[FullName] 
                                   FROM [HR].[dbo].[EmployeeRatingTempTBL] where EmpID = @EmpID ";
            cmd.Parameters.AddWithValue("@EmpID", hfEmpID.Value);

            DataTable dt = TBIMaster.GetData(cmd, lblMessage);
            //myReader = cmd.ExecuteReader();

            if (dt.Rows.Count > 0)
            {
                txtName.Text = (dt.Rows[0]["FullName"].ToString());
                ddlDegree.Focus();

            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlDegree.Focus();
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
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
            if (string.IsNullOrEmpty(txtName.Text))
            {
                lblMessage.Text = "الرجاء اختيار احد الموظفين";
            }

            else if (ddlDegree.SelectedIndex <= 0)
            {
                lblMessage.Text = "الرجاء اختيار احد الدرجات";
            }
            else
            {
                string empCount = (Math.Ceiling(Convert.ToDouble(hfCount.Value) * 0.25)).ToString();
                string emp35Count = (Math.Ceiling(Convert.ToDouble(hfCount.Value) * 0.35)).ToString();
                string emp25Count = (Math.Ceiling(Convert.ToDouble(hfCount.Value) * 0.25)).ToString();
                string emp15Count = (Math.Ceiling(Convert.ToDouble(hfCount.Value) * 0.15)).ToString();
                //(Math.Round(Convert.ToInt64(hfCount.Value) * 0.15)).ToString();
                lblExc.Text = empCount;
                lblVery.Text = emp35Count;
                lblGood.Text = emp25Count;
                lblInter.Text = emp15Count;
                SqlCommand cmd2 = new SqlCommand();
                cmd2.CommandText = @"  select count(rateDegree16)
	                               from [HR].[dbo].[Emp16RatingTBL]
	                               where rateDegree16 = 1 and submitDate >= GETDATE() - 8 and managerEmpID16 =@EmpID";
                cmd2.Parameters.AddWithValue("@EmpID", EmpID);
                int ratecount = Convert.ToInt32(TBIMaster.ExecuteScaler(cmd2, lblMessage, HttpContext.Current.Request.Path));

                SqlCommand cmd3 = new SqlCommand();
                cmd3.CommandText = @"  select count(rateDegree16)
	                               from [HR].[dbo].[Emp16RatingTBL]
	                               where rateDegree16 = 2 and submitDate >= GETDATE() - 8 and managerEmpID16 =@EmpID";
                cmd3.Parameters.AddWithValue("@EmpID", EmpID);
                int rate35count = Convert.ToInt32(TBIMaster.ExecuteScaler(cmd3, lblMessage, HttpContext.Current.Request.Path));

                SqlCommand cmd4 = new SqlCommand();
                cmd4.CommandText = @"  select count(rateDegree16)
	                               from [HR].[dbo].[Emp16RatingTBL]
	                               where rateDegree16 = 3 and submitDate >= GETDATE() - 8 and managerEmpID16 =@EmpID";
                cmd4.Parameters.AddWithValue("@EmpID", EmpID);
                int rate25count = Convert.ToInt32(TBIMaster.ExecuteScaler(cmd4, lblMessage, HttpContext.Current.Request.Path));


                SqlCommand cmd5 = new SqlCommand();
                cmd5.CommandText = @"  select count(rateDegree16)
	                               from [HR].[dbo].[Emp16RatingTBL]
	                               where rateDegree16 = 4 and submitDate >= GETDATE() - 8 and managerEmpID16 =@EmpID";
                cmd5.Parameters.AddWithValue("@EmpID", EmpID);
                int rate15count = Convert.ToInt32(TBIMaster.ExecuteScaler(cmd5, lblMessage, HttpContext.Current.Request.Path));


                if (ddlDegree.SelectedValue == "1")
                {
                    if (ratecount < Convert.ToDouble(empCount))
                    {
                        SqlCommand cmd = new SqlCommand();
                        cmd.CommandText = @"delete from [HR].[dbo].[Emp16RatingTBL] where EmpID16 = @EmpID and submitDate >= GETDATE() - 8; INSERT INTO [HR].[dbo].[Emp16RatingTBL] ([branchID16]
      ,[departmentID16], [EmpID16],[FullName16]
                                        , [rateDegree16], [managerEmpID16], [submitUser16], [submitDate])
                                        VALUES(@branchID, @departmentID ,@EmpID, @FullName, @rateDegree , @managerEmpID, @UserID, Getdate()) SELECT SCOPE_IDENTITY(); update [HR].[dbo].[EmployeeRatingTempTBL] set rate16Degree= @rateDegree where EmpID = @EmpID;";
                        ////////////////
                        cmd.Parameters.AddWithValue("@branchID", BranchID);
                        cmd.Parameters.AddWithValue("@departmentID", depID);
                        cmd.Parameters.AddWithValue("@EmpID", hfEmpID.Value);
                        ////////////////
                        cmd.Parameters.AddWithValue("@FullName", txtName.Text);
                        cmd.Parameters.AddWithValue("@rateDegree", ddlDegree.SelectedValue);
                        cmd.Parameters.AddWithValue("@managerEmpID", EmpID);
                        cmd.Parameters.AddWithValue("@UserID", UserID);


                        int RateID = Convert.ToInt32(TBIMaster.ExecuteScaler(cmd, lblMessage, HttpContext.Current.Request.Path));
                        if (RateID > 0)
                        {
                            //GridView1.SelectedRow.Visible = false;
                            TBIMaster.Messages(lblMessage, 1);
                            txtName.Text = string.Empty;
                            ddlDegree.SelectedIndex = 0;
                            GetGrid();
                        }
                        else if (RateID == 0)
                        {
                            TBIMaster.Messages(lblMessage, 14);

                        }
                    }
                    else
                    {
                        lblMessage.Text = "تم تجاوز نسبة ال25% المسموحة للتقدير 'ممتاز' يرجى اعادة التقييم";
                    }

                    //case 2
                }
                else if (ddlDegree.SelectedValue == "2")
                {
                    if (rate35count < Convert.ToDouble(emp35Count))
                    {
                        SqlCommand cmd = new SqlCommand();
                        cmd.CommandText = @"delete from [HR].[dbo].[Emp16RatingTBL] where EmpID16 = @EmpID and submitDate >= GETDATE() - 8; INSERT INTO [HR].[dbo].[Emp16RatingTBL] ([branchID16]
      ,[departmentID16], [EmpID16],[FullName16]
                                        , [rateDegree16], [managerEmpID16], [submitUser16], [submitDate])
                                        VALUES(@branchID, @departmentID ,@EmpID, @FullName, @rateDegree , @managerEmpID, @UserID, Getdate()) SELECT SCOPE_IDENTITY(); update [HR].[dbo].[EmployeeRatingTempTBL] set rate16Degree= @rateDegree where EmpID = @EmpID;";
                        ////////////////
                        cmd.Parameters.AddWithValue("@branchID", BranchID);
                        cmd.Parameters.AddWithValue("@departmentID", depID);
                        cmd.Parameters.AddWithValue("@EmpID", hfEmpID.Value);
                        ////////////////
                        cmd.Parameters.AddWithValue("@FullName", txtName.Text);
                        cmd.Parameters.AddWithValue("@rateDegree", ddlDegree.SelectedValue);
                        cmd.Parameters.AddWithValue("@managerEmpID", EmpID);
                        cmd.Parameters.AddWithValue("@UserID", UserID);


                        int RateID = Convert.ToInt32(TBIMaster.ExecuteScaler(cmd, lblMessage, HttpContext.Current.Request.Path));
                        if (RateID > 0)
                        {
                            //GridView1.SelectedRow.Visible = false;
                            TBIMaster.Messages(lblMessage, 1);
                            txtName.Text = string.Empty;
                            ddlDegree.SelectedIndex = 0;
                            GetGrid();
                        }
                        else if (RateID == 0)
                        {
                            TBIMaster.Messages(lblMessage, 14);

                        }
                    }
                    else
                    {
                        lblMessage.Text = "تم تجاوز نسبة ال25% المسموحة للتقدير 'جيد جداً' يرجى اعادة التقييم";
                    }
                }
                else if (ddlDegree.SelectedValue == "3")
                {
                    if (rate25count < Convert.ToDouble(emp25Count))
                    {
                        SqlCommand cmd = new SqlCommand();
                        cmd.CommandText = @"delete from [HR].[dbo].[Emp16RatingTBL] where EmpID16 = @EmpID and submitDate >= GETDATE() - 8; INSERT INTO [HR].[dbo].[Emp16RatingTBL] ([branchID16]
      ,[departmentID16], [EmpID16],[FullName16]
                                        , [rateDegree16], [managerEmpID16], [submitUser16], [submitDate])
                                        VALUES(@branchID, @departmentID ,@EmpID, @FullName, @rateDegree , @managerEmpID, @UserID, Getdate()) SELECT SCOPE_IDENTITY(); update [HR].[dbo].[EmployeeRatingTempTBL] set rate16Degree= @rateDegree where EmpID = @EmpID;";
                        ////////////////
                        cmd.Parameters.AddWithValue("@branchID", BranchID);
                        cmd.Parameters.AddWithValue("@departmentID", depID);
                        cmd.Parameters.AddWithValue("@EmpID", hfEmpID.Value);
                        ////////////////
                        cmd.Parameters.AddWithValue("@FullName", txtName.Text);
                        cmd.Parameters.AddWithValue("@rateDegree", ddlDegree.SelectedValue);
                        cmd.Parameters.AddWithValue("@managerEmpID", EmpID);
                        cmd.Parameters.AddWithValue("@UserID", UserID);


                        int RateID = Convert.ToInt32(TBIMaster.ExecuteScaler(cmd, lblMessage, HttpContext.Current.Request.Path));
                        if (RateID > 0)
                        {
                            //GridView1.SelectedRow.Visible = false;
                            TBIMaster.Messages(lblMessage, 1);
                            txtName.Text = string.Empty;
                            ddlDegree.SelectedIndex = 0;
                            GetGrid();
                        }
                        else if (RateID == 0)
                        {
                            TBIMaster.Messages(lblMessage, 14);

                        }
                    }
                    else
                    {
                        lblMessage.Text = "تم تجاوز نسبة ال25% المسموحة للتقدير 'جيد' يرجى اعادة التقييم";
                    }
                }
                else if (ddlDegree.SelectedValue == "4")
                {
                    if (rate15count < Convert.ToDouble(emp15Count))
                    {
                        SqlCommand cmd = new SqlCommand();
                        cmd.CommandText = @"delete from [HR].[dbo].[Emp16RatingTBL] where EmpID16 = @EmpID and submitDate >= GETDATE() - 8; INSERT INTO [HR].[dbo].[Emp16RatingTBL] ([branchID16]
      ,[departmentID16], [EmpID16],[FullName16]
                                        , [rateDegree16], [managerEmpID16], [submitUser16], [submitDate])
                                        VALUES(@branchID, @departmentID ,@EmpID, @FullName, @rateDegree , @managerEmpID, @UserID, Getdate()) SELECT SCOPE_IDENTITY(); update [HR].[dbo].[EmployeeRatingTempTBL] set rate16Degree= @rateDegree where EmpID = @EmpID;";
                        ////////////////
                        cmd.Parameters.AddWithValue("@branchID", BranchID);
                        cmd.Parameters.AddWithValue("@departmentID", depID);
                        cmd.Parameters.AddWithValue("@EmpID", hfEmpID.Value);
                        ////////////////
                        cmd.Parameters.AddWithValue("@FullName", txtName.Text);
                        cmd.Parameters.AddWithValue("@rateDegree", ddlDegree.SelectedValue);
                        cmd.Parameters.AddWithValue("@managerEmpID", EmpID);
                        cmd.Parameters.AddWithValue("@UserID", UserID);


                        int RateID = Convert.ToInt32(TBIMaster.ExecuteScaler(cmd, lblMessage, HttpContext.Current.Request.Path));
                        if (RateID > 0)
                        {
                            //GridView1.SelectedRow.Visible = false;
                            TBIMaster.Messages(lblMessage, 1);
                            txtName.Text = string.Empty;
                            ddlDegree.SelectedIndex = 0;
                            GetGrid();
                        }
                        else if (RateID == 0)
                        {
                            TBIMaster.Messages(lblMessage, 14);

                        }
                    }
                    else
                    {
                        lblMessage.Text = "تم تجاوز نسبة ال25% المسموحة للتقدير 'ممتاز' يرجى اعادة التقييم";
                    }
                }
                else
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = @"delete from [HR].[dbo].[Emp16RatingTBL] where EmpID16 = @EmpID and submitDate >= GETDATE() - 8; INSERT INTO [HR].[dbo].[Emp16RatingTBL] ([branchID16]
      ,[departmentID16], [EmpID16],[FullName16]
                                        , [rateDegree16], [managerEmpID16], [submitUser16], [submitDate])
                                        VALUES(@branchID, @departmentID ,@EmpID, @FullName, @rateDegree , @managerEmpID, @UserID, Getdate()) SELECT SCOPE_IDENTITY(); update [HR].[dbo].[EmployeeRatingTempTBL] set rate16Degree= @rateDegree where EmpID = @EmpID;";
                    ////////////////
                    cmd.Parameters.AddWithValue("@branchID", BranchID);
                    cmd.Parameters.AddWithValue("@departmentID", depID);
                    cmd.Parameters.AddWithValue("@EmpID", hfEmpID.Value);
                    ////////////////
                    cmd.Parameters.AddWithValue("@FullName", txtName.Text);
                    cmd.Parameters.AddWithValue("@rateDegree", ddlDegree.SelectedValue);
                    cmd.Parameters.AddWithValue("@managerEmpID", EmpID);
                    cmd.Parameters.AddWithValue("@UserID", UserID);


                    int RateID = Convert.ToInt32(TBIMaster.ExecuteScaler(cmd, lblMessage, HttpContext.Current.Request.Path));
                    if (RateID > 0)
                    {
                        //GridView1.SelectedRow.Visible = false;
                        TBIMaster.Messages(lblMessage, 1);
                        txtName.Text = string.Empty;
                        ddlDegree.SelectedIndex = 0;
                        GetGrid();
                    }
                    else if (RateID == 0)
                    {
                        TBIMaster.Messages(lblMessage, 14);

                    }
                }
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void btnEnd_Click(object sender, EventArgs e)
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

            //var confirmResult = MessageBox.Show("هل تم تقييم جميع الموظفين؟ سيتم ازالة صلاحية الصفحة عند الضغط على نعم",
            //                         "Confirmation",
            //                         MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxOptions.ServiceNotification);
            //if (confirmResult == DialogResult.Yes)
            //{
            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "نعم")
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"INSERT INTO [HR].[dbo].[RatingDone] ([branchID]
      ,[DepartmentID]
      ,[isDone]
      ,[isRating]
      ,[is16Rating]
      ,[submitUser]
      ,[submitDate])
                                        VALUES(@branchID, @DepartmentID ,1, 0, 1 , @submitUser, Getdate()) SELECT SCOPE_IDENTITY();";
                ////////////////
                cmd.Parameters.AddWithValue("@branchID", BranchID);
                cmd.Parameters.AddWithValue("@departmentID", depID);
                cmd.Parameters.AddWithValue("@submitUser", UserID);
                ////////////////


                int RateID = Convert.ToInt32(TBIMaster.ExecuteScaler(cmd, lblMessage, HttpContext.Current.Request.Path));
                if (RateID > 0)
                {
                    SqlCommand cmd1 = new SqlCommand();
                    cmd1.CommandText = @"SELECT [FullName] ,[BranchDescAR] ,[DepartmentDescAR]
 
  FROM [HR].[dbo].[UsersVW]
  where ApplicationID = 1 and UserID =@userID";
                    cmd1.Parameters.AddWithValue("@userID", UserID);
                    DataTable dt = new DataTable();

                    dt = TBIMaster.GetData(cmd1, lblMessage);

                    Emp16Rating.SendEmail("hr.dept@tbiraq.com", "HR", "rafid.mahdi@tbiraq.com;  khaled.ameer@tbiraq.com;", "ali.allawi@tbiraq.com; shams.ahameed@tbiraq.com", null, "<font color=\"navy\" dir=\"rtl\" style=\"text-align:right;\"><b>تحية طيبة... <br /> تم اكمال التقييمات للفرع : ( " + dt.Rows[0]["BranchDescAR"].ToString() + ")، القسم : ( " + dt.Rows[0]["DepartmentDescAR"].ToString() + ") من قبل : ( " + dt.Rows[0]["FullName"].ToString() + ").</b></font><br />", "اكتمال التقييم");
                    Session["msg"] = "1";
                    Response.Redirect("~/Pages/Default.aspx");
                }
                else if (RateID == 0)
                {
                    TBIMaster.Messages(lblMessage, 14);

                } 
            }
            else
            {
                //do nothing
            }
//                SqlCommand cmd = new SqlCommand();
//                cmd.CommandText = @"INSERT INTO [HR].[dbo].[RatingDone] ([branchID]
//      ,[DepartmentID]
//      ,[isDone]
//      ,[isRating]
//      ,[is16Rating]
//      ,[submitUser]
//      ,[submitDate])
//                                        VALUES(@branchID, @DepartmentID ,1, 0, 1 , @submitUser, Getdate()) SELECT SCOPE_IDENTITY();";
//                ////////////////
//                cmd.Parameters.AddWithValue("@branchID", BranchID);
//                cmd.Parameters.AddWithValue("@departmentID", depID);
//                cmd.Parameters.AddWithValue("@submitUser", UserID);
//                ////////////////


//                int RateID = Convert.ToInt32(TBIMaster.ExecuteScaler(cmd, lblMessage, HttpContext.Current.Request.Path));
//                if (RateID > 0)
//                {
//                    SqlCommand cmd1 = new SqlCommand();
//                    cmd1.CommandText = @"SELECT [FullName] ,[BranchDescAR] ,[DepartmentDescAR]
// 
//  FROM [HR].[dbo].[UsersVW]
//  where ApplicationID = 1 and UserID =@userID";
//                    cmd1.Parameters.AddWithValue("@userID", UserID);
//                    DataTable dt = new DataTable();

//                    dt = TBIMaster.GetData(cmd1, lblMessage);

//                    Emp16Rating.SendEmail("hr.dept@tbiraq.com", "HR", "rafid.mahdi@tbiraq.com;  khaled.ameer@tbiraq.com;", "ali.allawi@tbiraq.com; shams.ahameed@tbiraq.com", null, "<font color=\"navy\" dir=\"rtl\" style=\"text-align:right;\"><b>تحية طيبة... <br /> تم اكمال التقييمات للفرع : ( " + dt.Rows[0]["BranchDescAR"].ToString() + ")، القسم : ( " + dt.Rows[0]["DepartmentDescAR"].ToString() + ") من قبل : ( " + dt.Rows[0]["FullName"].ToString() + ").</b></font><br />", "اكتمال التقييم");
//                    Session["msg"] = "1";
//                    Response.Redirect("~/Pages/Default.aspx");
//                }
//                else if (RateID == 0)
//                {
//                    TBIMaster.Messages(lblMessage, 14);

//                } 
            //}
            //else
            //{
            //    // If 'No', do something here.
            //}

           
        }
        public static void SendEmail(string From, string FromName, string To, string CC, System.Web.UI.WebControls.Label label, string body, string Subject)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "dbo.sp_send_dbmail";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@profile_name", "HR");
            cmd.Parameters.AddWithValue("@recipients", To);
            cmd.Parameters.AddWithValue("@copy_recipients", CC);
            //cmd.Parameters.AddWithValue("@from_address", "IMS@tbiraq.com");
            cmd.Parameters.AddWithValue("@subject", Subject);
            cmd.Parameters.AddWithValue("@body", body);
            cmd.Parameters.AddWithValue("@body_format", "HTML");
            cmd.Parameters.AddWithValue("@reply_to", From);

            TBIMaster.Execute1(cmd, "", "MSDB");
            LogEmail(From, FromName, To, CC, body, Subject);


        }

        private static void LogEmail(string From, string FromName, string To, string CC, string body, string Subject)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = @"INSERT INTO [dbo].[EmailRatingLogTBL]  ([Sender], [SenderName], [To], [CC], [Body], [Subject])
                                                          VALUES (@Sender, @SenderName, @To, @CC, @Body, @Subject)";
            cmd.Parameters.AddWithValue("@Sender", From);
            cmd.Parameters.AddWithValue("@SenderName", FromName);
            cmd.Parameters.AddWithValue("@To", To);
            cmd.Parameters.AddWithValue("@CC", CC);
            cmd.Parameters.AddWithValue("@Body", body);
            cmd.Parameters.AddWithValue("@Subject", Subject);

            TBIMaster.Execute(cmd, "", "HR");

        }
    }
}