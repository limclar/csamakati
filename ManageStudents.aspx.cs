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
    ExcelPackage excelPackage = new ExcelPackage();
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
    
    private void ExcelConn(string FilePath)  
    {  
  
        constr = string.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=""Excel 12.0 Xml;HDR=YES;""", FilePath);  
        Econ = new OleDbConnection(constr);  
       
    }  
    private void connection()  
    {  
        sqlconn = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;  
        con = new SqlConnection(sqlconn);  
      
    }  
    
  
    private void InsertExcelRecords(string FilePath)  
    {  
        ExcelConn(FilePath);  
  
        Query = string.Format("Select [StudentNumber],[StudentName],[Gender],[Contact],[Email],[UserId] FROM [{0}]", "Sheet1$");  
        OleDbCommand Ecom = new OleDbCommand(Query, Econ);  
        Econ.Open();  
  
        DataSet ds=new DataSet();  
        OleDbDataAdapter oda = new OleDbDataAdapter(Query, Econ);  
        Econ.Close();  
        oda.Fill(ds);  
        DataTable Exceldt = ds.Tables[0];  
       connection();  
       //creating object of SqlBulkCopy    
       SqlBulkCopy objbulk = new SqlBulkCopy(con);  
       //assigning Destination table name    
       objbulk.DestinationTableName = "Student";  
       //Mapping Table column    
       objbulk.ColumnMappings.Add("StudentNumber", "StudentNumber");  
       objbulk.ColumnMappings.Add("StudentName", "StudentName");  
       objbulk.ColumnMappings.Add("Gender", "Gender");  
       objbulk.ColumnMappings.Add("Contact", "Contact");  
       objbulk.ColumnMappings.Add("Email", "Email");  
       objbulk.ColumnMappings.Add("UserId", "UserId");  
       //inserting Datatable Records to DataBase    
       con.Open();  
       objbulk.WriteToServer(Exceldt);  
       con.Close();  
 
    }   
    
    protected void btnUpload_Click(object sender, EventArgs e)
    {   
        string CurrentFilePath = Path.GetFullPath(FileUpload1.PostedFile.FileName);  
        InsertExcelRecords(CurrentFilePath);   
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
























