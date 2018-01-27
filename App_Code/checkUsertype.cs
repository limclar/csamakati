using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public class checkUsertype
{

    public checkUsertype()
    {

    }

    public static void filter(string utype, string currentType)
    {
        if (utype == "STAFF")
        {
            if (currentType == "FACULTY")
            {
                HttpContext.Current.Response.Redirect("FacultyDashboard.aspx");
            }
            else if (currentType == "STUDENT")
            {
                HttpContext.Current.Response.Redirect("StudentAnnouncements.aspx");
            }
            else if (currentType == "" || currentType == null)
            {
                HttpContext.Current.Response.Redirect("In.aspx");
            }
        }
        else if (utype == "FACULTY")
        {
            if (currentType == "STAFF")
            {
                HttpContext.Current.Response.Redirect("StaffDashboard.aspx");
            }
            else if (currentType == "STUDENT")
            {
                HttpContext.Current.Response.Redirect("StudentAnnouncements.aspx");
            }
            else if (currentType == "" || currentType == null)
            {
                HttpContext.Current.Response.Redirect("In.aspx");
            }
        }
        else if (utype == "STUDENT")
        {
            if (currentType == "STAFF")
            {
                HttpContext.Current.Response.Redirect("StaffDashboard.aspx");
            }
            else if (currentType == "FACULTY")
            {
                HttpContext.Current.Response.Redirect("FacultyDashboard.aspx");
            }
            else if (currentType == "" || currentType == null)
            {
                HttpContext.Current.Response.Redirect("In.aspx");
            }
        }
    }


    public static string convertToTime(string lbtnId)
    {
        switch (lbtnId)
        {
            //7:30 TO 9:00
            case "A1":
                return "Monday; 07:30-09:00;";

            case "A2":
                return "Tuesday; 07:30-09:00;";

            case "A3":
                return "Wednesday; 07:30-09:00;";

            case "A4":
                return "Thursday; 07:30-09:00;";

            case "A5":
                return "Friday; 07:30-09:00;";

            case "A6":
                return "Saturday; 07:30-09:00;";

            //9:00 TO 10
            case "B1":
                return "Monday; 09:00-10:30;";

            case "B2":
                return "Tuesday; 09:00-10:30;";

            case "B3":
                return "Wednesday; 09:00-10:30;";

            case "B4":
                return "Thursday; 09:00-10:30;";

            case "B5":
                return "Friday; 09:00-10:30;";

            case "B6":
                return "Saturday; 09:00-10:30;";

            //10 TO 12
            case "C1":
                return "Monday; 10:30-12:00;";

            case "C2":
                return "Tuesday; 10:30-12:00;";

            case "C3":
                return "Wednesday; 10:30-12:00;";

            case "C4":
                return "Thursday; 10:30-12:00;";

            case "C5":
                return "Friday; 10:30-12:00;";

            case "C6":
                return "Saturday; 10:30-12:00;";

            //12 TO 1
            case "D1":
                return "Monday; 12:00-13:30;";

            case "D2":
                return "Tuesday; 12:00-13:30;";

            case "D3":
                return "Wednesday; 12:00-13:30;";

            case "D4":
                return "Thursday; 12:00-13:30;";

            case "D5":
                return "Friday; 12:00-13:30;";

            case "D6":
                return "Saturday; 12:00-13:30;";

            //1 TO 3
            case "E1":
                return "Monday; 13:30-15:00;";

            case "E2":
                return "Tuesday; 13:30-15:00;";

            case "E3":
                return "Wednesday; 13:30-15:00;";

            case "E4":
                return "Thursday; 13:30-15:00;";

            case "E5":
                return "Friday; 13:30-15:00;";

            case "E6":
                return "Saturday; 13:30-15:00;";

            //3 TO 4
            case "F1":
                return "Monday; 15:00-16:30;";

            case "F2":
                return "Tuesday; 15:00-16:30;";

            case "F3":
                return "Wednesday; 15:00-16:30;";

            case "F4":
                return "Thursday; 15:00-16:30;";

            case "F5":
                return "Friday; 15:00-16:30";

            case "F6":
                return "Saturday; 15:00-16:30";

            //4 TO 6
            case "G1":
                return "Monday; 16:30-18:00;";

            case "G2":
                return "Tuesday; 16:30-18:00;";

            case "G3":
                return "Wednesday; 16:30-18:00;";

            case "G4":
                return "Thursday; 16:30-18:00;";

            case "G5":
                return "Friday; 16:30-18:00;";

            case "G6":
                return "Saturday; 16:30-18:00;";

            //6 TO 7
            case "H1":
                return "Monday; 18:00-19:30;";

            case "H2":
                return "Tuesday; 18:00-19:30;";

            case "H3":
                return "Wednesday; 18:00-19:30;";

            case "H4":
                return "Thursday; 18:00-19:30;";

            case "H5":
                return "Friday; 18:00-19:30;";

            case "H6":
                return "Saturday; 18:00-19:30;";

            //7 TO 9
            case "I1":
                return "Monday; 19:30-21:00;";

            case "I2":
                return "Tuesday; 19:30-21:00;";

            case "I3":
                return "Wednesday; 19:30-21:00;";

            case "I4":
                return "Thursday; 19:30-21:00;";

            case "I5":
                return "Friday; 19:30-21:00;";

            case "I6":
                return "Saturday; 19:30-21:00;";
        }
        return "blank";
    }

    public static string convertToDateTime(string lbtnId)
    {
        switch (lbtnId)
        {
            //7:30 TO 9:00
            case "A1":
                return "2; 07:30;";

            case "A2":
                return "3; 07:30;";

            case "A3":
                return "4; 07:30;";

            case "A4":
                return "5; 07:30;";

            case "A5":
                return "6; 07:30;";

            case "A6":
                return "7; 07:30;";

            //9:00 TO 10
            case "B1":
                return "2; 09:00;";

            case "B2":
                return "3; 09:00;";

            case "B3":
                return "4; 09:00;";

            case "B4":
                return "5; 09:00;";

            case "B5":
                return "6; 09:00;";

            case "B6":
                return "7; 09:00;";

            //10 TO 12
            case "C1":
                return "2; 10:30;";

            case "C2":
                return "3; 10:30;";

            case "C3":
                return "4; 10:30;";

            case "C4":
                return "5; 10:30;";

            case "C5":
                return "6; 10:30;";

            case "C6":
                return "7; 10:30;";

            //12 TO 1
            case "D1":
                return "2; 12:00;";

            case "D2":
                return "3; 12:00;";

            case "D3":
                return "4; 12:00;";

            case "D4":
                return "5; 12:00;";

            case "D5":
                return "6; 12:00;";

            case "D6":
                return "7; 12:00;";

            //1 TO 3
            case "E1":
                return "2; 13:30;";

            case "E2":
                return "3; 13:30;";

            case "E3":
                return "4; 13:30;";

            case "E4":
                return "5; 13:30;";

            case "E5":
                return "6; 13:30;";

            case "E6":
                return "7; 13:30;";

            //3 TO 4
            case "F1":
                return "2; 15:00;";

            case "F2":
                return "3; 15:00;";

            case "F3":
                return "4; 15:00;";

            case "F4":
                return "5; 15:00;";

            case "F5":
                return "6; 15:00;";

            case "F6":
                return "7; 15:00;";

            //4 TO 6
            case "G1":
                return "2; 16:30;";

            case "G2":
                return "3; 16:30;";

            case "G3":
                return "4; 16:30;";

            case "G4":
                return "5; 16:30;";

            case "G5":
                return "6; 16:30;";

            case "G6":
                return "7; 16:30;";

            //6 TO 7
            case "H1":
                return "2; 18:00;";

            case "H2":
                return "3; 18:00;";

            case "H3":
                return "4; 18:00;";

            case "H4":
                return "5; 18:00;";

            case "H5":
                return "6; 18:00;";

            case "H6":
                return "7; 18:00;";

            //7 TO 9
            case "I1":
                return "2; 19:30;";

            case "I2":
                return "3; 19:30;";

            case "I3":
                return "4; 19:30;";

            case "I4":
                return "5; 19:30;";

            case "I5":
                return "6; 19:30;";

            case "I6":
                return "7; 19:30;";
        }
        return "none";
    }

    public static string RandomString(int length)
    {
        Random random = new Random();
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
    }

    public void popup(System.Web.UI.Page x)
    {
        ScriptManager.RegisterStartupScript(x, typeof(string), "uniqueKey", "div_show()", true);
    }
}
        