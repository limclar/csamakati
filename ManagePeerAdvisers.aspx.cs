using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
            checkUsertype.filter("STAFF", Session["UserType"].ToString());
        }
        catch(Exception ex)
        {
            Response.Redirect("Out.aspx");
        }
        
        if(!IsPostBack)
        {

            fillLView("ACTIVE");
            Session["PArchive"] = "NO";
            ddlSubj.SelectedIndex = 0;
            tboxSKey.Text = "";

            ddlStudNum.DataSource = Class2.getDataSet("SELECT dbo.Student.StudentNumber FROM  dbo.Student WHERE  NOT EXISTS (SELECT dbo.PeerAdviser.StudentNumber  FROM   dbo.PeerAdviser  WHERE  dbo.PeerAdviser.StudentNumber = dbo.Student.StudentNumber and STATUS = 'ACTIVE')");
            ddlStudNum.DataValueField = "StudentNumber";
            ddlStudNum.DataTextField = "StudentNumber";
            ddlStudNum.DataBind();

            ddlOrg.DataSource = Class2.getDataSet("SELECT * FROM [dbo].[Organization]");
            ddlOrg.DataValueField = "OrganizationId";
            ddlOrg.DataTextField = "OrganizationName";
            ddlOrg.DataBind();

            ddlTeachSubject.DataSource = Class2.getDataSet("SELECT DISTINCT SubjectType FROM[dbo].[Subjects]");
            ddlTeachSubject.DataValueField = "SubjectType";
            ddlTeachSubject.DataTextField = "SubjectType";
            ddlTeachSubject.DataBind();
        }     
    }
    
    protected void moveToArchive(object sender, EventArgs e)
    {
        string confirmValue = Request.Form["confirm_value"];
        if (confirmValue == "Yes")
        {
            Session["Selected"] = "";
            foreach (ListViewItem item in ListViewPAdvisers.Items)
            {
                CheckBox box = (CheckBox)item.FindControl("chkSelect") as CheckBox;
                if (box.Checked)
                {
                  Label mylabel = (Label)item.FindControl("lblPId");
                  Session["Selected"] += mylabel.Text + ";";

                  if(Session["PArchive"] == "NO")
                    updateStatus("INACTIVE", int.Parse(mylabel.Text));
                  else
                    updateStatus("ACTIVE", int.Parse(mylabel.Text));
                }
            }
            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Adviser(s) are now on archive.');window.location ='ManagePeerAdvisers.aspx';", true);
        } 
    }
    
    public void updateStatus(string act, int Id)
    {
            
        SqlCommand cmdUser = new SqlCommand("UPDATE[dbo].[PeerAdviser] SET [Status] = '" + act + "' WHERE PAdviserId = " + Id);
        Class2.exe(cmdUser);
    }
    
    protected void showArchive(object sender, EventArgs e)
    {
        if(Session["PArchive"] == "NO")
        {
            fillLView("INACTIVE");
            Session["PArchive"] = "YES";
        }
        else
        {
            fillLView("ACTIVE");
            Session["PArchive"] = "NO";
        }
    }

    public void fillLView(string stat)
    {
         SqlCommand cmd = new SqlCommand("SELECT dbo.PeerAdviser.TeachingSubject, dbo.PeerAdviser.PAdviserId, dbo.PeerAdviser.StudentNumber, dbo.Student.StudentName, dbo.PeerAdviser.OrganizationId, dbo.PeerAdviser.Status, CONVERT(date, dbo.PeerAdviser.DateRegistered) AS DateReg, dbo.PeerAdviser.Contact FROM dbo.Student INNER JOIN dbo.PeerAdviser ON dbo.Student.StudentNumber = dbo.PeerAdviser.StudentNumber WHERE STATUS = '" + stat + "'");
         ListViewPAdvisers.DataSource = Class2.getDataSet(cmd);
         ListViewPAdvisers.DataBind();
    }

    protected void btnAddPeerAdvisers_Click(object sender, EventArgs e)
    {
        if(btnAddPeerAdviser.Text == "UPDATE ADVISER")
        {
            SqlCommand cmdEdAdv = new SqlCommand("UPDATE [dbo].[PeerAdviser] SET [OrganizationId] = " + ddlOrg.SelectedValue + ", [TeachingSubject] = '" + ddlTeachSubject.Text + "', [Status] = 'ACTIVE' WHERE PAdviserId = " + Session["PAId"]);
            Class2.exe(cmdEdAdv);
            SqlCommand cmdEdStud = new SqlCommand("UPDATE [dbo].[Student] SET Contact = '" + tboxCNum.Text + "' WHERE StudentNumber = " + Session["SNum"]);
            Class2.exe(cmdEdStud);
             
        }
        else
        {
        try
        {
            SqlCommand cmdPeer = new SqlCommand("[sp_t_PeerAdviser_ups]");
            cmdPeer.CommandType = CommandType.StoredProcedure;
            cmdPeer.Parameters.Add("@PAdviserId", SqlDbType.NVarChar).Value = "0";
            cmdPeer.Parameters.Add("@StudentNumber", SqlDbType.NVarChar).Value = ddlStudNum.SelectedValue;
            cmdPeer.Parameters.Add("@OrganizationId", SqlDbType.NVarChar).Value = ddlOrg.SelectedValue;
            cmdPeer.Parameters.Add("@TeachingSubject", SqlDbType.NVarChar).Value = ddlTeachSubject.Text.Trim();
            cmdPeer.Parameters.Add("@Status", SqlDbType.NVarChar).Value = ddlStatus.Text.Trim();
            cmdPeer.Parameters.Add("@DateRegistered", SqlDbType.NVarChar).Value = DBNull.Value;
            cmdPeer.Parameters.Add("@PeerSchedule", SqlDbType.NVarChar).Value = ';';
            cmdPeer.Parameters.Add("@Contact", SqlDbType.NVarChar).Value = Class2.getSingleData("SELECT [contact] from [student] where [studentnumber] = " + ddlStudNum.SelectedValue);
            Literal1.Text = " <script> alert('USER CREATION SUCCESSFUL.'); </script>";
            Class2.exe(cmdPeer);
        }
        catch(Exception ex)
        {
            Literal1.Text = " <script> alert('FAILED TO ADD A PEER ADVISER. " + ex + "'); </script>";
        }
        }
        Response.Redirect("ManagePeerAdvisers.aspx");
    }

    public void openPopup(object sender, EventArgs e)
    {
        btnAddPeerAdviser.Text = "ADD ADVISER";
        ScriptManager.RegisterStartupScript(this, typeof(string), "uniqueKey", "div_show()", true);
        ddlStudNum.Enabled = true;
        ddlStatus.Enabled = true;
        trSNum.Visible = true;
        popStatus.Visible = true;
    }
    
    public void searchKey(object sender, EventArgs e)
    {
         if(ddlSubj.SelectedIndex != 0)
             sortBySubject(Session["SearchBy"].ToString(), tboxSKey.Text);
         else
         {
              int i = 0;
              Session["SearchBy"] = "dbo.PeerAdviser.TeachingSubject,dbo.PeerAdviser.StudentNumber,dbo.Student.StudentName,dbo.Student.Contact, (SELECT OrganizationName from dbo.Organization where dbo.Organization.OrganizationId = dbo.PeerAdviser.OrganizationId)";
              do
              {
                  sortBySubject(Session["SearchBy"].ToString().Split(',')[i], tboxSKey.Text);
                  i++;
              }while(ListViewPAdvisers.Items.Count == 0 && i <= 4);
         }
    }

    public void sortBySubj(object sender, EventArgs e)
    {
        if(ddlSubj.SelectedIndex == 1)
           Session["SearchBy"] = "dbo.PeerAdviser.TeachingSubject";
        else if(ddlSubj.SelectedIndex == 2)
           Session["SearchBy"] = "dbo.PeerAdviser.StudentNumber";
        else if(ddlSubj.SelectedIndex == 3)
           Session["SearchBy"] = "dbo.Student.StudentName";
        else if(ddlSubj.SelectedIndex == 4)
           Session["SearchBy"] = "(SELECT OrganizationName from dbo.Organization where dbo.Organization.OrganizationId = dbo.PeerAdviser.OrganizationId)";
        else if(ddlSubj.SelectedIndex == 5)
           Session["SearchBy"] = "dbo.Student.Contact";
        
        if(Session["PArchive"] == "NO")
            fillLView("ACTIVE");
        else
            fillLView("INACTIVE");
         
         tboxSKey.Text = "";
    }

    public void sortBySubject(string column, string key)
    {
        string act;
        if(Session["PArchive"] == "NO")
            act = "ACTIVE";
        else
            act = "INACTIVE";
            
        SqlCommand cmd = new SqlCommand("SELECT dbo.PeerAdviser.TeachingSubject, dbo.PeerAdviser.PAdviserId, dbo.PeerAdviser.StudentNumber, dbo.Student.StudentName, dbo.PeerAdviser.OrganizationId, dbo.PeerAdviser.Status, CONVERT(date, dbo.PeerAdviser.DateRegistered) AS DateReg, dbo.PeerAdviser.Contact FROM dbo.Student INNER JOIN dbo.PeerAdviser ON dbo.Student.StudentNumber = dbo.PeerAdviser.StudentNumber WHERE STATUS = '" + act + "' AND " + column + " LIKE '%" + key + "%'");

        ListViewPAdvisers.DataSource = Class2.getDataSet(cmd);
        ListViewPAdvisers.DataBind();
    }


   public void sortByAll(object sender, EventArgs e)
   {
       SqlCommand cmd = new SqlCommand("SELECT dbo.PeerAdviser.TeachingSubject, dbo.PeerAdviser.PAdviserId, dbo.PeerAdviser.StudentNumber, dbo.Student.StudentName, dbo.PeerAdviser.OrganizationId, dbo.PeerAdviser.Status, CONVERT(date, dbo.PeerAdviser.DateRegistered) AS DateReg, dbo.PeerAdviser.Contact FROM dbo.Student INNER JOIN dbo.PeerAdviser ON dbo.Student.StudentNumber = dbo.PeerAdviser.StudentNumber WHERE STATUS = 'ACTIVE'");

            ListViewPAdvisers.DataSource = Class2.getDataSet(cmd);
            ListViewPAdvisers.DataBind();
   }

    protected void ListViewPAdvisers_ItemCommand(object sender, ListViewCommandEventArgs e)
    {
        if (e.CommandName == "DeletePeer")
        {
            SqlCommand cmdUser = new SqlCommand("UPDATE[dbo].[PeerAdviser] SET [Status] = 'INACTIVE' WHERE PAdviserId =" + e.CommandArgument);
            Class2.exe(cmdUser);
            Response.Redirect("ManagePeerAdvisers.aspx");
        }
        else if(e.CommandName == "UpdatePeer")
        {
            Session["PAId"] = e.CommandArgument;
            btnAddPeerAdviser.Text = "UPDATE ADVISER";
            ddlStudNum.Enabled = false;
            popStatus.Visible = false;
            ddlStatus.Enabled = false;
            String adv = Class2.getSingleData("SELECT (CONVERT(varchar(10),dbo.PeerAdviser.OrganizationId) + ';' +CONVERT(varchar(10), dbo.PeerAdviser.TeachingSubject) + ';' +  CONVERT(varchar(11),dbo.Student.Contact) + ';' + CONVERT(varchar(10),dbo.Student.StudentNumber)) FROM dbo.[PeerAdviser] INNER JOIN dbo.[Student] ON dbo.PeerAdviser.StudentNumber = dbo.Student.StudentNumber WHERE [PAdviserId] = " + e.CommandArgument);
            ddlOrg.SelectedIndex = Convert.ToInt32(adv.Split(';')[0]) - 1;
            ddlTeachSubject.Text = adv.Split(';')[1];
            tboxCNum.Text = adv.Split(';')[2];
            trSNum.Visible = false;
            Session["SNum"] = adv.Split(';')[3];
            ScriptManager.RegisterStartupScript(this, typeof(string), "uniqueKey", "div_show()", true);
            btnAddPeerAdviser.Text = "UPDATE ADVISER";
        }
    }
}




