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

            }
        }

        protected void btnAlExport_Click(object sender, EventArgs e)
        {
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

            MDirMaster.ToCSV(dt, "C:/HR/cc.csv");



        }

        protected void btnBatchExport_Click(object sender, EventArgs e)
        {

            SqlCommand cmd_ = new SqlCommand();


            //cmd_.CommandText = @"SELECT em.[EmpID], re.Card_number, re.Account_Number, pa.[Full Salary]
            //                    FROM [HR].[dbo].[emergency_employee$] as em left join 
            //                    [HR].[dbo].[alfile_tb] as al on em.EmpID = al.EmpID left join 
            //                    [HR].[dbo].[emergency_response$] as re on al.CONTRACT_REFERENCE = re.Contract_Reference left join 
            //                    [HR].[dbo].[emergency_payroll$] as pa on em.EmpID = pa.EmpID where pa.Reference =@Reference";

            
            cmd_.CommandText = @"SELECT em.[EmpID], re.Card_number, re.Account_Number, CAST(pa.[Full Salary] as numeric(10, 3)) as [Full Salary]
                FROM[HR].[dbo].[emergency_employee$] as em left join
                [HR].[dbo].[emergency_response$] as re on em.EmpID = re.Contract_Reference left join
                [HR].[dbo].[emergency_payroll$] as pa on em.EmpID = pa.EmpID where pa.Reference =@Reference";


            cmd_.Parameters.AddWithValue("@Reference", txt_salaryCode.Text);

            DataTable dt_ = MDirMaster.GetData(cmd_, lblMessage);



            // full salary

            SqlCommand cmd_fullsalary = new SqlCommand();

            //cmd_fullsalary.CommandText = @"SELECT sum( pa.[Full Salary]) as FullSalary
            //                    FROM [HR].[dbo].[emergency_employee$] as em left join 
            //                    [HR].[dbo].[alfile_tb] as al on em.EmpID = al.EmpID left join 
            //                    [HR].[dbo].[emergency_response$] as re on al.CONTRACT_REFERENCE = re.Contract_Reference left join 
            //                    [HR].[dbo].[emergency_payroll$] as pa on em.EmpID = pa.EmpID where pa.Reference =@Reference";



            

            cmd_fullsalary.CommandText = @"SELECT sum(CAST(pa.[Full Salary] as numeric(10, 3))) as FullSalary
                                FROM[HR].[dbo].[emergency_employee$] as em left join

                               [HR].[dbo].[emergency_response$] as re on em.EmpID = re.Contract_Reference left join
[HR].[dbo].[emergency_payroll$] as pa on em.EmpID = pa.EmpID where pa.Reference =@Reference";





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




            // get Max Sequence

            SqlCommand cmd_get_sec = new SqlCommand();
            cmd_get_sec.CommandText = @"SELECT max([SequenceNumber]) as maxsec
      
                                        FROM [HR].[dbo].[SequenceNumber_tb]";

            cmd_get_sec.Parameters.AddWithValue("@ISO_CODE", exp);
            DataTable dt_get_sec = MDirMaster.GetData(cmd_get_sec, lblMessage);

            int max_sec = int.Parse (dt_get_sec.Rows[0][0].ToString()) + 1;

            SequenceNumber.Text = max_sec.ToString();

            // End get Max Sequence


            MDirMaster.WriteDataToFile(dt_, "C:/HR/", dllCurrency.Text, int.Parse(txtBankId.Text), max_sec, int.Parse(txtDSlipNu.Text), int.Parse(ddlTraType.Text), int.Parse(dllTraCategory.Text), exponent, int.Parse(SlipNumber.Text), dt_fullsalary);


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


        }

        protected void dllCurrency_SelectedIndexChanged(object sender, EventArgs e)
        {
            string ee = e.ToString();
        }
    }
}