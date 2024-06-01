using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MDir_DMS.Pages.Courses
{
    public partial class Courses : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void gvCourses_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void gvCourses_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {

        }

        protected void gvCourseEmp_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void gvCourseEmp_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {

        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {

        }

        protected void RBAdd_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            if (rb.ID == "RBAdd")
            {
                pGrid.Visible = false;
                pForm.Visible = true;
                btnSubmit.Text = "إضافة";
            }
            else if (rb.ID == "RBEdit")
            {
                pGrid.Visible = true;
                pForm.Visible = false;
                btnSubmit.Text = "تعديل";
            }
        }
    }
}