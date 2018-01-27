using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
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
}