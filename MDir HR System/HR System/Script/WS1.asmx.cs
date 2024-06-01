using HR_Salaries;
using System;
using System.Data.SqlClient;
using System.Web.Script.Services;
using System.Web.Services;

namespace HR_Salaries.Script
{
    /// <summary>
    /// Summary description for WS1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WS1 : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        [WebMethod (EnableSession = true)]
        [ScriptMethod]
        public int AddLicense(string LicenseNameAR, string LicenseNameEN)
        {
            System.Web.UI.WebControls.Label label = new System.Web.UI.WebControls.Label();
            int Done = -1;
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = @"SELECT COUNT(*) FROM LicenseNameTBL WHERE LicenseNameAR= @LicenseNameAR";
            cmd.Parameters.AddWithValue("@LicenseNameAR", LicenseNameAR);
            cmd.Parameters.AddWithValue("@LicenseNameEN", LicenseNameEN);
            if (Convert.ToInt32(MDirMaster.ExecuteScaler(cmd, label, "Employee")) == 0)
            {
                cmd.CommandText = @"INSERT INTO [LicenseNameTBL] ([LicenseNameAR], [LicenseNameEN],[IsActive])
                                                   VALUES (@LicenseNameAR, @LicenseNameEN, 1)";
            }
            else
            {
                label.Text = " هذه المؤسسة موجوده حاليا. ";
                Done = 0;
            }
            if (MDirMaster.Execute(cmd, label, "Employee"))
            {
                Done = 1;
            }
            return Done;
        }
    }
}
