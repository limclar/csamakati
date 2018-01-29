using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnChangePass_Click(object sender, EventArgs e)
    {
        String oPass = Class2.getSingleData("SELECT [password] FROM [USER] WHERE [UserId] = " + Session["UserId"]);  
        if((oPass == tboxOPass.Text) && (tboxNPass.Text == tboxRPass.Text))
        {
            SqlCommand cmdChngPass = new SqlCommand("UPDATE [dbo].[USER] SET [Password] = '" + tboxNPass.Text + "' WHERE [UserId] = " + Session["UserId"]);
            Class2.exe(cmdChngPass);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Password has been changed.');window.location ='ChangePassword.aspx';", true);
        }
        else
        {
           ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Password does not match.');window.location ='ChangePassword.aspx';", true);
        }
    }
}
