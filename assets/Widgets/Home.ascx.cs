using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Widgets_Home : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        SqlCommand cmd = new SqlCommand("Select ProjectId,Proj_Name,status,class  from t_ProjectDescription order by Proj_Name desc");
        
        ListView1.DataSource = Class2.getDataSet(cmd);
        ListView1.DataBind();

    }


    protected void btnAddProject_Click(object sender, EventArgs e)
    {
        try
        {

            SqlCommand cmd = new SqlCommand("[udp_t_ProjectDescription_ups]");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ProjectID", SqlDbType.NVarChar).Value = "0";
            cmd.Parameters.Add("@Proj_Name", SqlDbType.NVarChar).Value = projTitle.Text;
            cmd.Parameters.Add("@Status", SqlDbType.NVarChar).Value = "WIP";
            cmd.Parameters.Add("@CreatedOn", SqlDbType.NVarChar).Value = DateTime.Now;
            cmd.Parameters.Add("@UpdatedOn", SqlDbType.NVarChar).Value = DBNull.Value;
            cmd.Parameters.Add("@Class", SqlDbType.NVarChar).Value = projClass.Text;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.NVarChar).Value = Session["UserId"].ToString();
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = DBNull.Value;
            cmd.Parameters.Add("@Client", SqlDbType.NVarChar).Value = projClient.Text;
            Class2.exe(cmd);
        }
        catch
        {
            Literal1.Text = " <script> alert('FAILED TO ADD A PROJECT'); </script>";
        }
        Response.Redirect("Default.aspx?Page=Home");
    }

    protected void ListView1_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        if (e.Item.ItemType == ListViewItemType.DataItem)
        {
            Label x = (Label)e.Item.FindControl("StatusLabel");
            if (x != null)
            {
                if (x.Text.Trim() == "WIP")
                {
                    HtmlTableCell qw = (HtmlTableCell)e.Item.FindControl("StatusTb");                    
                    qw.BgColor = "#E9AB17";
                    HtmlTableCell q = (HtmlTableCell)e.Item.FindControl("StatusTb1");
                    q.BgColor = "#E9AB17";
                    HtmlTableCell y = (HtmlTableCell)e.Item.FindControl("StatusTb2");
                    y.BgColor = "#E9AB17";
                }
                else if (x.Text.Trim() == "Done")
                {
                    HtmlTableCell qw = (HtmlTableCell)e.Item.FindControl("StatusTb");
                    qw.BgColor = "#667C26";
                    HtmlTableCell z = (HtmlTableCell)e.Item.FindControl("StatusTb1");
                    z.BgColor = "#667C26";
                    HtmlTableCell y = (HtmlTableCell)e.Item.FindControl("StatusTb2");
                    y.BgColor = "#667C26";
                }
                else if (x.Text.Trim() == "Removed")
                {
                    HtmlTableCell qw = (HtmlTableCell)e.Item.FindControl("StatusTb");
                    qw.BgColor = "#9F000F";
                    HtmlTableCell z = (HtmlTableCell)e.Item.FindControl("StatusTb1");
                    z.BgColor = "#9F000F";
                    HtmlTableCell y = (HtmlTableCell)e.Item.FindControl("StatusTb2");
                    y.BgColor = "#9F000F";
                }
            }
        }
    }

}