using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HR_Salaries.Pages.Export_PhysicalCard
{
    public partial class Export_PhysicalCard : System.Web.UI.Page
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

                MDirMaster.ToCSV(dt, "C:/HR/AL_IND_OUT_" + DateTime.Now.ToString("yyyyMMdd") + ".csv");


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


               FROM [HR].[dbo].[alfile_tb] as al left join [dbo].[Al_Response] as re on al.CONTRACT_REFERENCE = re.Contract_Reference
            where re.CONTRACT_REFERENCE is null";




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

        protected void btnBatchExport_Click(object sender, EventArgs e)
        {

            SqlCommand cmd_ = new SqlCommand();
            SqlCommand cmd_IQD = new SqlCommand();
            SqlCommand cmd_USD = new SqlCommand();

            cmd_IQD.CommandText = @" SELECT[name]
                                    ,[Card_number]
                                    ,[Account_Number]
                                    ,[Amount_IQD] as 'Full Salary'
                                    FROM[HR].[dbo].[AL_Physical_card_TBL] where[Card_number] = @Card_number";
            cmd_IQD.Parameters.AddWithValue("@Card_number", txt_cardnumber.Text);


            cmd_USD.CommandText = @"  SELECT[name]
                                  ,[Card_number]
                                  ,[Account_Number]
                                  ,[Amount_USD] as 'Full Salary'
                                    FROM[HR].[dbo].[AL_Physical_card_TBL] where[Card_number] = @Card_number";
            cmd_USD.Parameters.AddWithValue("@Card_number", txt_cardnumber.Text);


//368 IQD
//840 USD
            string ccy = dllCurrency.Text;

            DataTable dt_ = new DataTable();
            if (ccy == "368") {  dt_ = MDirMaster.GetData(cmd_IQD, lblMessage); }
            if (ccy == "840") {  dt_ = MDirMaster.GetData(cmd_USD, lblMessage); }

            // full salary                        

            SqlCommand cmd_fullsalary_IQD = new SqlCommand();
            SqlCommand cmd_fullsalary_USD = new SqlCommand();

            cmd_fullsalary_IQD.CommandText = @"SELECT 
                                              [Amount_IQD] as FullSalary
                                              FROM [HR].[dbo].[AL_Physical_card_TBL] where [Card_number] = @Card_number";
            cmd_fullsalary_IQD.Parameters.AddWithValue("@Card_number", txt_cardnumber.Text);

            cmd_fullsalary_USD.CommandText = @"SELECT 
                                              [Amount_USD] as FullSalary
                                              FROM [HR].[dbo].[AL_Physical_card_TBL] where [Card_number] = @Card_number";

            cmd_fullsalary_USD.Parameters.AddWithValue("@Card_number", txt_cardnumber.Text);

            DataTable dt_fullsalary = new DataTable();
            if (ccy == "368") {  dt_fullsalary = MDirMaster.GetData(cmd_fullsalary_IQD, lblMessage); }
            if (ccy == "840") {  dt_fullsalary = MDirMaster.GetData(cmd_fullsalary_USD, lblMessage); }

            //DataTable dt_fullsalary = MDirMaster.GetData(cmd_fullsalary, lblMessage);


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
      
       FROM [HR].[dbo].[alfile_out_tb] where [ADDR_LINE_3] =@ADDR_LINE_3 ";


            cmd.Parameters.AddWithValue("@ADDR_LINE_3", ddlInstitution.Text);
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




            // get Max Sequence

            SqlCommand cmd_get_sec = new SqlCommand();
            cmd_get_sec.CommandText = @"SELECT max([SequenceNumber]) as maxsec
      
                                        FROM [HR].[dbo].[SequenceNumber_tb]";

            //cmd_get_sec.Parameters.AddWithValue("@ISO_CODE", exp);
            DataTable dt_get_sec = MDirMaster.GetData(cmd_get_sec, lblMessage);

            int max_sec = int.Parse(dt_get_sec.Rows[0][0].ToString()) + 1;

            SequenceNumber.Text = max_sec.ToString();

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

            string dat_Processing_s = dat_Processing.Text.Replace("-", "");
            string dat_Batch_s = dat_Batch.Text.Replace("-", "");
            string dat_Transaction_Date_s = dat_Transaction_Date.Text.Replace("-", "");
            string dat_Time_s = dat_Time.Text;

            MDirMaster.WriteDataToFilePhiscal(dt_, "C:/HR/", dllCurrency.Text, int.Parse(txtBankId.Text), max_sec, int.Parse(SlipNumber.Text), int.Parse(ddlTraType.Text), int.Parse(dllTraCategory.Text), exponent, int.Parse(SlipNumber.Text), dt_fullsalary, dat_Processing_s, dat_Batch_s, dat_Transaction_Date_s, dat_Time_s, "BI_IND");
            SqlCommand cmd_sec = new SqlCommand();
            cmd_sec.CommandText = @"
            INSERT INTO [dbo].[SequenceNumber_tb]
           (
           [description]
           )
            VALUES
           ('description')

            ";
            MDirMaster.ExecuteScaler(cmd_sec, lblMessage, HttpContext.Current.Request.Path);




            //Deposit Slip Number

            SqlCommand cmd_DSlipNu = new SqlCommand();
            cmd_DSlipNu.CommandText = @"
            INSERT INTO [dbo].[AL_DepositSlipNumber]
           (
           [description]
           )
            VALUES
           ('description')

            ";
            MDirMaster.ExecuteScaler(cmd_sec, lblMessage, HttpContext.Current.Request.Path);


        }

        protected void dllCurrency_SelectedIndexChanged(object sender, EventArgs e)
        {
            string ee = e.ToString();
        }
    }
}