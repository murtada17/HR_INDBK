using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HR_Salaries.Pages.Out_Amount
{
    public partial class Out_Amount : System.Web.UI.Page
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
                dt.Columns.Add("name", typeof(string));
                dt.Columns.Add("cardnumber", typeof(string));
                dt.Columns.Add("Amount", typeof(float));
                dt.Columns.Add("reference", typeof(string));
                dt.Columns.Add("batch_ref", typeof(string));

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
                            foreach (string cell in row.Split(new string[] { "," }, StringSplitOptions.None))
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

                bulkCopy.DestinationTableName = "Payroll_Out";

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