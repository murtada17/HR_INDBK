using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI.WebControls;

namespace HR_Salaries.Pages.Vacations
{
    public partial class EmpVacation : System.Web.UI.Page
    {
        ReportDocument crd = new ReportDocument();
        string Path = "~/Reports/ReportSource/rptEmpVacation.rpt";

        protected void Page_Load(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            if (!IsPostBack)
            {
                string url = HttpContext.Current.Request.Path;
                if (!MDirMaster.HasPrivilage(url, lblMessage))
                {
                    Session["msg"] = "9";
                    Response.Redirect("~/Pages/Default.aspx");
                }
                else
                {
                    MDirMaster.FillCombo("BranchID", "BranchDescAR", "BranchsTBL", ddlSBranch, true, lblMessage);
                    MDirMaster.FillCombo("DepartmentID", "DepartmentDescAR", "DepartmentTBL", ddlSDep, true, lblMessage);
                    MDirMaster.FillCombo("SectionID", "SectionDescAR", "SectionTBL", ddlSection, true, lblMessage);
                    MDirMaster.FillCombo("EmpID", "FirstNameAR] + ' ' + [MidNameAR] + ' '+ [LastNameAR", "EmployeesTBL", ddlNameAR, true, lblMessage);
                    MDirMaster.FillCombo("EmpID", "FirstNameEN] + ' ' + [MidNameEN] + ' '+ [LastNameEN", "EmployeesTBL", ddlNameEN, true, lblMessage);
                    MDirMaster.FillCombo("VicationTypeID", "VicationDesc", "VicationTypesTBL", ddlVicationType, true, lblMessage);
                    ddlVicationType.SelectedValue = "1";
                    ddlVicationType_SelectedIndexChanged(sender, e);
                    txtStartDate.Text = DateTime.Now.ToShortDateString();
                    txtEndDate.Text = DateTime.Now.ToShortDateString();
                    txtTimeDate.Text = DateTime.Now.ToShortDateString();
                    txtOrderDate.Text = DateTime.Now.ToShortDateString();
                    txtStartDate_TextChanged(sender, e);
                    rbGrid.Checked = true;
                    MultiView1.SetActiveView(vwGrid);
                }
            }
        }

        protected void ddlSBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Condition = "";
            bool check = false;
            if (Convert.ToInt32(ddlSBranch.SelectedValue) > 0)
            {
                Condition += " BranchID = " + ddlSBranch.SelectedValue;
                check = true;
            }
            if (Convert.ToInt32(ddlSDep.SelectedValue) > 0)
            {
                if (check)
                {
                    Condition += " AND ";
                }
                Condition += " DepartmentID = " + ddlSDep.SelectedValue;
                check = true;
            }
            Condition += " AND IsActive = 1 ";
            if (check)
            {
                MDirMaster.FillCombo("EmpID", "FirstNameAR] + ' ' + [MidNameAR] + ' '+ [LastNameAR", "EmployeesTBL", ddlNameAR, Condition, lblMessage);
                MDirMaster.FillCombo("EmpID", "FirstNameEN] + ' ' + [MidNameEN] + ' '+ [LastNameEN", "EmployeesTBL", ddlNameEN, Condition, lblMessage);
            }
            else
            {
                MDirMaster.FillCombo("EmpID", "FirstNameAR] + ' ' + [MidNameAR] + ' '+ [LastNameAR", "EmployeesTBL", ddlNameAR, true, lblMessage);
                MDirMaster.FillCombo("EmpID", "FirstNameEN] + ' ' + [MidNameEN] + ' '+ [LastNameEN", "EmployeesTBL", ddlNameEN, true, lblMessage);
            }
        }

