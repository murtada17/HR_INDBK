using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HR_Salaries.Pages.Export
{
    public partial class Export : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //dllCurrency
                MDirMaster.FillCombo("TransactionType_Nu", "TransactionType_Name", "TransactionType", ddlTraType, "1=1", lblMessage);
                MDirMaster.FillCombo("TransactionCategory_Nu", "TransactionCategory_Name", "TransactionCategory", dllTraCategory, "1=1", lblMessage);
                MDirMaster.FillCombo("ISO_CODE", "SWIFT_CODE", "Al_Currency", dllCurrency, "1=1", lblMessage);
                MDirMaster.FillCombo("id", "institusion", "AL_institusion_TBL", ddlInstitution, "1=1", lblMessage);

                string today = DateTime.Now.ToString("yyyy-MM-dd"); 

                dat_Processing.Text = today.ToString();
                dat_Batch.Text = today.ToString();
                dat_Transaction_Date.Text = today.ToString();


            }
        }

        //btnAlExport_OUT_Click

        protected void btnAlExport_OUT_Click(object sender, EventArgs e)
        {
            string inst_S = ddlInstitution.Text;

            if(inst_S != "0")
            {
                SqlCommand cmd = new SqlCommand();


                cmd.CommandText = @"SELECT 

               al.[RECORD_DATE]
              ,al.[INSTITUTION_NUMBER]
              ,al.[LAST_NAME]
              ,al.[FIRST_NAME]
              ,al.[BIRTH_NAME]
              ,al.[FATHER_NAME]
              ,al.[EMBOSS_LINE_1]
              ,al.[EMBOSS_LINE_2]
              ,al.[EMBOSS_LINE_3]
              ,al.[TITLE]
              ,al.[MARITAL_STATUS]
              ,al.[TEL_PRIVATE]
              ,al.[TEL_WORK]
              ,al.[FAX_PRIVATE]
              ,al.[FAX_WORK]
              ,al.[ID_NUMBER]
              ,al.[PASSPORT_NUMBER]
              ,al.[DRIVING_LICENSE]
              ,al.[BIRTH_DATE]
              ,al.[BIRTH_PLACE]
              ,al.[CLIENT_COUNTRY]
              ,al.[CLIENT_CITY]
              ,al.[CLIENT_LANGUAGE]
              ,al.[NATIONALITY]
              ,al.[EMPLOYMENT_STATUS]
              ,al.[CLIENT_BRANCH]
              ,al.[VAT_REG_NUMBER]
              ,al.[REGISTRATION_NUMBER]
              ,al.[CLIENT_ORGANIZATION]
              ,al.[BANK_CLEARING_NUMBER]
              ,al.[BANK_TEL_NUMBER]
              ,al.[BANK_REFERECE]
              ,al.[NOTE_TEXT]
              ,al.[Bank_Contact_Name]
              ,al.[EMPLOYMENT_POSITION]
              ,al.[EMPLOYER_NAME]
              ,al.[EMPLOYMENT_DATE]
              ,al.[WORKING_SECTOR]
              ,al.[RISK_GROUP]
              ,al.[MOBILE_NO1]
              ,al.[MOBILE_NO2]
              ,al.[FATHERS_NAME_L2]
              ,al.[CLIENT_NUMBER_RBS]
              ,al.[PARINT_CLIENT_NUMBER_RBS]
              ,al.[SETTLEMENT_BANK_NAME]
              ,al.[SETTLEMENT_BANK_CITY]
              ,al.[BANK_GUARANTEE]
              ,al.[SERVICE_CONTRACT_ID]
              ,al.[SERVICE_ID]
              ,al.[EXTENTION_FLAG]
              ,al.[CLIENT_NUMBER]
              ,al.[CONDITION_SET]
              ,al.[CLIENT_LIMIT]
              ,al.[LIMIT_CURRENCY]
              ,al.[COUNTER_BANK_ACCOUNT]
              ,al.[DOMICILIATION_COUNTER_BANK_ACCOUNT_]
              ,al.[COUNTER_BANK_ACCT_NAME]
              ,al.[SETTLEMENT_METHOD]
              ,al.[CLIENT_LEVEL]
              ,al.[BILLING_LEVEL]
              ,al.[PARENT_APPL_NUMBER]
              ,al.[CONTRACT_REFERENCE]
              ,al.[INSTITUTION_ACC_OFFICER]
              ,al.[PROVIDER_ACCT_OFFICER]
              ,al.[CARD_NUMBER]
              ,al.[EXPIRY_DATE]
              ,al.[MOTHERS_MAIDEN_NAME]
              ,al.[RESIDENCE_STATUS]
              ,al.[COMPANY_NAME]
              ,al.[TIME_WITH_PRESENT_EMPLOYER]
              ,al.[INCOME]
              ,al.[DATE_OF_APPLICATION]
              ,al.[SECURE_REGISTRATION_INDICATOT]
              ,al.[CMO_REGISTRATION_INDICATOR]
              ,al.[CMO_MOBILE_NUMBER]
              ,al.[COM_STIKER_REGISTRATION_INDICATRO]
              ,al.[IBAN_NUMBER]
              ,al.[STICKER_CARD]
              ,al.[DELIVERY_METHOD]
              ,al.[ADDR_LINE_1]
              ,al.[ADDR_LINE_2]
              ,al.[ADDR_LINE_3]
              ,al.[STATE]
              ,al.[OTHER]
              ,al.[POST_CODE]
              ,al.[ADDRESS_CLIENT_CITY]
              ,al.[EMAIL_ADDRESS]
              ,al.[EMAIL_ADDRESS2]
              ,al.[ADR1_NAME_OF_CLIENT]
              ,al.[ADR2STREET1]
              ,al.[ADR3STREET2]
              ,al.[ADR4_STATE]
              ,al.[ADR5_OTHER]
              ,al.[POST_CODE1]
              ,al.[ADDRESS_CLIENT_CITY1]
              ,al.[EMAIL_ADDRESS1]

               FROM [HR].[dbo].[alfile_out_tb] as al left join [dbo].[Al_Response] as re on al.CONTRACT_REFERENCE = re.Contract_Reference
               where re.CONTRACT_REFERENCE is null and al.[ADDR_LINE_3] = '" + inst_S +"'";

                DataTable dt = MDirMaster.GetData(cmd, lblMessage);

                MDirMaster.ToCSV(dt, "C:/HR/BI_IND" + DateTime.Now.ToString("ddMMyyyy") + ".csv");

            }
        }

            protected void btnAlExport_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand();


            cmd.CommandText = @"SELECT 

              al.[RECORD_DATE]
              ,al.[INSTITUTION_NUMBER]
              ,al.[LAST_NAME]
              ,al.[FIRST_NAME]
              ,al.[BIRTH_NAME]
              ,al.[FATHER_NAME]
              ,al.[EMBOSS_LINE_1]
              ,al.[EMBOSS_LINE_2]
              ,al.[EMBOSS_LINE_3]
              ,al.[TITLE]
              ,al.[MARITAL_STATUS]
              ,al.[TEL_PRIVATE]
              ,al.[TEL_WORK]
              ,al.[FAX_PRIVATE]
              ,al.[FAX_WORK]
              ,al.[ID_NUMBER]
              ,al.[PASSPORT_NUMBER]
              ,al.[DRIVING_LICENSE]
              ,al.[BIRTH_DATE]
              ,al.[BIRTH_PLACE]
              ,al.[CLIENT_COUNTRY]
              ,al.[CLIENT_CITY]
              ,al.[CLIENT_LANGUAGE]
              ,al.[NATIONALITY]
              ,al.[EMPLOYMENT_STATUS]
              ,al.[CLIENT_BRANCH]
              ,al.[VAT_REG_NUMBER]
              ,al.[REGISTRATION_NUMBER]
              ,al.[CLIENT_ORGANIZATION]
              ,al.[BANK_CLEARING_NUMBER]
              ,al.[BANK_TEL_NUMBER]
              ,al.[BANK_REFERECE]
              ,al.[NOTE_TEXT]
              ,al.[Bank_Contact_Name]
              ,al.[EMPLOYMENT_POSITION]
              ,al.[EMPLOYER_NAME]
              ,al.[EMPLOYMENT_DATE]
              ,al.[WORKING_SECTOR]
              ,al.[RISK_GROUP]
              ,al.[MOBILE_NO1]
              ,al.[MOBILE_NO2]
              ,al.[FATHERS_NAME_L2]
              ,al.[CLIENT_NUMBER_RBS]
              ,al.[PARINT_CLIENT_NUMBER_RBS]
              ,al.[SETTLEMENT_BANK_NAME]
              ,al.[SETTLEMENT_BANK_CITY]
              ,al.[BANK_GUARANTEE]
              ,al.[SERVICE_CONTRACT_ID]
              ,al.[SERVICE_ID]
              ,al.[EXTENTION_FLAG]
              ,al.[CLIENT_NUMBER]
              ,al.[CONDITION_SET]
              ,al.[CLIENT_LIMIT]
              ,al.[LIMIT_CURRENCY]
              ,al.[COUNTER_BANK_ACCOUNT]
              ,al.[DOMICILIATION_COUNTER_BANK_ACCOUNT_]
              ,al.[COUNTER_BANK_ACCT_NAME]
              ,al.[SETTLEMENT_METHOD]
              ,al.[CLIENT_LEVEL]
              ,al.[BILLING_LEVEL]
              ,al.[PARENT_APPL_NUMBER]
              ,al.[CONTRACT_REFERENCE]
              ,al.[INSTITUTION_ACC_OFFICER]
              ,al.[PROVIDER_ACCT_OFFICER]
              ,al.[CARD_NUMBER]
              ,al.[EXPIRY_DATE]
              ,al.[MOTHERS_MAIDEN_NAME]
              ,al.[RESIDENCE_STATUS]
              ,al.[COMPANY_NAME]
              ,al.[TIME_WITH_PRESENT_EMPLOYER]
              ,al.[INCOME]
              ,al.[DATE_OF_APPLICATION]
              ,al.[SECURE_REGISTRATION_INDICATOT]
              ,al.[CMO_REGISTRATION_INDICATOR]
              ,al.[CMO_MOBILE_NUMBER]
              ,al.[COM_STIKER_REGISTRATION_INDICATRO]
              ,al.[IBAN_NUMBER]
              ,al.[STICKER_CARD]
              ,al.[DELIVERY_METHOD]
              ,al.[ADDR_LINE_1]
              ,al.[ADDR_LINE_2]
              ,al.[ADDR_LINE_3]
              ,al.[STATE]
              ,al.[OTHER]
              ,al.[POST_CODE]
              ,al.[ADDRESS_CLIENT_CITY]
              ,al.[EMAIL_ADDRESS]
              ,al.[EMAIL_ADDRESS2]
              ,al.[ADR1_NAME_OF_CLIENT]
              ,al.[ADR2STREET1]
              ,al.[ADR3STREET2]
              ,al.[ADR4_STATE]
              ,al.[ADR5_OTHER]
              ,al.[POST_CODE1]
              ,al.[ADDRESS_CLIENT_CITY1]
              ,al.[EMAIL_ADDRESS1]


               FROM [HR].[dbo].[alfile_tb] as al 
            where [IsSend] = 1";




            //            cmd.CommandText = @"
            //SELECT TOP 1000 al.[RECORD_DATE]
            //      ,RIGHT('0000000000000000000000000' + al.[INSTITUTION_NUMBER], 8) AS INSTITUTION_NUMBER
            //      ,left(al.[LAST_NAME] + '                                                               '  , 25) AS LAST_NAME
            //	  ,left(al.[FIRST_NAME] + '                                                               '  , 15) AS FIRST_NAME
            //      ,left(al.[BIRTH_NAME] + '                                                               '  , 20) AS BIRTH_NAME
            //	  ,left(al.[FATHER_NAME] + '                                                               '  , 20) AS FATHER_NAME
            //	  ,left(al.[EMBOSS_LINE_1] + '                                                               '  , 26) AS EMBOSS_LINE_1
            //      ,left(al.[EMBOSS_LINE_2] + '                                                               '  , 26) AS EMBOSS_LINE_2
            //      ,left(al.[EMBOSS_LINE_3] + '                                                               '  , 26) AS EMBOSS_LINE_3



            //      ,al.[TITLE]
            //      ,al.[MARITAL_STATUS]

            //	  ,left(al.[TEL_PRIVATE] + '                                                               '  , 15) AS TEL_PRIVATE

            //      ,al.[TEL_WORK]
            //      ,al.[FAX_PRIVATE]
            //      ,al.[FAX_WORK]
            //      ,al.[ID_NUMBER]
            //      ,al.[PASSPORT_NUMBER]
            //      ,al.[DRIVING_LICENSE]
            //      ,al.[BIRTH_DATE]
            //      ,al.[BIRTH_PLACE]
            //      ,al.[CLIENT_COUNTRY]
            //      ,al.[CLIENT_CITY]
            //      ,al.[CLIENT_LANGUAGE]
            //      ,al.[NATIONALITY]
            //      ,al.[EMPLOYMENT_STATUS]
            //      ,al.[CLIENT_BRANCH]
            //      ,al.[VAT_REG_NUMBER]
            //      ,al.[REGISTRATION_NUMBER]
            //      ,al.[CLIENT_ORGANIZATION]
            //      ,al.[BANK_CLEARING_NUMBER]
            //      ,al.[BANK_TEL_NUMBER]
            //      ,al.[BANK_REFERECE]
            //      ,al.[NOTE_TEXT]
            //      ,al.[BANK_CONTACT_NAME]
            //      ,al.[EMPLOYMENT_POSITION]
            //      ,al.[EMPLOYER_NAME]
            //      ,al.[EMPLOYMENT_DATE]
            //      ,al.[WORKING_SECTOR]
            //      ,al.[RISK_GROUP]
            //      ,al.[MOBILE_NO1]
            //      ,al.[MOBILE_NO2]
            //      ,al.[FATHERS_NAME_L2]
            //      ,al.[CLIENT_NUMBER_RBS]
            //      ,al.[PARINT_CLIENT_NUMBER_RBS]
            //      ,al.[SETTLEMENT_BANK_NAME]
            //      ,al.[SETTLEMENT_BANK_CITY]
            //      ,al.[BANK_GUARANTEE]
            //      ,al.[SERVICE_CONTRACT_ID]
            //      ,al.[SERVICE_ID]
            //      ,al.[EXTENTION_FLAG]
            //      ,al.[CLIENT_NUMBER]
            //      ,al.[CONDITION_SET]
            //      ,al.[CLIENT_LIMIT]
            //      ,al.[LIMIT_CURRENCY]
            //      ,al.[COUNTER_BANK_ACCOUNT]
            //      ,al.[DOMICILIATION_COUNTER_BANK_ACCOUNT_]
            //      ,al.[COUNTER_BANK_ACCT_NAME]
            //      ,al.[SETTLEMENT_METHOD]
            //      ,al.[CLIENT_LEVEL]
            //      ,al.[BILLING_LEVEL]
            //      ,al.[PARENT_APPL_NUMBER]
            //      ,al.[CONTRACT_REFERENCE]
            //      ,al.[INSTITUTION_ACC_OFFICER]
            //      ,al.[PROVIDER_ACCT_OFFICER]
            //      ,al.[CARD_NUMBER]
            //      ,al.[EXPIRY_DATE]
            //      ,al.[MOTHERS_MAIDEN_NAME]
            //      ,al.[RESIDENCE_STATUS]
            //      ,al.[COMPANY _NAME]
            //      ,al.[TIME_WITH_PRESENT_EMPLOYER]
            //      ,al.[INCOME]
            //      ,al.[DATE_OF_APPLICATION]
            //      ,al.[3D_SECURE_REGISTRATION_INDICATOT]
            //      ,al.[CMO_REGISTRATION_INDICATOR]
            //      ,al.[CMO_MOBILE_NUMBER]
            //      ,al.[COM_STIKER_REGISTRATION_INDICATRO]
            //      ,al.[IBAN_NUMBER]
            //      ,al.[STICKER_CARD]
            //      ,al.[DELIVERY_METHOD]
            //      ,al.[ADDR_LINE_1]
            //      ,al.[ADDR_LINE_2]
            //      ,al.[ADDR_LINE_3]
            //      ,al.[STATE]
            //      ,al.[OTHER]
            //      ,al.[POST_CODE]
            //      ,al.[ADDRESS_CLIENT_CITY]
            //      ,al.[EMAIL_ADDRESS]
            //      ,al.[EMAIL_ADDRESS2]
            //      ,al.[ADR1_NAME_OF_CLIENT]
            //      ,al.[ADR2:STREET1]
            //      ,al.[ADR3:STREET2]
            //      ,al.[ADR4_STATE]
            //      ,al.[ADR5_OTHER]
            //      ,al.[POST_CODE1]
            //      ,al.[ADDRESS_CLIENT_CITY1]
            //      ,al.[EMAIL_ADDRESS1]
            //  FROM [HR].[dbo].[Al_20190212$] as al left join [HR].[dbo].[Al_Response] as re on al.CONTRACT_REFERENCE = re.Contract_Reference
            //	   where re.CONTRACT_REFERENCE is null";








            DataTable dt = MDirMaster.GetData(cmd, lblMessage);

            MDirMaster.ToCSV(dt, "C:/HR/AL_IND_"+ DateTime.Now.ToString("yyyyMMdd")+".csv");



        }



        protected void btnADExport_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand();


            cmd.CommandText = @"SELECT 

              [RECORD_DATE]
             ,[INSTITUTION_NUMBER]
             ,[Account_Number]
             ,[LAST_NAME]
             ,[FIRST_NAME]
             ,[FATHER_NAME]
             ,[SHORT_NAME]
             ,[COUNTER_BANK_ACCOUNT]
             ,[EMBOSS_LINE_2]
             ,[TEL_PRIVATE]
             ,[PASSPORT_NUMBER]
             ,[DRIVING_LICENSE]
             ,[BIRTH_DATE]
             ,[BIRTH_PLACE]
             ,[CLIENT_COUNTRY]
             ,[CLIENT_CITY]
             ,[NATIONALITY]
             ,[ADR1_NAME_OF_CLIENT]
             ,[ADR2STREET1]
             ,[ADR3STREET2]
             ,[ADR4_STATE]
             ,[ADR5_OTHER]
             ,[POST_CODE1]
             ,[ADDRESS_CLIENT_CITY1]
             ,[EMAIL_ADDRESS1]
             ,[Address_Category]
             ,[RESIDENCE_STATUS]
             ,[DELIVERY_METHOD]
             ,[TEL_WORK]
             ,[FAX_WORK]
             ,[MOBILE_NO2]
             ,[EMAIL_ADDRESS2]
             ,[ID_NUMBER]
             ,[OUR_REFERENCE]
             ,[EMBOSS_LINE_3]
             ,[Domiciliation]
             ,[Domiciliation_2]
             ,[Settlement_Bank_Name]
             ,[Mobile_no_1]
             
            FROM [HR].[dbo].[AE_tb]
            where [IsSend] = 1";

          

            DataTable dt = MDirMaster.GetData(cmd, lblMessage);

            MDirMaster.ToCSV(dt, "C:/HR/AD_" + DateTime.Now.ToString("yyyyMMdd") + ".csv");



        }

        protected void btnBatchExport_Click(object sender, EventArgs e)
        {

            SqlCommand cmd_ = new SqlCommand();


            //cmd_.CommandText = @"SELECT em.[EmpID], re.Card_number, re.Account_Number, pa.[Full Salary]
            //                    FROM [HR].[dbo].[EmployeesTBL] as em left join 
            //                    [HR].[dbo].[alfile_tb] as al on em.EmpID = al.EmpID left join 
            //                    [HR].[dbo].[Al_Response] as re on al.CONTRACT_REFERENCE = re.Contract_Reference left join 
            //                    [HR].[dbo].[PayrollTBL] as pa on em.EmpID = pa.EmpID where pa.Reference =@Reference";




            cmd_.CommandText = @"select em.ID_No, re.Card_number, re.Account_Number ,pa.[Full Salary]
from hr.dbo.EmployeesTBL as em left join hr.dbo.Al_Response as re on em.ID_No = re.Contract_Reference
left join hr.dbo.[PayrollTBL] as pa on pa.EmpID = em.EmpID
where pa.Reference = @Reference and re.Card_number is not null and em.IsActive=1 ";

//            cmd_.CommandText = @"select em.ID_No, re.Card_number, re.Account_Number ,pa.[Full Salary]
//from hr.dbo.EmployeesTBL as em left join hr.dbo.alfile_tb_1$ as al on em.ID_No = al.CONTRACT_REFERENCE 
//left join hr.dbo.Al_Response as re on al.CONTRACT_REFERENCE = re.Contract_Reference

//left join hr.dbo.[PayrollTBL] as pa on pa.EmpID = em.EmpID
//where pa.Reference = @Reference and re.Card_number is not null and em.IsActive=1";


            cmd_.Parameters.AddWithValue("@Reference", txt_salaryCode.Text);

            DataTable dt_ = MDirMaster.GetData(cmd_, lblMessage);



            // full salary                        

            SqlCommand cmd_fullsalary = new SqlCommand();

            cmd_fullsalary.CommandText = @"SELECT sum( pa.[Full Salary]) as FullSalary
                                FROM [HR].[dbo].[EmployeesTBL] as em left join 
                                [HR].[dbo].[Al_Response] as re on em.ID_No = re.Contract_Reference left join 
                                [HR].[dbo].[PayrollTBL] as pa on em.EmpID = pa.EmpID 
                                where pa.Reference =@Reference and re.Card_number is not null and em.IsActive=1 ";

            //cmd_fullsalary.CommandText = @"SELECT sum( pa.[Full Salary]) as FullSalary
            //                    FROM [HR].[dbo].[EmployeesTBL] as em left join 
            //                    [HR].[dbo].alfile_tb_1$ as al on em.ID_No = al.CONTRACT_REFERENCE left join 
            //                    [HR].[dbo].[Al_Response] as re on al.CONTRACT_REFERENCE = re.Contract_Reference left join 
            //                    [HR].[dbo].[PayrollTBL] as pa on em.EmpID = pa.EmpID where pa.Reference =@Reference and re.Card_number is not null and em.IsActive=1";

            cmd_fullsalary.Parameters.AddWithValue("@Reference", txt_salaryCode.Text);

            DataTable dt_fullsalary = MDirMaster.GetData(cmd_fullsalary, lblMessage);


            // End full salary



            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = @"SELECT 
      
      [RECORD_DATE]
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
      ,[DATE_OF_APPLICATION]
      ,[SECURE_REGISTRATION_INDICATOT]
      ,[CMO_REGISTRATION_INDICATOR]
      ,[CMO_MOBILE_NUMBER]
      ,[COM_STIKER_REGISTRATION_INDICATRO]
      ,[IBAN_NUMBER]
      ,[STICKER_CARD]
      ,[DELIVERY_METHOD]
      ,[ADDR_LINE_1]
      ,[ADDR_LINE_2]
      ,[ADDR_LINE_3]
      ,[STATE]
      ,[OTHER]
      ,[POST_CODE]
      ,[ADDRESS_CLIENT_CITY]
      ,[EMAIL_ADDRESS]
      ,[EMAIL_ADDRESS2]
      ,[ADR1_NAME_OF_CLIENT]
      ,[ADR2STREET1]
      ,[ADR3STREET2]
      ,[ADR4_STATE]
      ,[ADR5_OTHER]
      ,[POST_CODE1]
      ,[ADDRESS_CLIENT_CITY1]
      ,[EMAIL_ADDRESS1]
      
       FROM [HR].[dbo].[alfile_tb]";

            DataTable dt = MDirMaster.GetData(cmd, lblMessage);


            // Exponent
            string exp = dllCurrency.Text;

            SqlCommand cmd_exp = new SqlCommand();
            cmd_exp.CommandText = @"SELECT [EXPONENT]
                                    FROM [HR].[dbo].[Al_Currency] 
                                    where [ISO_CODE] = @ISO_CODE";

            cmd_exp.Parameters.AddWithValue("@ISO_CODE", exp);
            DataTable dt_exp = MDirMaster.GetData(cmd_exp, lblMessage);

            string exponent = dt_exp.Rows[0][0].ToString();

            // End Exponent



            //////////////////////////////////////////////////////
            string today1 = DateTime.Now.ToString("yyyy-MM-dd");
            //string toDate = today1;
            string toDate = "2019-04-16";
            SqlCommand cmd_sec_ = new SqlCommand();
            cmd_sec_.CommandText = @"
            select count([SequenceNumber_T]) from HR.[dbo].[SequenceNumber_tb]
            where [date] = '" + toDate + "'";
            DataTable get_max_id = MDirMaster.GetData(cmd_sec_, lblMessage);

            string get_max_id_ = get_max_id.Rows[0][0].ToString();
            int max_sec = 0;
            if (get_max_id_ != "")
            {
                max_sec = int.Parse(get_max_id_) + 1;
            }
            else
            {
                max_sec = 1;
            }
            SequenceNumber.Text = max_sec.ToString();

            //////////////////////////////////////////////////////
            // get Max Sequence

            //SqlCommand cmd_get_sec = new SqlCommand();
            //cmd_get_sec.CommandText = @"SELECT max([SequenceNumber]) as maxsec
      
            //                            FROM [HR].[dbo].[SequenceNumber_tb]";

            ////cmd_get_sec.Parameters.AddWithValue("@ISO_CODE", exp);
            //DataTable dt_get_sec = MDirMaster.GetData(cmd_get_sec, lblMessage);

            //int max_sec = int.Parse(dt_get_sec.Rows[0][0].ToString()) + 1;

            //SequenceNumber.Text = max_sec.ToString();

            // End get Max Sequence



            // get Max Deposit slip number

            SqlCommand cmd_get_DSlipNu = new SqlCommand();
            cmd_get_DSlipNu.CommandText = @"SELECT max([DepositSlipNumber])
      
                                        FROM [HR].[dbo].[AL_DepositSlipNumber]";

            //cmd_get_sec.Parameters.AddWithValue("@ISO_CODE", exp);
            DataTable dt_get_DSlipNu = MDirMaster.GetData(cmd_get_DSlipNu, lblMessage);

            int max_sec_DSlipNu = int.Parse(dt_get_DSlipNu.Rows[0][0].ToString()) + 1;

            txtDSlipNu.Text = max_sec_DSlipNu.ToString();

            // End get Max Deposit slip number

            //



            string dat_Processing_s = dat_Processing.Text.Replace("-","");
            string dat_Batch_s = dat_Batch.Text.Replace("-", "");
            string dat_Transaction_Date_s = dat_Transaction_Date.Text.Replace("-", "");
            string dat_Time_s = dat_Time.Text;



            MDirMaster.WriteDataToFile(dt_, "C:/HR/", dllCurrency.Text, int.Parse(txtBankId.Text), max_sec, max_sec, int.Parse(ddlTraType.Text), int.Parse(dllTraCategory.Text), exponent, int.Parse(SlipNumber.Text), dt_fullsalary, dat_Processing_s, dat_Batch_s, dat_Transaction_Date_s, dat_Time_s, "BI_IND");


            




                SqlCommand cmd_sec = new SqlCommand();
            cmd_sec.CommandText = @"
            INSERT INTO [dbo].[SequenceNumber_tb]
           (
           [description]
          ,[SequenceNumber_T]
           )
            VALUES
           ('description',1)

            ";
           


            MDirMaster.ExecuteScaler(cmd_sec, lblMessage, HttpContext.Current.Request.Path);




            //Deposit Slip Number

           // SqlCommand cmd_DSlipNu = new SqlCommand();
           // cmd_DSlipNu.CommandText = @"
           // INSERT INTO [dbo].[AL_DepositSlipNumber]
           //(
           //[description]
           //)
           // VALUES
           //('description')

           // ";
           // MDirMaster.ExecuteScaler(cmd_sec, lblMessage, HttpContext.Current.Request.Path);


        }



        /// <summary>
        /// //////////////////////////////////////////////////////////////////////////////////////////////
        /// </summary>

        protected void dllCurrency_SelectedIndexChanged(object sender, EventArgs e)
        {
            string ee = e.ToString();
        }

        protected void btnBatchExport_New_Click(object sender, EventArgs e)
        {

            SqlCommand cmd_ = new SqlCommand();


          

            cmd_.CommandText = @"select em.ID_No, re.Account_Number, re.Account_Number ,pa.[Full Salary]
            from hr.dbo.EmployeesTBL as em left join hr.dbo.Response_New as re on em.Account_Number_CSC = re.Account_Number
            left join hr.dbo.[PayrollTBL] as pa on pa.EmpID = em.EmpID
            where pa.Reference = @Reference and re.Account_Number is not null and em.IsActive=1  ";


            cmd_.Parameters.AddWithValue("@Reference", txt_salaryCode.Text);

            DataTable dt_ = MDirMaster.GetData(cmd_, lblMessage);



            // full salary                        

            SqlCommand cmd_fullsalary = new SqlCommand();

            cmd_fullsalary.CommandText = @"
SELECT sum( pa.[Full Salary]) as FullSalary
                                FROM [HR].[dbo].[EmployeesTBL] as em left join 
                                [HR].[dbo].[Response_New] as re on em.Account_Number_CSC = re.Account_Number left join 
                                [HR].[dbo].[PayrollTBL] as pa on em.EmpID = pa.EmpID 
                                where pa.Reference =@Reference and re.Account_Number is not null and em.IsActive=1
";

         

            cmd_fullsalary.Parameters.AddWithValue("@Reference", txt_salaryCode.Text);

            DataTable dt_fullsalary = MDirMaster.GetData(cmd_fullsalary, lblMessage);


            // End full salary



            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = @"SELECT
       [RECORD_DATE]
      ,[INSTITUTION_NUMBER]
      ,[Account_Number]
      ,[LAST_NAME]
      ,[FIRST_NAME]
      ,[FATHER_NAME]
      ,[SHORT_NAME]
      ,[COUNTER_BANK_ACCOUNT]
      ,[EMBOSS_LINE_2]
      ,[TEL_PRIVATE]
      ,[PASSPORT_NUMBER]
      ,[DRIVING_LICENSE]
      ,[BIRTH_DATE]
      ,[BIRTH_PLACE]
      ,[CLIENT_COUNTRY]
      ,[CLIENT_CITY]
      ,[NATIONALITY]
      ,[ADR1_NAME_OF_CLIENT]
      ,[ADR2STREET1]
      ,[ADR3STREET2]
      ,[ADR4_STATE]
      ,[ADR5_OTHER]
      ,[POST_CODE1]
      ,[ADDRESS_CLIENT_CITY1]
      ,[EMAIL_ADDRESS1]
      ,[Address_Category]
      ,[DELIVERY_METHOD]
      ,[TEL_WORK]
      ,[FAX_WORK]
      ,[MOBILE_NO2]
      ,[EMAIL_ADDRESS2]
      ,[ID_NUMBER]
      ,[OUR_REFERENCE]
      ,[EMBOSS_LINE_3]
      ,[Domiciliation]
      ,[Settlement_Bank_Name]
      ,[isSend]
  FROM [HR].[dbo].[Response_New]";

            DataTable dt = MDirMaster.GetData(cmd, lblMessage);


            // Exponent
            string exp = dllCurrency.Text;

            SqlCommand cmd_exp = new SqlCommand();
            cmd_exp.CommandText = @"SELECT [EXPONENT]
                                    FROM [HR].[dbo].[Al_Currency] 
                                    where [ISO_CODE] = @ISO_CODE";

            cmd_exp.Parameters.AddWithValue("@ISO_CODE", exp);
            DataTable dt_exp = MDirMaster.GetData(cmd_exp, lblMessage);

            string exponent = dt_exp.Rows[0][0].ToString();

            // End Exponent



            //////////////////////////////////////////////////////
            string today1 = DateTime.Now.ToString("yyyy-MM-dd");
            //string toDate = today1;
            string toDate = "2019-04-16";
            SqlCommand cmd_sec_ = new SqlCommand();
            cmd_sec_.CommandText = @"
            select count([SequenceNumber_T]) from HR.[dbo].[SequenceNumber_tb]
            where [date] = '" + toDate + "'";
            DataTable get_max_id = MDirMaster.GetData(cmd_sec_, lblMessage);

            string get_max_id_ = get_max_id.Rows[0][0].ToString();
            int max_sec = 0;
            if (get_max_id_ != "")
            {
                max_sec = int.Parse(get_max_id_) + 1;
            }
            else
            {
                max_sec = 1;
            }
            SequenceNumber.Text = max_sec.ToString();




            // get Max Deposit slip number

            SqlCommand cmd_get_DSlipNu = new SqlCommand();
            cmd_get_DSlipNu.CommandText = @"SELECT max([DepositSlipNumber])
      
                                        FROM [HR].[dbo].[AL_DepositSlipNumber]";

            //cmd_get_sec.Parameters.AddWithValue("@ISO_CODE", exp);
            DataTable dt_get_DSlipNu = MDirMaster.GetData(cmd_get_DSlipNu, lblMessage);

            int max_sec_DSlipNu = int.Parse(dt_get_DSlipNu.Rows[0][0].ToString()) + 1;

            txtDSlipNu.Text = max_sec_DSlipNu.ToString();

            // End get Max Deposit slip number

            //



            string dat_Processing_s = dat_Processing.Text.Replace("-", "");
            string dat_Batch_s = dat_Batch.Text.Replace("-", "");
            string dat_Transaction_Date_s = dat_Transaction_Date.Text.Replace("-", "");
            string dat_Time_s = dat_Time.Text;



            MDirMaster.WriteDataToFile2(dt_, "C:/HR/", dllCurrency.Text, int.Parse(txtBankId.Text), max_sec, max_sec, int.Parse(ddlTraType.Text), int.Parse(dllTraCategory.Text), exponent, int.Parse(SlipNumber.Text), dt_fullsalary, dat_Processing_s, dat_Batch_s, dat_Transaction_Date_s, dat_Time_s, "BI_IND");







            SqlCommand cmd_sec = new SqlCommand();
            cmd_sec.CommandText = @"
            INSERT INTO [dbo].[SequenceNumber_tb]
           (
           [description]
          ,[SequenceNumber_T]
           )
            VALUES
           ('description',1)

            ";



            MDirMaster.ExecuteScaler(cmd_sec, lblMessage, HttpContext.Current.Request.Path);


        
    }
    }
}