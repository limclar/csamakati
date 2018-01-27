using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
       {
            if (Session["Userid"] == null)
            {
                Response.Redirect("In.aspx");
            }

            if (Session["UserType"].ToString().ToUpper() == "FACULTY")
            {
                sidebarFaculty.Visible = true; sidebarStaff.Visible = false; sidebarStudent.Visible = false;
            }
            else if (Session["UserType"].ToString().ToUpper() == "STAFF")
            {
                sidebarFaculty.Visible = false; sidebarStaff.Visible = true; sidebarStudent.Visible = false;
            }
            else if (Session["UserType"].ToString().ToUpper() == "STUDENT")
            {
                sidebarFaculty.Visible = false; sidebarStaff.Visible = false; sidebarStudent.Visible = true;
            }

            
        }
        catch (Exception ex)
        {
            Response.Redirect("In.aspx");
        }
    }
}