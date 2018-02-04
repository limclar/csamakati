using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
         try
        {
            checkUsertype.filter("STUDENT", Session["UserType"].ToString());
        }
        catch(Exception ex)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('You have been inactive for too long. Please relogin.');window.location ='Out.aspx';", true);
        }

        string cStatus = Class2.getSingleData("SELECT CurrentStatus FROM [dbo].[StudentStatus] WHERE StudentNumber = " + Session["StudentNumber"]);

        if (cStatus.Trim() == "EWP" && Class2.getSingleData("SELECT COUNT(*) FROM StudentStatus JOIN EWPRefusal ON StudentStatus.StudentNumber = EWPRefusal.StudentNumber WHERE EWPRefusal.StudentNumber = " + Session["StudentNumber"] + " AND EWPRefusal.SYTerm = '" + Session["SYTerm"] + "'") == "0")
            ewpAnn.Visible = true;
        else
            ewpAnn.Visible = false;
    }
}
