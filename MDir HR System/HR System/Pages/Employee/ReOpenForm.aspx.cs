using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Services;
using System.Windows.Forms;
using System.IO;
using System.Text;
using System.Web.UI.HtmlControls;

namespace HR_Salaries.Pages.Employee
{
    public partial class ReOpenForm : System.Web.UI.Page
    {
        string BranchID = "0";
        string depID = "0";
        string UserID = "0";
        string IsManager = "0";
        string IsCEO = "0";
        string IsCEOAssist = "0";
        string EmpID = "0";

        protected void Page_Load(object sender, EventArgs e)
        {
              if (!IsPostBack)
            {

                string url = HttpContext.Current.Request.Path;
                if (!TBIMaster.HasPrivilage(url, lblMessage))
                {
                    Session["msg"] = "9";
                    Response.Redirect("~/Pages/Default.aspx");
                }
                else
                {

                    TBIMaster.FillCombo("EmpID", "FullName", "EmpCurrentLocationVW", ddlRateManager, "IsManager = 1 or IsCEO=1 or IsCEOAssist=1", lblMessage);
                    TBIMaster.FillCombo("RateTypeID", "RateType", "RateTypeTBL", ddlRateType, lblMessage);
                    TBIMaster.FillCombo("RateTypeID", "RateType", "RateTypeTBL", ddlRateOpen, lblMessage);
                   
                 
                }


            }
            lblMessage.Text = "";
        }


        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                //BranchID = Session["BranchID"].ToString();
                //depID = Session["depID"].ToString();
                //UserID = Session["UserID"].ToString();
                //IsManager = Session["IsManager"].ToString();
                //IsCEO = Session["IsCEO"].ToString();
                //IsCEOAssist = Session["IsCEOAssist"].ToString();
                //EmpID = Session["EmpID"].ToString();
            }
            catch
            {
                TBIMaster.Messages(lblMessage, 0);
                return;
            }
            if ((ddlRateType.SelectedValue == "0") || (ddlRateManager.SelectedValue == "0"))
            {
                lblMessage.Text = "يرجى اختيار نوع التقييم واسم المدير.";
            }
            else if (ddlRateType.SelectedValue == "1")
            {
                SqlCommand cmd = new SqlCommand(@"select userID from UsersVW where EmpID = @EmpID and ApplicationID=1");
                cmd.Parameters.AddWithValue("@EmpID", ddlRateManager.SelectedValue);
                DataTable dt1 = new DataTable();

                dt1 = TBIMaster.GetData(cmd, lblMessage);
                if (dt1.Rows.Count <= 0)
                {
                    lblMessage.Text = "يرجى تحديد المدير مرة اخرى";
                }
                else
                {
                    SqlCommand cmdCheck = new SqlCommand(@"update [HR].[dbo].[RatingDone] set isRating = 0 where submitUser = @UserID and submitDate >= GETDATE() - 8");
                    cmdCheck.Parameters.AddWithValue("@UserID", dt1.Rows[0]["userID"]);

                    DataTable dt = new DataTable();

                    dt = TBIMaster.GetData(cmdCheck, lblMessage);


                    bool rating = TBIMaster.Execute(cmdCheck, lblMessage, HttpContext.Current.Request.Path);
                    if (rating)
                    {
                        TBIMaster.Messages(lblMessage, 1);
                    }
                    else
                    {

                        lblMessage.Text = "لم يتم ارسال التقييمات من قبل هذا الفرع/القسم.";
                    }
                }
            }
            else if (ddlRateType.SelectedValue == "2")
            {
                SqlCommand cmd = new SqlCommand(@"select userID from UsersVW where EmpID = @EmpID and ApplicationID=1");
                cmd.Parameters.AddWithValue("@EmpID", ddlRateManager.SelectedValue);
                DataTable dt1 = new DataTable();

                dt1 = TBIMaster.GetData(cmd, lblMessage);
                if (dt1.Rows.Count <= 0)
                {
                    lblMessage.Text = "يرجى تحديد المدير مرة اخرى";
                }
                else
                {
                    SqlCommand cmdCheck = new SqlCommand(@"update [HR].[dbo].[RatingDone] set is16Rating = 0 where submitUser = @UserID and submitDate >= GETDATE() - 8");
                    cmdCheck.Parameters.AddWithValue("@UserID", dt1.Rows[0]["userID"]);

                    DataTable dt = new DataTable();

                    dt = TBIMaster.GetData(cmdCheck, lblMessage);


                    bool rating = TBIMaster.Execute(cmdCheck, lblMessage, HttpContext.Current.Request.Path);
                    if (rating)
                    {
                        TBIMaster.Messages(lblMessage, 1);
                    }
                    else
                    {

                        lblMessage.Text = "لم يتم ارسال التقييمات من قبل هذا الفرع/القسم.";
                    }
                }
            }
        }

        protected void BtnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/Employee/ReOpenForm.aspx");
        }

        protected void Open_Click(object sender, EventArgs e)
        {
            if (ddlRateOpen.SelectedValue == "0")
            {
                lblMessage.Text = "يرجى اختيار نوع التقييم.";
            }
             else if (ddlRateOpen.SelectedValue == "1")
             {
                 SqlCommand cmd5 = new SqlCommand();
                 cmd5.CommandText = @"update [HR].[dbo].[EmployeeRatingTempTBL] 
                                    set PageOpen=1 where IsManager = 1 or IsCEO=1 or IsCEOAssist=1";

                 bool PageOpen = TBIMaster.Execute(cmd5, lblMessage, HttpContext.Current.Request.Path);
                 if (PageOpen)
                 {
                     TBIMaster.Messages(lblMessage, 1);
                 }
                 else
                 {
                     TBIMaster.Messages(lblMessage, 14);
                 }
             }
             else if (ddlRateOpen.SelectedValue == "2")
             {
                 SqlCommand cmd5 = new SqlCommand();
                 cmd5.CommandText = @"update [HR].[dbo].[EmployeeRatingTempTBL] 
                                    set Page16Open=1 where IsManager = 1 or IsCEO=1 or IsCEOAssist=1";

                 bool Page16Open = TBIMaster.Execute(cmd5, lblMessage, HttpContext.Current.Request.Path);
                 if (Page16Open)
                 {
                     TBIMaster.Messages(lblMessage, 1);
                 }
                 else
                 {
                     TBIMaster.Messages(lblMessage, 14);
                 }
             }
        }

        protected void close_Click(object sender, EventArgs e)
        {
            if (ddlRateOpen.SelectedValue == "0")
            {
                lblMessage.Text = "يرجى اختيار نوع التقييم.";
            }
            else if (ddlRateOpen.SelectedValue == "1")
            {
                SqlCommand cmd5 = new SqlCommand();
                cmd5.CommandText = @"update [HR].[dbo].[EmployeeRatingTempTBL] 
                                    set PageOpen=0 where IsManager = 1 or IsCEO=1 or IsCEOAssist=1";

                bool PageOpen = TBIMaster.Execute(cmd5, lblMessage, HttpContext.Current.Request.Path);
                if (PageOpen)
                {
                    TBIMaster.Messages(lblMessage, 1);
                }
                else
                {
                    TBIMaster.Messages(lblMessage, 14);
                }
            }
            else if (ddlRateOpen.SelectedValue == "2")
            {
                SqlCommand cmd5 = new SqlCommand();
                cmd5.CommandText = @"update [HR].[dbo].[EmployeeRatingTempTBL] 
                                    set Page16Open=0 where IsManager = 1 or IsCEO=1 or IsCEOAssist=1";

                bool Page16Open = TBIMaster.Execute(cmd5, lblMessage, HttpContext.Current.Request.Path);
                if (Page16Open)
                {
                    TBIMaster.Messages(lblMessage, 1);
                }
                else
                {
                    TBIMaster.Messages(lblMessage, 14);
                }
            }
        }
    }
}