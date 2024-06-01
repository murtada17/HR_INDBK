using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace HR_Salaries.Pages.Vacancies
{
    public partial class VacanciesTypes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                string url = HttpContext.Current.Request.Path;
                if (!MDirMaster.HasPrivilage(url, lblMessage))
                {
                    Session["msg"] = "9";
                    Response.Redirect("~/Pages/Default.aspx");
                }
                else
                {
                    GetData();
                }
            }
        }

        public void GetData()
        {

            SqlCommand cmdValues = new SqlCommand(@"SELECT [VicationTypeID], [VicationDesc] AS [العنوان], [WithSalary] AS [اجازة برصيد؟], [FullSalary] AS [براتب تام؟], [IsActive] AS [فعال؟]
                                                        FROM [HR].[dbo].[VicationTypesTBL]");
            DataTable dtValues = MDirMaster.GetData(cmdValues, lblMessage);
            MDirMaster.AddColumnsToGridView(gvValues, dtValues);
            gvValues.DataSource = dtValues;
            gvValues.DataBind();
            //int count = gvValues.Columns.Count;
            gvValues.Columns[0].Visible = false;
            //btnSubmit.Text = "تعديل";
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            int type = Convert.ToInt16(ddlType.SelectedValue);
            if (type != 0)
            {
                string Query = @"INSERT INTO VicationTypesTBL (VicationDesc, WithSalary, FullSalary, IsActive)
                                                    VALUES   (@VicationDesc, @WithSalary, @FullSalary, @IsActive)";
                SqlCommand cmd = new SqlCommand(Query);
                cmd.Parameters.AddWithValue("@VicationDesc", txtDesc.Text);
                cmd.Parameters.AddWithValue("@IsActive", chbIsActive.Checked);
                switch (type)
                {
                    case 1:
                        cmd.Parameters.AddWithValue("@WithSalary", 1);
                        cmd.Parameters.AddWithValue("@FullSalary", 1);
                        break;
                    case 2:
                        cmd.Parameters.AddWithValue("@WithSalary", 1);
                        cmd.Parameters.AddWithValue("@FullSalary", 0);

                        break;
                    case 3:
                        cmd.Parameters.AddWithValue("@WithSalary", 0);
                        cmd.Parameters.AddWithValue("@FullSalary", 0);

                        break;
                }
                if (MDirMaster.Execute(cmd, lblMessage, HttpContext.Current.Request.Path))
                {
                    Session["msg"] = 1;
                    Response.Redirect("~/Pages/Default.aspx");
                }
            }
            else
            {
                lblMessage.Text = "الرجاء اختيار النوع";
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/Default.aspx");
        }

        protected void gvValues_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}