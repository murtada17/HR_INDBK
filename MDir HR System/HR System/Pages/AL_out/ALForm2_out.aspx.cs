using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HR_Salaries.Pages
{
    public partial class ALForm2_out : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


            if (!IsPostBack)
            {

                // MDirMaster.FillCombo("INDEX_FIELD", "MARITAL_STATUS", "Al_Marital_Status", EMPLOYMENT_STATUS, "1=1", lblMessage);

                MDirMaster.FillCombo("INDEX_FIELD", "EMPLOYMENT_STATUS", "Al_EMPLOYMENT_STATUS", EMPLOYMENT_STATUS, "1=1", lblMessage);
                MDirMaster.FillCombo("INDEX_FIELD", "WORKING_SECTOR", "Al_Working_Sector", WORKING_SECTOR, "1=1", lblMessage);
                MDirMaster.FillCombo("INDEX_FIELD", "RISK_GROUP", "Al_Risk_Group", RISK_GROUP, "1=1", lblMessage);
                MDirMaster.FillCombo("INDEX_FIELD", "RESIDENT_STATUS", "Al_Resident_Status", RESIDENCE_STATUS, "1=1", lblMessage);
                MDirMaster.FillCombo("ISO_CODE", "SWIFT_CODE", "Al_Currency", LIMIT_CURRENCY, "1=1", lblMessage);
                MDirMaster.FillCombo("INDEX_FIELD", "EMPLOYMENT_POSITION", "Al_EMPLOYMENT_POSITION", EMPLOYMENT_POSITION, "1=1", lblMessage);

                EXTENTION_FLAG.Items.Add("1");
                SETTLEMENT_METHOD   .Items.Add("950");
CLIENT_LEVEL        .Items.Add("001");
BILLING_LEVEL       .Items.Add("001");
INCOME              .Items.Add("1");

                LIMIT_CURRENCY.SelectedIndex = 368;

            }

        }



        protected void btnSend_Click(object sender, EventArgs e)
        {
            if(EMPLOYMENT_STATUS.SelectedValue=="0")
            {
                lblMessage.Text = "Must be select EMPLOYMENT_STATUS";
                return;
            }
            
if (LIMIT_CURRENCY.SelectedValue == "0")
            {
                lblMessage.Text = "Must be select LIMIT_CURRENCY";
                return;
            }
            
if (SETTLEMENT_METHOD.SelectedValue == "0")
            {
                lblMessage.Text = "Must be select SETTLEMENT_METHOD";
                return;
            }
            
if (CLIENT_LEVEL.SelectedValue == "0")
            {
                lblMessage.Text = "Must be select CLIENT_LEVEL";
                return;
            }
            
                if (BILLING_LEVEL.SelectedValue == "0")
            {
                lblMessage.Text = "Must be select BILLING_LEVEL";
                return;
            }

                if (RESIDENCE_STATUS.SelectedValue == "0")
            {
                lblMessage.Text = "Must be select RESIDENCE_STATUS";
                return;
            }

                string EMPLOYMENT_DATE_S = "";
            if (EMPLOYMENT_DATE.Text !="")
            {
                EMPLOYMENT_DATE_S = Convert.ToDateTime(EMPLOYMENT_DATE.Text).ToString("yyyyMMdd");
            }
                else
            {
                EMPLOYMENT_DATE_S = "";
            }

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = @"UPDATE [HR].[dbo].[alfile_out_tb] Set                
            EMPLOYMENT_STATUS= '" +  EMPLOYMENT_STATUS.Text.PadLeft(3, '0') + @"',
            CLIENT_BRANCH= '"+            CLIENT_BRANCH.Text.PadLeft(3, '0') + @"',
            VAT_REG_NUMBER= '"+            VAT_REG_NUMBER.Text.PadRight(15, ' ') + @"',
            REGISTRATION_NUMBER= '"+            REGISTRATION_NUMBER.Text.PadRight(15, ' ') + @"',
            CLIENT_ORGANIZATION= '"+            CLIENT_ORGANIZATION.Text.PadRight(8, ' ') + @"',
            BANK_CLEARING_NUMBER= '"+            BANK_CLEARING_NUMBER.Text.PadRight(8, ' ') + @"',
            BANK_TEL_NUMBER= '"+            BANK_TEL_NUMBER.Text.PadRight(15, ' ') + @"',
            BANK_REFERECE= '"+            BANK_REFERECE.Text.PadRight(8, ' ') + @"',
            NOTE_TEXT= '"+            NOTE_TEXT.Text.PadRight(100, ' ') + @"',
            Bank_Contact_Name= '"+ Bank_Contact_Name.Text.PadRight(35, ' ') + @"',
            EMPLOYMENT_POSITION= '" +            EMPLOYMENT_POSITION.Text.PadLeft(3, '0') + @"',
            EMPLOYER_NAME= '"+            EMPLOYER_NAME.Text.PadRight(35, ' ') + @"',
            EMPLOYMENT_DATE= '" + EMPLOYMENT_DATE_S + @"',         
            WORKING_SECTOR = '"+            WORKING_SECTOR.Text.PadLeft(3, '0') + @"',
            RISK_GROUP= '"+            RISK_GROUP.Text.PadLeft(3, '0') + @"',
            MOBILE_NO1= '"+            MOBILE_NO1.Text.PadRight(15, ' ') + @"',
            MOBILE_NO2= '"+            MOBILE_NO2.Text.PadRight(15, ' ') + @"',
            FATHERS_NAME_L2= '"+            FATHERS_NAME_L2.Text.PadRight(35, ' ') + @"',
            CLIENT_NUMBER_RBS= '"+            CLIENT_NUMBER_RBS.Text.PadRight(20, ' ') + @"',
            PARINT_CLIENT_NUMBER_RBS= '"+            PARINT_CLIENT_NUMBER_RBS.Text.PadRight(20, ' ') + @"',
            SETTLEMENT_BANK_NAME= '"+            SETTLEMENT_BANK_NAME.Text.PadRight(35, ' ') + @"',
            SETTLEMENT_BANK_CITY= '"+            SETTLEMENT_BANK_CITY.Text.PadRight(20, ' ') + @"',
            BANK_GUARANTEE= '"+            BANK_GUARANTEE.Text.PadRight(18, ' ') + @"',
            SERVICE_CONTRACT_ID= '"+            SERVICE_CONTRACT_ID.Text+@"',
            SERVICE_ID= '"+            SERVICE_ID.Text+@"',
            EXTENTION_FLAG= '"+            EXTENTION_FLAG.Text+@"',
            CLIENT_NUMBER= '"+            CLIENT_NUMBER.Text.PadLeft(8, '0') + @"',
            CONDITION_SET= '" +            CONDITION_SET.Text.PadLeft(3, '0') + @"',
            CLIENT_LIMIT= '"+            CLIENT_LIMIT.Text.PadLeft(18, '0') + @"',
            LIMIT_CURRENCY= '"+            LIMIT_CURRENCY.Text.PadLeft(3, '0') + @"',
            COUNTER_BANK_ACCOUNT= '"+            COUNTER_BANK_ACCOUNT.Text+@"',
            DOMICILIATION_COUNTER_BANK_ACCOUNT_= '"+ DOMICILIATION_COUNTER_BANK_ACCOUNT_.Text+@"',
            COUNTER_BANK_ACCT_NAME= '"+            COUNTER_BANK_ACCT_NAME.Text+@"',
            SETTLEMENT_METHOD= '"+            SETTLEMENT_METHOD.Text+@"',
            CLIENT_LEVEL= '"+            CLIENT_LEVEL.Text+@"',
            BILLING_LEVEL= '"+            BILLING_LEVEL.Text+@"',
            PARENT_APPL_NUMBER= '"+            PARENT_APPL_NUMBER.Text+@"',
            CONTRACT_REFERENCE= '"+            CONTRACT_REFERENCE.Text.PadRight(8, ' ') + @"',
            INSTITUTION_ACC_OFFICER= '"+            INSTITUTION_ACC_OFFICER.Text.PadLeft(3, '0') + @"',
            PROVIDER_ACCT_OFFICER= '"+            PROVIDER_ACCT_OFFICER.Text.PadLeft(3, '0') + @"',
            CARD_NUMBER= '"+            CARD_NUMBER.Text+@"',
            EXPIRY_DATE= '"+            EXPIRY_DATE.Text+@"',
            MOTHERS_MAIDEN_NAME= '"+            MOTHERS_MAIDEN_NAME.Text.PadRight(25, ' ') + @"',
            RESIDENCE_STATUS= '"+            RESIDENCE_STATUS.Text.PadLeft(3, '0') + @"',
            COMPANY_NAME= '"+            COMPANY_NAME.Text.PadRight(35, ' ')+ @"',
            TIME_WITH_PRESENT_EMPLOYER= '" + TIME_WITH_PRESENT_EMPLOYER.Text.PadRight(3, ' ') + @"',
            INCOME= '" +            INCOME.Text.PadRight(3, ' ') + @"'

                where id = @id

                ";

            string pID =Session["sID"].ToString();

            cmd.Parameters.AddWithValue("@id", pID);


            MDirMaster.Execute(cmd, lblMessage, HttpContext.Current.Request.Path);
            
            
            Session["sID3"] = Server.HtmlEncode(pID.ToString());
            Response.Redirect("ALForm3_out.aspx", false);

        }
    }
}