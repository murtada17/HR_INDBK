using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace HR_Salaries.Pages.Employee
{
    public partial class Employee : System.Web.UI.Page
    {

        string image;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string url = HttpContext.Current.Request.Path;
                string title = MDirMaster.HasPrivilage(url, lblMessage, true);
                if (string.IsNullOrEmpty(title))
                {
                    Session["msg"] = "9";
                    Response.Redirect("~/Pages/Default.aspx", false);
                }
                else
                {
                    Master.PageTitle = Title = title;
                    //search
                    MDirMaster.FillCombo("BranchID", "BranchDescAR", "BranchsTBL", ddlSBranch, true, lblMessage);
                    MDirMaster.FillCombo("DepartmentID", "DepartmentDescAR", "DepartmentTBL", ddlSDep, true, lblMessage);
                    MDirMaster.FillCombo("SectionID", "SectionDescAR", "SectionTBL", ddlSection, true, lblMessage);
                    //info
                    MDirMaster.FillCombo("BranchID", "BranchDescAR", "BranchsTBL", ddlIBranchs, true, lblMessage);
                    MDirMaster.FillCombo("DepartmentID", "DepartmentDescAR", "DepartmentTBL", ddlIDepartment, true, lblMessage);
                    MDirMaster.FillCombo("BloodID", "BloodType", "BloodTBL", ddlBloodType, true, lblMessage);
                    MDirMaster.FillCombo("GenderID", "GenderDescAR", "GendersTBL", ddlGender, true, lblMessage);
                    MDirMaster.FillCombo("StatusID", "StatusDescEN", "MaritalStatusTBL", ddlMarital, true, lblMessage);
                    MDirMaster.FillCombo("LicenseDegID", "LicenseDegDescAR", "LicenseDegTBL", ddlLicenseDigree, true, lblMessage);
                    MDirMaster.FillCombo("LicenseNameID", "LicenseNameAR", "LicenseNameTBL", ddlLicenseName, true, lblMessage);

                    txMDirrthDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                    txtJoinDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                    ddlSBranch_SelectedIndexChanged(null, null);
                    ddlIDepartment_SelectedIndexChanged(null, null);

                    ddlLicenseName.SelectedValue = "1";
                }
            }
            lblMessage.Text = "";
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            int EmpID = Convert.ToInt32(hfEmpID.Value);
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@BranchID", ddlIBranchs.SelectedValue);
            cmd.Parameters.AddWithValue("@DepartmentID", ddlIDepartment.SelectedValue);
            cmd.Parameters.AddWithValue("@SectionID", ddlISection.SelectedValue);
            cmd.Parameters.AddWithValue("@LicenseDigreeID", ddlLicenseDigree.SelectedValue);
            cmd.Parameters.AddWithValue("@LicenseNameID", ddlLicenseName.SelectedValue);
            cmd.Parameters.AddWithValue("@GenderID", ddlGender.SelectedValue);
            cmd.Parameters.AddWithValue("@MaritalStatusID", ddlMarital.SelectedValue);
            cmd.Parameters.AddWithValue("@BloodID", ddlBloodType.SelectedValue);

            cmd.Parameters.AddWithValue("@FirstNameEN", txtFNameEN.Text);
            cmd.Parameters.AddWithValue("@MidNameEN", txtMNameEN.Text);
            cmd.Parameters.AddWithValue("@LastNameEN", txtLNameEN.Text);
            cmd.Parameters.AddWithValue("@MotherNameEN", txtMotherNameEN.Text);
            cmd.Parameters.AddWithValue("@FirstNameAR", txtFNameAR.Text);
            cmd.Parameters.AddWithValue("@MidNameAR", txtMNameAR.Text);
            cmd.Parameters.AddWithValue("@LastNameAR", txtLNameAR.Text);
            cmd.Parameters.AddWithValue("@MotherNameAR", txtMotherNameAR.Text);
            cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
            cmd.Parameters.AddWithValue("@PhoneNo", txtPhone.Text);

            cmd.Parameters.Add("@BirthDate", System.Data.SqlDbType.Date);
            cmd.Parameters["@BirthDate"].Value = (txMDirrthDate.Text);
            cmd.Parameters.Add("@JoinDate", System.Data.SqlDbType.Date);
            cmd.Parameters["@JoinDate"].Value = (txtJoinDate.Text);
            cmd.Parameters.AddWithValue("@EmergencyComtactName", txtContactName.Text);
            cmd.Parameters.AddWithValue("@EmergencyPhoneNo", txtContactPhone.Text);
            cmd.Parameters.AddWithValue("@LandLine", txtLandLine.Text);
            cmd.Parameters.AddWithValue("@ChildrenCount", txtChildren.Text);
            //cmd.Parameters.AddWithValue("@PersonalEmail", txtEmailPer.Text);
            cmd.Parameters.AddWithValue("@Notes", txtNotes.Text);
            cmd.Parameters.AddWithValue("@VicationBalance", txtVicationBalance.Text);
            cmd.Parameters.AddWithValue("@IsActive", chbIsActive.Checked);
            cmd.Parameters.AddWithValue("@IsManager", chbIsManager.Checked);
            cmd.Parameters.AddWithValue("@IsManagerAssist", chbIsManagerAssist.Checked);
            cmd.Parameters.AddWithValue("@IsTemp", chbIsTemp.Checked);
            cmd.Parameters.AddWithValue("@IsBlocked", chbIsBlocked.Checked);
            cmd.Parameters.AddWithValue("@IsCEOAssist", chbIsCEOAssist.Checked);
            cmd.Parameters.AddWithValue("@IsSectionManager", chbIsSectionManager.Checked);
            cmd.Parameters.AddWithValue("@IsActing", chbIsActing.Checked);
            cmd.Parameters.AddWithValue("@IsCEO", chbIsCEO.Checked);
            cmd.Parameters.AddWithValue("@IsExpert", chbIsExpert.Checked);
            cmd.Parameters.AddWithValue("@IsEmployee", chbIsEmployee.Checked);
            cmd.Parameters.AddWithValue("@IsDaily", chbIsDaily.Checked);
            cmd.Parameters.AddWithValue("@IsContract", chbIsContract.Checked);
            cmd.Parameters.AddWithValue("@MaturityDate", txtMaturityDate.Text);
            cmd.Parameters.AddWithValue("@Image", "Image");
            cmd.Parameters.Add("@ID_No", SqlDbType.Int, 32);
            cmd.Parameters["@ID_No"].Value = txtIdNo.Text;

            if (EmpID > 0)
            {
                if (fuPhoto.HasFile)
                {
                    for (int i = 1; i < 100; i++)
                    {
                        HttpPostedFile uploadfile = fuPhoto.PostedFile;
                        string fileType = uploadfile.ContentType;
                        if (fileType == "application/pdf")
                        {
                            string fileName = EmpID + "_Image_" + i + uploadfile.FileName.Substring(uploadfile.FileName.LastIndexOf('.'));
                            string ImageFullPath = Server.MapPath(MDirMaster.Path + fileName);
                            if (System.IO.File.Exists(ImageFullPath))
                            {

                            }
                            else
                            {
                                if (uploadfile.ContentLength > 0)
                                {
                                    uploadfile.SaveAs(ImageFullPath);
                                    break;
                                }
                            }
                        }
                    }
                }
                if (fuDocs.HasFile)
                {
                    for (int j = 1; j < 100; j++)
                    {
                        HttpPostedFile uploadfile = fuDocs.PostedFile;
                        string fileType = uploadfile.ContentType;
                        if (fileType == "application/pdf")
                        {
                            string fileName = EmpID + "_Docs_" + j + uploadfile.FileName.Substring(uploadfile.FileName.LastIndexOf('.'));
                            string DocFullPath = Server.MapPath(MDirMaster.Path + fileName);
                            if (System.IO.File.Exists(DocFullPath))
                            {

                            }
                            else
                            {
                                if (uploadfile.ContentLength > 0)
                                {
                                    uploadfile.SaveAs(DocFullPath);
                                    break;
                                }
                            }
                        }
                    }
                }

                cmd.CommandText = @" DECLARE @result bit = 0;
                                    BEGIN TRAN
                                    set @Result = (select (IIF(((SELECT count([ID_No])  FROM [dbo].[EmployeesTBL] WHERE [ID_No] =@ID_No and EmpID != @EmpID) > 0) ,0,1)))
                                    IF(@Result =1)
                                    	BEGIN
                                    		UPDATE EmployeesTBL 
                                                 SET  BranchID= @BranchID,DepartmentID= @DepartmentID, SectionID= @SectionID, FirstNameEN=@FirstNameEN,MidNameEN= @MidNameEN,LastNameEN= @LastNameEN, MotherNameEN= @MotherNameEN,
                                                      FirstNameAR=  @FirstNameAR,MidNameAR= @MidNameAR,LastNameAR= @LastNameAR, MotherNameAR= @MotherNameAR, Address= @Address,PhoneNo= @PhoneNo, LicenseDigreeID= @LicenseDigreeID,
                                                      LicenseNameID=@LicenseNameID, GenderID= @GenderID, BirthDate= @BirthDate, EmergencyComtactName= @EmergencyComtactName, VicationBalance=@VicationBalance, ID_No = @ID_No, EmergencyPhoneNo= @EmergencyPhoneNo,
                                                      LandLine= @LandLine, MaritalStatusID= @MaritalStatusID, ChildrenCount= @ChildrenCount, BloodID= @BloodID, Notes= @Notes, JoinDate= @JoinDate, IsActive= @IsActive, IsManager=@IsManager,
                                                      IsCEOAssist = @IsCEOAssist, IsSectionManager = @IsSectionManager, IsActing =@IsActing, IsManagerAssist= @IsManagerAssist, IsBlocked= @IsBlocked, IsTemp =@IsTemp,
                                                      IsCEO = @IsCEO, IsExpert =@IsExpert, IsEmployee= @IsEmployee, IsDaily= @IsDaily, IsContract =@IsContract, MaturityDate = @MaturityDate
                                                  WHERE EmpID= @EmpID;
                                    		Commit TRAN
                                    	END
                                    ELSE
                                    	BEGIN
                                    		Rollback TRAN
                                    	END
                                    select @result";
                cmd.Parameters.AddWithValue("@EmpID", EmpID);
                if (Convert.ToBoolean(MDirMaster.ExecuteScaler(cmd, lblMessage, HttpContext.Current.Request.Path)))
                {
                    btnCancel_Click(null, null);
                }
                else
                {
                    MDirMaster.Messages(lblMessage, "رقم الهوية مكرر.");
                }
            }

            else
            {
                cmd.CommandText = @" SET @ID_No = (SELECT isnull(MAX(ID_No),0) + 1 FROM EmployeesTBL);
                        INSERT INTO EmployeesTBL 
                                    ( BranchID, DepartmentID, SectionID, FirstNameEN, MidNameEN, LastNameEN, MotherNameEN, FirstNameAR, MidNameAR, LastNameAR, MotherNameAR, Address, PhoneNo, Image, LicenseDigreeID, LicenseNameID,
                         GenderID, BirthDate, EmergencyComtactName, EmergencyPhoneNo, LandLine, MaritalStatusID, ChildrenCount, BloodID, CurrentLocation, IsCEOAssist, IsSectionManager, IsActing, 
                         Notes, JoinDate, IsActive, IsManager, IsManagerAssist, IsCEO, IsExpert, IsEmployee, IsDaily, IsContract, IsBlocked, VicationBalance, StartedWork, IsTemp, ID_NO, MaturityDate)
                                    VALUES (@BranchID, @DepartmentID, @SectionID, @FirstNameEN, @MidNameEN, @LastNameEN, @MotherNameEN, @FirstNameAR, @MidNameAR, @LastNameAR, @MotherNameAR, @Address, @PhoneNo, @Image, @LicenseDigreeID, @LicenseNameID,
                         @GenderID, @BirthDate, @EmergencyComtactName, @EmergencyPhoneNo, @LandLine, @MaritalStatusID, @ChildrenCount, @BloodID, 1, @IsCEOAssist, @IsSectionManager, @IsActing,
                         @Notes, @JoinDate, 'True', @IsManager, @IsManagerAssist, @IsCEO, @IsExpert, @IsEmployee, @IsDaily, @IsContract, 'False', 0, 0, @IsTemp, @ID_No, @MaturityDate );
                       SELECT SCOPE_IDENTITY() AS [SCOPE_IDENTITY];";
                cmd.Parameters["@ID_No"].Direction = ParameterDirection.Output;
                int EmployeeID = Convert.ToInt32(MDirMaster.ExecuteScaler(cmd, lblMessage, HttpContext.Current.Request.Path));
                if (EmployeeID > 0)
                {
                    string OrderDesc = @"تعيين في " + ddlIBranchs.SelectedItem.Text + " / " + ddlIDepartment.SelectedItem.Text;
                    if (MDirMaster.AdminOrderAdd(EmployeeID, Convert.ToInt32(ddlIBranchs.SelectedValue), Convert.ToInt32(ddlIDepartment.SelectedValue), OrderDesc, txtAdminOrderNo.Text, txtJoinDate.Text, 2, lblMessage))
                    {
                        string name = txtFNameAR.Text + ' ' + txtMNameAR.Text + ' ' + txtLNameAR.Text;
                        string message = "رقم هوية الموظف\\ة " + name + ' ' + cmd.Parameters["@ID_No"].Value.ToString();
                        MDirMaster.MsgBox(message, this, this);
                        btnCancel_Click(null, null);
                    }
                    else
                    {
                        MDirMaster.Messages(lblMessage, 0);
                    }
                }
                else
                {
                    MDirMaster.Messages(lblMessage, 0);
                }
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            hfEmpID.Value = "-1";
            FillData(getdata());
            //ddlSBranch_SelectedIndexChanged(null, null);
            pForm.Visible = false;
            fuPhoto.Enabled = false;
            //pGrid.Enabled = true;
            pGrid.Visible = false;
            RBAdd.Checked = false;
            RBEdit.Checked = false;
            MDirMaster.ClearControls(pForm);
        }

        protected void ddlSBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Condition = "";
            bool check = false;
            bool Parameter = false, Parameter2 = false;
            if (Convert.ToInt32(ddlSBranch.SelectedValue) > 0)
            {
                Condition += " dbo.EmployeesTBL.BranchID = " + ddlSBranch.SelectedValue;
                check = true;
            }
            if (Convert.ToInt32(ddlSDep.SelectedValue) > 0)
            {
                if (check)
                {
                    Condition += " AND ";
                }
                Condition += " dbo.EmployeesTBL.DepartmentID = " + ddlSDep.SelectedValue;
                check = true;
            }
            if (Convert.ToInt32(ddlSection.SelectedValue) > 0)
            {
                if (check)
                {
                    Condition += " AND ";
                }
                Condition += " dbo.EmployeesTBL.SectionID = " + ddlSDep.SelectedValue;
                check = true;
            }
            if (!string.IsNullOrEmpty(txtFNameARS.Text))
            {
                if (check)
                {
                    Condition += " AND ";
                }
                Condition += " dbo.EmployeesTBL.FirstNameAR + ' ' + dbo.EmployeesTBL.MidNameAR + ' ' + dbo.EmployeesTBL.LastNameAR LIKE @NAME";
                check = true;
                Parameter = true;
            }
            if (!string.IsNullOrEmpty(txtsID_No.Text))
            {
                if (check)
                {
                    Condition += " AND ";
                }
                Condition += " ID_No LIKE @ID_No";
                check = true;
                Parameter2 = true;
            }
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = @"SELECT         dbo.EmployeesTBL.EmpID, dbo.EmployeesTBL.FirstNameAR + ' ' + dbo.EmployeesTBL.MidNameAR + ' ' + dbo.EmployeesTBL.LastNameAR AS [اسم الموظف عربي], ID_No [رقم الهوية], dbo.BranchsTBL.BranchDescAR AS الفرع, 
                                               dbo.DepartmentTBL.DepartmentDescAR AS القسم, dbo.SectionTBL.SectionDescAR AS الشعبة, dbo.EmployeesTBL.JoinDate AS [تاريخ التعيين], dbo.EmployeesTBL.LastModification AS [تاريخ اخر تعديل], 
                                               dbo.EmployeesTBL.IsActive AS [فعال ؟], dbo.EmployeesTBL.CurrentLocation AS [حالي ؟], dbo.EmployeesTBL.Notes AS ملاحظات
                               FROM            dbo.EmployeesTBL INNER JOIN
                                               dbo.BranchsTBL ON dbo.EmployeesTBL.BranchID = dbo.BranchsTBL.BranchID INNER JOIN
                                               dbo.DepartmentTBL ON dbo.EmployeesTBL.DepartmentID = dbo.DepartmentTBL.DepartmentID INNER JOIN
                                               dbo.SectionTBL ON dbo.EmployeesTBL.SectionID = dbo.SectionTBL.SectionID";
            if (check)
            {
                cmd.CommandText += " WHERE " + Condition;
            }
            if (RBName.Checked)
            {
                cmd.CommandText += " ORDER BY [اسم الموظف عربي]";
            }
            else if (RBDate.Checked)
            {
                cmd.CommandText += " ORDER BY [تاريخ التعيين]";
            }
            if (Parameter)
            {
                cmd.Parameters.AddWithValue("@Name", txtFNameARS.Text + "%");
            }
            if (Parameter2)
            {
                cmd.Parameters.AddWithValue("@ID_No", txtsID_No.Text + "%");
            }
            MDirMaster.FillGrid(cmd, gvEmployees, lblMessage);
        }

        public DataTable getdata()
        {
            DataTable dt = new DataTable();
            int EmpID = Convert.ToInt32(hfEmpID.Value);
            if (EmpID > 0)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"SELECT        EmpID, BranchID, DepartmentID, SectionID, FirstNameEN, MidNameEN, LastNameEN, MotherNameEN, FirstNameAR, MidNameAR, LastNameAR, MotherNameAR, 
                                         Address, PhoneNo, Image, LicenseDigreeID, LicenseNameID, GenderID, BasicSalary, VisaCardNo, BirthDate, IsBlocked, EmergencyComtactName, 
                                         EmergencyPhoneNo, LandLine, MaritalStatusID, ChildrenCount, BloodID, Notes, JoinDate, IsActive, IsManager, IsManagerAssist, IsTemp, VicationBalance,
                                         IsCEOAssist, IsSectionManager, IsActing, IsCEO, IsExpert, IsEmployee, IsDaily, IsContract, (SELECT OrderNo FROM AdminOrdersTBL where EmpID = @EmpID and OrderTypeID = 2)AS OrderNo, MaturityDate, ID_No
                                    FROM            dbo.EmployeesTBL
                                    WHERE        (EmpID = @EmpID)";
                cmd.Parameters.AddWithValue("@EmpID", EmpID);
                dt = MDirMaster.GetData(cmd, lblMessage);
            }
            return dt;
        }

        public bool FillData(DataTable dt)
        {
            bool status = false;
            try
            {
                if (dt.Rows.Count == 1)
                {
                    hfEmpID.Value = dt.Rows[0]["EmpID"].ToString();
                    try
                    {
                        ddlIBranchs.SelectedValue = dt.Rows[0]["BranchID"].ToString();
                        ddlIDepartment.SelectedValue = dt.Rows[0]["DepartmentID"].ToString();
                        ddlISection.SelectedValue = dt.Rows[0]["SectionID"].ToString();
                        ddlGender.SelectedValue = dt.Rows[0]["GenderID"].ToString();
                        ddlBloodType.SelectedValue = dt.Rows[0]["BloodID"].ToString();
                        ddlLicenseDigree.SelectedValue = dt.Rows[0]["LicenseDigreeID"].ToString();
                        ddlLicenseName.SelectedValue = dt.Rows[0]["LicenseNameID"].ToString();
                        ddlMarital.SelectedValue = dt.Rows[0]["MaritalStatusID"].ToString();
                    }
                    catch
                    {
                    }
                    image = dt.Rows[0]["Image"].ToString();

                    txtFNameEN.Text = dt.Rows[0]["FirstNameEN"].ToString();
                    txtMNameEN.Text = dt.Rows[0]["MidNameEN"].ToString();
                    txtLNameEN.Text = dt.Rows[0]["LastNameEN"].ToString();
                    txtMotherNameEN.Text = dt.Rows[0]["MotherNameEN"].ToString();
                    txtFNameAR.Text = dt.Rows[0]["FirstNameAR"].ToString();
                    txtMNameAR.Text = dt.Rows[0]["MidNameAR"].ToString();
                    txtLNameAR.Text = dt.Rows[0]["LastNameAR"].ToString();
                    txtMotherNameAR.Text = dt.Rows[0]["MotherNameAR"].ToString();
                    txtAddress.Text = dt.Rows[0]["Address"].ToString();
                    txtPhone.Text = dt.Rows[0]["PhoneNo"].ToString();

                    txtContactName.Text = dt.Rows[0]["EmergencyComtactName"].ToString();
                    txtContactPhone.Text = dt.Rows[0]["EmergencyPhoneNo"].ToString();
                    txtLandLine.Text = dt.Rows[0]["LandLine"].ToString();
                    txtChildren.Text = dt.Rows[0]["ChildrenCount"].ToString();
                    //txtEmailInt.Text = dt.Rows[0]["InternalEmail"].ToString();
                    txtIdNo.Text = dt.Rows[0]["ID_No"].ToString();
                    txtNotes.Text = dt.Rows[0]["Notes"].ToString();
                    txtVicationBalance.Text = dt.Rows[0]["VicationBalance"].ToString();
                    txtAdminOrderNo.Text = dt.Rows[0]["OrderNo"].ToString();
                    txtAdminOrderNo.Enabled = false;

                    txMDirrthDate.Text = Convert.ToDateTime(dt.Rows[0]["BirthDate"]).ToString("yyyy-MM-dd");
                    txtJoinDate.Text = Convert.ToDateTime(dt.Rows[0]["JoinDate"]).ToString("yyyy-MM-dd");
                    try
                    {
                        txtMaturityDate.Text = Convert.ToDateTime(dt.Rows[0]["MaturityDate"]).ToString("yyyy-MM-dd");
                    }
                    catch
                    {
                        lblMessage.Text = "تاريخ الاستحقاق غير معروف.";
                    }
                    chbIsActive.Checked = Convert.ToBoolean(dt.Rows[0]["IsActive"]);
                    chbIsManager.Checked = Convert.ToBoolean(dt.Rows[0]["IsManager"]);
                    chbIsManagerAssist.Checked = Convert.ToBoolean(dt.Rows[0]["IsManagerAssist"]);
                    chbIsTemp.Checked = Convert.ToBoolean(dt.Rows[0]["IsTemp"]);
                    chbIsBlocked.Checked = Convert.ToBoolean(dt.Rows[0]["IsBlocked"]);
                    chbIsCEOAssist.Checked = Convert.ToBoolean(dt.Rows[0]["IsCEOAssist"]);
                    chbIsSectionManager.Checked = Convert.ToBoolean(dt.Rows[0]["IsSectionManager"]);
                    chbIsActing.Checked = Convert.ToBoolean(dt.Rows[0]["IsActing"]);
                    chbIsCEO.Checked = Convert.ToBoolean(dt.Rows[0]["IsCEO"]);

                    ////////Your patching has been modified and replaced with better patching//////
                    try { chbIsExpert.Checked = Convert.ToBoolean(dt.Rows[0]["IsExpert"]); }
                    catch { chbIsExpert.Checked = false; }
                    
                    
                    try { chbIsEmployee.Checked = Convert.ToBoolean(dt.Rows[0]["IsEmployee"]); }
                    catch { chbIsEmployee.Checked = false; }

                    
                    try { chbIsDaily.Checked = Convert.ToBoolean(dt.Rows[0]["IsDaily"]); }
                    catch { chbIsDaily.Checked = false; }

                    
                    try { chbIsContract.Checked = Convert.ToBoolean(dt.Rows[0]["IsContract"]); }
                    catch { chbIsContract.Checked = false; }

                    ////////////////////////////////////////////////////////////////////////////


                    //files 
                    string[] fileEntries = Directory.GetFiles(Server.MapPath(MDirMaster.Path));
                    links.InnerHtml = "";
                    foreach (string fileName in fileEntries)
                    {
                        int x = fileName.LastIndexOf(@"\");
                        if (fileName.Substring(x + 1, fileName.IndexOf("_", x) - x - 1) == hfEmpID.Value)
                        {
                            links.InnerHtml += " <a href='" + System.Web.VirtualPathUtility.ToAbsolute("~/Pages/OpenDoc.ashx?FT=" + fileName.Substring(fileName.LastIndexOf(".") + 1) + "&FP=" + fileName.Substring(x + 1, fileName.LastIndexOf(".") - x - 1)) + "' target='_Blank' style='direction:ltr; text-align:left' >" + fileName.Substring(x + 1) + "</a> <br/>";
                        }
                    }
                }
                else
                {
                    ddlIBranchs.SelectedValue = "0".ToString();
                    ddlIDepartment.SelectedValue = "0".ToString();
                    ddlGender.SelectedValue = "0".ToString();
                    ddlBloodType.SelectedValue = "0".ToString();
                    ddlLicenseDigree.SelectedValue = "0".ToString();
                    ddlLicenseName.SelectedValue = "0".ToString();
                    ddlMarital.SelectedValue = "0".ToString();

                    image = "";

                    txtFNameEN.Text = "";
                    txtMNameEN.Text = "";
                    txtLNameEN.Text = "";
                    txtMotherNameEN.Text = "";
                    txtFNameAR.Text = "";
                    txtMNameAR.Text = "";
                    txtLNameAR.Text = "";
                    txtMotherNameAR.Text = "";
                    txtAddress.Text = "";
                    txtPhone.Text = "";

                    txtContactName.Text = "";
                    txtContactPhone.Text = "";
                    txtLandLine.Text = "";
                    txtChildren.Text = "";
                    //txtEmailInt.Text = "";
                    txtIdNo.Text = "";
                    txtNotes.Text = "";

                    txMDirrthDate.Text = "";
                    txtJoinDate.Text = "";
                    txtMaturityDate.Text = "";

                    chbIsActive.Checked = true;
                    chbIsBlocked.Checked = false;
                    chbIsManager.Checked = false;
                    chbIsManagerAssist.Checked = false;
                    chbIsActing.Checked = false;
                    chbIsSectionManager.Checked = false;
                    chbIsCEOAssist.Checked = false;
                    chbIsTemp.Checked = false;
                    chbIsCEO.Checked = false;
                    chbIsExpert.Checked = false;
                    chbIsEmployee.Checked = false;
                    chbIsDaily.Checked = false;
                    chbIsContract.Checked = false;
                }
                status = true;

            }
            catch (Exception ex)
            {
                MDirMaster.Messages(lblMessage, ex.Message);
                status = false;
            }
            return status;
        }

        protected void txtJoinDate_TextChanged(object sender, EventArgs e)
        {
            WebControl MyWebControl = sender as WebControl;
            if (MyWebControl != null)
            {
                lblMessage.Text = "";
                TextBox txt = (TextBox)MyWebControl;
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

        protected void gvEmployees_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            int index = e.NewSelectedIndex;
            int EmpID = Convert.ToInt32(gvEmployees.Rows[index].Cells[1].Text);
            hfEmpID.Value = EmpID.ToString();
            if (EmpID > 0)
            {
                if (FillData(getdata()))
                {
                    pForm.Visible = true;
                    fuPhoto.Enabled = true;
                    //pGrid.Enabled = false;
                    pGrid.Visible = false;
                    txtFNameEN.Focus();
                }
                else
                {
                    MDirMaster.Messages(lblMessage, 0);
                }
            }
            else
            {
                MDirMaster.Messages(lblMessage, 3);
            }
        }

        protected void gvEmployees_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            GridView gv = sender as GridView;
            gv.PageIndex = e.NewPageIndex;
            gv.SelectedIndex = -1;
            ddlSBranch_SelectedIndexChanged(null, null);
        }

        protected void RBAdd_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            if (rb.ID == "RBAdd")
            {
                pGrid.Visible = false;
                pForm.Visible = true;
                btnSubmit.Text = "إضافة";
                txtIdNo.Enabled = false;
                MDirMaster.ClearControls(pForm);
            }
            else if (rb.ID == "RBEdit")
            {
                pGrid.Visible = true;
                pForm.Visible = false;
                btnSubmit.Text = "تعديل";
                txtIdNo.Enabled = true;
            }
        }

        protected void ddlIDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            string con = "";
            con = "[DepartmentID] = " + ddlIDepartment.SelectedValue;
            if (Convert.ToInt32(ddlIDepartment.SelectedValue) > 0)
            {
                MDirMaster.FillCombo("SectionID", "SectionDescAR", "SectionTBL", ddlISection, con, lblMessage);
            }
            else
            {
                MDirMaster.FillCombo("SectionID", "SectionDescAR", "SectionTBL", ddlISection, true, lblMessage);
            }
            if (ddlISection.Items.Count > 1)
            {
                //ddlISection.SelectedValue = "3";
            }
        }
    }
}