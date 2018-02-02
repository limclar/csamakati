using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        checkUsertype.filter("STAFF", Session["UserType"].ToString());
        reportForStudent("PEER");
        
    }
    
    public void reportForStudent(string status)
    {
        SqlCommand cmd = new SqlCommand("SELECT dbo.Student.StudentName, dbo.Student.StudentNumber, dbo.StudentStatus.Program, (SELECT CASE WHEN dbo.StudentGrades.Grade <> 5.00 THEN 'PASSED' ELSE 'FAILED' END) AS Remarks, dbo.StudentGrades.SYTerm, (SELECT COUNT(*) FROM [PeerAdviserConsultations] WHERE [StudentNumber] = dbo.Student.StudentNumber and [CourseCode] = dbo.PeerAdviserConsultations.CourseCode and Status = 'DONE') AS COUNT, dbo.PeerAdviserConsultations.CourseCode, dbo.StudentGrades.Grade, CONVERT(varchar,dbo.PeerAdviserConsultations.ConsultationDate,101) AS ConsultationDate, dbo.PeerAdviserConsultations.TimeStart, dbo.PeerAdviserConsultations.TimeEnd, (SELECT dbo.Student.StudentName FROM dbo.PeerAdviser INNER JOIN dbo.Student ON dbo.PeerAdviser.StudentNumber = dbo.Student.StudentNumber where dbo.PeerAdviser.PAdviserId = dbo.PeerAdviserConsultations.PAdviserId) AS PAdviserId, dbo.StudentStatus.AcademicStatus FROM dbo.PeerAdviserConsultations INNER JOIN dbo.StudentGrades ON (dbo.PeerAdviserConsultations.StudentNumber = dbo.StudentGrades.StudentNumber and dbo.PeerAdviserConsultations.CourseCode = dbo.StudentGrades.CourseCode) INNER JOIN dbo.Student ON dbo.StudentGrades.StudentNumber = dbo.Student.StudentNumber INNER JOIN dbo.StudentStatus ON dbo.Student.StudentNumber = dbo.StudentStatus.StudentNumber WHERE dbo.PeerAdviserConsultations.Status = 'DONE' and dbo.StudentStatus.CurrentStatus = '" + status + "' ORDER BY StudentName, CourseCode");
       
        GridView1.DataSource = Class2.getDataSet(cmd);
        GridView1.DataBind();

        for (int rowIndex = GridView1.Rows.Count - 2; rowIndex >= 0; rowIndex--)
        {
            GridViewRow row = GridView1.Rows[rowIndex];
            GridViewRow previousRow = GridView1.Rows[rowIndex + 1];
 
            if (row.Cells[2].Text == previousRow.Cells[2].Text && row.Cells[0].Text == previousRow.Cells[0].Text && row.Cells[7].Text == previousRow.Cells[7].Text)
            {
                row.Cells[2].RowSpan = previousRow.Cells[2].RowSpan < 2 ? 2 : 
                                       previousRow.Cells[2].RowSpan + 1;
                previousRow.Cells[2].Visible = false;
            }
        }
    }
    
    public void Type_Change(Object sender, EventArgs e)
    {
        if(ddlType.SelectedIndex == 0)
            Session["conType"] = "AND (ConsultationType = 'APPOINTMENT' OR ConsultationType = 'EWP' OR ConsultationType = 'Walk-In')";
        else if(ddlType.SelectedIndex == 1)
            Session["conType"] = "AND (ConsultationType = 'APPOINTMENT' OR ConsultationType = 'EWP')";
        else if(ddlType.SelectedIndex == 2)
            Session["conType"] = "AND (ConsultationType = 'Walk-in')";
    }

    protected void btnExportToExcel_Click(object sender, EventArgs e)
    {
        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("content-disposition","attachment;filename=GridViewExport.xls");
        Response.Charset = "";
        Response.ContentType = "application/vnd.ms-excel";
        StringWriter sw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);
        
        GridView1.AllowPaging = false;
        GridView1.DataBind();
        GridView1.HeaderRow.Style.Add("background-color", "#FFFFFF");
        GridView1.HeaderRow.Cells[0].Style.Add("background-color", "green");
        GridView1.HeaderRow.Cells[1].Style.Add("background-color", "green");
        GridView1.HeaderRow.Cells[2].Style.Add("background-color", "green");
        GridView1.HeaderRow.Cells[3].Style.Add("background-color", "green");  

        for (int i = 0; i < GridView1.Rows.Count;i++ )
        {

            GridViewRow row = GridView1.Rows[i];
            row.BackColor = System.Drawing.Color.White;
            row.Attributes.Add("class", "textmode");
            if (i % 2 != 0)
            {
                row.Cells[0].Style.Add("background-color", "#C2D69B");
                row.Cells[1].Style.Add("background-color", "#C2D69B");
                row.Cells[2].Style.Add("background-color", "#C2D69B");
                row.Cells[3].Style.Add("background-color", "#C2D69B");  
            }
        }

        GridView1.RenderControl(hw);
        string style = @"<style> .textmode { mso-number-format:\@; } </style>";
        Response.Write(style);
        Response.Output.Write(sw.ToString());
        Response.Flush();
        Response.End();
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
         //base.VerifyRenderingInServerForm(control);
    }
}


