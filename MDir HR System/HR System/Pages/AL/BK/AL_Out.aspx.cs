using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HR_Salaries.Pages.AL_Out
{
    public partial class AL_Out : System.Web.UI.Page
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
                MDirMaster.FillCombo("INDEX_FIELD", "EMPLOYMENT_STATUS", "Al_EMPLOYMENT_STATUS", EMPLOYMENT_STATUS, "1=1", lblMessage);
                MDirMaster.FillCombo("INDEX_FIELD", "WORKING_SECTOR", "Al_Working_Sector", WORKING_SECTOR, "1=1", lblMessage);
                MDirMaster.FillCombo("INDEX_FIELD", "RISK_GROUP", "Al_Risk_Group", RISK_GROUP, "1=1", lblMessage);
                MDirMaster.FillCombo("INDEX_FIELD", "RESIDENT_STATUS", "Al_Resident_Status", RESIDENCE_STATUS, "1=1", lblMessage);
                MDirMaster.FillCombo("ISO_CODE", "SWIFT_CODE", "Al_Currency", LIMIT_CURRENCY, "1=1", lblMessage);
                MDirMaster.FillCombo("INDEX_FIELD", "EMPLOYMENT_POSITION", "Al_EMPLOYMENT_POSITION", EMPLOYMENT_POSITION, "1=1", lblMessage);
                MDirMaster.FillCombo("id", "status_yn", "Al_YN", SECURE_REGISTRATION_INDICATOT, "1=1", lblMessage);
                MDirMaster.FillCombo("id", "status_yn", "Al_YN", CMO_REGISTRATION_INDICATOR, "1=1", lblMessage);
                MDirMaster.FillCombo("id", "status_yn", "Al_YN", COM_STIKER_REGISTRATION_INDICATRO, "1=1", lblMessage);
                MDirMaster.FillCombo("id", "status_yn", "Al_YN", STICKER_CARD, "1=1", lblMessage);
                MDirMaster.FillCombo("INDEX_FIELD", "delivery_method", "Al_DeliveryMethod", DELIVERY_METHOD, "1=1", lblMessage);
                MDirMaster.FillCombo("id", "institusion", "AL_institusion_TBL", ADDR_LINE_33, "1=1", lblMessage);

                DELIVERY_METHOD.SelectedIndex = 0;
                EXTENTION_FLAG.Items.Add("1");
                SETTLEMENT_METHOD.Items.Add("950");
                CLIENT_LEVEL.Items.Add("001");
                BILLING_LEVEL.Items.Add("001");
                INCOME.Items.Add("1  ");
                LIMIT_CURRENCY.SelectedIndex = 368;
            }


        }

        // Serch in EmployeesTBL
        //protected void btnSerch_Click(object sender, EventArgs e)
        //{
        //    SqlCommand cmd_Search = new SqlCommand();


        //    cmd_Search.CommandText = @"SELECT [EmpID]
        //      ,[ID_No]
        //      ,[BranchID]
        //      ,[DepartmentID]
        //      ,[SectionID]
        //      ,[FirstNameEN]
        //      ,[MidNameEN]
        //      ,[LastNameEN]
        //      ,[MotherNameEN]
        //      ,[FirstNameAR]
        //      ,[MidNameAR]
          
        //  FROM [HR].[dbo].[EmployeesTBL]
        //Where [FirstNameEN] = @FirstNameEN
        //";

        //    cmd_Search.Parameters.AddWithValue("@FirstNameEN", txtSerch.Text);

        //    MDirMaster.FillGrid(cmd_Search, GriSerch, lblMessage);
        //}


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
     
  FROM [HR].[dbo].[alfile_out_tb]
        Where [CONTRACT_REFERENCE] = @CONTRACT_REFERENCE
        ";

            cmd_Search.Parameters.AddWithValue("@CONTRACT_REFERENCE", txtUpdate.Text);

            MDirMaster.FillGrid(cmd_Search, GVUpdate, lblMessage);
        }


        // GV
        //protected void GriSerch_PageIndexChanging(object sender, EventArgs e)
        //{
        //    AddUpdate.Text = "add";

        //    string id = GriSerch.SelectedRow.Cells[6].Text;
        //    SqlCommand cmd_GV = new SqlCommand();

        //    cmd_GV.CommandText = @"SELECT [EmpID]
        //                  ,[ID_No]
        //                  ,[BranchID]
        //                  ,[DepartmentID]
        //                  ,[SectionID]
        //                  ,[FirstNameEN]
        //                  ,[MidNameEN]
        //                  ,[LastNameEN]
        //                  ,[MotherNameEN]
        //                  ,[FirstNameAR]
        //                  ,[MidNameAR]
        //                  ,[LastNameAR]
        //                  ,[MotherNameAR]
        //                  ,[Address]
        //                  ,[EmployeRank]
        //                  ,[PhoneNo]
        //                  ,[Image]
        //                  ,[LicenseDigreeID]
        //                  ,[LicenseNameID]
        //                  ,[GenderID]
        //                  ,[BasicSalary]
        //                  ,[OldBasicSalary]
        //                  ,[VisaCardNo]
        //                  ,[BirthDate]
        //                  ,[JoinDate]
        //                  ,[EmployementStartDate]
        //                  ,[LocationStartDate]
        //                  ,[LeaveDate]
        //                  ,[MaturityDate]
        //                  ,[VicationBalance]
        //                  ,[SickLeavesBalance]
        //                  ,[LastModification]
        //                  ,[CurrentLocation]
        //                  ,[TempTransfare]
        //                  ,[IsActive]
        //                  ,[IsBlocked]
        //                  ,[IsManager]
        //                  ,[IsManagerAssist]
        //                  ,[IsCEO]
        //                  ,[IsCEOAssist]
        //                  ,[IsSectionManager]
        //                  ,[IsActing]
        //                  ,[IsTemp]
        //                  ,[IsSuposeNoWork]
        //                  ,[EmergencyComtactName]
        //                  ,[EmergencyPhoneNo]
        //                  ,[LandLine]
        //                  ,[MaritalStatusID]
        //                  ,[ChildrenCount]
        //                  ,[ResignReasonID]
        //                  ,[EmployeGroup]
        //                  ,[BloodID]
        //                  ,[PersonalEmail]
        //                  ,[Notes]
        //                  ,[imgsign]
        //                  ,[SpouseJob]
        //                  ,[EmailProcessed]
        //                  ,[InternalEmail]
        //                  ,[StartedWork]
        //              FROM [HR].[dbo].[EmployeesTBL] 
        //              where FirstNameEN= @id";

        //    cmd_GV.Parameters.AddWithValue("@id", id);

        //    DataTable dt = MDirMaster.GetData(cmd_GV, lblMessage);

        //    string fname = dt.Rows[0][9].ToString();
        //    string id_num = dt.Rows[0][1].ToString();
        //    lblempid.Text = id_num;
        //    FIRST_NAME.Text = fname;
        //    Panel2.Visible = true;


        //    //MDirMaster.ToCSV(dt, "C:/HR/cc.csv");
        //    //filll();

        //}


        //  GV for Update
        protected void GVUpdate_PageIndexChanging(object sender, EventArgs e)
        {

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
      ,[EMPLOYMENT_STATUS]
      ,[CLIENT_BRANCH]
      ,[VAT_REG_NUMBER]
      ,[REGISTRATION_NUMBER]
      ,[CLIENT_ORGANIZATION]
      ,[BANK_CLEARING_NUMBER]
      ,[BANK_TEL_NUMBER]
      ,[BANK_REFERECE]
      ,[NOTE_TEXT]
      ,[Bank_Contact_Name]
      ,[EMPLOYMENT_POSITION]
      ,[EMPLOYER_NAME]
      ,[EMPLOYMENT_DATE]
      ,[WORKING_SECTOR]
      ,[RISK_GROUP]
      ,[MOBILE_NO1]
      ,[MOBILE_NO2]
      ,[FATHERS_NAME_L2]
      ,[CLIENT_NUMBER_RBS]
      ,[PARINT_CLIENT_NUMBER_RBS]
      ,[SETTLEMENT_BANK_NAME]
      ,[SETTLEMENT_BANK_CITY]
      ,[BANK_GUARANTEE]
      ,[SERVICE_CONTRACT_ID]
      ,[SERVICE_ID]
      ,[EXTENTION_FLAG]
      ,[CLIENT_NUMBER]
      ,[CONDITION_SET]
      ,[CLIENT_LIMIT]
      ,[LIMIT_CURRENCY]
      ,[COUNTER_BANK_ACCOUNT]
      ,[DOMICILIATION_COUNTER_BANK_ACCOUNT_]
      ,[COUNTER_BANK_ACCT_NAME]
      ,[SETTLEMENT_METHOD]
      ,[CLIENT_LEVEL]
      ,[BILLING_LEVEL]
      ,[PARENT_APPL_NUMBER]
      ,[CONTRACT_REFERENCE]
      ,[INSTITUTION_ACC_OFFICER]
      ,[PROVIDER_ACCT_OFFICER]
      ,[CARD_NUMBER]
      ,[EXPIRY_DATE]
      ,[MOTHERS_MAIDEN_NAME]
      ,[RESIDENCE_STATUS]
      ,[COMPANY_NAME]
      ,[TIME_WITH_PRESENT_EMPLOYER]
      ,[INCOME]
      ,DATE_OF_APPLICATION
      ,SECURE_REGISTRATION_INDICATOT
      ,CMO_REGISTRATION_INDICATOR
      ,CMO_MOBILE_NUMBER
      ,COM_STIKER_REGISTRATION_INDICATRO
      ,IBAN_NUMBER
      ,STICKER_CARD
      ,DELIVERY_METHOD
      ,ADDR_LINE_1
      ,ADDR_LINE_2
      ,ADDR_LINE_3
      ,STATE
      ,OTHER
      ,POST_CODE
      ,ADDRESS_CLIENT_CITY
      ,EMAIL_ADDRESS
      ,EMAIL_ADDRESS2
      ,ADR1_NAME_OF_CLIENT
      ,ADR2STREET1
      ,ADR3STREET2
      ,ADR4_STATE
      ,ADR5_OTHER
      ,POST_CODE1
      ,ADDRESS_CLIENT_CITY1
      ,EMAIL_ADDRESS1
      
  FROM [HR].[dbo].[alfile_out_tb] where [CONTRACT_REFERENCE] = @CONTRACT_REFERENCE";

            cmd_GV.Parameters.AddWithValue("@CONTRACT_REFERENCE", id);

            DataTable dt = MDirMaster.GetData(cmd_GV, lblMessage);

            string cl = dt.Rows[0][24].ToString();
            string co = dt.Rows[0][25].ToString();

            lbl_id.Text = dt.Rows[0][0].ToString();

            string CLIENTCOUNTRY = dt.Rows[0]["CLIENT_COUNTRY"].ToString();

            string dss = dt.Rows[0][2].ToString();

            DateTime dsd = DateTime.ParseExact(dss.ToString(), "yyyyMMdd", null);

            string RECORD_DATE_CD = dsd.ToString("MM/dd/yyy");



            RECORD_DATE.Text = RECORD_DATE_CD;
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



            CLIENT_COUNTRY.SelectedValue = CLIENTCOUNTRY;  /////////////////////////////////////////////////////////////////////



            CLIENT_CITY.Text = dt.Rows[0][23].ToString();
            CLIENT_LANGUAGE.SelectedValue = dt.Rows[0]["CLIENT_LANGUAGE"].ToString();
            NATIONALITY.SelectedValue = dt.Rows[0]["NATIONALITY"].ToString();
            EMPLOYMENT_STATUS.SelectedValue = dt.Rows[0]["EMPLOYMENT_STATUS"].ToString();
            CLIENT_BRANCH.Text = dt.Rows[0]["CLIENT_BRANCH"].ToString();
            REGISTRATION_NUMBER.Text = dt.Rows[0]["REGISTRATION_NUMBER"].ToString();
            CLIENT_ORGANIZATION.Text = dt.Rows[0]["CLIENT_ORGANIZATION"].ToString();
            BANK_CLEARING_NUMBER.Text = dt.Rows[0]["BANK_CLEARING_NUMBER"].ToString();
            BANK_TEL_NUMBER.Text = dt.Rows[0]["BANK_TEL_NUMBER"].ToString();
            BANK_REFERECE.Text = dt.Rows[0]["BANK_REFERECE"].ToString();
            NOTE_TEXT.Text = dt.Rows[0]["NOTE_TEXT"].ToString();
            Bank_Contact_Name.Text = dt.Rows[0]["Bank_Contact_Name"].ToString();
            EMPLOYMENT_POSITION.Text = dt.Rows[0]["EMPLOYMENT_POSITION"].ToString();
            EMPLOYER_NAME.Text = dt.Rows[0]["EMPLOYER_NAME"].ToString();
            EMPLOYMENT_DATE.Text = dt.Rows[0]["EMPLOYMENT_DATE"].ToString();

            //////////////////////////////////////////////////////////////
            string WORKING_SECTOR_S = dt.Rows[0]["WORKING_SECTOR"].ToString().PadLeft(3, '0');
            if (WORKING_SECTOR_S == "0" || WORKING_SECTOR_S == "000")
                 {

                 }
            else {
                WORKING_SECTOR.SelectedValue = dt.Rows[0]["WORKING_SECTOR"].ToString().PadLeft(3, '0');
                 }


            //////////////////////////////////////////////////////////////



            //////////////////////////////////////////////////////////////
            string RISK_GROUP_S = dt.Rows[0]["RISK_GROUP"].ToString().PadLeft(3, '0');
            if (RISK_GROUP_S == "0" || RISK_GROUP_S == "000")
            {

            }
            else
            {
                RISK_GROUP.SelectedValue = dt.Rows[0]["RISK_GROUP"].ToString().PadLeft(3, '0');
            }


            //////////////////////////////////////////////////////////////


            MOBILE_NO1.Text = dt.Rows[0]["MOBILE_NO1"].ToString();
            MOBILE_NO2.Text = dt.Rows[0]["MOBILE_NO2"].ToString();
            FATHERS_NAME_L2.Text = dt.Rows[0]["FATHERS_NAME_L2"].ToString();
            CLIENT_NUMBER_RBS.Text = dt.Rows[0]["CLIENT_NUMBER_RBS"].ToString();
            PARINT_CLIENT_NUMBER_RBS.Text = dt.Rows[0]["PARINT_CLIENT_NUMBER_RBS"].ToString();
            SETTLEMENT_BANK_NAME.Text = dt.Rows[0]["SETTLEMENT_BANK_NAME"].ToString();
            SETTLEMENT_BANK_CITY.Text = dt.Rows[0]["SETTLEMENT_BANK_CITY"].ToString();
            BANK_GUARANTEE.Text = dt.Rows[0]["BANK_GUARANTEE"].ToString();
            SERVICE_CONTRACT_ID.Text = dt.Rows[0]["SERVICE_CONTRACT_ID"].ToString();
            SERVICE_ID.Text = dt.Rows[0]["SERVICE_ID"].ToString();
            EXTENTION_FLAG.Text = dt.Rows[0]["EXTENTION_FLAG"].ToString();
            CLIENT_NUMBER.Text = dt.Rows[0]["CLIENT_NUMBER"].ToString();
            CONDITION_SET.Text = dt.Rows[0]["CONDITION_SET"].ToString();
            CLIENT_LIMIT.Text = dt.Rows[0]["CLIENT_LIMIT"].ToString();

            ////////////////////////////////////////////////////////////////
            //LIMIT_CURRENCY.Text = dt.Rows[0]["LIMIT_CURRENCY"].ToString();
            string LIMIT_CURRENCY_S = dt.Rows[0]["LIMIT_CURRENCY"].ToString().PadLeft(3, '0');
            if (LIMIT_CURRENCY_S == "0" || LIMIT_CURRENCY_S == "000")
            {

            }
            else
            {
                LIMIT_CURRENCY.SelectedValue = dt.Rows[0]["LIMIT_CURRENCY"].ToString().PadLeft(3, '0');
            }

            /////////////////////////////////////////////////////////////////////////
            COUNTER_BANK_ACCOUNT.Text = dt.Rows[0]["COUNTER_BANK_ACCOUNT"].ToString();
            DOMICILIATION_COUNTER_BANK_ACCOUNT_.Text = dt.Rows[0]["DOMICILIATION_COUNTER_BANK_ACCOUNT_"].ToString();
            COUNTER_BANK_ACCT_NAME.Text = dt.Rows[0]["COUNTER_BANK_ACCT_NAME"].ToString();
            SETTLEMENT_METHOD.Text = dt.Rows[0]["SETTLEMENT_METHOD"].ToString();
            CLIENT_LEVEL.Text = dt.Rows[0]["CLIENT_LEVEL"].ToString();
            BILLING_LEVEL.Text = dt.Rows[0]["BILLING_LEVEL"].ToString();
            PARENT_APPL_NUMBER.Text = dt.Rows[0]["PARENT_APPL_NUMBER"].ToString();
            CONTRACT_REFERENCE.Text = dt.Rows[0]["CONTRACT_REFERENCE"].ToString();
            INSTITUTION_ACC_OFFICER.Text = dt.Rows[0]["INSTITUTION_ACC_OFFICER"].ToString();
            PROVIDER_ACCT_OFFICER.Text = dt.Rows[0]["PROVIDER_ACCT_OFFICER"].ToString();
            CARD_NUMBER.Text = dt.Rows[0]["CARD_NUMBER"].ToString();
            EXPIRY_DATE.Text = dt.Rows[0]["EXPIRY_DATE"].ToString();
            MOTHERS_MAIDEN_NAME.Text = dt.Rows[0]["MOTHERS_MAIDEN_NAME"].ToString();
            RESIDENCE_STATUS.Text = (dt.Rows[0]["RESIDENCE_STATUS"].ToString()).PadLeft(3, '0');
            COMPANY_NAME.Text = dt.Rows[0]["COMPANY_NAME"].ToString();
            TIME_WITH_PRESENT_EMPLOYER.Text = dt.Rows[0]["TIME_WITH_PRESENT_EMPLOYER"].ToString();
            INCOME.Text = dt.Rows[0]["INCOME"].ToString();
            DATE_OF_APPLICATION.Text = dt.Rows[0]["DATE_OF_APPLICATION"].ToString();
            SECURE_REGISTRATION_INDICATOT.Text = dt.Rows[0]["SECURE_REGISTRATION_INDICATOT"].ToString();
            CMO_REGISTRATION_INDICATOR.Text = dt.Rows[0]["CMO_REGISTRATION_INDICATOR"].ToString();
            CMO_MOBILE_NUMBER.Text = dt.Rows[0]["CMO_MOBILE_NUMBER"].ToString();
            COM_STIKER_REGISTRATION_INDICATRO.Text = dt.Rows[0]["COM_STIKER_REGISTRATION_INDICATRO"].ToString();
            IBAN_NUMBER.Text = dt.Rows[0]["IBAN_NUMBER"].ToString();
            STICKER_CARD.Text = dt.Rows[0]["STICKER_CARD"].ToString();
            DELIVERY_METHOD.Text = dt.Rows[0]["DELIVERY_METHOD"].ToString();
            ADDR_LINE_1.Text = dt.Rows[0]["ADDR_LINE_1"].ToString();
            ADDR_LINE_2.Text = dt.Rows[0]["ADDR_LINE_2"].ToString();
            ADDR_LINE_33.Text = dt.Rows[0]["ADDR_LINE_3"].ToString();
            STATE.Text = dt.Rows[0]["STATE"].ToString();
            OTHER.Text = dt.Rows[0]["OTHER"].ToString();
            POST_CODE.Text = dt.Rows[0]["POST_CODE"].ToString();
            ADDRESS_CLIENT_CITY.Text = dt.Rows[0]["ADDRESS_CLIENT_CITY"].ToString();
            EMAIL_ADDRESS.Text = dt.Rows[0]["EMAIL_ADDRESS"].ToString();
            EMAIL_ADDRESS2.Text = dt.Rows[0]["EMAIL_ADDRESS2"].ToString();
            ADR1_NAME_OF_CLIENT.Text = dt.Rows[0]["ADR1_NAME_OF_CLIENT"].ToString();
            ADR2STREET1.Text = dt.Rows[0]["ADR2STREET1"].ToString();
            ADR3STREET2.Text = dt.Rows[0]["ADR3STREET2"].ToString();
            ADR4_STATE.Text = dt.Rows[0]["ADR4_STATE"].ToString();
            ADR5_OTHER.Text = dt.Rows[0]["ADR5_OTHER"].ToString();
            POST_CODE1.Text = dt.Rows[0]["POST_CODE1"].ToString();
            ADDRESS_CLIENT_CITY1.Text = dt.Rows[0]["ADDRESS_CLIENT_CITY1"].ToString();
            EMAIL_ADDRESS1.Text = dt.Rows[0]["EMAIL_ADDRESS1"].ToString();
            

            //lblempid.Text = id_num;
            Panel2.Visible = true;



            // MDirMaster.ToCSV(dt, "C:/HR/cc.csv");


        }



        protected void ButAdd_OnClick(object sender, EventArgs e)
        {
           // PalAdd.Visible = true;
           // PalUpdate.Visible = false;
            Panel2.Visible = true;
        }

        protected void ButUpdate_OnClick(object sender, EventArgs e)
        {
            PalAdd.Visible = false;
            PalUpdate.Visible = true;

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            updatee();
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {

            if (TITLE.SelectedValue == "0")
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

            string EMPLOYMENT_DATE_S = "";
            if (EMPLOYMENT_DATE.Text != "")
            {
                EMPLOYMENT_DATE_S = Convert.ToDateTime(EMPLOYMENT_DATE.Text).ToString("yyyyMMdd");
            }
            else
            {
                EMPLOYMENT_DATE_S = "";
            }

            string RECORD_DATE_S = "";
            if (EMPLOYMENT_DATE.Text != "")
            {
                RECORD_DATE_S = Convert.ToDateTime(RECORD_DATE.Text).ToString("yyyyMMdd");
            }
            else
            {
                RECORD_DATE_S = "";
            }

            string EXPIRY_DATE_S = "";
            if (EXPIRY_DATE.Text != "")
            {
                EXPIRY_DATE_S = Convert.ToDateTime(EXPIRY_DATE.Text).ToString("yyyyMMdd");
            }
            else
            {
                EXPIRY_DATE_S = "";
            }

            string DATE_OF_APPLICATION_S = "";
            if (EMPLOYMENT_DATE.Text != "")
            {
                DATE_OF_APPLICATION_S = Convert.ToDateTime(DATE_OF_APPLICATION.Text).ToString("yyyyMMdd");
            }
            else
            {
                DATE_OF_APPLICATION_S = "";
            }


            string EmpID_S = lblempid.Text;


            SqlCommand cmd_max = new SqlCommand();
            SqlCommand cmd = new SqlCommand();
            SqlCommand cmd_update = new SqlCommand();

            cmd_update.CommandText = @"update HR.[dbo].[alfile_out_tb] set
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
               [NATIONALITY] =                  '" + NATIONALITY.Text.PadLeft(3, '0') + @"',

                EMPLOYMENT_STATUS=              '" + EMPLOYMENT_STATUS.Text.PadLeft(3, '0') + @"',
                CLIENT_BRANCH=                  '" + CLIENT_BRANCH.Text.PadLeft(3, '0') + @"',
                VAT_REG_NUMBER=                 '" + VAT_REG_NUMBER.Text.PadRight(15, ' ') + @"',
                REGISTRATION_NUMBER=            '" + REGISTRATION_NUMBER.Text.PadRight(15, ' ') + @"',
                CLIENT_ORGANIZATION=            '" + CLIENT_ORGANIZATION.Text.PadRight(8, ' ') + @"',
                BANK_CLEARING_NUMBER=           '" + BANK_CLEARING_NUMBER.Text.PadRight(8, ' ') + @"',
                BANK_TEL_NUMBER=                '" + BANK_TEL_NUMBER.Text.PadRight(15, ' ') + @"',
                BANK_REFERECE=                  '" + BANK_REFERECE.Text.PadRight(8, ' ') + @"',
                NOTE_TEXT=                      '" + NOTE_TEXT.Text.PadRight(100, ' ') + @"',
                Bank_Contact_Name=              '" + Bank_Contact_Name.Text.PadRight(35, ' ') + @"',
                EMPLOYMENT_POSITION=            '" + EMPLOYMENT_POSITION.Text.PadLeft(3, '0') + @"',
                EMPLOYER_NAME=                  '" + EMPLOYER_NAME.Text.PadRight(35, ' ') + @"',
                EMPLOYMENT_DATE=                '" + EMPLOYMENT_DATE_S + @"',         
                WORKING_SECTOR =                '" + WORKING_SECTOR.Text.PadLeft(3, '0') + @"',
                RISK_GROUP=                     '" + RISK_GROUP.Text.PadLeft(3, '0') + @"',
                MOBILE_NO1=                     '" + MOBILE_NO1.Text.PadRight(15, ' ') + @"',
                MOBILE_NO2=                     '" + MOBILE_NO2.Text.PadRight(15, ' ') + @"',
                FATHERS_NAME_L2=                '" + FATHERS_NAME_L2.Text.PadRight(35, ' ') + @"',
                CLIENT_NUMBER_RBS=              '" + CLIENT_NUMBER_RBS.Text.PadRight(20, ' ') + @"',
                PARINT_CLIENT_NUMBER_RBS=       '" + PARINT_CLIENT_NUMBER_RBS.Text.PadRight(20, ' ') + @"',
                SETTLEMENT_BANK_NAME=           '" + SETTLEMENT_BANK_NAME.Text.PadRight(35, ' ') + @"',
                SETTLEMENT_BANK_CITY=           '" + SETTLEMENT_BANK_CITY.Text.PadRight(20, ' ') + @"',
                BANK_GUARANTEE=                 '" + BANK_GUARANTEE.Text.PadRight(18, ' ') + @"',
                SERVICE_CONTRACT_ID=            '" + SERVICE_CONTRACT_ID.Text + @"',
                SERVICE_ID=                     '" + SERVICE_ID.Text + @"',
                EXTENTION_FLAG=                 '" + EXTENTION_FLAG.Text + @"',
                CLIENT_NUMBER=                  '" + CLIENT_NUMBER.Text.PadLeft(8, '0') + @"',
                CONDITION_SET=                  '" + CONDITION_SET.Text.PadLeft(3, '0') + @"',
                CLIENT_LIMIT=                   '" + CLIENT_LIMIT.Text.PadLeft(18, '0') + @"',
                LIMIT_CURRENCY=                 '" + LIMIT_CURRENCY.Text.PadLeft(3, '0') + @"',
                COUNTER_BANK_ACCOUNT=           '" + COUNTER_BANK_ACCOUNT.Text + @"',
                DOMICILIATION_COUNTER_BANK_ACCOUNT_= '" + DOMICILIATION_COUNTER_BANK_ACCOUNT_.Text + @"',
                COUNTER_BANK_ACCT_NAME=         '" + COUNTER_BANK_ACCT_NAME.Text + @"',
                SETTLEMENT_METHOD=              '" + SETTLEMENT_METHOD.Text + @"',
                CLIENT_LEVEL=                   '" + CLIENT_LEVEL.Text + @"',
                BILLING_LEVEL=                  '" + BILLING_LEVEL.Text + @"',
                PARENT_APPL_NUMBER=             '" + PARENT_APPL_NUMBER.Text + @"',
                CONTRACT_REFERENCE=             '" + CONTRACT_REFERENCE.Text.PadRight(8, ' ') + @"',
                INSTITUTION_ACC_OFFICER=        '" + INSTITUTION_ACC_OFFICER.Text.PadLeft(3, '0') + @"',
                PROVIDER_ACCT_OFFICER=          '" + PROVIDER_ACCT_OFFICER.Text.PadLeft(3, '0') + @"',
                CARD_NUMBER=                    '" + CARD_NUMBER.Text + @"',
                EXPIRY_DATE=                    '" + EXPIRY_DATE_S + @"',
                MOTHERS_MAIDEN_NAME=            '" + MOTHERS_MAIDEN_NAME.Text.PadRight(25, ' ') + @"',
                RESIDENCE_STATUS=               '" + RESIDENCE_STATUS.SelectedIndex + @"',
                COMPANY_NAME=                   '" + COMPANY_NAME.Text.PadRight(35, ' ') + @"',
                TIME_WITH_PRESENT_EMPLOYER=     '" + TIME_WITH_PRESENT_EMPLOYER.Text.PadRight(3, ' ') + @"',
                INCOME=                         '" + INCOME.Text.PadRight(3, ' ') + @"',
                DATE_OF_APPLICATION=            '" + DATE_OF_APPLICATION_S + @"',

                SECURE_REGISTRATION_INDICATOT = '" + SECURE_REGISTRATION_INDICATOT.Text + @"',
                CMO_REGISTRATION_INDICATOR =	'" + CMO_REGISTRATION_INDICATOR.Text + @"',
                CMO_MOBILE_NUMBER =	            '" + CMO_MOBILE_NUMBER.Text + @"',
                COM_STIKER_REGISTRATION_INDICATRO =	'" + COM_STIKER_REGISTRATION_INDICATRO.Text + @"',
                IBAN_NUMBER =	                '" + IBAN_NUMBER.Text + @"',
                STICKER_CARD =	                '" + STICKER_CARD.Text + @"',
                DELIVERY_METHOD =	            '" + DELIVERY_METHOD.Text + @"',
                ADDR_LINE_1 =	                '" + ADDR_LINE_1.Text + @"',
                ADDR_LINE_2 =	                '" + ADDR_LINE_2.Text + @"',
                ADDR_LINE_3 =	                '" + ADDR_LINE_33.Text + @"',
                STATE =	                        '" + STATE.Text + @"',
                OTHER =	                        '" + OTHER.Text + @"',
                POST_CODE =	                    '" + POST_CODE.Text + @"',
                ADDRESS_CLIENT_CITY =	        '" + ADDRESS_CLIENT_CITY.Text + @"',
                EMAIL_ADDRESS =	                '" + EMAIL_ADDRESS.Text + @"',
                EMAIL_ADDRESS2 =	            '" + EMAIL_ADDRESS2.Text + @"',
                ADR1_NAME_OF_CLIENT =	        '" + ADR1_NAME_OF_CLIENT.Text + @"',
                ADR2STREET1 =	                '" + ADR2STREET1.Text + @"',
                ADR3STREET2 =	                '" + ADR3STREET2.Text + @"',
                ADR4_STATE =	                '" + ADR4_STATE.Text + @"',
                ADR5_OTHER =	                '" + ADR5_OTHER.Text + @"',
                POST_CODE1 =	                '" + POST_CODE1.Text + @"',
                ADDRESS_CLIENT_CITY1 =	        '" + ADDRESS_CLIENT_CITY1.Text + @"',
                EMAIL_ADDRESS1 =	            '" + EMAIL_ADDRESS1.Text + @"',
                status =	                    '1'
                where CONTRACT_REFERENCE = @CONTRACT_REFERENCE and id = '" + lbl_id.Text + "'";

            cmd_update.Parameters.AddWithValue("@CONTRACT_REFERENCE", CONTRACTREFERENCE.Text);


            cmd.CommandText = @"INSERT INTO HR.[dbo].[alfile_out_tb]
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
,[EMPLOYMENT_STATUS]
,[CLIENT_BRANCH]
,[VAT_REG_NUMBER]
,[REGISTRATION_NUMBER]
,[CLIENT_ORGANIZATION]
,[BANK_CLEARING_NUMBER]
,[BANK_TEL_NUMBER]
,[BANK_REFERECE]
,[NOTE_TEXT]
,[Bank_Contact_Name]
,[EMPLOYMENT_POSITION]
,[EMPLOYER_NAME]
,[EMPLOYMENT_DATE]
,[WORKING_SECTOR]
,[RISK_GROUP]
,[MOBILE_NO1]
,[MOBILE_NO2]
,[FATHERS_NAME_L2]
,[CLIENT_NUMBER_RBS]
,[PARINT_CLIENT_NUMBER_RBS]
,[SETTLEMENT_BANK_NAME]
,[SETTLEMENT_BANK_CITY]
,[BANK_GUARANTEE]
,[SERVICE_CONTRACT_ID]
,[SERVICE_ID]
,[EXTENTION_FLAG]
,[CLIENT_NUMBER]
,[CONDITION_SET]
,[CLIENT_LIMIT]
,[LIMIT_CURRENCY]
,[COUNTER_BANK_ACCOUNT]
,[DOMICILIATION_COUNTER_BANK_ACCOUNT_]
,[COUNTER_BANK_ACCT_NAME]
,[SETTLEMENT_METHOD]
,[CLIENT_LEVEL]
,[BILLING_LEVEL]
,[PARENT_APPL_NUMBER]
,[CONTRACT_REFERENCE]
,[INSTITUTION_ACC_OFFICER]
,[PROVIDER_ACCT_OFFICER]
,[CARD_NUMBER]
,[EXPIRY_DATE]
,[MOTHERS_MAIDEN_NAME]
,[RESIDENCE_STATUS]
,[COMPANY_NAME]
,[TIME_WITH_PRESENT_EMPLOYER]
,[INCOME]
,DATE_OF_APPLICATION
,SECURE_REGISTRATION_INDICATOT
,CMO_REGISTRATION_INDICATOR
,CMO_MOBILE_NUMBER
,COM_STIKER_REGISTRATION_INDICATRO
,IBAN_NUMBER
,STICKER_CARD
,DELIVERY_METHOD
,ADDR_LINE_1
,ADDR_LINE_2
,ADDR_LINE_3
,STATE
,OTHER
,POST_CODE
,ADDRESS_CLIENT_CITY
,EMAIL_ADDRESS
,EMAIL_ADDRESS2
,ADR1_NAME_OF_CLIENT
,ADR2STREET1
,ADR3STREET2
,ADR4_STATE
,ADR5_OTHER
,POST_CODE1
,ADDRESS_CLIENT_CITY1
,EMAIL_ADDRESS1
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
 '" + NATIONALITY.Text.PadLeft(3, '0') + @"',              
'" + EMPLOYMENT_STATUS.Text.PadLeft(3, '0') + @"',
'" + CLIENT_BRANCH.Text.PadLeft(3, '0') + @"',
'" + VAT_REG_NUMBER.Text.PadRight(15, ' ') + @"',
'" + REGISTRATION_NUMBER.Text.PadRight(15, ' ') + @"',
'" + CLIENT_ORGANIZATION.Text.PadRight(8, ' ') + @"',
'" + BANK_CLEARING_NUMBER.Text.PadRight(8, ' ') + @"',
'" + BANK_TEL_NUMBER.Text.PadRight(15, ' ') + @"',
'" + BANK_REFERECE.Text.PadRight(8, ' ') + @"',
'" + NOTE_TEXT.Text.PadRight(100, ' ') + @"',
'" + Bank_Contact_Name.Text.PadRight(35, ' ') + @"',
'" + EMPLOYMENT_POSITION.Text.PadLeft(3, '0') + @"',
'" + EMPLOYER_NAME.Text.PadRight(35, ' ') + @"',     
'" + EMPLOYMENT_DATE_S + @"',         
'" + WORKING_SECTOR.Text.PadLeft(3, '0') + @"',
'" + RISK_GROUP.Text.PadLeft(3, '0') + @"',
'" + MOBILE_NO1.Text.PadRight(15, ' ') + @"',
'" + MOBILE_NO2.Text.PadRight(15, ' ') + @"',
'" + FATHERS_NAME_L2.Text.PadRight(35, ' ') + @"',
'" + CLIENT_NUMBER_RBS.Text.PadRight(20, ' ') + @"',
'" + PARINT_CLIENT_NUMBER_RBS.Text.PadRight(20, ' ') + @"',
'" + SETTLEMENT_BANK_NAME.Text.PadRight(35, ' ') + @"',
'" + SETTLEMENT_BANK_CITY.Text.PadRight(20, ' ') + @"',
'" + BANK_GUARANTEE.Text.PadRight(18, ' ') + @"',
'" + SERVICE_CONTRACT_ID.Text + @"',
'" + SERVICE_ID.Text + @"',
'" + EXTENTION_FLAG.Text + @"',
'" + CLIENT_NUMBER.Text.PadLeft(8, '0') + @"',
'" + CONDITION_SET.Text.PadLeft(3, '0') + @"',
'" + CLIENT_LIMIT.Text + @"',
'" + LIMIT_CURRENCY.Text.PadLeft(3, '0') + @"',
'" + COUNTER_BANK_ACCOUNT.Text + @"',
'" + DOMICILIATION_COUNTER_BANK_ACCOUNT_.Text + @"',
'" + COUNTER_BANK_ACCT_NAME.Text + @"',
'" + SETTLEMENT_METHOD.Text + @"',
'" + CLIENT_LEVEL.Text + @"',
'" + BILLING_LEVEL.Text.PadLeft(3, '0') + @"',
'" + PARENT_APPL_NUMBER.Text + @"',
'" + CONTRACT_REFERENCE.Text.PadRight(8, ' ') + @"',
'" + INSTITUTION_ACC_OFFICER.Text.PadLeft(3, '0') + @"',
'" + PROVIDER_ACCT_OFFICER.Text.PadLeft(3, '0') + @"',
'" + CARD_NUMBER.Text + @"',
'" + EXPIRY_DATE_S + @"',
'" + MOTHERS_MAIDEN_NAME.Text.PadRight(25, ' ') + @"',
'" + RESIDENCE_STATUS.Text.PadLeft(3, '0') + @"',
'" + COMPANY_NAME.Text.PadRight(35, ' ') + @"',
'" + TIME_WITH_PRESENT_EMPLOYER.Text.PadRight(3, ' ') + @"',
'" + INCOME.Text.PadRight(3, ' ') + @"',
'" + DATE_OF_APPLICATION_S + @"',
'" + SECURE_REGISTRATION_INDICATOT.Text + @"',
'" + CMO_REGISTRATION_INDICATOR.Text + @"',
'" + CMO_MOBILE_NUMBER.Text + @"',
'" + COM_STIKER_REGISTRATION_INDICATRO.Text + @"',
'" + IBAN_NUMBER.Text + @"',
'" + STICKER_CARD.Text + @"',
'" + DELIVERY_METHOD.Text.PadLeft(3, '0') + @"',
'" + ADDR_LINE_1.Text + @"',
'" + ADDR_LINE_2.Text + @"',
'" + ADDR_LINE_33.Text + @"',
'" + STATE.Text + @"',
'" + OTHER.Text + @"',
'" + POST_CODE.Text + @"',
'" + ADDRESS_CLIENT_CITY.Text + @"',
'" + EMAIL_ADDRESS.Text + @"',
'" + EMAIL_ADDRESS2.Text + @"',
'" + ADR1_NAME_OF_CLIENT.Text + @"',
'" + ADR2STREET1.Text + @"',
'" + ADR3STREET2.Text + @"',
'" + ADR4_STATE.Text + @"',
'" + ADR5_OTHER.Text + @"',
'" + POST_CODE1.Text + @"',
'" + ADDRESS_CLIENT_CITY1.Text + @"',
'" + EMAIL_ADDRESS1.Text + @"'
)";


            if (AddUpdate.Text == "update")
            {
                MDirMaster.Execute(cmd_update, lblMessage, HttpContext.Current.Request.Path);
            }
            else
            {
                MDirMaster.Execute(cmd, lblMessage, HttpContext.Current.Request.Path);
            }


        }

        public void filll()
        {
            try
            {
                lblempid.Text = "1";
                RECORD_DATE.Text = "1";
                INSTITUTION_NUMBER.Text = "1";
                LAST_NAME.Text = "1";
                FIRST_NAME.Text = "1";
                BIRTH_NAME.Text = "1";
                FATHER_NAME.Text = "1";
                EMBOSS_LINE_1.Text = "1";
                EMBOSS_LINE_2.Text = "1";
                EMBOSS_LINE_3.Text = "1";
                TITLE.SelectedIndex = 001;
                //MARITAL_STATUS.Text = "1";
                TEL_PRIVATE.Text = "1";
                TEL_WORK.Text = "1";
                FAX_PRIVATE.Text = "1";
                FAX_WORK.Text = "1";
                ID_NUMBER.Text = "1";
                PASSPORT_NUMBER.Text = "1";
                DRIVING_LICENSE.Text = "1";
                CLIENT_LANGUAGE.SelectedIndex = 1;
                BIRTH_PLACE.Text = "1";
                CLIENT_COUNTRY.SelectedIndex = 1;
                CLIENT_CITY.Text = "1";
                NATIONALITY.SelectedIndex = 1;
                EMPLOYMENT_STATUS.SelectedIndex = 1;
                CLIENT_BRANCH.Text = "1";
                VAT_REG_NUMBER.Text = "1";
                REGISTRATION_NUMBER.Text = "1";
                CLIENT_ORGANIZATION.Text = "1";
                BANK_CLEARING_NUMBER.Text = "1";
                BANK_TEL_NUMBER.Text = "1";
                BANK_REFERECE.Text = "1";
                NOTE_TEXT.Text = "1";
                Bank_Contact_Name.Text = "1";
                EMPLOYMENT_POSITION.SelectedIndex = 1;
                EMPLOYER_NAME.Text = "1";
                WORKING_SECTOR.SelectedIndex = 1;
                RISK_GROUP.SelectedIndex = 1;
                MOBILE_NO1.Text = "1";
                MOBILE_NO2.Text = "1";
                FATHERS_NAME_L2.Text = "1";
                CLIENT_NUMBER_RBS.Text = "1";
                PARINT_CLIENT_NUMBER_RBS.Text = "1";
                SETTLEMENT_BANK_NAME.Text = "1";
                SETTLEMENT_BANK_CITY.Text = "1";
                BANK_GUARANTEE.Text = "1";
                SERVICE_CONTRACT_ID.Text = "1";
                SERVICE_ID.Text = "1";
                EXTENTION_FLAG.Text = "1";
                CLIENT_NUMBER.Text = "1";
                CONDITION_SET.Text = "1";
                CLIENT_LIMIT.Text = "1";
                LIMIT_CURRENCY.SelectedIndex = 1;
                COUNTER_BANK_ACCOUNT.Text = "1";
                DOMICILIATION_COUNTER_BANK_ACCOUNT_.Text = "1";
                COUNTER_BANK_ACCT_NAME.Text = "1";
                SETTLEMENT_METHOD.Text = "950";
                CLIENT_LEVEL.Text = "001";
                BILLING_LEVEL.Text = "001";
                PARENT_APPL_NUMBER.Text = "1";
                CONTRACT_REFERENCE.Text = "1";
                INSTITUTION_ACC_OFFICER.Text = "1";
                PROVIDER_ACCT_OFFICER.Text = "1";
                CARD_NUMBER.Text = "1";
                MOTHERS_MAIDEN_NAME.Text = "1";
                RESIDENCE_STATUS.SelectedIndex = 1;
                COMPANY_NAME.Text = "1";
                TIME_WITH_PRESENT_EMPLOYER.Text = "1";
                INCOME.Text = "1  ";
                SECURE_REGISTRATION_INDICATOT.SelectedIndex = 1;
                CMO_REGISTRATION_INDICATOR.SelectedIndex = 1;
                CMO_MOBILE_NUMBER.Text = "1";
                COM_STIKER_REGISTRATION_INDICATRO.SelectedIndex = 1;
                IBAN_NUMBER.Text = "1";
                STICKER_CARD.SelectedIndex = 1;
                DELIVERY_METHOD.SelectedIndex = 1;
                ADDR_LINE_1.Text = "1";
                ADDR_LINE_2.Text = "1";
                ADDR_LINE_33.Text = "1";
                STATE.Text = "1";
                OTHER.Text = "1";
                POST_CODE.Text = "1";
                ADDRESS_CLIENT_CITY.Text = "1";
                EMAIL_ADDRESS.Text = "1";
                EMAIL_ADDRESS2.Text = "1";
                ADR1_NAME_OF_CLIENT.Text = "1";
                ADR2STREET1.Text = "1";
                ADR3STREET2.Text = "1";
                ADR4_STATE.Text = "1";
                ADR5_OTHER.Text = "1";
                POST_CODE1.Text = "1";
                ADDRESS_CLIENT_CITY1.Text = "1";
                EMAIL_ADDRESS1.Text = "1";
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.ToString();
            }
        }

        
        public void updatee()
        {
            try
            {
                lblempid.Text = "2";
                RECORD_DATE.Text = "2";
                INSTITUTION_NUMBER.Text = "2";
                LAST_NAME.Text = "2";
                FIRST_NAME.Text = "2";
                BIRTH_NAME.Text = "2";
                FATHER_NAME.Text = "2";
                EMBOSS_LINE_1.Text = "2";
                EMBOSS_LINE_2.Text = "2";
                EMBOSS_LINE_3.Text = "2";
                TITLE.SelectedIndex = 002;
                //MARITAL_STATUS.Text = "2";
                TEL_PRIVATE.Text = "2";
                TEL_WORK.Text = "2";
                FAX_PRIVATE.Text = "2";
                FAX_WORK.Text = "2";
                ID_NUMBER.Text = "2";
                PASSPORT_NUMBER.Text = "2";
                DRIVING_LICENSE.Text = "2";
                CLIENT_LANGUAGE.SelectedIndex = 2;

                BIRTH_PLACE.Text = "2";
                CLIENT_COUNTRY.SelectedIndex = 2;
                CLIENT_CITY.Text = "2";
                NATIONALITY.SelectedIndex = 2;


                EMPLOYMENT_STATUS.SelectedIndex = 2;
                CLIENT_BRANCH.Text = "2";
                VAT_REG_NUMBER.Text = "2";
                REGISTRATION_NUMBER.Text = "2";
                CLIENT_ORGANIZATION.Text = "2";
                BANK_CLEARING_NUMBER.Text = "2";
                BANK_TEL_NUMBER.Text = "2";
                BANK_REFERECE.Text = "2";
                NOTE_TEXT.Text = "2";
                Bank_Contact_Name.Text = "2";
                EMPLOYMENT_POSITION.SelectedIndex = 2;
                EMPLOYER_NAME.Text = "2";


                WORKING_SECTOR.SelectedIndex = 2;
                RISK_GROUP.SelectedIndex = 2;
                MOBILE_NO1.Text = "2";
                MOBILE_NO2.Text = "2";
                FATHERS_NAME_L2.Text = "2";
                CLIENT_NUMBER_RBS.Text = "2";
                PARINT_CLIENT_NUMBER_RBS.Text = "2";
                SETTLEMENT_BANK_NAME.Text = "2";
                SETTLEMENT_BANK_CITY.Text = "2";
                BANK_GUARANTEE.Text = "2";
                SERVICE_CONTRACT_ID.Text = "2";
                SERVICE_ID.Text = "2";
                EXTENTION_FLAG.Text = "2";
                CLIENT_NUMBER.Text = "2";
                CONDITION_SET.Text = "2";
                CLIENT_LIMIT.Text = "2";
                LIMIT_CURRENCY.SelectedIndex = 2;
                COUNTER_BANK_ACCOUNT.Text = "2";
                DOMICILIATION_COUNTER_BANK_ACCOUNT_.Text = "2";
                COUNTER_BANK_ACCT_NAME.Text = "2";
                SETTLEMENT_METHOD.Text = "950";
                CLIENT_LEVEL.Text = "002";
                BILLING_LEVEL.Text = "002";
                PARENT_APPL_NUMBER.Text = "2";
                CONTRACT_REFERENCE.Text = "2";
                INSTITUTION_ACC_OFFICER.Text = "2";
                PROVIDER_ACCT_OFFICER.Text = "2";
                CARD_NUMBER.Text = "2";

                MOTHERS_MAIDEN_NAME.Text = "2";
                RESIDENCE_STATUS.SelectedIndex = 2;
                COMPANY_NAME.Text = "2";
                TIME_WITH_PRESENT_EMPLOYER.Text = "2";
                INCOME.Text = "2  ";


                SECURE_REGISTRATION_INDICATOT.SelectedIndex = 2;
                CMO_REGISTRATION_INDICATOR.SelectedIndex = 2;
                CMO_MOBILE_NUMBER.Text = "2";
                COM_STIKER_REGISTRATION_INDICATRO.SelectedIndex = 2;
                IBAN_NUMBER.Text = "2";
                STICKER_CARD.SelectedIndex = 2;
                DELIVERY_METHOD.SelectedIndex = 2;
                ADDR_LINE_1.Text = "2";
                ADDR_LINE_2.Text = "2";
                ADDR_LINE_3.Text = "2";
                STATE.Text = "2";
                OTHER.Text = "2";
                POST_CODE.Text = "2";
                ADDRESS_CLIENT_CITY.Text = "2";
                EMAIL_ADDRESS.Text = "2";
                EMAIL_ADDRESS2.Text = "2";
                ADR1_NAME_OF_CLIENT.Text = "2";
                ADR2STREET1.Text = "2";
                ADR3STREET2.Text = "2";
                ADR4_STATE.Text = "2";
                ADR5_OTHER.Text = "2";
                POST_CODE1.Text = "2";
                ADDRESS_CLIENT_CITY1.Text = "2";
                EMAIL_ADDRESS1.Text = "2";

            }
            catch (Exception ex)
            {

            }
        }



    }
}
