using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HR_Salaries.Pages.Out_AL_Test
{
    public partial class Out_AL_Test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                string csvPath = Server.MapPath("~/Files/") + Path.GetFileName(FileUpload1.PostedFile.FileName);
                FileUpload1.SaveAs(csvPath);

                //Create a DataTable.  
                DataTable dt = new DataTable();
                //dt.Columns.Add("name", typeof(string));



                dt.Columns.Add("RECORD_DATE", typeof(string));
                dt.Columns.Add("INSTITUTION_NUMBER", typeof(string));
                dt.Columns.Add("LAST_NAME", typeof(string));
                dt.Columns.Add("FIRST_NAME", typeof(string));
                dt.Columns.Add("BIRTH_NAME", typeof(string));
                dt.Columns.Add("FATHER_NAME", typeof(string));
                dt.Columns.Add("EMBOSS_LINE_1", typeof(string));
                dt.Columns.Add("EMBOSS_LINE_2", typeof(string));
                dt.Columns.Add("EMBOSS_LINE_3", typeof(string));
                dt.Columns.Add("TITLE", typeof(string));
                dt.Columns.Add("MARITAL_STATUS", typeof(string));
                dt.Columns.Add("TEL_PRIVATE", typeof(string));
                dt.Columns.Add("TEL_WORK", typeof(string));
                dt.Columns.Add("FAX_PRIVATE", typeof(string));
                dt.Columns.Add("FAX_WORK", typeof(string));
                dt.Columns.Add("ID_NUMBER", typeof(string));
                dt.Columns.Add("PASSPORT_NUMBER", typeof(string));
                dt.Columns.Add("DRIVING_LICENSE", typeof(string));
                dt.Columns.Add("BIRTH_DATE", typeof(string));
                dt.Columns.Add("BIRTH_PLACE", typeof(string));
                dt.Columns.Add("CLIENT_COUNTRY", typeof(string));
                dt.Columns.Add("CLIENT_CITY", typeof(string));
                dt.Columns.Add("CLIENT_LANGUAGE", typeof(string));
                dt.Columns.Add("NATIONALITY", typeof(string));
                dt.Columns.Add("EMPLOYMENT_STATUS", typeof(string));
                dt.Columns.Add("CLIENT_BRANCH", typeof(string));
                dt.Columns.Add("VAT_REG_NUMBER", typeof(string));
                dt.Columns.Add("REGISTRATION_NUMBER", typeof(string));
                dt.Columns.Add("CLIENT_ORGANIZATION", typeof(string));
                dt.Columns.Add("BANK_CLEARING_NUMBER", typeof(string));
                dt.Columns.Add("BANK_TEL_NUMBER", typeof(string));
                dt.Columns.Add("BANK_REFERECE", typeof(string));
                dt.Columns.Add("NOTE_TEXT", typeof(string));
                dt.Columns.Add("Bank_Contact_Name", typeof(string));
                dt.Columns.Add("EMPLOYMENT_POSITION", typeof(string));
                dt.Columns.Add("EMPLOYER_NAME", typeof(string));
                dt.Columns.Add("EMPLOYMENT_DATE", typeof(string));
                dt.Columns.Add("WORKING_SECTOR", typeof(string));
                dt.Columns.Add("RISK_GROUP", typeof(string));
                dt.Columns.Add("MOBILE_NO1", typeof(string));
                dt.Columns.Add("MOBILE_NO2", typeof(string));
                dt.Columns.Add("FATHERS_NAME_L2", typeof(string));
                dt.Columns.Add("CLIENT_NUMBER_RBS", typeof(string));
                dt.Columns.Add("PARINT_CLIENT_NUMBER_RBS", typeof(string));
                dt.Columns.Add("SETTLEMENT_BANK_NAME", typeof(string));
                dt.Columns.Add("SETTLEMENT_BANK_CITY", typeof(string));
                dt.Columns.Add("BANK_GUARANTEE", typeof(string));
                dt.Columns.Add("SERVICE_CONTRACT_ID", typeof(string));
                dt.Columns.Add("SERVICE_ID", typeof(string));
                dt.Columns.Add("EXTENTION_FLAG", typeof(double));
                dt.Columns.Add("CLIENT_NUMBER", typeof(string));
                dt.Columns.Add("CONDITION_SET", typeof(string));
                dt.Columns.Add("CLIENT_LIMIT", typeof(string));
                dt.Columns.Add("LIMIT_CURRENCY", typeof(string));
                dt.Columns.Add("COUNTER_BANK_ACCOUNT", typeof(string));
                dt.Columns.Add("DOMICILIATION_COUNTER_BANK_ACCOUNT_", typeof(string));
                dt.Columns.Add("COUNTER_BANK_ACCT_NAME", typeof(string));
                dt.Columns.Add("SETTLEMENT_METHOD", typeof(string));
                dt.Columns.Add("CLIENT_LEVEL", typeof(string));
                dt.Columns.Add("BILLING_LEVEL", typeof(string));
                dt.Columns.Add("PARENT_APPL_NUMBER", typeof(string));
                dt.Columns.Add("CONTRACT_REFERENCE", typeof(double));
                dt.Columns.Add("INSTITUTION_ACC_OFFICER", typeof(string));
                dt.Columns.Add("PROVIDER_ACCT_OFFICER", typeof(string));
                dt.Columns.Add("CARD_NUMBER", typeof(string));
                dt.Columns.Add("EXPIRY_DATE", typeof(string));
                dt.Columns.Add("MOTHERS_MAIDEN_NAME", typeof(string));
                dt.Columns.Add("RESIDENCE_STATUS", typeof(string));
                dt.Columns.Add("COMPANY_NAME", typeof(string));
                dt.Columns.Add("TIME_WITH_PRESENT_EMPLOYER", typeof(string));
                dt.Columns.Add("INCOME", typeof(string));
                dt.Columns.Add("DATE_OF_APPLICATION", typeof(string));
                dt.Columns.Add("SECURE_REGISTRATION_INDICATOT", typeof(string));
                dt.Columns.Add("CMO_REGISTRATION_INDICATOR", typeof(string));
                dt.Columns.Add("CMO_MOBILE_NUMBER", typeof(string));
                dt.Columns.Add("COM_STIKER_REGISTRATION_INDICATRO", typeof(string));
                dt.Columns.Add("IBAN_NUMBER", typeof(string));
                dt.Columns.Add("STICKER_CARD", typeof(string));
                dt.Columns.Add("DELIVERY_METHOD", typeof(string));
                dt.Columns.Add("ADDR_LINE_1", typeof(string));
                dt.Columns.Add("ADDR_LINE_2", typeof(string));
                dt.Columns.Add("ADDR_LINE_3", typeof(string));
                dt.Columns.Add("STATE", typeof(string));
                dt.Columns.Add("OTHER", typeof(string));
                dt.Columns.Add("POST_CODE", typeof(string));
                dt.Columns.Add("ADDRESS_CLIENT_CITY", typeof(string));
                dt.Columns.Add("EMAIL_ADDRESS", typeof(string));
                dt.Columns.Add("EMAIL_ADDRESS2", typeof(string));
                dt.Columns.Add("ADR1_NAME_OF_CLIENT", typeof(string));
                dt.Columns.Add("ADR2STREET1", typeof(string));
                dt.Columns.Add("ADR3STREET2", typeof(string));
                dt.Columns.Add("ADR4_STATE", typeof(string));
                dt.Columns.Add("ADR5_OTHER", typeof(string));
                dt.Columns.Add("POST_CODE1", typeof(string));
                dt.Columns.Add("ADDRESS_CLIENT_CITY1", typeof(string));
                dt.Columns.Add("EMAIL_ADDRESS1", typeof(string));
            















                //cardnumber	Amount	reference

                //Read the contents of CSV file.  
                string csvData = File.ReadAllText(csvPath);

                //Execute a loop over the rows.  
                int j = 0;
                foreach (string row in csvData.Split('\n'))
                {
                    if (!string.IsNullOrEmpty(row))
                    {
                        int i = 0;
                        //Execute a loop over the columns names.
                        if (j == 0)
                        {
                          
                        }
                        else
                        {
                            dt.Rows.Add();
                            foreach (string cell in row.Split(new string[] { "<!>" }, StringSplitOptions.None))
                            {
                                if (cell == "")
                                {
                                    dt.Rows[dt.Rows.Count - 1][i] = 0;
                                }
                                else
                                {
                                    dt.Rows[dt.Rows.Count - 1][i] = cell.Trim();
                                }
                                i++;
                            }
                        }
                        j++;
                    }
                }

                SqlConnection con = MDirMaster.con;
                SqlBulkCopy bulkCopy = new SqlBulkCopy(con);

                bulkCopy.DestinationTableName = "alfile_out_tb";

                try
                {
                    con.Open();
                    foreach (DataColumn c in dt.Columns)
                        bulkCopy.ColumnMappings.Add(c.ColumnName, c.ColumnName);
                    bulkCopy.WriteToServer(dt);
                }
                catch (Exception ex)
                {
                    lblMessage.Text = ex.Message;
                }
                finally
                {
                    con.Close();
                    lblmasseg_.Text = "تم تحميل الملف بنجاح";
                }
            }
            else
            {
                lblMessage.Text = "يرجى تحديد الملف!";
            }
        }
    }
}