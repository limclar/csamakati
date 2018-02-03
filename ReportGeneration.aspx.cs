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
        SqlCommand cmd = new SqlCommand("SELECT [Student Name] as Adviser, Sessions, Advisees, Sessions * 3.5 as [Sessions (70%)], Advisees * 3 as [Advisees (30%)], Sessions * 3.5 + Advisees * 3 as [Total (100%)], CAST(ROUND((Sessions * 3.5 + Advisees * 3) / 3.333333, 2) as numeric(36,2)) as [Number of Advisees Assisted (30%)], CAST(ROUND((Sessions * 3.5 + Advisees * 3) / 3.333333, 0) as numeric(36,0)) as Actual FROM (SELECT dbo.Student.StudentName as [Student Name], (SELECT COUNT(PConsultationId) FROM dbo.PeerAdviserConsultations WHERE PAdviserId = (SELECT PAdviserId FROM dbo.PeerAdviser WHERE dbo.PeerAdviser.StudentNumber = dbo.Student.StudentNumber) AND SYTERM = '" + SYTERM + "' AND [STATUS]='DONE') as Sessions, (SELECT COUNT(*) FROM (SELECT DISTINCT StudentNumber FROM dbo.PeerAdviserConsultations WHERE PAdviserId = (SELECT PAdviserId FROM dbo.PeerAdviser WHERE dbo.PeerAdviser.StudentNumber = dbo.Student.StudentNumber) AND SYTERM = '" + SYTERM + "' AND [STATUS]='DONE') as Advisees) as Advisees FROM dbo.Student JOIN dbo.PeerAdviser ON dbo.Student.StudentNumber = dbo.PeerAdviser.StudentNumber) as EE Order By Adviser");
       
        GridViewEE.DataSource = Class2.getDataSet(cmd);
        GridViewEE.DataBind();
    }
    
    public void reportForFF()
    {
        SqlCommand cmd = new SqlCommand("SELECT ROW_NUMBER() OVER (ORDER BY StudentName ASC) AS Rank, StudentName, (Select OrganizationName From dbo.Organization WHERE dbo.Organization.OrganizationId = PeerAdviser.OrganizationId) as Organization, TeachingSubject as [Subject], '' as [Attendance on Declared Schedule (30%)], '' as [Evaluation of Peer Advisees (20%)], '' as [Participation in PA Activity (20%)], '' as [Number of Peer Advisees Assisted (30%)], '' as [Total (100%)] FROM PeerAdviser JOIN Student ON PeerAdviser.Studentnumber = Student.StudentNumber WHERE dbo.PeerAdviser.[STATUS]='ACTIVE' Order by StudentName");
       
        GridViewFF.DataSource = Class2.getDataSet(cmd);
        GridViewFF.DataBind();
    }
    
    public void reportForGG(string SYTERM)
    {
        SqlCommand cmd = new SqlCommand("SELECT (SELECT StudentName FROM Student JOIN PeerAdviser ON Student.StudentNumber = PeerAdviser.StudentNumber JOIN PeerAdviserConsultations ON PeerAdviser.PAdviserId = PeerAdviserConsultations.PAdviserId WHERE PeerAdviserConsultations.PConsultationId = ConsultationEvaluation.PConsultationId and PeerAdviser.[Status] = 'ACTIVE')  AS Adviser, StudentName as Advisee, Mastery * 2 as Mastery, Respect * 2 as Respect, EncourageAdvisee * 2 as [Encourage Advisee], ManageAdvisee * 2 as [Manage Advisee's Records Properly], ShareLearning * 2 as [Shares Learning Techniques Unselfishly], (Mastery * 2 + Respect * 2 + EncourageAdvisee * 2 + ManageAdvisee * 2 + ShareLearning * 2) as Total FROM ConsultationEvaluation JOIN PeerAdviserConsultations ON ConsultationEvaluation.PConsultationId = PeerAdviserConsultations.PConsultationId JOIN Student ON PeerAdviserConsultations.StudentNumber = Student.StudentNumber WHERE PeerAdviserConsultations.SYTerm = '" + SYTERM + "' ORDER BY ADVISER");
       
        GridViewGG.DataSource = Class2.getDataSet(cmd);
        GridViewGG.DataBind();
    }
    
    public void reportFoxR()
    {
        SqlCommand cmd = new SqlCommand("SELECT  dbo.Student.StudentName as [Name], dbo.PeerAdviser.TeachingSubject as [Subject Taught], dbo.StudentStatus.Program, dbo.Organization.OrganizationName as Organization FROM dbo.Organization JOIN dbo.PeerAdviser ON dbo.Organization.OrganizationId = dbo.PeerAdviser.OrganizationId INNER JOIN dbo.Student ON dbo.PeerAdviser.StudentNumber = dbo.Student.StudentNumber INNER JOIN dbo.StudentStatus ON dbo.Student.StudentNumber = dbo.StudentStatus.StudentNumber WHERE [Status] = 'ACTIVE'");
       
        GridViewR.DataSource = Class2.getDataSet(cmd);
        GridViewR.DataBind();
    }
    
    public void reportFoxS(string SYTERM)
    {
        SqlCommand cmd = new SqlCommand("SELECT dbo.Student.StudentNumber, dbo.Student.StudentName, Program, dbo.StudentStatus.AcademicAdviser FROM dbo.Student JOIN dbo.StudentStatus ON dbo.Student.StudentNumber = dbo.StudentStatus.StudentNumber WHERE LastEnrolled = '" + SYTERM + "' order by program, dbo.student.studentnumber, dbo.student.studentname");
       
        GridViewS.DataSource = Class2.getDataSet(cmd);
        GridViewS.DataBind();
    }
    
    public void reportForY()
    {
    }
    
    public void reportForX(string SYTERM)
    {
        SqlCommand cmd = new SqlCommand("SELECT FORMAT(dbo.AcademicAdviserConsultations.ConsultationDateTime, 'MMMM dd yyyy') as [Date], dbo.Student.StudentName, dbo.Student.StudentNumber, dbo.StudentStatus.Program, dbo.AcademicAdviserConsultations.NatureOfAdvising, ActionTaken,dbo.AcademicAdviser.FName + ' ' + dbo.AcademicAdviser.LName as [Academic Adviser] FROM dbo.AcademicAdviser INNER JOIN dbo.AcademicAdviserConsultations ON dbo.AcademicAdviser.AAdviserId = dbo.AcademicAdviserConsultations.AAdviserId INNER JOIN dbo.Student ON dbo.AcademicAdviserConsultations.StudentNumber = dbo.Student.StudentNumber INNER JOIN dbo.StudentStatus ON dbo.Student.StudentNumber = dbo.StudentStatus.StudentNumber WHERE dbo.AcademicAdviser.[Status] = 'ACTIVE' AND dbo.AcademicAdviserConsultations.SYTerm = '" + SYTERM + "' AND dbo.StudentStatus.[SYTerm] = '" + SYTERM + "' ORDER BY [Academic Adviser], ConsultationDateTime");
       
        GridViewX.DataSource = Class2.getDataSet(cmd);
        GridViewX.DataBind();
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
            GridViewEE.Visible = false; GridViewFF.Visible = false; GridViewGG.Visible = false;GridViewS.Visible = false; GridViewX.Visible = false; GridViewR.Visible = false;
            reportForZ("PEER");
        }
        else if(ddlRep.SelectedIndex == 1)
        {
            GridViewEE.Visible = true;
            GridViewZ.Visible = false; GridViewFF.Visible = false; GridViewGG.Visible = false; GridViewS.Visible = false; GridViewX.Visible = false; GridViewR.Visible = false;
            reportForEE("2017 - 2");
        }
        else if(ddlRep.SelectedIndex == 2)
        {
            GridViewEE.Visible = false; GridViewGG.Visible = false; GridViewZ.Visible = false; GridViewS.Visible = false; GridViewX.Visible = false; GridViewR.Visible = false;          
            GridViewFF.Visible = true;          
            reportForFF();
        }
        else if(ddlRep.SelectedIndex == 3)
        {
            GridViewEE.Visible = false; GridViewFF.Visible = false;GridViewZ.Visible = false; GridViewS.Visible = false; GridViewX.Visible = false; GridViewR.Visible = false;  
            GridViewGG.Visible = true;
            reportForGG("2017 - 2");
        }
        else if(ddlRep.SelectedIndex == 4)
        {
            GridViewZ.Visible = false; GridViewEE.Visible = false; GridViewFF.Visible = false; GridViewGG.Visible = false; GridViewS.Visible = false; GridViewX.Visible = false;
            GridViewR.Visible = true;
            reportForR();
        }
        else if(ddlRep.SelectedIndex == 5)
        {
            GridViewZ.Visible = false; GridViewEE.Visible = false; GridViewFF.Visible = false; GridViewGG.Visible = false; GridViewR.Visible = false; GridViewX.Visible = false;
            GridViewS.Visible = true;
            reportForS("2017 - 2");
        }
        else if(ddlRep.SelectedIndex == 6)
        {
            GridViewZ.Visible = false; GridViewEE.Visible = false; GridViewFF.Visible = false; GridViewGG.Visible = false; GridViewR.Visible = false; GridViewS.Visible = false;
            GridViewX.Visible = true;
            reportForX("2017 - 2");
        }
        else if(ddlRep.SelectedIndex == 7)
        {
            GridViewZ.Visible = false; GridViewEE.Visible = false; GridViewFF.Visible = false; GridViewGG.Visible = false; GridViewR.Visible = false; GridViewS.Visible = false; GridViewX.Visible = false;
            //GridViewY.Visible = true;
            reportForY("2017 - 2");
        }

    }

    protected void btnExportToExcel_Click(object sender, EventArgs e)
    {    
        Response.Clear();

        Response.AddHeader("content-disposition", "attachment; filename=FileName.xls");


        Response.ContentType = "application/vnd.xls";

        System.IO.StringWriter stringWrite = new System.IO.StringWriter();

        System.Web.UI.HtmlTextWriter htmlWrite =
        new HtmlTextWriter(stringWrite);
        
        if(GridViewZ.Visible == true)
        {
            GridViewZ.RenderControl(htmlWrite);
        }
        else if(GridViewEE.Visible == true)
        {
            GridViewEE.RenderControl(htmlWrite);  
        }
        else if(GridViewFF.Visible == true)
        {
            GridViewFF.RenderControl(htmlWrite);  
        }
        else if(GridViewGG.Visible == true)
        {
            GridViewGG.RenderControl(htmlWrite);  
        }
        else if(GridViewR.Visible == true)
        {
            GridViewR.RenderControl(htmlWrite);  
        }
        else if(GridViewS.Visible == true)
        {
            GridViewS.RenderControl(htmlWrite);  
        }
        else if(GridViewX.Visible == true)
        {
            GridViewX.RenderControl(htmlWrite);  
        }
        /*
        else if(GridViewY.Visible == true)
        {
            GridViewY.RenderControl(htmlWrite);  
        }*/
        

        Response.Write(stringWrite.ToString());

        Response.End();
        
        

    }
    
    
    
    public static void WriteAttachment(string FileName, string FileType, string content)
    {
        HttpResponse Response = System.Web.HttpContext.Current.Response;
        Response.ClearHeaders();
        Response.AppendHeader("Content-Disposition", "attachment; filename=" + FileName);
        Response.ContentType = FileType;
        Response.Write(content);
        Response.End();
    }
    
    public override void VerifyRenderingInServerForm(Control control)
    {
      /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
         server control at run time. */
    }
}


