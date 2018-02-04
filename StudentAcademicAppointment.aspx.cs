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
    int dayCon = 0;

    LinkButton ichi, ni, san, yon, go, roku;
    protected void Page_Load(object sender, EventArgs e)
    {
        checkUsertype.filter("STUDENT", Session["UserType"].ToString());
        
        if (!IsPostBack)
        {
            Session["StudGroup"] = Session["StudentNumber"].ToString();
            ddlDepartment.DataSource = Class2.getDataSet("SELECT [DeptId], [DeptName] FROM [dbo].[Department]");
            ddlDepartment.DataValueField = "DeptId";
            ddlDepartment.DataTextField = "DeptName";
            ddlDepartment.DataBind();

            populateStudents();
            populateGroup();

            fiilFaculty();
            populateSched();
        }
    }

    public void populateGroup()
    {
        ddlGroup.DataSource = Class2.getDataSet("SELECT [StudentNumber] FROM [dbo].[Student] WHERE [StudentNumber] IN (" + Session["StudGroup"] + ");");
        ddlGroup.DataValueField = "StudentNumber";
        ddlGroup.DataTextField = "StudentNumber";
        ddlGroup.DataBind();
    }

    public void populateStudents()
    {
        ddlAddStudent.DataSource = Class2.getDataSet("SELECT [StudentNumber] FROM [dbo].[Student] WHERE [StudentNumber] NOT IN (" + Session["StudGroup"] + ");");
        ddlAddStudent.DataValueField = "StudentNumber";
        ddlAddStudent.DataTextField = "StudentNumber";
        ddlAddStudent.DataBind();
    }

    public void fiilFaculty()
    {
        ddlFaculty.DataSource = Class2.getDataSet("SELECT [AAdviserId], [LName] + ', ' + [FName] + ' (' + [MName] + ')' AS [FullName], [Status] FROM [dbo].[AcademicAdviser] WHERE [Status] = 'ACTIVE' and DeptId = " + ddlDepartment.SelectedValue);
        ddlFaculty.DataValueField = "AAdviserId";
        ddlFaculty.DataTextField = "FullName";
        ddlFaculty.DataBind();
    }

    public void populateSched()
    {

        String aSched = Class2.getSingleData("SELECT TOP 1 [AdviserSchedule] FROM [dbo].[AcademicAdviser] WHERE AAdviserId = " + ddlFaculty.SelectedValue);

        int aTimeCount = Regex.Matches(aSched, ";").Count;

        string[] availableTime = new string[aTimeCount + 1];

        for (int aTimeIndex = 0; aTimeIndex < aTimeCount; aTimeIndex++)
        {
            if (aTimeIndex <= aTimeCount)
                availableTime[aTimeIndex] = aSched.Split(';')[aTimeIndex];
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
                case 7:
                    time = "18:00-19:30";
                    ichi = H1; ni = H2; san = H3; yon = H4; go = H5; roku = H6;
                    break;
                case 8:
                    time = "19:30-21:00";
                    ichi = I1; ni = I2; san = I3; yon = I4; go = I5; roku = I6;
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

    protected void ddlDepartment_SelectedIndexChanged(object sender, EventArgs e)
    {
        fiilFaculty();
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
        H1.Text = "---"; H2.Text = "---"; H3.Text = "---"; H4.Text = "---"; H5.Text = "---"; H6.Text = "---";
        I1.Text = "---"; I2.Text = "---"; I3.Text = "---"; I4.Text = "---"; I5.Text = "---"; I6.Text = "---";
    }

    protected void ddlFaculty_SelectedIndexChanged(object sender, EventArgs e)
    {
        clearTable();
        populateSched();
    }

    protected void LinkButtons_Click(object sender, EventArgs e)
    {
        LinkButton source = (LinkButton)sender;


        if (source.Text == "AVAILABLE")
        {
            Session["sCounter"] = 1;
            Session["ConsultationDate"] = checkUsertype.convertToTime(source.ID.ToString());
            Session["Header"] = Session["ConsultationDate"].ToString().Split(';')[0] + Session["ConsultationDate"].ToString().Split(';')[1];
            Session["uCode"] = checkUsertype.RandomString(6);
            lblConCode.Text = Session["uCode"].ToString();

            ScriptManager.RegisterStartupScript(this, typeof(string), "uniqueKey", "div_show()", true);
        }
        else if (source.Text == "SELECTED" && Session["sCounter"].ToString() == "1")
        {
            source.Text = "AVAILABLE";
            Session["sCounter"] = 0;
        }
        //
    }

    public void addAppointment(object sender, EventArgs e)
    {
        string cd = Session["ConsultationDate"].ToString().Split(';')[0];
        string ct = Session["ConsultationDate"].ToString().Split(';')[1];
        int grpCount = Regex.Matches(Session["StudGroup"].ToString(), ",").Count + 1;

        for(int i = 1; i <= grpCount; i++)
        {
            try
            {
                SqlCommand cmdUser = new SqlCommand("[sp_t_AConsultation_ups]");
                cmdUser.CommandType = CommandType.StoredProcedure;
                cmdUser.Parameters.Add("@AConsultationId", SqlDbType.NVarChar).Value = "0";
                cmdUser.Parameters.Add("@ConsultationCode", SqlDbType.NVarChar).Value = lblConCode.Text;
                cmdUser.Parameters.Add("@SYTerm", SqlDbType.NVarChar).Value = Session["SYTerm"];
                cmdUser.Parameters.Add("@StudentNumber", SqlDbType.NVarChar).Value = Session["StudGroup"].ToString().Split(',')[i-1];
                cmdUser.Parameters.Add("@Status", SqlDbType.NVarChar).Value = DBNull.Value;
                cmdUser.Parameters.Add("@DeptId", SqlDbType.NVarChar).Value = ddlDepartment.SelectedValue;
                cmdUser.Parameters.Add("@AAdviserId", SqlDbType.NVarChar).Value = ddlFaculty.SelectedValue;
            
                SqlCommand cmdX = new SqlCommand("[sp_t_GetConDateTime_ups]");
                cmdX.CommandType = CommandType.StoredProcedure;
                cmdX.Parameters.Add("@time", SqlDbType.NVarChar).Value = ct.Split('-')[0]; //timestart
                switch (cd)
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

                string check = Class2.getSingleData("IF GETDATE() > CONVERT(datetime, '" + cmdxX + ct.Split('-')[0] + "') SELECT CONVERT(datetime, '" + cmdxX + ct.Split('-')[0] + "')+7 ELSE SELECT 'NO'");

                if (check != "NO")
                {
                    cmdxX = check;
                }
                else
                {
                    cmdxX += ct.Split('-')[0];
                }


                cmdUser.Parameters.Add("@ConsultationDateTime", SqlDbType.NVarChar).Value = cmdxX.Split(' ')[0] + ct.Split(':')[0] + ':' + cmdxX.Split(':')[1];
                cmdUser.Parameters.Add("@NatureOfAdvising", SqlDbType.NVarChar).Value = ddlNature.Text;
                cmdUser.Parameters.Add("@ActionTaken", SqlDbType.NVarChar).Value = DBNull.Value;
                SqlCommand checker = new SqlCommand("SELECT COUNT(AConsultationId) FROM [dbo].[AcademicAdviserConsultations] WHERE SYTerm = '" + cmdUser.Parameters[2].Value + "' and StudentNumber = '" + cmdUser.Parameters[3].Value + "' and ConsultationDateTime = '" + cmdUser.Parameters[7].Value + "' AND STATUS = 'PENDING'"); 
                if(Class2.getSingleData(checker) == "0")
                {
                    Class2.exe(cmdUser);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Appointment has been scheduled! Your consultation code is " + lblConCode.Text + "');window.location ='StudentAcademicAppointment.aspx';", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('ERROR! YOU ALREADY HAVE AN APPOINTMENT AT THAT TIME');window.location ='StudentAcademicAppointment.aspx';", true);
                }
            }
            catch(Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Failed to schedule an appointment!');window.location ='StudentAcademicAppointment.aspx';", true);
            }
        }
        
    }

    protected void ddlNature_SelectedIndexChanged(object sender, EventArgs e)
    {
        if(ddlNature.SelectedIndex == 7)
        {
            txtOthers.Enabled = true;
            ScriptManager.RegisterStartupScript(this, typeof(string), "uniqueKey", "div_show()", true);
        }
        else
        {
            txtOthers.Enabled = false;
            ScriptManager.RegisterStartupScript(this, typeof(string), "uniqueKey", "div_show()", true);
        }
    }

    protected void btnAddToGroupd_Click(object sender, EventArgs e)
    {
        Session["StudGroup"] += ", " + txtAddToGroup.Text;
        populateStudents();
        populateGroup();
    }
}
