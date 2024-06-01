using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;


//this template was created by Muthanna Al-Ani Aug./ 2013
//then mantained by Shams, Nims, Murtadha somewhen in 2018
namespace HR_Salaries
{
    public partial class MDirMaster : System.Web.UI.MasterPage
    {
        public static int WorkHours;
        public static int ApplicationID = 1;
        public static string DefaultPass;
        public static string Path = @"~\UserImages\";
        //Data Source=190.190.200.100,1433;Network Library=DBMSSOCN;Initial Catalog = myDataBase; User ID = myUsername; Password=myPassword;

        //public static SqlConnection con = new SqlConnection("Data Source=MASTERCARD/INDBK;Network Library=DBMSSOCN;Initial Catalog = HR; User ID = HR; Password=12qw!@QW");
        //public static SqlConnection con = new SqlConnection("Data Source=.; Initial Catalog=HR; user ID=HR; Password= 1HR12IIB18");
        //public static SqlConnection con = new SqlConnection("Data Source=.; Initial Catalog=HR; user ID=HR; Password= 1HR12IIB18");
        public static SqlConnection con = new SqlConnection("Data Source=10.10.16.30; Initial Catalog=HR; User ID=HR;Password=1HR12IIB18");

        protected void Page_Load(object sender, EventArgs e)
        {
            string PageName = System.IO.Path.GetFileName(Request.Url.AbsolutePath).ToLower();
            Style();

            if (!IsPostBack)
            {
                Page.Header.DataBind();
                SqlCommand SetCmd = new SqlCommand();
                SetCmd.CommandText = "SELECT * FROM SystemSettingsTBL";
                DataTable Setdt = GetData(SetCmd, lblMessage);
                if (Setdt.Rows.Count > 0)
                {
                    DefaultPass = Setdt.Select(string.Format("SettingID = {0}", 1))[0]["SettingValue"].ToString();
                    WorkHours = Convert.ToInt32(Setdt.Select(string.Format("SettingID = {0}", 2))[0]["SettingValue"]);
                }
                else
                {
                    return;
                }
                SqlCommand cmd = new SqlCommand();
                if (Session["Logged"] != null)
                {
                    if (Convert.ToBoolean(Session["Logged"]))
                    {
                        string url = HttpContext.Current.Request.Path.ToLower();
                        if (url != "/pages/salaries/allowaded.aspx" && url != "/hr/pages/default.aspx" && url != "/pages/default.aspx" && url != "/pages/users/login.aspx")
                        {
                            if (!HasPrivilage(url, lblMessage))
                            {
                                Session["msg"] = "9";
                                Response.Redirect("~/Pages/Default.aspx");
                            }
                        }
                        lblUserName.Text = "مرحبا " + Session["FullName"].ToString();
                        lbtnLogInOut.Text = "تسجيل الخروج";
                        lbtnLogInOut.Visible = true;
                        cmd.CommandText = @"WITH Foo AS (SELECT  TOP (100) PERCENT dbo.PagesTBL.PageID, dbo.PagesTBL.PageName, dbo.PagesTBL.PageLink, dbo.PagesTBL.ParentID, dbo.PagesTBL.OrderSequnce
					                                                 	 FROM  dbo.UserPagesTBL INNER JOIN
			                                                 			 dbo.PagesTBL ON dbo.UserPagesTBL.PageID = dbo.PagesTBL.PageID 
                                           	            				 WHERE        (dbo.UserPagesTBL.UserID = @UserID) AND ((PagesTBL.ApplicationID = @ApplicationID) OR (PagesTBL.ApplicationID = 5))
                                                         			 UNION ALL SELECT TOP (100) PERCENT t0.PageID, t0.PageName, t0.PageLink, t0.ParentID, t0.OrderSequnce
                                                         					 FROM dbo.PagesTBL as t0
                                                         					 INNER JOIN Foo on Foo.ParentID =  t0.PageID) 
                                                         SELECT DISTINCT * FROM Foo
                                                         ORDER BY Foo.OrderSequnce";
                        cmd.Parameters.AddWithValue("@UserID", Session["UserID"].ToString());
                        cmd.Parameters.AddWithValue("@ApplicationID", ApplicationID);
                        PopMenu(cmd, lblMessage);
                    }

                    else
                    {
                        if (PageName != "login.aspx")
                        {
                            lbtnLogInOut.Visible = true;
                            if (PageName == "reportsrpt.aspx")
                            { }
                            else
                            {
                                HttpContext.Current.Session["Handler"] = Request.Url;
                                Response.Redirect("~/Pages/User/Login.aspx", false);
                            }
                        }
                        else
                        {
                        }
                    }
                }
                else
                {
                    if (PageName != "login.aspx")
                    {
                        lbtnLogInOut.Visible = true;
                        if (PageName == "reportsrpt.aspx")
                        { }
                        else
                        {
                            HttpContext.Current.Session["Handler"] = Request.Url;
                            Response.Redirect("~/Pages/User/Login.aspx", false);
                        }
                    }
                    else
                    {
                        lbtnLogInOut.Visible = false;
                    }
                }

                lblVersion.Text = String.Format("النسخة: {0}<br>بتاريـــــخ: {1}",
        System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString(),
        File.GetLastWriteTime(System.Reflection.Assembly.GetExecutingAssembly().Location).ToString("yyyy/MM/dd"));
            }
            else
            {
                if (PageName != "login.aspx")
                {
                    if (Session["Logged"] != null)
                    {
                        if (Convert.ToBoolean(Session["Logged"]))
                        {
                            return;
                        }
                    }
                    HttpContext.Current.Session["Handler"] = Request.Url;
                    Response.Redirect("~/Pages/User/Login.aspx", false);
                }
            }
        }

