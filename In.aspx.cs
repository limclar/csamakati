using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class In : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(Session["UserType"] == "STUDENT")
            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert",  window.location ='StudentAnnouncements.aspx';", true);
        else if(Session["UserType"] == "STAFF")
            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert",  window.location ='StaffDashboard.aspx';", true);
        else if(Session["UserType"] == "STUDENT")
            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert",  window.location ='FacultyDashboard.aspx';", true);
        
        
        
        Session["UserId"] = "";
        Session["UserType"] = "";
        Session["Username"] = "";
        string ewpCount = Class2.getSingleData("SELECT COUNT(*) FROM PeerAdviserConsultations WHERE ConsultationType = 'EWP' and Status = 'PENDING' AND CONSULTATIONDATE < dateadd(hour,8,getutcdate())");
        for(int i = 0; i <= Int32.Parse(ewpCount); i++)
        {
            SqlCommand updStud = new SqlCommand("UPDATE [dbo].[StudentStatus] SET [CurrentStatus] = 'EWP' WHERE StudentNumber = (SELECT TOP 1 StudentNumber FROM PeerAdviserConsultations WHERE ConsultationType = 'EWP' and Status = 'PENDING' AND CONSULTATIONDATE < dateadd(hour,8,getutcdate()))");
            Class2.exe(updStud);
        }
        SqlCommand nsPeer = new SqlCommand("UPDATE [dbo].[PeerAdviserConsultations] SET [STATUS] = 'NOSHOW' WHERE CONSULTATIONDATE < dateadd(hour,8,getutcdate()) AND STATUS='PENDING'");
        Class2.exe(nsPeer);
        SqlCommand nsAcad = new SqlCommand("UPDATE [dbo].[AcademicAdviserConsultations] SET [STATUS] = 'NOSHOW' WHERE CONSULTATIONDATETIME < dateadd(hour,8,getutcdate()) AND STATUS='PENDING'");
        Class2.exe(nsAcad);
        
        
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        SqlCommand cmd = new SqlCommand("Select Convert(nvarchar(50),UserId)+';'+ ISNULL([UserType],'')+';'+ ISNULL([Username],'') from [dbo].[User] where [Username] =  '"+ txtUsername.Text + "' and [Password] = '" + txtPassword.Text + "'");
        String x = Class2.getSingleData(cmd);

        if (string.IsNullOrEmpty(x))
        {
            txtPassword.Text = "";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Invalid user credentials. Please try again.');window.location ='In.aspx';", true);
        }
        else
        {
            literalMsg.Text = x;
            Session["UserId"] = x.Split(';')[0];
            Session["UserType"] = x.Split(';')[1];
            Session["Username"] = x.Split(';')[2];
            String utype = Session["UserType"].ToString().ToUpper();
            SqlCommand cmdSYTerm = new SqlCommand("SELECT TOP 1 SYTerm FROM [dbo].[StudentStatus] order by CreatedDateTime desc");
            Session["SYTerm"] = Class2.getSingleData(cmdSYTerm);

            if (utype == "FACULTY")
            {
                SqlCommand cmdFaculty = new SqlCommand("SELECT CONVERT(nvarchar,dbo.AcademicAdviser.AAdviserId) + ';' + dbo.AcademicAdviser.FName +  ' ' + SUBSTRING( dbo.AcademicAdviser.MName, 1, 1 ) + '. ' + dbo.AcademicAdviser.LName AS [Full Name] FROM dbo.AcademicAdviser INNER JOIN dbo.[User] ON dbo.AcademicAdviser.UserId = dbo.[User].UserId WHERE dbo.[User].UserId = " + Session["UserId"].ToString().Trim());
                string nameFaculty = Class2.getSingleData(cmdFaculty);
                Session["Name"] = nameFaculty.Split(';')[1];
                Session["AAdviserId"] = nameFaculty.Split(';')[0];
                Response.Redirect("FacultyDashboard.aspx");
            }
            else if (utype == "STAFF")
            {
                SqlCommand cmdStaff = new SqlCommand("SELECT dbo.Staff.FName +  ' ' + SUBSTRING( dbo.Staff.MName, 1, 1 ) + '. ' + dbo.Staff.LName AS [Full Name] FROM dbo.Staff INNER JOIN dbo.[User] ON dbo.Staff.UserId = dbo.[User].UserId WHERE dbo.[User].UserId = " + Session["UserId"].ToString().Trim());
                string nameStaff = Class2.getSingleData(cmdStaff);
                Session["Name"] = nameStaff;
                Response.Redirect("StaffDashboard.aspx");
            }
            else if (utype == "STUDENT")
            {
                
                SqlCommand cmdStud = new SqlCommand("SELECT dbo.Student.StudentName FROM dbo.Student INNER JOIN dbo.[User] ON dbo.Student.UserId = dbo.[User].UserId WHERE dbo.[User].UserId = " + Session["UserId"].ToString().Trim());
                SqlCommand cmdStudentNumber = new SqlCommand("SELECT dbo.Student.StudentNumber FROM dbo.Student INNER JOIN dbo.[User] ON dbo.Student.UserId = dbo.[User].UserId WHERE dbo.[User].UserId = " + Session["UserId"].ToString().Trim());
                string nameStud = Class2.getSingleData(cmdStud);
                Session["Name"] = nameStud;
                string StudentNumber = Class2.getSingleData(cmdStudentNumber);
                Session["StudentNumber"] = StudentNumber;
                Response.Redirect("StudentAnnouncements.aspx");
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Invalid user credentials. Please try again.');window.location ='In.aspx';", true);
            }
        }
    }
}
