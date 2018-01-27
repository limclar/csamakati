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
        checkUsertype.filter("STUDENT", Session["UserType"].ToString());
        string cStatus = Class2.getSingleData("SELECT CurrentStatus FROM [dbo].[StudentStatus] WHERE StudentNumber = " + Session["StudentNumber"]);

        if (cStatus.Trim() == "EWP")
            ewpAnn.Visible = true;
        else
            ewpAnn.Visible = false;
    }
}