        protected void lbtnLogInOut_Click(object sender, EventArgs e)
        {
            if (Convert.ToBoolean(Session["Logged"]))
            {
                Session["Logged"] = false;
            }
            HttpContext.Current.Session["Handler"] = null;
            Response.Redirect("~/Pages/User/Login.aspx", false);
        }

        public void Style()
        {
            System.Web.HttpBrowserCapabilities browser = Request.Browser;

            if ((browser.Browser == "Chrome") && (Convert.ToDecimal(browser.Version) > 52))
            {
                HtmlLink css = new HtmlLink();
                css.Href = "../CSS/Menu.css";
                css.Attributes["rel"] = "stylesheet";
                css.Attributes["type"] = "text/css";
                css.Attributes["media"] = "all";
                Page.Header.Controls.Add(css);
            }
            else
            {
                HtmlLink css = new HtmlLink();
                css.Href = "../CSS/MenuOther.css";
                css.Attributes["rel"] = "stylesheet";
                css.Attributes["type"] = "text/css";
                css.Attributes["media"] = "all";
                Page.Header.Controls.Add(css);
            }
            if (((browser.Browser == "Chrome") && (Convert.ToDecimal(browser.Version) < 40)) || ((browser.Browser == "InternetExplorer") && (Convert.ToDecimal(browser.Version) < 10)))
            {
                lblMessage.Text = "نسخة المتصفح قديمة، يرجى طلب تحديث المتصفح من موظفي الـIT ";
            }
        }

        public void PopMenu(SqlCommand cmd, Label lblMessage)
        {
            DataTable dt = GetData(cmd, lblMessage);
            if (dt.Rows.Count > 1)
            {
                DataRow[] parentMenus = dt.Select("ParentID IS null");

                var sb = new StringBuilder();
                string unorderedList = GenerateUL("fa fa-tachometer-alt", parentMenus, dt, sb);
                nav.InnerHtml = unorderedList;
            }
        }

        private string GenerateUL(string css, DataRow[] menu, DataTable table, StringBuilder sb)
        {
            if (menu.Length > 0)
            {
                int x = 0;
                foreach (DataRow dr in menu)
                {
                    string handler = HttpContext.Current.Request.Url.Scheme + "://" + HttpContext.Current.Request.Url.Authority;
                    if (dr["ParentID"].ToString() == "")
                    {
                        string menuText = dr["PageName"].ToString();
                        string TxtPageID = dr["PageID"].ToString();
                        string line = String.Format(@" <a href='#{1}' data-toggle='collapse' aria-expanded='false'>{0}</a>
<ul class='collapse list-unstyled' id='{1}'>",
                            menuText, TxtPageID);
                        sb.Append(line);

                    }

                    else
                    {
                        handler += HttpContext.Current.Request.ApplicationPath + dr["PageLink"].ToString();
                        string menuText = dr["PageName"].ToString();
                        string line = String.Format(@"<li class='{0}'><a href='{1}' style='display:block;''>{2} {3}</a>", css, handler, menuText,
                            "<span class='badge badge-pill badge-warning'></span>");
                        sb.Append(line);
                        sb.Append("</li>");
                        x++;
                    }
                    string pid = dr["PageID"].ToString();
                    string parentId = dr["ParentID"].ToString();
                    DataRow[] subMenu = table.Select(String.Format("ParentID = {0}", pid));
                    if (subMenu.Length > 0 && !pid.Equals(parentId))
                    {
                        var subMenuBuilder = new StringBuilder();
                        if (css == "fa fa-tachometer-alt")
                        {
                            sb.Append(GenerateUL("", subMenu, table, subMenuBuilder));
                        }
                        sb.Append("</ul>");
                    }
                }
            }
            return sb.ToString();
        }

        public static bool HasPrivilage(string FullURL, Label lbl)
        {
            bool result = false;
            if (HttpContext.Current.Session["UserID"] != null)
            {
                int Index = FullURL.IndexOf("/HR");
                if (Index == -1)
                {
                    Index = FullURL.IndexOf("/hr");
                }
                string URL;
                if (Index != -1)
                {
                    URL = FullURL.Substring(3);
                }
                else
                {
                    URL = FullURL;
                }
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"SELECT COUNT(*) FROM UserPagesTBL
                                            WHERE UserID= @UserID AND PageID IN 
            	                              (SELECT PageID FROM PagesTBL
            	                                 WHERE PageLink=@URL)";
                cmd.Parameters.AddWithValue("@UserID", HttpContext.Current.Session["UserID"].ToString());
                cmd.Parameters.AddWithValue("@URL", URL);
                result = Convert.ToBoolean(ExecuteScaler(cmd, lbl, HttpContext.Current.Request.Path));
            }
            else
            {
                HttpContext.Current.Session["Handler"] = FullURL;
                HttpContext.Current.Response.Redirect("~/Pages/User/Login.aspx", false);
            }
            return result;
        }
        public static string HasPrivilage(string FullURL, Label lbl, bool name)
        {
            string result = null;
            if (HttpContext.Current.Session["UserID"] != null)
            {
                int Index = FullURL.IndexOf("/HR");
                string URL;
                if (Index != -1)
                {
                    URL = FullURL.Substring(3);
                }
                else
                {
                    URL = FullURL;
                }
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"SELECT parent.PageName+ ' > '+ PagesTBL.PageName FROM UserPagesTBL left join
                                                PagesTBL on PagesTBL.PageID = UserPagesTBL.PageID left join
                                                PagesTBL as parent on PagesTBL.ParentID = parent.PageID 
                                            WHERE UserID= @UserID AND UserPagesTBL.PageID IN 
            	                              (SELECT PageID FROM PagesTBL
            	                                 WHERE PageLink=@URL)";
                cmd.Parameters.AddWithValue("@UserID", HttpContext.Current.Session["UserID"].ToString());
                cmd.Parameters.AddWithValue("@URL", URL);
                result = ExecuteScaler(cmd, lbl, HttpContext.Current.Request.Path).ToString();
            }
            else
            {
                HttpContext.Current.Session["Handler"] = FullURL;
                HttpContext.Current.Response.Redirect("~/Pages/User/Login.aspx", false);
            }
            return result;
        }

