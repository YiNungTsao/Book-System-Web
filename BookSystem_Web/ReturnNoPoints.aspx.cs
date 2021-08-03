using Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.LeftBar.Items[8].Selected = true;

        if (this.LeftBar.Items[0].Selected) Response.Redirect("Lend.aspx");
        else if (this.LeftBar.Items[1].Selected) Response.Redirect("Return.aspx");
        else if (this.LeftBar.Items[2].Selected) Response.Redirect("NotReturn.aspx");
        else if (this.LeftBar.Items[3].Selected) Response.Redirect("PersonalRecord.aspx");
        else if (this.LeftBar.Items[4].Selected) Response.Redirect("ClassRecord.aspx");
        else if (this.LeftBar.Items[5].Selected) Response.Redirect("AddStudents.aspx");
        else if (this.LeftBar.Items[6].Selected) Response.Redirect("AddBooks.aspx");
        else if (this.LeftBar.Items[7].Selected) Response.Redirect("DelStudent.aspx");
        else if (this.LeftBar.Items[9].Selected) Response.Redirect("UpdateBook.aspx");
        else if (this.LeftBar.Items[10].Selected) Response.Redirect("UpdateStudent.aspx");
    }

    
    protected void ReturnNoPoints_ReadData_Click(object sender, EventArgs e)
    {
        try
        {
            ReturnNoPoints_Status.Text = "";
            ReturnNoPoints_Status.ForeColor = System.Drawing.Color.Black;
            string startTime = "";

            List<Student> AllStudents = MySQL.SelectStudents("SELECT * FROM STUDENTS");
            List<Book> AllBooks = MySQL.SelectBooks("SELECT * FROM BOOKS");
            //還書
            Dictionary<string, List<string>> Personal_currRecord = MySQL.SelectCurrent("SELECT * FROM CURRENT_RECORD");

            //歷史紀錄
            Dictionary<string, Tuple<List<string>, List<string>, List<string>, List<string>>> Class_historyRecord = MySQL.SelectHistory("SELECT * FROM history_RECORD", Information.Class);
            Dictionary<string, Tuple<List<string>, List<string>, List<string>, List<string>>> Personal_historyRecord = MySQL.SelectHistory("SELECT * FROM History_RECORD", Information.Personal);

            //補齊文字方框的資料
            string period = "";
            string points = "0";
            foreach (Book book in AllBooks)
            {
                if (book.ID == ReturnNoPoints_BookIDtxt.Text)
                {
                    //書的資料
                    period = book.Period;
                    points = book.Points;
                    ReturnNoPoints_BookNametxt.Text = book.Name;
                    ReturnNoPoints_EndDatetxt.Text = DateTime.Now.ToShortDateString();
                    startTime = MySQL.Select(string.Format("SELECT * FROM CURRENT_RECORD WHERE BookID = '{0}'", ReturnNoPoints_BookIDtxt.Text), Information.StartTime);

                    //學生資料
                    ReturnNoPoints_Nametxt.Text = MySQL.Select(string.Format("SELECT * FROM CURRENT_RECORD WHERE BookID = '{0}'", ReturnNoPoints_BookIDtxt.Text), Information.StdName);
                    ReturnNoPoints_StdIDtxt.Text = MySQL.Select(string.Format("SELECT * FROM CURRENT_RECORD WHERE BookID = '{0}'", ReturnNoPoints_BookIDtxt.Text), Information.StdID);
                    ReturnNoPoints_Classtxt.Text = MySQL.Select(string.Format("SELECT * FROM CURRENT_RECORD WHERE BookID = '{0}'", ReturnNoPoints_BookIDtxt.Text), Information.Class);

                    break;
                }
            }

            if ((period != "") && (points != "0"))
            {
                if ((ReturnNoPoints_Nametxt.Text.Length != 0) && (ReturnNoPoints_Classtxt.Text.Length != 0) && (ReturnNoPoints_StdIDtxt.Text.Length != 0)) ReturnNoPoints_Status.Text = "不計點歸還查詢成功";
                else
                {
                    ReturnNoPoints_Status.ForeColor = System.Drawing.Color.Red;
                    ReturnNoPoints_Status.Text = "此本書沒有被外借";
                } 
            }
            else
            {
                ReturnNoPoints_BookNametxt.Text = "";
                ReturnNoPoints_Classtxt.Text = "";
                ReturnNoPoints_Nametxt.Text = "";
                ReturnNoPoints_StdIDtxt.Text = "";
                ReturnNoPoints_EndDatetxt.Text = "";
                ReturnNoPoints_Status.ForeColor = System.Drawing.Color.Red;
                ReturnNoPoints_Status.Text = "沒有此本書的資訊";
            }
            
        }
        catch (Exception error)
        {
            //Response.Write(error);
            ReturnNoPoints_Status.ForeColor = System.Drawing.Color.Red;
            ReturnNoPoints_Status.Text = "資料格式錯誤，不計點查詢失敗";
            //Response.Write("查詢失敗");
        }
    }

    protected void ReturnNoPoints_UpdateData_Click(object sender, EventArgs e)
    {
        try
        {
            ReturnNoPoints_Status.Text = "";
            string startTime = "";

            List<Student> AllStudents = MySQL.SelectStudents("SELECT * FROM STUDENTS");
            List<Book> AllBooks = MySQL.SelectBooks("SELECT * FROM BOOKS");
            //還書
            Dictionary<string, List<string>> Personal_currRecord = MySQL.SelectCurrent("SELECT * FROM CURRENT_RECORD");

            //歷史紀錄
            Dictionary<string, Tuple<List<string>, List<string>, List<string>, List<string>>> Class_historyRecord = MySQL.SelectHistory("SELECT * FROM history_RECORD", Information.Class);
            Dictionary<string, Tuple<List<string>, List<string>, List<string>, List<string>>> Personal_historyRecord = MySQL.SelectHistory("SELECT * FROM History_RECORD", Information.Personal);

            //補齊文字方框的資料
            string period = "";
            string points = "0";
            foreach (Book book in AllBooks)
            {
                if (book.ID == ReturnNoPoints_BookIDtxt.Text)
                {
                    //書的資料
                    period = book.Period;
                    points = book.Points;
                    ReturnNoPoints_BookNametxt.Text = book.Name;
                    ReturnNoPoints_EndDatetxt.Text = DateTime.Now.ToShortDateString();
                    startTime = MySQL.Select(string.Format("SELECT * FROM CURRENT_RECORD WHERE BookID = '{0}'", ReturnNoPoints_BookIDtxt.Text), Information.StartTime);

                    //學生資料
                    ReturnNoPoints_Nametxt.Text = MySQL.Select(string.Format("SELECT * FROM CURRENT_RECORD WHERE BookID = '{0}'", ReturnNoPoints_BookIDtxt.Text), Information.StdName);
                    ReturnNoPoints_StdIDtxt.Text = MySQL.Select(string.Format("SELECT * FROM CURRENT_RECORD WHERE BookID = '{0}'", ReturnNoPoints_BookIDtxt.Text), Information.StdID);
                    ReturnNoPoints_Classtxt.Text = MySQL.Select(string.Format("SELECT * FROM CURRENT_RECORD WHERE BookID = '{0}'", ReturnNoPoints_BookIDtxt.Text), Information.Class);

                    break;
                }
            }

            if ((period != "") && (points != "0"))
            {
                if ((ReturnNoPoints_Nametxt.Text.Length != 0) || (ReturnNoPoints_StdIDtxt.Text.Length != 0) || (ReturnNoPoints_Classtxt.Text.Length != 0))
                {
                    MySQL.Delete(string.Format("DELETE FROM CURRENT_RECORD WHERE BookID = '{0}' AND StdID = '{1}'", ReturnNoPoints_BookIDtxt.Text, ReturnNoPoints_StdIDtxt.Text));
                    //MySQL.Update(string.Format("UPDATE BOOKS SET AVAILABLE = '{0}' WHERE"))

                    MySQL.Update(string.Format("UPDATE BOOKS SET AVAILABLE = '{0}' WHERE ID = '{1}'", "true", ReturnNoPoints_BookIDtxt.Text));

                    ReturnNoPoints_Status.Text = "不計點歸還書籍成功";
                }
                else
                {
                    ReturnNoPoints_Status.ForeColor = System.Drawing.Color.Red;
                    ReturnNoPoints_Status.Text = "此本書沒有被外借";
                }
            }
            else
            {
                ReturnNoPoints_BookNametxt.Text = "";
                ReturnNoPoints_Classtxt.Text = "";
                ReturnNoPoints_Nametxt.Text = "";
                ReturnNoPoints_StdIDtxt.Text = "";
                ReturnNoPoints_EndDatetxt.Text = "";
                ReturnNoPoints_Status.ForeColor = System.Drawing.Color.Red;
                ReturnNoPoints_Status.Text = "沒有此本書的資訊";
            }
        }
        catch (Exception error)
        {
            //Response.Write(error);
            ReturnNoPoints_Status.ForeColor = System.Drawing.Color.Red;
            ReturnNoPoints_Status.Text = "資料格式錯誤，不計點歸還失敗";
            //Response.Write("歸還失敗");
        }
    }
}