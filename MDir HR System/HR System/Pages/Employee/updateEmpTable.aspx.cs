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
    public partial class updateEmpTable : System.Web.UI.Page
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
                lblMessage.Text = "";
                string url = HttpContext.Current.Request.Path;
                if (!TBIMaster.HasPrivilage(url, lblMessage))
                {
                    Session["msg"] = "9";
                    Response.Redirect("~/Pages/Default.aspx");
                }
                else
                {
                    TBIMaster.FillCombo("EmpID", "FullName", "EmployeeRatingTempTBL", ddlEmployees, lblMessage);
                    TBIMaster.FillCombo("EmpID", "FirstNameAR] + ' ' + [MidNameAR] + ' '+ [LastNameAR", "EmployeesTBL", ddlEmployeesActive0, false, lblMessage);
                    TBIMaster.FillCombo("BranchID", "BranchDescAR", "BranchsTBL", ddlIBranch, true, lblMessage);
                    TBIMaster.FillCombo("DepartmentID", "DepartmentDescAR", "DepartmentTBL", ddlIDepartment, true, lblMessage);
                    TBIMaster.FillCombo("SectionID", "SectionDescAR", "SectionTBL", ddlSection, true, lblMessage);

                    TBIMaster.FillCombo("BranchID", "BranchDescAR", "BranchsTBL", ddlNewBranch, true, lblMessage);
                    TBIMaster.FillCombo("DepartmentID", "DepartmentDescAR", "DepartmentTBL", ddlNewDep, true, lblMessage);
                    TBIMaster.FillCombo("SectionID", "SectionDescAR", "SectionTBL", ddlNewSec, true, lblMessage);

                    TBIMaster.FillCombo("monthID", "monthValue", "RateMonthsTBL", ddlRateMonth, lblMessage);
                    if (Session["msg"] != null)
                    {
                        int msg = Convert.ToInt32(Session["msg"]);

                        TBIMaster.Messages(lblMessage, msg);
                        Session["msg"] = null;
                    }
                }
            }
            lblMessage.Text = "";
        }


        public void GetGrid()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = @"select [EmpID]
      ,[ID_No]
      ,[FullName]
      ,[BranchID]
      ,[DepartmentID]
      ,[SectionID]
      ,[EmployementStartDate]
      ,[CurrentLocation]
      ,[TempTransfare]
      ,[IsActive]
      ,[IsBlocked]
      ,[IsManager]
      ,[IsManagerAssist]
      ,[IsCEO]
      ,[IsCEOAssist]
      ,[IsSectionManager]
      ,[IsActing]
      ,[IsTemp] from [HR].[dbo].[EmpCurrentLocationVW] where [EmployementStartDate] is not null ";
            DataTable dt1 = new DataTable();
            dt1 = TBIMaster.GetData(cmd, lblMessage);
            SqlCommand cmdDel = new SqlCommand();
            cmdDel.CommandText = @"delete from [HR].[dbo].[EmployeeRatingTempTBL]; ";
            TBIMaster.ExecuteTest(cmdDel, lblMessage, HttpContext.Current.Request.Path);
            DataTable dt2 = new DataTable();
            cmd.CommandText = @"select * from [HR].[dbo].[EmployeeRatingTempTBL] order by FullName";
            dt2 = TBIMaster.GetData(cmd, lblMessage);
            foreach (DataRow dr in dt1.Rows)
            {
                dt2.Rows.Add(dr.ItemArray);
            }
            
            //SqlCommand cmdres = new SqlCommand();
            //cmdres.CommandText = @"DBCC CHECKIDENT ('[HR].[dbo].[EmployeeRatingTempTBL]', RESEED, 0)";
            //TBIMaster.ExecuteTest(cmdres, lblMessage, HttpContext.Current.Request.Path);
            for (int i = 0; dt2.Rows.Count > i; i++)
            {
                cmd.CommandText = @" insert into [HR].[dbo].[EmployeeRatingTempTBL] ([EmpID],[ID_No] ,[FullName] ,[BranchID],[DepartmentID] ,[SectionID],

[EmployementStartDate],[CurrentLocation],[TempTransfare],[IsActive] ,[IsBlocked],[IsManager] ,
[IsManagerAssist] ,[IsCEO],[IsCEOAssist] ,[IsSectionManager],[IsActing],[IsTemp],[rateNotes],[rateDegree],[rate16Degree],[isLess6Months],[hasNotice],[hasWarning],[hasAbsence] ,[hasOffwithout], [PageOpen], [Page16Open], [rateMonth])
                values ('" + dt2.Rows[i]["EmpID"].ToString() +
                        "','" + dt2.Rows[i]["ID_No"].ToString() +
                        "', '" + dt2.Rows[i]["FullName"].ToString() +
                        "','" + dt2.Rows[i]["BranchID"].ToString() +
                       " ','" + dt2.Rows[i]["DepartmentID"].ToString() +
                       " ','" + dt2.Rows[i]["SectionID"].ToString() +

                    " ','" + Convert.ToDateTime(dt2.Rows[i]["EmployementStartDate"]).ToString("yyyy-MM-dd").ToString() +
                    " ','" + dt2.Rows[i]["CurrentLocation"].ToString() +
                    " ','" + dt2.Rows[i]["TempTransfare"].ToString() +
                    " ','" + dt2.Rows[i]["IsActive"].ToString() +
                    " ','" + dt2.Rows[i]["IsBlocked"].ToString() +
                    " ','" + dt2.Rows[i]["IsManager"].ToString() +
                    " ','" + dt2.Rows[i]["IsManagerAssist"].ToString() +
                    " ','" + dt2.Rows[i]["IsCEO"].ToString() +
                    " ','" + dt2.Rows[i]["IsCEOAssist"].ToString() +
                    " ','" + dt2.Rows[i]["IsSectionManager"].ToString() +
                    " ','" + dt2.Rows[i]["IsActing"].ToString() +
                    " ','" + dt2.Rows[i]["IsTemp"].ToString() + "' ,'',0,0,0,0,0,0,0,0,0, @rateMonth) ";

                cmd.Parameters.AddWithValue("@rateMonth", ddlRateMonth.SelectedValue);
                    //old update
                    //                IF EXISTS (select empid from [HR].[dbo].[EmployeeRatingTempTBL] where [HR].[dbo].[EmployeeRatingTempTBL].EmpID
                    // in(select empid from [HR].[dbo].[EmpCurrentLocationVW]))
                    //update   [HR].[dbo].[EmployeeRatingTempTBL]  set 
                    //                        [ID_No] = '" + dt2.Rows[i]["ID_No"].ToString() +
                    //                    "', [FullName] = '" + dt2.Rows[i]["FullName"].ToString() +
                    //                    "',[BranchID] = '" + dt2.Rows[i]["BranchID"].ToString() +
                    //                   " ',[DepartmentID]='" + dt2.Rows[i]["DepartmentID"].ToString() +
                    //                   " ',[SectionID]= '" + dt2.Rows[i]["SectionID"].ToString() +
                    //                " ',[FirstNameEN]='" + dt2.Rows[i]["FirstNameEN"].ToString() +
                    //                " ',[MidNameEN]='" + dt2.Rows[i]["MidNameEN"].ToString() +
                    //                " ',[LastNameEN]='" + dt2.Rows[i]["LastNameEN"].ToString() +
                    //                " ',[MotherNameEN]= '" + dt2.Rows[i]["MotherNameEN"].ToString() +
                    //                " ',[FirstNameAR]='" + dt2.Rows[i]["FirstNameAR"].ToString() +
                    //                " ',[MidNameAR]='" + dt2.Rows[i]["MidNameAR"].ToString() +
                    //                " ',[LastNameAR]='" + dt2.Rows[i]["LastNameAR"].ToString() +
                    //                " ',[Address]='" + dt2.Rows[i]["Address"].ToString() +
                    //                " ',[EmployeRank]='" + dt2.Rows[i]["EmployeRank"].ToString() +
                    //                " ',[PhoneNo]='" + dt2.Rows[i]["PhoneNo"].ToString() +
                    //                " ',[Image]='" + dt2.Rows[i]["Image"].ToString() +
                    //                " ',[LicenseDigreeID]='" + dt2.Rows[i]["LicenseDigreeID"].ToString() +
                    //                " ',[LicenseNameID]='" + dt2.Rows[i]["LicenseNameID"].ToString() +
                    //                " ',[GenderID]='" + dt2.Rows[i]["GenderID"].ToString() +
                    //                " ',[BasicSalary]='" + dt2.Rows[i]["BasicSalary"].ToString() +
                    //                " ',[VisaCardNo]='" + dt2.Rows[i]["VisaCardNo"].ToString() +
                    //                " ',[BirthDate]='" + dt2.Rows[i]["BirthDate"].ToString() +
                    //                " ',[JoinDate]='" + dt2.Rows[i]["JoinDate"].ToString() +
                    //                " ',[EmployementStartDate]='" + dt2.Rows[i]["EmployementStartDate"].ToString() +
                    //                " ',[LocationStartDate]='" + dt2.Rows[i]["LocationStartDate"].ToString() +
                    //                " ',[LeaveDate]='" + dt2.Rows[i]["LeaveDate"].ToString() +
                    //                " ',[MaturityDate]='" + dt2.Rows[i]["MaturityDate"].ToString() +
                    //                " ',[VicationBalance]='" + dt2.Rows[i]["VicationBalance"].ToString() +
                    //                " ',[SickLeavesBalance]='" + dt2.Rows[i]["SickLeavesBalance"].ToString() +
                    //                " ',[LastModification]='" + dt2.Rows[i]["LastModification"].ToString() +
                    //                " ',[CurrentLocation]='" + dt2.Rows[i]["CurrentLocation"].ToString() +
                    //                " ',[TempTransfare]='" + dt2.Rows[i]["TempTransfare"].ToString() +
                    //                " ',[IsActive]='" + dt2.Rows[i]["IsActive"].ToString() +
                    //                " ',[IsBlocked]='" + dt2.Rows[i]["IsBlocked"].ToString() +
                    //                " ',[IsManager]='" + dt2.Rows[i]["IsManager"].ToString() +
                    //                " ',[IsManagerAssist]='" + dt2.Rows[i]["IsManagerAssist"].ToString() +
                    //                " ',[IsCEO]='" + dt2.Rows[i]["IsCEO"].ToString() +
                    //                " ',[IsCEOAssist]='" + dt2.Rows[i]["IsCEOAssist"].ToString() +
                    //                " ',[IsSectionManager]='" + dt2.Rows[i]["IsSectionManager"].ToString() +
                    //                " ',[IsActing]='" + dt2.Rows[i]["IsActing"].ToString() +
                    //                " ',[IsTemp]='" + dt2.Rows[i]["IsTemp"].ToString() +
                    //                " ',[EmergencyComtactName]='" + dt2.Rows[i]["EmergencyComtactName"].ToString() +
                    //                " ',[EmergencyPhoneNo]='" + dt2.Rows[i]["EmergencyPhoneNo"].ToString() +
                    //                " ',[LandLine]='" + dt2.Rows[i]["LandLine"].ToString() +
                    //                " ',[MaritalStatusID]='" + dt2.Rows[i]["MaritalStatusID"].ToString() +
                    //                " ',[ChildrenCount]='" + dt2.Rows[i]["ChildrenCount"].ToString() +
                    //                " ',[ResignReasonID]='" + dt2.Rows[i]["ResignReasonID"].ToString() +
                    //                " ',[EmployeGroup]='" + dt2.Rows[i]["EmployeGroup"].ToString() +
                    //                " ',[BloodID]='" + dt2.Rows[i]["BloodID"].ToString() +
                    //                " ',[PersonalEmail]='" + dt2.Rows[i]["PersonalEmail"].ToString() +
                    //                " ',[Notes]='" + dt2.Rows[i]["Notes"].ToString() +
                    //                " ',[imgsign]='" + dt2.Rows[i]["imgsign"].ToString() +
                    //                " ',[SpouseJob]='" + dt2.Rows[i]["SpouseJob"].ToString() +
                    //                " ',[EmailProcessed]='" + dt2.Rows[i]["EmailProcessed"].ToString() +
                    //                " ',[InternalEmail]='" + dt2.Rows[i]["InternalEmail"].ToString() +
                    //                " ',[StartedWork]='" + dt2.Rows[i]["StartedWork"].ToString() +
                    //                " ',[Table]='" + dt2.Rows[i]["Table"].ToString() + "' , isless6months = 0, hasNotice =0 , hasWarning =0 or hasOffwithout = 0 or hasAbsence =0   where [EmpID]= '" + dt2.Rows[i]["EmpID"].ToString() +
                    //                @"'  else 

                    if (TBIMaster.ExecuteTest(cmd, lblMessage, HttpContext.Current.Request.Path))
                    {
                        Session["msg"] = "1";
                        //                    SqlCommand cmd3 = new SqlCommand();

                        //                    cmd3.CommandText = @"select [EmpID],[FullName], HR.dbo.BranchsTBL.BranchDescAR
                        //                                       ,HR.dbo.DepartmentTBL.DepartmentDescAR ,[SectionID]
                        //                                       from [HR].[dbo].[EmpCurrentLocationVW]  LEFT JOIN HR.dbo.BranchsTBL ON [HR].[dbo].[EmployeeRatingTempTBL].BranchID = HR.dbo.BranchsTBL.BranchID LEFT JOIN HR.dbo.DepartmentTBL ON [HR].[dbo].[EmployeeRatingTempTBL].DepartmentID = HR.dbo.DepartmentTBL.DepartmentID
                        //  left join hr.dbo.SectionTBL on hr.dbo.EmployeeRatingTempTBL.SectionID = hr.dbo.SectionTBL.SectionID
                        //  order by FullName";
                        //                    DataTable dt3 = new DataTable();
                        //                    dt3 = TBIMaster.GetData(cmd3, lblMessage);

                        //GridView1.Columns.Clear();
                        //TBIMaster.AddColumnsToGridView(GridView1, dt2);
                        //GridView1.DataSource = dt2;
                        //GridView1.DataBind();
                        //GridView1.Columns[1].Visible = false;

                        //for (int col = 6; col < GridView1.Columns.Count; col++)
                        //{
                        //    GridView1.Columns[col].Visible = false;
                        //}

                }
            }
        }
        public void ShowGrid()
        {
            SqlCommand cmd3 = new SqlCommand();

            cmd3.CommandText = @"select ' ' as [ ],[EmpID], [FullName] as [اسم الموظف], [HR].[dbo].[BranchsTBL].BranchDescAR as [الفرع]
                                                   ,HR.dbo.DepartmentTBL.DepartmentDescAR as [القسم],hr.dbo.SectionTBL.SectionDescAR as [الشعبة] , [EmployementStartDate] as [تار يخ المباشرة]
                                                  
                                                   from [HR].[dbo].[EmployeeRatingTempTBL]  
LEFT JOIN HR.dbo.BranchsTBL ON [HR].[dbo].[EmployeeRatingTempTBL].BranchID = HR.dbo.BranchsTBL.BranchID
LEFT JOIN HR.dbo.DepartmentTBL ON [HR].[dbo].[EmployeeRatingTempTBL].DepartmentID = HR.dbo.DepartmentTBL.DepartmentID
left join hr.dbo.SectionTBL on hr.dbo.EmployeeRatingTempTBL.SectionID = hr.dbo.SectionTBL.SectionID
              order by FullName";
            DataTable dt3 = new DataTable();
            dt3 = TBIMaster.GetData(cmd3, lblMessage);
            GridView1.Columns.Clear();
            TBIMaster.AddColumnsToGridView(GridView1, dt3);
            GridView1.DataSource = dt3;
            GridView1.DataBind();
            AddLinkButton(GridView1);

        }


        public void ShowAllGrid()
        {
            SqlCommand cmd3 = new SqlCommand();

            cmd3.CommandText = @"select ' ' as [ ],[EmpID], [FullName] as [اسم الموظف], [HR].[dbo].[BranchsTBL].BranchDescAR as [الفرع]
                                                   ,HR.dbo.DepartmentTBL.DepartmentDescAR as [القسم],hr.dbo.SectionTBL.SectionDescAR as [الشعبة] , [EmployementStartDate] as [تار يخ المباشرة]
                                                  
                                                   from [HR].[dbo].[EmployeeRatingTempTBL]  
LEFT JOIN HR.dbo.BranchsTBL ON [HR].[dbo].[EmployeeRatingTempTBL].BranchID = HR.dbo.BranchsTBL.BranchID
LEFT JOIN HR.dbo.DepartmentTBL ON [HR].[dbo].[EmployeeRatingTempTBL].DepartmentID = HR.dbo.DepartmentTBL.DepartmentID
left join hr.dbo.SectionTBL on hr.dbo.EmployeeRatingTempTBL.SectionID = hr.dbo.SectionTBL.SectionID
              order by FullName";
            DataTable dt3 = new DataTable();
            dt3 = TBIMaster.GetData(cmd3, lblMessage);
            GridView4.Columns.Clear();
            TBIMaster.AddColumnsToGridView(GridView4, dt3);
            GridView4.DataSource = dt3;
            GridView4.DataBind();
            AddLinkButton(GridView4);

        }

        public void ShowNotesGrid()
        {
            SqlCommand cmd6 = new SqlCommand();

            cmd6.CommandText = @"select [HR].[dbo].[EmployeeRatingTempTBL].[EmpID], [HR].[dbo].[EmployeeRatingTempTBL].[FullName] as [اسم الموظف], [HR].[dbo].[BranchsTBL].BranchDescAR as [الفرع]
                                                   ,HR.dbo.DepartmentTBL.DepartmentDescAR as [القسم] , [EmployementStartDate] as [تار يخ المباشرة]
												   , isLess6Months as [اقل من 6 اشهر], hasNotice as [يوجد تنبيه],hasWarning as [يوجد انذار], hasOffwithout as [مجاز بدون راتب], hasAbsence as [غياب]
          from      [HR].[dbo].[EmployeeRatingTempTBL]
		  left join HR.dbo.BranchsTBL ON [HR].[dbo].[EmployeeRatingTempTBL].BranchID = HR.dbo.BranchsTBL.BranchID
LEFT join HR.dbo.DepartmentTBL ON [HR].[dbo].[EmployeeRatingTempTBL].DepartmentID = HR.dbo.DepartmentTBL.DepartmentID
             where isLess6Months =1 or hasNotice =1 or hasWarning =1 or hasOffwithout = 1 or hasAbsence =1 
			 
			  order by FullName";
            DataTable dt = new DataTable();
            dt = TBIMaster.GetData(cmd6, lblMessage);
            GridView2.Columns.Clear();
            TBIMaster.AddColumnsToGridView(GridView2, dt);
            GridView2.DataSource = dt;
            GridView2.DataBind();

        }
        private void AddLinkButton(GridView gridviewex)
        {
            foreach (GridViewRow row in gridviewex.Rows)
            {
                LinkButton lb = (LinkButton)row.Cells[0].Controls[0];
                lb.Text = "تعديل";
                lb.ForeColor = System.Drawing.Color.Blue;
                if (row.RowType == DataControlRowType.DataRow)
                {

                    string deleteBtn = @"<a href='#' ID='" + row.Cells[2].Text + "' class = 'link' >حذف</a>";
                    row.Cells[1].Text += deleteBtn;

                }
            }
        }
        [WebMethod]
        public static string OnConfirm(string rid)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = @"delete from [HR].[dbo].[EmployeeRatingTempTBL] WHERE EmpID = @ID ";
            cmd.Parameters.AddWithValue("@ID", rid);
            string check = TBIMaster.Execute(cmd, "", "HR");
            return (check);

        }


        protected void Submit_Click(object sender, EventArgs e)
        {
            if (ddlRateMonth.SelectedIndex == 0)
            {
                lblMessage.Text = "يرجى اختيار احد الاشهر";
            }
            else
            {
                GetGrid();
                // GridView1.Visible = false;
                AddForm.Visible = false;
                newForm.Visible = false;
                divName.Attributes["style"] = "display: none";
                divSearch.Attributes["style"] = "display: none";
            }
            
        }

        protected void Add_Click(object sender, EventArgs e)
        {

            try
            {
                BranchID = Session["BranchID"].ToString();
                depID = Session["depID"].ToString();
                UserID = Session["UserID"].ToString();
            }
            catch
            {
                TBIMaster.Messages(lblMessage, 0);
                return;
            }
            if (true)
            {
                //Label id = gvDocs.Rows[e.RowIndex].FindControl("lbl_ID") as Label;


                //updating the record    
                Int64 EmpID = Convert.ToInt64(hfEmpID.Value);
                if (EmpID > 0)
                {

                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = @"update [HR].[dbo].[EmployeeRatingTempTBL]
                                          set BranchID = @BranchID ,DepartmentID = @DepartmentID , SectionID = @SectionID 
                                        where EmpID=@ID";
                    cmd.Parameters.AddWithValue("@ID", hfEmpID.Value);

                    ////////////////
                    cmd.Parameters.AddWithValue("@BranchID", ddlIBranch.SelectedValue);
                    cmd.Parameters.AddWithValue("@DepartmentID", ddlIDepartment.SelectedValue);
                    cmd.Parameters.AddWithValue("@SectionID", ddlSection.SelectedValue);


                    bool check = TBIMaster.Execute(cmd, lblMessage, HttpContext.Current.Request.Path);
                    if (check)
                    {
                        TBIMaster.Messages(lblMessage, 1);
                        Session["msg"] = "1";
                       
                     
                        AddForm.Visible = false;
                        ShowGrid();


                    }
                }
            }
        }

        protected void delete_Click(object sender, EventArgs e)
        {

        }
        protected void GridView1_PageIndexChanged(object sender, EventArgs e)
        {
            ShowGrid();
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
        }
        protected void GridView2_PageIndexChanged(object sender, EventArgs e)
        {
            ShowNotesGrid();
        }

        protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView2.PageIndex = e.NewPageIndex;
        }
        protected void addEmployee_Click(object sender, EventArgs e)
        {
            ShowAllGrid();
            GridView3.Visible = false;
            GridView2.Visible = false;
            GridView4.Visible = true;
            AddForm.Visible = false;
            newForm.Visible = false;
            divName.Attributes["style"] = "display: inlineblock";
            divSearch.Attributes["style"] = "display: inlineblock";
            
        }
        protected void BtnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/Employee/updateEmpTable.aspx");
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {

            int index = e.NewSelectedIndex;
            int ID = Convert.ToInt32(GridView1.Rows[index].Cells[2].Text);
            hfEmpID.Value = ID.ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = @"select [EmpID], [FullName] , 
                               [BranchID] ,[DepartmentID],[SectionID] 
                                from [HR].[dbo].[EmployeeRatingTempTBL]  where EmpID =@ID";
            cmd.Parameters.AddWithValue("@ID", hfEmpID.Value);
            DataTable dt = TBIMaster.GetData(cmd, lblMessage);
            //myReader = cmd.ExecuteReader();

            if (dt.Rows.Count > 0)
            {
                ddlEmployees.SelectedValue = dt.Rows[0]["EmpID"].ToString();
                ddlIBranch.SelectedValue = (dt.Rows[0]["BranchID"].ToString());
                ddlSection.SelectedValue = (dt.Rows[0]["SectionID"].ToString());
                ddlIDepartment.Text = (dt.Rows[0]["DepartmentID"].ToString());
                AddForm.Visible = true;
                AddForm.Focus();
            }
        }

        protected void NewEmployee_Click(object sender, EventArgs e)
        {
            newForm.Visible = true;
            AddForm.Visible = false;
            GridView2.Visible = false;
            divName.Attributes["style"] = "display: none";
            divSearch.Attributes["style"] = "display: none";

        }

        protected void btnNewEmp_Click(object sender, EventArgs e)
        {
            try
            {
                BranchID = Session["BranchID"].ToString();
                depID = Session["depID"].ToString();
                UserID = Session["UserID"].ToString();
               
                EmpID = Session["EmpID"].ToString();
            }
            catch
            {
                TBIMaster.Messages(lblMessage, 0);
                return;
            }
     

            if ((ddlNewBranch.SelectedIndex ==0) || (ddlNewDep.SelectedIndex==0) || (ddlNewSec.SelectedIndex==0) || (ddlEmployeesActive0.SelectedIndex==0))
            {
                lblMessage.Text = "الرجاء اختيار القسم والفرع والشعبة";
            }
            else
            {
                GridView1.Visible = false;
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"IF EXISTS (select * from [HR].[dbo].[EmployeeRatingTempTBL] where EmpID=@EmpID) 
					select '0' 
					else
                    INSERT INTO [HR].[dbo].[EmployeeRatingTempTBL] ([EmpID],[FullName],[BranchID], [DepartmentID],[SectionID], [isActive], [rateNotes], [isManager], [IsCEOAssist])
                                        VALUES( @EmpID,@FullName, @BranchID, @DepartmentID, @SectionID, 1, @rateNotes, 0, 0) ";
                ////////////////
              
                cmd.Parameters.AddWithValue("@EmpID", ddlEmployeesActive0.SelectedValue);
                cmd.Parameters.AddWithValue("@FullName", ddlEmployeesActive0.SelectedItem.Text);
                cmd.Parameters.AddWithValue("@BranchID", ddlNewBranch.SelectedValue);
                cmd.Parameters.AddWithValue("@DepartmentID", ddlNewDep.SelectedValue);
                cmd.Parameters.AddWithValue("@SectionID", ddlNewSec.SelectedValue);
                cmd.Parameters.AddWithValue("@rateNotes", txtNotes.Text);

                int RateID = Convert.ToInt32(TBIMaster.ExecuteScaler(cmd, lblMessage, HttpContext.Current.Request.Path));
                if (RateID >= 0)
                {
                    TBIMaster.Messages(lblMessage, 1);
                }
                else if (RateID < 0)
                {
                    lblMessage.Text = "الموظف موجود مسبقاً";

                }
                else
                {
                    TBIMaster.Messages(lblMessage, 14);
                }
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            GridView4.Visible = false;
            GridView2.Visible = false;
            GridView1.Visible = false;
            GridView3.Visible = true;
            ShowSearchGrid();
            
        }
        public void ShowSearchGrid()
        {
            SqlCommand cmd3 = new SqlCommand();

            cmd3.CommandText = @"select ' ' as [ ],[EmpID], [FullName] as [اسم الموظف], [HR].[dbo].[BranchsTBL].BranchDescAR as [الفرع]
                                                   ,HR.dbo.DepartmentTBL.DepartmentDescAR as [القسم],hr.dbo.SectionTBL.SectionDescAR as [الشعبة] , [EmployementStartDate] as [تار يخ المباشرة]
                                                   
                                                   from [HR].[dbo].[EmployeeRatingTempTBL]  
LEFT JOIN HR.dbo.BranchsTBL ON [HR].[dbo].[EmployeeRatingTempTBL].BranchID = HR.dbo.BranchsTBL.BranchID
LEFT JOIN HR.dbo.DepartmentTBL ON [HR].[dbo].[EmployeeRatingTempTBL].DepartmentID = HR.dbo.DepartmentTBL.DepartmentID
left join hr.dbo.SectionTBL on hr.dbo.EmployeeRatingTempTBL.SectionID = hr.dbo.SectionTBL.SectionID  where [HR].[dbo].[EmployeeRatingTempTBL].[FullName] like  '%' + @FullName + '%'
              order by FullName";
            cmd3.Parameters.AddWithValue("@FullName", txtNameSearch.Text);
            DataTable dt3 = new DataTable();
            dt3 = TBIMaster.GetData(cmd3, lblMessage);
            GridView3.Columns.Clear();
            TBIMaster.AddColumnsToGridView(GridView3, dt3);
            GridView3.DataSource = dt3;
            GridView3.DataBind();
            AddLinkButton(GridView3);
            if (GridView3.Rows.Count == 0)
            {
                lblMessage.Text = "لم يتم العثور على نتائج";
            }
        }
        protected void notesUpdate_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = @"update [HR].[dbo].[EmployeeRatingTempTBL]
                                  set isless6months = 1
                                  where ((DATEDIFF(MONTH, EmployementStartDate ,DATEADD (month, DATEDIFF(month, 0, GETDATE()), 0))) - 2) <= 6";

            
            bool isless6months = TBIMaster.Execute(cmd, lblMessage, HttpContext.Current.Request.Path);
                  
            SqlCommand cmd2 = new SqlCommand();
            cmd2.CommandText = @"update [HR].[dbo].[EmployeeRatingTempTBL] 
                                 set hasNotice = 1
                                where [HR].[dbo].[EmployeeRatingTempTBL].EmpID in
                                (select EmpID
                                 from [HR].[dbo].[AdminOrdersTBL]
                                where OrderTypeID = 13 and DATEDIFF(month, OrderDate ,DATEADD (month, DATEDIFF(month, 0, GETDATE()), 0)) between 1 and 2
                                 ) SELECT SCOPE_IDENTITY();";

           
            bool hasNotice = TBIMaster.Execute(cmd2, lblMessage, HttpContext.Current.Request.Path);
            SqlCommand cmd3 = new SqlCommand();
            cmd3.CommandText = @"update [HR].[dbo].[EmployeeRatingTempTBL] 
                                    set hasWarning = 1
                                where [HR].[dbo].[EmployeeRatingTempTBL].EmpID in
                                (select EmpID
                                from [HR].[dbo].[AdminOrdersTBL]
                                where OrderTypeID = 14 and DATEDIFF(month, OrderDate ,DATEADD (month, DATEDIFF(month, 0, GETDATE()), 0)) between 1 and 2
                                ) ";

           
            bool hasWarning = TBIMaster.Execute(cmd3, lblMessage, HttpContext.Current.Request.Path);
            SqlCommand cmd4 = new SqlCommand();
            cmd4.CommandText = @"update [HR].[dbo].[EmployeeRatingTempTBL] 
                                set hasOffwithout = 1
                            where [HR].[dbo].[EmployeeRatingTempTBL].EmpID in
                                (SELECT EmpID
                                 FROM [HR].[dbo].[VicationsTBL]
                                 where VicationTypeID = 2
                                 and DATEDIFF(month, StartDate ,DATEADD (month, DATEDIFF(month, 0, GETDATE()), 0)) between 1 and 2
                                 and VicationInterval/7 >=5)";
        
            bool hasOffwithout = TBIMaster.Execute(cmd4, lblMessage, HttpContext.Current.Request.Path);
            SqlCommand cmd5 = new SqlCommand();
            cmd5.CommandText = @"update [HR].[dbo].[EmployeeRatingTempTBL] 
                                    set hasAbsence = 1
                                  where [HR].[dbo].[EmployeeRatingTempTBL].EmpID in (SELECT EmpID
                                 FROM [HR].[dbo].[VicationsTBL]
                                 where VicationTypeID = 4
                                 and DATEDIFF(month, StartDate ,DATEADD (month, DATEDIFF(month, 0, GETDATE()), 0)) between 1 and 2
                                 and VicationInterval/7 >=4)";

            bool hasAbsence = TBIMaster.Execute(cmd5, lblMessage, HttpContext.Current.Request.Path);
            if ((isless6months) & (hasNotice) & (hasWarning) & (hasOffwithout))
            {
                TBIMaster.Messages(lblMessage, 1);
                ShowNotesGrid();
            }
            else
            {
                TBIMaster.Messages(lblMessage, 14);
            }
        }

        protected void GridView3_PageIndexChanged(object sender, EventArgs e)
        {
            ShowSearchGrid();
        }

        protected void GridView3_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView3.PageIndex = e.NewPageIndex;
        }

        protected void GridView3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GridView3_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            int index = e.NewSelectedIndex;
            int ID = Convert.ToInt32(GridView3.Rows[index].Cells[2].Text);
            hfEmpID.Value = ID.ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = @"select [EmpID], [FullName] , 
                               [BranchID] ,[DepartmentID],[SectionID] 
                                from [HR].[dbo].[EmployeeRatingTempTBL]  where EmpID =@ID";
            cmd.Parameters.AddWithValue("@ID", hfEmpID.Value);
            DataTable dt = TBIMaster.GetData(cmd, lblMessage);
            //myReader = cmd.ExecuteReader();

            if (dt.Rows.Count > 0)
            {
                ddlEmployees.SelectedValue = dt.Rows[0]["EmpID"].ToString();
                ddlIBranch.SelectedValue = (dt.Rows[0]["BranchID"].ToString());
                ddlSection.SelectedValue = (dt.Rows[0]["SectionID"].ToString());
                ddlIDepartment.Text = (dt.Rows[0]["DepartmentID"].ToString());
                AddForm.Visible = true;
                AddForm.Focus();
            }
        }

        protected void GridView4_PageIndexChanged(object sender, EventArgs e)
        {
            ShowAllGrid();
        }

        protected void GridView4_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView4.PageIndex = e.NewPageIndex;
        }

        protected void GridView4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GridView4_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            int index = e.NewSelectedIndex;
            int ID = Convert.ToInt32(GridView4.Rows[index].Cells[2].Text);
            hfEmpID.Value = ID.ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = @"select [EmpID], [FullName] , 
                               [BranchID] ,[DepartmentID],[SectionID] 
                                from [HR].[dbo].[EmployeeRatingTempTBL]  where EmpID =@ID";
            cmd.Parameters.AddWithValue("@ID", hfEmpID.Value);
            DataTable dt = TBIMaster.GetData(cmd, lblMessage);
            //myReader = cmd.ExecuteReader();

            if (dt.Rows.Count > 0)
            {
                ddlEmployees.SelectedValue = dt.Rows[0]["EmpID"].ToString();
                ddlIBranch.SelectedValue = (dt.Rows[0]["BranchID"].ToString());
                ddlSection.SelectedValue = (dt.Rows[0]["SectionID"].ToString());
                ddlIDepartment.Text = (dt.Rows[0]["DepartmentID"].ToString());
                AddForm.Visible = true;
                AddForm.Focus();
            }
        }

     
    }
}