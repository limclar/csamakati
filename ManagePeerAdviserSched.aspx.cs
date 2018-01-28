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
    string time, pAvail = "";
    LinkButton ichi, ni, san, yon, go, roku;

    protected void Page_Load(object sender, EventArgs e)
    {
        checkUsertype.filter("STAFF", Session["UserType"].ToString());


        if (!IsPostBack)
        {
            ddl.DataSource = Class2.getDataSet("SELECT DISTINCT dbo.Student.StudentName, dbo.Student.UserId FROM dbo.PeerAdviser INNER JOIN dbo.Student ON dbo.PeerAdviser.StudentNumber = dbo.Student.StudentNumber");
            ddl.DataValueField = "UserId";
            ddl.DataTextField = "StudentName";
            ddl.DataBind();
            //lipat this shit
            populateSched();
        }
    }

    protected void ddl_SelectedIndexChanged(object sender, EventArgs e)
    {
        populateSched();
    }

    public void populateSched()
    {

        String pSched = Class2.getSingleData("SELECT TOP 1 dbo.PeerAdviser.PeerSchedule FROM dbo.PeerAdviser INNER JOIN dbo.Student ON dbo.PeerAdviser.StudentNumber = dbo.Student.StudentNumber WHERE UserId = " + ddl.SelectedValue);

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

    protected void ddl_TextChanged(object sender, EventArgs e)
    {
        clearTable();
        populateSched();

    }

    public void clearTable()
    {
        A1.Text = "---"; A2.Text = "---"; A3.Text = "---"; A4.Text = "---"; A5.Text = "---"; A6.Text = "---";
        B1.Text = "---"; B2.Text = "---"; B3.Text = "---"; B4.Text = "---"; B5.Text = "---"; B6.Text = "---";
        C1.Text = "---"; C2.Text = "---"; C3.Text = "---"; C4.Text = "---"; C5.Text = "---"; C6.Text = "---";
        D1.Text = "---"; D2.Text = "---"; D3.Text = "---"; D4.Text = "---"; D5.Text = "---"; D6.Text = "---";
        E1.Text = "---"; E2.Text = "---"; E3.Text = "---"; E4.Text = "---"; E5.Text = "---"; E6.Text = "---";
        F1.Text = "---"; F2.Text = "---"; F3.Text = "---"; F4.Text = "---"; F5.Text = "---"; F6.Text = "---";
        G1.Text = "---"; G2.Text = "---"; G3.Text = "---"; G4.Text = "---"; G5.Text = "---"; G6.Text = "---";
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

                if (linkbuttonkaru.Text == "AVAILABLE")
                    pAvail += checkUsertype.convertToTime(linkbuttonkaru.ID).Split(';')[0] + "(" + checkUsertype.convertToTime(linkbuttonkaru.ID).Split(';')[1].Split(' ')[1] + ");";



                karuuu++;
            }
            x++;
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

    protected void btnFinalizeSched_Click(object sender, EventArgs e)
    {
        LoopTextboxes();
        if (pAvail == "")
            pAvail = ";";
        
        SqlCommand cmdUser = new SqlCommand("UPDATE[dbo].[PeerAdviser] SET[PeerSchedule] = '" + pAvail + "' WHERE PAdviserId = " + Class2.getSingleData("SELECT dbo.PeerAdviser.PAdviserId FROM dbo.PeerAdviser INNER JOIN dbo.Student ON dbo.PeerAdviser.StudentNumber = dbo.Student.StudentNumber WHERE UserId = " + ddl.SelectedValue));
        Class2.exe(cmdUser);
        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Schedule has been updated.'); window.location ='ManagePeerAdviserSched.aspx';", true);
    }
}
