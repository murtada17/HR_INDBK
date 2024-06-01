using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HR_Salaries;

namespace HR_Salaries.Pages.Additional
{
    public partial class BranchAdEd : System.Web.UI.Page
    {
        public static int BranchID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string url = HttpContext.Current.Request.Path;
                if (!MDirMaster.HasPrivilage(url, lblMessage))
                {
                    Session["msg"] = "9";
                    Response.Redirect("~/Pages/Default.aspx", false);
                }
                else
                {
                    GetGrid();
                    MDirMaster.FillCombo("EmailID", "EmailName", "EmailsTBL", ddlEmail, lblMessage);
                }
            }
            else
            {
                lblMessage.Text = string.Empty;
            }
        }

        public void GetGrid()
        {

            string Query = @" SELECT       dbo.BranchsTBL.BranchID, dbo.BranchsTBL.BranchNo AS [رقم الفرع], dbo.BranchsTBL.BranchDescEN AS [أسم الفرع (انكليزي)], 
                                           dbo.BranchsTBL.BranchDescAR AS [أسم الفرع (عربي)], dbo.EmailsTBL.EmailName AS [البريد الألكتروني], dbo.BranchsTBL.City AS المدينة, dbo.BranchsTBL.Address AS العنوان, 
                                           dbo.BranchsTBL.PhoneNo AS [رقم الهاتف], dbo.BranchsTBL.IsActive AS [فعال؟]
                            FROM           dbo.BranchsTBL FULL JOIN
                         dbo.EmailsTBL ON dbo.BranchsTBL.EmailID = dbo.EmailsTBL.EmailID";
            SqlCommand cmd = new SqlCommand(Query);
            MDirMaster.FillGrid(cmd, gvBranch, lblMessage);
            //gvBranch.Columns[1].Visible = false;
        }

        protected void gvBranch_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView gv = sender as GridView;
            gv.PageIndex = e.NewPageIndex;
            gv.SelectedIndex = -1;
            MDirMaster.ClearControls(pnlControls);
            GetGrid();
        }

        protected void gvBranch_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            int index = e.NewSelectedIndex;
            GridView gv = sender as GridView;
            BranchID = Convert.ToInt32(gv.Rows[index].Cells[1].Text);
            string Query = @" SELECT [BranchNo], [BranchDescEN], [BranchDescAR], [EmailID], [City], [Address], [PhoneNo], [IsActive]
                                FROM [HR].[dbo].[BranchsTBL]
                                WHERE [BranchID] = @BranchID";
            SqlCommand cmd = new SqlCommand(Query);
            cmd.Parameters.AddWithValue("@BranchID", BranchID);
            DataTable dt = MDirMaster.GetData(cmd, lblMessage);
            txtNumber.Text = dt.Rows[0]["BranchNo"].ToString();
            txtNameEN.Text = dt.Rows[0]["BranchDescEN"].ToString();
            txtNameAR.Text = dt.Rows[0]["BranchDescAR"].ToString();
            ddlEmail.SelectedValue = dt.Rows[0]["EmailID"].ToString();
            txtCity.Text = dt.Rows[0]["City"].ToString();
            txtAddress.Text = dt.Rows[0]["Address"].ToString();
            txtPhoneNo.Text = dt.Rows[0]["PhoneNo"].ToString();
            chbActive.Checked = (bool)dt.Rows[0]["IsActive"];
            txtNumber.Enabled = false;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@BranchDescEN", txtNameEN.Text);
            cmd.Parameters.AddWithValue("@BranchDescAR", txtNameAR.Text);
            cmd.Parameters.AddWithValue("@EmailID ", ddlEmail.SelectedValue);
            cmd.Parameters.AddWithValue("@City", txtCity.Text);
            cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
            cmd.Parameters.AddWithValue("@PhoneNo", txtPhoneNo.Text);
            cmd.Parameters.AddWithValue("@IsActive", chbActive.Checked);
            cmd.Parameters.AddWithValue("@BranchID", BranchID);
            if (BranchID > 0)
            {
                //Edit
                cmd.CommandText = @"UPDATE [HR].[dbo].[BranchsTBL] SET [BranchDescEN] = @BranchDescEN, [BranchDescAR] = @BranchDescAR, [EmailID ] = @EmailID , 
                                                                       [City] = @City, [Address] = @Address, [PhoneNo] = @PhoneNo, [IsActive] = @IsActive
                                
                                WHERE [BranchID] = @BranchID";

                MDirMaster.Execute(cmd, lblMessage, HttpContext.Current.Request.Path);
                Session["PageIndex"] = gvBranch.PageIndex;
                BranchID = 0;
                MDirMaster.ClearControls(pnlControls);
            }
            else
            {
                //Insert
                cmd.CommandText = @" INSERT INTO [HR].[dbo].[BranchsTBL] ([BranchNo], [BranchDescEN], [BranchDescAR], [EmailID ], [City], [Address], [PhoneNo], [IsActive])
                                                                VALUES   (@BranchNo, @BranchDescEN, @BranchDescAR, @EmailID , @City, @Address, @PhoneNo, @IsActive) ";
                cmd.Parameters.AddWithValue("@BranchNo", txtNumber.Text);
                MDirMaster.Execute(cmd, lblMessage, HttpContext.Current.Request.Path);
                MDirMaster.ClearControls(pnlControls);
            }
            GetGrid();

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            if (BranchID > 0)
            {
                Session["PageIndex"] = gvBranch.PageIndex;
                BranchID = 0;
                Response.Redirect("~/Pages/Additional/BranchAdEd.aspx", false);
            }
            else
            {
                Response.Redirect("~/Pages/Default.aspx", false);
            }
        }
    }
}