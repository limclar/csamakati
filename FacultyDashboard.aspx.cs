using System;
using System.Collections.Generic;
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

        if(!IsPostBack)
        {
            LoopTextboxes(0, "PENDING");
            conCount(0);
            ddlWeek.SelectedIndex = 1;
        }
    }

    public void conCount(int week)
    {
/*
        btnToday.Text = Class2.getSingleData("SELECT COUNT(*) AS ConsultationToday FROM dbo.AcademicAdviserConsultations INNER JOIN dbo.AcademicAdviser ON dbo.AcademicAdviserConsultations.AAdviserId = dbo.AcademicAdviser.AAdviserId WHERE ConsultationDateTime >= GETDATE()+" + week + " AND ConsultationDateTime <= CONVERT(date, GETDATE() + 1 +" + week + ")  AND dbo.AcademicAdviser.UserId = " + Session["UserId"] + " AND dbo.AcademicAdviserConsultations.Status = 'PENDING'");
*/
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


                SqlCommand cmd = new SqlCommand("SELECT StudentNumber FROM [dbo].[AcademicAdviserConsultations] WHERE ConsultationDateTime = (SELECT CONVERT(VARCHAR(50), (DATEADD(dd, " + (Int32.Parse(value.Split(';')[0])+week) + "-(DATEPART(dw, GETDATE())), CONVERT(date, getdate()))), 120) + ' " + value.Split(';')[1] + "') and Status = '" + stat + "' and AAdviserId = " + Session["AAdviserId"]);
                SqlCommand cmdCount = new SqlCommand("SELECT COUNT(StudentNumber) FROM [dbo].[AcademicAdviserConsultations] WHERE ConsultationDateTime = (SELECT CONVERT(VARCHAR(50), (DATEADD(dd, " + (Int32.Parse(value.Split(';')[0]) + week) + "-(DATEPART(dw, GETDATE())), CONVERT(date, getdate()))), 120) + ' " + value.Split(';')[1] + "') and Status = '" + stat + "' and AAdviserId = " + Session["AAdviserId"]);
                if (Int32.Parse(Class2.getSingleData(cmdCount)) > 1)
                {
                    linkbuttonkaru.Text = Class2.getSingleData(cmdCount) + " students";
                }
                else
                {
                    linkbuttonkaru.Text = Class2.getSingleData(cmd);
                }
                karuuu++;
            }
            x++;
        }
    }

    protected void ddlWeek_SelectedIndexChanged(object sender, EventArgs e)
    {
        if(ddlWeek.SelectedValue == "Previous")
        {
            LoopTextboxes(-7, "DONE");
        }
        else if(ddlWeek.SelectedValue == "Next")
        {
            LoopTextboxes(7, "PENDING");
        }
        else
        {
            LoopTextboxes(0, "PENDING");
        }

    }
}
