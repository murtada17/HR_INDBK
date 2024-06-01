using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HR_Salaries.Pages
{
    public partial class ALForm1 : System.Web.UI.Page
    {
        string AddOrUpdate = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                
                MDirMaster.FillCombo("INDEX_FIELD", "SALUTATION", "Al_Salutation", TITLE, "1=1", lblMessage);
                MDirMaster.FillCombo("INDEX_FIELD", "MARITAL_STATUS", "Al_Marital_Status", MARITAL_STATUS, "1=1", lblMessage);
                MDirMaster.FillCombo("INDEX_FIELD", "CLIENT_COUNTRY", "Al_Country", CLIENT_COUNTRY, "1=1", lblMessage);
                MDirMaster.FillCombo("INDEX_FIELD", "CLIENT_LANGUAGE", "Al_languages", CLIENT_LANGUAGE, "1=1", lblMessage);
                MDirMaster.FillCombo("INDEX_FIELD", "CLIENT_COUNTRY", "Al_Country", NATIONALITY, "1=1", lblMessage);

            }


        }

        // Serch in EmployeesTBL
        protected void btnSerch_Click(object sender, EventArgs e)
        {
            SqlCommand cmd_Search = new SqlCommand();


            cmd_Search.CommandText = @"SELECT [EmpID]
              ,[ID_No]
              ,[BranchID]
              ,[DepartmentID]
              ,[SectionID]
              ,[FirstNameEN]
              ,[MidNameEN]
              ,[LastNameEN]
              ,[MotherNameEN]
              ,[FirstNameAR]
              ,[MidNameAR]
          
          FROM [HR].[dbo].[EmployeesTBL]
        Where [FirstNameEN] = @FirstNameEN
        ";

            cmd_Search.Parameters.AddWithValue("@FirstNameEN", txtSerch.Text);

            MDirMaster.FillGrid(cmd_Search, GriSerch, lblMessage);
        }


        // Serch in alfile_tb
        protected void btnSerchUpdate_Click(object sender, EventArgs e)
        {
            SqlCommand cmd_Search = new SqlCommand();


            cmd_Search.CommandText = @"SELECT     
      [LAST_NAME]
      ,[FIRST_NAME]
      ,[BIRTH_NAME]
      ,[FATHER_NAME]
      ,[EMBOSS_LINE_1]   
      ,[CONTRACT_REFERENCE]
     
  FROM [HR].[dbo].[alfile_tb]
        Where [CONTRACT_REFERENCE] = @CONTRACT_REFERENCE
        ";

            cmd_Search.Parameters.AddWithValue("@CONTRACT_REFERENCE", txtUpdate.Text);

            MDirMaster.FillGrid(cmd_Search, GVUpdate, lblMessage);
        }


        // GV
        protected void GriSerch_PageIndexChanging(object sender, EventArgs e)
        {
            AddUpdate.Text = "add";

            string id = GriSerch.SelectedRow.Cells[6].Text;
            SqlCommand cmd_GV = new SqlCommand();

            cmd_GV.CommandText = @"SELECT [EmpID]
                          ,[ID_No]
                          ,[BranchID]
                          ,[DepartmentID]
                          ,[SectionID]
                          ,[FirstNameEN]
                          ,[MidNameEN]
                          ,[LastNameEN]
                          ,[MotherNameEN]
                          ,[FirstNameAR]
                          ,[MidNameAR]
                          ,[LastNameAR]
                          ,[MotherNameAR]
                          ,[Address]
                          ,[EmployeRank]
                          ,[PhoneNo]
                          ,[Image]
                          ,[LicenseDigreeID]
                          ,[LicenseNameID]
                          ,[GenderID]
                          ,[BasicSalary]
                          ,[OldBasicSalary]
                          ,[VisaCardNo]
                          ,[BirthDate]
                          ,[JoinDate]
                          ,[EmployementStartDate]
                          ,[LocationStartDate]
                          ,[LeaveDate]
                          ,[MaturityDate]
                          ,[VicationBalance]
                          ,[SickLeavesBalance]
                          ,[LastModification]
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
                          ,[IsTemp]
                          ,[IsSuposeNoWork]
                          ,[EmergencyComtactName]
                          ,[EmergencyPhoneNo]
                          ,[LandLine]
                          ,[MaritalStatusID]
                          ,[ChildrenCount]
                          ,[ResignReasonID]
                          ,[EmployeGroup]
                          ,[BloodID]
                          ,[PersonalEmail]
                          ,[Notes]
                          ,[imgsign]
                          ,[SpouseJob]
                          ,[EmailProcessed]
                          ,[InternalEmail]
                          ,[StartedWork]
                      FROM [HR].[dbo].[EmployeesTBL] 
                      where FirstNameEN= @id";

            cmd_GV.Parameters.AddWithValue("@id", id);

            DataTable dt = MDirMaster.GetData(cmd_GV, lblMessage);

            string fname = dt.Rows[0][9].ToString();
            string id_num = dt.Rows[0][1].ToString();
            lblempid.Text = id_num;
            FIRST_NAME.Text = fname;
            Panel2.Visible = true;


            //MDirMaster.ToCSV(dt, "C:/HR/cc.csv");


        }




        //  GV for Update
        protected void GVUpdate_PageIndexChanging(object sender, EventArgs e)
        {
            //MDirMaster.FillCombo("INDEX_FIELD", "CLIENT_LANGUAGE", "Al_languages", CLIENT_LANGUAGE, "1=1", lblMessage);
            //MDirMaster.FillCombo("INDEX_FIELD", "CLIENT_COUNTRY", "Al_Country", NATIONALITY, "1=1", lblMessage);
            AddUpdate.Text = "update";
            
            string id = GVUpdate.SelectedRow.Cells[6].Text;
            CONTRACTREFERENCE.Text = id;
            SqlCommand cmd_GV = new SqlCommand();

            cmd_GV.CommandText = @"SELECT 
        [id]
      ,[EmpID]
      ,[RECORD_DATE]
      ,[INSTITUTION_NUMBER]
      ,[LAST_NAME]
      ,[FIRST_NAME]
      ,[BIRTH_NAME]
      ,[FATHER_NAME]
      ,[EMBOSS_LINE_1]
      ,[EMBOSS_LINE_2]
      ,[EMBOSS_LINE_3]
      ,[TITLE]
      ,[MARITAL_STATUS]
      ,[TEL_PRIVATE]
      ,[TEL_WORK]
      ,[FAX_PRIVATE]
      ,[FAX_WORK]
      ,[ID_NUMBER]
      ,[PASSPORT_NUMBER]
      ,[DRIVING_LICENSE]
      ,[BIRTH_DATE]
      ,[BIRTH_PLACE]
      ,[CLIENT_COUNTRY]
      ,[CLIENT_CITY]
      ,[CLIENT_LANGUAGE]
      ,[NATIONALITY]
      
  FROM [HR].[dbo].[alfile_tb] where [CONTRACT_REFERENCE] = @CONTRACT_REFERENCE";

            cmd_GV.Parameters.AddWithValue("@CONTRACT_REFERENCE", id);

            DataTable dt = MDirMaster.GetData(cmd_GV, lblMessage);

            string cl = dt.Rows[0][24].ToString();
            string co = dt.Rows[0][25].ToString();

            lbl_id.Text = dt.Rows[0][0].ToString();

            RECORD_DATE.Text = dt.Rows[0][2].ToString();
            INSTITUTION_NUMBER.Text = dt.Rows[0]["INSTITUTION_NUMBER"].ToString();
            LAST_NAME.Text = dt.Rows[0][4].ToString();
            FIRST_NAME.Text = dt.Rows[0][5].ToString();
            BIRTH_NAME.Text = dt.Rows[0][6].ToString();
            FATHER_NAME.Text = dt.Rows[0][7].ToString();
            EMBOSS_LINE_1.Text = dt.Rows[0][8].ToString();
            EMBOSS_LINE_2.Text = dt.Rows[0][9].ToString();
            EMBOSS_LINE_3.Text = dt.Rows[0][10].ToString();
            TITLE.Text = dt.Rows[0][11].ToString();
            MARITAL_STATUS.Text = dt.Rows[0][12].ToString();
            TEL_PRIVATE.Text = dt.Rows[0][13].ToString();
            TEL_WORK.Text = dt.Rows[0][14].ToString();
            FAX_PRIVATE.Text = dt.Rows[0][15].ToString();
            FAX_WORK.Text = dt.Rows[0][16].ToString();
            ID_NUMBER.Text = dt.Rows[0][17].ToString();
            PASSPORT_NUMBER.Text = dt.Rows[0][18].ToString();
            DRIVING_LICENSE.Text = dt.Rows[0][19].ToString();
            BIRTH_DATE.Text = dt.Rows[0][20].ToString();
            BIRTH_PLACE.Text = dt.Rows[0][21].ToString();
            CLIENT_COUNTRY.Text = dt.Rows[0][22].ToString();
            CLIENT_CITY.Text = dt.Rows[0][23].ToString();
            CLIENT_LANGUAGE.SelectedValue = dt.Rows[0]["CLIENT_LANGUAGE"].ToString();
            NATIONALITY.SelectedValue = dt.Rows[0]["NATIONALITY"].ToString();


            //lblempid.Text = id_num;
            Panel2.Visible = true;



           // MDirMaster.ToCSV(dt, "C:/HR/cc.csv");


        }










        protected void ButAdd_OnClick(object sender, EventArgs e)
        {
            PalAdd.Visible = true;
            PalUpdate.Visible = false;

        }

        protected void ButUpdate_OnClick(object sender, EventArgs e)
        {
            PalAdd.Visible = false;
            PalUpdate.Visible = true;

        }
        








        protected void btnSend_Click(object sender, EventArgs e)
        {

            if (TITLE.SelectedValue=="0")
            {
                lblMessage.Text = "Must be select TITLE";
                return;
            }
            if (MARITAL_STATUS.SelectedValue == "0")
            {
                lblMessage.Text = "Must be select MARITAL_STATUS";
                return;
            }
         
 if (CLIENT_COUNTRY.SelectedValue == "0")
            {
                lblMessage.Text = "Must be select CLIENT_COUNTRY";
                return;
            }
            
                if (CLIENT_LANGUAGE.SelectedValue == "0")
            {
                lblMessage.Text = "Must be select CLIENT_LANGUAGE";
                return;
            }
            
                    if (NATIONALITY.SelectedValue == "0")
            {
                lblMessage.Text = "Must be select NATIONALITY";
                return;
            }

            string EmpID_S = lblempid.Text;


            SqlCommand cmd_max = new SqlCommand();
            SqlCommand cmd = new SqlCommand();
            SqlCommand cmd_update = new SqlCommand();

            cmd_update.CommandText = @"update HR.[dbo].[alfile_tb] set
               [EmpID] =                       '" + EmpID_S + @"',
               [RECORD_DATE] =                  '" + Convert.ToDateTime(RECORD_DATE.Text).ToString("yyyyMMdd") + @"',
               [INSTITUTION_NUMBER] =           '" + INSTITUTION_NUMBER.Text.PadLeft(8, '0') + @"',
               [LAST_NAME] =                    '" + LAST_NAME.Text.PadRight(25, ' ') + @"',
               [FIRST_NAME] =                   '" + FIRST_NAME.Text.PadRight(15, ' ') + @"',
               [BIRTH_NAME] =                   '" + BIRTH_NAME.Text.PadRight(20, ' ') + @"',
               [FATHER_NAME] =                  '" + FATHER_NAME.Text.PadRight(20, ' ') + @"',
               [EMBOSS_LINE_1] =                '" + EMBOSS_LINE_1.Text.PadRight(26, ' ') + @"',
               [EMBOSS_LINE_2]  =               '" + EMBOSS_LINE_2.Text.PadRight(26, ' ') + @"',
               [EMBOSS_LINE_3]  =               '" + EMBOSS_LINE_3.Text.PadRight(26, ' ') + @"',
               [TITLE] =                        '" + TITLE.Text + @"',
               [MARITAL_STATUS] =               '" + MARITAL_STATUS.Text + @"',
               [TEL_PRIVATE] =                  '" + TEL_PRIVATE.Text.PadRight(15, ' ') + @"',
               [TEL_WORK] =                     '" + TEL_WORK.Text.PadRight(15, ' ') + @"',
               [FAX_PRIVATE] =                  '" + FAX_PRIVATE.Text.PadRight(15, ' ') + @"',
               [FAX_WORK] =                     '" + FAX_WORK.Text.PadRight(15, ' ') + @"',
               [ID_NUMBER] =                    '" + ID_NUMBER.Text.PadRight(15, ' ') + @"',
               [PASSPORT_NUMBER] =              '" + PASSPORT_NUMBER.Text.PadRight(15, ' ') + @"',
               [DRIVING_LICENSE] =              '" + DRIVING_LICENSE.Text.PadRight(15, ' ') + @"',
               [BIRTH_DATE] =                   '" + Convert.ToDateTime(BIRTH_DATE.Text).ToString("yyyyMMdd") + @"',
               [BIRTH_PLACE] =                  '" + BIRTH_PLACE.Text.PadRight(15, ' ') + @"',
               [CLIENT_COUNTRY] =               '" + CLIENT_COUNTRY.Text.PadLeft(3, '0') + @"',
               [CLIENT_CITY] =                  '" + CLIENT_CITY.Text.PadRight(13, ' ') + @"',
               [CLIENT_LANGUAGE] =              '" + CLIENT_LANGUAGE.Text.PadLeft(3, '0') + @"',
               [NATIONALITY] =                  '" + NATIONALITY.Text.PadLeft(3, '0') + @"'
                where CONTRACT_REFERENCE = @CONTRACT_REFERENCE ";

            cmd_update.Parameters.AddWithValue("@CONTRACT_REFERENCE", CONTRACTREFERENCE.Text);


            cmd.CommandText = @"INSERT INTO HR.[dbo].[alfile_tb]
               ([EmpID]
               ,[RECORD_DATE]
               ,[INSTITUTION_NUMBER]
               ,[LAST_NAME]
               ,[FIRST_NAME]
               ,[BIRTH_NAME]
               ,[FATHER_NAME]
               ,[EMBOSS_LINE_1]
               ,[EMBOSS_LINE_2]
               ,[EMBOSS_LINE_3]
               ,[TITLE]
               ,[MARITAL_STATUS]
               ,[TEL_PRIVATE]
               ,[TEL_WORK]
               ,[FAX_PRIVATE]
               ,[FAX_WORK]
               ,[ID_NUMBER]
               ,[PASSPORT_NUMBER]
               ,[DRIVING_LICENSE]
               ,[BIRTH_DATE]
               ,[BIRTH_PLACE]
               ,[CLIENT_COUNTRY]
               ,[CLIENT_CITY]
               ,[CLIENT_LANGUAGE]
               ,[NATIONALITY]
  )
            VALUES
               ('" + EmpID_S + @"',
                '" + Convert.ToDateTime(RECORD_DATE.Text).ToString("yyyyMMdd") + @"',
                '" + INSTITUTION_NUMBER.Text.PadLeft(8, '0') + @"',
                '" + LAST_NAME.Text.PadRight(25, ' ') + @"',
                '" + FIRST_NAME.Text.PadRight(15, ' ') + @"',
                '" + BIRTH_NAME.Text.PadRight(20, ' ') + @"',
                '" + FATHER_NAME.Text.PadRight(20, ' ') + @"',
                '" + EMBOSS_LINE_1.Text.PadRight(26, ' ') + @"',
                '" + EMBOSS_LINE_2.Text.PadRight(26, ' ') + @"',
                '" + EMBOSS_LINE_3.Text.PadRight(26, ' ') + @"',
                '" + TITLE.Text + @"',
                '" + MARITAL_STATUS.Text + @"',
                '" + TEL_PRIVATE.Text.PadRight(15, ' ') + @"',
                '" + TEL_WORK.Text.PadRight(15, ' ') + @"',
                '" + FAX_PRIVATE.Text.PadRight(15, ' ') + @"',
                '" + FAX_WORK.Text.PadRight(15, ' ') + @"',
                '" + ID_NUMBER.Text.PadRight(15, ' ') + @"',
                '" + PASSPORT_NUMBER.Text.PadRight(15, ' ') + @"',
                '" + DRIVING_LICENSE.Text.PadRight(15, ' ') + @"',
                '" + Convert.ToDateTime(BIRTH_DATE.Text).ToString("yyyyMMdd") + @"',
                '" + BIRTH_PLACE.Text.PadRight(15, ' ') + @"',
                '" + CLIENT_COUNTRY.Text.PadLeft(3, '0') + @"',
                '" + CLIENT_CITY.Text.PadRight(13, ' ') + @"',
                
                '" + CLIENT_LANGUAGE.Text.PadLeft(3, '0') + @"',
'" + NATIONALITY.Text.PadLeft(3, '0') + @"'
                
                )";

            try
            {
                if (AddUpdate.Text == "add")
                {
                    MDirMaster.Execute(cmd, lblMessage, HttpContext.Current.Request.Path);

                    cmd_max.CommandText = @"SELECT MAX ([id]) as maxid
                                            FROM[HR].[dbo].[alfile_tb]";

                    DataTable dt = MDirMaster.GetData(cmd_max, lblMessage);
                    int param1Variable = int.Parse(dt.Rows[0][0].ToString());
                    Session["sID"] = Server.HtmlEncode(param1Variable.ToString());
                    Session["update_ref"] = "";
                    Response.Redirect("ALForm2.aspx", false);
                }

                else
                {
                    MDirMaster.Execute(cmd_update, lblMessage, HttpContext.Current.Request.Path);
                    Session["sID"] = "";
                    Session["update_ref"] = Server.HtmlEncode(lbl_id.Text.ToString());
                    Response.Redirect("ALForm2.aspx", false);
                }
            }

            catch(Exception ex)
            {
                lblMessage.Text = ex.ToString();
            }





            
        }

        
    }
}
   