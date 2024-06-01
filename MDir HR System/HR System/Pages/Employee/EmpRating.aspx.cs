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
    public partial class EmpRating : System.Web.UI.Page
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
            string date1 = DateTime.Now.ToString("yyyy/MM/dd");
            //string date2 = "2018/03/06";
            //string date3 = "2018/03/18";
            //int result = string.Compare(date1, date3);
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
                    //if (result != 0)
                    //{
                    // || result2 == 0
                    SqlCommand cmd5 = new SqlCommand();
                    cmd5.CommandText = @"select PageOpen from [EmployeeRatingTempTBL] where (IsManager = 1 or IsCEO=1 or IsCEOAssist=1) and pageOpen=0";

                    DataTable dt = new DataTable();

                    dt = TBIMaster.GetData(cmd5, lblMessage);

                    if (dt.Rows.Count > 0)
                    {
                        Session["msg"] = "9";
                        Response.Redirect("~/Pages/Default.aspx");

                    }
                    else
                    {

                        TBIMaster.FillCombo("degreeID", "degreeDesc", "EmpRateDegreeTBL", ddlDegreeCeo, lblMessage);
                        TBIMaster.FillCombo("degreeID", "degreeDesc", "EmpRateDegreeTBL", ddlSumDegree, lblMessage);
                        //if (UserID == "4886")
                        //{
                        //    depID = "25";
                        //}
                        GetGrid();
                        //}
                        //else
                        //{
                        //    Session["msg"] = "9";
                        //    Response.Redirect("~/Pages/Default.aspx");
                        //}
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
            SqlCommand cmdCheck = new SqlCommand(@"SELECT [doneID]
      ,[branchID]
      ,[DepartmentID]
      ,[isDone]
      ,[isRating]
      ,[is16Rating]
      ,[submitUser]
      ,[submitDate]
  FROM [HR].[dbo].[RatingDone] where submitUser=@userID and israting = 1 and isdone =1 and [submitDate] >= GETDATE() - 10");
             cmdCheck.Parameters.AddWithValue("@userID",UserID);

            DataTable dt = new DataTable();

            dt = TBIMaster.GetData(cmdCheck, lblMessage);

            if (dt.Rows.Count > 0)
            {
                //if ((dt.Rows[0]["isDone"].ToString() == "True") & (dt.Rows[0]["isRating"].ToString() == "True"))
                //{
                    Session["msg"] = "9";
                    Response.Redirect("~/Pages/Default.aspx");
                //}
            }
            else
            {

                string cond = "";
                string CmdText = @"SELECT [EmpID]  as [رقم الموظف] ,[FullName] as [اسم الموظف], [rateNotes] as [ملاحظات],  hr.dbo.EmpRateDegreeTBL.degreeDesc as[درجة التقييم]
            , isLess6Months as [اقل من 6 اشهر], hasNotice as [يوجد تنبيه],hasWarning as [يوجد انذار], hasOffwithout as [مجاز بدون راتب], hasAbsence as [غياب]
                                   FROM [HR].[dbo].[EmployeeRatingTempTBL]
                                left join hr.dbo.EmpRateDegreeTBL on [HR].[dbo].[EmployeeRatingTempTBL].[rateDegree] = hr.dbo.EmpRateDegreeTBL.degreeID";
                SqlCommand cmd = new SqlCommand();
                //if (UserID == "4886")
                //{
                //    depID = "25";
                //}
                if (BranchID == "1" & IsManager == "True" & depID != "69")
                {// for dept managers
                    //if (UserID == "1228")
                    //{
                    //    cond = condAND(cond);
                    //    cond += " DepartmentID in (33, 85) and IsManager = 0";
                    //    cmd.Parameters.AddWithValue("@depID", depID);
                    //    pnlEdit.Visible = true;
                    //    btnSubmit.Visible = true;
                    //    btnCeo.Visible = false;
                    //    pnlCeos.Visible = false;
                    //}
                    //else if (UserID == "4886")
                    //{
                    //    cond = condAND(cond);
                    //    cond += " DepartmentID in (25, 52) and IsManager = 0";
                    //    cmd.Parameters.AddWithValue("@depID", depID);
                    //    pnlEdit.Visible = true;
                    //    btnSubmit.Visible = true;
                    //    btnCeo.Visible = false;
                    //    pnlCeos.Visible = false;
                    //}
                    //else
                    //{
                    cond = condAND(cond);
                    cond += " DepartmentID = @depID and IsManager = 0";
                    cmd.Parameters.AddWithValue("@depID", depID);
                    pnlEdit.Visible = true;
                    btnSubmit.Visible = true;
                    btnCeo.Visible = false;
                    pnlCeos.Visible = false;
                    //}
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
                    pnlCeos.Visible = true;
                    btnCeo.Visible = true;
                    pnlEdit.Visible = false;
                    btnSubmit.Visible = false;
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
                    pnlCeos.Visible = true;
                    btnCeo.Visible = true;
                    pnlEdit.Visible = false;
                    btnSubmit.Visible = false;
                }
                else if (BranchID != "1" & IsManager == "True")
                {//branches managers
                    cond = condAND(cond);
                    cond += " branchID = @branchID and IsManager = 0";
                    cmd.Parameters.AddWithValue("@branchID", BranchID);
                    pnlEdit.Visible = true;
                    btnSubmit.Visible = true;
                    pnlCeos.Visible = false;
                    btnCeo.Visible = false;
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
                    for (int i = 2; i < GridView1.Columns.Count; i++)
                    {
                        //GridView1.Columns[i].ItemStyle.Width = 50;
                    }
                    foreach (GridViewRow row in GridView1.Rows)
                    {
                        LinkButton lb = (LinkButton)row.Cells[0].Controls[0];

                        //lb.Text = "اختيار";
                        lb.ForeColor = System.Drawing.Color.DarkSlateGray;
                        //lb.BackColor = System.Drawing.Color.Honeydew;
                        //lb.BorderColor = System.Drawing.Color.Aquamarine;
                        lb.Font.Size = FontUnit.XLarge;
                        lb.Font.Italic = true;
                        //lb.BorderWidth = 2;
                    }

                }
                else
                {
                    lblMessage.Text = "لم يتم العثور على موظفين.";
                }
            }

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
                ddlSumDegree.Enabled = true;
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

            else if ((string.IsNullOrEmpty(txtresp.Text)) & (string.IsNullOrEmpty(txtconf.Text)) & (string.IsNullOrEmpty(txtinst.Text)) & (string.IsNullOrEmpty(txtsers.Text)) & (string.IsNullOrEmpty(txtrel.Text)) & (string.IsNullOrEmpty(txtcomm.Text)) & (string.IsNullOrEmpty(txtSum.Text)))
            {
                lblMessage.Text = "الرجاء ملئ جميع الحقول";
            }
            else
            {
                //hatha el jawwa i added it for thaer and shahad
                string empCount = "";
                int ratecount = 0;
                //if (UserID == "1228" || UserID == "4886")
                if (UserID == "1228")
                {
                     empCount = (Math.Ceiling(Convert.ToDouble(hfCount.Value) * 0.25)).ToString();
                    SqlCommand cmd2 = new SqlCommand();
                    cmd2.CommandText = @"  select count(rateDegree)
	                               from [HR].[dbo].[EmpRatingTBL]
	                               where rateDegree = 1 and submitDate >= GETDATE() - 8 and and departmentID = @depID";
                    //
                    cmd2.Parameters.AddWithValue("@EmpID", EmpID);
                    cmd2.Parameters.AddWithValue("@depID", depID);
                     ratecount = Convert.ToInt32(TBIMaster.ExecuteScaler(cmd2, lblMessage, HttpContext.Current.Request.Path));

                }
                else
                {
                     empCount = (Math.Ceiling(Convert.ToDouble(hfCount.Value) * 0.25)).ToString();
                    SqlCommand cmd2 = new SqlCommand();
                    cmd2.CommandText = @"  select count(rateDegree)
	                               from [HR].[dbo].[EmpRatingTBL]
	                               where rateDegree = 1 and submitDate >= GETDATE() - 8 and managerEmpID =@EmpID";
                    //and departmentID = @depID
                    cmd2.Parameters.AddWithValue("@EmpID", EmpID);
                    cmd2.Parameters.AddWithValue("@depID", depID);
                     ratecount = Convert.ToInt32(TBIMaster.ExecuteScaler(cmd2, lblMessage, HttpContext.Current.Request.Path));
                }
                 if (ddlSumDegree.SelectedValue != "1")
                 {
                     SqlCommand cmd = new SqlCommand();
                     cmd.CommandText = @"delete from [HR].[dbo].[EmpRatingTBL] where EmpID = @EmpID and submitDate >= GETDATE() - 8; INSERT INTO [HR].[dbo].[EmpRatingTBL] ([branchID],[DepartmentID],[EmpID],[FullName],[responsibility],[confidentiality],[instructions],[seriousness],[relationships]
                                        ,[commitment], [sum], [rateDegree],[rateMonth], [managerEmpID], [submitUser], [submitDate])
                                        VALUES(@branchID, @departmentID,@EmpID, @FullName, @responsibility, @confidentiality, @instructions, @seriousness, @relationships,
                                        @commitment, @sum, @rateDegree ,(select ratemonth from EmployeeRatingTempTBL where EmpID = @EmpID), @managerEmpID, @UserID, Getdate()) SELECT SCOPE_IDENTITY(); update [HR].[dbo].[EmployeeRatingTempTBL] set rateDegree= @rateDegree where EmpID = @EmpID; ";
                     ////////////////
                     cmd.Parameters.AddWithValue("@branchID", BranchID);
                     cmd.Parameters.AddWithValue("@departmentID", depID);
                     cmd.Parameters.AddWithValue("@EmpID", hfEmpID.Value);
                     ////////////////
                     cmd.Parameters.AddWithValue("@FullName", txtName.Text);
                     cmd.Parameters.AddWithValue("@responsibility", txtresp.Text);
                     ////////////////
                     cmd.Parameters.AddWithValue("@confidentiality", txtconf.Text);
                     cmd.Parameters.AddWithValue("@instructions", txtinst.Text);
                     ////////////////
                     cmd.Parameters.AddWithValue("@seriousness", txtsers.Text);
                     cmd.Parameters.AddWithValue("@relationships", txtrel.Text);
                     cmd.Parameters.AddWithValue("@commitment", txtcomm.Text);
                     cmd.Parameters.AddWithValue("@sum", txtSum.Text);
                     cmd.Parameters.AddWithValue("@rateDegree", ddlSumDegree.SelectedValue);

                     cmd.Parameters.AddWithValue("@managerEmpID", EmpID);
                     cmd.Parameters.AddWithValue("@UserID", UserID);


                     int RateID = Convert.ToInt32(TBIMaster.ExecuteScaler(cmd, lblMessage, HttpContext.Current.Request.Path));
                     if (RateID > 0)
                     {
                         
                         TBIMaster.Messages(lblMessage, 1);
                         
                         txtName.Text = string.Empty;
                         txtSum.Text = string.Empty;
                         txtDegree.Text = string.Empty;
                         GetGrid();

                     }
                     else if (RateID == 0)
                     {
                         TBIMaster.Messages(lblMessage, 14);

                     }
                 }else
                if (ratecount < Convert.ToDouble(empCount))
                 {
                     SqlCommand cmd = new SqlCommand();
                     cmd.CommandText = @"delete from [HR].[dbo].[EmpRatingTBL] where EmpID = @EmpID and submitDate >= GETDATE() - 8 ; INSERT INTO [HR].[dbo].[EmpRatingTBL] ([branchID],[DepartmentID],[EmpID],[FullName],[responsibility],[confidentiality],[instructions],[seriousness],[relationships]
                                        ,[commitment], [sum], [rateDegree],[rateMonth], [managerEmpID], [submitUser], [submitDate])
                                        VALUES(@branchID, @departmentID,@EmpID, @FullName, @responsibility, @confidentiality, @instructions, @seriousness, @relationships,
                                        @commitment, @sum, @rateDegree ,(select ratemonth from EmployeeRatingTempTBL where EmpID = @EmpID), @managerEmpID, @UserID, Getdate()) SELECT SCOPE_IDENTITY(); update [HR].[dbo].[EmployeeRatingTempTBL] set rateDegree= @rateDegree where EmpID = @EmpID;";
                     ////////////////
                     cmd.Parameters.AddWithValue("@branchID", BranchID);
                     cmd.Parameters.AddWithValue("@departmentID", depID);
                     cmd.Parameters.AddWithValue("@EmpID", hfEmpID.Value);
                     ////////////////
                     cmd.Parameters.AddWithValue("@FullName", txtName.Text);
                     cmd.Parameters.AddWithValue("@responsibility", txtresp.Text);
                     ////////////////
                     cmd.Parameters.AddWithValue("@confidentiality", txtconf.Text);
                     cmd.Parameters.AddWithValue("@instructions", txtinst.Text);
                     ////////////////
                     cmd.Parameters.AddWithValue("@seriousness", txtsers.Text);
                     cmd.Parameters.AddWithValue("@relationships", txtrel.Text);
                     cmd.Parameters.AddWithValue("@commitment", txtcomm.Text);
                     cmd.Parameters.AddWithValue("@sum", txtSum.Text);
                     cmd.Parameters.AddWithValue("@rateDegree", ddlSumDegree.SelectedValue);

                     cmd.Parameters.AddWithValue("@managerEmpID", EmpID);
                     cmd.Parameters.AddWithValue("@UserID", UserID);


                     int RateID = Convert.ToInt32(TBIMaster.ExecuteScaler(cmd, lblMessage, HttpContext.Current.Request.Path));
                     if (RateID > 0)
                     {
                         //GridView1.SelectedRow.Visible = false;
                         TBIMaster.Messages(lblMessage, 1);
                         
                         txtName.Text = string.Empty;
                         txtSum.Text = string.Empty;
                         txtDegree.Text = string.Empty;
                         GetGrid();

                     }
                     else if (RateID == 0)
                     {
                         TBIMaster.Messages(lblMessage, 14);

                     }
                 }else
                 {
                    
                     lblMessage.Text = "تم تجاوز نسبة ال25% المسموحة للتقدير 'ممتاز' يرجى اعادة التقييم";
                 }
            }
        }

        protected void BtnCancel_Click(object sender, EventArgs e)
        {
            //GridView1.SelectedIndex = -1;
            Response.Redirect("~/Pages/Employee/EmpRating.aspx");
           
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
            txtresp.Text = "30";
            txtinst.Text = "15";
            txtconf.Text = "20";
            txtcomm.Text = "10";
            txtrel.Text = "10";
            txtsers.Text = "15";
            txtSum.Text = "";
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
                txtNameCeo.Text = (dt.Rows[0]["FullName"].ToString());
                txtresp.Focus();
                
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtresp.Focus();
        }
        protected void btnCeo_Click(object sender, EventArgs e)
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

            else if (ddlDegreeCeo.SelectedIndex <= 0)
            {
                lblMessage.Text = "الرجاء ملئ جميع الحقول";
            }
            else
            {
                string empCount = (Math.Round(Convert.ToInt64(hfCount.Value) * 0.25)).ToString() ;
                SqlCommand cmd2 = new SqlCommand();
                cmd2.CommandText = @"  select count(rateDegreeCeoID)
	                               from [HR].[dbo].[EmpRatingTBL]
	                               where rateDegreeCeoID = 1 and submitDate >= GETDATE() - 8 and managerEmpID =@EmpID";
                cmd2.Parameters.AddWithValue("@EmpID", EmpID);
                 int ratecount = Convert.ToInt32(TBIMaster.ExecuteScaler(cmd2, lblMessage, HttpContext.Current.Request.Path));
                 if (ddlDegreeCeo.SelectedValue != "1")
                 {
                     SqlCommand cmd = new SqlCommand();
                     cmd.CommandText = @"delete from [HR].[dbo].[EmpRatingTBL] where EmpID = @EmpID and submitDate >= GETDATE() - 8; INSERT INTO [HR].[dbo].[EmpRatingTBL] ([branchID]
      ,[departmentID], [EmpID],[FullName]
                                        ,[sumCeo], [rateDegreeCeoID],[rateMonth], [managerEmpID], [submitUser], [submitDate])
                                        VALUES(@branchID, @departmentID ,@EmpID, @FullName,@sumCeo, @rateDegreeCeoID ,(select ratemonth from EmployeeRatingTempTBL where EmpID = @EmpID), @managerEmpID, @UserID, Getdate()) SELECT SCOPE_IDENTITY(); update [HR].[dbo].[EmployeeRatingTempTBL] set rateDegree= @rateDegreeCeoID where EmpID = @EmpID;";
                     ////////////////
                     cmd.Parameters.AddWithValue("@branchID", BranchID);
                     cmd.Parameters.AddWithValue("@departmentID", depID);
                     cmd.Parameters.AddWithValue("@EmpID", hfEmpID.Value);
                     ////////////////
                     cmd.Parameters.AddWithValue("@FullName", txtNameCeo.Text);
                     cmd.Parameters.AddWithValue("@sumCeo", txtSumCeo.Text);
                     cmd.Parameters.AddWithValue("@rateDegreeCeoID", ddlDegreeCeo.SelectedValue);
                     cmd.Parameters.AddWithValue("@managerEmpID", EmpID);
                     cmd.Parameters.AddWithValue("@UserID", UserID);


                     int RateID = Convert.ToInt32(TBIMaster.ExecuteScaler(cmd, lblMessage, HttpContext.Current.Request.Path));
                     if (RateID > 0)
                     {
                         //GridView1.SelectedRow.Visible = false;
                         TBIMaster.Messages(lblMessage, 1);
                         txtNameCeo.Text = string.Empty;
                         txtSumCeo.Text = string.Empty;
                         txtDegreeCeo.Text = string.Empty;
                         GetGrid();
                     }
                     else if (RateID == 0)
                     {
                         TBIMaster.Messages(lblMessage, 14);

                     }
                 }else
                if (ratecount < Convert.ToInt32(empCount))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = @"delete from [HR].[dbo].[EmpRatingTBL] where EmpID = @EmpID and submitDate >= GETDATE() - 8; INSERT INTO [HR].[dbo].[EmpRatingTBL] ([branchID]
      ,[departmentID], [EmpID],[FullName]
                                        ,[sumCeo], [rateDegreeCeoID],[rateMonth], [managerEmpID], [submitUser], [submitDate])
                                        VALUES(@branchID, @departmentID ,@EmpID, @FullName,@sumCeo, @rateDegreeCeoID ,(select ratemonth from EmployeeRatingTempTBL where EmpID = @EmpID), @managerEmpID, @UserID, Getdate()) SELECT SCOPE_IDENTITY(); update [HR].[dbo].[EmployeeRatingTempTBL] set rateDegree= @rateDegreeCeoID where EmpID = @EmpID;";
                    ////////////////
                    cmd.Parameters.AddWithValue("@branchID", BranchID);
                    cmd.Parameters.AddWithValue("@departmentID", depID);
                    cmd.Parameters.AddWithValue("@EmpID", hfEmpID.Value);
                    ////////////////
                    cmd.Parameters.AddWithValue("@FullName", txtNameCeo.Text);
                    cmd.Parameters.AddWithValue("@sumCeo", txtSumCeo.Text);
                    cmd.Parameters.AddWithValue("@rateDegreeCeoID", ddlDegreeCeo.SelectedValue);
                    cmd.Parameters.AddWithValue("@managerEmpID", EmpID);
                    cmd.Parameters.AddWithValue("@UserID", UserID);


                    int RateID = Convert.ToInt32(TBIMaster.ExecuteScaler(cmd, lblMessage, HttpContext.Current.Request.Path));
                    if (RateID > 0)
                    {
                        //GridView1.SelectedRow.Visible = false;
                        TBIMaster.Messages(lblMessage, 1);
                        txtNameCeo.Text = string.Empty;
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
        }
        //public void Sum()
        //{
        //    if (string.IsNullOrEmpty(txtresp.Text))
        //    {
        //        txtresp.Text = "0";
        //    }
        //        else if(string.IsNullOrEmpty(txtconf.Text))
        //        {
        //            txtconf.Text = "0";
        //        }
        //         else if (string.IsNullOrEmpty(txtinst.Text))
        //        {
        //            txtinst.Text = "0";
        //        }
        //         else if (string.IsNullOrEmpty(txtrel.Text))
        //        {
        //            txtrel.Text = "0";
        //        }
        //         else if (string.IsNullOrEmpty(txtcomm.Text))
        //        {
        //            txtcomm.Text = "0";
        //        }
        //         else if (string.IsNullOrEmpty(txtsers.Text))
        //        {
        //            txtsers.Text = "0";
        //        }

        //    else
        //    {
        //        int sum = Convert.ToInt32(txtresp.Text) + Convert.ToInt32(txtinst.Text) + Convert.ToInt32(txtrel.Text) + Convert.ToInt32(txtsers.Text) + Convert.ToInt32(txtconf.Text) + Convert.ToInt32(txtcomm.Text);
        //        txtSum.Text = Convert.ToString(sum);
        //        if (Enumerable.Range(90, 100).Contains(sum))
        //        {
        //            txtDegree.Text = "ممتاز";
        //        }
        //        else if (Enumerable.Range(80, 89).Contains(sum))
        //        {
        //            txtDegree.Text = "جيد جداً";
        //        }
        //        else if (Enumerable.Range(70, 79).Contains(sum))
        //        {
        //            txtDegree.Text = "جيد";
        //        }
        //        else if (Enumerable.Range(60, 69).Contains(sum))
        //        {
        //            txtDegree.Text = "متوسط";
        //        }
        //        else if (Enumerable.Range(50, 59).Contains(sum))
        //        {
        //            txtDegree.Text = "مقبول";
        //        }
        //        else if (Enumerable.Range(0, 49).Contains(sum))
        //        {
        //            txtDegree.Text = "ضعيف";
        //        }
        //        else if (sum > 100)
        //        {
        //            lblMessage.Text = "يرجى اعادة التقييم لزيادة التقييم عن 100";
        //        }
        //    }
        //}

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    DataRowView drv = e.Row.DataItem as DataRowView;
            //    string rate = Convert.ToString(drv["درجة التقييم"]);

            //    if (!string.IsNullOrEmpty(rate))
            //    {
            //        e.Row.Visible = false;
            //    }


            //}
            //if (DataControlRowType.DataRow == e.Row.RowType && e.Row.RowState != DataControlRowState.Edit && (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate))
            //{
            //    TextBox resp = new TextBox();  //here i m adding a control.
            //    resp.ID = "resp";
            //    resp.Width = 70;
            //    resp.Height = 50;
            //    resp.Font.Size = 20;

            //    resp.BackColor = System.Drawing.Color.LavenderBlush;
            //    resp.Style["text-align"] = "center";
            //    resp.Attributes.Add("runat", "server");
            //    int i = e.Row.Cells.Count;
            //    i = i - 8;
            //    e.Row.Cells[i].Controls.Add(resp);   //textbox is added as last column of grid

            //    TextBox conf = new TextBox();  //here i m adding a control.
            //    conf.ID = "conf";
            //    conf.Width = 70;
            //    conf.Height = 50;
            //    conf.Font.Size = 20;
            //    conf.BackColor = System.Drawing.Color.LavenderBlush;
            //    conf.Style["text-align"] = "center";
            //    conf.Attributes.Add("runat", "server");
            //    int c = e.Row.Cells.Count;
            //    c = c - 7;
            //    e.Row.Cells[c].Controls.Add(conf);

            //    TextBox inst = new TextBox();  //here i m adding a control.
            //    inst.ID = "inst";
            //    inst.Width = 70;
            //    inst.Height = 50;
            //    inst.Font.Size = 20;
            //    inst.BackColor = System.Drawing.Color.LavenderBlush;
            //    inst.Style["text-align"] = "center";
            //    inst.Attributes.Add("runat", "server");
            //    int s = e.Row.Cells.Count;
            //    s = s - 6;
            //    e.Row.Cells[s].Controls.Add(inst);

            //    TextBox sers = new TextBox();  //here i m adding a control.
            //    sers.ID = "sers";
            //    sers.Width = 70;
            //    sers.Height = 50;
            //    sers.Font.Size = 20;
            //    sers.BackColor = System.Drawing.Color.LavenderBlush;
            //    sers.Style["text-align"] = "center";
            //    sers.Attributes.Add("runat", "server");
            //    int r = e.Row.Cells.Count;
            //    r = r - 5;
            //    e.Row.Cells[r].Controls.Add(sers);

            //    TextBox rel = new TextBox();  //here i m adding a control.
            //    rel.ID = "rel";
            //    rel.Width = 70;
            //    rel.Height = 50;
            //    rel.Font.Size = 20;
            //    rel.BackColor = System.Drawing.Color.LavenderBlush;
            //    rel.Style["text-align"] = "center";
            //    rel.Attributes.Add("runat", "server");
            //    int l = e.Row.Cells.Count;
            //    l = l - 4;
            //    e.Row.Cells[l].Controls.Add(rel);

            //    TextBox comm = new TextBox();  //here i m adding a control.
            //    comm.ID = "comm";
            //    comm.Width = 70;
            //    comm.Height = 50;
            //    comm.Font.Size = 20;
            //    comm.BackColor = System.Drawing.Color.LavenderBlush;
            //    comm.Style["text-align"] = "center";
            //    comm.Attributes.Add("runat", "server");
            //    int m = e.Row.Cells.Count;
            //    m = m - 3;
            //    e.Row.Cells[m].Controls.Add(comm);

            //    Label sum = new Label();  //here i m adding a control.
            //    sum.ID = "sum";
            //    sum.Width = 70;
            //    sum.Height = 50;
            //    sum.Font.Size = 20;
            //    sum.BackColor = System.Drawing.Color.MintCream;

            //    sum.Style["text-align"] = "center";
            //    sum.Attributes.Add("runat", "server");
            //    int su = e.Row.Cells.Count;
            //    su = su - 2;
            //    e.Row.Cells[su].Controls.Add(sum);

            //    Label degree = new Label();  //here i m adding a control.
            //    degree.ID = "degree";
            //    degree.Width = 70;
            //    degree.Height = 50;
            //    degree.Font.Size = 20;
            //    degree.BackColor = System.Drawing.Color.MintCream;

            //    degree.Style["text-align"] = "center";
            //    degree.Attributes.Add("runat", "server");
            //    int de = e.Row.Cells.Count;
            //    de = de - 1;
            //    e.Row.Cells[de].Controls.Add(degree);
            //    for (int inc = 2; inc < GridView1.Rows.Count; inc++)
            //    {
            //        if (e.Row.RowType == DataControlRowType.DataRow)
            //        {

            //        }
            //    }



            //}
        }

       
        //protected void txtresp_TextChanged(object sender, EventArgs e)
        //{
        //    if (System.Text.RegularExpressions.Regex.IsMatch(txtresp.Text, "[^0-9]"))
        //    {
        //        lblMessage.Text = "الرجاء ادخال ارقام فقط وليس احرف";
        //        txtresp.Text = txtresp.Text.Remove(txtresp.Text.Length - 1);
        //    }
        //    else
        //    {
        //        int resp = Convert.ToInt32(txtresp.Text);
        //        if (resp > 30)
        //        {
        //            lblMessage.Text = "الرجاء ادخال رقم اقل من 30";
        //        }
        //        Sum();
        //    }
        //}

        //protected void txtconf_TextChanged(object sender, EventArgs e)
        //{
        //    if (System.Text.RegularExpressions.Regex.IsMatch(txtresp.Text, "[^0-9]"))
        //    {
        //        lblMessage.Text = "الرجاء ادخال ارقام فقط وليس احرف";
        //        txtresp.Text = txtresp.Text.Remove(txtresp.Text.Length - 1);
        //    }
        //    else
        //    {
        //        int conf = Convert.ToInt32(txtconf.Text);
        //        if (conf > 20)
        //        {
        //            lblMessage.Text = "الرجاء ادخال رقم اقل من 20";
        //        }
        //        Sum();
        //    }
        //}

        //protected void txtinst_TextChanged(object sender, EventArgs e)
        //{
        //    if (System.Text.RegularExpressions.Regex.IsMatch(txtresp.Text, "[^0-9]"))
        //    {
        //        lblMessage.Text = "الرجاء ادخال ارقام فقط وليس احرف";
        //        txtresp.Text = txtresp.Text.Remove(txtresp.Text.Length - 1);
        //    }
        //    else
        //    {
        //        int inst = Convert.ToInt32(txtinst.Text);
        //        if (inst > 15)
        //        {
        //            lblMessage.Text = "الرجاء ادخال رقم اقل من 15";
        //        }
        //        Sum();
        //    }
        //}

        //protected void txtsers_TextChanged(object sender, EventArgs e)
        //{
        //    if (System.Text.RegularExpressions.Regex.IsMatch(txtresp.Text, "[^0-9]"))
        //    {
        //        lblMessage.Text = "الرجاء ادخال ارقام فقط وليس احرف";
        //        txtresp.Text = txtresp.Text.Remove(txtresp.Text.Length - 1);
        //    }
        //    else
        //    {
        //        int sers = Convert.ToInt32(txtsers.Text);
        //        if (sers > 15)
        //        {
        //            lblMessage.Text = "الرجاء ادخال رقم اقل من 15";
        //        }
        //        Sum();
        //    }
        //}

        //protected void txtrel_TextChanged(object sender, EventArgs e)
        //{
        //    if (System.Text.RegularExpressions.Regex.IsMatch(txtresp.Text, "[^0-9]"))
        //    {
        //        lblMessage.Text = "الرجاء ادخال ارقام فقط وليس احرف";
        //        txtresp.Text = txtresp.Text.Remove(txtresp.Text.Length - 1);
        //    }
        //    else
        //    {
        //        int rel = Convert.ToInt32(txtrel.Text);
        //        if (rel > 10)
        //        {
        //            lblMessage.Text = "الرجاء ادخال رقم اقل من 10";
        //        }
        //        //if ((txtresp.Text ?? txtconf.Text ?? txtcomm.Text ?? txtrel.Text ?? txtsers.Text ?? txtinst.Text) == null)
        //        //{
        //        //    txtresp = 0;

        //        //    int sum = Convert.ToInt32(txtresp.Text) + Convert.ToInt32(txtinst.Text) + Convert.ToInt32(txtrel.Text) + Convert.ToInt32(txtsers.Text) + Convert.ToInt32(txtconf.Text) + Convert.ToInt32(txtcomm.Text);
        //        //    txtSum.Text = Convert.ToString(sum);
        //        //}
        //        Sum();
        //    }
        //}

        //protected void txtcomm_TextChanged(object sender, EventArgs e)
        //{
        //    if (System.Text.RegularExpressions.Regex.IsMatch(txtresp.Text, "[^0-9]"))
        //    {
        //        lblMessage.Text = "الرجاء ادخال ارقام فقط وليس احرف";
        //        txtresp.Text = txtresp.Text.Remove(txtresp.Text.Length - 1);
        //    }
        //    else
        //    {
        //        int comm = Convert.ToInt32(txtcomm.Text);
        //        if (comm > 10)
        //        {
        //            lblMessage.Text = "الرجاء ادخال رقم اقل من 10";
        //        }
        //        //int sum = Convert.ToInt32(txtresp.Text) + Convert.ToInt32(txtinst.Text) + Convert.ToInt32(txtrel.Text) + Convert.ToInt32(txtsers.Text) + Convert.ToInt32(txtconf.Text) + Convert.ToInt32(txtcomm.Text);
        //        //txtSum.Text = Convert.ToString(sum);
        //        //if (Enumerable.Range(90, 100).Contains(sum))
        //        //{
        //        //    txtDegree.Text = "ممتاز";
        //        //}
        //        //else if (Enumerable.Range(80, 89).Contains(sum))
        //        //{
        //        //    txtDegree.Text = "جيد جداً";
        //        //}
        //        //else if (Enumerable.Range(70, 79).Contains(sum))
        //        //{
        //        //    txtDegree.Text = "جيد";
        //        //}
        //        //else if (Enumerable.Range(60, 69).Contains(sum))
        //        //{
        //        //    txtDegree.Text = "متوسط";
        //        //}
        //        //else if (Enumerable.Range(50, 59).Contains(sum))
        //        //{
        //        //    txtDegree.Text = "مقبول";
        //        //}
        //        //else if (Enumerable.Range(0, 49).Contains(sum))
        //        //{
        //        //    txtDegree.Text = "ضعيف";
        //        //}
        //        //else if (sum > 100)
        //        //{
        //        //    lblMessage.Text = "يرجى اعادة التقييم لزيادة التقييم عن 100";
        //        //}
        //        Sum();
        //    }
        //}

        //protected void txtSum_TextChanged(object sender, EventArgs e)
        //{
        //    if ((txtresp.Text ?? txtconf.Text ?? txtcomm.Text ?? txtrel.Text ?? txtsers.Text ?? txtinst.Text) == null)
        //    {
        //        lblMessage.Text = "يرجى تعبئة جميع الحقول السابقة";
        //    }
          
        //}


        

        //protected void btnSubmit(object sender, EventArgs e)
        //{

        //}

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
                                        VALUES(@branchID, @DepartmentID ,1, 1, 0 , @submitUser, Getdate()) SELECT SCOPE_IDENTITY();";
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

                    EmpRating.SendEmail("hr.dept@tbiraq.com", "HR", " rafid.mahdi@tbiraq.com;  khaled.ameer@tbiraq.com; hussien.ali@tbiraq.com; balsam.gharbawy@tbiraq.com;", "ali.allawi@tbiraq.com; shams.ahameed@tbiraq.com", null, "<font color=\"navy\" dir=\"rtl\" style=\"text-align:center; margin: auto;\"><b>تحية طيبة... <br /> تم اكمال التقييمات للفرع : ( " + dt.Rows[0]["BranchDescAR"].ToString() + ")، القسم : ( " + dt.Rows[0]["DepartmentDescAR"].ToString() + ") من قبل : ( " + dt.Rows[0]["FullName"].ToString() + ").</b></font><br />", "اكتمال التقييم");
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