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
        checkUsertype.filter("STAFF", Session["UserType"].ToString());
        Session["aId"] = Request.QueryString["aId"];
        Label1.Text = Class2.getSingleData("SELECT (Select dbo.Student.StudentName from Student WHERE dbo.Student.StudentNumber = dbo.PeerAdviserConsultations.StudentNumber) FROM PeerAdviserConsultations WHERE dbo.PeerAdviserConsultations.PConsultationId = " + Session["aId"]);
        Label2.Text = Class2.getSingleData("SELECT (Select Student.StudentName FROM STUDENT WHERE Student.StudentNumber = (Select dbo.PeerAdviser.StudentNumber from PeerAdviser WHERE dbo.PeerAdviser.PAdviserId = dbo.PeerAdviserConsultations.PAdviserId)) FROM PeerAdviserConsultations WHERE dbo.PeerAdviserConsultations.PConsultationId = " + Session["aId"]);
    }

    protected void btnAddEval_Click(object sender, EventArgs e)
    {
        SqlCommand cmdUser = new SqlCommand("INSERT INTO [dbo].[ConsultationEvaluation] VALUES ("+ Request.QueryString["aId"] +", " + rdbtnMaster.SelectedValue + ",  " + rdbtnRespect.SelectedValue + ",  " + rdbtnEncourage.SelectedValue + ", " + rdbtnManage.SelectedValue + ", " + rdbtnLearning.SelectedValue + ")");
        Class2.exe(cmdUser);
        Response.Redirect("StudentMyAppointment.aspx");
    }
}
