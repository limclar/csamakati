using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Configuration;
using System.Net;

using System.Configuration;
using Twilio;
using System.Threading.Tasks;
using System.IO;

public partial class _Default : System.Web.UI.Page
{
    HtmlTableCell yesEWP;
    HtmlTableCell noEWP;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                checkUsertype.filter("STAFF", Session["UserType"].ToString());
            }
            catch(Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('You have been inactive for too long. Please relogin.');window.location ='Out.aspx';", true);
            }

            populateListView();
            ddlPA1.DataSource = Class2.getDataSet("SELECT dbo.Student.StudentName, dbo.PeerAdviser.PAdviserId FROM dbo.PeerAdviser INNER JOIN dbo.Student ON dbo.PeerAdviser.StudentNumber = dbo.Student.StudentNumber");
            ddlPA1.DataValueField = "PAdviserId";
            ddlPA1.DataTextField = "StudentName";
            ddlPA1.DataBind();

            ddlPA2.DataSource = Class2.getDataSet("SELECT dbo.Student.StudentName, dbo.PeerAdviser.PAdviserId FROM dbo.PeerAdviser INNER JOIN dbo.Student ON dbo.PeerAdviser.StudentNumber = dbo.Student.StudentNumber");
            ddlPA2.DataValueField = "PAdviserId";
            ddlPA2.DataTextField = "StudentName";
            ddlPA2.DataBind();
            
            ddlPA3.DataSource = Class2.getDataSet("SELECT dbo.Student.StudentName, dbo.PeerAdviser.PAdviserId FROM dbo.PeerAdviser INNER JOIN dbo.Student ON dbo.PeerAdviser.StudentNumber = dbo.Student.StudentNumber");
            ddlPA3.DataValueField = "PAdviserId";
            ddlPA3.DataTextField = "StudentName";
            ddlPA3.DataBind();
        }
    }
    
    protected void ListViewSAttendance_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        SqlCommand cmdEWP = new SqlCommand("SELECT ConsultationType FROM PeerAdviserConsultations WHERE [PConsultationId] = " + Request.QueryString["aId"]);
       
        yesEWP = (HtmlTableCell)e.Item.FindControl("yesEWP");
        noEWP = (HtmlTableCell)e.Item.FindControl("noEWP");
        
        if(Class2.getSingleData(cmdEWP) == "EWP")
        {
            noEWP.Visible = false;
            yesEWP.Visible = true;
        }
        else
        {
            noEWP.Visible = true;
            yesEWP.Visible = false;
        }
    }

    public void populateListView()
    {
        SqlCommand cmd = new SqlCommand("SELECT * FROM [dbo].[PeerAdviserConsultations] WHERE Status = 'ON-GOING'");

        ListViewSAttendance.DataSource = Class2.getDataSet(cmd);
        ListViewSAttendance.DataBind();
        
    }

    protected void btnUpdateAdvisers_Click(object sender, EventArgs e) //for updating peer advisers
    {
        SqlCommand cmdUser = new SqlCommand("UPDATE [dbo].[PeerAdviserConsultations] SET [PAdviserId] = " + ddlPA1.SelectedValue + ", PeerAdviser2 = " + ddlPA2.SelectedValue + ", PeerAdviser3 = " + ddlPA3.SelectedValue + " WHERE [PConsultationId] =  " + Request.QueryString["aId"]);
        Class2.exe(cmdUser);
        populateListView();
    }

    protected void btnUpdateTimeStart_Click(object sender, EventArgs e)
    {
        Session["TStart"] = Class2.getSingleData("SELECT ConsultationType FROM PeerAdviserConsultations WHERE [PConsultationId] = " + Request.QueryString["aId"]);
        SqlCommand cmdUser = new SqlCommand("UPDATE [dbo].[PeerAdviserConsultations] SET [TimeStart] = CONVERT(char(5), convert(char(8), DATEADD(hour,8,GETUTCDATE()), 108) WHERE [PConsultationId] =  " + Request.QueryString["aId"]);
        Class2.exe(cmdUser);
        populateListView();
    }

    protected void btnUpdateTimeEnd_Click(object sender, EventArgs e) // save nadin status done
    {   
        if(noEWP.Visible == true)
        {
            SqlCommand cmdUser = new SqlCommand("UPDATE [dbo].[PeerAdviserConsultations] SET Status = 'DONE', [TimeEnd] = convert(char(8), DATEADD(hour,8,GETUTCDATE()), 108) WHERE [PConsultationId] = " + Request.QueryString["aId"]);
            Class2.exe(cmdUser);
            populateListView();
            ScriptManager.RegisterStartupScript(this, typeof(string), "Message", "if(confirm('Do you really want to end the consultation?')){alert('Consultation is now done! Please take the evaluation.'); window.location ='StudentSessionEvaluation.aspx?aId=" + Request.QueryString["aId"] + "';}else{}",true);
        }
        else
        {
            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "Yes")
            {
                SqlCommand cmdUP = new SqlCommand("UPDATE [dbo].[PeerAdviserConsultations] SET Status = 'DONE', [TimeEnd] = convert(char(8), DATEADD(hour,8,GETUTCDATE()), 108) WHERE [PConsultationId] = " + Request.QueryString["aId"]);
                Class2.exe(cmdUP);
                SqlCommand cmdSel = new SqlCommand("SELECT SYTerm + ';' + CAST(StudentNumber AS VARCHAR(10))+ ';' + CourseCode + ';' + CAST(PAdviserId AS VARCHAR(10))+ ';' + LEFT(CONVERT(VARCHAR, dateadd(hour,8,getutcdate()) + 7, 101), 10) + ';' + CAST(TimeStart AS VARCHAR(10)) FROM [dbo].[PeerAdviserConsultations] WHERE [PConsultationId] = " + Request.QueryString["aId"]);
                string var = Class2.getSingleData(cmdSel);
                SqlCommand cmdUser = new SqlCommand("[sp_t_PConsultation_ups]");
                cmdUser.CommandType = CommandType.StoredProcedure;
                cmdUser.Parameters.Add("@PConsultationId", SqlDbType.NVarChar).Value = "0";
                cmdUser.Parameters.Add("@SYTerm", SqlDbType.NVarChar).Value = var.Split(';')[0];
                cmdUser.Parameters.Add("@StudentNumber", SqlDbType.NVarChar).Value = var.Split(';')[1];
                cmdUser.Parameters.Add("@ConsultationType", SqlDbType.NVarChar).Value = "EWP";
                cmdUser.Parameters.Add("@CourseCode", SqlDbType.NVarChar).Value = var.Split(';')[2];
                cmdUser.Parameters.Add("@Status", SqlDbType.NVarChar).Value = "PENDING";
                cmdUser.Parameters.Add("@PAdviserId", SqlDbType.NVarChar).Value = var.Split(';')[3];
                cmdUser.Parameters.Add("@PeerAdviser2", SqlDbType.NVarChar).Value = DBNull.Value;
                cmdUser.Parameters.Add("@PeerAdviser3", SqlDbType.NVarChar).Value = DBNull.Value;
                cmdUser.Parameters.Add("@ConsultationDate", SqlDbType.NVarChar).Value = var.Split(';')[4];
                cmdUser.Parameters.Add("@TimeStart", SqlDbType.NVarChar).Value = var.Split(';')[5];
                cmdUser.Parameters.Add("@TimeEnd", SqlDbType.NVarChar).Value = DBNull.Value;
                Class2.exe(cmdUser);
                 ScriptManager.RegisterStartupScript(this, typeof(string), "Message", "alert('Scheduling is now done! Please take the evaluation for the last consultation.'); window.location ='StudentSessionEvaluation.aspx?aId=" + Request.QueryString["aId"] + "';",true);
            }
            else
            {
                SqlCommand cmdUP = new SqlCommand("UPDATE [dbo].[PeerAdviserConsultations] SET Status = 'DONE', [TimeEnd] = convert(char(8), DATEADD(hour,8,GETUTCDATE()), 108) WHERE [PConsultationId] = " + Request.QueryString["aId"]);
                Class2.exe(cmdUP);
                 ScriptManager.RegisterStartupScript(this, typeof(string), "Message", "alert('Consultation is now done! Please take the evaluation.'); window.location ='StudentSessionEvaluation.aspx?aId=" + Request.QueryString["aId"] + "';",true);
            }
        }
    }

    protected void btnUpdateSession_Click(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(this, typeof(string), "uniqueKey", "div_show()", true);
    }

    public object msg(string Number, string Message, string API_CODE)
    {
        object functionReturnValue = null;
        using (System.Net.WebClient client = new System.Net.WebClient())
        {
            System.Collections.Specialized.NameValueCollection parameter = new System.Collections.Specialized.NameValueCollection();
            string url = "https://www.itexmo.com/php_api/api.php";
            parameter.Add("1", Number);
            parameter.Add("2", Message);
            parameter.Add("3", API_CODE);
            dynamic rpb = client.UploadValues(url, "POST", parameter);
            functionReturnValue = (new System.Text.UTF8Encoding()).GetString(rpb);
        }
        return functionReturnValue;
    }

    protected void btnCancelSession_Click(object sender, EventArgs e)
    {                                                                                                           
    }
    
    protected void ListViewSAttendance_ItemCommand(object sender, ListViewCommandEventArgs e)
    {
        try
        {
            if(e.CommandName == "TimeStart")
            {
                //if EWP
                Session["TStart"] = Class2.getSingleData("SELECT ConsultationType FROM PeerAdviserConsultations WHERE [PConsultationId] = " + e.CommandArgument);
                SqlCommand cmdUser = new SqlCommand("UPDATE [dbo].[PeerAdviserConsultations] SET [TimeStart] = CONVERT(char(5), convert(char(8), DATEADD(hour,8,GETUTCDATE()), 108)) WHERE [PConsultationId] =  " + e.CommandArgument);
                Class2.exe(cmdUser);
                populateListView();
            }
            else if(e.CommandName == "Cancel")
            {
                SqlCommand cmdUser = new SqlCommand("UPDATE [dbo].[PeerAdviserConsultations] SET Status = 'CANCELLED' WHERE [PConsultationId] = " + e.CommandArgument);
                Class2.exe(cmdUser);
                if(Class2.getSingleData("SELECT [ConsultationType] FROM dbo.PeerAdviserConsultations WHERE PConsultationId = " + e.CommandArgument) != "Walk-In")
                {
                   string studCNumber = Class2.getSingleData("SELECT dbo.Student.Contact + ';' + CONVERT(nvarchar, ConsultationDate) + ';' + CONVERT(nvarchar, TimeStart, 120) + ';' FROM dbo.PeerAdviserConsultations INNER JOIN dbo.Student ON dbo.PeerAdviserConsultations.StudentNumber = dbo.Student.StudentNumber WHERE PConsultationId = " + e.CommandArgument);
                   msg("0" + studCNumber.Split(';')[0].ToString(), "Your peer advising appointment on " + studCNumber.Split(';')[1].ToString() + " " + studCNumber.Split(';')[2].ToString() + " has been cancelled.", "ST-CLARE459781_VHVVV");     
                }

                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Consultation has been cancelled!'); ", true);
            }
        }
        catch(Exception ex)
        {
            Response.Redirect("StaffSessionAttendance.aspx");
        }
    }

}