        protected void ddlName_SelectedIndexChanged(object sender, EventArgs e)
        {

            WebControl MyWebControl = sender as WebControl;
            if (MyWebControl != null)
            {
                string SenderID = MyWebControl.ID.ToString();
                if (SenderID == "ddlNameAR")
                {
                    ddlNameEN.SelectedValue = ddlNameAR.SelectedValue;
                }
                else if (SenderID == "ddlNameEN")
                {
                    ddlNameAR.SelectedValue = ddlNameEN.SelectedValue;
                }
                hfEmpID.Value = ddlNameEN.SelectedValue;
                DataTable dt = MDirMaster.GetBranchDep(Convert.ToInt32(hfEmpID.Value), lblMessage);
                ddlSBranch.SelectedValue = dt.Rows[0]["BranchID"].ToString();
                ddlSDep.SelectedValue = dt.Rows[0]["DepartmentID"].ToString();
                ddlSection.SelectedValue = dt.Rows[0]["SectionID"].ToString();
            }
            GetBalance();
            GetGrid();
        }

        private void GetGrid()
        {
            int EmpID = Convert.ToInt32(hfEmpID.Value);
            if (EmpID > 0)
            {
                if (rbGrid.Checked)
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = @"SELECT       dbo.VicationsTBL.VicationID, dbo.EmployeesTBL.FirstNameAR + ' ' + dbo.EmployeesTBL.MidNameAR + ' ' + dbo.EmployeesTBL.LastNameAR AS الأسم, 
                                                 dbo.VicationTypesTBL.VicationDesc AS [نوع الإجازة], 
                                                 CASE WHEN dbo.VicationTypesTBL.VicationTypeID != 8 THEN dbo.VicationsTBL.VicationInterval / 7 WHEN dbo.VicationTypesTBL.VicationTypeID = 8 THEN dbo.VicationsTBL.VicationInterval
                                                 END AS [مدة الإجازة], dbo.VicationsTBL.StartDate AS [ابتدءاً من], dbo.VicationsTBL.EndDate AS [انتهاءاً], dbo.VicationsTBL.SubmitDate AS [تاريخ الإدخال], dbo.VicationsTBL.Note AS ملاحظات
                                    FROM         dbo.EmployeesTBL INNER JOIN
                                                 dbo.VicationsTBL ON dbo.EmployeesTBL.EmpID = dbo.VicationsTBL.EmpID INNER JOIN
                                                 dbo.VicationTypesTBL ON dbo.VicationsTBL.VicationTypeID = dbo.VicationTypesTBL.VicationTypeID
                                    WHERE        (dbo.VicationsTBL.IsActive = 1) AND (dbo.EmployeesTBL.EmpID = @EmpID)
                                    ORDER BY dbo.VicationsTBL.SubmitDate DESC, dbo.VicationsTBL.StartDate DESC";
                    cmd.Parameters.AddWithValue("@EmpID", EmpID);
                    MDirMaster.FillGrid(cmd, gvEmpVications, lblMessage);
                }
                else
                {
                    crd.Load(Server.MapPath(Path));
                    crd.SetDatabaseLogon("reporter", "123", "192.168.0.49", "HR", true);
                    crd.RecordSelectionFormula = condition(crd.RecordSelectionFormula.ToString());
                    crd.Refresh();
                    crvReports.Zoom(110);
                    crvReports.ReportSource = crd;
                    crvReports.RefreshReport();
                    crvReports.Visible = true;
                    //crvReports
                    //crd.Close();
                    //crd.Dispose();
                }
            }
        }

        public string condition(string SFormula)
        {
            string Condition = SFormula;
            bool check = false;
            if (!string.IsNullOrEmpty(Condition))
            {
                check = true;
            }
            if (check)
            {
                Condition += " AND ";
            }
            Condition += " {EmployeesTBL.EmpID} = " + ddlNameAR.SelectedValue;
            check = true;
            return Condition;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            int EmpID = Convert.ToInt32(hfEmpID.Value);
            if ((Convert.ToInt32(ddlNameAR.SelectedValue) > 0) && (Convert.ToInt32(ddlVicationType.SelectedValue) > 0)
                && (EmpID > 0))
            {
                bool addOrder = false;
                DateTime EndDate = Convert.ToDateTime(hfEndDate.Value);
                DateTime StartDate = Convert.ToDateTime(hfStartDate.Value);
                int VicationType = Convert.ToInt32(hfVicationTypeID.Value), Days = Convert.ToInt32(hfDays.Value);
                if (VicationType == 8)//زمنية
                {

                }
                else
                {
                    //EndDate = StartDate.AddDays(Days - 1);
                    if ((VicationType == 3) && (Days > 3))
                    {
                        if (string.IsNullOrEmpty(txtOrderNo.Text) || txtOrderDate.Text.Length < 7)
                        {
                            MDirMaster.Messages(lblMessage, 3);
                            return;
                        }
                        else
                        {
                            addOrder = true;
                        }
                    }
                    else if (Days > 10)
                    {
                        if (string.IsNullOrEmpty(txtOrderNo.Text) || txtOrderDate.Text.Length < 7)
                        {
                            MDirMaster.Messages(lblMessage, 3);
                            return;
                        }
                        else
                        {
                            addOrder = true;
                        }
                    }
                    else if (!string.IsNullOrEmpty(txtOrderNo.Text) && txtOrderDate.Text.Length > 7)
                    {
                        addOrder = true;
                    }
                }
                string Query = "AddVicationSP ";
                SqlCommand cmd = new SqlCommand(Query);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EmpID", EmpID);
                cmd.Parameters.AddWithValue("@VicationTypeID", VicationType);
                if ((VicationType == 1) || (VicationType == 8))
                {
                    cmd.Parameters.AddWithValue("@WithBalance", 1);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@WithBalance", 0);
                }
                cmd.Parameters.AddWithValue("@HoursOfVication", hfHours.Value);
                cmd.Parameters.Add("@StartDate", System.Data.SqlDbType.DateTime);
                cmd.Parameters["@StartDate"].Value = (StartDate);
                cmd.Parameters.Add("@EndDate", System.Data.SqlDbType.DateTime);
                cmd.Parameters["@EndDate"].Value = (EndDate);
                cmd.Parameters.Add("@Result", System.Data.SqlDbType.Int);
                cmd.Parameters["@Result"].Direction = ParameterDirection.Output;
                cmd.Parameters.AddWithValue("@Note", txtNote.Text);
                MDirMaster.Execute(cmd, lblMessage, HttpContext.Current.Request.Path);
                int Result = Convert.ToInt32(cmd.Parameters["@Result"].Value);
                if (Result == -1)
                {
                    lblMessage.Text = "تتعارض الاجازة مع اجازة اخرى، يرجى التأكد.";
                    return;
                }
                else if (Result == -2)
                {
                    lblMessage.Text = "تتصل هذه الاجازة بإجازة سابقة.";
                    return;
                }
                else if (addOrder)
                {
                    DataTable dt = MDirMaster.GetBranchDep(EmpID, lblMessage);
                    int DepartmentID = Convert.ToInt32(dt.Rows[0]["DepartmentID"]);
                    int BranchID = Convert.ToInt32(dt.Rows[0]["BranchID"]);
                    string note = ddlVicationType.SelectedItem.Text + " ابتدأ من " + txtStartDate.Text + " إلى " + txtEndDate.Text + "، لمدة " + txtDaysCount.Text + " يوم، " + txtNote.Text;
                    MDirMaster.AdminOrderAdd(EmpID, BranchID, DepartmentID, note, txtOrderNo.Text, txtOrderDate.Text, 9, lblMessage);
                }
                //Response.Redirect("~/Pages/Vications/EmpVication.aspx");
                hfBalance.Value = "0";
                hfDays.Value = "0";
                hfEndDate.Value = "0";
                hfHours.Value = "0";
                hfStartDate.Value = "0";
                txtOrderNo.Text = "";
                txtOrderDate.Text = "";
                txtNote.Text = "";
                if (VicationType == 8)
                {
                    txtTimeStart_TextChanged(null, null);
                }
                else
                {
                    txtStartDate_TextChanged(null, null);
                }
                GetBalance();
                GetGrid();
            }
            else
            {
                MDirMaster.Messages(lblMessage, 3);
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/Default.aspx");
        }

        public void GetBalance()
        {
            int EmpID = Convert.ToInt32(hfEmpID.Value);
            if (EmpID > 0)
            {

                int Balance = Convert.ToInt32(hfBalance.Value);
                int VicationType = Convert.ToInt32(hfVicationTypeID.Value);
                string query = @"SELECT [VicationBalance], [EmployementStartDate], [MaturityDate] From EmployeesTBL
                                WHERE EmpID = @EmpID";
                SqlCommand cmd = new SqlCommand(query);
                cmd.Parameters.AddWithValue("@EmpID", EmpID);
                DataTable dt = MDirMaster.GetData(cmd, lblMessage);
                Balance = Convert.ToInt32(dt.Rows[0]["VicationBalance"]);
                lblStartDate.Text = Convert.ToDateTime(dt.Rows[0]["EmployementStartDate"]).ToString("yyyy/MM/dd");
                lblMaturity.Text = Convert.ToDateTime(dt.Rows[0]["MaturityDate"]).ToString("yyyy/MM/dd");
                if (VicationType == 8)
                {
                    lblVicationBalance.Text = Balance.ToString() + " ساعة";
                }
                else if (VicationType == 1)
                {

                    lblVicationBalance.Text = (Balance / MDirMaster.WorkHours).ToString() + " يوما";
                }
                else if (VicationType == 3)
                {
                    query = @"SELECT [SickLeavesBalance] From EmployeesTBL
                                WHERE EmpID = @EmpID";
                    cmd.CommandText = query;
                    dt = MDirMaster.GetData(cmd, lblMessage);
                    Balance = Convert.ToInt32(dt.Rows[0]["SickLeavesBalance"]);
                    lblVicationBalance.Text = (Balance / MDirMaster.WorkHours).ToString() + " يوما";
                }
                else if (VicationType == 2 || VicationType == 13)
                {
                    query = @"SELECT ISNULL(SUM([VicationInterval]),0)
                              FROM [HR].[dbo].[VicationsTBL]
	                          where [VicationTypeID]= @VicationType
	                          and IsActive=1
	                          and EmpID = @EmpID";
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@VicationType",VicationType);
                    dt = MDirMaster.GetData(cmd, lblMessage);
                    Balance = Convert.ToInt32(dt.Rows[0][0]);
                    lblVicationBalance.Text = " متمتع بـ " + (Balance / MDirMaster.WorkHours).ToString() + " يوما" + ddlVicationType.SelectedItem.Text + ".";
                    lblVicationBalance.BackColor = System.Drawing.Color.YellowGreen;
                    lblVicationBalance.ForeColor = System.Drawing.Color.Black;
                }
                else if (VicationType == 4)
                {
                    query = @"SELECT ISNULL(SUM([VicationInterval]),0)
                              FROM [HR].[dbo].[VicationsTBL]
	                          where [VicationTypeID]=4
	                          and IsActive=1
	                          and EmpID = @EmpID";
                    cmd.CommandText = query;
                    dt = MDirMaster.GetData(cmd, lblMessage);
                    Balance = Convert.ToInt32(dt.Rows[0][0]);
                    lblVicationBalance.Text = " لديه غياب " + (Balance / MDirMaster.WorkHours).ToString() + " يوما.";
                    lblVicationBalance.BackColor = System.Drawing.Color.YellowGreen;
                    lblVicationBalance.ForeColor = System.Drawing.Color.Black;
                }
                if ((VicationType != 2) && (VicationType != 4) && (VicationType != 13))
                {
                    lblVicationBalance.BackColor = System.Drawing.Color.Green;
                    lblVicationBalance.ForeColor = System.Drawing.Color.LightGray;
                }
            }
        }

        protected void txtStartDate_TextChanged(object sender, EventArgs e)
        {
            try
            {

                if ((txtStartDate.Text.Length >= 6) && (txtEndDate.Text.Length >= 6))
                {
                    DateTime StartDate = Convert.ToDateTime(txtStartDate.Text + " 8:00");
                    DateTime EndDate = Convert.ToDateTime(txtEndDate.Text + " 15:00");
                    hfStartDate.Value = StartDate.ToString();
                    hfEndDate.Value = EndDate.ToString();

                    double days, Hours = Convert.ToDouble(hfHours.Value);
                    int EmpID = Convert.ToInt32(hfEmpID.Value),
                    Balance = Convert.ToInt32(hfBalance.Value);
                    days = (int)((EndDate.AddDays(1)) - StartDate).TotalDays;
                    txtDaysCount.Text = days.ToString();
                    hfDays.Value = days.ToString();
                    Hours = days * MDirMaster.WorkHours;
                    hfHours.Value = Hours.ToString();
                    if (Hours <= 0)
                    {
                        lblMessage.Text = "الرجاء التأكد من فترة الاجازة";
                        return;
                    }
                    if (days < 0)
                    {
                        lblMessage.Text = "الرجاء التأكد من التأريخ";
                        return;
                    }

                    if (ddlVicationType.SelectedValue == "9")//اجازة وضع
                    {
                        txtDaysCount.Text = "180";
                        txtDaysCount_TextChanged(null, null);
                    }
                    else if ((ddlVicationType.SelectedValue == "5") || (ddlVicationType.SelectedValue == "6"))//اجازات الامومة الجزء الاول والثاني
                    {
                        txtDaysCount.Text = "180";
                        txtDaysCount_TextChanged(null, null);
                    }
                    else if (ddlVicationType.SelectedValue == "10")//إجازة ما قبل الوضع
                    {
                        txtDaysCount.Text = "21";
                        txtDaysCount_TextChanged(null, null);
                    }
                    else if (ddlVicationType.SelectedValue == "11")//إجازة ما بعد الوضع
                    {
                        txtDaysCount.Text = "51";
                        txtDaysCount_TextChanged(null, null);
                    }
                    // chack balance
                    if ((ddlVicationType.SelectedValue == "2")/*بدون راتب*/|| (ddlVicationType.SelectedValue == "4") /*غياب*/||
                        (ddlVicationType.SelectedValue == "5")/*أمومة الجزء الأول*/ || (ddlVicationType.SelectedValue == "6") /*أمومة الجزء الثاني*/||
                        (ddlVicationType.SelectedValue == "7"/*عقوبة*/) || (ddlVicationType.SelectedValue == "9"/*وضع*/))
                    {
                        //بدون رصيد
                    }
                    else if (ddlVicationType.SelectedValue == "3")// إجازة مرضية
                    {
                        //رصيد خاص بالإجازات المرضية
                        if (EmpID > 0)
                        {
                            string query = @"SELECT SickLeavesBalance From EmployeesTBL
                                WHERE EmpID = @EmpID";
                            SqlCommand cmd = new SqlCommand(query);
                            cmd.Parameters.AddWithValue("@EmpID", EmpID);
                            Balance = Convert.ToInt32(MDirMaster.ExecuteScaler(cmd, lblMessage, HttpContext.Current.Request.Path));
                            if (Hours > Balance)
                            {
                                lblMessage.Text = "لا يوجد رصيد كافي";
                            }
                        }
                    }
                    else if (ddlVicationType.SelectedValue == "1" || ddlVicationType.SelectedValue == "8")
                    {
                        //رصيد الإجازات الإعتيادية والزمنية
                        //double days, Hours = Convert.ToDouble(hfHours.Value);
                        //int EmpID = Convert.ToInt32(hfEmpID.Value), Balance = Convert.ToInt32(hfBalance.Value);
                        //days = (int)((EndDate.AddDays(1)) - StartDate).TotalDays;
                        //txtDaysCount.Text = days.ToString();
                        //hfDays.Value = days.ToString();
                        //Hours = days * MDirMaster.WorkHours;
                        //hfHours.Value = Hours.ToString();
                        //if (days < 0)
                        //{
                        //    lblMessage.Text = "الرجاء التأكد من التأريخ";
                        //    return;
                        //}
                        if (EmpID > 0)
                        {
                            string query = @"SELECT VicationBalance From EmployeesTBL
                                WHERE EmpID = @EmpID";
                            SqlCommand cmd = new SqlCommand(query);
                            cmd.Parameters.AddWithValue("@EmpID", EmpID);
                            Balance = Convert.ToInt32(MDirMaster.ExecuteScaler(cmd, lblMessage, HttpContext.Current.Request.Path));
                            if (Hours > Balance)
                            {
                                lblMessage.Text = "لا يوجد رصيد كافي";
                            }
                        }
                    }
                }
            }
            catch
            {
                lblMessage.Text = "الرجاء ادخال التاريخ بصورة صحيحة يوم/شهر/سنة او يوم-شهر-سنة";
                return;
            }
        }

        protected void txtTimeStart_TextChanged(object sender, EventArgs e)
        {
            //WebControl MyWebControl = sender as WebControl;
            //if (MyWebControl != null)
            //{
            //lblMessage.Text = "";
            //TextBox txt = txtTimeStart;
            try
            {
                //DateTime Time = Convert.ToDateTime(txt.Text);
                if ((txtTimeStart.Text.Length >= 4) && (txtTimeEnd.Text.Length >= 4))
                {
                    DateTime StartTime = Convert.ToDateTime(txtTimeDate.Text + " " + txtTimeStart.Text);
                    DateTime EndTime = Convert.ToDateTime(txtTimeDate.Text + " " + txtTimeEnd.Text);
                    hfStartDate.Value = StartTime.ToString();
                    hfEndDate.Value = EndTime.ToString();
                    double Hours = (EndTime - StartTime).TotalHours;
                    hfHours.Value = Hours.ToString();
                    if ((Hours >= 1) && (Hours <= 3))
                    {
                        // chack balance
                        string query = @"SELECT VicationBalance From EmployeesTBL
                                WHERE EmpID = @EmpID";
                        SqlCommand cmd = new SqlCommand(query);
                        cmd.Parameters.AddWithValue("@EmpID", hfEmpID.Value);
                        int Balance = Convert.ToInt32(MDirMaster.ExecuteScaler(cmd, lblMessage, HttpContext.Current.Request.Path));
                        hfBalance.Value = Balance.ToString();
                        if (Hours > Balance)
                        {
                            lblMessage.Text = "لا يوجد رصيد كافي";
                        }
                        else
                        {

                        }
                    }
                    else
                    {
                        lblMessage.Text = "الاجازة الزمنية يجب ان تكون بين ساعة و ثلاث ساعات ";
                    }
                }
            }
            catch
            {
                lblMessage.Text = "الرجاء ادخال الوقت بصورة صحيحة";
                //txt.Focus();
            }
            //}
        }

        protected void ddlVicationType_SelectedIndexChanged(object sender, EventArgs e)
        {
            int VicationType = Convert.ToInt32(hfVicationTypeID.Value = ddlVicationType.SelectedValue);
            if (VicationType == 8)//زمنية
            {
                divTime.Attributes["style"] = "display: inlineblock";
                divDate.Attributes["style"] = "display: none";
            }
            else if (VicationType == 0)//يرجى الاختيار
            {
                divDate.Attributes["style"] = "display: none";
                divTime.Attributes["style"] = "display: none";
            }
            else//إجازات يومية
            {
                divDate.Attributes["style"] = "display: inlineblock";
                divTime.Attributes["style"] = "display: none";
            }
            GetBalance();
        }

        protected void txtDaysCount_TextChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtDaysCount.Text) > 0)
            {
                DateTime StartDate = Convert.ToDateTime(hfStartDate.Value);
                DateTime EndDate;
                EndDate = (StartDate.AddDays((Convert.ToDouble(txtDaysCount.Text)) - 1)).AddHours(MDirMaster.WorkHours);
                txtEndDate.Text = EndDate.ToShortDateString();
                hfEndDate.Value = EndDate.ToString();
                hfDays.Value = txtDaysCount.Text;
                hfHours.Value = (Convert.ToInt32(txtDaysCount.Text) * 7).ToString();
            }
        }

        protected void txtOrderDate_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtOrderDate.Text.Length > 6)
                {
                    DateTime OrderDate = Convert.ToDateTime(txtOrderDate.Text);
                }
            }
            catch
            {
                lblMessage.Text = "الرجاء ادخال التاريخ بصورة صحيحة يوم/شهر/سنة او يوم-شهر-سنة";
                return;
            }
        }

        protected void RBAdd_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            if (rb.ID == "RBAdd")
            {
                pGrid.Visible = false;
                pForm.Visible = true;
                btnSubmit.Text = "إضافة";
            }
            else if (rb.ID == "RBEdit")
            {
                pGrid.Visible = true;
                pForm.Visible = false;

            }
        }

        protected void gvEmpVications_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            GridView gv = sender as GridView;
            gv.PageIndex = e.NewPageIndex;
            gv.SelectedIndex = -1;
            ddlSBranch_SelectedIndexChanged(null, null);
        }

        protected void gvEmpVications_RowDeleted(object sender, GridViewDeletedEventArgs e)
        {
        }

        protected void gvEmpVications_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int index = e.RowIndex;
            int VicationID = Convert.ToInt32(gvEmpVications.Rows[index].Cells[1].Text);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "DeleteVication ";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@VacationID", VicationID);
            cmd.Parameters.Add("@Result", System.Data.SqlDbType.Int);
            cmd.Parameters["@Result"].Direction = ParameterDirection.Output;
            MDirMaster.Execute(cmd, lblMessage, HttpContext.Current.Request.Path);
            int Result = Convert.ToInt32(cmd.Parameters["@Result"].Value);
            GetGrid();
            GetBalance();
            //if (Result == -1)
            //{
            //    MDirMaster.Messages(lblMessage, -1);
            //}
            //else
            //{
            //    MDirMaster.Messages(lblMessage, 1);
            //}
        }

        protected void rbGrid_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            if (rb.ID == "rbGrid")
            {
                MultiView1.SetActiveView(vwGrid);
                GetGrid();
            }
            else if (rb.ID == "rbReport")
            {
                MultiView1.SetActiveView(vwReport);
                GetGrid();
            }
        }

        protected void CrystalReportViewer1_Load(object sender, EventArgs e)
        {

            //Path = "~/Reports/ReportSource/rptEmpVacation.rpt";
            //crd.Load(Server.MapPath(Path));
            //crd.SetDatabaseLogon("reporter", "123", "192.168.0.49", "HR", true);
            //crd.RecordSelectionFormula = condition(crd.RecordSelectionFormula.ToString());
            //crd.Refresh();
            //string Orientation = crd.PrintOptions.PaperOrientation.ToString();
            //if (Orientation == "Portrait")
            //{
            //    crvReports.Zoom(110);
            //}
            //else
            //{
            //    //crvReports.PrintMode= crd.PrintOptions.PaperOrientation;
            //    crvReports.Zoom(80);

            //}
            //crvReports.ReportSource = crd;
            //crvReports.RefreshReport();
            //crvReports.Visible = true;
            ////crvReports
            //// crd.Close();
            //// crd.Dispose();
        }
    }
}