        public static DataTable GetData(SqlCommand cmd, Label label)
        {
            cmd.Connection = con;
            DataTable dt = new DataTable();
            try
            {
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
            }
            catch (Exception ex)
            {
                label.Text = ex.Message.ToString();
                label.BackColor = System.Drawing.Color.Red;
            }
            finally
            {
                con.Close();
                //con.Dispose();
            }
            return dt;
        }

        public static object ExecuteScaler(SqlCommand cmd, Label label, string Page)
        {
            object result;
            try
            {
                con.Open();
                cmd.Connection = con;
                Log(cmd, Page);
                result = cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                label.Text = ex.Message.ToString();
                label.BackColor = System.Drawing.Color.Red;
                result = -1;
            }
            finally
            {
                con.Close();
                //con.Dispose();
            }
            return result;

        }

        public static bool Execute(SqlCommand cmd, Label label, string Page)
        {
            bool result;
            try
            {
                //con.ChangeDatabase("");
                con.Open();
                cmd.Connection = con;
                Log(cmd, Page);
                if (cmd.CommandType == CommandType.StoredProcedure)
                {
                    cmd.ExecuteScalar();
                    result = true;
                }
                else
                {
                    cmd.CommandText = @" DECLARE @result bit = 0;
                                        Begin try
                                        Begin transaction 
                                        "
                                            + cmd.CommandText +
                                      @" Commit transaction
                                         set @result= 1;
                                     End try
                                     Begin catch
                                       Rollback transaction
                                       set @result= 0;
                                     End catch
									 select @result";
                    result = Convert.ToBoolean(cmd.ExecuteScalar());
                }

                Messages(label, 1);
            }
            catch (Exception ex)
            {
                label.Text = ex.Message.ToString();
                label.BackColor = System.Drawing.Color.Red;
                result = false;
            }
            finally
            {
                con.Close();
                //con.Dispose();
            }
            return result;
        }

        public static void Messages(Label lbl, int ID)
        {
            string message = "";
            switch (ID)
            {
                case 1:
                    message = "تمت العملية بنجاح";
                    lbl.BackColor = System.Drawing.Color.Green;
                    break;
                case 2:
                    message = "حدث خطأ في قاعدة البيانات، يرجى إعادة المحاولة";
                    lbl.BackColor = System.Drawing.Color.Red;
                    break;
                case 3:
                    message = "الرجاء ملئ جميع البيانات";
                    lbl.BackColor = System.Drawing.Color.Red;
                    break;
                case 4:
                    message = "خطأ في كلمة السر، الرجاء التأكد";
                    lbl.BackColor = System.Drawing.Color.Red;
                    break;
                case 5:
                    message = "كلمة السر يجب ان تكون ما بين اربعة احرف و عشرون حرفا";
                    lbl.BackColor = System.Drawing.Color.Red;
                    break;
                case 6:
                    // message = "New passwords don't match, please check";
                    break;
                case 7:
                    message = "موجود حاليا";
                    lbl.BackColor = System.Drawing.Color.Red;
                    break;
                case 8:
                    message = "أسم المستخدم غير صحيح";
                    lbl.BackColor = System.Drawing.Color.Red;
                    break;
                case 9:
                    message = "ليس لديك الصلاحية لدخول هذه الصفحة";
                    lbl.BackColor = System.Drawing.Color.Red;
                    break;
                case 10:
                    message = "هذه الفقرة تحت التطوير";
                    lbl.BackColor = System.Drawing.Color.Red;
                    break;
                default:
                    message = "حدث خطأ غير معروف، يرجى إعادة المحاولة، إذا تكرر الخطأ يرجى الاتصال بقسم الدعم الفني لشركة الاتجاه ميم.";
                    lbl.BackColor = System.Drawing.Color.Red;
                    break;
            }
            if (message.Length > 2)
            {
                Messages(lbl, message + ".");
            }

        }
        public string PageTitle
        {
            get
            {
                return lblTitle.Text;
            }
            set
            {
                lblTitle.Text = value;
            }
        }

        public static void Messages(Label lbl, string Message)
        {
            // if (lbl.Text.Length < 2)
            {
                lbl.Text = Message;
            }
            // else
            // {
            //     lbl.Text = lbl.Text + ", <br/> " + Message;
            // }
        }

        public static void MsgBox(String ex, Page pg, Object obj)
        {
            string s = "<SCRIPT language='javascript'>alert('" + ex.Replace("\r\n", "\\n").Replace("'", "") + "'); </SCRIPT>";
            Type cstype = obj.GetType();
            ClientScriptManager cs = pg.ClientScript;
            cs.RegisterClientScriptBlock(cstype, s, s.ToString());
        }

