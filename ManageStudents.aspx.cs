using System;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.Common;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Text.RegularExpressions;
using System.Configuration;
using System.Data.SqlClient; 
using System.Data;  

public partial class _Default : System.Web.UI.Page
{
   protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {

        }
        string uname = "";
        try
        {
            string user = Class2.getSingleData("SELECT TOP 1 (CONVERT(VARCHAR(10), StudentNumber) + ';' + StudentName) FROM STUDENT WHERE USERID = 0");
            int count = 0;
            for (int i = 0; i < user.ToString().Split(';')[1].Split(',')[1].Split('(')[0].Length; i++)
            {
                if (user.ToString().Split(';')[1].Split(',')[1].Split('(')[0].Substring(i, 1) == " ")
                {
                    count++;
                }
            }


            for (int i = 1; i <= count; i++)
            {
                uname += user.ToString().Split(';')[1].Split(',')[1].Split('(')[0].Split(' ')[i].Substring(0, 1);
            }

            string username = uname + user.ToString().Split(';')[1].Split(',')[1].Split('(')[1].Substring(0, 1) + user.ToString().Split(';')[1].Split(',')[0].Replace(" ", string.Empty) +"@mymail.mapua.edu.ph";
            SqlCommand cmdCUser = new SqlCommand("INSERT INTO [USER] VALUES ('STUDENT', '" + username + "', '" + user.Split(';')[0] + "')");
            Class2.exe(cmdCUser);

            SqlCommand cmdAUser = new SqlCommand("UPDATE STUDENT SET USERID = (SELECT TOP 1 USERID FROM [USER] ORDER BY USERID DESC) WHERE StudentNumber = '" + user.Split(';')[0] + "'");
            Class2.exe(cmdAUser);
            
            //ADD StudentStatus PLANAHEAD
        }
        catch (Exception ex)
        {
        }
    }
    
    
    protected void btnUpload_Click(object sender, EventArgs e)
    {   
        try
       {
            string path = string.Concat(Server.MapPath("~/" + FileUpload1.PostedFile.FileName));
            if(File.Exists(path))
            {
               File.Delete(path);
            }
            else
            {
              FileUpload1.SaveAs(path);
            }
            string excelConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";Extended Properties=Excel 12.0;Persist Security Info=False";
            OleDbConnection excelConnection =new OleDbConnection(excelConnectionString);

            OleDbCommand cmd = new OleDbCommand("Select * from [Sheet1$]",excelConnection);
            excelConnection.Open();
           
            OleDbDataReader dReader = cmd.ExecuteReader();
            SqlBulkCopy sqlBulk = new SqlBulkCopy(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            
            
            if(ddlTable.SelectedValue == "GRADES")
            {
              sqlBulk.DestinationTableName = "[StudentGrades]";
              sqlBulk.WriteToServer(dReader);
            }
            else if(ddlTable.SelectedValue == "STATUS")
            {
                OleDbCommand cmdSS = new OleDbCommand("SELECT StudentNumber, Program, YearLvl, SYTerm, AcademicStatus, (SELECT SWITCH(AcademicStatus = 'ACADEMIC GOOD STANDING','PEER',AcademicStatus = 'ACADEMIC WARNING STATUS','EWP',AcademicStatus = 'ACADEMIC PROBATIONARY STATUS','CARE',AcademicStatus = 'ACADEMIC FINAL PROBATIONARY STATUS','CARE') from [Sheet1$]) AS CurrentStatus, NOW(), LastEnrolled, AcademicAdviser from [Sheet1$]", excelConnection);
                OleDbDataReader drSS = cmdSS.ExecuteReader();
                sqlBulk.DestinationTableName = "[StudentStatus]";
                sqlBulk.WriteToServer(drSS);
            }
            else
            {
              sqlBulk.DestinationTableName = "[Student]";
              sqlBulk.WriteToServer(dReader);
              OleDbCommand cmdCnt = new OleDbCommand("select count(*) from [Sheet1$]", excelConnection);
              cmdCnt.Connection.Open();
              Session["rowCount"] = cmdCnt.ExecuteScalar().ToString();
            }
            excelConnection.Close();
             ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Importing data from excel successful!');window.location ='ManageStudents.aspx';", true);
           
       }
       catch(Exception ex)
       {
           Label1.Text = ex.Message;
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Failed to import data!');window.location ='ManageStudents.aspx';", true);
       } 
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        Label5.Text = Session["fpath"].ToString();  
    }
    
    protected void btnSend_Click(object sender, EventArgs e)
    {
        string messge = TextArea1.Text;
        string nums = textTo.Text.ToString();
        int nCount = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i].Equals(';'))
            {
                nCount++;
            }
        }
        
        if(Class2.getSingleData("SELECT [ConsultationType] FROM dbo.PeerAdviserConsultations WHERE PConsultationId = " + Request.QueryString["aId"]) != "Walk-In")
        {
            for(int j = 0; j <= nCount; j++)
            {
                string studCNumber = Class2.getSingleData("SELECT dbo.Student.Contact FROM Student WHERE StudentNumber = " + textTo.Text.Split(';')[j]);
                msg("0" + studCNumber.ToString(), messge, "ST-CLARE459781_VHVVV");
           }
        }
        
        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Message has been sent!'); window.location ='ManageAppointments.aspx';", true);
    
    }
    
    public object msg(string Number, string Message, string API_CODE)
    {
        object functionReturnValue = null;
        using (System.Net.WebClient client = new System.Net.WebClient())
        {
            System.Collections.Specialized.NameValueCollection parameter = new System.Collections.Specialized.NameValueCollection();
            string url = "https://www.itexmo.com/php_api/api.php";
            parameter.Add("1", Number);
            parameter.Add("2", Message);
            parameter.Add("3", API_CODE);
            dynamic rpb = client.UploadValues(url, "POST", parameter);
            functionReturnValue = (new System.Text.UTF8Encoding()).GetString(rpb);
        }
        return functionReturnValue;
    }
    
    protected void AddStudent(object sender, EventArgs e)
    {
        textTo.Text =  textStudNo.Text + ";" + textTo.Text;
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Panel1.Visible = true;
        Panel2.Visible = false; 
    }
}





















