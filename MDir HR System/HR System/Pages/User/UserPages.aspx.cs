using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace HR_Salaries.Pages.User
{
    public partial class UserPages : System.Web.UI.Page
    {
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
                    if(!MDirMaster.IsAdmin(lblMessage, "UserPages"))
                    {
                        btnSubmit.Enabled = false;
                    }
                    string UserID = Request.QueryString["UID"];
                    MDirMaster.Pop(MDirMaster.GetData(new SqlCommand(@"SELECT '0' AS [ID], N' يرجى الأختيار' AS [VALUE] UNION SELECT [ID], [VALUE]
                                                                FROM (SELECT TOP (100) PERCENT dbo.UsersTBL.UserID AS [ID],EmployeesTBL.FirstNameAR + ' ' + EmployeesTBL.MidNameAR + ' '+ EmployeesTBL.LastNameAR + ' - ' +  dbo.UsersTBL.UserName AS [VALUE]
                                                                      FROM            dbo.UsersTBL INNER JOIN
                                                                            dbo.UserPrivilegesTBL ON dbo.UsersTBL.UserID = dbo.UserPrivilegesTBL.UserID
																			INNER JOIN dbo.EmployeesTBL ON EmployeesTBL.EmpID = UsersTBL.EmpID
                                                                      WHERE        (dbo.UserPrivilegesTBL.ApplicationID = " + MDirMaster.ApplicationID + @"))
                                                                AS Foo ORDER BY VALUE ASC"), lblMessage), ddlUserName);
                    GetList();
                    ddlUserName.SelectedValue = UserID;
                    ddlUserName_SelectedIndexChanged(sender, e);
                }
            }
            //System.Web.HttpBrowserCapabilities browser = Request.Browser;
            //string s = "Browser Capabilities\n"
            //    + "Type = " + browser.Type + "\n"
            //    + "Name = " + browser.Browser + "\n"
            //    + "Version = " + browser.Version + "\n"
            //    + "Major Version = " + browser.MajorVersion + "\n"
            //    + "Minor Version = " + browser.MinorVersion + "\n"
            //    + "Platform = " + browser.Platform + "\n"
            //    + "Is Beta = " + browser.Beta + "\n"
            //    + "Is Crawler = " + browser.Crawler + "\n"
            //    + "Is AOL = " + browser.AOL + "\n"
            //    + "Is Win16 = " + browser.Win16 + "\n"
            //    + "Is Win32 = " + browser.Win32 + "\n"
            //    + "Supports Frames = " + browser.Frames + "\n"
            //    + "Supports Tables = " + browser.Tables + "\n"
            //    + "Supports Cookies = " + browser.Cookies + "\n"
            //    + "Supports VBScript = " + browser.VBScript + "\n"
            //    + "Supports JavaScript = " +
            //        browser.EcmaScriptVersion.ToString() + "\n"
            //    + "Supports Java Applets = " + browser.JavaApplets + "\n"
            //    + "Supports ActiveX Controls = " + browser.ActiveXControls
            //          + "\n"
            //    + "Supports JavaScript Version = " +
            //        browser["JavaScriptVersion"] + "\n";

            //lblMessage.Text = s;
            //lblMessage.Text = s + "\n" + HttpContext.Current.Request.UserAgent;


        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            SqlCommand cmdDeletePages = new SqlCommand();
            cmdDeletePages.CommandText = "DELETE FROM UserPagesTBL WHERE (UserID= @UserID) AND (ApplicationID = @ApplicationID)";
            cmdDeletePages.Parameters.AddWithValue("@ApplicationID", MDirMaster.ApplicationID);
            cmdDeletePages.Parameters.AddWithValue("@UserID", ddlUserName.SelectedValue);
            if (MDirMaster.Execute(cmdDeletePages, lblMessage, HttpContext.Current.Request.Path))
            {
                SqlCommand cmdInsertPages = new SqlCommand();
                cmdInsertPages.CommandText = @"INSERT INTO UserPagesTBL (UserID, PageID, ApplicationID)
                                                            VALUES (@UserID, @PageID, @ApplicationID)";
                cmdInsertPages.Parameters.AddWithValue("@UserID", ddlUserName.SelectedValue);
                cmdInsertPages.Parameters.AddWithValue("@ApplicationID", MDirMaster.ApplicationID);
                cmdInsertPages.Parameters.Add("@PageID", SqlDbType.Int);
                bool Error = true;
                for (int i = 0; i < chbPages.Items.Count; i++)
                {
                    if (chbPages.Items[i].Selected)
                    {
                        cmdInsertPages.CommandText = @"INSERT INTO UserPagesTBL (UserID, PageID, ApplicationID)
                                                            VALUES (@UserID, @PageID, @ApplicationID)";
                        cmdInsertPages.Parameters["@PageID"].Value = chbPages.Items[i].Value;
                        //cmdInsertPages.Parameters.AddWithValue("@ApplicationID", MDirMaster.ApplicationID);
                        Error = MDirMaster.Execute(cmdInsertPages, lblMessage, HttpContext.Current.Request.Path);
                    }
                }
                if (Error)
                {

                    SqlCommand cmdDeleteReports = new SqlCommand();
                    cmdDeleteReports.CommandText = "DELETE FROM UserReportsTBL WHERE (UserID= @UserID) AND (ApplicationID = @ApplicationID)";
                    cmdDeleteReports.Parameters.AddWithValue("@UserID", ddlUserName.SelectedValue);
                    cmdDeleteReports.Parameters.AddWithValue("@ApplicationID", MDirMaster.ApplicationID);
                    if (MDirMaster.Execute(cmdDeleteReports, lblMessage, HttpContext.Current.Request.Path))
                    {
                        SqlCommand cmdInsertReports = new SqlCommand();
                        
                        cmdInsertReports.Parameters.AddWithValue("@UserID", ddlUserName.SelectedValue);
                        cmdInsertReports.Parameters.AddWithValue("@ApplicationID", MDirMaster.ApplicationID);
                        cmdInsertReports.Parameters.Add("@ReportID", SqlDbType.Int);
                        bool ErrorRep = true;
                        for (int i = 0; i < chbReports.Items.Count; i++)
                        {
                            if (chbReports.Items[i].Selected)
                            {
                                cmdInsertReports.CommandText = @"INSERT INTO [HR].[dbo].[UserReportsTBL] (UserID, ReportID, Export, Printing, ApplicationID)
                                                            VALUES (@UserID, @ReportID, 0, 0,@ApplicationID)";
                                cmdInsertReports.Parameters["@ReportID"].Value = chbReports.Items[i].Value;
                                ErrorRep = MDirMaster.Execute(cmdInsertReports, lblMessage, HttpContext.Current.Request.Path);
                            }
                        }
                        if (ErrorRep || Error)
                        {
                            Response.Redirect("~/Pages/User/UserPages.aspx", false);
                        }

                    }
                }

            }

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/Default.aspx", false);
        }

        protected void ddlUserName_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetList();
        }

        private void GetList()
        {
            SqlCommand cmdPagesList = new SqlCommand(@"SELECT dbo.PagesTBL.PageID AS [ID], dbo.PagesTBL.PageName AS [VALUE]
                                                   FROM PagesTBL
                                                    WHERE (dbo.PagesTBL.ParentID IS NOT NULL) AND ((ApplicationID =@ApplicationID) OR (ApplicationID =5)) ORDER BY VALUE");
            cmdPagesList.Parameters.AddWithValue("@ApplicationID", MDirMaster.ApplicationID);
            DataTable PagesList = MDirMaster.GetData(cmdPagesList, lblMessage);
            DataTable CheckedPages = new DataTable();
            SqlCommand cmdCheckedPages = new SqlCommand();
            if (Convert.ToInt32(ddlUserName.SelectedValue) > 0)
            {
                cmdCheckedPages.CommandText = @"SELECT PageID AS [ID]
                                                FROM   UserPagesTBL 
                                                WHERE  UserID = @UserID";
                cmdCheckedPages.Parameters.AddWithValue("@UserID", ddlUserName.SelectedValue);
                CheckedPages = MDirMaster.GetData(cmdCheckedPages, lblMessage);
            }
            else
            {
                CheckedPages.Columns.Add(new DataColumn("ID"));
            }
            MDirMaster.Pop(PagesList, CheckedPages, chbPages);
            SqlCommand cmdReportsList = new SqlCommand(@"SELECT [ReportID] AS [ID], [Name] AS [Value]
                                                         FROM [HR].[dbo].[ReportsTBL]
                                                         WHERE [IsActive] = 1 AND (ApplicationID =@ApplicationID)");
            cmdReportsList.Parameters.AddWithValue("@ApplicationID", MDirMaster.ApplicationID);
            DataTable ReportsList = MDirMaster.GetData(cmdReportsList, lblMessage);
            DataTable CheckedReports = new DataTable();
            SqlCommand cmdCheckedReports = new SqlCommand();
            if (Convert.ToInt32(ddlUserName.SelectedValue) > 0)
            {
                cmdCheckedReports.CommandText = @"SELECT [ReportID] AS ID
                                                  FROM   [UserReportsTBL]
                                                  WHERE  [UserID] = @UserID";
                cmdCheckedReports.Parameters.AddWithValue("@UserID", ddlUserName.SelectedValue);
                CheckedReports = MDirMaster.GetData(cmdCheckedReports, lblMessage);
            }
            else
            {
                CheckedReports.Columns.Add(new DataColumn("ID"));
            }
            MDirMaster.Pop(ReportsList, CheckedReports, chbReports);
        }
    }
}