using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Configuration;
using System.Net;

using System.Configuration;
using Twilio;
using System.Threading.Tasks;
using System.IO;

public partial class _Default : System.Web.UI.Page
{
    
    protected void Page_Load(object sender, EventArgs e)
    {
        checkUsertype.filter("STAFF", Session["UserType"].ToString());
        SqlCommand cmdEWP = new SqlCommand("SELECT ConsultationType FROM PeerAdviserConsultations WHERE [PConsultationId] = " + Request.QueryString["aId"]);
        
        populateListView();
        if(Class2.getSingleData(cmdEWP) == "EWP")
        {
            btnUpdateTimeEnd.Visible = false;
            yesEWP.Visible = true;
        }
        else
        {
            btnUpdateTimeEnd.Visible = true;
            yesEWP.Visible = false;
        }
            
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

    public void populateListView()
    {
        Session["TStart"] = Class2.getSingleData("SELECT ConsultationType FROM PeerAdviserConsultations WHERE [PConsultationId] = " + Request.QueryString["aId"]);
        SqlCommand cmd = new SqlCommand("SELECT * FROM [dbo].[PeerAdviserConsultations] WHERE PConsultationId = " + Request.QueryString["aId"]);

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
        SqlCommand cmdUser = new SqlCommand("UPDATE [dbo].[PeerAdviserConsultations] SET [TimeStart] = CONVERT(char(5), convert(char(8), DATEADD(hour,8,GETUTCDATE()), 108) WHERE [PConsultationId] =  " + Request.QueryString["aId"]);
        Class2.exe(cmdUser);
        populateListView();
    }

    protected void btnUpdateTimeEnd_Click(object sender, EventArgs e) // save nadin status done
    {   
        if(btnUpdateTimeEnd.Visible == true)
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
                SqlCommand cmdUser = new SqlCommand("UPDATE [dbo].[PeerAdviserConsultations] SET Status = 'DONE', [TimeEnd] = convert(char(8), DATEADD(hour,8,GETUTCDATE()), 108) WHERE [PConsultationId] = " + Request.QueryString["aId"]);
                Class2.exe(cmdUser);
                populateListView();
            }
            else
            {
                SqlCommand cmdUP = new SqlCommand("UPDATE [dbo].[PeerAdviserConsultations] SET Status = 'DONE', [TimeEnd] = convert(char(8), DATEADD(hour,8,GETUTCDATE()), 108) WHERE [PConsultationId] = " + Request.QueryString["aId"]);
                Class2.exe(cmdUP);
                SqlCommand cmdSel = new SqlCommand("SELECT SYTerm + ';' + StudentNumber + ';' + CourseCode + ';' + PAdviserId + ';' + (LEFT(CONVERT(VARCHAR, dateadd(hour,8,getutcdate()) + 7, 101), 10)) FROM [dbo].[PeerAdviserConsultations] WHERE [PConsultationId] = " + Request.QueryString["aId"]);
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
                cmdUser.Parameters.Add("@TimeStart", SqlDbType.NVarChar).Value = Session["TStart"];
                cmdUser.Parameters.Add("@TimeEnd", SqlDbType.NVarChar).Value = DBNull.Value;
                Class2.exe(cmdUser);
                populateListView();
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
        SqlCommand cmdUser = new SqlCommand("UPDATE [dbo].[PeerAdviserConsultations] SET Status = 'CANCELLED' WHERE [PConsultationId] = " + Request.QueryString["aId"]);
        Class2.exe(cmdUser);
        populateListView();

        if(Class2.getSingleData("SELECT [ConsultationType] FROM dbo.PeerAdviserConsultations WHERE PConsultationId = " + Request.QueryString["aId"]) != "Walk-In")
        {
           string studCNumber = Class2.getSingleData("SELECT dbo.Student.Contact + ';' + CONVERT(nvarchar, ConsultationDate) + ';' + CONVERT(nvarchar, TimeStart, 120) + ';' FROM dbo.PeerAdviserConsultations INNER JOIN dbo.Student ON dbo.PeerAdviserConsultations.StudentNumber = dbo.Student.StudentNumber WHERE PConsultationId = " + Request.QueryString["aId"]);
           msg("0" + studCNumber.Split(';')[0].ToString(), "Your appointment on " + studCNumber.Split(';')[1].ToString() + " " + studCNumber.Split(';')[2].ToString() + " has been cancelled.", "ST-CLARE459781_FISP7");     
        }
        
        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Consultation has been cancelled!'); window.close();", true);
    }
}













