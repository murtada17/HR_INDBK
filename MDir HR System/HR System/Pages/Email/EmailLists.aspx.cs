using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HR_Salaries.Pages.Email
{
    public partial class EmailLists : System.Web.UI.Page
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
                    MDirMaster.FillCombo("EmpID", "FirstNameAR] + ' ' + [MidNameAR] + ' '+ [LastNameAR", "EmployeesTBL", ddlNameUpdateAR, true, lblMessage);
                    MDirMaster.FillCombo("EmpID", "FirstNameAR] + ' ' + [MidNameAR] + ' '+ [LastNameAR", "EmployeesTBL", ddlMemberName, true, lblMessage);
                    MDirMaster.FillCombo("EmpID", "FirstNameEN] + ' ' + [MidNameEN] + ' '+ [LastNameEN", "EmployeesTBL", ddlNameUpdateEN, true, lblMessage);
                    MDirMaster.FillCombo("EmailID", "EmailName", "EmailsTBL", ddlEmail, lblMessage);

                    getdata();
                    pnlSearch.Visible = true;
                    pnlData.Visible = true;
                    pnlList.Visible = false;

                }
            }
        }

        void ResetControls()
        {
            MDirMaster.ClearControls(pnlData);
            txtCreationDate.Text = DateTime.Now.ToString("yyyy/MM/dd");
            gvEmailList.DataSource = null;
            gvEmailList.DataBind();
            chbIsActive.Checked = true;
            //hfEmailID.Value = "0";
            btnSubmit.Text = "إضافة";
            getdata();
        }

        public bool getdata()
        {
            bool result = false;
            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = @"SELECT     ROW_NUMBER() OVER (ORDER BY EmailListTBL.ListName) AS [ت],dbo.EmailListTBL.EmailListID, dbo.EmailListTBL.ListName AS [القائمة البريدية], dbo.EmployeesTBL.FirstNameAR + ' ' + dbo.EmployeesTBL.MidNameAR + ' ' + dbo.EmployeesTBL.LastNameAR AS [أسم الموظف], dbo.BranchsTBL.BranchDescAR AS الفرع, 
                                           dbo.DepartmentTBL.DepartmentDescAR AS القسم, dbo.EmailListTBL.ListDesc AS ملاحظات, dbo.EmailListTBL.CreationDate AS [تاريخ الانشاء]
                                FROM       dbo.EmailListTBL LEFT OUTER JOIN
                                           dbo.BranchsTBL INNER JOIN
                                           dbo.EmployeesTBL ON dbo.BranchsTBL.BranchID = dbo.EmployeesTBL.BranchID INNER JOIN
                                           dbo.DepartmentTBL ON dbo.EmployeesTBL.DepartmentID = dbo.DepartmentTBL.DepartmentID ON dbo.EmailListTBL.EmpID = dbo.EmployeesTBL.EmpID
                                ORDER BY   [القائمة البريدية]";
            //cmd.Parameters.AddWithValue("@EmpID", ID);
            //ddlNameUpdateAR.SelectedValue = ddlNameUpdateEN.SelectedValue = ID.ToString();
            dt = MDirMaster.GetData(cmd, lblMessage);
            if (dt.Rows.Count > 0)
            {

                gvEmailList.DataSource = dt;
                MDirMaster.AddColumnsToGridView(gvEmailList, dt);
                gvEmailList.DataBind();
                gvEmailList.Columns[1].Visible = false;
            }
            result = true;
            //pnlSearch.Visible = true;
            //pnlData.Visible = true;
            //pnlList.Visible = false;
            return result;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ResetControls();
            pnlSearch.Visible = true;
            pnlData.Visible = true;
            pnlList.Visible = false;
            hfEmailID.Value = "0";
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand();
            string Query;
            if (!string.IsNullOrEmpty(txtEmail.Text) && !string.IsNullOrEmpty(txtCreationDate.Text) && ddlNameUpdateAR.SelectedValue != "0")
            {
                if (Convert.ToInt32(hfEmailID.Value) > 0)
                {
                    //EDIT
                    Query = @"UPDATE [dbo].[EmailListTBL]
                              SET    [EmpID] = @EmpID, [ListName] = @ListName, [ListDesc] = @ListDesc, [CreationDate] = @CreationDate, [IsActive] = @IsActive
                              WHERE  EmailListTBL.[EmailListID] = @EmailListID";
                    cmd.Parameters.AddWithValue("@EmailListID", hfEmailID.Value);
                }
                else
                {
                    //NEW
                    Query = @"INSERT INTO [dbo].[EmailListTBL]
                                        ([EmpID], [ListName], [ListDesc], [CreationDate], [IsActive])
                              VALUES (@EmpID, @ListName, @ListDesc, @CreationDate, @IsActive)";
                }
                cmd.Parameters.AddWithValue("@EmpID", hfEmpID.Value);
                cmd.Parameters.AddWithValue("@ListName", txtEmail.Text);
                cmd.Parameters.Add("@CreationDate", System.Data.SqlDbType.Date);
                cmd.Parameters["@CreationDate"].Value = (txtCreationDate.Text);
                cmd.Parameters.AddWithValue("@IsActive", chbIsActive.Checked);
                cmd.Parameters.AddWithValue("@ListDesc", txtNotes.Text);
                cmd.CommandText = Query;
                if (MDirMaster.Execute(cmd, lblMessage, HttpContext.Current.Request.Path))
                {
                    ResetControls();
                    getdata();
                    pnlSearch.Visible = true;
                    pnlData.Visible = true;
                    pnlList.Visible = false;
                    hfEmailID.Value = "0";
                }
            }
            else
            {
                lblMessage.Text = "انت لوتي حبيبي! املي البيانات اول.";
            }
        }

        protected void ddlName_SelectedIndexChanged(object sender, EventArgs e)
        {

            DropDownList ddl = sender as DropDownList;
            if (ddl != null)
            {
                string SenderID = ddl.SelectedValue;

                MDirMaster.FillCombo("EmailID", "EmailName", "EmailsTBL", ddlEmail, "(EmpID = " + SenderID + ") AND (IsActive = 1 ) ", lblMessage);
            }
        }

        protected void gvEmailList_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            btnSubmit.Text = "تعديل";
            int index = e.NewSelectedIndex;
            try
            {
                int ID = Convert.ToInt32(gvEmailList.Rows[index].Cells[2].Text);
                hfEmailID.Value = ID.ToString();
                if (ID > 0)
                {
                    // get the data

                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = @"SELECT  [EmpID], [ListName], [ListDesc], [CreationDate], [IsActive]
                                        FROM    [HR].[dbo].[EmailListTBL]
                                        WHERE   [EmailListTBL].[EmailListID] = @EmailListID";
                    cmd.Parameters.AddWithValue("@EmailListID", ID);
                    hfListID.Value = ID.ToString();
                    DataTable dt = MDirMaster.GetData(cmd, lblMessage);
                    txtCreationDate.Text = Convert.ToDateTime(dt.Rows[0]["CreationDate"]).ToString("yyyy/MM/dd");
                    txtEmail.Text = dt.Rows[0]["ListName"].ToString();
                    txtNotes.Text = dt.Rows[0]["ListDesc"].ToString();
                    try
                    {
                        hfEmpID.Value = ddlNameUpdateAR.SelectedValue = ddlNameUpdateEN.SelectedValue = dt.Rows[0]["EmpID"].ToString();
                    }
                    catch
                    {
                        lblMessage.Text = "الشخص المسؤول عن القائمة ليس في قائمة الموظفيين الحاليين، يرجى اختيار موظف اخر. ";
                    }
                    chbIsActive.Checked = Convert.ToBoolean(dt.Rows[0]["IsActive"]);
                    SqlCommand cmdList = new SqlCommand();
                    cmdList.CommandText = @"SELECT   EmailListMembersTBL.EmailID, FirstNameAR + ' ' + MidNameAR + ' ' + LastNameAR as [اسم الموظف], EmailName as [البريد الألكتروني],
                                                     [AdditonDate] as [تاريخ الاضافة]
                                            FROM     [EmailListMembersTBL] 
                                            JOIN     EmailsTBL on EmailsTBL.EmailID = EmailListMembersTBL.EmailID
                                            JOIN     EmployeesTBL on EmployeesTBL.EmpID = EmailsTBL.EmpID
                                            WHERE    EmailListID = @EmailListID AND EmailListMembersTBL.IsActive = 1 AND EmailsTBL.IsActive =1
                                            ORDER BY [البريد الألكتروني]";
                    cmdList.Parameters.AddWithValue("@EmailListID", ID);
                    MDirMaster.FillGrid(cmdList, gvEmails, lblMessage);
                    pnlData.Visible = true;
                    pnlList.Visible = true;
                    pnlSearch.Visible = false;
                }
                //int index = e.NewSelectedIndex;
            }
            catch
            {
                MDirMaster.Messages(lblMessage, 0);
            }
        }

        protected void gvEmailList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView gv = sender as GridView;
            gv.PageIndex = e.NewPageIndex;
            gv.SelectedIndex = -1;
            getdata();
        }

        protected void ddlNameUpdate_SelectedIndexChanged(object sender, EventArgs e)
        {

            DropDownList ddl = sender as DropDownList;
            if (ddl != null)
            {
                string SenderID = ddl.SelectedValue;
                hfEmpID.Value = ddlNameUpdateAR.SelectedValue = ddlNameUpdateEN.SelectedValue = SenderID;
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

        protected void gvEmails_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int index = e.RowIndex;
            int EmailID = Convert.ToInt32(gvEmails.Rows[index].Cells[1].Text);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "UPDATE [EmailListMembersTBL] SET IsActive = 0, [RemovalDate] = GETDATE() WHERE [EmailID] = @EmailID AND [EmailListID] = @EmailListID AND IsActive = 1";
            cmd.Parameters.AddWithValue("@EmailID", EmailID);
            cmd.Parameters.AddWithValue("@EmailListID", hfListID.Value);

            MDirMaster.Execute(cmd, lblMessage, HttpContext.Current.Request.Path);
            ResetControls();
            int ID = Convert.ToInt32(hfEmailID.Value);
            SqlCommand cmdList = new SqlCommand();
            cmdList.CommandText = @"SELECT   EmailListMembersTBL.EmailID, FirstNameAR + ' ' + MidNameAR + ' ' + LastNameAR as [اسم الموظف], EmailName as [البريد الألكتروني],
                                                     [AdditonDate] as [تاريخ الاضافة]
                                            FROM     [EmailListMembersTBL] 
                                            JOIN     EmailsTBL on EmailsTBL.EmailID = EmailListMembersTBL.EmailID
                                            JOIN     EmployeesTBL on EmployeesTBL.EmpID = EmailsTBL.EmpID
                                            WHERE    EmailListID = @EmailListID AND EmailListMembersTBL.IsActive = 1 AND EmailsTBL.IsActive =1
                                            ORDER BY [البريد الألكتروني]";
            cmdList.Parameters.AddWithValue("@EmailListID", ID);
            MDirMaster.FillGrid(cmdList, gvEmails, lblMessage);
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = @"IF NOT EXISTS (SELECT 1 FROM [EmailListMembersTBL] WHERE [EmailListID]= @EmailListID AND [EmailID] = @EmailID AND IsActive = 1)
                                INSERT INTO [EmailListMembersTBL] 
                                            ([EmailListID], [EmailID])
                                     VALUES (@EmailListID, @EmailID)";
            cmd.Parameters.AddWithValue("@EmailListID", hfEmailID.Value);
            cmd.Parameters.AddWithValue("@EmailID", ddlEmail.SelectedValue);
            MDirMaster.Execute(cmd, lblMessage, HttpContext.Current.Request.Path);
            ResetControls();
            int ID = Convert.ToInt32(hfEmailID.Value);
            SqlCommand cmdList = new SqlCommand();
            cmdList.CommandText = @"SELECT   EmailListMembersTBL.EmailID, FirstNameAR + ' ' + MidNameAR + ' ' + LastNameAR as [اسم الموظف], EmailName as [البريد الألكتروني],
                                                     [AdditonDate] as [تاريخ الاضافة]
                                            FROM     [EmailListMembersTBL] 
                                            JOIN     EmailsTBL on EmailsTBL.EmailID = EmailListMembersTBL.EmailID
                                            JOIN     EmployeesTBL on EmployeesTBL.EmpID = EmailsTBL.EmpID
                                            WHERE    EmailListID = @EmailListID AND EmailListMembersTBL.IsActive = 1 AND EmailsTBL.IsActive =1
                                            ORDER BY [البريد الألكتروني]";
            cmdList.Parameters.AddWithValue("@EmailListID", ID);
            MDirMaster.FillGrid(cmdList, gvEmails, lblMessage);
        }

        protected void btnCancelMemebers_Click(object sender, EventArgs e)
        {

        }
    }
}