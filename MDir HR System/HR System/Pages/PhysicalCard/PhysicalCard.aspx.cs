using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HR_Salaries.Pages.PhysicalCard
{
    public partial class PhysicalCard : System.Web.UI.Page
    {
        string AddOrUpdate = "";

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {

                MDirMaster.FillCombo("ISO_CODE", "SWIFT_CODE", "Al_Currency_2", ddlCCY, "1=1", lblMessage);
                MDirMaster.FillCombo("TransactionType_Nu", "TransactionType_Name", "TransactionType", ddlTraType, "1=1", lblMessage);

                //MDirMaster.FillCombo("INDEX_FIELD", "EMPLOYMENT_POSITION", "Al_EMPLOYMENT_POSITION", EMPLOYMENT_POSITION, "1=1", lblMessage);
                //MDirMaster.FillCombo("id", "status_yn", "Al_YN", SECURE_REGISTRATION_INDICATOT, "1=1", lblMessage);
                //MDirMaster.FillCombo("id", "status_yn", "Al_YN", CMO_REGISTRATION_INDICATOR, "1=1", lblMessage);
                //MDirMaster.FillCombo("id", "status_yn", "Al_YN", COM_STIKER_REGISTRATION_INDICATRO, "1=1", lblMessage);
                //MDirMaster.FillCombo("id", "status_yn", "Al_YN", STICKER_CARD, "1=1", lblMessage);
                //MDirMaster.FillCombo("INDEX_FIELD", "delivery_method", "Al_DeliveryMethod", DELIVERY_METHOD, "1=1", lblMessage);
                //MDirMaster.FillCombo("id", "institusion", "AL_institusion_TBL", ADDR_LINE_33, "1=1", lblMessage);


            }


        }

        
        // Serch in alfile_out_tb
        protected void btnSerchUpdate_Click(object sender, EventArgs e)
        {
            SqlCommand cmd_Search = new SqlCommand();


            cmd_Search.CommandText = @"SELECT 
      [id]
      ,[name]
      ,[Card_number]
      ,[Account_Number]
      ,[Amount_IQD]
      ,[Amount_USD]
      ,[phone_number]
      ,[email]
      ,[status]
      ,[IsSend]
  FROM [HR].[dbo].[AL_Physical_card_TBL]
     
  
        Where [Card_number] like '%" + txtUpdate.Text + "%'";

            //cmd_Search.Parameters.AddWithValue("@CONTRACT_REFERENCE", txtUpdate.Text);

            MDirMaster.FillGrid(cmd_Search, GVUpdate, lblMessage);

            PalUpdate.Visible = true;
        }



        //  GV for Update
        protected void GVUpdate_PageIndexChanging(object sender, EventArgs e)
        {

            AddUpdate.Text = "update";

            string id = GVUpdate.SelectedRow.Cells[1].Text;
            CONTRACTREFERENCE.Text = id;
            SqlCommand cmd_GV = new SqlCommand();

            cmd_GV.CommandText = @"SELECT
                                  [name]
                                  ,[Card_number]
                                  ,[Account_Number]
                                  ,[Amount_IQD]
                                  ,[Amount_USD]
                                  ,[phone_number]
                                  ,[email]
                                  ,[status]
                                  ,[IsSend]
                                  ,[ccy]
                              
                              FROM [HR].[dbo].[AL_Physical_card_TBL] where id = @id";

            cmd_GV.Parameters.AddWithValue("@id", id);

            DataTable dt = MDirMaster.GetData(cmd_GV, lblMessage);

            

            txtfull_name.Text = dt.Rows[0]["name"].ToString();
            txtCardNumber.Text = dt.Rows[0]["Card_number"].ToString();
            txtAccount_Number.Text = dt.Rows[0]["Account_Number"].ToString();
            /////////////////////////////
            string amo =     dt.Rows[0]["Amount_IQD"].ToString();
            string amo_usd = dt.Rows[0]["Amount_USD"].ToString();
            string rsamount = "";

            if(amo == "0.000") { rsamount = dt.Rows[0]["Amount_USD"].ToString(); }
            else { rsamount = dt.Rows[0]["Amount_IQD"].ToString(); }

            txtAmount.Text = rsamount;
            ////////////////////////////////////////////////////////////////////////////

            txtphone_number.Text = dt.Rows[0]["phone_number"].ToString();

            txtEmail.Text = dt.Rows[0]["email"].ToString();


            if (dt.Rows[0]["status"].ToString() == "True") { isActive.Checked = true; } else { isActive.Checked = false; }
            if (dt.Rows[0]["isSend"].ToString() == "True") { isSend.Checked = true; } else { isSend.Checked = false; }



            ddlCCY.Text = dt.Rows[0]["ccy"].ToString();






            Panel2.Visible = true;


            GVUpdate.Visible = false;
        }


        //select re.Contract_Reference, re.Card_number, re.Account_Number ,pa.[Amount]  as 'Full Salary'

        protected void btn_export_Click(object sender, EventArgs e)
        {
            SqlCommand cmd_ = new SqlCommand();
            cmd_.CommandText = @"SELECT
           [name]
          ,[Card_number]
          ,[Account_Number]
          ,[Amount_IQD]
          ,[Amount_USD]
          ,[ccy]
          FROM [HR].[dbo].[AL_Physical_card_TBL] where [Card_number] =@Card_number ";

            cmd_.Parameters.AddWithValue("@Card_number", txtCardNumber.Text);
            DataTable dt_ = MDirMaster.GetData(cmd_, lblMessage);


            string exp = ddlCCY.Text;
            SqlCommand cmd_exp = new SqlCommand();
            cmd_exp.CommandText = @"SELECT [EXPONENT]
                                    FROM [HR].[dbo].[Al_Currency_2] 
                                    where [ISO_CODE] = @ISO_CODE";

            cmd_exp.Parameters.AddWithValue("@ISO_CODE", exp);
            DataTable dt_exp = MDirMaster.GetData(cmd_exp, lblMessage);

            string exponent = dt_exp.Rows[0][0].ToString();




            // get Max Sequence

            SqlCommand cmd_get_sec = new SqlCommand();
            cmd_get_sec.CommandText = @"SELECT max([SequenceNumber]) as maxsec
      
                                        FROM [HR].[dbo].[SequenceNumber_2_tb]";

            //cmd_get_sec.Parameters.AddWithValue("@ISO_CODE", exp);
            DataTable dt_get_sec = MDirMaster.GetData(cmd_get_sec, lblMessage);

            int max_sec = int.Parse(dt_get_sec.Rows[0][0].ToString()) + 1;

            SequenceNumber.Text = max_sec.ToString();

            // End get Max Sequence

            // get Max Deposit slip number

            SqlCommand cmd_get_DSlipNu = new SqlCommand();
            cmd_get_DSlipNu.CommandText = @"SELECT max([DepositSlipNumber])
      
                                        FROM [HR].[dbo].[AL_DepositSlipNumber_2]";

            //cmd_get_sec.Parameters.AddWithValue("@ISO_CODE", exp);
            DataTable dt_get_DSlipNu = MDirMaster.GetData(cmd_get_DSlipNu, lblMessage);

            int max_sec_DSlipNu = int.Parse(dt_get_DSlipNu.Rows[0][0].ToString()) + 1;

            txtDSlipNu.Text = max_sec_DSlipNu.ToString();

            // End get Max Deposit slip number



           // MDirMaster.WriteDataToFile(dt_, "C:/HR/", ddlCCY.Text, 00000154, max_sec, int.Parse(txtDSlipNu.Text), int.Parse(ddlTraType.Text), int.Parse(dllTraCategory.Text), exponent, int.Parse(SlipNumber.Text), dt_fullsalary);
            SqlCommand cmd_sec = new SqlCommand();
            cmd_sec.CommandText = @"
            INSERT INTO [dbo].[SequenceNumber_2_tb]
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
            INSERT INTO [dbo].[AL_DepositSlipNumber_2]
           (
           [description]
           )
            VALUES
           ('description')

            ";
            MDirMaster.ExecuteScaler(cmd_sec, lblMessage, HttpContext.Current.Request.Path);






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

            //if (TITLE.SelectedValue == "0")
            //{
            //    lblMessage.Text = "Must be select TITLE";
            //    return;
            //}
           
            //string EMPLOYMENT_DATE_S = "";
            //if (EMPLOYMENT_DATE.Text != "" && EMPLOYMENT_DATE.Text.Length != 8)
            //{
            //    EMPLOYMENT_DATE_S = Convert.ToDateTime(EMPLOYMENT_DATE.Text).ToString("yyyyMMdd");
            //}
            //else
            //{
            //    EMPLOYMENT_DATE_S = EMPLOYMENT_DATE.Text;
            //}
           
            string EmpID_S = "";


            SqlCommand cmd_max = new SqlCommand();
            SqlCommand cmd = new SqlCommand();
            SqlCommand cmd_update = new SqlCommand();


            //368 IQD
            //840 USD
            string amount_iqd_s = "";
            string amount_usd_s = "";

            string ccy_s = ddlCCY.Text;
            if (ccy_s == "368") { amount_iqd_s = txtAmount.Text; amount_usd_s = "0"; }
            if (ccy_s == "840") { amount_usd_s = txtAmount.Text; amount_iqd_s = "0"; }


            int issend_ss = 0;
            int isactive_ss = 0;

            bool issend_s = isSend.Checked;
            bool isactive_s = isActive.Checked;

            if (issend_s == true) { issend_ss = 1; } else { issend_ss = 0; }
            if (isactive_s == true) { isactive_ss = 1; } else { isactive_ss = 0; }



            cmd_update.CommandText = @"USE [HR]


UPDATE HR.[dbo].[AL_Physical_card_TBL]
   SET [name] = '" + txtfull_name.Text + @"'
      ,[Card_number] = '" + txtCardNumber.Text + @"'
      ,[Account_Number] = '" + txtAccount_Number.Text + @"'
      ,[Amount_IQD] = '" + amount_iqd_s + @"'
      ,[Amount_USD] = '" + amount_usd_s + @"'
      ,[phone_number] = '" + txtphone_number.Text + @"'
      ,[email] ='" + txtEmail.Text + @"'
      ,[status] = '" + isactive_ss + @"'
      ,[IsSend] = '" + issend_ss + @"'
      where id = '" + CONTRACTREFERENCE.Text + "'";

            //cmd_update.Parameters.AddWithValue("@id", id.Text);


            cmd.CommandText = @"
           INSERT INTO HR.[dbo].[AL_Physical_card_TBL]
           ([name]
           ,[Card_number]
           ,[Account_Number]
           ,[Amount_IQD]
           ,[Amount_USD]
           ,[phone_number]
           ,[email]
           ,[status]
           ,[IsSend]
            ,[ccy])
           VALUES
           (
            '" + txtfull_name.Text + @"'
           ,'" + txtCardNumber.Text + @"'
           ,'" + txtAccount_Number.Text + @"'
           ,'" + amount_iqd_s + @"'
           ,'" + amount_usd_s + @"'
           ,'" + txtphone_number.Text + @"'
           ,'" + txtEmail.Text + @"'
           ,'" + isactive_ss + @"'
           ,'" + issend_ss + @"'
           ,'" + ddlCCY.Text + @"'
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
