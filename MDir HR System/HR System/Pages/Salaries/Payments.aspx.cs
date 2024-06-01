using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Data.SqlClient;
using System.Web;

namespace HR_Salaries.Pages.Salaries
{
    public partial class Payments : System.Web.UI.Page
    {
        public int Emp_ID = 0, BasicSalary = 0, totalSalary;

        string Path;
        ReportDocument crd = new ReportDocument();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               // rblType_SelectedIndexChanged(null, null);
            }
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (rblType.SelectedIndex > -1)
            {
                bool IsContract = Convert.ToBoolean(rblType.SelectedValue);
                bool result = false;
                SqlCommand cmdCheck = new SqlCommand(@"SELECT count(*)
                                FROM [HR].[dbo].[PayrollTBL]
                                WHERE [Year] = @year and [Month] = @Month and [Reference] = @Reference");
                cmdCheck.Parameters.AddWithValue("@year", txtYear.Text);
                cmdCheck.Parameters.AddWithValue("@Month", ddlMonths.SelectedValue);
                cmdCheck.Parameters.AddWithValue("@Reference", txtReference.Text);
                if (MDirMaster.ExecuteScaler(cmdCheck, lblMessage, HttpContext.Current.Request.Path).ToString() != "0")
                {
                    lblMessage.Text = ".تم الترحيل مسبقا بنفس الزمر والتاريخ";
                    lblMessage.BackColor = System.Drawing.Color.Red;
                    result = true;
                }
                else
                {
                    string Query = @" INSERT INTO [dbo].[PayrollTBL]
                                ([EmpID], [Name], [BasicSalary], [Acctual Basic Salary], [Allowances], [Deductions], [Tax]
                                 ,[Full Salary], [Total Salary], [Year], [Month], [PaymentDate], [IsApproved], [Reference], [IsContract])
                                SELECT [EmpID], [Name], [BasicSalary], [Acctual Basic Salary], [Allowances], [Deductions], [Tax]
			                            ,[Full Salary], [Total Salary], @year, @Month, GETDATE(), 0, @Reference, [IsContract]
                                  FROM [HR].[dbo].[payroll] 
                                 WHERE IsContract = @IsContract;
                              INSERT INTO [dbo].[PayrollDetailsTBL]
                                         ([EmpID],[Name],[LeaveDate],[BasicSalary],[EmployementStartDate],[Allowance],[Descreption],[ParentID],
                              		    [Year],[Month],[PaymentDate],[IsApproved], [Reference], [IsContract])
                                   SELECT [EmpID],[Name],[LeaveDate],[BasicSalary],[EmployementStartDate],[Allowance],[Descreption],[ParentID],
                              			@year, @Month, GETDATE(), 0, @Reference, [IsContract]
                                FROM [HR].[dbo].[PayrollDetailsVW]
                                 WHERE IsContract = @IsContract;";

                    SqlCommand cmd = new SqlCommand(Query);
                    cmd.Parameters.AddWithValue("@year", txtYear.Text);
                    cmd.Parameters.AddWithValue("@Month", ddlMonths.SelectedValue);
                    cmd.Parameters.AddWithValue("@Reference", txtReference.Text);
                    cmd.Parameters.AddWithValue("@IsContract", IsContract);
                    if (MDirMaster.Execute(cmd, lblMessage, HttpContext.Current.Request.Path))
                    {
                        result = true;
                    }
                }
                if (result)
                {
                    cmdCheck.CommandText = @"SELECT sum([BasicSalary]) [مجموع الاسمي]
                                     ,sum([Acctual Basic Salary]) [مجموع الاسمي المدفوع]
                                     ,sum([Allowances]) [مجموع المخصصات]
                                     ,sum([Deductions]) [مجموع الاستقطاعات]
                                     ,sum([Tax]) [مجموع الضريبة]
                                     ,sum([Full Salary]) [المجموع الصافي]
                                     ,sum([Total Salary]) [مجموع المدفوع]
                                     ,[Year] [السنة]
                                     ,[Month] [الشهر]
                                     ,[Reference] [الرمز التعريفي]
                                FROM [HR].[dbo].[PayrollTBL]
                                WHERE [Year] = @year and [Month] = @Month and [Reference] = @Reference
                                GROUP BY [Year], [Month], [Reference]";
                    MDirMaster.FillGrid(cmdCheck, gvPayment, lblMessage);
                }
                else
                {
                    MDirMaster.Messages(lblMessage, "فشل في عملية الترحيل.");
                    lblMessage.BackColor = System.Drawing.Color.Red;
                }
            }
            else
            {
                lblMessage.Text = "يرجى اختيار نوع الترحيل";
            }
        }

        protected void rblType_SelectedIndexChanged(object sender, EventArgs e)
        {

            Path = "~/Reports/ReportSource/rptPayroll.rpt";
            crd.Load(Server.MapPath(Path));
            crd.SetDatabaseLogon("HR", "1HR12IIB18");
            if (rblType.SelectedIndex > -1)
            {
                bool IsContract = Convert.ToBoolean(rblType.SelectedValue);
                crd.RecordSelectionFormula += " AND {payroll.IsContract} = " + IsContract;
            }
            string Orientation = crd.PrintOptions.PaperOrientation.ToString();
            if (Orientation == "Portrait")
            {
                crvReports.Zoom(110);
            }
            else
            {
                crvReports.Zoom(80);
            }
            crvReports.ReportSource = crd;
            crvReports.Visible = true;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {

        }
    }
}