using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
        
        checkUsertype.filter("STAFF", Session["UserType"].ToString());
        
        if(!IsPostBack)
        {
            SqlCommand cmd = new SqlCommand("SELECT StaffId, LName + ', ' + FName + ' (' + MName + ')' as FullName, Status, DateRegistered FROM dbo.Staff WHERE STATUS = 'ACTIVE'");
            ListViewStaff.DataSource = Class2.getDataSet(cmd);
            ListViewStaff.DataBind();
            Session["SArchive"] = "NO";
        } 
    }
    
    protected void moveToArchive(object sender, EventArgs e)
    {
        string confirmValue = Request.Form["confirm_value"];
        if (confirmValue == "Yes")
        {
            Session["Selected"] = "";
            foreach (ListViewItem item in ListViewStaff.Items)
            {
                CheckBox box = (CheckBox)item.FindControl("chkSelect") as CheckBox;
                if (box.Checked)
                {
                  Label mylabel = (Label)item.FindControl("lblSId");
                  Session["Selected"] += mylabel.Text + ";";

                  if(Session["SArchive"] == "NO")
                    updateStatus("INACTIVE", int.Parse(mylabel.Text));
                  else
                    updateStatus("ACTIVE", int.Parse(mylabel.Text));
                }
            }
            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('User(s) are now on archive.');window.location ='ManageStaff.aspx';", true);
        }

    }
    
    public void updateStatus(string act, int Id)
    {
            
        SqlCommand cmdUser = new SqlCommand("UPDATE[dbo].[Staff] SET [Status] = '" + act + "' WHERE StaffId =" + Id);
        Class2.exe(cmdUser);
    }

    protected void showArchive(object sender, EventArgs e)
    {
        if(Session["SArchive"] == "NO")
        {
            SqlCommand cmd = new SqlCommand("SELECT StaffId, LName + ', ' + FName + ' (' + MName + ')' as FullName, Status, DateRegistered FROM dbo.Staff WHERE STATUS = 'INACTIVE'");
            ListViewStaff.DataSource = Class2.getDataSet(cmd);
            ListViewStaff.DataBind();
            Session["SArchive"] = "YES";
        }
        else
        {
            SqlCommand cmd2 = new SqlCommand("SELECT StaffId, LName + ', ' + FName + ' (' + MName + ')' as FullName, Status, DateRegistered FROM dbo.Staff WHERE STATUS = 'ACTIVE'");
            ListViewStaff.DataSource = Class2.getDataSet(cmd2);
            ListViewStaff.DataBind();
            Session["SArchive"] = "NO";
        }
    }

    protected void btnAddStaff_Click(object sender, EventArgs e)
    {
        if(btnAddStaff.Text == "UPDATE STAFF")
        {
            SqlCommand cmdEdSt = new SqlCommand("UPDATE [dbo].[Staff] SET [FName] = '" + tboxFName.Text + "', [MName] = '" + tboxMName.Text + "', [LName] = '" + tboxLName.Text + "' WHERE PAdviserId = " + Session["SId"]);
            Class2.exe(cmdEdSt);
        }
        else
        {
            try
            {
                Literal1.Text = " <script> alert('FAILED TO ADD A STAFF'); </script>";
                SqlCommand cmdUser = new SqlCommand("[sp_t_User_ups]");
                cmdUser.CommandType = CommandType.StoredProcedure;
                cmdUser.Parameters.Add("@UserId", SqlDbType.NVarChar).Value = "0";
                cmdUser.Parameters.Add("@UserType", SqlDbType.NVarChar).Value = "STAFF";
                cmdUser.Parameters.Add("@Username", SqlDbType.NVarChar).Value = tboxUsername.Text;
                cmdUser.Parameters.Add("@Password", SqlDbType.NVarChar).Value = "";
                Class2.exe(cmdUser);

                SqlCommand cmdStaff = new SqlCommand("[sp_t_Staff_ups]");
                cmdStaff.CommandType = CommandType.StoredProcedure;
                cmdStaff.Parameters.Add("@StaffId", SqlDbType.NVarChar).Value = "0";
                cmdStaff.Parameters.Add("@LName", SqlDbType.NVarChar).Value = tboxLName.Text;
                cmdStaff.Parameters.Add("@MName", SqlDbType.NVarChar).Value = tboxMName.Text;
                cmdStaff.Parameters.Add("@FName", SqlDbType.NVarChar).Value = tboxFName.Text;
                cmdStaff.Parameters.Add("@Status", SqlDbType.NVarChar).Value = ddlStatus.Text;
                cmdStaff.Parameters.Add("@UserId", SqlDbType.NVarChar).Value = DBNull.Value;
                cmdStaff.Parameters.Add("@DateRegistered", SqlDbType.NVarChar).Value = DBNull.Value;
                Class2.exe(cmdStaff);

                Literal1.Text = " <script> alert('USER CREATION SUCCESSFUL.'); </script>";
            }
            catch
            {
                Literal1.Text = " <script> alert('FAILED TO ADD A STAFF.'); </script>";
            }
        }
        Response.Redirect("ManageStaff.aspx");
    }

    protected void ListViewStaff_ItemCommand(object sender, ListViewCommandEventArgs e)
    {
        if (e.CommandName == "UpdateStaff")
        {
            Session["SId"] = e.CommandArgument;
            btnAddStaff.Text = "UPDATE STAFF";
            popStat.Visible = false;
            popUname.Visible = false;
            String adv = Class2.getSingleData("SELECT LName + ';' + MName + ';' + FName FROM STAFF WHERE [StaffId] = " + e.CommandArgument);
            tboxLName.Text = adv.Split(';')[0];
            tboxMName.Text = adv.Split(';')[1];
            tboxFName.Text = adv.Split(';')[2];
            Session["SNum"] = adv.Split(';')[3];
            ScriptManager.RegisterStartupScript(this, typeof(string), "uniqueKey", "div_show()", true);
            btnAddStaff.Text = "UPDATE STAFF";
            Response.Redirect("ManageStaff.aspx");
        }
    }
}
