using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace HR_Salaries
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {

        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {
            //Response.Redirect(HttpContext.Current.Request.Path);
            try
            {
                string lcReqPath = Request.Path.ToString().ToLower();

                // Session is not stable in AcquireRequestState - Use Current.Session instead.
                System.Web.SessionState.HttpSessionState curSession = HttpContext.Current.Session;

                // If we do not have a OK Logon (remember Session["LogonOK"] = null; on logout, and set to true on logon.)
                //  and we are not already on loginpage, redirect.

                // note: on missing pages curSession is null, Test this without 'curSession == null || ' and catch exception.
                if (lcReqPath != "/pages/users/login.aspx" &&
                    (curSession == null || curSession["Logged"] == null))
                {
                    // Redirect nicely
                    Context.Server.ClearError();
                    Context.Response.AddHeader("Location", "~/pages/users/login.aspx");
                    Context.Response.TrySkipIisCustomErrors = true;
                    Context.Response.StatusCode = (int)System.Net.HttpStatusCode.Redirect;
                    // End now end the current request so we dont leak.
                    Context.Response.Output.Close();
                    Context.Response.End();
                    return;
                }
            }
            catch (Exception)
            {

                // todo: handle exceptions nicely!
            }
        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}