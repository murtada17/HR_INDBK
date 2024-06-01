using System;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI.WebControls;

namespace HR_Salaries.Pages.Email
{
    public partial class Emails : System.Web.UI.Page
    {
        public int EmpID;

        protected void Page_Load(object sender, EventArgs e)
        {
            lblMessage.Text = "";
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
                    //search
                    MDirMaster.FillCombo("BranchID", "BranchDescAR", "BranchsTBL", ddlSBranch, true, lblMessage);
                    MDirMaster.FillCombo("DepartmentID", "DepartmentDescAR", "DepartmentTBL", ddlSDep, true, lblMessage);
                    MDirMaster.FillCombo("EmpID", "FirstNameAR] + ' ' + [MidNameAR] + ' '+ [LastNameAR", "EmployeesTBL", ddlNameAR, lblMessage);
                    MDirMaster.FillCombo("EmpID", "FirstNameEN] + ' ' + [MidNameEN] + ' '+ [LastNameEN", "EmployeesTBL", ddlNameEN, lblMessage);
                    MDirMaster.FillCombo("EmpID", "FirstNameAR] + ' ' + [MidNameAR] + ' '+ [LastNameAR", "EmployeesTBL", ddlNameUpdateAR, lblMessage);
                    MDirMaster.FillCombo("EmpID", "FirstNameEN] + ' ' + [MidNameEN] + ' '+ [LastNameEN", "EmployeesTBL", ddlNameUpdateEN, lblMessage);
                    //info
                    MDirMaster.FillCombo("EmailTypeID", "EmailTypeDesc", "EmailTypeTBL", ddlEmailType, true, lblMessage);
                }
            }
        }

        void ResetControls()
        {
            txtMailBoxSize.Text = txtEmail.Text = null;
            txtCreationDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            ddlNameUpdateEN.SelectedValue = ddlNameUpdateAR.SelectedValue = ddlEmailType.SelectedValue = "0";
            gvEmails.DataSource = null;
            gvEmails.DataBind();
            chbIsActive.Checked = true;
            pEdit.Enabled = false;
            pSearch.Enabled = true;
            hfEmailID.Value = "0";
            
        }

        public bool getdata(int ID)
        {
            bool result = false;
            DataTable dt = new DataTable();
            if (ID > 0)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"SELECT ROW_NUMBER() OVER (ORDER BY EmailsTBL.EmailID) AS [ت],dbo.EmailsTBL.EmailID, dbo.EmployeesTBL.FirstNameAR + ' ' + dbo.EmployeesTBL.MidNameAR + ' ' + dbo.EmployeesTBL.LastNameAR AS [أسم الموظف], 
                                             dbo.BranchsTBL.BranchDescAR AS الفرع, dbo.DepartmentTBL.DepartmentDescAR AS القسم, dbo.EmailsTBL.EmailName AS [عنوان البريد], 
                                             iif(dbo.EmailListTBL.ListName is null, '---', dbo.EmailListTBL.ListName) AS [القوائم البريدية], dbo.EmailTypeTBL.EmailTypeDesc AS [نوع الايميل], dbo.EmailsTBL.CreationDate AS [تاريخ الانشاء], dbo.EmailsTBL.IsActive AS [فعال؟]
							        FROM     dbo.EmailsTBL inner JOIN
					                         dbo.EmailTypeTBL ON dbo.EmailsTBL.EmailTypeID = dbo.EmailTypeTBL.EmailTypeID RIGHT JOIN
					                         dbo.EmployeesTBL ON dbo.EmailsTBL.EmpID = dbo.EmployeesTBL.EmpID INNER JOIN
					                         dbo.BranchsTBL ON dbo.EmployeesTBL.BranchID = dbo.BranchsTBL.BranchID INNER JOIN
					                         dbo.DepartmentTBL ON dbo.EmployeesTBL.DepartmentID = dbo.DepartmentTBL.DepartmentID LEFT JOIN
					                         dbo.EmailListMembersTBL ON dbo.EmailsTBL.EmailID = dbo.EmailListMembersTBL.EmailID AND EmailListMembersTBL.IsActive = 1 LEFT JOIN
					                         dbo.EmailListTBL ON dbo.EmailListMembersTBL.EmailListID = dbo.EmailListTBL.EmailListID
                                        WHERE dbo.EmployeesTBL.EmpID = @EmpID ";
                cmd.Parameters.AddWithValue("@EmpID", ID);
                ddlNameUpdateAR.SelectedValue = ddlNameUpdateEN.SelectedValue = ID.ToString();
                dt = MDirMaster.GetData(cmd, lblMessage);
                if (dt.Rows.Count > 0)
                {
                    
                    gvEmails.DataSource = dt;
                    MDirMaster.AddColumnsToGridView(gvEmails, dt);
                    gvEmails.DataBind();
                    //gvEmails.Columns[0].Visible = false;
                    gvEmails.Columns[1].Visible = false;
                    //gvEmails.Columns[8] = gvEmails.Columns[8]. ToString().Substring(0, 9);
                }
                result = true;
                
            }
            return result;
        }

        protected void btnGetInfo_Click(object sender, EventArgs e)
        {
            EmpID = Convert.ToInt32(hfEmpID.Value);
            if (EmpID > 0)
            {
                if (getdata(EmpID))
                {
                    pEdit.Enabled = true;
                    pSearch.Enabled = false;
                }
                else
                {
                    MDirMaster.Messages(lblMessage, 0);
                }
            }
            else
            {
                MDirMaster.Messages(lblMessage, 3);
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ResetControls();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(hfEmpTempID.Value) > 0)
            {
                SqlCommand cmd = new SqlCommand();
                string Query;
                if (Convert.ToInt32(hfEmailID.Value) > 0)
                {
                    //EDIT
                    Query = @"UPDATE EmailsTBL SET EmpID= @EmpID, EmailTypeID = @EmailTypeID, EmailName =@EmailName,
                                                   BoxSize=@BoxSize, CreationDate= @CreationDate, IsActive = @IsActive
                                             WHERE EmailsTBL.EmailID = @EmailID";
                    cmd.Parameters.AddWithValue("@EmailID", hfEmailID.Value);
                }
                else
                {
                    //NEW
                    Query = @"INSERT INTO EmailsTBL ( EmpID, EmailTypeID, EmailName, BoxSize, CreationDate, IsActive)
                                    VALUES (@EmpID, @EmailTypeID, @EmailName, @BoxSize, @CreationDate, @IsActive )";
                }
                cmd.Parameters.AddWithValue("@EmpID", hfEmpTempID.Value);
                cmd.Parameters.AddWithValue("@EmailTypeID", ddlEmailType.SelectedValue);
                cmd.Parameters.AddWithValue("@EmailName", txtEmail.Text);
                cmd.Parameters.AddWithValue("@BoxSize", txtMailBoxSize.Text);
                cmd.Parameters.Add("@CreationDate", System.Data.SqlDbType.Date);
                cmd.Parameters["@CreationDate"].Value = (txtCreationDate.Text);
                cmd.Parameters.AddWithValue("@IsActive", chbIsActive.Checked);
                cmd.CommandText = Query;
                if (MDirMaster.Execute(cmd, lblMessage, HttpContext.Current.Request.Path))
                {
                    ResetControls();
                }
            }
        }

        protected void ddlSBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Condition = "";
            bool check = false;
            if (Convert.ToInt32(ddlSBranch.SelectedValue) > 0)
            {
                Condition += " BranchID = " + ddlSBranch.SelectedValue;
                check = true;
            }
            if (Convert.ToInt32(ddlSDep.SelectedValue) > 0)
            {
                if (check)
                {
                    Condition += " AND ";
                }
                Condition += " DepartmentID = " + ddlSDep.SelectedValue;
                check = true;
            }
            if (check)
            {
                MDirMaster.FillCombo("EmpID", "FirstNameAR] + ' ' + [MidNameAR] + ' '+ [LastNameAR", "EmployeesTBL", ddlNameAR, Condition, lblMessage);
                MDirMaster.FillCombo("EmpID", "FirstNameEN] + ' ' + [MidNameEN] + ' '+ [LastNameEN", "EmployeesTBL", ddlNameEN, Condition, lblMessage);
            }
            else
            {
                MDirMaster.FillCombo("EmpID", "FirstNameAR] + ' ' + [MidNameAR] + ' '+ [LastNameAR", "EmployeesTBL", ddlNameAR, lblMessage);
                MDirMaster.FillCombo("EmpID", "FirstNameEN] + ' ' + [MidNameEN] + ' '+ [LastNameEN", "EmployeesTBL", ddlNameEN, lblMessage);
            }
        }

        protected void ddlName_SelectedIndexChanged(object sender, EventArgs e)
        {

            DropDownList ddl = sender as DropDownList;
            if (ddl != null)
            {
                string SenderID = ddl.SelectedValue;
                hfEmpTempID.Value = hfEmpID.Value = ddlNameEN.SelectedValue = ddlNameAR.SelectedValue = SenderID;
            }
        }

        protected void gvEmails_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            int index = e.NewSelectedIndex;
            try
            {
                int ID = Convert.ToInt32(gvEmails.Rows[index].Cells[2].Text);
                hfEmailID.Value = ID.ToString();
                if (ID > 0)
                {
                    // get the data

                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = @"SELECT [EmailID],[EmpID],[EmailTypeID],[EmailName],[BoxSize],[CreationDate],[IsActive]
                                  FROM [HR].[dbo].[EmailsTBL]
                                 WHERE EmailsTBL.EmailID = @EmailID";
                    cmd.Parameters.AddWithValue("@EmailID", ID);
                    DataTable dt = MDirMaster.GetData(cmd, lblMessage);
                    txtCreationDate.Text = Convert.ToDateTime(dt.Rows[0]["CreationDate"]).ToString("dd/MM/yyyy");
                    txtEmail.Text = dt.Rows[0]["EmailName"].ToString();
                    txtMailBoxSize.Text = dt.Rows[0]["BoxSize"].ToString();
                    ddlEmailType.SelectedValue = dt.Rows[0]["EmailTypeID"].ToString();
                    ddlNameUpdateAR.SelectedValue = ddlNameUpdateEN.SelectedValue = dt.Rows[0]["EmpID"].ToString();
                    chbIsActive.Checked = Convert.ToBoolean(dt.Rows[0]["IsActive"]);
                }

                //int index = e.NewSelectedIndex;
            }
            catch
            {
                MDirMaster.Messages(lblMessage, 0);
            }
        }

        protected void gvEmails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView gv = sender as GridView;
            gv.PageIndex = e.NewPageIndex;
            gv.SelectedIndex = -1;
            getdata(EmpID);
        }

        protected void ddlNameUpdate_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddl = sender as DropDownList;
            if (ddl != null)
            {
                string SenderID = ddl.SelectedValue;
                hfEmpTempID.Value = ddlNameUpdateEN.SelectedValue = ddlNameUpdateAR.SelectedValue = SenderID;
            }
        }

        protected void txtCreationDate_TextChanged(object sender, EventArgs e)
        {
            WebControl MyWebControl = sender as WebControl;
            if (MyWebControl != null)
            {
                lblMessage.Text = "";
                TextBox txt = (TextBox)MyWebControl;
                try
                {
                    DateTime date = Convert.ToDateTime(txt.Text);
                }
                catch
                {
                    lblMessage.Text = "الرجاء ادخال التاريخ بصورة صحيحة يوم/شهر/سنة او يوم-شهر-سنة";
                    txt.Focus();
                }
            }
        }

    }
}