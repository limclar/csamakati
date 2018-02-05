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
using OfficeOpenXml;

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
    
    protected void btnUpload_Click(object sender, EventArgs e)
    {   
        //FileUpload1.SaveAs(Server.MapPath("~/" + FileName));
        using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
        {
            con.Open();

            var excelFile = new FileInfo(@"~/" + FileUpload1.FileName);
            using (var epPackage =new ExcelPackage(FileUpload1.PostedFile.InputStream))
            {
                var worksheet = epPackage.Workbook.Worksheets.First();

                for (var row = 1; row <= worksheet.Dimension.End.Row; row++)
                {
                    var rowValues = worksheet.Cells[row, 1, row, worksheet.Dimension.End.Column];
                    var cmd = new SqlCommand("INSERT INTO Student(StudentNumber, StudentName, Gender, Contact, Email, UserId) VALUES (@StudentNumber, @StudentName, @Gender, @Contact, @Email, @UserId)", con);
                    cmd.Parameters.AddWithValue("@StudentNumber", rowValues["A2"].Value);
                    cmd.Parameters.AddWithValue("@StudentName", rowValues["B2"].Value);
                    cmd.Parameters.AddWithValue("@Gender", rowValues["C2"].Value);
                    cmd.Parameters.AddWithValue("@Contact", rowValues["D2"].Value);
                    cmd.Parameters.AddWithValue("@Email", rowValues["E2"].Value);
                    cmd.Parameters.AddWithValue("@UserId", rowValues["F2"].Value);
                    cmd.ExecuteNonQuery();
                }

            }

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
























