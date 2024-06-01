using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HR_Salaries.Pages
{
    public partial class ALForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                MDirMaster.FillCombo("id", "status_yn", "Al_YN", SECURE_REGISTRATION_INDICATOT, "1=1", lblMessage);
                MDirMaster.FillCombo("id", "status_yn", "Al_YN", CMO_REGISTRATION_INDICATOR, "1=1", lblMessage);
                MDirMaster.FillCombo("id", "status_yn", "Al_YN", COM_STIKER_REGISTRATION_INDICATRO, "1=1", lblMessage);
                MDirMaster.FillCombo("id", "status_yn", "Al_YN", STICKER_CARD, "1=1", lblMessage);
                MDirMaster.FillCombo("INDEX_FIELD", "delivery_method", "Al_DeliveryMethod", DELIVERY_METHOD, "1=1", lblMessage);

                DELIVERY_METHOD.SelectedIndex = 0;
            }














        }


        protected void btnSend_Click(object sender, EventArgs e)
        {
            
if (DELIVERY_METHOD.SelectedValue == "0")
            {
                lblMessage.Text = "Must be select DELIVERY_METHOD";
                return;
            }















            string pID = Session["sID3"].ToString();

            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = @"UPDATE [dbo].[alfile_tb] Set 
            DATE_OF_APPLICATION= @DATE_OF_APPLICATION,
            
            SECURE_REGISTRATION_INDICATOT = @SECURE_REGISTRATION_INDICATOT,
            CMO_REGISTRATION_INDICATOR = @CMO_REGISTRATION_INDICATOR,
            CMO_MOBILE_NUMBER = @CMO_MOBILE_NUMBER,
            COM_STIKER_REGISTRATION_INDICATRO = @COM_STIKER_REGISTRATION_INDICATRO,
            IBAN_NUMBER = @IBAN_NUMBER,
            STICKER_CARD = @STICKER_CARD,
            DELIVERY_METHOD = @DELIVERY_METHOD,
            ADDR_LINE_1 = @ADDR_LINE_1,
            ADDR_LINE_2 = @ADDR_LINE_2,
            ADDR_LINE_3 = @ADDR_LINE_3,
            STATE = @STATE,
            OTHER = @OTHER,
            POST_CODE = @POST_CODE,
            ADDRESS_CLIENT_CITY = @ADDRESS_CLIENT_CITY,
            EMAIL_ADDRESS = @EMAIL_ADDRESS,
            EMAIL_ADDRESS2 = @EMAIL_ADDRESS2,
            ADR1_NAME_OF_CLIENT = @ADR1_NAME_OF_CLIENT,
            ADR2STREET1 = @ADR2STREET1,
            ADR3STREET2 = @ADR3STREET2,
            ADR4_STATE = @ADR4_STATE,
            ADR5_OTHER = @ADR5_OTHER,
            POST_CODE1 = @POST_CODE1,
            ADDRESS_CLIENT_CITY1 = @ADDRESS_CLIENT_CITY1,
            EMAIL_ADDRESS1 = @EMAIL_ADDRESS1,
            status = @status


            where id = @id

            ";

            //.PadRight(35, ' ')
            //Convert.ToDateTime(DATE_OF_APPLICATION.Text).ToString("yyyyMMdd")

            string DATE_OF_APPLICATION_S = "";
            if (DATE_OF_APPLICATION.Text != "")
            {
                DATE_OF_APPLICATION_S = Convert.ToDateTime(DATE_OF_APPLICATION.Text).ToString("yyyyMMdd");
            }
            else
            {
                DATE_OF_APPLICATION_S = "";
            }



            cmd.Parameters.AddWithValue("@id", pID);
            cmd.Parameters.AddWithValue("@DATE_OF_APPLICATION", DATE_OF_APPLICATION_S);
            cmd.Parameters.AddWithValue("@SECURE_REGISTRATION_INDICATOT", SECURE_REGISTRATION_INDICATOT.Text);
            cmd.Parameters.AddWithValue("@CMO_REGISTRATION_INDICATOR", CMO_REGISTRATION_INDICATOR.Text);
            cmd.Parameters.AddWithValue("@CMO_MOBILE_NUMBER", CMO_MOBILE_NUMBER.Text);
            cmd.Parameters.AddWithValue("@COM_STIKER_REGISTRATION_INDICATRO", COM_STIKER_REGISTRATION_INDICATRO.Text);
            cmd.Parameters.AddWithValue("@IBAN_NUMBER", IBAN_NUMBER.Text);
            cmd.Parameters.AddWithValue("@STICKER_CARD", STICKER_CARD.Text);
            cmd.Parameters.AddWithValue("@DELIVERY_METHOD", DELIVERY_METHOD.Text.PadLeft(3, '0'));
            cmd.Parameters.AddWithValue("@ADDR_LINE_1", ADDR_LINE_1.Text);
            cmd.Parameters.AddWithValue("@ADDR_LINE_2", ADDR_LINE_2.Text);
            cmd.Parameters.AddWithValue("@ADDR_LINE_3", ADDR_LINE_3.Text);
            cmd.Parameters.AddWithValue("@STATE", STATE.Text);
            cmd.Parameters.AddWithValue("@OTHER", OTHER.Text);
            cmd.Parameters.AddWithValue("@POST_CODE", POST_CODE.Text);
            cmd.Parameters.AddWithValue("@ADDRESS_CLIENT_CITY", ADDRESS_CLIENT_CITY.Text);
            cmd.Parameters.AddWithValue("@EMAIL_ADDRESS", EMAIL_ADDRESS.Text);
            cmd.Parameters.AddWithValue("@EMAIL_ADDRESS2", EMAIL_ADDRESS2.Text);
            cmd.Parameters.AddWithValue("@ADR1_NAME_OF_CLIENT", ADR1_NAME_OF_CLIENT.Text);
            cmd.Parameters.AddWithValue("@ADR2STREET1", ADR2STREET1.Text);
            cmd.Parameters.AddWithValue("@ADR3STREET2", ADR3STREET2.Text);
            cmd.Parameters.AddWithValue("@ADR4_STATE", ADR4_STATE.Text);
            cmd.Parameters.AddWithValue("@ADR5_OTHER", ADR5_OTHER.Text);
            cmd.Parameters.AddWithValue("@POST_CODE1", POST_CODE1.Text);
            cmd.Parameters.AddWithValue("@ADDRESS_CLIENT_CITY1", ADDRESS_CLIENT_CITY1.Text);
            cmd.Parameters.AddWithValue("@EMAIL_ADDRESS1", EMAIL_ADDRESS1.Text);

            cmd.Parameters.AddWithValue("@status", "0");

            MDirMaster.Execute(cmd, lblMessage, HttpContext.Current.Request.Path);

        }



    }
}