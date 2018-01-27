using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;   
using System.Web.UI.DataVisualization.Charting;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            checkUsertype.filter("STAFF", Session["UserType"].ToString());
        }
        catch
        {
            Response.Redirect("In.aspx");
        }
        BindChart();

        btnToday.Text = Class2.getSingleData("SELECT COUNT(*) AS ApptToday FROM dbo.PeerAdviserConsultations WHERE ConsultationDate = CONVERT(date, GETDATE()) AND STATUS = 'PENDING' AND TimeEnd IS NULL AND (ConsultationType = 'APPOINTMENT' OR ConsultationType = 'EWP')");
        btnWeek.Text = Class2.getSingleData("SELECT COUNT(*) AS ApptToday FROM dbo.PeerAdviserConsultations WHERE ConsultationDate >= CONVERT(date, GETDATE()) AND ConsultationDate <= CONVERT(date ,DATEADD(dd, 7-(DATEPART(dw, GETDATE())), GETDATE())) AND STATUS = 'PENDING' AND TimeEnd IS NULL AND (ConsultationType = 'APPOINTMENT' OR ConsultationType = 'EWP')");
        btnMonth.Text = Class2.getSingleData("SELECT COUNT(*) AS ApptToday FROM dbo.PeerAdviserConsultations WHERE ConsultationDate >= GETDATE() AND ConsultationDate<DATEADD(MONTH, DATEDIFF(MONTH, 0, GETDATE())+1, 0)-1 AND STATUS = 'PENDING' AND TimeEnd IS NULL AND (ConsultationType = 'APPOINTMENT' OR ConsultationType = 'EWP')");
        //btnMonth.Text = Class2.getSingleData("SELECT COUNT(*) AS ApptToday FROM dbo.PeerAdviserConsultations WHERE ConsultationDate >= DATEADD(MONTH, DATEDIFF(MONTH, 0, GETDATE()), 0) AND ConsultationDate < DATEADD(MONTH, DATEDIFF(MONTH, 0, GETDATE())+1, 0) AND STATUS = 'PENDING' AND TimeEnd IS NULL;"); 
    }

    protected void test1_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        Chart ch = (Chart)e.Item.FindControl("Chart1");
        ch.DataSource = Class2.getDataSet(@"SELECT COUNT(*) AS ApptToday FROM dbo.PeerAdviserConsultations WHERE ConsultationDate >= GETDATE() AND ConsultationDate<DATEADD(MONTH, DATEDIFF(MONTH, 0, GETDATE())+1, 0)-1 AND STATUS = 'PENDING' AND TimeEnd IS NULL");
        ch.DataBind();
    }
    
    private DataTable GetChartData()  
    {  
        DataSet dsData = new DataSet();  
        try  
        {  
            SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString);  
            SqlDataAdapter sqlCmd = new SqlDataAdapter("SELECT dbo.Department.DeptNameFROM dbo.Department INNER JOIN dbo.Subjects ON dbo.Department.DeptId = dbo.Subjects.DeptId INNER JOIN dbo.PeerAdviserConsultations ON dbo.Subjects.CourseCode = dbo.PeerAdviserConsultations.CourseCode", sqlCon);  
              
  
            sqlCon.Open();  
  
            sqlCmd.Fill(dsData);  
  
            sqlCon.Close();  
        }  
        catch  
        {  
            throw;  
        }  
        return dsData.Tables[0];  
    }   
    
    private void BindChart()  
    {  
        DataTable dsChartData = new DataTable();  
        StringBuilder strScript = new StringBuilder();  
  
        try  
        {  
            dsChartData = GetChartData();  
  
            strScript.Append(@"<script type='text/javascript'>  
                    google.load('visualization', '1', {packages: ['corechart']}); </script>  
                      
                    <script type='text/javascript'>  
                     
                    function drawChart() {         
                    var data = google.visualization.arrayToDataTable([  
                    ['Subject', 'Count'],");  
  
            foreach (DataRow row in dsChartData.Rows)  
            {  
                strScript.Append("['" + row["DeptName"] + "'," + row["Count"] + "],");  
            }  
            strScript.Remove(strScript.Length - 1, 1);  
            strScript.Append("]);");  
  
            strScript.Append(@" var options = {     
                                    title: 'Subject',            
                                    is3D: true,          
                                    };   ");  
  
            strScript.Append(@"var chart = new google.visualization.PieChart(document.getElementById('piechart_3d'));          
                                chart.draw(data, options);        
                                }    
                            google.setOnLoadCallback(drawChart);  
                            ");  
            strScript.Append(" </script>");  
  
            ltScripts.Text = strScript.ToString();  
        }  
        catch  
        {  
        }  
        finally  
        {  
            dsChartData.Dispose();  
            strScript.Clear();  
        }  
    }   
}
