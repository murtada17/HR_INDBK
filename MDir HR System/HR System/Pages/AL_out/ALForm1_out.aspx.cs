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
    public partial class ALForm1_out : System.Web.UI.Page
    {
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

            SqlCommand cmd_max = new SqlCommand();
            SqlCommand cmd = new SqlCommand();

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
  )
            VALUES
               ('" + txtEmpID.Text + @"',
                '" + Convert.ToDateTime(RECORD_DATE.Text).ToString("yyyyMMdd") + @"',
                '"+ INSTITUTION_NUMBER.Text.PadLeft(8, '0') + @"',
                '"+ LAST_NAME.Text.PadRight(25, ' ') + @"',
                '"+ FIRST_NAME.Text.PadRight(15, ' ') + @"',
                '"+ BIRTH_NAME.Text.PadRight(20, ' ') + @"',
                '"+ FATHER_NAME.Text.PadRight(20, ' ') + @"',
                '"+ EMBOSS_LINE_1.Text.PadRight(26, ' ') + @"',
                '"+ EMBOSS_LINE_2.Text.PadRight(26, ' ') + @"',
                '"+ EMBOSS_LINE_3.Text.PadRight(26, ' ') + @"',
                '"+ TITLE.Text + @"',
                '"+ MARITAL_STATUS.Text + @"',
                '"+ TEL_PRIVATE.Text.PadRight(15, ' ') + @"',
                '"+ TEL_WORK.Text.PadRight(15, ' ') + @"',
                '"+ FAX_PRIVATE.Text.PadRight(15, ' ') + @"',
                '"+ FAX_WORK.Text.PadRight(15, ' ') + @"',
                '"+ ID_NUMBER.Text.PadRight(15, ' ') + @"',
                '"+ PASSPORT_NUMBER.Text.PadRight(15, ' ') + @"',
                '"+ DRIVING_LICENSE.Text.PadRight(15, ' ') + @"',
                '"+ Convert.ToDateTime(BIRTH_DATE.Text).ToString("yyyyMMdd") + @"',
                '"+ BIRTH_PLACE.Text.PadRight(15, ' ') + @"',
                '"+ CLIENT_COUNTRY.Text.PadLeft(3, '0') + @"',
                '"+ CLIENT_CITY.Text.PadRight(13, ' ') + @"',
                '"+ NATIONALITY.Text.PadLeft(3, '0') + @"',
                '"+ CLIENT_LANGUAGE.Text.PadLeft(3, '0') + @"'
                
                )";





            MDirMaster.Execute(cmd, lblMessage, HttpContext.Current.Request.Path);

            cmd_max.CommandText = @"SELECT MAX ([id]) as maxid
            FROM[HR].[dbo].[alfile_out_tb]";

            DataTable dt= MDirMaster.GetData(cmd_max, lblMessage);


            int param1Variable = int.Parse( dt.Rows[0][0].ToString());


            Session["sID"] = Server.HtmlEncode(param1Variable.ToString());

            Response.Redirect("ALForm2_out.aspx", false);
        }

        
    }
}
   