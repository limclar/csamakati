using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Class2
/// </summary>
public class Class2
{
    public static SqlConnection getCon()
    {
        SqlConnection sqlConnection;
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
        try
        {
            con.Open();
            sqlConnection = con;
        }
        catch
        {
            sqlConnection = null;
        }
        return sqlConnection;
    }

    public static DataSet getDataSet(string sql)
    {
        DataSet dataSet;
        using (SqlConnection con = getCon())
        {
            SqlDataAdapter ad = new SqlDataAdapter(new SqlCommand(sql, con));
            DataSet ds = new DataSet();
            ad.Fill(ds);
            dataSet = ds;
        }
        return dataSet;
    }
    public static DataSet getDataSet(SqlCommand cmd)
    {
        DataSet dataSet;
        using (SqlConnection con = getCon())
        {
            cmd.Connection = con;
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            ad.Fill(ds);
            dataSet = ds;
        }
        return dataSet;
    }
    public static string getSingleData(string sql)
    {
        string str;

        using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
        {
            try
            {
                con.Open();
                str = (new SqlCommand(sql, con)).ExecuteScalar().ToString();
            }
            catch
            {
                str = "";
            }
        }
        return str;
    }
    public static string getSingleData(SqlCommand cmd)
    {
        string str;

        using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
        {
            try
            {
                con.Open();
                cmd.Connection = con;
                str = cmd.ExecuteScalar().ToString();
            }
            catch
            {
                str = "";
            }
        }
        return str;
    }
    public static bool performAction(string sql)
    {
        bool flag;
        using (SqlConnection con = getCon())
        {
            flag = ((new SqlCommand(sql, con)).ExecuteNonQuery() <= 1 ? false : true);
        }
        return flag;
    }
    public static string exe(SqlCommand cmd)
    {
        try
        {
            using (SqlConnection con = getCon())
            {
                cmd.Connection = con;
                int r = cmd.ExecuteNonQuery();
                if (r > 1)
                {
                    return "Success";
                }
                else
                {
                    return "False";
                }
            }
        }
        catch
        { return null; }

    }


    public static DataView TEseet(string sql)
    {
        using (SqlConnection con = getCon())
        {
            try
            {
                SqlDataAdapter ad = new SqlDataAdapter(new SqlCommand(sql, con));
                DataSet ds = new DataSet();
                ad.Fill(ds);
                //dataSet = ds;

                return null;
            }
            catch { return null; }
        }
    }
}