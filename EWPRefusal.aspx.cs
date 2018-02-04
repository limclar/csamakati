using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    string reason;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
             checkUsertype.filter("STUDENT", Session["UserType"].ToString());
        }
        catch(Exception ex)
        {
            Response.Redirect("Out.aspx");
        }
    }

    protected void CheckBoxList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (CheckBoxList1.SelectedIndex == 6)
        {
            txtOthers.Enabled = true;
            
        }
        else
        {
            txtOthers.Text = "";
            txtOthers.Enabled = false;
        }   
    }

    protected void btnsubmitEWP_Click(object sender, EventArgs e)
    {
        if (CheckBoxList1.SelectedIndex == 6)
            reason = txtOthers.Text;
        else
            reason = CheckBoxList1.Text;

        SqlCommand cmdEWPRefuse = new SqlCommand("INSERT INTO[dbo].[EWPRefusal] VALUES( " + Session["StudentNumber"] + ", '" + DateTime.Now.ToString().Split(' ')[0] + "', '" + reason + "', '" + Session["SYTerm"] + "')");
        Class2.exe(cmdEWPRefuse);
        Response.Redirect("StudentAnnouncements.aspx");

        
    }
}