        public static void FillCombo(string ID, string Value, string TableName, DropDownList combo, Label label)
        {
            SqlCommand cmd = new SqlCommand();
            if (combo.CssClass == "ddlltr")
            {
                cmd.CommandText = @"SELECT '0' AS [ID], N' Please Select One ' AS [VALUE] UNION SELECT [ID], [VALUE] 
                    FROM (SELECT TOP (100) PERCENT [" + ID + "] AS [ID], [" + Value + "] AS [VALUE] FROM " + TableName + " ) AS Foo ORDER BY VALUE ASC ";

            }
            else
            {
                cmd.CommandText = @"SELECT '0' AS [ID], N' يرجى الأختيار' AS [VALUE] UNION SELECT [ID], [VALUE] 
                    FROM (SELECT TOP (100) PERCENT [" + ID + "] AS [ID], [" + Value + "] AS [VALUE] FROM " + TableName + " ) AS Foo ORDER BY VALUE ASC ";
            }
            DataTable dt = GetData(cmd, label);
            Pop(dt, combo);
        }
        public static void FillCombo(string ID, string Value, string TableName, DropDownList combo, bool Active, Label label)
        {
            SqlCommand cmd = new SqlCommand();
            if (combo.CssClass == "ddlltr")
            {
                cmd.CommandText = @"SELECT '0' AS [ID], N' Please Select One ' AS [VALUE] UNION SELECT [ID], [VALUE] 
                    FROM (SELECT TOP (100) PERCENT [" + ID + "] AS [ID], [" + Value + "] AS [VALUE] FROM " + TableName + " WHERE IsActive = '" + Active + "' ) AS Foo ORDER BY VALUE ASC ";

            }
            else
            {
                cmd.CommandText = @"SELECT '0' AS [ID], N' يرجى الأختيار' AS [VALUE] UNION SELECT [ID], [VALUE] 
                    FROM (SELECT TOP (100) PERCENT [" + ID + "] AS [ID], [" + Value + "] AS [VALUE] FROM " + TableName + " WHERE IsActive = '" + Active + "' ) AS Foo ORDER BY VALUE ASC ";
            }
            DataTable dt = GetData(cmd, label);
            Pop(dt, combo);
        }
        public static void FillCombo(string ID, string Value, string TableName, DropDownList combo, string CondColumn, object CondValue, Label label)
        {
            SqlCommand cmd = new SqlCommand();
            if (combo.CssClass == "ddlltr")
            {
                cmd.CommandText = "SELECT '0' AS [ID], N' Please Select One' AS [VALUE] FROM " + TableName + @" UNION SELECT [ID], [VALUE] 
                    FROM (SELECT TOP (100) PERCENT [" + ID + "] AS [ID], [" + Value + "] AS [VALUE] FROM " + TableName + " WHERE " + CondColumn + CondValue + ") AS Foo ORDER BY VALUE ASC  ";
            }
            else
            {
                cmd.CommandText = "SELECT '0' AS [ID], N' يرجى الأختيار' AS [VALUE] FROM " + TableName + @" UNION SELECT [ID], [VALUE] 
                    FROM (SELECT TOP (100) PERCENT [" + ID + "] AS [ID], [" + Value + "] AS [VALUE] FROM " + TableName + " WHERE " + CondColumn + CondValue + ") AS Foo ORDER BY VALUE ASC  ";
            }
            DataTable dt = GetData(cmd, label);
            Pop(dt, combo);
        }
        public static void FillCombo(string ID, string Value, string TableName, DropDownList combo, string Condition, Label label)
        {
            SqlCommand cmd = new SqlCommand();
            if (combo.CssClass == "ddlltr")
            {
                cmd.CommandText = "SELECT '0' AS [ID], N' Please Select One' AS [VALUE] FROM " + TableName + @" UNION SELECT [ID], [VALUE] 
                    FROM (SELECT TOP (100) PERCENT [" + ID + "] AS [ID], [" + Value + "] AS [VALUE] FROM " + TableName + " WHERE " + Condition + " ) AS Foo ORDER BY VALUE ASC";
            }
            else
            {
                cmd.CommandText = "SELECT '0' AS [ID], N' يرجى الأختيار' AS [VALUE] FROM " + TableName + @" UNION SELECT [ID], [VALUE] 
                    FROM (SELECT TOP (100) PERCENT [" + ID + "] AS [ID], [" + Value + "] AS [VALUE] FROM " + TableName + " WHERE " + Condition + " ) AS Foo ORDER BY VALUE ASC";
            }
            DataTable dt = GetData(cmd, label);
            Pop(dt, combo);
        }

        public static void Pop(DataTable dt, DropDownList combo)
        {
            if (dt.Rows.Count > 0)
            {
                combo.DataTextField = dt.Columns["VALUE"].ToString();
                combo.DataValueField = dt.Columns["ID"].ToString();
            }
            combo.DataSource = dt;
            combo.DataBind();
            try
            {
                combo.SelectedValue = "0";
            }
            catch
            {
                combo.SelectedIndex = -1;
            }
        }
        public static void Pop(DataTable dt, CheckBoxList ChBL)
        {
            if (dt.Rows.Count > 0)
            {
                ChBL.DataTextField = dt.Columns["VALUE"].ToString();
                ChBL.DataValueField = dt.Columns["ID"].ToString();
            }
            ChBL.DataSource = dt;
            ChBL.DataBind();
        }
        public static void Pop(DataTable dtList, DataTable dtChecked, CheckBoxList ChBL)
        {
            ChBL.Items.Clear();
            bool Selected;
            int ListID, CheckedID;
            for (int i = 0; i < dtList.Rows.Count; i++)
            {
                Selected = false;
                ListID = (int)dtList.Rows[i]["ID"];
                for (int j = 0; j < dtChecked.Rows.Count; j++)
                {
                    CheckedID = (int)dtChecked.Rows[j]["ID"];
                    if (ListID == CheckedID)
                    {
                        Selected = true;
                        break;
                    }
                }
                ListItem li = new ListItem(dtList.Rows[i]["VALUE"].ToString(), dtList.Rows[i]["ID"].ToString(), true);
                li.Selected = Selected;
                ChBL.Items.Add(li);
            }
            ChBL.DataBind();
        }
        public static void Pop(DataTable dt, RadioButtonList ChBL)
        {
            if (dt.Rows.Count > 0)
            {
                ChBL.DataTextField = dt.Columns["VALUE"].ToString();
                ChBL.DataValueField = dt.Columns["ID"].ToString();
            }
            ChBL.DataSource = dt;
            ChBL.DataBind();
        }

