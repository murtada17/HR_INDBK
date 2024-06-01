using System;


public class TBIMaster
{

    public static TBIMaster ob = new TBIMaster();

    public static int UserP = -1;

    public static string UserName;

    public static int UserID = 0, BranchID = 0, depID = 0;

    public static string DefaultPass = "pass";

    public static SqlConnection con = new SqlConnection("Data Source=10.1.50.25;Initial Catalog=HR ;User ID=sa ;Password=W20nOv9f");

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Convert.ToBoolean(Session["Logged"]))
            {
                lbtnLogInOut.Text = "تسجيل الخروج";
                lbtnLogInOut.Visible = true;

            }
            else
            {
                lbtnLogInOut.Visible = false;
                if (System.IO.Path.GetFileName(Request.Url.AbsolutePath).ToLower() != "login.aspx")
                {
                    HttpContext.Current.Session["Handler"] = Request.Url;
                    Response.Redirect("~/Pages/User/Login.aspx");
                }
            }
        }
    }

    protected void lbtnLogInOut_Click(object sender, EventArgs e)
    {
        if (Convert.ToBoolean(Session["Logged"]))
        {
            Session["Logged"] = false;
        }
        HttpContext.Current.Session["Handler"] = Request.Url;
        Response.Redirect("~/Pages/User/Login.aspx");
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
            label.Text = ex.Message;
        }
        finally
        {
            con.Close();
            //con.Dispose();
        }
        return dt;

    }

    public static object ExecuteScaler(SqlCommand cmd, Label label)
    {
        object result;
        try
        {
            con.Open();
            cmd.Connection = con;
            result = cmd.ExecuteScalar();
        }
        catch (Exception ex)
        {
            label.Text = ex.Data.Values.ToString();
            result = -1;
        }
        finally
        {
            con.Close();
            //con.Dispose();
        }
        return result;

    }

    public static bool Execute(SqlCommand cmd, Label label)
    {
        bool result;
        try
        {
            //con.ChangeDatabase("");
            con.Open();
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            result = true;
            label.Text = "Command Executed Successfully ";
        }
        catch (Exception ex)
        {
            label.Text = ex.Message;
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
                message = "Operation done successfully";
                break;
            case 2:
                message = "Database error";
                break;
            case 3:
                message = "Please check your entries, all fields are required";
                break;
            case 4:
                message = "Invalid old password, please check";
                break;
            case 5:
                message = "Password should be between four and 20 characters long";
                break;
            case 6:
                message = "New passwords don't match, please check";
                break;
            case 7:
                message = "already exists";
                break;
            case 8:
                message = "Invalid user name, please check";
                break;
            default:
                message = "unknown error, please try again";
                break;
        }
        if (message.Length > 2)
        {
            Messages(lbl, message + ".");
        }

    }
    public static void Messages(Label lbl, string Message)
    {
        if (lbl.Text.Length < 5)
        {
            lbl.Text = Message;
        }
    }

    //        public static void FillCombo(string ID, string Value, string TableName, DropDownList combo, bool Active, Label label)
    //        {
    //            SqlCommand cmd = new SqlCommand();
    //            cmd.CommandText = @"SELECT '0' AS [ID], 'Please Select One' AS [VALUE] FROM " + TableName + @" UNION SELECT [ID], [VALUE] 
    //                    FROM (SELECT TOP 9223372036854775807 [" + ID + "] AS [ID], [" + Value + "] AS [VALUE] FROM " + TableName + " ORDER BY " + ID + " ASC ) AS Foo";
    //            DataTable dt = GetData(cmd, label);
    //            if (dt.Rows.Count > 0)
    //            {
    //                combo.DataTextField = dt.Columns["VALUE"].ToString();
    //                combo.DataValueField = dt.Columns["ID"].ToString();
    //                combo.DataSource = dt;
    //                combo.DataBind();
    //            }
    //        }
    //        public static void FillCombo(string ID, string Value, string TableName, DropDownList combo, string CondColumn, object CondValue, Label label)
    //        {
    //            SqlCommand cmd = new SqlCommand();
    //            cmd.CommandText = "SELECT '0' AS [ID], 'Please Select One' AS [VALUE] FROM " + TableName + @" UNION SELECT [ID], [VALUE] 
    //                    FROM (SELECT TOP 9223372036854775807 [" + ID + "] AS [ID], [" + Value + "] AS [VALUE] FROM " + TableName + " WHERE " + CondColumn + CondValue + " ORDER BY " + ID + @" ASC ) AS Foo ";
    //            DataTable dt = GetData(cmd, label);
    //            if (dt.Rows.Count > 0)
    //            {
    //                combo.DataTextField = dt.Columns["VALUE"].ToString();
    //                combo.DataValueField = dt.Columns["ID"].ToString();
    //                combo.DataSource = dt;
    //                combo.DataBind();
    //            }
    //        }
    //        public static void FillCombo(string ID, string Value, string TableName, DropDownList combo, string Condition, Label label)
    //        {
    //            SqlCommand cmd = new SqlCommand();
    //            cmd.CommandText = "SELECT '0' AS [ID], 'Please Select One' AS [VALUE] FROM " + TableName + @" UNION SELECT [ID], [VALUE] 
    //                    FROM (SELECT TOP 9223372036854775807 [" + ID + "] AS [ID], [" + Value + "] AS [VALUE] FROM " + TableName + " WHERE " + Condition + " ORDER BY " + ID + @" ASC ) AS Foo"
    //                       ;
    //            DataTable dt = GetData(cmd, label);
    //            if (dt.Rows.Count > 0)
    //            {
    //                combo.DataTextField = dt.Columns["VALUE"].ToString();
    //                combo.DataValueField = dt.Columns["ID"].ToString();
    //                combo.DataSource = dt;
    //                combo.DataBind();
    //            }
    //        }

    public static void FillCombo(string ID, string Value, string TableName, DropDownList combo, bool Active, Label label)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = @"SELECT '0' AS [ID], N' يرجى الأختيار' AS [VALUE] UNION SELECT [ID], [VALUE] 
                    FROM (SELECT TOP (100) PERCENT [" + ID + "] AS [ID], [" + Value + "] AS [VALUE] FROM " + TableName + ") AS Foo ORDER BY VALUE ASC ";
        DataTable dt = GetData(cmd, label);
        Pop(dt, combo);
    }
    public static void FillCombo(string ID, string Value, string TableName, DropDownList combo, string CondColumn, object CondValue, Label label)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "SELECT '0' AS [ID], N' يرجى الأختيار' AS [VALUE] FROM " + TableName + @" UNION SELECT [ID], [VALUE] 
                    FROM (SELECT TOP (100) PERCENT [" + ID + "] AS [ID], [" + Value + "] AS [VALUE] FROM " + TableName + " WHERE " + CondColumn + CondValue + ") AS Foo ORDER BY VALUE ASC  ";
        DataTable dt = GetData(cmd, label);
        Pop(dt, combo);
    }
    public static void FillCombo(string ID, string Value, string TableName, DropDownList combo, string Condition, Label label)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "SELECT '0' AS [ID], N' يرجى الأختيار' AS [VALUE] FROM " + TableName + @" UNION SELECT [ID], [VALUE] 
                    FROM (SELECT TOP (100) PERCENT [" + ID + "] AS [ID], [" + Value + "] AS [VALUE] FROM " + TableName + " WHERE " + Condition + " ) AS Foo ORDER BY VALUE ASC"
                   ;
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
        combo.SelectedValue = "0";
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


}
