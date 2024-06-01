using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HR_Salaries.Pages.Al_Send_Manage
{
    public partial class SendManage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Pal_select.Visible = false;
            countissend();
            countisNotsend();
        }

        

        protected void btnIsSendManage_Click(object sender, EventArgs e)
        {
            if (dat_RecordDate.Text.Length == 8)
            {
                SqlCommand cmd = new SqlCommand();


                cmd.CommandText = @"
                                UPDATE [HR].[dbo].[alfile_tb]
                                SET [IsSend] = 1
                                WHERE [RECORD_DATE] = '" + dat_RecordDate.Text + @"'";
                MDirMaster.ExecuteScaler(cmd, lblMessage, HttpContext.Current.Request.Path);

                countissend();
                countisNotsend();
            }

            else
            {
                lblMessage.Text = "يرجى ملىء حقل التاريخ";
            }

        }

        protected void btnIsSendManage_not_Click(object sender, EventArgs e)
        {
            if (dat_RecordDate.Text.Length == 8)
            {
                SqlCommand cmd = new SqlCommand();


                cmd.CommandText = @"
                                UPDATE [HR].[dbo].[alfile_tb]
                                SET [IsSend] = 0
                                WHERE [RECORD_DATE] = '" + dat_RecordDate.Text + @"'";
                MDirMaster.ExecuteScaler(cmd, lblMessage, HttpContext.Current.Request.Path);

                countissend();
                countisNotsend();
            }

            else
            {
                lblMessage.Text = "يرجى ملىء حقل التاريخ";
            }
        }





        protected void btn_notSendAll_Click(object sender, EventArgs e)
        {
            Pal_select.Visible = true;
                
        }

        protected void btnno_Click(object sender, EventArgs e)
        {
            Pal_select.Visible = false;

        }

        protected void btnyes_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand();


            cmd.CommandText = @"
                                UPDATE [HR].[dbo].[alfile_tb]
                                SET [IsSend] = 0
                                ";
            MDirMaster.ExecuteScaler(cmd, lblMessage, HttpContext.Current.Request.Path);
            Pal_select.Visible = false;

            countissend();
            countisNotsend();

        }







        public void countissend()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = @"SELECT count([id])

                FROM[HR].[dbo].[alfile_tb]
                where[IsSend] = 1";


            DataTable dt = MDirMaster.GetData(cmd, lblMessage);

            lbl_SendCount.Text = dt.Rows[0][0].ToString();
        }


        public void countisNotsend()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = @"SELECT count([id])

                FROM[HR].[dbo].[alfile_tb]
                where[IsSend] = 0";


            DataTable dt = MDirMaster.GetData(cmd, lblMessage);

            lbl_NotSendCount.Text = dt.Rows[0][0].ToString();
        }

    }
}