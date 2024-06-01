using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HR_Salaries.Pages.Salaries
{
    public partial class AllowAdEd : System.Web.UI.Page
    {
        public static int ParentID = 0, ValueID = 0, ValueTypeID = 0;
        public static bool IsPerecantage;
        public static DataTable dtValues = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string url = HttpContext.Current.Request.Path;
                string newURL = url.Replace("AllowAdEd", "Allowance");// .Substring(url.LastIndexOf("/")+1);
                if (!TBIMaster.HasPrivilage(newURL, lblMessage))
                {
                    Session["msg"] = "9";
                    Response.Redirect("~/Pages/Default.aspx");
                }
                else
                {
                    TBIMaster.FillCombo("ValuesTypeID", "ValuesTypeDescAR", "ValuesTypeTBL", ddlType, true, lblMessage);
                    if (Session["AllowanceID"] != null)
                    {
                        IsPerecantage = Convert.ToBoolean(rblIsPercentage.SelectedValue);
                        ParentID = Convert.ToInt32(Session["AllowanceID"]);
                        if (ParentID > 0)
                        {
                            GetData();
                        }
                        else
                        {
                            btnSubmit.Text = "إضافة";
                        }
                    }
                }
            }
            else
            {
                lblMessage.Text = "";
            }

        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand();
            string Query = "";
            if (ValueID > 0)
            {
                //edit
                Query = @"UPDATE ValuesTBL SET TitleEN= @TitleEN, TitleAR= @TitleAR, Value= @Value, IsActive= @IsActive, ParentID=@ParentID, ValueTypeID= @ValueTypeID
                                    WHERE (ValueID= @ValueID)";
                cmd.Parameters.AddWithValue("ValueID", ValueID);
            }
            else
            {
                //Add
                Query = @"INSERT INTO ValuesTBL (TitleEN, TitleAR, Value, IsActive, ParentID, ValueTypeID)
                                      VALUES (@TitleEN, @TitleAR, @Value, @IsActive, @ParentID, @ValueTypeID)";
            }
            cmd.CommandText = Query;
            cmd.Parameters.AddWithValue("@TitleEN", txtValueDescEN.Text);
            cmd.Parameters.AddWithValue("@TitleAR", txtValueDescAR.Text);
            cmd.Parameters.AddWithValue("@Value", txtValue.Text);
            cmd.Parameters.AddWithValue("@IsActive", chbValueActive.Checked);
            cmd.Parameters.AddWithValue("@ParentID", ParentID);
            cmd.Parameters.AddWithValue("@ValueTypeID", ValueTypeID);
            if (TBIMaster.Execute(cmd, lblMessage))
            {
                GetData();
            }
        }

        public void GetData()
        {
            SqlCommand cmd = new SqlCommand(@"SELECT [TitleEN]   ,[TitleAR]      ,[GlCode]      ,[IsActive],    [ValueTypeID]      ,[IsPercentage]
                    FROM [HR].[dbo].[ValuesTBL]
                    WHERE [ValueID]=@ID");
            cmd.Parameters.AddWithValue("@ID", ParentID);
            DataTable dt = TBIMaster.GetData(cmd, lblMessage);
            if (dt.Rows.Count > 0)
            {
                txtAllowTitleEN.Text = dt.Rows[0][0].ToString();
                txtAllowTitleAR.Text = dt.Rows[0][1].ToString();
                txtGLCode.Text = dt.Rows[0][2].ToString();
                chbActive.Checked = Convert.ToBoolean(dt.Rows[0][3].ToString());
                ddlType.SelectedValue = dt.Rows[0][4].ToString();
                ValueTypeID = Convert.ToInt32(dt.Rows[0][4]);
                rblIsPercentage.SelectedValue = dt.Rows[0][5].ToString();

                // get Values 
                SqlCommand cmdValues = new SqlCommand(@"SELECT      ROW_NUMBER() OVER (ORDER BY ValueID) AS [ت],  dbo.ValuesTBL.ValueID, dbo.ValuesTBL.ParentID, dbo.ValuesTBL.ValueTypeID, dbo.ValuesTBL.TitleEN AS [العنوان (انكليزي)], dbo.ValuesTBL.TitleAR AS [العنوان (عربي)], 
                         dbo.ValuesTBL.Value AS [المبلغ او النسبة], dbo.ValuesTBL.IsPercentage AS [نسبة؟], dbo.ValuesTypeTBL.ValuesTypeDescAR AS [النوع (عربي)], 
                         dbo.ValuesTypeTBL.ValuesTypeDescEN AS [النوع (انكليزي)], dbo.ValuesTBL.IsActive AS [فعال؟]
                    FROM            dbo.ValuesTBL INNER JOIN
                         dbo.ValuesTypeTBL ON dbo.ValuesTBL.ValueTypeID = dbo.ValuesTypeTBL.ValuesTypeID
                    WHERE        (dbo.ValuesTBL.ParentID = @PID)");
                cmdValues.Parameters.AddWithValue("@PID", ParentID);
                dtValues = TBIMaster.GetData(cmdValues, lblMessage);
                pnlValues.Enabled = true;
                gvValues.DataSource = dtValues;
                gvValues.DataBind();
                int count = gvValues.Columns.Count;
                //gvValues.Columns[1].Visible = false;
                //gvValues.Columns[2].Visible = false;
                //gvValues.Columns[3].Visible = false;
                btnSubmit.Text = "تعديل";
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@ValueTypeID", ddlType.SelectedValue);
            cmd.Parameters.AddWithValue("@TitleEN", txtAllowTitleEN.Text);
            cmd.Parameters.AddWithValue("@TitleAR", txtAllowTitleAR.Text);
            cmd.Parameters.AddWithValue("@GlCode", txtGLCode.Text);
            cmd.Parameters.AddWithValue("@IsActive", chbActive.Checked);
            cmd.Parameters.AddWithValue("@IsPercentage", IsPerecantage);
            if (ParentID > 0)
            {
                cmd.CommandText = @"UPDATE ValuesTBL SET ValueTypeID= @ValueTypeID, TitleEN= @TitleEN, TitleAR= @TitleAR, GlCode= @GlCode, IsActive= @IsActive, IsPercentage= @IsPercentage WHERE ValueID=@ID";
                cmd.Parameters.AddWithValue("@ID", ParentID);
                TBIMaster.Execute(cmd, lblMessage);
            }
            else
            {
                cmd.CommandText = @"INSERT INTO ValuesTBL (ValueTypeID, TitleEN, TitleAR, GlCode, IsActive, IsPercentage, ParentID)
                                                   values (@ValueTypeID, @TitleEN, @TitleAR, @GlCode, @IsActive, @IsPercentage, @ParentID);
                                    SELECT SCOPE_IDENTITY()";
                cmd.Parameters.AddWithValue("@ParentID", 0);
                ParentID = Convert.ToInt32(TBIMaster.ExecuteScaler(cmd, lblMessage));
            }
            GetData();
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/Default.aspx");
        }

        protected void gvAllowances_RowEditing(object sender, GridViewEditEventArgs e)
        {
            int index = e.NewEditIndex;

            ValueID = Convert.ToInt32(gvValues.Rows[index].Cells[2].Text);
            SqlCommand cmd = new SqlCommand(@"SELECT [TitleEN]   ,[TitleAR]     ,[Value]    ,[IsActive]     
                                                  FROM [HR].[dbo].[ValuesTBL]
                                                  WHERE [ParentID]=@ID AND [ValueID]= @ValueID");
            cmd.Parameters.AddWithValue("@ID", ParentID);
            cmd.Parameters.AddWithValue("@ValueID", ValueID);
            DataTable dt = TBIMaster.GetData(cmd, lblMessage);
            if (dt.Rows.Count > 0)
            {
                txtValueDescEN.Text = dt.Rows[0][0].ToString();
                txtValueDescAR.Text = dt.Rows[0][1].ToString();
                txtValue.Text = dt.Rows[0][2].ToString();
                chbValueActive.Checked = Convert.ToBoolean(dt.Rows[0][3].ToString());
            }
        }

        protected void rblIsPercentage_SelectedIndexChanged(object sender, EventArgs e)
        {
            IsPerecantage = Convert.ToBoolean(rblIsPercentage.SelectedValue);
        }

    }
}