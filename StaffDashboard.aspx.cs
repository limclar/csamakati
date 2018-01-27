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
        try
        {
            checkUsertype.filter("STAFF", Session["UserType"].ToString());
        }
        catch
        {
            Response.Redirect("In.aspx");
        }
        // Bind Gridview  
            BindGvData();  
  
            // Bind Charts  
            BindChart();   

        btnToday.Text = Class2.getSingleData("SELECT COUNT(*) AS ApptToday FROM dbo.PeerAdviserConsultations WHERE ConsultationDate = CONVERT(date, GETDATE()) AND STATUS = 'PENDING' AND TimeEnd IS NULL AND (ConsultationType = 'APPOINTMENT' OR ConsultationType = 'EWP')");
        btnWeek.Text = Class2.getSingleData("SELECT COUNT(*) AS ApptToday FROM dbo.PeerAdviserConsultations WHERE ConsultationDate >= CONVERT(date, GETDATE()) AND ConsultationDate <= CONVERT(date ,DATEADD(dd, 7-(DATEPART(dw, GETDATE())), GETDATE())) AND STATUS = 'PENDING' AND TimeEnd IS NULL AND (ConsultationType = 'APPOINTMENT' OR ConsultationType = 'EWP')");
        btnMonth.Text = Class2.getSingleData("SELECT COUNT(*) AS ApptToday FROM dbo.PeerAdviserConsultations WHERE ConsultationDate >= GETDATE() AND ConsultationDate<DATEADD(MONTH, DATEDIFF(MONTH, 0, GETDATE())+1, 0)-1 AND STATUS = 'PENDING' AND TimeEnd IS NULL AND (ConsultationType = 'APPOINTMENT' OR ConsultationType = 'EWP')");
    }
    
    private void BindGvData()  
    {  
        gvData.DataSource = GetChartData(""SELECT Status, COUNT(STATUS) as Count FROM dbo.PeerAdviserConsultations WHERE ConsultationDate >= CONVERT(date, GETDATE()) AND ConsultationDate <= CONVERT(date ,DATEADD(dd, 7-(DATEPART(dw, GETDATE())), GETDATE())) GROUP BY STATUS "");  
        gvData.DataBind();  
    } 

    protected void test1_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        Chart ch = (Chart)e.Item.FindControl("Chart1");
        ch.DataSource = Class2.getDataSet(@"SELECT COUNT(*) AS ApptToday FROM dbo.PeerAdviserConsultations WHERE ConsultationDate >= GETDATE() AND ConsultationDate<DATEADD(MONTH, DATEDIFF(MONTH, 0, GETDATE())+1, 0)-1 AND STATUS = 'PENDING' AND TimeEnd IS NULL");
        ch.DataBind();
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
    
    private void BindChart()  
    {  
        DataTable dsChartData = new DataTable();  
        StringBuilder strScript = new StringBuilder();  
  
        try  
        {  
            dsChartData = GetChartData("SELECT Status, COUNT(STATUS) as Count FROM dbo.PeerAdviserConsultations WHERE ConsultationDate >= CONVERT(date, GETDATE()) AND ConsultationDate <= CONVERT(date ,DATEADD(dd, 7-(DATEPART(dw, GETDATE())), GETDATE())) GROUP BY STATUS");
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
                                    title: 'Peer Advising',            
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
}
