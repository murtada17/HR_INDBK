
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
       // public static int ParentID = 0, ValueID = 0, ValueTypeID = 0;
        //public static bool IsPerecantage = true;
        public static DataTable dtValues = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               // rblIsPercentage.Items.Add(new ListItem("قطعي", "true"));
               // rblIsPercentage.Items.Add(new ListItem("نسبي", "false"));
                string url = HttpContext.Current.Request.Path;
                string newURL = url.Replace("AllowAdEd", "Allowance");// .Substring(url.LastIndexOf("/")+1);
                if (!MDirMaster.HasPrivilage(newURL, lblMessage))
                {
                    Session["msg"] = "9";
                    Response.Redirect("~/Pages/Default.aspx", false);
                }
                else
                {
                    MDirMaster.FillCombo("ValuesTypeID", "ValuesTypeDescAR", "ValuesTypeTBL", ddlType, true, lblMessage);
                    if (Session["AllowanceID"] != null)
                    {
                        bool IsPerecantage = Convert.ToBoolean(rblIsPercentage.SelectedValue);
                        int ParentID = Convert.ToInt32(Session["AllowanceID"]);
                        hfParentID.Value = ParentID.ToString();
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

        public void GetData()
        {
            SqlCommand cmd = new SqlCommand(@"SELECT [TitleEN]   ,[TitleAR]      ,[GlCode]      ,[IsActive],    [ValueTypeID]      ,[IsPercentage]
                    FROM [HR].[dbo].[ValuesTBL]
                    WHERE [ValueID]=@ID");
            cmd.Parameters.AddWithValue("@ID", hfParentID.Value);
            DataTable dt = MDirMaster.GetData(cmd, lblMessage);
            if (dt.Rows.Count > 0)
            {
                try
                {
                    txtAllowTitleEN.Text = dt.Rows[0][0].ToString();
                    txtAllowTitleAR.Text = dt.Rows[0][1].ToString();
                    txtGLCode.Text = dt.Rows[0][2].ToString();
                    chbActive.Checked = Convert.ToBoolean(dt.Rows[0][3].ToString());
                    ddlType.SelectedValue = dt.Rows[0][4].ToString();
                    hfValueTypeID.Value =dt.Rows[0][4].ToString();
                    rblIsPercentage.SelectedValue = dt.Rows[0]["IsPercentage"].ToString().ToLower();
                }
                catch (Exception ex)
                {
                    lblMessage.Text = ex.Message;
                }
                // get Values 
                SqlCommand cmdValues = new SqlCommand(@"SELECT      ROW_NUMBER() OVER (ORDER BY ValueID) AS [ت],  dbo.ValuesTBL.ValueID, dbo.ValuesTBL.ParentID, dbo.ValuesTBL.ValueTypeID, dbo.ValuesTBL.TitleEN AS [العنوان (انكليزي)], dbo.ValuesTBL.TitleAR AS [العنوان (عربي)],
                         dbo.ValuesTBL.Value AS [المبلغ او النسبة], dbo.ValuesTypeTBL.ValuesTypeDescAR AS [النوع (عربي)], 
                         dbo.ValuesTypeTBL.ValuesTypeDescEN AS [النوع (انكليزي)], dbo.ValuesTBL.IsPercentage AS [نسبة؟], dbo.ValuesTBL.IsActive AS [فعال؟]
                    FROM            dbo.ValuesTBL INNER JOIN
                         dbo.ValuesTypeTBL ON dbo.ValuesTBL.ValueTypeID = dbo.ValuesTypeTBL.ValuesTypeID
                    WHERE        (dbo.ValuesTBL.ParentID = @PID)");
                cmdValues.Parameters.AddWithValue("@PID", hfParentID.Value);
                dtValues = MDirMaster.GetData(cmdValues, lblMessage);
                pnlValues.Enabled = true;
                MDirMaster.AddColumnsToGridView(gvValues, dtValues);
                gvValues.DataSource = dtValues;
                gvValues.DataBind();
                int count = gvValues.Columns.Count;
                gvValues.Columns[1].Visible = false;
                gvValues.Columns[2].Visible = false;
                gvValues.Columns[3].Visible = false;
                btnSubmit.Text = "تعديل";
            }
        }

        protected void gvValues_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            int index = e.NewSelectedIndex;
            GridView gv = sender as GridView;
            int ValueID = Convert.ToInt32(gv.Rows[index].Cells[2].Text);
            hfValueID.Value = ValueID.ToString();
            SqlCommand cmd = new SqlCommand(@"SELECT [TitleEN]   ,[TitleAR]     ,[Value]    ,[IsActive]     
                                                  FROM [HR].[dbo].[ValuesTBL]
                                                  WHERE [ParentID]=@ID AND [ValueID]= @ValueID");
            cmd.Parameters.AddWithValue("@ID", hfParentID.Value);
            cmd.Parameters.AddWithValue("@ValueID", ValueID);
            DataTable dt = MDirMaster.GetData(cmd, lblMessage);
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
           bool IsPerecantage = Convert.ToBoolean(rblIsPercentage.SelectedValue);
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand();
            string Query = "";
            int ValueID = Convert.ToInt32(hfValueID.Value);
            if (ValueID > 0)
            {
                //edit
                Query = @"UPDATE ValuesTBL SET TitleEN= @TitleEN, TitleAR= @TitleAR, Value= @Value, IsActive= @IsActive, ParentID=@ParentID, ValueTypeID= @ValueTypeID, IsPercentage= @IsPercentage
                                    WHERE (ValueID= @ValueID)";
                cmd.Parameters.AddWithValue("ValueID", ValueID);
            }
            else
            {
                //Add
                Query = @"INSERT INTO ValuesTBL (TitleEN, TitleAR, Value, IsActive, ParentID, ValueTypeID, IsPercentage)
                                      VALUES (@TitleEN, @TitleAR, @Value, @IsActive, @ParentID, @ValueTypeID, @IsPercentage)";
            }
            cmd.CommandText = Query;
            cmd.Parameters.AddWithValue("@TitleEN", txtValueDescEN.Text);
            cmd.Parameters.AddWithValue("@TitleAR", txtValueDescAR.Text);
            cmd.Parameters.AddWithValue("@Value", txtValue.Text);
            cmd.Parameters.AddWithValue("@IsActive", chbValueActive.Checked);
            cmd.Parameters.AddWithValue("@ParentID", hfParentID.Value);
            cmd.Parameters.AddWithValue("@ValueTypeID", hfValueTypeID.Value);
            cmd.Parameters.AddWithValue("@IsPercentage", rblIsPercentage.SelectedValue);
            if (MDirMaster.Execute(cmd, lblMessage, HttpContext.Current.Request.Path))
            {
                ValueID = 0;
                string url = HttpContext.Current.Request.Url.ToString();
                Response.Redirect(url, false);
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
            cmd.Parameters.AddWithValue("@IsPercentage", rblIsPercentage.SelectedValue);
            if (Convert.ToInt32(hfParentID.Value) > 0)
            {
                cmd.CommandText = @"UPDATE ValuesTBL SET ValueTypeID= @ValueTypeID, TitleEN= @TitleEN, TitleAR= @TitleAR, GlCode= @GlCode, IsActive= @IsActive, IsPercentage= @IsPercentage WHERE ValueID=@ID";
                cmd.Parameters.AddWithValue("@ID", hfParentID.Value);
                MDirMaster.Execute(cmd, lblMessage, HttpContext.Current.Request.Path);
            }
            else
            {
                cmd.CommandText = @"INSERT INTO ValuesTBL (ValueTypeID, TitleEN, TitleAR, GlCode, IsActive, IsPercentage, ParentID)
                                                   values (@ValueTypeID, @TitleEN, @TitleAR, @GlCode, @IsActive, @IsPercentage, @ParentID);
                                    SELECT SCOPE_IDENTITY()";
                cmd.Parameters.AddWithValue("@ParentID", 0);
                hfParentID.Value= MDirMaster.ExecuteScaler(cmd, lblMessage, HttpContext.Current.Request.Path).ToString();
            }
            GetData();
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/Salaries/Allowance.aspx",false);
        }

        protected void gvValues_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView gv = sender as GridView;
            gv.PageIndex = e.NewPageIndex;
            gv.SelectedIndex = -1;
            MDirMaster.ClearControls(pnlControls);
            GetData();
        }

    }
}