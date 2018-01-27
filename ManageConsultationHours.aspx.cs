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

    string time, aAvail = "";
    LinkButton ichi, ni, san, yon, go, roku;
    

    protected void Page_Load(object sender, EventArgs e)
    {

        checkUsertype.filter("FACULTY", Session["UserType"].ToString());

        if (!IsPostBack)
        {
            populateSched();
        }
 
    }

    public void populateSched()
    {

        string aSched = Class2.getSingleData("SELECT [AdviserSchedule] FROM [dbo].[AcademicAdviser] WHERE UserId = " + Session["UserId"]);
        string[] availableTime = new string[60];

        int aTimeCount = Regex.Matches(aSched, ";").Count;

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

    protected void LinkButtons_Click(object sender, EventArgs e)
    {
        LinkButton source = (LinkButton)sender;

        if (source.Text == "AVAILABLE")
            source.Text = "---";
        else
            source.Text = "AVAILABLE";

        
    }

    private void LoopTextboxes()
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

                if(linkbuttonkaru.Text == "AVAILABLE")
                {
                    aAvail += checkUsertype.convertToTime(linkbuttonkaru.ID).Split(';')[0] + "(" + checkUsertype.convertToTime(linkbuttonkaru.ID).Split(';')[1].Split(' ')[1] + ");";
                }
                    
                karuuu++;
            }
            x++;
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        LoopTextboxes();
        if (aAvail == "")
            aAvail = ";";

        SqlCommand cmdUser = new SqlCommand("UPDATE [dbo].[AcademicAdviser] SET [AdviserSchedule] = '" + aAvail + "' WHERE AAdviserId = " + Session["AAdviserId"]);
        Class2.exe(cmdUser);
        Response.Redirect("ManageConsultationHours.aspx");
    }
}