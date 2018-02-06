using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            checkUsertype.filter("FACULTY", Session["UserType"].ToString());
        }
        catch(Exception ex)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('You have been inactive for too long. Please relogin.');window.location ='Out.aspx';", true);
        }
        if(!IsPostBack)
             btnRecord.Enabled = false;
    }

    protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if(rbtnActTaken.SelectedIndex == 2)
            ddlDepartment.Enabled = true;
        else
        {
            ddlDepartment.Enabled = false;
            tboxDeptOthers.Enabled = false;
            ddlDepartment.SelectedIndex = 0;
        }  
    }

    protected void ddlDepartment_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlDepartment.SelectedIndex == 3)
            tboxDeptOthers.Enabled = true;
        else
            tboxDeptOthers.Enabled = false;
    }

    protected void btnSearchCon_Click(object sender, EventArgs e)
    {
        try
        {
            DataSet ds = Class2.getDataSet("SELECT dbo.Student.StudentNumber, dbo.Student.StudentName, dbo.AcademicAdviserConsultations.AConsultationId, dbo.AcademicAdviserConsultations.ConsultationCode, dbo.AcademicAdviserConsultations.NatureOfAdvising, dbo.AcademicAdviserConsultations.ActionTaken FROM dbo.AcademicAdviserConsultations INNER JOIN dbo.Student ON dbo.AcademicAdviserConsultations.StudentNumber = dbo.Student.StudentNumber WHERE dbo.AcademicAdviserConsultations.[Status] = 'PENDING' and [ConsultationCode] = '" + tboxConCode.Text + "' and dbo.AcademicAdviserConsultations.AAdviserId = " + Session["AAdviserId"] + " and dbo.AcademicAdviserConsultations.StudentNumber = " + Int32.Parse(tboxStudentNumber.Text) + "");
            tboxStudentName.Text = ds.Tables[0].Rows[0]["StudentName"].ToString();
            ddlNature.Text = ds.Tables[0].Rows[0]["NatureOfAdvising"].ToString();
            Session["ApptId"] = ds.Tables[0].Rows[0]["AConsultationId"].ToString();
            btnRecord.Enabled = true;
        }
        catch (Exception ex)
        {
             btnRecord.Enabled = false;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Incorrect Details. Please try again.');window.location ='FacultyVerifyAppointment.aspx';", true);
        }
    }

    protected void btnRecord_Click(object sender, EventArgs e)
    {   
        try
        {
            SqlCommand cmdUptAppt = new SqlCommand("[sp_t_AConsultation_ups]");
            cmdUptAppt.CommandType = CommandType.StoredProcedure;
            cmdUptAppt.Parameters.Add("@AConsultationId", SqlDbType.NVarChar).Value = Int32.Parse(Session["ApptId"].ToString());
            cmdUptAppt.Parameters.Add("@ConsultationCode", SqlDbType.NVarChar).Value = DBNull.Value;
            cmdUptAppt.Parameters.Add("@SYTerm", SqlDbType.NVarChar).Value = DBNull.Value;
            cmdUptAppt.Parameters.Add("@StudentNumber", SqlDbType.NVarChar).Value = DBNull.Value;
            cmdUptAppt.Parameters.Add("@Status", SqlDbType.NVarChar).Value = DBNull.Value;
            cmdUptAppt.Parameters.Add("@DeptId", SqlDbType.NVarChar).Value = DBNull.Value;
            cmdUptAppt.Parameters.Add("@AAdviserId", SqlDbType.NVarChar).Value = DBNull.Value;
            cmdUptAppt.Parameters.Add("@ConsultationDateTime", SqlDbType.NVarChar).Value = DBNull.Value;
            cmdUptAppt.Parameters.Add("@NatureOfAdvising", SqlDbType.NVarChar).Value = ddlNature.SelectedItem.Text;


            if (rbtnActTaken.SelectedIndex == 2)
            {
                if (ddlDepartment.SelectedIndex == 3)
                    cmdUptAppt.Parameters.Add("@ActionTaken", SqlDbType.NVarChar).Value = rbtnActTaken.SelectedValue + " " + tboxDeptOthers.Text;
                else
                    cmdUptAppt.Parameters.Add("@ActionTaken", SqlDbType.NVarChar).Value = rbtnActTaken.SelectedValue + " " + ddlDepartment.SelectedValue;

            }
            else
                cmdUptAppt.Parameters.Add("@ActionTaken", SqlDbType.NVarChar).Value = rbtnActTaken.SelectedValue;

            
            Class2.exe(cmdUptAppt);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Appointment has been verified!');window.location ='FacultyVerifyAppointment.aspx';", true);
        }
        catch(Exception ex)
        {
        }
    }
}