        public static string GetMd5Hash(MD5 md5Hash, string input)
        {
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }

        public static void AddColumnsToGridView(GridView gv, DataTable table)
        {
            gv.Columns.Clear();
            foreach (DataColumn column in table.Columns)
            {
                string DataType = column.DataType.ToString();
                if (DataType == "System.Boolean")
                {
                    CheckBoxField field = new CheckBoxField();
                    field.DataField = column.ColumnName;
                    field.HeaderText = column.ColumnName;
                    gv.Columns.Add(field);
                }
                else if (DataType == "System.DateTime")
                {
                    BoundField field = new BoundField();
                    field.DataField = column.ColumnName;
                    field.HeaderText = column.ColumnName;
                    field.DataFormatString = "{0:yyyy/MM/dd-HH:mm}";
                    gv.Columns.Add(field);

                }
                else
                {
                    BoundField field = new BoundField();
                    field.DataField = column.ColumnName;
                    field.HeaderText = column.ColumnName;
                    gv.Columns.Add(field);
                }
            }
        }

        public static void UploadFile(FileUpload FU, int OrderType, string OrderNo, string OrderDate, bool IsActive)
        {


        }

        public static void FillGrid(SqlCommand cmd, GridView gv, Label lable)
        {
            DataTable dt = GetData(cmd, lable);
            AddColumnsToGridView(gv, dt);
            gv.DataSource = dt;
            gv.DataBind();
            if (gv.Rows.Count > 0)
            {
                gv.Columns[0].Visible = false;
            }
        }

        public static void ClearControls(Control p1)
        {
            foreach (Control ctrl in p1.Controls)
            {
                if (ctrl is TextBox)
                {
                    TextBox t = ctrl as TextBox;

                    if (t != null)
                    {
                        t.Text = String.Empty;
                    }
                }
                else if (ctrl is DropDownList)
                {
                    DropDownList d = ctrl as DropDownList;
                    if (d.SelectedIndex > 0)
                    {
                        d.SelectedIndex = 0;
                    }
                }
                else if (ctrl is CheckBox)
                {
                    CheckBox c = ctrl as CheckBox;
                    c.Checked = false;
                }
            }
        }

        public static bool AdminOrderAdd(int EmpID, int BranchID, int DepartmentID, string OrderDesc, string OrderNo, string OrderDate, int OrderType, Label label)
        {
            bool result = false;

            SqlCommand cmd = new SqlCommand(@"AddAdminOrderSP ");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@EmpID", EmpID);
            cmd.Parameters.AddWithValue("@BranchID", BranchID);
            cmd.Parameters.AddWithValue("@DepartmentID", DepartmentID);
            cmd.Parameters.AddWithValue("@OrderDesc", OrderDesc);
            cmd.Parameters.AddWithValue("@OrderNo", OrderNo);
            cmd.Parameters.AddWithValue("@OrderType", OrderType);
            cmd.Parameters.Add("@OrderDate", System.Data.SqlDbType.Date);
            cmd.Parameters["@OrderDate"].Value = (OrderDate);
            if (MDirMaster.Execute(cmd, label, HttpContext.Current.Request.Path))
            {
                result = true;
            }
            return result;
        }
        public static DataTable GetBranchDep(int EmployeeID, Label lbl)
        {
            DataTable dt = new DataTable();
            SqlCommand cmdSelect = new SqlCommand();
            cmdSelect.CommandText = @"SELECT    dbo.EmployeesTBL.BranchID, dbo.EmployeesTBL.DepartmentID, dbo.BranchsTBL.BranchDescAR, dbo.DepartmentTBL.DepartmentDescAR,
                                                dbo.EmployeesTBL.SectionID, dbo.SectionTBL.SectionDescAR
                                      FROM      dbo.EmployeesTBL INNER JOIN
                                                dbo.BranchsTBL ON dbo.EmployeesTBL.BranchID = dbo.BranchsTBL.BranchID INNER JOIN
                                                dbo.DepartmentTBL ON dbo.EmployeesTBL.DepartmentID = dbo.DepartmentTBL.DepartmentID INNER JOIN
                                                dbo.SectionTBL ON dbo.EmployeesTBL.SectionID = dbo.SectionTBL.SectionID
                                      WHERE     EmpID = @EmpID";
            cmdSelect.Parameters.AddWithValue("@EmpID", EmployeeID);
            dt = MDirMaster.GetData(cmdSelect, lbl);
            return dt;
        }

