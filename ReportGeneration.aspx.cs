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
        if(!IsPostBack)
        {
            reportForZ("PEER");
        }
    }
    
    public void reportForZ(string status)
    {
        SqlCommand cmd = new SqlCommand("SELECT dbo.Student.StudentName, dbo.Student.StudentNumber, dbo.StudentStatus.Program, (SELECT CASE WHEN dbo.StudentGrades.Grade <> 5.00 THEN 'PASSED' ELSE 'FAILED' END) AS Remarks, dbo.StudentGrades.SYTerm, (SELECT COUNT(*) FROM [PeerAdviserConsultations] WHERE [StudentNumber] = dbo.Student.StudentNumber and [CourseCode] = dbo.PeerAdviserConsultations.CourseCode and Status = 'DONE') AS COUNT, dbo.PeerAdviserConsultations.CourseCode, dbo.StudentGrades.Grade, CONVERT(varchar,dbo.PeerAdviserConsultations.ConsultationDate,101) AS ConsultationDate, dbo.PeerAdviserConsultations.TimeStart, dbo.PeerAdviserConsultations.TimeEnd, (SELECT dbo.Student.StudentName FROM dbo.PeerAdviser INNER JOIN dbo.Student ON dbo.PeerAdviser.StudentNumber = dbo.Student.StudentNumber where dbo.PeerAdviser.PAdviserId = dbo.PeerAdviserConsultations.PAdviserId) AS PAdviserId, dbo.StudentStatus.AcademicStatus FROM dbo.PeerAdviserConsultations INNER JOIN dbo.StudentGrades ON (dbo.PeerAdviserConsultations.StudentNumber = dbo.StudentGrades.StudentNumber and dbo.PeerAdviserConsultations.CourseCode = dbo.StudentGrades.CourseCode) INNER JOIN dbo.Student ON dbo.StudentGrades.StudentNumber = dbo.Student.StudentNumber INNER JOIN dbo.StudentStatus ON dbo.Student.StudentNumber = dbo.StudentStatus.StudentNumber WHERE dbo.PeerAdviserConsultations.Status = 'DONE' and dbo.StudentStatus.CurrentStatus = '" + status + "' ORDER BY StudentName, CourseCode");
       
        GridViewZ.DataSource = Class2.getDataSet(cmd);
        GridViewZ.DataBind();

        for (int rowIndex = GridViewZ.Rows.Count - 2; rowIndex >= 0; rowIndex--)
        {
            GridViewRow row = GridViewZ.Rows[rowIndex];
            GridViewRow previousRow = GridViewZ.Rows[rowIndex + 1];
 
            if (row.Cells[2].Text == previousRow.Cells[2].Text && row.Cells[0].Text == previousRow.Cells[0].Text && row.Cells[7].Text == previousRow.Cells[7].Text)
            {
                row.Cells[2].RowSpan = previousRow.Cells[2].RowSpan < 2 ? 2 : 
                                       previousRow.Cells[2].RowSpan + 1;
                previousRow.Cells[2].Visible = false;
            }
        }
    }
    
    public void reportForEE(string SYTERM)
    {
        SqlCommand cmd = new SqlCommand("SELECT [Student Name], Sessions, Advisees, Sessions * 3.5 as [Sessions (70%)], Advisees * 3 as [Advisees (30%)], Sessions * 3.5 + Advisees * 3 as [Total (100%)], CAST(ROUND((Sessions * 3.5 + Advisees * 3) / 3.333333, 2) as numeric(36,2)) as [Number of Advisees Assisted (30%)], CAST(ROUND((Sessions * 3.5 + Advisees * 3) / 3.333333, 0) as numeric(36,0)) as Actual FROM (SELECT dbo.Student.StudentName as [Student Name], (SELECT COUNT(PConsultationId) FROM dbo.PeerAdviserConsultations WHERE PAdviserId = (SELECT PAdviserId FROM dbo.PeerAdviser WHERE dbo.PeerAdviser.StudentNumber = dbo.Student.StudentNumber) AND SYTERM = '" + SYTERM + "' AND [STATUS]='DONE') as Sessions, (SELECT COUNT(*) FROM (SELECT DISTINCT StudentNumber FROM dbo.PeerAdviserConsultations WHERE PAdviserId = (SELECT PAdviserId FROM dbo.PeerAdviser WHERE dbo.PeerAdviser.StudentNumber = dbo.Student.StudentNumber) AND SYTERM = '" + SYTERM + "' AND [STATUS]='DONE') as Advisees) as Advisees FROM dbo.Student JOIN dbo.PeerAdviser ON dbo.Student.StudentNumber = dbo.PeerAdviser.StudentNumber) as EE");
       
        GridViewEE  .DataSource = Class2.getDataSet(cmd);
        GridViewEE.DataBind();
    }
    
    public void Type_Change(Object sender, EventArgs e)
    {
        if(ddlType.SelectedIndex == 0)
            reportForZ("PEER"); 
        else if(ddlType.SelectedIndex == 1)
            reportForZ("EWP"); 
        else if(ddlType.SelectedIndex == 2)
            reportForZ("CARE"); 
        else if(ddlType.SelectedIndex == 3)
            reportForZ("PLAN AHEAD"); 
    }
    
    public void GV_Change(Object sender, EventArgs e)
    {
        if(ddlRep.SelectedIndex == 0)
        {
            GridViewZ.Visible = true;
            GridViewEE.Visible = false;
        }
        else if(ddlRep.SelectedIndex == 1)
        {
            GridViewZ.Visible = false;
            GridViewEE.Visible = true;
        }

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
        
        //GridView Changer
        if(GridViewZ.Visible == true)
        {
            exportZExcel(hw);
        }
        
        //Needed
        string style = @"<style> .textmode { mso-number-format:\@; } </style>";
        Response.Write(style);
        Response.Output.Write(sw.ToString());
        Response.Flush();
        Response.End();
    }
    
    public void exportZExcel(HtmlTextWriter htw)
    {
            GridViewZ.AllowPaging = false;
            GridViewZ.DataBind();
            GridViewZ.HeaderRow.Style.Add("background-color", "#FFFFFF");
            GridViewZ.HeaderRow.Cells[0].Style.Add("background-color", "green");
            GridViewZ.HeaderRow.Cells[1].Style.Add("background-color", "green");
            GridViewZ.HeaderRow.Cells[2].Style.Add("background-color", "green");
            GridViewZ.HeaderRow.Cells[3].Style.Add("background-color", "green");  

            for (int i = 0; i < GridViewZ.Rows.Count;i++ )
            {

                GridViewRow row = GridViewZ.Rows[i];
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

            GridViewZ.RenderControl(htw);
    }
    
    public override void VerifyRenderingInServerForm(Control control)
    {
         //base.VerifyRenderingInServerForm(control);
    }
}


