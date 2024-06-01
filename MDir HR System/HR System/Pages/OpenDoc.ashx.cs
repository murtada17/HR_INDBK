using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Net;
using System.Web.SessionState;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace HR_Salaries.Pages
{
    /// <summary>
    /// Summary description for OpenDoc1
    /// </summary>
    public class OpenDoc1 : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            if ((HttpContext.Current.Session["UserID"] != null) && (Convert.ToBoolean(HttpContext.Current.Session["Logged"])))
            {
                string type = context.Request.QueryString["FT"];
                string fileName = context.Request.QueryString["FP"];
                string path = context.Server.MapPath(MDirMaster.Path + fileName + "." + type);
                if (File.Exists(path))
                {
                    WebClient client = new WebClient();
                    Byte[] buffer = client.DownloadData(path);
                    context.Response.ContentType = "application/pdf";
                    context.Response.AddHeader("content-length", buffer.Length.ToString());
                    context.Response.BinaryWrite(buffer);
                    context.Response.End();
                }
                else
                {
                    context.Response.Write("<br/><br/><div class=\"row\" style=\"text-align: center; font-size: larger;background-color: #FF0000; color: white;\"> عذرا، الملف المطلوب قد يكون مفقودا، يرجى إعادة المحاولة.</div>");
                }

            }

            else
            {
                HttpContext.Current.Session["Handler"] = context.Request.Url;
                context.Response.Redirect("~/Pages/User/Login.aspx", false);
            }
        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}