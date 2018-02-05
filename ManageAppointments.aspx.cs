using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    string time;
    SqlCommand cmdConId;
    LinkButton ichi, ni, san, yon, go, roku;
    protected void Page_Load(object sender, EventArgs e)
    {
        checkUsertype.filter("STAFF", Session["UserType"].ToString());
        

        if (!IsPostBack)
        {
            
            LoopTextboxes(0, "PENDING");
            ddlWeek.SelectedIndex = 1;

            ddlSubjType.DataSource = Class2.getDataSet("SELECT DISTINCT SubjectType FROM [dbo].[Subjects]");
            ddlSubjType.DataValueField = "SubjectType";
            ddlSubjType.DataTextField = "SubjectType";
            ddlSubjType.DataBind();

            

            ddlStudNum.DataSource = Class2.getDataSet("SELECT dbo.Student.StudentNumber FROM dbo.Student");
            ddlStudNum.DataValueField = "StudentNumber";
            ddlStudNum.DataTextField = "StudentNumber";
            ddlStudNum.DataBind();
            fillTextBox();
            populateCourseCode();
            populatePeerAdviser();
            ScriptManager.RegisterStartupScript(this, typeof(string), "uniqueKey", "div_hide()", true);
        }
        else
        {
            //ScriptManager.RegisterStartupScript(this, typeof(string), "uniqueKey", "div_show()", true);
        }

    }

    protected void fillCCode(object sender, EventArgs e)
    {
        populateCourseCode();
        populatePeerAdviser();
        
    }

    protected void displayWalkin(object sender, EventArgs e)
    {
        walkin.Visible = true;
        students.Visible = false;
        ScriptManager.RegisterStartupScript(this, typeof(string), "uniqueKey", "div_show()", true);
    }

    protected void populateCourseCode()
    {
        ddlCourseCode.DataSource = Class2.getDataSet("SELECT [CourseCode], [DeptId], [SubjectType] FROM [dbo].[Subjects] WHERE [SubjectType] = '" + ddlSubjType.SelectedValue + "';");
        ddlCourseCode.DataValueField = "CourseCode";
        ddlCourseCode.DataTextField = "CourseCode";
        ddlCourseCode.DataBind();

        if(IsPostBack)
        {
            ScriptManager.RegisterStartupScript(this, typeof(string), "uniqueKey", "div_show()", true);
        } 
    }

    protected void populatePeerAdviser()
    {
        ddlPeerAdviser.DataSource = Class2.getDataSet("SELECT dbo.Student.StudentName, dbo.PeerAdviser.PAdviserId FROM dbo.PeerAdviser INNER JOIN dbo.Student ON dbo.PeerAdviser.StudentNumber = dbo.Student.StudentNumber AND STATUS = 'ACTIVE' AND TeachingSubject = '" + ddlSubjType.SelectedValue + "' AND dbo.Student.StudentName <> '" + studentName.Text + "';");
        ddlPeerAdviser.DataValueField = "PAdviserId";
        ddlPeerAdviser.DataTextField = "StudentName";
        ddlPeerAdviser.DataBind(); 
    }

    protected void LinkButtons_Click(object sender, EventArgs e)
    {
        
        LinkButton source = (LinkButton)sender;
        string value = checkUsertype.convertToDateTime(source.ID);
        
            if (ddlWeek.SelectedValue == "Previous")
            {
                cmdConId = new SqlCommand("SELECT PConsultationId FROM [dbo].[PeerAdviserConsultations] WHERE ConsultationDate = (SELECT CONVERT(VARCHAR(50), (DATEADD(dd, " + value.Split(';')[0] + "-(DATEPART(dw, dateadd(hour,8,getutcdate()))), CONVERT(date, dateadd(hour,8,getutcdate())-7 ))), 120)) and TimeStart = CONVERT(time, '" + value.Split(';')[1] + "') and StudentNumber ='" + source.Text + "' and STATUS = 'DONE'");
            }
            else if (ddlWeek.SelectedValue == "Next")
            {
                if(source.Text.Contains("students") == true)
                {
                    walkin.Visible = false;
                    students.Visible = true;
                    ScriptManager.RegisterStartupScript(this, typeof(string), "uniqueKey", "div_show()", true);
                    ddlStudents.DataSource = Class2.getDataSet("SELECT StudentNumber FROM [dbo].[PeerAdviserConsultations] WHERE ConsultationDate = (SELECT CONVERT(VARCHAR(50), (DATEADD(dd, " + value.Split(';')[0] + "-(DATEPART(dw, dateadd(hour,8,getutcdate()))), CONVERT(date, dateadd(hour,8,getutcdate())+7))), 120)) and TimeStart = CONVERT(time, '" + value.Split(';')[1] + "') and TimeEnd IS NULL and Status = 'PENDING'");
                    ddlStudents.DataValueField = "StudentNumber";
                    ddlStudents.DataTextField = "StudentNumber";
                    ddlStudents.DataBind();
                    Session["apptQuery"] = "SELECT PConsultationId FROM [dbo].[PeerAdviserConsultations] WHERE ConsultationDate = (SELECT CONVERT(VARCHAR(50), (DATEADD(dd, " + value.Split(';')[0] + "-(DATEPART(dw, dateadd(hour,8,getutcdate()))), CONVERT(date, dateadd(hour,8,getutcdate())))), 120)) and TimeStart = CONVERT(time, '" + value.Split(';')[1] + "') and STATUS = 'PENDING'";
                
                }
                else
                {
                    cmdConId = new SqlCommand("SELECT PConsultationId FROM [dbo].[PeerAdviserConsultations] WHERE ConsultationDate = (SELECT CONVERT(VARCHAR(50), (DATEADD(dd, " + value.Split(';')[0] + "-(DATEPART(dw, dateadd(hour,8,getutcdate()))), CONVERT(date, dateadd(hour,8,getutcdate())+7))), 120)) and TimeStart = CONVERT(time, '" + value.Split(';')[1] + "') and StudentNumber ='" + source.Text + "' and STATUS = 'PENDING'");
                    SqlCommand cmdUser = new SqlCommand("UPDATE [dbo].[PeerAdviserConsultations] SET [Status] = 'ON-GOING' WHERE [PConsultationId] = " + Class2.getSingleData(cmdConId));
                    Class2.exe(cmdUser);
                    Response.Redirect("StaffSessionAttendance.aspx?aId=" + Class2.getSingleData(cmdConId));
                } 
            }
            else
            {
                if (source.Text.Contains("students") == true)
                {
                    walkin.Visible = false;
                    students.Visible = true;
                    ScriptManager.RegisterStartupScript(this, typeof(string), "uniqueKey", "div_show()", true);
                    ddlStudents.DataSource = Class2.getDataSet("SELECT StudentNumber FROM [dbo].[PeerAdviserConsultations] WHERE ConsultationDate = (SELECT CONVERT(VARCHAR(50), (DATEADD(dd, " + (Int32.Parse(value.Split(';')[0]) + 0) + "-(DATEPART(dw, dateadd(hour,8,getutcdate()))), CONVERT(date, dateadd(hour,8,getutcdate())))), 120)) and TimeStart = CONVERT(time, '" + value.Split(';')[1] + "') and TimeEnd IS NULL and Status = 'PENDING'");
                    ddlStudents.DataValueField = "StudentNumber";
                    ddlStudents.DataTextField = "StudentNumber";
                    ddlStudents.DataBind();
                    Session["apptQuery"] = "SELECT PConsultationId FROM [dbo].[PeerAdviserConsultations] WHERE ConsultationDate = (SELECT CONVERT(VARCHAR(50), (DATEADD(dd, " + value.Split(';')[0] + "-(DATEPART(dw, dateadd(hour,8,getutcdate()))), CONVERT(date, dateadd(hour,8,getutcdate())))), 120)) and TimeStart = CONVERT(time, '" + value.Split(';')[1] + "') and STATUS = 'PENDING'";
                }
                else
                {
                    if(source.Text.Contains("EWP") == true)
                    {
                        cmdConId = new SqlCommand("SELECT PConsultationId FROM [dbo].[PeerAdviserConsultations] WHERE ConsultationDate = (SELECT CONVERT(VARCHAR(50), (DATEADD(dd, " + value.Split(';')[0] + "-(DATEPART(dw, dateadd(hour,8,getutcdate()))), CONVERT(date, dateadd(hour,8,getutcdate())))), 120)) and TimeStart = CONVERT(time, '" + value.Split(';')[1] + "') and StudentNumber ='" + source.Text.Split('(')[0] + "' and STATUS = 'PENDING'");
                        SqlCommand cmdUser = new SqlCommand("UPDATE [dbo].[PeerAdviserConsultations] SET [Status] = 'ON-GOING' WHERE [PConsultationId] = " + Class2.getSingleData(cmdConId));
                        Class2.exe(cmdUser);
                        Response.Redirect("StaffSessionAttendance.aspx?aId=" + Class2.getSingleData(cmdConId));
                    }
                    else
                    {
                        cmdConId = new SqlCommand("SELECT PConsultationId FROM [dbo].[PeerAdviserConsultations] WHERE ConsultationDate = (SELECT CONVERT(VARCHAR(50), (DATEADD(dd, " + value.Split(';')[0] + "-(DATEPART(dw, dateadd(hour,8,getutcdate()))), CONVERT(date, dateadd(hour,8,getutcdate())))), 120)) and TimeStart = CONVERT(time, '" + value.Split(';')[1] + "') and StudentNumber ='" + source.Text + "' and STATUS = 'PENDING'");
                        SqlCommand cmdUser = new SqlCommand("UPDATE [dbo].[PeerAdviserConsultations] SET [Status] = 'ON-GOING' WHERE [PConsultationId] = " + Class2.getSingleData(cmdConId));
                        Class2.exe(cmdUser);
                        Response.Redirect("StaffSessionAttendance.aspx?aId=" + Class2.getSingleData(cmdConId));
                    }
                } 
            }
        

        
    }

    private void LoopTextboxes(int week, string stat)
    {
        int x = 0;
        string y = "";
        while (x < 9)
        {
            #region loop
            if (x == 0)
                y = "A";
            if (x == 1)
                y = "B";
            if (x == 2)
                y = "C";
            if (x == 3)
                y = "D";
            if (x == 4)
                y = "E";
            if (x == 5)
                y = "F";
            if (x == 6)
                y = "G";
            if (x == 7)
                y = "H";
            if (x == 8)
                y = "I";
            #endregion
            int karuuu = 1;
            while (true)
            {
                string id = y + karuuu.ToString();
                if (schedule.FindControl(id) == null)
                    break;

                LinkButton linkbuttonkaru = (LinkButton)schedule.FindControl(id);
                string value = checkUsertype.convertToDateTime(linkbuttonkaru.ID);


                SqlCommand cmd = new SqlCommand("SELECT StudentNumber FROM [dbo].[PeerAdviserConsultations] WHERE ConsultationDate = (SELECT CONVERT(VARCHAR(50), (DATEADD(dd, " + (Int32.Parse(value.Split(';')[0]) + week) + "-(DATEPART(dw, dateadd(hour,8,getutcdate()))), CONVERT(date, dateadd(hour,8,getutcdate())))), 120)) and TimeStart = CONVERT(time, '" + value.Split(';')[1] + "') and TimeEnd IS NULL and Status = '" + stat + "'");
                SqlCommand cmdCount = new SqlCommand("SELECT COUNT(StudentNumber) FROM [dbo].[PeerAdviserConsultations] WHERE ConsultationDate = (SELECT CONVERT(VARCHAR(50), (DATEADD(dd, " + (Int32.Parse(value.Split(';')[0]) + week) + "-(DATEPART(dw, dateadd(hour,8,getutcdate()))), CONVERT(date, dateadd(hour,8,getutcdate())))), 120)) and TimeStart = CONVERT(time, '" + value.Split(';')[1] + "') and TimeEnd IS NULL and Status = '" + stat + "'");
                SqlCommand cmdEWP = new SqlCommand("SELECT ConsultationType FROM [dbo].[PeerAdviserConsultations] WHERE ConsultationDate = (SELECT CONVERT(VARCHAR(50), (DATEADD(dd, " + (Int32.Parse(value.Split(';')[0]) + week) + "-(DATEPART(dw, dateadd(hour,8,getutcdate()))), CONVERT(date, dateadd(hour,8,getutcdate())))), 120)) and TimeStart = CONVERT(time, '" + value.Split(';')[1] + "') and TimeEnd IS NULL and Status = '" + stat + "'");
               
                if(Int32.Parse(Class2.getSingleData(cmdCount)) > 1)
                {
                    linkbuttonkaru.Text = Class2.getSingleData(cmdCount) + " students";
                }
                else
                {
                    if(Class2.getSingleData(cmdEWP) == "EWP")
                        linkbuttonkaru.Text = Class2.getSingleData(cmd) + "(EWP)";
                    else
                        linkbuttonkaru.Text = Class2.getSingleData(cmd);
                }
                
                karuuu++;
            }
            x++;
        }
    }

    protected void btnSearchStudent_Click(object sender, EventArgs e)
    {
        try
        {
            fillTextBox();
            populatePeerAdviser();
            ScriptManager.RegisterStartupScript(this, typeof(string), "uniqueKey", "div_show()", true);
        }
        catch (Exception ex)
        {
            studentName.Text = "";
            studentProgram.Text = "";
        }
    }

    public void fillTextBox()
    {
        DataSet ds = Class2.getDataSet("SELECT dbo.Student.StudentName, dbo.StudentStatus.Program FROM dbo.Student INNER JOIN dbo.StudentStatus ON dbo.Student.StudentNumber = dbo.StudentStatus.StudentNumber WHERE dbo.Student.StudentNumber = " + ddlStudNum.Text);
        studentName.Text = ds.Tables[0].Rows[0]["StudentName"].ToString();
        studentProgram.Text = ds.Tables[0].Rows[0]["Program"].ToString();
    }

    public void addWalkin(object sender, EventArgs e)
    {
        try
        {
            SqlCommand cmdUser = new SqlCommand("[sp_t_PConsultation_ups]");
            cmdUser.CommandType = CommandType.StoredProcedure;
            cmdUser.Parameters.Add("@PConsultationId", SqlDbType.NVarChar).Value = "0";
            cmdUser.Parameters.Add("@SYTerm", SqlDbType.NVarChar).Value = Session["SYTerm"];
            cmdUser.Parameters.Add("@StudentNumber", SqlDbType.NVarChar).Value = ddlStudNum.Text;
            cmdUser.Parameters.Add("@ConsultationType", SqlDbType.NVarChar).Value = "Walk-In";
            cmdUser.Parameters.Add("@CourseCode", SqlDbType.NVarChar).Value = ddlCourseCode.Text;
            cmdUser.Parameters.Add("@Status", SqlDbType.NVarChar).Value = "ON-GOING";
            cmdUser.Parameters.Add("@PAdviserId", SqlDbType.NVarChar).Value = ddlPeerAdviser.SelectedValue;
            cmdUser.Parameters.Add("@PeerAdviser2", SqlDbType.NVarChar).Value = DBNull.Value;
            cmdUser.Parameters.Add("@PeerAdviser3", SqlDbType.NVarChar).Value = DBNull.Value;
            cmdUser.Parameters.Add("@ConsultationDate", SqlDbType.NVarChar).Value = DateTime.Today;
            cmdUser.Parameters.Add("@TimeStart", SqlDbType.NVarChar).Value = DateTime.Now.ToString("HH:mm");
            cmdUser.Parameters.Add("@TimeEnd", SqlDbType.NVarChar).Value = DBNull.Value;
            Class2.exe(cmdUser);
            String x = Class2.getSingleData("SELECT TOP 1 [PConsultationId] FROM [dbo].[PeerAdviserConsultations] ORDER BY PConsultationId DESC");

            ScriptManager.RegisterStartupScript(this, typeof(string), "Message", "if(confirm('Do you want to start the " + ddlCourseCode.Text + " consultation for " + studentName.Text + " and " + ddlPeerAdviser.SelectedItem.Text + " as the Peer Adviser?')){alert('Consultation has started!');window.open('StaffSessionAttendance.aspx?aId=" + x + "','_blank');}else{alert('Cancelled');}",true);
        }
        catch
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please choose a Peer Adviser.');window.location ='ManageAppointments.aspx';", true);
        }
        
    }

    protected void ddlWeek_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlWeek.SelectedValue == "Previous")
        {
            LoopTextboxes(-7, "DONE");
        }
        else if (ddlWeek.SelectedValue == "Next")
        {
            LoopTextboxes(7, "PENDING");
        }
        else
        {
            LoopTextboxes(0, "PENDING");
        }

    }

    protected void btnViewAppt_Click(object sender, EventArgs e)
    {
        SqlCommand vAppt = new SqlCommand(Session["apptQuery"] + " and StudentNumber = '" + ddlStudents.SelectedValue + "'");
        SqlCommand cmdUser = new SqlCommand("UPDATE [dbo].[PeerAdviserConsultations] SET [Status] = 'ON-GOING' WHERE [PConsultationId] = " + Class2.getSingleData(vAppt));
        Class2.exe(cmdUser);
        Response.Redirect("StaffSessionAttendance.aspx?aId=" + Class2.getSingleData(vAppt));
    }
}












