using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HR_Salaries.Pages.RESPONSE
{
    public partial class ALResponse_Out_BackUp : System.Web.UI.Page
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
                dt.Columns.Add("Institution_number", typeof(double));
                dt.Columns.Add("Record_Date", typeof(double));
                dt.Columns.Add("Account_Number", typeof(double));
                dt.Columns.Add("Client_number", typeof(double));
                dt.Columns.Add("Group_number", typeof(double));
                dt.Columns.Add("Card_number", typeof(string));
                dt.Columns.Add("Last_Name", typeof(string));
                dt.Columns.Add("First_Name", typeof(string));
                dt.Columns.Add("EMBOSS_LINE_1", typeof(string));
                dt.Columns.Add("Emboss_line_2", typeof(string));
                dt.Columns.Add("Emboss_line_3", typeof(string));
                dt.Columns.Add("Fathers_Name", typeof(string));
                dt.Columns.Add("Mother_Maiden_Name", typeof(string));
                dt.Columns.Add("Birth_Date", typeof(double));
                dt.Columns.Add("Birth_Place", typeof(string));
                dt.Columns.Add("Passport_Number", typeof(string));
                dt.Columns.Add("Residential_Status", typeof(string));
                dt.Columns.Add("Birth_Name", typeof(string));
                dt.Columns.Add("Parent_Client_Number", typeof(double));
                dt.Columns.Add("Contract_Reference", typeof(double));
                dt.Columns.Add("ID_Number", typeof(string));
                dt.Columns.Add("Branch_Index", typeof(double));
                dt.Columns.Add("Branch", typeof(string));
                dt.Columns.Add("Tel_Private", typeof(string));
                dt.Columns.Add("Tel_Work", typeof(double));
                dt.Columns.Add("Driving_License", typeof(double));
                dt.Columns.Add("VAT_Reg_number", typeof(string));
                dt.Columns.Add("Registration_number", typeof(string));
                dt.Columns.Add("Employee_position", typeof(string));
                dt.Columns.Add("Employer_Name", typeof(string));
                dt.Columns.Add("Employment_Date", typeof(string));
                dt.Columns.Add("Service_id", typeof(string));
                dt.Columns.Add("Service_Contract_ID", typeof(string));
                dt.Columns.Add("Client_Limit", typeof(string));
                dt.Columns.Add("Limit_Currency", typeof(string));
                dt.Columns.Add("Institution_Account_Officer", typeof(string));
                dt.Columns.Add("Provider_Account_Officer", typeof(string));
                dt.Columns.Add("Settlement_Method_Index", typeof(string));
                dt.Columns.Add("Condition_set", typeof(string));
                dt.Columns.Add("Counter_Bank_Account", typeof(double));
                dt.Columns.Add("IBAN_number", typeof(string));
                dt.Columns.Add("Expiry_Date", typeof(double));
                dt.Columns.Add("Card_Status", typeof(string));
                dt.Columns.Add("Event", typeof(double));
                dt.Columns.Add("Time", typeof(string));

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
                            ///////////////////////////////
                                    //foreach (string cell in row.Split(new string[] { "<!>" }, StringSplitOptions.None))
                                    //{
                                    //    try
                                    //    {
                                    //        Convert.ToDouble(cell);
                                    //        dt.Columns.Add(cell, typeof(Double));
                                    //    }
                                    //    catch
                                    //    {
                                    //        dt.Columns.Add(cell, typeof(String));
                                    //    }
                                    //    i++;
                                    //}
                            /////////////////////////////////
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

                bulkCopy.DestinationTableName = "Al_Response_out";

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
                }
            }
            else
            {
                lblMessage.Text = "يرجى تحديد الملف!";
            }
        }
    }
}