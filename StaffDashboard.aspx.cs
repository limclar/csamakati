﻿using System;
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
        Page.ClientScript.RegisterStartupScript(Me.GetType(),"refresh","window.setTimeout('var url = window.location.href;window.location.href = StaffDashboard.aspx',1000);",true);
        this.Title = "Dashboard";
        try
        {
            checkUsertype.filter("STAFF", Session["UserType"].ToString());
        }
        catch
        {
            Response.Redirect("In.aspx");
        }
        
 
        if(!IsPostBack)
        {
            Session["conType"] = "AND (ConsultationType = 'APPOINTMENT' OR ConsultationType = 'EWP' OR ConsultationType = 'Walk-In')";
            Session["queryRange"] = "ConsultationDate = CONVERT(date, GETDATE()) " + Session["conType"];
        }
        populateBtn();
        BindGvData();
        BindChart();
        BindChart2();
    }
    
    public void populateBtn()
    {
        btnToday.Text = Class2.getSingleData("SELECT COUNT(*) AS ApptToday FROM dbo.PeerAdviserConsultations WHERE ConsultationDate = CONVERT(date, GETDATE()) AND STATUS = 'PENDING' AND TimeEnd IS NULL " + Session["conType"]);
        btnWeek.Text = Class2.getSingleData("SELECT COUNT(*) AS ApptToday FROM dbo.PeerAdviserConsultations WHERE ConsultationDate >= DATEADD(dd, -(DATEPART(dw, GETUTCDATE())-1), GETUTCDATE()) AND ConsultationDate <= DATEADD(dd, 7-(DATEPART(dw, GETUTCDATE())), GETUTCDATE()) AND STATUS = 'PENDING' AND TimeEnd IS NULL " + Session["conType"]);
        btnMonth.Text = Class2.getSingleData("SELECT COUNT(*) AS ApptToday FROM dbo.PeerAdviserConsultations WHERE ConsultationDate >= DATEADD(month, DATEDIFF(month, 0, GETUTCDATE()), 0) AND ConsultationDate <= DATEADD(s,-1,dateadd(mm,datediff(m,0,getutcdate())+1,0)) AND STATUS = 'PENDING' AND TimeEnd IS NULL " + Session["conType"]);
    }
    
    public void Type_Change(Object sender, EventArgs e)
    {
        if(ddlType.SelectedIndex == 0)
            Session["conType"] = "AND (ConsultationType = 'APPOINTMENT' OR ConsultationType = 'EWP' OR ConsultationType = 'Walk-In')";
        else if(ddlType.SelectedIndex == 1)
            Session["conType"] = "AND (ConsultationType = 'APPOINTMENT' OR ConsultationType = 'EWP')";
        else if(ddlType.SelectedIndex == 2)
            Session["conType"] = "AND (ConsultationType = 'Walk-in')";
            
        populateBtn();
        string[] tokens = Session["queryRange"].ToString().Split(new[] { "AND" }, StringSplitOptions.None);
        Session["queryRange"] = tokens[0] + Session["conType"];
        BindGvData();
        BindChart();
        BindChart2();
    }
    
    public void Btn_Click(Object sender, EventArgs e)
    {
        Button btn=(Button)sender;
        
        if(btn.ID == "btnToday")
            Session["queryRange"] = "ConsultationDate = CONVERT(date, GETDATE()) " + Session["conType"];
        else if(btn.ID == "btnWeek")
            Session["queryRange"] = "ConsultationDate >= DATEADD(dd, -(DATEPART(dw, GETUTCDATE())-1), GETUTCDATE()) AND ConsultationDate <= DATEADD(dd, 7-(DATEPART(dw, GETUTCDATE())), GETUTCDATE()) " + Session["conType"];
        else if(btn.ID == "btnMonth")
            Session["queryRange"] = "ConsultationDate >= DATEADD(month, DATEDIFF(month, 0, GETUTCDATE()), 0) AND ConsultationDate <= DATEADD(s,-1,dateadd(mm,datediff(m,0,getutcdate())+1,0)) " + Session["conType"];
       
       BindGvData();
       BindChart();
       BindChart2();
       //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Consultation has been cancelled! " + Session["queryRange"] + "," + btn.ID +  "');", true);
    }
    
    private void BindGvData()  
    {  
        gvData.DataSource = GetChartData("SELECT Status, COUNT(STATUS) as Count FROM dbo.PeerAdviserConsultations WHERE " + Session["queryRange"] + " GROUP BY STATUS");  
        gvData.DataBind(); 
        
        gvData2.DataSource = GetChartData("SELECT COUNT(dbo.Department.DeptName) as Count, DeptName FROM dbo.Department INNER JOIN dbo.Subjects ON dbo.Department.DeptId = dbo.Subjects.DeptId INNER JOIN dbo.PeerAdviserConsultations ON dbo.Subjects.CourseCode = dbo.PeerAdviserConsultations.CourseCode WHERE " + Session["queryRange"] + " GROUP BY dbo.Department.DeptName");
        gvData2.DataBind();
    } 
    
    
    
    private void BindChart()  
    {  
        DataTable dsChartData = new DataTable();  
        StringBuilder strScript = new StringBuilder();  
  
        try  
        {  
            dsChartData = GetChartData("SELECT Status, COUNT(STATUS) as Count FROM dbo.PeerAdviserConsultations WHERE " + Session["queryRange"] + " GROUP BY STATUS");
            strScript.Append(@"<script type='text/javascript'>  
                    google.load('visualization', '1', {packages: ['corechart']}); </script>  
                      
                    <script type='text/javascript'>  
                     
                    function drawChart() {         
                    var data = google.visualization.arrayToDataTable([  
                    ['Status', 'Count'],");  
  
            foreach (DataRow row in dsChartData.Rows)  
            {  
                strScript.Append("['" + row["Status"] + "'," + row["Count"] + "],");  
            }  
            strScript.Remove(strScript.Length - 1, 1);  
            strScript.Append("]);");  
  
            strScript.Append(@" var options = {     
                                    title: 'Consultation Status',            
                                    pieHole: 0.4,          
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
    
    private void BindChart2()
    {
        DataTable dsChartData2 = new DataTable();  
        StringBuilder strScript2 = new StringBuilder();  
  
        try  
        {  
            dsChartData2 = GetChartData("SELECT COUNT(dbo.Department.DeptName) as Count, DeptName FROM dbo.Department INNER JOIN dbo.Subjects ON dbo.Department.DeptId = dbo.Subjects.DeptId INNER JOIN dbo.PeerAdviserConsultations ON dbo.Subjects.CourseCode = dbo.PeerAdviserConsultations.CourseCode WHERE " + Session["queryRange"] + " GROUP BY dbo.Department.DeptName"); 
            strScript2.Append(@"<script type='text/javascript'>  
                    google.load('visualization', '1', {packages: ['corechart']}); </script>  
                      
                    <script type='text/javascript'>  
                     
                    function drawChart() {         
                    var data = google.visualization.arrayToDataTable([  
                    ['DeptName', 'Count'],");  
  
            foreach (DataRow row in dsChartData2.Rows)  
            {  
                strScript2.Append("['" + row["DeptName"] + "'," + row["Count"] + "],");  
            }  
            strScript2.Remove(strScript2.Length - 1, 1);  
            strScript2.Append("]);");  
  
            strScript2.Append(@" var options = {     
                                    title: 'Departments',            
                                    is3D: true,          
                                    };   ");  
  
            strScript2.Append(@"var chart = new google.visualization.PieChart(document.getElementById('chart_div'));          
                                chart.draw(data, options);        
                                }    
                            google.setOnLoadCallback(drawChart);  
                            ");  
            strScript2.Append(" </script>");  
  
            ltScripts2.Text = strScript2.ToString();  
        } 
        catch  
        {  
        }  
        finally  
        {  
            dsChartData2.Dispose();  
            strScript2.Clear();  
        }   
    }
    
    private DataTable GetChartData(string sqlStatement)  
    {  
        DataSet dsData = new DataSet();  
        try  
        {  
            SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString);  
            SqlDataAdapter sqlCmd = new SqlDataAdapter(sqlStatement, sqlCon);  
            sqlCmd.SelectCommand.CommandType = CommandType.Text;
              
  
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
}
