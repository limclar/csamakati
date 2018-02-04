using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
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
        SqlCommand cmd = new SqlCommand("SELECT PConsultationId,Status,CONVERT(varchar(10), dbo.PeerAdviserConsultations.ConsultationDate, 20) as ConsultationDate, dbo.PeerAdviserConsultations.ConsultationType, dbo.PeerAdviserConsultations.CourseCode, dbo.PeerAdviserConsultations.TimeStart, dbo.PeerAdviserConsultations.TimeEnd, dbo.PeerAdviserConsultations.PAdviserId as PeerAdvisers FROM dbo.PeerAdviserConsultations INNER JOIN dbo.Student ON dbo.PeerAdviserConsultations.StudentNumber = dbo.Student.StudentNumber INNER JOIN dbo.[User] ON dbo.Student.UserId = dbo.[User].UserId WHERE STATUS = 'PENDING' and NOT EXISTS (SELECT * FROM [dbo].[ConsultationEvaluation] WHERE dbo.PeerAdviserConsultations.PConsultationId = dbo.[ConsultationEvaluation].PConsultationId) and dbo.[User].UserId = " + Session["UserId"] + " ORDER BY ConsultationDate desc;");

        ListViewPAdvising.DataSource = Class2.getDataSet(cmd);
        ListViewPAdvising.DataBind();
        if (Request.QueryString["sortby"] == "1")
        {
            sortByAcad();
        }     
    }
    
    protected void conType(object sender, EventArgs e)
    {
        if(ddlType.SelectedIndex == 0)
        {
            Response.Redirect("StudentMyAppointment.aspx");
            ListViewPAdvising.Visible = true;
            ListViewAAdvising.Visible = false;
            SqlCommand cmd = new SqlCommand("SELECT PConsultationId,Status,CONVERT(varchar(10), dbo.PeerAdviserConsultations.ConsultationDate, 20) as ConsultationDate, dbo.PeerAdviserConsultations.ConsultationType, dbo.PeerAdviserConsultations.CourseCode, CONVERT(varchar(10), dbo.PeerAdviserConsultations.TimeStart, dbo.PeerAdviserConsultations.TimeEnd, dbo.PeerAdviserConsultations.PAdviserId as PeerAdvisers FROM dbo.PeerAdviserConsultations INNER JOIN dbo.Student ON dbo.PeerAdviserConsultations.StudentNumber = dbo.Student.StudentNumber INNER JOIN dbo.[User] ON dbo.Student.UserId = dbo.[User].UserId WHERE STATUS <> 'CANCELLED' and NOT EXISTS (SELECT * FROM [dbo].[ConsultationEvaluation] WHERE dbo.PeerAdviserConsultations.PConsultationId = dbo.[ConsultationEvaluation].PConsultationId) and dbo.[User].UserId = " + Session["UserId"] + "ORDER BY ConsultationDate desc;");
            ListViewPAdvising.DataSource = Class2.getDataSet(cmd);
            ListViewPAdvising.DataBind();
        }
        else
        {
            sortByAcad();
        }  
    }

    protected void showAHistory(object sender, EventArgs e)
    {
        sortByAcad();
    }

    protected void sortByAcad()
    {
        ListViewAAdvising.Visible = true;
        ListViewPAdvising.Visible = false;
        SqlCommand cmd = new SqlCommand("SELECT AConsultationId,dbo.AcademicAdviserConsultations.ConsultationDateTime, dbo.AcademicAdviserConsultations.ConsultationCode, dbo.AcademicAdviserConsultations.NatureOfAdvising, dbo.AcademicAdviser.LName + ', ' + dbo.AcademicAdviser.FName + ' (' + dbo.AcademicAdviser.MName + ')' AS [AdviserName] FROM dbo.AcademicAdviserConsultations INNER JOIN dbo.AcademicAdviser ON dbo.AcademicAdviserConsultations.AAdviserId = dbo.AcademicAdviser.AAdviserId INNER JOIN dbo.Student ON dbo.AcademicAdviserConsultations.StudentNumber = dbo.Student.StudentNumber  WHERE dbo.AcademicAdviserConsultations.STATUS <> 'DONE' and dbo.AcademicAdviserConsultations.STATUS <> 'CANCELLED' and dbo.[Student].UserId = " + Session["UserId"] + " ORDER BY ConsultationDateTime desc;");
        ListViewAAdvising.DataSource = Class2.getDataSet(cmd);
        ListViewAAdvising.DataBind();
    }

    protected void showPHistory(object sender, EventArgs e)
    {
        
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

    protected void ListViewPAdvising_ItemCommand(object sender, ListViewCommandEventArgs e)
    {
        if (e.CommandName == "CancelAppt")
        {
            SqlCommand cmdUser = new SqlCommand("UPDATE [dbo].[PeerAdviserConsultations] SET Status = 'CANCELLED' WHERE [PConsultationId] = " + e.CommandArgument);
            Class2.exe(cmdUser);
            string advNum = Class2.getSingleData("SELECT dbo.Student.Contact FROM dbo.PeerAdviser INNER JOIN dbo.Student ON dbo.PeerAdviser.StudentNumber = dbo.Student.StudentNumber JOIN PeerAdviserConsultations ON PeerAdviser.PAdviserId = PeerAdviserConsultations.PAdviserId WHERE PConsultationId = " + e.CommandArgument);
            string apptDet = Class2.getSingleData("SELECT (CONVERT(varchar(10),ConsultationDate) + ';' + CONVERT(varchar(5), TimeStart) + ';' + CourseCode + ';' + (SELECT StudentName From dbo.Student WHERE dbo.Student.[StudentNumber] = dbo.PeerAdviserConsultations.StudentNumber)) FROM [dbo].[PeerAdviserConsultations] WHERE PConsultationId = " + e.CommandArgument);
            msg("0" + advNum, apptDet.Split(';')[3] + " has scheduled an appointment to you at " + apptDet.Split(';')[0]  + " " + apptDet.Split(';')[1] + " regarding the course " + apptDet.Split(';')[2] + ".", "ST-CLARE459781_VHVVV");
            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Consultation has been cancelled!'); window.location ='StudentMyAppointment.aspx?';", true);
        }
    }

    protected void ListViewPAdvising_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        if (e.Item.ItemType == ListViewItemType.DataItem)
        {
            HtmlTableCell c = (HtmlTableCell)e.Item.FindControl("pcanCel");
            HtmlTableCell ev = (HtmlTableCell)e.Item.FindControl("pEval");
            Label x = (Label)e.Item.FindControl("StatusLabel");
            if (x != null)
            {
                if (x.Text.Trim() == "DONE")
                {
                    HtmlTableCell qw = (HtmlTableCell)e.Item.FindControl("StatusTb");
                    qw.BgColor = "#e91717";
                    c.Visible = false;
                }
                else
                {
                    HtmlTableCell qw = (HtmlTableCell)e.Item.FindControl("StatusTb");
                    qw.BgColor = "#e91717";
                    c.Visible = true;
                }
            }
        }
    }

    protected void ListViewAAdvising_ItemCommand(object sender, ListViewCommandEventArgs e)
    {
        if (e.CommandName == "aCancelAppt")
        {
            SqlCommand cmdUser = new SqlCommand("UPDATE [dbo].[AcademicAdviserConsultations] SET Status = 'CANCELLED' WHERE [AConsultationId] = " + e.CommandArgument);
            Class2.exe(cmdUser);
            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Consultation has been cancelled!'); window.location ='StudentMyAppointment.aspx?sortby=1';", true);
        }
    }
}
