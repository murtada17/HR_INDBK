using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HR_Salaries.Pages.AL
{
    public partial class AD_out : System.Web.UI.Page
    {
        string AddOrUpdate = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            //OnSelectedIndexChanged="GriSerch_PageIndexChanging"
            if (!IsPostBack)
            {
                MDirMaster.FillCombo("INDEX_FIELD", "CLIENT_COUNTRY", "Al_Country", CLIENT_COUNTRY_DDL, "1=1", lblMessage);
                MDirMaster.FillCombo("INDEX_FIELD", "RESIDENT_STATUS", "Al_Resident_Status", RESIDENCE_STATUS_DDL, "1=1", lblMessage);
                MDirMaster.FillCombo("INDEX_FIELD", "CLIENT_COUNTRY", "Al_Country", NATIONALITY_DDL, "1=1", lblMessage);
                MDirMaster.FillCombo("INDEX_FIELD", "delivery_method", "Al_DeliveryMethod", DELIVERY_METHOD_DDL, "1=1", lblMessage);
                //MDirMaster.FillCombo("INDEX_FIELD", "Address_Category", "Al_Address_Category", Address_Category_DDL, "1=1", lblMessage); //// هذا نقص بالمعلومات
                MDirMaster.FillCombo("id", "institusion", "AL_institusion_TBL", institusion_DDL, "1=1", lblMessage); //// هذا نقص بالمعلومات
                

                DELIVERY_METHOD_DDL.SelectedIndex = 0;
                string today = DateTime.Now.ToString("yyyy-MM-dd");
                RECORD_DATE.Text = today.ToString();
                RESIDENCE_STATUS_DDL.SelectedValue = "001";
                DELIVERY_METHOD_DDL.SelectedValue = "500";
                Address_Category_DDL.SelectedValue = "006";


            }
        }





        protected void btnSerchUpdate_Click(object sender, EventArgs e)
        {
            SqlCommand cmd_Search = new SqlCommand();


            cmd_Search.CommandText = @"SELECT     
                                      [LAST_NAME]
                                     ,[FIRST_NAME]
                                     ,[FATHER_NAME]
									 ,[ID_NUMBER]
                                      FROM [HR].[dbo].[AE_out_tb]
                                      Where [ID_NUMBER] ='" + txtUpdate.Text + "'";

            //cmd_Search.Parameters.AddWithValue("@CONTRACT_REFERENCE", txtUpdate.Text);

            MDirMaster.FillGrid(cmd_Search, GVUpdate, lblMessage);

            PalUpdate.Visible = true;
        }


       

        //  GV for Update
        protected void GVUpdate_PageIndexChanging(object sender, EventArgs e)
        {

            AddUpdate.Text = "update";

            string id = GVUpdate.SelectedRow.Cells[4].Text;
            ID_NUMBER_.Text = id;
            SqlCommand cmd_GV = new SqlCommand();

            cmd_GV.CommandText = @"SELECT [id]
      ,[EmpID]
      ,[RECORD_DATE]
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
      ,[institution]
      ,[isSend]
  FROM [HR].[dbo].[AE_out_tb] where [ID_NUMBER] = @ID_NUMBER";

            cmd_GV.Parameters.AddWithValue("@ID_NUMBER", id);

            DataTable dt = MDirMaster.GetData(cmd_GV, lblMessage);

            RECORD_DATE.Text = dt.Rows[0]["RECORD_DATE"].ToString();
            INSTITUTION_NUMBER.Text = dt.Rows[0]["INSTITUTION_NUMBER"].ToString(); 
            ACCOUNT_NUMBER.Text = dt.Rows[0]["Account_Number"].ToString();
            LAST_NAME.Text = dt.Rows[0]["LAST_NAME"].ToString(); 
            FIRST_NAME.Text = dt.Rows[0]["FIRST_NAME"].ToString(); 
            FATHER_NAME.Text = dt.Rows[0]["FATHER_NAME"].ToString(); 
            SHORT_NAME.Text = dt.Rows[0]["SHORT_NAME"].ToString(); 
            COUNTER_BANK_ACCOUNT.Text = dt.Rows[0]["COUNTER_BANK_ACCOUNT"].ToString(); 
            EMBOSS_LINE_2.Text = dt.Rows[0]["EMBOSS_LINE_2"].ToString(); 
            TEL_PRIVATE.Text = dt.Rows[0]["TEL_PRIVATE"].ToString(); 
            PASSPORT_NUMBER.Text = dt.Rows[0]["PASSPORT_NUMBER"].ToString(); 
            DRIVING_LICENSE.Text = dt.Rows[0]["DRIVING_LICENSE"].ToString(); 
            BIRTH_DATE.Text = dt.Rows[0]["BIRTH_DATE"].ToString(); 
            BIRTH_PLACE.Text = dt.Rows[0]["BIRTH_PLACE"].ToString(); 
            CLIENT_COUNTRY_DDL.Text = dt.Rows[0]["CLIENT_COUNTRY"].ToString(); 
            CLIENT_CITY.Text = dt.Rows[0]["CLIENT_CITY"].ToString(); 
            NATIONALITY_DDL.Text =  dt.Rows[0]["NATIONALITY"].ToString(); 
            ADR1_NAME_OF_CLIENT.Text = dt.Rows[0]["ADR1_NAME_OF_CLIENT"].ToString(); 
            ADR2STREET1.Text = dt.Rows[0]["ADR2STREET1"].ToString(); 
            ADR3STREET2.Text = dt.Rows[0]["ADR3STREET2"].ToString(); 
            ADR4_STATE.Text = dt.Rows[0]["ADR4_STATE"].ToString(); 
            ADR5_OTHER.Text = dt.Rows[0]["ADR5_OTHER"].ToString(); 
            POST_CODE1.Text = dt.Rows[0]["POST_CODE1"].ToString(); 
            ADDRESS_CLIENT_CITY1.Text = dt.Rows[0]["ADDRESS_CLIENT_CITY1"].ToString(); 
            EMAIL_ADDRESS1.Text = dt.Rows[0]["EMAIL_ADDRESS1"].ToString(); 
            Address_Category_DDL.Text = dt.Rows[0]["Address_Category"].ToString(); 
            RESIDENCE_STATUS_DDL.Text = dt.Rows[0]["RESIDENCE_STATUS"].ToString(); 
            DELIVERY_METHOD_DDL.Text = dt.Rows[0]["DELIVERY_METHOD"].ToString(); 
            TEL_WORK.Text = dt.Rows[0]["TEL_WORK"].ToString(); 
            FAX_WORK.Text = dt.Rows[0]["FAX_WORK"].ToString(); 
            MOBILE_NO2.Text = dt.Rows[0]["MOBILE_NO2"].ToString(); 
            EMAIL_ADDRESS2.Text = dt.Rows[0]["EMAIL_ADDRESS2"].ToString(); 
            ID_NUMBER.Text = dt.Rows[0]["ID_NUMBER"].ToString(); 
            OUR_REFERENCE.Text = dt.Rows[0]["OUR_REFERENCE"].ToString();
            EMBOSS_LINE_3.Text = dt.Rows[0]["EMBOSS_LINE_3"].ToString();
            Domiciliation.Text = dt.Rows[0]["Domiciliation"].ToString();

            Domiciliation_2.Text = dt.Rows[0]["Domiciliation_2"].ToString();
            Settlement_Bank_Name.Text = dt.Rows[0]["Settlement_Bank_Name"].ToString();
            Mobile_no_1.Text = dt.Rows[0]["Mobile_no_1"].ToString();
            institusion_DDL.Text = dt.Rows[0]["institution"].ToString();

 
        lbl_id.Text = dt.Rows[0]["id"].ToString();
            
            //isSend.Text = dt.Rows[0]["RECORD_DATE"].ToString(); ;



            //INSTITUTION_NUMBER.Text = dt.Rows[0]["INSTITUTION_NUMBER"].ToString();
            // LAST_NAME.Text = dt.Rows[0][4].ToString();
            // FIRST_NAME.Text = dt.Rows[0][5].ToString();

            string iss = dt.Rows[0]["IsSend"].ToString();
            if (iss == "True") { isSend.Checked = true; } else { isSend.Checked = false; }



            //lblempid.Text = id_num;
            Panel2.Visible = true;



            // MDirMaster.ToCSV(dt, "C:/HR/cc.csv");


        }







        protected void ButAdd_OnClick(object sender, EventArgs e)
        {
            //PalAdd.Visible = true;
            //PalUpdate.Visible = false;
            Panel2.Visible = true;

        }

        protected void ButUpdate_OnClick(object sender, EventArgs e)
        {
            //PalAdd.Visible = false;
            PalUpdate.Visible = true;

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //updatee();
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {

            string RECORD_DATE_S = "";
            if (RECORD_DATE.Text != "" && RECORD_DATE.Text.Length != 8)
            {
                RECORD_DATE_S = Convert.ToDateTime(RECORD_DATE.Text).ToString("yyyyMMdd");
            }
            else
            {
                RECORD_DATE_S = RECORD_DATE.Text;
            }
            string BIRTH_DATE_S = "";
            if (BIRTH_DATE.Text != "" && BIRTH_DATE.Text.Length != 8)
            {
                BIRTH_DATE_S = Convert.ToDateTime(BIRTH_DATE.Text).ToString("yyyyMMdd");
            }
            else
            {
                BIRTH_DATE_S = BIRTH_DATE.Text;
            }






            
            //if (TITLE.SelectedValue == "0")
            //{
            //    lblMessage.Text = "Must be select TITLE";
            //    lblMessage.BackColor = System.Drawing.Color.Red;
            //    return;
            //}


            string EmpID_S = lblempid.Text;


            SqlCommand cmd = new SqlCommand();
            SqlCommand cmd_update = new SqlCommand();

            //.PadLeft(8, '0')
            //EmpID = '" + EmpID.Text + @"',
            cmd_update.CommandText = @"update HR.[dbo].[AE_out_tb] set
               
RECORD_DATE	=                           '" + RECORD_DATE_S + @"',
INSTITUTION_NUMBER	=                   '" + INSTITUTION_NUMBER.Text + @"',
Account_Number	=                       '" + ACCOUNT_NUMBER.Text + @"',
LAST_NAME	=                           '" + LAST_NAME.Text + @"',
FIRST_NAME	=                           '" + FIRST_NAME.Text + @"',
FATHER_NAME	=                           '" + FATHER_NAME.Text + @"',
SHORT_NAME	=                           '" + SHORT_NAME.Text + @"',
COUNTER_BANK_ACCOUNT	=               '" + COUNTER_BANK_ACCOUNT.Text + @"',
EMBOSS_LINE_2	=                       '" + EMBOSS_LINE_2.Text + @"',
TEL_PRIVATE	=                           '" + TEL_PRIVATE.Text + @"',
PASSPORT_NUMBER	=                       '" + PASSPORT_NUMBER.Text + @"',
DRIVING_LICENSE	=                       '" + DRIVING_LICENSE.Text + @"',
BIRTH_DATE	=                           '" + BIRTH_DATE_S + @"',
BIRTH_PLACE	=                           '" + BIRTH_PLACE.Text + @"',
CLIENT_COUNTRY	=                       '" + CLIENT_COUNTRY_DDL.Text + @"',
CLIENT_CITY	=                           '" + CLIENT_CITY.Text + @"',
NATIONALITY	=                           '" + NATIONALITY_DDL.Text + @"',
ADR1_NAME_OF_CLIENT	=                   '" + ADR1_NAME_OF_CLIENT.Text + @"',
ADR2STREET1	=                           '" + ADR2STREET1.Text + @"',
ADR3STREET2	=                           '" + ADR3STREET2.Text + @"',
ADR4_STATE	=                           '" + ADR4_STATE.Text + @"',
ADR5_OTHER	=                           '" + ADR5_OTHER.Text + @"',
POST_CODE1	=                           '" + POST_CODE1.Text + @"',
ADDRESS_CLIENT_CITY1	=               '" + ADDRESS_CLIENT_CITY1.Text+ @"',
EMAIL_ADDRESS1	=                       '" + EMAIL_ADDRESS1.Text + @"',
Address_Category	=                   '" + Address_Category_DDL.Text + @"',
RESIDENCE_STATUS	=                   '" + RESIDENCE_STATUS_DDL.Text + @"',
DELIVERY_METHOD	=                       '" + DELIVERY_METHOD_DDL.Text + @"',
TEL_WORK	=                           '" + TEL_WORK.Text + @"',
FAX_WORK	=                           '" + FAX_WORK.Text + @"',
MOBILE_NO2	=                           '" + MOBILE_NO2.Text + @"',
EMAIL_ADDRESS2	=                       '" + EMAIL_ADDRESS2.Text + @"',
ID_NUMBER	=                           '" + ID_NUMBER.Text + @"',
OUR_REFERENCE	=                       '" + OUR_REFERENCE.Text + @"',
EMBOSS_LINE_3	=                       '" + EMBOSS_LINE_3.Text + @"',
Domiciliation	=                       '" + Domiciliation.Text + @"',
Domiciliation_2 =                       '" + Domiciliation_2.Text + @"',
Settlement_Bank_Name =                  '" + Settlement_Bank_Name.Text + @"',
Mobile_no_1 =                           '" + Mobile_no_1.Text + @"',
institution =                           '" + institusion_DDL.Text + @"',


isSend	=                               '" + isSend.Text + @"'


                where ID_NUMBER = @ID_NUMBER and id = '" + lbl_id.Text + "'";

            cmd_update.Parameters.AddWithValue("@ID_NUMBER", ID_NUMBER_.Text);


            cmd.CommandText = @"INSERT INTO HR.[dbo].[AE_out_tb]
([RECORD_DATE]
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
      ,[institution]
      ,[isSend] )
  VALUES
(
 '" + RECORD_DATE_S + @"',
'" + INSTITUTION_NUMBER.Text + @"',
'" + ACCOUNT_NUMBER.Text + @"',
'" + LAST_NAME.Text + @"',
'" + FIRST_NAME.Text + @"',
'" + FATHER_NAME.Text + @"',
'" + SHORT_NAME.Text + @"',
'" + COUNTER_BANK_ACCOUNT.Text + @"',
'" + EMBOSS_LINE_2.Text + @"',
'" + TEL_PRIVATE.Text + @"',
'" + PASSPORT_NUMBER.Text + @"',
'" + DRIVING_LICENSE.Text + @"',
'" + BIRTH_DATE_S + @"',
'" + BIRTH_PLACE.Text + @"',
'" + CLIENT_COUNTRY_DDL.Text + @"',
'" + CLIENT_CITY.Text + @"',
'" + NATIONALITY_DDL.Text + @"',
'" + ADR1_NAME_OF_CLIENT.Text + @"',
'" + ADR2STREET1.Text + @"',
'" + ADR3STREET2.Text + @"',
'" + ADR4_STATE.Text + @"',
'" + ADR5_OTHER.Text + @"',
'" + POST_CODE1.Text + @"',
'" + ADDRESS_CLIENT_CITY1.Text + @"',
'" + EMAIL_ADDRESS1.Text + @"',
'" + Address_Category_DDL.Text + @"',
'" + RESIDENCE_STATUS_DDL.Text + @"',
'" + DELIVERY_METHOD_DDL.Text + @"',
'" + TEL_WORK.Text + @"',
'" + FAX_WORK.Text + @"',
'" + MOBILE_NO2.Text + @"',
'" + EMAIL_ADDRESS2.Text + @"',
'" + ID_NUMBER.Text + @"',
'" + OUR_REFERENCE.Text + @"',
'" + EMBOSS_LINE_3.Text + @"',
'" + Domiciliation.Text+ @"',
'" + Domiciliation_2.Text + @"',
'" + Settlement_Bank_Name.Text + @"',
'" + Mobile_no_1.Text + @"',
'" + institusion_DDL.Text + @"',

 '" + isSend.Text + @"'

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


    }
}




//'" + RECORD_DATE_S + @"',
//'" + INSTITUTION_NUMBER.Text + @"',
//'" + LAST_NAME.Text.PadLeft(25, ' ') + @"',
//'" + FIRST_NAME.Text.PadLeft(15, ' ') + @"',
//'" + FATHER_NAME.Text.PadLeft(20, ' ') + @"',
//'" + SHORT_NAME.Text.PadLeft(24, ' ') + @"',
//'" + COUNTER_BANK_ACCOUNT.Text.PadLeft(16, ' ') + @"',
//'" + EMBOSS_LINE_2.Text.PadLeft(24, ' ') + @"',
//'" + TEL_PRIVATE.Text.PadLeft(15, ' ') + @"',
//'" + PASSPORT_NUMBER.Text.PadLeft(15, ' ') + @"',
//'" + DRIVING_LICENSE.Text.PadLeft(15, ' ') + @"',
//'" + BIRTH_DATE_S + @"',
//'" + BIRTH_PLACE.Text.PadLeft(15, ' ') + @"',
//'" + CLIENT_COUNTRY_DDL.Text + @"',
//'" + CLIENT_CITY.Text.PadLeft(13, ' ') + @"',
//'" + NATIONALITY_DDL.Text + @"',
//'" + ADR1_NAME_OF_CLIENT.Text.PadLeft(35, ' ') + @"',
//'" + ADR2STREET1.Text.PadLeft(35, ' ') + @"',
//'" + ADR3STREET2.Text.PadLeft(35, ' ') + @"',
//'" + ADR4_STATE.Text.PadLeft(35, ' ') + @"',
//'" + ADR5_OTHER.Text.PadLeft(35, ' ') + @"',
//'" + POST_CODE1.Text.PadLeft(20, ' ') + @"',
//'" + ADDRESS_CLIENT_CITY1.Text.PadLeft(35, ' ') + @"',
//'" + EMAIL_ADDRESS1.Text.PadLeft(32, ' ') + @"',
//'" + Address_Category_DDL.Text + @"',
//'" + RESIDENCE_STATUS_DDL.Text.PadLeft(15, ' ') + @"',
//'" + DELIVERY_METHOD_DDL.Text.PadLeft(3, ' ') + @"',
//'" + TEL_WORK.Text.PadLeft(15, ' ') + @"',
//'" + FAX_WORK.Text.PadLeft(15, ' ') + @"',
//'" + MOBILE_NO2.Text.PadLeft(15, ' ') + @"',
//'" + EMAIL_ADDRESS2.Text.PadLeft(60, ' ') + @"',
//'" + ID_NUMBER.Text.PadLeft(15, ' ') + @"',
//'" + OUR_REFERENCE.Text.PadLeft(20, ' ') + @"',
//'" + EMBOSS_LINE_3.Text.PadLeft(26, ' ') + @"',
//'" + Domiciliation.Text.PadLeft(16, ' ') + @"',
//'" + Domiciliation_2.Text.PadLeft(35, ' ') + @"',
//'" + Settlement_Bank_Name.Text.PadLeft(40, ' ') + @"',
//'" + Mobile_no_1.Text.PadLeft(15, ' ') + @"',