using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Text.RegularExpressions;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class _Default : System.Web.UI.Page
{
    string time, shit;
    int dayCon = 0;
    LinkButton ichi, ni, san, yon, go, roku;

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

        if (!IsPostBack)
        {
            Session["sCounter"] = 0;
            ddlSubjType.DataSource = Class2.getDataSet("SELECT DISTINCT SubjectType FROM [dbo].[Subjects]");
            ddlSubjType.DataValueField = "SubjectType";
            ddlSubjType.DataTextField = "SubjectType";
            ddlSubjType.DataBind();
            

            fillAdvisers();
            fillCCode();
            populateSched();
        }
    }

    public void fillCCode()
    {
        ddlCCode.DataSource = Class2.getDataSet("SELECT [CourseCode], [DeptId], [SubjectType] FROM [dbo].[Subjects] WHERE [SubjectType] = '" + ddlSubjType.SelectedValue + "';");
        ddlCCode.DataValueField = "CourseCode";
        ddlCCode.DataTextField = "CourseCode";
        ddlCCode.DataBind();
    }

    public void fillAdvisers()
    {
        ddlPeerAdviser.DataSource = Class2.getDataSet("SELECT dbo.Student.StudentName, dbo.PeerAdviser.PAdviserId FROM dbo.PeerAdviser INNER JOIN dbo.Student ON dbo.PeerAdviser.StudentNumber = dbo.Student.StudentNumber AND STATUS = 'ACTIVE' AND TeachingSubject = '" + ddlSubjType.SelectedValue + "' AND dbo.Student.StudentNumber <> '" + Session["StudentNumber"] + "';");
        ddlPeerAdviser.DataValueField = "PAdviserId";
        ddlPeerAdviser.DataTextField = "StudentName";
        ddlPeerAdviser.DataBind();
    }

    public void populateSched()
    {

        String pSched = Class2.getSingleData("SELECT TOP 1 dbo.PeerAdviser.PeerSchedule FROM dbo.PeerAdviser INNER JOIN dbo.Student ON dbo.PeerAdviser.StudentNumber = dbo.Student.StudentNumber WHERE PAdviserId = " + ddlPeerAdviser.SelectedValue);

        int aTimeCount = Regex.Matches(pSched, ";").Count;

        string[] availableTime = new string[aTimeCount + 1];

        for (int aTimeIndex = 0; aTimeIndex < aTimeCount; aTimeIndex++)
        {
            if (aTimeIndex <= aTimeCount)
                availableTime[aTimeIndex] = pSched.Split(';')[aTimeIndex];
        }

        for (int h = 0; h <= 8; h++)
        {
            //TIME
            switch (h)
            {
                case 0:
                    time = "07:30-09:00";
                    ichi = A1; ni = A2; san = A3; yon = A4; go = A5; roku = A6;
                    break;
                case 1:
                    time = "09:00-10:30";
                    ichi = B1; ni = B2; san = B3; yon = B4; go = B5; roku = B6;
                    break;
                case 2:
                    time = "10:30-12:00";
                    ichi = C1; ni = C2; san = C3; yon = C4; go = C5; roku = C6;
                    break;
                case 3:
                    time = "12:00-13:30";
                    ichi = D1; ni = D2; san = D3; yon = D4; go = D5; roku = D6;
                    break;
                case 4:
                    time = "13:30-15:00";
                    ichi = E1; ni = E2; san = E3; yon = E4; go = E5; roku = E6;
                    break;
                case 5:
                    time = "15:00-16:30";
                    ichi = F1; ni = F2; san = F3; yon = F4; go = F5; roku = F6;
                    break;
                case 6:
                    time = "16:30-18:00";
                    ichi = G1; ni = G2; san = G3; yon = G4; go = G5; roku = G6;
                    break;
            }

            //DAYS
            for (int i = 0; i < aTimeCount; i++)
            {
                if (availableTime[i] == "Monday(" + time + ")")
                {
                    ichi.Text = "AVAILABLE";
                }
                else if (availableTime[i] == "Tuesday(" + time + ")")
                {
                    ni.Text = "AVAILABLE";
                }
                else if (availableTime[i] == "Wednesday(" + time + ")")
                {
                    san.Text = "AVAILABLE";
                }
                else if (availableTime[i] == "Thursday(" + time + ")")
                {
                    yon.Text = "AVAILABLE";
                }
                else if (availableTime[i] == "Friday(" + time + ")")
                {
                    go.Text = "AVAILABLE";
                }
                else if (availableTime[i] == "Saturday(" + time + ")")
                {
                    roku.Text = "AVAILABLE";
                }
            }
        }
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

    protected void ddlSubjType_SelectedIndexChanged(object sender, EventArgs e)
    {   
        fillCCode();
        fillAdvisers();
        clearTable();
        populateSched();
    }

    public void clearTable()
    {
        Session["sCounter"] = 0;
        A1.Text = "---"; A2.Text = "---"; A3.Text = "---"; A4.Text = "---"; A5.Text = "---"; A6.Text = "---";
        B1.Text = "---"; B2.Text = "---"; B3.Text = "---"; B4.Text = "---"; B5.Text = "---"; B6.Text = "---";
        C1.Text = "---"; C2.Text = "---"; C3.Text = "---"; C4.Text = "---"; C5.Text = "---"; C6.Text = "---";
        D1.Text = "---"; D2.Text = "---"; D3.Text = "---"; D4.Text = "---"; D5.Text = "---"; D6.Text = "---";
        E1.Text = "---"; E2.Text = "---"; E3.Text = "---"; E4.Text = "---"; E5.Text = "---"; E6.Text = "---";
        F1.Text = "---"; F2.Text = "---"; F3.Text = "---"; F4.Text = "---"; F5.Text = "---"; F6.Text = "---";
        G1.Text = "---"; G2.Text = "---"; G3.Text = "---"; G4.Text = "---"; G5.Text = "---"; G6.Text = "---";
    }

    protected void LinkButtons_Click(object sender, EventArgs e)
    {
        LinkButton source = (LinkButton)sender;
        

        if (source.Text == "AVAILABLE" && Session["sCounter"].ToString() == "0")
        {
            Session["sCounter"] = 1;
            source.Text = "SELECTED";
            Session["ConsultationDate"] = checkUsertype.convertToTime(source.ID.ToString());
        }
        else if(source.Text == "SELECTED" && Session["sCounter"].ToString() == "1")
        {
            source.Text = "AVAILABLE";
            Session["sCounter"] = 0;
        }
        //ScriptManager.RegisterStartupScript(this, typeof(string), "uniqueKey", "div_show()", true);
    }

    protected void ddlPeerAdviser_SelectedIndexChanged(object sender, EventArgs e)
    {
        clearTable();
        populateSched();
    }

    public void addAppointment(object sender, EventArgs e)
    {
        string confirmValue = Request.Form["confirm_value"];
        if (confirmValue == "Yes")
        {
            try
            {
                string date = Session["ConsultationDate"].ToString().Split(';')[0];
                string time = Session["ConsultationDate"].ToString().Split(';')[1];
                int day;
                SqlCommand cmdUser = new SqlCommand("[sp_t_PConsultation_ups]");
                cmdUser.CommandType = CommandType.StoredProcedure;
                cmdUser.Parameters.Add("@PConsultationId", SqlDbType.NVarChar).Value = "0";
                cmdUser.Parameters.Add("@SYTerm", SqlDbType.NVarChar).Value = Session["SYTerm"];
                cmdUser.Parameters.Add("@StudentNumber", SqlDbType.NVarChar).Value = Session["StudentNumber"];
                try
                {
                    if(Request.QueryString["aType"] == "2")
                    {
                        cmdUser.Parameters.Add("@ConsultationType", SqlDbType.NVarChar).Value = "EWP";
                    }
                    else
                    {
                        cmdUser.Parameters.Add("@ConsultationType", SqlDbType.NVarChar).Value = "APPOINTMENT";
                    }

                }
                catch
                {

                }

                cmdUser.Parameters.Add("@CourseCode", SqlDbType.NVarChar).Value = ddlCCode.Text;
                cmdUser.Parameters.Add("@Status", SqlDbType.NVarChar).Value = "PENDING";
                cmdUser.Parameters.Add("@PAdviserId", SqlDbType.NVarChar).Value = ddlPeerAdviser.SelectedValue;
                cmdUser.Parameters.Add("@PeerAdviser2", SqlDbType.NVarChar).Value = DBNull.Value;
                cmdUser.Parameters.Add("@PeerAdviser3", SqlDbType.NVarChar).Value = DBNull.Value;

                SqlCommand cmdX = new SqlCommand("[sp_t_GetConDateTime_ups]");
                cmdX.CommandType = CommandType.StoredProcedure;
                cmdX.Parameters.Add("@time", SqlDbType.NVarChar).Value = time.Split('-')[0];

                switch (date)
                {
                    case "Monday":
                        dayCon = 2;
                        break;
                    case "Tuesday":
                        dayCon = 3;
                        break;
                    case "Wednesday":
                        dayCon = 4;
                        break;
                    case "Thursday":
                        dayCon = 5;
                        break;
                    case "Friday":
                        dayCon = 6;
                        break;
                    case "Saturday":
                        dayCon = 7;
                        break;
                }
                string cmdxX;
                cmdX.Parameters.Add("@day", SqlDbType.NVarChar).Value = dayCon;
                cmdxX = Class2.getSingleData(cmdX).Split(' ')[0];

                string check = Class2.getSingleData("IF dateadd(hour,8,getutcdate()) > CONVERT(datetime, '" + cmdxX + time.Split('-')[0] + "') SELECT CONVERT(datetime, '" + cmdxX + time.Split('-')[0] + "')+7 ELSE SELECT 'NO'");

                if ( check != "NO")
                {
                    cmdxX = check;
                }

                cmdUser.Parameters.Add("@ConsultationDate", SqlDbType.NVarChar).Value = cmdxX.Split(' ')[0];

                if(Class2.getSingleData(cmdX).Split(' ')[2] == "PM" && Class2.getSingleData(cmdX).Split(' ')[1] != "12:00:00")
                {
                    cmdUser.Parameters.Add("@TimeStart", SqlDbType.NVarChar).Value = (Int32.Parse(Class2.getSingleData(cmdX).Split(' ')[1].Split(':')[0]) + 12) + ":" + Class2.getSingleData(cmdX).Split(' ')[1].Split(':')[1];
                }
                else
                {
                    cmdUser.Parameters.Add("@TimeStart", SqlDbType.NVarChar).Value = Class2.getSingleData(cmdX).Split(' ')[1].Split(':')[0] + ":" + Class2.getSingleData(cmdX).Split(' ')[1].Split(':')[1];
                }

                cmdUser.Parameters.Add("@TimeEnd", SqlDbType.NVarChar).Value = DBNull.Value;
                SqlCommand checker = new SqlCommand("SELECT COUNT(PConsultationId) FROM [dbo].[PeerAdviserConsultations] WHERE SYTerm = '" + cmdUser.Parameters[1].Value + "' and StudentNumber = '" + cmdUser.Parameters[2].Value + "' and ConsultationType='" + cmdUser.Parameters[3].Value + "' and ConsultationDate = '" + cmdUser.Parameters[9].Value + "' and TimeStart='" + cmdUser.Parameters[10].Value + "' and STATUS = 'PENDING'");
                if(Class2.getSingleData(checker) == "0")
                {
                    Class2.exe(cmdUser);
                    string advNum = Class2.getSingleData("SELECT dbo.Student.Contact FROM dbo.PeerAdviser INNER JOIN dbo.Student ON dbo.PeerAdviser.StudentNumber = dbo.Student.StudentNumber WHERE PAdviserId = (SELECT TOP 1 PAdviserId FROM [dbo].[PeerAdviserConsultations] ORDER BY PConsultationId desc)");

                    string apptDet = Class2.getSingleData("SELECT TOP 1 (CONVERT(varchar(10),ConsultationDate) + ';' + CONVERT(varchar(5), TimeStart) + ';' + CourseCode + ';' + (SELECT StudentName From dbo.Student WHERE dbo.Student.[StudentNumber] = dbo.PeerAdviserConsultations.StudentNumber)) FROM [dbo].[PeerAdviserConsultations] ORDER BY PConsultationId desc");

                    msg("0" + advNum, apptDet.Split(';')[3] + " has scheduled an appointment to you at " + apptDet.Split(';')[0]  + " " + apptDet.Split(';')[1] + " regarding the course " + apptDet.Split(';')[2] + ". Topic : " + txtTopic.Text, "ST-CLARE459781_VHVVV");

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Appointment has been scheduled!');window.location ='StudentPeerAppointment.aspx';", true);
                }
                else
                {
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Please reschedule. You already have an appointment at that time.'); window.location ='StudentPeerAppointment.aspx';", true);

                }  
            }
            catch
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Please choose a peer adviser and a schedule'); window.location ='StudentPeerAppointment.aspx';", true);
            }
        }
    }
}

