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
        checkUsertype.filter("FACULTY", Session["UserType"].ToString());

        SqlCommand cmd = new SqlCommand("SELECT dbo.AcademicAdviserConsultations.ConsultationDateTime, (SELECT dbo.Student.StudentName FROM Student WHERE Student.StudentNumber = AcademicAdviserConsultations.StudentNumber) as [Student Name], dbo.AcademicAdviserConsultations.ConsultationCode, dbo.AcademicAdviserConsultations.NatureOfAdvising, dbo.AcademicAdviserConsultations.ActionTaken FROM dbo.AcademicAdviserConsultations INNER JOIN dbo.AcademicAdviser ON dbo.AcademicAdviserConsultations.AAdviserId = dbo.AcademicAdviser.AAdviserId WHERE dbo.AcademicAdviserConsultations.Status = 'DONE' and dbo.AcademicAdviser.UserId = " + Session["UserId"]);

        ListViewAHistory.DataSource = Class2.getDataSet(cmd);
        ListViewAHistory.DataBind();
    }

    public void sortByAction(string act)
    {
        SqlCommand cmd = new SqlCommand("SELECT dbo.AcademicAdviserConsultations.ConsultationDateTime, (SELECT dbo.Student.StudentName FROM Student WHERE Student.StudentNumber = AcademicAdviserConsultations.StudentNumber) as [Student Name], dbo.AcademicAdviserConsultations.ConsultationCode, dbo.AcademicAdviserConsultations.NatureOfAdvising, dbo.AcademicAdviserConsultations.ActionTaken FROM dbo.AcademicAdviserConsultations INNER JOIN dbo.AcademicAdviser ON dbo.AcademicAdviserConsultations.AAdviserId = dbo.AcademicAdviser.AAdviserId WHERE dbo.AcademicAdviserConsultations.Status = 'DONE' and dbo.AcademicAdviser.UserId = " + Session["UserId"] + " and dbo.AcademicAdviserConsultations.ActionTaken = '" + act + "';");

        ListViewAHistory.DataSource = Class2.getDataSet(cmd);
        ListViewAHistory.DataBind();
    }

    public void sortByFFU(object sender, EventArgs e)
    {
        sortByAction("For Follow Up");
    }

    public void sortByRef(object sender, EventArgs e)
    {
        SqlCommand cmd = new SqlCommand("SELECT dbo.AcademicAdviserConsultations.ConsultationDateTime, (SELECT dbo.Student.StudentName FROM Student WHERE Student.StudentNumber = AcademicAdviserConsultations.StudentNumber) as [Student Name], dbo.AcademicAdviserConsultations.ConsultationCode, dbo.AcademicAdviserConsultations.NatureOfAdvising, dbo.AcademicAdviserConsultations.ActionTaken FROM dbo.AcademicAdviserConsultations INNER JOIN dbo.AcademicAdviser ON dbo.AcademicAdviserConsultations.AAdviserId = dbo.AcademicAdviser.AAdviserId WHERE dbo.AcademicAdviserConsultations.Status = 'DONE' and dbo.AcademicAdviserConsultations.ActionTaken <> 'For Follow Up' and dbo.AcademicAdviserConsultations.ActionTaken <> 'Resolved' and dbo.AcademicAdviser.UserId = " + Session["UserId"]);

        ListViewAHistory.DataSource = Class2.getDataSet(cmd);
        ListViewAHistory.DataBind();
        
    }

    public void sortByRes(object sender, EventArgs e)
    {
        sortByAction("Resolved");
    }
}
