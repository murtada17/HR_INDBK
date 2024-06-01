using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;

namespace HR_Salaries.Pages.RESPONSE
{
    public partial class Delete_Reference : System.Web.UI.Page
    {
          int add_udate = 0; // Add = 1 & update = 2;

        protected void Page_Load(object sender, EventArgs e)
        {
            

            if (!IsPostBack)
            {
                
                
            }
        }

       

       

        protected void GVUpdate_SelectedIndexChanged(object sender, EventArgs e)
        {

            string id = GVUpdate.SelectedRow.Cells[1].Text;

            SqlCommand cmd_Search3 = new SqlCommand();
            SqlCommand cmd_Search4 = new SqlCommand();

            cmd_Search3.CommandText = @"


                                      
                                ";


            cmd_Search4.CommandText = cmd_Search3.CommandText.Replace("$WhereString", " [id] Like '%" + id + "%' ");

            DataTable dt = MDirMaster.GetData(cmd_Search4, lblMessage);

            //item_name.Text    =     dt.Rows[0]["item_name"].ToString();
            //item_number.Text  =     dt.Rows[0]["item_number"].ToString();
           

            Panel_Add_Update.Visible = true;
            Panel3.Visible           = true;




        }

        protected void btnSerchUpdate_Click(object sender, EventArgs e)
        {

            // get month & years :
           

            SqlCommand cmd_Search   = new SqlCommand();
            SqlCommand cmd_Search2  = new SqlCommand();
            cmd_Search2.CommandText = @"
                                        SELECT 
                                             [Institution_number] 'ID'
                                            ,[Last_Name]
                                            ,[First_Name]
                                            ,[EMBOSS_LINE_1]
                                            ,[Contract_Reference]
                                            
                                         
                                        FROM [HR].[dbo].[Al_Response_out] 
                                 
                                  WHERE $WhereString
                                
                                ";

            cmd_Search.CommandText = cmd_Search2.CommandText.Replace("$WhereString", "[Contract_Reference] = '" + txtUpdate.Text + "' ");

            MDirMaster.FillGrid(cmd_Search, GVUpdate, lblMessage);

            //Panel_Add_Update.Visible = true;
           
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            Panel2.Visible = true;

        }

        protected void btnyes_Click(object sender, EventArgs e)
        {
           string Contract_Reference1 = GVUpdate.SelectedRow.Cells[5].Text;


            SqlCommand cmd_Search = new SqlCommand();
            SqlCommand cmd_Search2 = new SqlCommand();
            cmd_Search2.CommandText = @"
                                  DELETE FROM [dbo].[Al_Response_out]
                                  WHERE $WhereString
                                
                                ";
            cmd_Search.CommandText = cmd_Search2.CommandText.Replace("$WhereString", "[Contract_Reference] = '" + Contract_Reference1 + "' ");
            //cmd_Search.CommandText = cmd_Search2.CommandText.Replace("$WhereString", "[Contract_Reference] Like '%" + Contract_Reference1 + "%' ");

            MDirMaster.Execute(cmd_Search, lblMessage, "");

            Panel2.Visible = false;
            Panel_Add_Update.Visible = false;
            Panel3.Visible = false;


            GVUpdate.DataSource = null;
            GVUpdate.DataBind();


        }

        protected void btnno_Click(object sender, EventArgs e)
        {

        }
    }
}