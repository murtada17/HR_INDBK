using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web;
using System.Web.Hosting;
using System.Web.Services;

namespace HR_Salaries.Reports
{
    public partial class ReportsRPT : System.Web.UI.Page
    {
        ReportDocument crd = new ReportDocument();
        string Path;
        public string FileExtention = null;
        public string FileName = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            lblMessage.Text = "";
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
                    SqlCommand cmd = new SqlCommand(@"SELECT '0' AS [ID], N' يرجى الأختيار' AS [VALUE] UNION SELECT [ID], [VALUE] 
                                                      FROM (SELECT TOP (100) PERCENT dbo.ReportsTBL.ReportSource AS ID, dbo.ReportsTBL.Name AS Value
                                                            FROM         dbo.UserReportsTBL INNER JOIN
                                                                         dbo.ReportsTBL ON dbo.UserReportsTBL.ReportID = dbo.ReportsTBL.ReportID
                                                            WHERE        (dbo.UserReportsTBL.UserID = @UserID) AND (dbo.ReportsTBL.IsActive = 1) AND (dbo.ReportsTBL.ReportType = '.rpt')AND (dbo.ReportsTBL.ApplicationID = @ApplicationID ) ) AS Foo ORDER BY VALUE ASC ");
                    cmd.Parameters.AddWithValue("@UserID", HttpContext.Current.Session["UserID"].ToString());
                    cmd.Parameters.AddWithValue("@ApplicationID", MDirMaster.ApplicationID);
                    DataTable dtReports = MDirMaster.GetData(cmd, lblMessage);
                    MDirMaster.Pop(dtReports, ddlReport);
                    MDirMaster.FillCombo("BranchID", "BranchDescAR", "BranchsTBL", ddlSBranch, true, lblMessage);

                    MDirMaster.FillCombo("DepartmentID", "DepartmentDescAR", "DepartmentTBL", ddlSDep, true, lblMessage);
                    MDirMaster.FillCombo("BranchID", "BranchDescAR", "BranchsTBL", ddlOtherBranch, true, lblMessage);
                    MDirMaster.FillCombo("DepartmentID", "DepartmentDescAR", "DepartmentTBL", ddlOtherDep, true, lblMessage);
                    MDirMaster.FillCombo("GenderID", "GenderDescEN", "GendersTBL", ddlGender, true, lblMessage);
                    MDirMaster.FillCombo("SectionID", "SectionDescAR", "SectionTBL", ddlSection, true, lblMessage);
                    MDirMaster.FillCombo("ResonID", "ResonDescAR", "ResignResonsTBL", ddlResignReason, true, lblMessage);
                    MDirMaster.FillCombo("VicationTypeID", "VicationDesc", "VicationTypesTBL", ddlVacationType, lblMessage);
                    MDirMaster.FillCombo("LicenseDegID", "LicenseDegDescAR", "LicenseDegTBL", ddlLicenseDigree, true, lblMessage);
                    MDirMaster.FillCombo("LicenseNameID", "LicenseNameAR", "LicenseNameTBL", ddlLicenseName, true, lblMessage);
                    MDirMaster.FillCombo("TypeID", "TypeDescAR", "AdminOrdersTypesTBL", ddlOrderType, true, lblMessage);
                    //if (Convert.ToBoolean(Session["BranchID"]))
                    //{
                    //    if (Session["BranchID"].ToString() == "1")
                    //    {

                    //    }
                    //    else
                    //    {
                    //        ddlSBranch.SelectedValue = Session["BranchID"].ToString();
                    //        ddlSBranch.Enabled = false;
                    //    }
                    //}
                    //else
                    //{
                    //    Response.Redirect("~/User/Login.aspx", false);
                    //}
                    ddlReport_SelectedIndexChanged(sender, e);
                    if (Session["depID"].ToString() == "9")
                    {
                        ddlFormat.Visible = false;
                    }

                }
            }
        }

        public string condition(string SFormula)
        {
            string Condition = SFormula;
            bool check = false;
            if (!string.IsNullOrEmpty(Condition))
            {
                check = true;
            }
            if (Convert.ToInt32(ddlSBranch.SelectedValue) > 0)
            {
                if (check)
                {
                    Condition += " AND ";
                }
                Condition += " {@BranchID} = " + ddlSBranch.SelectedValue;
                check = true;
            }
            if (Convert.ToInt32(ddlSDep.SelectedValue) > 0)
            {
                if (check)
                {
                    Condition += " AND ";
                }
                Condition += " {@DepartmentID} = " + ddlSDep.SelectedValue;
                check = true;
            }
            if (Convert.ToInt32(ddlOtherBranch.SelectedValue) > 0)
            {
                if (check)
                {
                    Condition += " AND ";
                }
                Condition += " {@OtherBranchID} = " + ddlOtherBranch.SelectedValue;
                check = true;
            }
            if (Convert.ToInt32(ddlOtherDep.SelectedValue) > 0)
            {
                if (check)
                {
                    Condition += " AND ";
                }
                Condition += " {@OtherDepID} = " + ddlOtherDep.SelectedValue;
                check = true;
            }
            if (Convert.ToInt32(ddlSection.SelectedValue) > 0)
            {
                if (check)
                {
                    Condition += " AND ";
                }
                Condition += " {@SectionID} = " + ddlSection.SelectedValue;
                check = true;
            }
            if (Convert.ToInt32(ddlGender.SelectedValue) > 0)
            {
                if (check)
                {
                    Condition += " AND ";
                }
                Condition += " {@GenderID} = " + ddlGender.SelectedValue;
                check = true;
            }
            if (Convert.ToInt32(ddlVacationType.SelectedValue) > 0)
            {
                if (check)
                {
                    Condition += " AND ";
                }
                Condition += " {@VacationTypeID} = " + ddlVacationType.SelectedValue;
                check = true;
            }
            if (Convert.ToInt32(ddlLicenseDigree.SelectedValue) > 0)
            {
                if (check)
                {
                    Condition += " AND ";
                }
                Condition += " {@LicenseDigreeID} = " + ddlLicenseDigree.SelectedValue;
                check = true;
            }
            if (Convert.ToInt32(ddlLicenseName.SelectedValue) > 0)
            {
                if (check)
                {
                    Condition += " AND ";
                }
                Condition += " {@LicenseNameID} = " + ddlLicenseName.SelectedValue;
                check = true;
            }
            if (Convert.ToInt32(ddlOrderType.SelectedValue) > 0)
            {
                if (check)
                {
                    Condition += " AND ";
                }
                Condition += " {@OrderTypeID} = " + ddlOrderType.SelectedValue;
                check = true;
            }
            if (Convert.ToInt32(ddlResignReason.SelectedValue) > 0)
            {
                if (check)
                {
                    Condition += " AND ";
                }
                Condition += " {@ResignReasonID} = " + ddlResignReason.SelectedValue;
                check = true;
            }
            string nameAR = txtFNameARS.Text.ToString();
            if (!string.IsNullOrEmpty(nameAR))
            {
                if (check)
                {
                    Condition += " AND ";
                }
                Condition += " {@nameAR} like '" + nameAR + "*'";
                check = true;
            }
            string nameEN = txtFNameENS.Text.ToString();
            if (!string.IsNullOrEmpty(nameEN))
            {
                if (check)
                {
                    Condition += " AND ";
                }
                Condition += " {@nameEN} like '" + nameEN + "*'";
                check = true;
            }
            string JoinDateFrom = txtJoinDateFrom.Text.ToString();
            if (!string.IsNullOrEmpty(JoinDateFrom))
            {
                if (check)
                {
                    Condition += " AND ";
                }
                Condition += " {@JoinDate} >= CDATE('" + JoinDateFrom + "')";
                check = true;
            }
            string JoinDateTo = txtJoinDateTo.Text.ToString();
            if (!string.IsNullOrEmpty(JoinDateTo))
            {
                if (check)
                {
                    Condition += " AND ";
                }
                Condition += " {@JoinDate} <= CDATE('" + JoinDateTo + "')";
                check = true;
            }
            string BirthDateFrom = txMDirrthDateFrom.Text.ToString();
            if (!string.IsNullOrEmpty(BirthDateFrom))
            {
                if (check)
                {
                    Condition += " AND ";
                }
                Condition += " {@BirthDate} >= CDATE('" + BirthDateFrom + "')";
                check = true;
            }
            string BirthDateTo = txMDirrthDateTo.Text.ToString();
            if (!string.IsNullOrEmpty(BirthDateTo))
            {
                if (check)
                {
                    Condition += " AND ";
                }
                Condition += " {@BirthDate} <= CDATE('" + BirthDateTo + "')";
                check = true;
            }
            string EndDate = txtEndDate.Text.ToString();
            if (!string.IsNullOrEmpty(EndDate))
            {
                if ((EndDate == "انفكاك") || (EndDate == "أنفكاك"))
                {
                    if (check)
                    {
                        Condition += " AND ";
                    }
                    Condition += "{@Note} LIKE '*انفكاك*' OR {@Note} LIKE '*أنفكاك*' ";
                    check = true;
                }
                else
                {
                    if (check)
                    {
                        Condition += " AND ";
                    }
                    Condition += " {@EndDate} <= CDATE('" + EndDate + "')";
                    check = true;
                }
            }
            string StartDate = txtStartDate.Text.ToString();
            if (!string.IsNullOrEmpty(StartDate))
            {
                if ((StartDate == "انفكاك") || (StartDate == "أنفكاك"))
                {
                    if (check)
                    {
                        Condition += " AND ";
                    }
                    Condition += "{@Note} LIKE '*انفكاك*' OR {@Note} LIKE '*أنفكاك*' ";
                    check = true;
                }
                else
                {
                    if (check)
                    {
                        Condition += " AND ";
                    }
                    Condition += " {@StartDate} >= CDATE('" + StartDate + "')";
                    check = true;
                }
            }
            string EmployeementStartDateFrom = txtEmployeementStartDateFrom.Text.ToString();
            if (!string.IsNullOrEmpty(EmployeementStartDateFrom))
            {
                if (check)
                {
                    Condition += " AND ";
                }
                Condition += " {@EmployeementStartDate} >= CDATE('" + EmployeementStartDateFrom + "')";
                check = true;
            }
            string EmployeementStartDateTo = txtEmployeementStartDateTo.Text.ToString();
            if (!string.IsNullOrEmpty(EmployeementStartDateTo))
            {
                if (check)
                {
                    Condition += " AND ";
                }
                Condition += " {@EmployeementStartDate} <= CDATE('" + EmployeementStartDateTo + "')";
                check = true;
            }
            string OrderDateFrom = txtOrderDateFrom.Text.ToString();
            if (!string.IsNullOrEmpty(OrderDateFrom))
            {
                if (check)
                {
                    Condition += " AND ";
                }
                Condition += " {@OrderDate} >= CDATE('" + OrderDateFrom + "')";
                check = true;
            }
            string OrderDateTo = txtOrderDateTo.Text.ToString();
            if (!string.IsNullOrEmpty(OrderDateTo))
            {
                if (check)
                {
                    Condition += " AND ";
                }
                Condition += " {@OrderDate} <= CDATE('" + OrderDateTo + "')";
                check = true;
            }
            string IDNo = txtID_No.Text.ToString();
            if (!string.IsNullOrEmpty(IDNo))
            {
                if (check)
                {
                    Condition += " AND ";
                }
                Condition += " {@ID_No} = " + IDNo;
                check = true;
            }
            if (rblEmployees.SelectedIndex > -1)
            {
                if (check)
                {
                    Condition += " AND ";
                }
                Condition += " {@Employee} = " + rblEmployees.SelectedValue;
                check = true;
            }
            string LeaveDateFrom = txtLeaveDateFrom.Text.ToString();
            string LeaveDateTo = txtLeaveDateTo.Text.ToString();
            bool skipLeave = false;
            if (!string.IsNullOrEmpty(LeaveDateFrom))
            {
                if ((LeaveDateFrom == "مستمر"))
                {
                    if (check)
                    {
                        Condition += " AND ";
                    }
                    if (!string.IsNullOrEmpty(LeaveDateTo))
                    {
                        Condition += " IsNull({@LeaveDate}) ";
                        skipLeave = true;
                    }
                    else
                    {
                        Condition += " IsNull({@LeaveDate}) ";
                    }
                    check = true;
                }
                else
                {
                    if (check)
                    {
                        Condition += " AND ";
                    }
                    Condition += " {@LeaveDate} >= CDATE('" + LeaveDateFrom + "')";
                    check = true;
                }
            }
            if (!skipLeave)
            {
                if (!string.IsNullOrEmpty(LeaveDateTo))
                {
                    if ((LeaveDateTo == "مستمر"))
                    {
                        if (check)
                        {
                            Condition += " AND ";
                        }
                        Condition += " IsNull({@LeaveDate}) ";
                        check = true;
                    }
                    else
                    {
                        if (check)
                        {
                            Condition += " AND ";
                        }
                        Condition += " {@LeaveDate} <= CDATE('" + LeaveDateTo + "')";
                        check = true;
                    }
                }
            }
            else
            {
            }
            return Condition;
        }

        protected void ddlSBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            //crd.RecordSelectionFormula = condition();
        }

        protected void CrystalReportViewer1_Unload(object sender, EventArgs e)
        {
            crd.Close();
            crd.Dispose();
        }

        protected void CrystalReportViewer1_Load(object sender, EventArgs e)
        {
        }

        protected void ddlReport_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlOrderType.SelectedValue = "0";
            ddlLicenseDigree.SelectedValue = "0";
            ddlLicenseName.SelectedValue = "0";
            ddlSBranch.SelectedValue = "0";
            ddlSDep.SelectedValue = "0";
            ddlOtherBranch.SelectedValue = "0";
            ddlOtherDep.SelectedValue = "0";
            ddlSection.SelectedValue = "0";
            ddlResignReason.SelectedValue = "0";
            ddlVacationType.SelectedValue = "0";
            ddlGender.SelectedValue = "0";

            txMDirrthDateFrom.Text = string.Empty;
            txMDirrthDateTo.Text = string.Empty;
            txtEmployeementStartDateFrom.Text = string.Empty;
            txtEmployeementStartDateTo.Text = string.Empty;
            txtEndDate.Text = string.Empty;
            txtFNameARS.Text = string.Empty;
            txtFNameENS.Text = string.Empty;
            txtJoinDateFrom.Text = string.Empty;
            txtJoinDateTo.Text = string.Empty;
            txtLeaveDateFrom.Text = string.Empty;
            txtLeaveDateTo.Text = string.Empty;
            txtStartDate.Text = string.Empty;
            txtOrderDateFrom.Text = string.Empty;
            txtOrderDateTo.Text = string.Empty;
            txtID_No.Text = string.Empty;
            rblEmployees.SelectedIndex = -1;

            ddlOrderType.Enabled = false;
            ddlLicenseDigree.Enabled = false;
            ddlLicenseName.Enabled = false;
            ddlSBranch.Enabled = false;
            ddlSDep.Enabled = false;
            ddlOtherBranch.Enabled = false;
            ddlOtherDep.Enabled = false;
            ddlSection.Enabled = false;
            ddlResignReason.Enabled = false;
            ddlVacationType.Enabled = false;
            ddlGender.Enabled = false;

            pnlBirthDate.Enabled = false;
            pnlEmployeementStartDate.Enabled = false;
            txtEndDate.Enabled = false;
            txtFNameARS.Enabled = false;
            txtFNameENS.Enabled = false;
            pnlJoinDate.Enabled = false;
            pnlLeaveDate.Enabled = false;
            txtStartDate.Enabled = false;
            pnlOrderDate.Enabled = false;
            pnlIDNo.Enabled = false;
            pnlEmployee.Enabled = false;

            if (ddlReport.SelectedValue == "0")
            {

            }
            else
            {
                Path = "~/Reports/ReportSource/" + ddlReport.SelectedValue;
                if (ddlReport.SelectedValue == "rptAttenSkip.rpt")
                {
                    crd.SetParameterValue("@date", DateTime.Now);
                }
                crd.Load(Server.MapPath(Path));
                crd.SetDatabaseLogon("HR", "12qw!@QW");
                int count = crd.DataDefinition.FormulaFields.Count;
                string[] formula = new string[count];
                for (int i = 0; i < count; i++)
                {
                    formula[i] = crd.DataDefinition.FormulaFields[i].Name.ToLower();
                    switch (formula[i])
                    {
                        case "branchid":
                            ddlSBranch.Enabled = true;
                            break;
                        case "otherbranchid":
                            ddlOtherBranch.Enabled = true;
                            break;
                        case "sectionid":
                            ddlSection.Enabled = true;
                            break;
                        case "resignreasonid":
                            ddlResignReason.Enabled = true;
                            break;
                        case "vacationtypeid":
                            ddlVacationType.Enabled = true;
                            break;
                        case "genderid":
                            ddlGender.Enabled = true;
                            break;
                        case "departmentid":
                            ddlSDep.Enabled = true;
                            break;
                        case "otherdepid":
                            ddlOtherDep.Enabled = true;
                            break;
                        case "licensedigreeid":
                            ddlLicenseDigree.Enabled = true;
                            break;
                        case "licensenameid":
                            ddlLicenseName.Enabled = true;
                            break;
                        case "ordertypeid":
                            ddlOrderType.Enabled = true;
                            break;
                        case "namear":
                            txtFNameARS.Enabled = true;
                            break;
                        case "nameen":
                            txtFNameENS.Enabled = true;
                            break;
                        case "joindate":
                            pnlJoinDate.Enabled = true;
                            break;
                        case "birthdate":
                            pnlBirthDate.Enabled = true;
                            break;
                        case "enddate":
                            txtEndDate.Enabled = true;
                            break;
                        case "startdate":
                            txtStartDate.Enabled = true;
                            break;
                        case "employeementstartdate":
                            pnlEmployeementStartDate.Enabled = true;
                            break;
                        case "leavedate":
                            pnlLeaveDate.Enabled = true;
                            break;
                        case "orderdate":
                            pnlOrderDate.Enabled = true;
                            break;
                        case "id_no":
                            pnlIDNo.Enabled = true;
                            break;
                        case "employee":
                            pnlEmployee.Enabled = true;
                            break;
                        default:
                            break;
                    }
                }
            }
            crvReports.Visible = false;
        }

        protected void btnGenrate_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(ddlReport.SelectedIndex) < 1)
            {
                crvReports.Visible = false;
                return;
            }
            else
            {
                Path = "~/Reports/ReportSource/" + ddlReport.SelectedValue;
                if (ddlReport.SelectedValue == "rptAttenSkip.rpt")
                {
                    string Date;
                    if (!string.IsNullOrEmpty(txtOrderDateFrom.Text))
                    {
                        Date = txtOrderDateFrom.Text;
                    }
                    else if (!string.IsNullOrEmpty(txtOrderDateTo.Text))
                    {
                        Date = txtOrderDateTo.Text;
                    }
                    else
                    {
                        Date = DateTime.Now.ToString();
                        lblMessage.Text = "التقرير ادناه لتاريخ اليوم";
                    }
                    crd.SetParameterValue("@date", Convert.ToInt32(Date));

                }
                crd.Load(Server.MapPath(Path));
                if (ddlReport.SelectedValue == "CrystalReport1.rpt")
                {
                    if (Session["depID"].ToString() == "9")
                    {
                        crd.SetParameterValue("USerGET", Session["FullName"].ToString() + "_" + Session["DepartmentDescAR"].ToString());
                        crd.SetParameterValue("TrueImage", "True");
                    }

                    else
                    {
                        crd.SetParameterValue("USerGET", "_");
                        crd.SetParameterValue("TrueImage", "Fals");
                    }
                    if (rblEmployees.SelectedValue == "true" || rblEmployees.SelectedValue == "false")
                    {
                        crd.SetParameterValue("ConOREmp", rblEmployees.SelectedItem.ToString());
                    }
                    else
                    {
                        crd.SetParameterValue("ConOREmp", "ملاك و عقود");
                    }
                }
               
                
                //crd.SetDatabaseLogon("HR", "12qw!@QW");
                crd.SetDatabaseLogon("HR", "1HR12IIB18");
                crd.RecordSelectionFormula = condition(crd.RecordSelectionFormula.ToString());


                //crd.Refresh();
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
                //crvReports.RefreshReport();
                crvReports.Visible = true;
            }
        }

        protected void btnPrint_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(ddlReport.SelectedIndex) < 1)
            {
                crvReports.Visible = false;
                return;
            }
            else
            {
                try
                {
                    btnGenrate_Click(sender, e);
                    FileName = Session["UserID"].ToString() + ddlSBranch.SelectedValue + DateTime.Now.Ticks + ".pdf";
                    ExportOptions CrExportOptions;
                    DiskFileDestinationOptions CrDiskFileDestinationOptions = new DiskFileDestinationOptions();
                    CrExportOptions = crd.ExportOptions;
                    CrExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                    CrExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                    CrDiskFileDestinationOptions.DiskFileName = Server.MapPath("~/Reports/ExportFiles/" + FileName);
                    CrExportOptions.DestinationOptions = CrDiskFileDestinationOptions;
                    crd.Export();
                    lblMessage.Text = null;

                    iFramePdf.Attributes["src"] = "ExportFiles/" + FileName;  // File Path starting from the page dir(where the exprted file is at), [FileName] is the filename with the extention
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "myScript", "printTrigger(name= '" + FileName + "');", true);

                }
                catch (Exception ex)
                {
                    MDirMaster ob = new MDirMaster();
                    lblMessage.Text = ex.Message;
                }
            }



        }

        protected void btnExport_Click(object sender, EventArgs e)
        {

            if (Convert.ToInt32(ddlReport.SelectedIndex) < 1)
            {
                crvReports.Visible = false;
                return;
            }
            else
            {
                try
                {
                    btnGenrate_Click(sender, e);
                    DateTime datetime = DateTime.Now;
                    int Index = ddlReport.SelectedValue.IndexOf('.');
                    FileName = ddlReport.SelectedValue.Substring(0, Index) + "_at(" + datetime.Year + "-" + datetime.Month + "-" + datetime.Day + ")";
                    ExportOptions CrExportOptions;
                    DiskFileDestinationOptions CrDiskFileDestinationOptions = new DiskFileDestinationOptions();
                    CrExportOptions = crd.ExportOptions;
                    CrExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                    int format = Convert.ToInt32(ddlFormat.SelectedItem.Value);
                    switch (format)
                    {
                        case 0:
                        case 1://"Adobe PDF":
                            CrExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                            FileExtention = ".pdf";
                            break;
                        case 2://"Microsoft Excel":
                            CrExportOptions.ExportFormatType = ExportFormatType.Excel;
                            FileExtention = ".xls";
                            break;
                        case 3://"Microsoft Excel (Data Only)":
                            CrExportOptions.ExportFormatType = ExportFormatType.ExcelRecord;
                            FileExtention = ".xls";
                            break;
                        case 4://"Rich Text File":
                            CrExportOptions.ExportFormatType = ExportFormatType.RichText;
                            FileExtention = ".rtf";
                            break;
                        case 5://"Seperated Values":
                            break;
                    }
                    CrDiskFileDestinationOptions.DiskFileName = Server.MapPath("~/Reports/ExportFiles/" + FileName + FileExtention);
                    CrExportOptions.DestinationOptions = CrDiskFileDestinationOptions;
                    crd.Export();
                    lblMessage.Text = null;
                    System.IO.FileStream fs = null;
                    fs = System.IO.File.Open(CrDiskFileDestinationOptions.DiskFileName, System.IO.FileMode.Open);
                    byte[] btFile = new byte[fs.Length];
                    fs.Read(btFile, 0, Convert.ToInt32(fs.Length));
                    fs.Close();
                    fs = null;
                    System.IO.File.Delete(CrDiskFileDestinationOptions.DiskFileName);
                    Response.AddHeader("Content-disposition", "attachment; filename=" + FileName + FileExtention);
                    Response.ContentType = "application/octet-stream";
                    Response.BinaryWrite(btFile);
                    Response.End();
                }
                catch (Exception ex)
                {
                    MDirMaster ob = new MDirMaster();
                    lblMessage.Text = ex.Message;
                }
            }
        }



        [WebMethod]
        public static void OnConfirm(string name)
        {
            System.IO.File.Delete(HostingEnvironment.MapPath("~/Reports/ExportFiles/" + name));
        }
    }
}