        public static bool IsAdmin(Label lable, string Page)
        {
            bool Admin = false;
            if (HttpContext.Current.Session["UserID"] != null)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"SELECT count(*)
                                    FROM [HR].[dbo].[UserPrivilegesTBL]
                                    WHERE ApplicationID = @ApplicationID and PrivilegeID = 1 and UserID = @UserID";
                cmd.Parameters.AddWithValue("@ApplicationID", ApplicationID);
                cmd.Parameters.AddWithValue("@UserID", HttpContext.Current.Session["UserID"].ToString());
                Admin = Convert.ToBoolean(ExecuteScaler(cmd, lable, Page));
            }
            return Admin;
        }
        public static void Log(SqlCommand cmd, string page)
        {
            int commandType = 0;
            string CommandText = cmd.CommandText;
            string querytype = CommandText.Substring(0, CommandText.IndexOf(" "));
            if (querytype.ToLower() == "update")
            {
                commandType = 2;
            }
            else if (querytype.ToLower() == "insert")
            {
                commandType = 1;
            }
            else if (querytype.ToLower() == "delete")
            {
                commandType = 4;
            }
            else if (cmd.CommandType == CommandType.StoredProcedure)
            {
                commandType = 3;
            }
            if (commandType != 0)
            {
                int index = page.LastIndexOf("/");
                string PageName = "";
                if (index > 0)
                {
                    PageName = page.Substring(index + 1);
                }
                else
                {
                    PageName = page;
                }
                // string TableName = "";
                //string[] command = CommandText.Split(' ');
                //TableName= CommandText.Substring(tnindex,
                SqlCommand cmdLOG = new SqlCommand();
                string par_value;
                string parameters = "";
                foreach (SqlParameter par in cmd.Parameters)
                {
                    if (par.Direction == ParameterDirection.Input)
                    {
                        par_value = par.Value.ToString();
                        if (parameters.Length > 1)
                        {
                            parameters += ",/ ";
                        }
                        parameters += par_value;
                    }
                    else
                    {
                        par_value = par.ParameterName.ToString();
                        if (parameters.Length > 1)
                        {
                            parameters += ",/ ";
                        }
                        parameters += par_value;// parameter name instead of nothing for the output parameters
                    }
                }
                cmdLOG.CommandText = @"INSERT INTO LogTBL (UserID, CommandType, CommandText, ParValues, CommandDate, PageName)
                                                 Values (@UserID, @CommandType, @CommandText, @ParValues, GETDATE(), @PageName)";
                cmdLOG.Parameters.AddWithValue("@UserID", HttpContext.Current.Session["UserID"].ToString());
                cmdLOG.Parameters.AddWithValue("@CommandType", commandType);
                cmdLOG.Parameters.AddWithValue("@CommandText", CommandText);
                cmdLOG.Parameters.AddWithValue("@ParValues", parameters);
                cmdLOG.Parameters.AddWithValue("@PageName", PageName);
                try
                {
                    cmdLOG.Connection = con;
                    cmdLOG.ExecuteNonQuery();
                }
                finally
                {

                }
            }
        }

        public static void Write(DataTable dt, string outputFilePath)
        {
            int[] maxLengths = new int[dt.Columns.Count];

            for (int i = 0; i < dt.Columns.Count; i++)
            {
                maxLengths[i] = dt.Columns[i].ColumnName.Length;

                foreach (DataRow row in dt.Rows)
                {
                    if (!row.IsNull(i))
                    {
                        int length = row[i].ToString().Length;

                        if (length > maxLengths[i])
                        {
                            maxLengths[i] = length;
                        }
                    }
                }
            }

            using (StreamWriter sw = new StreamWriter(outputFilePath, false))
            {
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    sw.Write(dt.Columns[i].ColumnName.PadRight(maxLengths[i] + 2));
                }

                sw.WriteLine();

                foreach (DataRow row in dt.Rows)
                {
                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        if (!row.IsNull(i))
                        {
                            sw.Write(row[i].ToString().PadRight(maxLengths[i] + 2));
                        }
                        else
                        {
                            sw.Write(new string(' ', maxLengths[i] + 2));
                        }
                    }

                    sw.WriteLine();
                }

                sw.Close();
            }
        }


        public static void WriteDataToFile(DataTable dt, string submittedFilePath, string ccy, int bankid, int SequenceNumber, int DSlipNu, int TraType, int TraCategory, string exp, int SlipNumber, DataTable fullsalary, string datProcessing, string datBatchDate, string TransactionDate, String dat_Time, String BatchName)
        {


            StreamWriter sw = new StreamWriter(submittedFilePath + BatchName + ".txt"); //create the file


            // Processing Date
            // string dat_Processing = Convert.ToDateTime(DateTime.Now).ToString("yyyyMMdd");
            // Batch Date
            //string dat_BatchDate = Convert.ToDateTime(DateTime.Now).ToString("yyyyMMdd");







            string dat = Convert.ToDateTime(DateTime.Now).ToString("yyyyMMdd");
            string tim = dat_Time;

            // File Header
            string line1 = "FH";
            line1 += bankid.ToString().PadLeft(8, '0');   // bank id number
            line1 += "BATCH-MISC"; // File Label
            line1 += datProcessing;         // Processing Date datProcessing  line1 += dat;   
            line1 += SequenceNumber.ToString().PadLeft(4, '0');       // Sequence Number
            line1 += "0001";       // Layout Version 

            sw.WriteLine(line1);
            // File Header


            // Batch Header



            string line_bHeader = "BH";
            line_bHeader += DSlipNu.ToString().PadLeft(11, '0');  // Deposit Slip Number
            line_bHeader += datBatchDate;        // Batch Date  datBatchDate     line_bHeader += dat;     
            line_bHeader += TraType.ToString().PadLeft(3, '0');      // Transaction Type
            line_bHeader += TraCategory.ToString().PadLeft(3, '0');      // Transaction Category
            line_bHeader += "N";         // Reversal Indicator 
            line_bHeader += ccy;         // Batch Currency
            line_bHeader += exp;         // Batch Currency Exponent


            sw.WriteLine(line_bHeader);


            // Batch Header


            // 
            int se = 0;
            foreach (DataRow dr in dt.Rows)
            {
                se = se + 1;
                string line = "RD";
                //line += SlipNumber.ToString().PadLeft(11, '0');  // Deposit Slip Number
                line += se.ToString().PadLeft(11, '0');  // Deposit Slip Number
                line += TransactionDate;
                line += tim;               // Transaction Time
                //line += dr["Card_number"].ToString().PadRight(19, ' '); // CardNumber 
                line += "".ToString().PadRight(19, ' '); // CardNumber 
                line += dr["Account_Number"].ToString().PadLeft(11, '0');  // Account Number
                line += "".ToString().PadRight(19, ' ');  //Settlement Account
                line += "Payment".ToString().PadRight(25, ' ');  // Transaction Narrativ
                line += ((dr["Full Salary"].ToString().Replace(".", "")).PadLeft(18, '0'));  // Amount

                sw.WriteLine(line);
            }
            // Batch Trailer
            foreach (DataRow dr1 in fullsalary.Rows)
            {
                string line_Batch_Trailer = "BT";
                //line_Batch_Trailer += "1".ToString().PadLeft(10, '0'); //Number Slips
                line_Batch_Trailer += dt.Rows.Count.ToString().PadLeft(10, '0');
                line_Batch_Trailer += (dr1["FullSalary"].ToString().Replace(".", "").PadLeft(18, '0')); //Total Amount
                                                                                                        //line_Batch_Trailer += "2000000".ToString().PadLeft(18, '0'); //Total Amount
                sw.WriteLine(line_Batch_Trailer);
                // Batch Trailer
            }



            // File Trailer
            string line_File_Trailer = "FT"; // Identifler
            line_File_Trailer += "1".ToString().PadLeft(10, '0'); // Number Batches

            sw.WriteLine(line_File_Trailer);

            // File Trailer

            sw.Close();
        }
        public static void WriteDataToFilePhiscal(DataTable dt, string submittedFilePath, string ccy, int bankid, int SequenceNumber, int DSlipNu, int TraType, int TraCategory, string exp, int SlipNumber, DataTable fullsalary, string datProcessing, string datBatchDate, string TransactionDate, String dat_Time, String BatchName)
        {


            StreamWriter sw = new StreamWriter(submittedFilePath + BatchName + ".txt"); //create the file


            // Processing Date
            // string dat_Processing = Convert.ToDateTime(DateTime.Now).ToString("yyyyMMdd");
            // Batch Date
            //string dat_BatchDate = Convert.ToDateTime(DateTime.Now).ToString("yyyyMMdd");







            string dat = Convert.ToDateTime(DateTime.Now).ToString("yyyyMMdd");
            string tim = dat_Time;

            // File Header
            string line1 = "FH";
            line1 += bankid.ToString().PadLeft(8, '0');   // bank id number
            line1 += "BATCH-MISC"; // File Label
            line1 += datProcessing;         // Processing Date datProcessing  line1 += dat;   
            line1 += SequenceNumber.ToString().PadLeft(4, '0');       // Sequence Number
            line1 += "0001";       // Layout Version 

            sw.WriteLine(line1);
            // File Header


            // Batch Header



            string line_bHeader = "BH";
            line_bHeader += DSlipNu.ToString().PadLeft(11, '0');  // Deposit Slip Number
            line_bHeader += datBatchDate;        // Batch Date  datBatchDate     line_bHeader += dat;     
            line_bHeader += TraType.ToString().PadLeft(3, '0');      // Transaction Type
            line_bHeader += TraCategory.ToString().PadLeft(3, '0');      // Transaction Category
            line_bHeader += "N";         // Reversal Indicator 
            line_bHeader += ccy;         // Batch Currency
            line_bHeader += exp;         // Batch Currency Exponent


            sw.WriteLine(line_bHeader);


            // Batch Header


            // 
            int se = 0;
            foreach (DataRow dr in dt.Rows)
            {
                se = se + 1;
                string line = "RD";
                //line += SlipNumber.ToString().PadLeft(11, '0');  // Deposit Slip Number
                line += se.ToString().PadLeft(11, '0');  // Deposit Slip Number
                line += TransactionDate;
                line += tim;               // Transaction Time
                //line += dr["Card_number"].ToString().PadRight(19, ' '); // CardNumber 
                line += "".ToString().PadRight(19, ' '); // CardNumber 
                line += dr["Card_number"].ToString().PadLeft(11, '0');  // Account Number
                line += "".ToString().PadRight(19, ' ');  //Settlement Account
                line += "Payment".ToString().PadRight(25, ' ');  // Transaction Narrativ
                line += ((dr["Full Salary"].ToString().Replace(".", "")).PadLeft(18, '0'));  // Amount

                sw.WriteLine(line);
            }
            // Batch Trailer
            foreach (DataRow dr1 in fullsalary.Rows)
            {
                string line_Batch_Trailer = "BT";
                //line_Batch_Trailer += "1".ToString().PadLeft(10, '0'); //Number Slips
                line_Batch_Trailer += dt.Rows.Count.ToString().PadLeft(10, '0');
                line_Batch_Trailer += (dr1["FullSalary"].ToString().Replace(".", "").PadLeft(18, '0')); //Total Amount
                                                                                                        //line_Batch_Trailer += "2000000".ToString().PadLeft(18, '0'); //Total Amount
                sw.WriteLine(line_Batch_Trailer);
                // Batch Trailer
            }



            // File Trailer
            string line_File_Trailer = "FT"; // Identifler
            line_File_Trailer += "1".ToString().PadLeft(10, '0'); // Number Batches

            sw.WriteLine(line_File_Trailer);

            // File Trailer

            sw.Close();
        }


        // new batch file for AD / 14-01-2020
        public static void WriteDataToFile2(DataTable dt, string submittedFilePath, string ccy, int bankid, int SequenceNumber, int DSlipNu, int TraType, int TraCategory, string exp, int SlipNumber, DataTable fullsalary, string datProcessing, string datBatchDate, string TransactionDate, String dat_Time, String BatchName)
        {


            StreamWriter sw = new StreamWriter(submittedFilePath + BatchName + ".txt"); //create the file


            // Processing Date
            // string dat_Processing = Convert.ToDateTime(DateTime.Now).ToString("yyyyMMdd");
            // Batch Date
            //string dat_BatchDate = Convert.ToDateTime(DateTime.Now).ToString("yyyyMMdd");







            string dat = Convert.ToDateTime(DateTime.Now).ToString("yyyyMMdd");
            string tim = dat_Time;

            // File Header
            string line1 = "FH";
            line1 += bankid.ToString().PadLeft(8, '0');   // bank id number
            line1 += "BATCH-MISC"; // File Label
            line1 += datProcessing;         // Processing Date datProcessing  line1 += dat;   
            line1 += SequenceNumber.ToString().PadLeft(4, '0');       // Sequence Number
            line1 += "0001";       // Layout Version 

            sw.WriteLine(line1);
            // File Header


            // Batch Header



            string line_bHeader = "BH";
            line_bHeader += DSlipNu.ToString().PadLeft(11, '0');  // Deposit Slip Number
            line_bHeader += datBatchDate;        // Batch Date  datBatchDate     line_bHeader += dat;     
            line_bHeader += TraType.ToString().PadLeft(3, '0');      // Transaction Type
            line_bHeader += TraCategory.ToString().PadLeft(3, '0');      // Transaction Category
            line_bHeader += "N";         // Reversal Indicator 
            line_bHeader += ccy;         // Batch Currency
            line_bHeader += exp;         // Batch Currency Exponent


            sw.WriteLine(line_bHeader);


            // Batch Header


            // 
            int se = 0;
            foreach (DataRow dr in dt.Rows)
            {
                se = se + 1;
                string line = "RD";
                //line += SlipNumber.ToString().PadLeft(11, '0');  // Deposit Slip Number
                line += se.ToString().PadLeft(11, '0');  // Deposit Slip Number
                line += TransactionDate;
                line += tim;               // Transaction Time
                line += dr["Account_Number"].ToString().PadRight(19, ' '); // CardNumber
                line += "".ToString().PadRight(11, ' ');  // Account Number
                line += "".ToString().PadRight(19, ' ');  //Settlement Account
                line += "Payment".ToString().PadRight(25, ' ');  // Transaction Narrativ
                line += ((dr["Full Salary"].ToString().Replace(".", "")).PadLeft(18, '0'));  // Amount

                sw.WriteLine(line);
            }
            // Batch Trailer
            foreach (DataRow dr1 in fullsalary.Rows)
            {
                string line_Batch_Trailer = "BT";
                //line_Batch_Trailer += "1".ToString().PadLeft(10, '0'); //Number Slips
                line_Batch_Trailer += dt.Rows.Count.ToString().PadLeft(10, '0');
                line_Batch_Trailer += (dr1["FullSalary"].ToString().Replace(".", "").PadLeft(18, '0')); //Total Amount
                                                                                                        //line_Batch_Trailer += "2000000".ToString().PadLeft(18, '0'); //Total Amount
                sw.WriteLine(line_Batch_Trailer);
                // Batch Trailer
            }



            // File Trailer
            string line_File_Trailer = "FT"; // Identifler
            line_File_Trailer += "1".ToString().PadLeft(10, '0'); // Number Batches

            sw.WriteLine(line_File_Trailer);

            // File Trailer

            sw.Close();
        }










        public static void BulkUpload(string TableName, DataTable dt, Label lbl)
        {
            SqlConnection con = MDirMaster.con;
            SqlBulkCopy bulkCopy = new SqlBulkCopy(con);

            bulkCopy.DestinationTableName = TableName;// "Al_Response";

            try
            {
                con.Open();
                foreach (DataColumn c in dt.Columns)
                    bulkCopy.ColumnMappings.Add(c.ColumnName, c.ColumnName);
                bulkCopy.WriteToServer(dt);
                MDirMaster.Messages(lbl, 1);
            }
            catch (Exception ex)
            {
                lbl.Text = ex.Message;
            }
            finally
            {
                con.Close();
            }
        }

        public static void ToCSV(DataTable dtDataTable, string strFilePath)
        {
            StreamWriter sw = new StreamWriter(strFilePath, false);
            //headers  
            for (int i = 0; i < dtDataTable.Columns.Count; i++)
            {
                sw.Write(dtDataTable.Columns[i]);
                if (i < dtDataTable.Columns.Count - 1)
                {
                    sw.Write("<!>");
                }
            }
            sw.Write(sw.NewLine);
            foreach (DataRow dr in dtDataTable.Rows)
            {
                for (int i = 0; i < dtDataTable.Columns.Count; i++)
                {
                    if (!Convert.IsDBNull(dr[i]))
                    {
                        string value = dr[i].ToString();
                        if (value.Contains("<!>"))
                        {
                            value = String.Format("\"{0}\"", value);
                            sw.Write(value);
                        }
                        else
                        {
                            sw.Write(dr[i].ToString());
                        }
                    }
                    if (i < dtDataTable.Columns.Count - 1)
                    {
                        sw.Write("<!>");
                    }
                }
                sw.Write(sw.NewLine);
            }
            sw.Close();
        }

    }
}
