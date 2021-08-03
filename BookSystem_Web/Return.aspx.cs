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
        Return_BookIDtxt.Enabled = true;

        LeftBar.Items[1].Selected = true;
        if (this.LeftBar.Items[0].Selected) Response.Redirect("Lend.aspx");
        else if (this.LeftBar.Items[2].Selected) Response.Redirect("NotReturn.aspx");
        else if (this.LeftBar.Items[3].Selected) Response.Redirect("PersonalRecord.aspx");
        else if (this.LeftBar.Items[4].Selected) Response.Redirect("ClassRecord.aspx");
        else if (this.LeftBar.Items[5].Selected) Response.Redirect("AddStudents.aspx");
        else if (this.LeftBar.Items[6].Selected) Response.Redirect("AddBooks.aspx");
        else if (this.LeftBar.Items[7].Selected) Response.Redirect("DelStudent.aspx");
        else if (this.LeftBar.Items[8].Selected) Response.Redirect("ReturnNoPoints.aspx");
        else if (this.LeftBar.Items[9].Selected) Response.Redirect("UpdateBook.aspx");
        else if (this.LeftBar.Items[10].Selected) Response.Redirect("UpdateStudent.aspx");
    }

    protected void Return_ReadData_Click(object sender, EventArgs e)
    {
        try
        {
            Return_Status.ForeColor = System.Drawing.Color.Black;
            Return_Status.Text = "";
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
            if (Return_BookIDtxt.Text.Length != 0)
            {
                foreach (Book book in AllBooks)
                {
                    if (book.ID == Return_BookIDtxt.Text)
                    {
                        //書的資料
                        period = book.Period;
                        points = book.Points;
                        Return_BookNametxt.Text = book.Name;
                        Return_EndDatetxt.Text = DateTime.Now.ToShortDateString();
                        startTime = MySQL.Select(string.Format("SELECT * FROM CURRENT_RECORD WHERE BookID = '{0}'", Return_BookIDtxt.Text), Information.StartTime);

                        //學生資料
                        Return_Nametxt.Text = MySQL.Select(string.Format("SELECT * FROM CURRENT_RECORD WHERE BookID = '{0}'", Return_BookIDtxt.Text), Information.StdName);
                        Return_StdIDtxt.Text = MySQL.Select(string.Format("SELECT * FROM CURRENT_RECORD WHERE BookID = '{0}'", Return_BookIDtxt.Text), Information.StdID);
                        Return_Classtxt.Text = MySQL.Select(string.Format("SELECT * FROM CURRENT_RECORD WHERE BookID = '{0}'", Return_BookIDtxt.Text), Information.Class);

                        break;
                    }
                }
                if((period != "") && (points != "0"))
                {
                    if ((Return_Nametxt.Text.Length != 0) && (Return_StdIDtxt.Text.Length != 0) && (Return_Classtxt.Text.Length != 0)) Return_Status.Text = "查詢成功";
                    else
                    {
                        Return_Status.ForeColor = System.Drawing.Color.Red;
                        Return_Status.Text = "此本書沒有被外借";
                    } 
                }
                else
                {
                    Return_BookNametxt.Text = "";
                    Return_EndDatetxt.Text = "";
                    Return_Classtxt.Text = "";
                    Return_Nametxt.Text = "";
                    Return_StdIDtxt.Text = "";
                    Return_Status.ForeColor = System.Drawing.Color.Red;
                    Return_Status.Text = "沒有此本書的資訊";
                }
            }
            else
            {
                Return_Status.ForeColor = System.Drawing.Color.Red;
                Return_Status.Text = "請輸入欲歸還的書籍代碼";
            }
            
            
        }
        catch (Exception error)
        {
            //Response.Write(error);
            Return_Status.ForeColor = System.Drawing.Color.Red;
            Return_Status.Text = "查詢失敗";
            //Response.Write("查詢失敗");
        }
    }

    protected void Return_UpdateData_Click(object sender, EventArgs e)
    {
        try
        {
            Return_Status.Text = "";
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
            if (Return_BookIDtxt.Text.Length != 0)
            {
                foreach (Book book in AllBooks)
                {
                    if (book.ID == Return_BookIDtxt.Text)
                    {
                        //書的資料
                        period = book.Period;
                        points = book.Points;
                        Return_BookNametxt.Text = book.Name;
                        Return_EndDatetxt.Text = DateTime.Now.ToShortDateString();
                        startTime = MySQL.Select(string.Format("SELECT * FROM CURRENT_RECORD WHERE BookID = '{0}'", Return_BookIDtxt.Text), Information.StartTime);

                        //學生資料
                        Return_Nametxt.Text = MySQL.Select(string.Format("SELECT * FROM CURRENT_RECORD WHERE BookID = '{0}'", Return_BookIDtxt.Text), Information.StdName);
                        Return_StdIDtxt.Text = MySQL.Select(string.Format("SELECT * FROM CURRENT_RECORD WHERE BookID = '{0}'", Return_BookIDtxt.Text), Information.StdID);
                        Return_Classtxt.Text = MySQL.Select(string.Format("SELECT * FROM CURRENT_RECORD WHERE BookID = '{0}'", Return_BookIDtxt.Text), Information.Class);

                        break;
                    }
                }
                if ((period != "") && (points != "0"))
                {
                    if ((Return_Nametxt.Text.Length != 0) && (Return_StdIDtxt.Text.Length != 0) && (Return_Classtxt.Text.Length != 0))
                    {
                        //判斷還書時間是否在期限內
                        bool inTime = true;
                        if (DateTime.Compare(Convert.ToDateTime(startTime), Convert.ToDateTime(DateTime.Now.ToShortDateString())) > 14)
                            inTime = false;

                        MySQL.Insert(string.Format("INSERT INTO HISTORY_RECORD VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}')"
                            , Return_Nametxt.Text, Return_StdIDtxt.Text, Return_Classtxt.Text, Return_BookNametxt.Text, Return_BookIDtxt.Text, startTime
                            , period, points, DateTime.Now.ToShortDateString(), inTime));

                        MySQL.Delete(string.Format("DELETE FROM CURRENT_RECORD WHERE BookID = '{0}' AND StdID = '{1}'", Return_BookIDtxt.Text, Return_StdIDtxt.Text));

                        MySQL.Update(string.Format("UPDATE BOOKS SET AVAILABLE = '{0}' WHERE ID = '{1}'", "true", Return_BookIDtxt.Text));
                        //Personal_currRecord = MySQL.SelectCurrent("SELECT * FROM CURRENT_RECORD");
                        //Class_historyRecord = MySQL.SelectHistory("SELECT * FROM history_RECORD", Information.Class);
                        //Personal_historyRecord = MySQL.SelectHistory("SELECT * FROM History_RECORD", Information.Personal);

                        Return_Status.Text = "歸還完成";
                    }
                    else
                    {
                        Return_Status.ForeColor = System.Drawing.Color.Red;
                        Return_Status.Text = "此本書沒有被外借";
                    }
                }
                else
                {
                    Return_BookNametxt.Text = "";
                    Return_EndDatetxt.Text = "";
                    Return_Classtxt.Text = "";
                    Return_Nametxt.Text = "";
                    Return_StdIDtxt.Text = "";
                    Return_Status.ForeColor = System.Drawing.Color.Red;
                    Return_Status.Text = "沒有此本書的資訊";
                }
            }
            else
            {
                Return_BookNametxt.Text = "";
                Return_EndDatetxt.Text = "";
                Return_Classtxt.Text = "";
                Return_Nametxt.Text = "";
                Return_StdIDtxt.Text = "";
                Return_Status.ForeColor = System.Drawing.Color.Red;
                Return_Status.Text = "請輸入書本代碼 ! ";
            }
            
        }
        catch (Exception error)
        {
            //Response.Write(error);
            Return_Status.ForeColor = System.Drawing.Color.Red;
            Return_Status.Text = "歸還失敗";
            //Response.Write("歸還失敗");
        }
    }
    
}