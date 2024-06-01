using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HR_Salaries.Reports
{
    public partial class FileSalarie : System.Web.UI.Page
    {
        string Datetime = DateTime.Now.ToString("dd-MM-yyyy hh:ss:mm");

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
                    MDirMaster.FillCombo("BranchID", "BranchDescAR", "BranchsTBL", ddlSBranchUplo, true, lblMessage);
                    if (Session["depID"].ToString() == "9" || Session["UserName"].ToString() == "moh")
                    {
                        PnUpload.Visible = true;
                        PnDown.Visible = false;
                    }
                    else
                    {
                        PnDown.Visible = true;
                        PnUpload.Visible = false;
                    }
                }
            }
        }
        protected void btnUpload_Click(object sender, EventArgs e)
        {
            if (fuDocs.HasFile)
            {

                HttpPostedFile uploadfile = fuDocs.PostedFile;
                string fileType = uploadfile.ContentType;
                if (fileType == "application/pdf")
                {
                    var rand = new Random();
                    var uid = rand.Next(1, 1000000);

                    string fileName = ddlSBranchUplo.SelectedItem.ToString() + uploadfile.FileName.Substring(uploadfile.FileName.LastIndexOf('.'));
                    string fileNameMove = uid + ddlSBranchUplo.SelectedItem.ToString() + Session["UserName"].ToString() + uploadfile.FileName.Substring(uploadfile.FileName.LastIndexOf('.'));
                    string DocFullPath = Server.MapPath(@"~\Reports\Det" + ddlConEmp.SelectedValue + @"\" + fileName);
                    string DocFullPathMOve = Server.MapPath(@"~\Reports\His" + ddlConEmp.SelectedValue + @"\" + fileNameMove);
                    FileInfo file = new FileInfo(DocFullPath);
                    FileInfo fileMove = new FileInfo(DocFullPathMOve);

                    if (file.Exists)//check file exsit or not  
                    {
                        file.Delete();
                    }
                    else
                    {
                        lblMessage.Text = fileName + " This file does not Delete ";
                    }

                    if (System.IO.File.Exists(DocFullPath))
                    {
                        lblMessage.Text = fileName + " This file does not Upload ";
                    }
                    else
                    {
                        if (uploadfile.ContentLength > 0)
                        {
                            uploadfile.SaveAs(DocFullPath);
                            uploadfile.SaveAs(DocFullPathMOve);
                            lblMessage.Text = fileName + "تم تحميل الفايل";

                        }
                    }
                }

            }
        }

        protected void btnDown_Click(object sender, EventArgs e)
        {
            try
            {
                string fileName = ddlSBranchUplo.SelectedItem.ToString();
                string DocFullPath = Server.MapPath(@"~\Reports\Det" + ddlConEmp.SelectedValue + @"\" + fileName + ".pdf");
                FileInfo file = new FileInfo(DocFullPath);
                if (file.Exists)
                {
                    // Clear Rsponse reference  
                    Response.Clear();
                    // Add header by specifying file name  
                    Response.AddHeader("Content-Disposition", "attachment; filename=" + file.Name);
                    // Add header for content length  
                    Response.AddHeader("Content-Length", file.Length.ToString());
                    // Specify content type  
                    Response.ContentType = "text/plain";
                    // Clearing flush  
                    Response.Flush();
                    // Transimiting file  
                    Response.TransmitFile(file.FullName);
                    Response.End();
                }
                else lblMessage.Text = "لم يتم رفع الملف";
            }
            catch (IOException)
            {
            }
        }
    }
}