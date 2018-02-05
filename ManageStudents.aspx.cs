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
using Microsoft.Office.Interop.Excel;
using Excel = Microsoft.Office.Interop.Excel;


public partial class _Default : System.Web.UI.Page
{
    OleDbConnection Econ;  
    SqlConnection con;  
  
    string constr,Query,sqlconn; 
    protected void Page_Load(object sender, EventArgs e)
    {
        
            if(!IsPostBack)
            {
                
            }
          string user = Class2.getSingleData("SELECT TOP 1 (CONVERT(VARCHAR(10), StudentNumber) + ';' + StudentName) FROM STUDENT WHERE USERID = 0");
            int count = 0;
            for (int i = 0; i < user.Length; i++)
            {
                if (user[i].Equals(' '))
                {
                    count++;
                }
            }
            
            string uname = "";
            for(int i = 1; i < count-1; i++)
            {
                uname += user.Split(' ')[i].Substring(0,1);
            }

            try
            {
                string username = uname + Regex.Match(user, @"\(([^)]*)\)").Groups[1].Value.Substring(0,1) + user.Split(';')[1].Split(',')[0];
                SqlCommand cmdCUser = new SqlCommand("INSERT INTO [USER] VALUES ('STUDENT', '" + username  + "', '" + user.Split(';')[0]+ "')");
                Class2.exe(cmdCUser);

                SqlCommand cmdAUser = new SqlCommand("UPDATE STUDENT SET USERID = (SELECT TOP 1 USERID FROM [USER] ORDER BY USERID DESC) WHERE StudentNumber = '" + user.Split(';')[0] + "'");
                Class2.exe(cmdAUser);
            }
            catch(Exception ex)
            {
            }
    }
    
     private void connection()  
    {  
        sqlconn = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;  
        con = new SqlConnection(sqlconn);  
      
    }   

    protected void btnUpload_Click(object sender, EventArgs e)
    {
            constr = string.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=""Excel 12.0 Xml;HDR=YES;""", Path.GetFullPath(FileUpload1.PostedFile.FileName));  
            var objConn = new SqlConnection(constr);
            objConn.Open();

            using (FileStream stream = File.Open(Server.MapPath("~/" + FileUpload1.FileName), FileMode.Open, FileAccess.Read))
            {
                IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
                excelReader.IsFirstRowAsColumnNames = false;
                int i = 0;
                while (excelReader.Read())
                {
                    if (i > 0)
                    {
                        string strSQL = "INSERT INTO STUDENT (Column1,Column2,Column3,Column4,Column5, Column6) "
                            + " VALUES  ("
                            + " '" + excelReader.GetString(0) + "', "
                            + " '" + excelReader.GetString(1) + "', "
                            + " '" + excelReader.GetString(2) + "', "
                            + " '" + excelReader.GetString(3) + "', "
                            + " '" + excelReader.GetString(4) + "', "
                            + " '" + excelReader.GetString(5) + "' "
                            + ")";
                        var objCmd = new SqlCommand(strSQL, objConn);
                        objCmd.ExecuteNonQuery();
                    }
                    i++;
                }
            }

            objConn.Close();
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
























