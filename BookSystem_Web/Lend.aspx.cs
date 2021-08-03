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
        LeftBar.Items[0].Selected = true;
        if (this.LeftBar.Items[1].Selected) Response.Redirect("Return.aspx");
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

    protected void Lend_ReadData_Click(object sender, EventArgs e)
    {
        Lend_Status.ForeColor = System.Drawing.Color.Black;
        try
        {
            List<Student> AllStudents = MySQL.SelectStudents("SELECT * FROM STUDENTS");
            List<Book> AllBooks = MySQL.SelectBooks("SELECT * FROM BOOKS");
            Lend_Status.Text = "";

            bool Std_Find = false;
            //根據學號 補齊學生姓名、班級
            if (Lend_StdIDtxt.Text.Length != 0)
            {
                string StdID = Lend_StdIDtxt.Text;
                foreach (Student student in AllStudents)
                {
                    if (StdID == student.ID)
                    {
                        Lend_Nametxt.Text = student.Name;
                        Lend_Classtxt.Text = student.Class;
                        Std_Find = true;
                        break;
                    }
                }
            }
            else
            {
                Lend_Status.ForeColor = System.Drawing.Color.Red;
                Lend_Status.Text = "一定要輸入學號 !";
                //Response.Write("一定要輸入學號 !");
            }

            //根據書的代碼(掃進) 補齊書名和可借閱期限
            string period = "";
            string points = "0";
            bool book_Find = false;
            if (Lend_BookIDtxt.Text.Length != 0)
            {
                string BookID = Lend_BookIDtxt.Text;
                foreach (Book book in AllBooks)
                {
                    if (BookID == book.ID)
                    {
                        period = book.Period;
                        points = book.Points;
                        Lend_BookNametxt.Text = book.Name;
                        Lend_StartDatetxt.Text = DateTime.Now.ToShortDateString();
                        book_Find = true;
                        break;
                    }
                }
            }
            else
            {
                Lend_Status.ForeColor = System.Drawing.Color.Red;
                Lend_Status.Text = "要掃到書本的代碼才行";
                //Response.Write("要掃到書本的代碼才行");
            }

            if (book_Find)
            {
                if (Std_Find) Lend_Status.Text = "查詢成功";
                else
                {
                    Lend_Nametxt.Text = "";
                    Lend_Classtxt.Text = "";
                    Lend_Status.ForeColor = System.Drawing.Color.Red;
                    Lend_Status.Text = "沒有此學生的資訊";
                }
            }
            else
            {
                Lend_StartDatetxt.Text = "";
                Lend_BookNametxt.Text = "";
                Lend_Status.ForeColor = System.Drawing.Color.Red;
                Lend_Status.Text = "沒有此本書的資訊";
            } 
        }
        catch (Exception error)
        {
            Console.WriteLine(error);
            Lend_Status.ForeColor = System.Drawing.Color.Red;
            Lend_Status.Text = "查詢失敗";
            //Response.Write("查詢失敗"); 
        }
    }

    protected void Lend_InsertData_Click(object sender, EventArgs e)
    {
        try
        {
            Lend_Status.ForeColor = System.Drawing.Color.Black;
            Lend_Status.Text = "";

            List<Student> AllStudents = MySQL.SelectStudents("SELECT * FROM STUDENTS");
            List<Book> AllBooks = MySQL.SelectBooks("SELECT * FROM BOOKS");
            //還書
            Dictionary<string, List<string>> Personal_currRecord = MySQL.SelectCurrent("SELECT * FROM CURRENT_RECORD");

            //歷史紀錄
            Dictionary<string, Tuple<List<string>, List<string>, List<string>, List<string>>> Class_historyRecord = MySQL.SelectHistory("SELECT * FROM history_RECORD", Information.Class);
            Dictionary<string, Tuple<List<string>, List<string>, List<string>, List<string>>> Personal_historyRecord = MySQL.SelectHistory("SELECT * FROM History_RECORD", Information.Personal);


            //找出此本書對應的 期限 和 點數
            string points = "0";
            string period = "";
            Book book = new Book();
            foreach (Book eachBook in AllBooks)
            {
                if (eachBook.ID == Lend_BookIDtxt.Text)
                {
                    points = eachBook.Points;
                    period = eachBook.Period;
                    book = eachBook;
                    break;
                }
            }

            if ((period != "") && (points != "0"))
            {
                try
                {
                    //防止連按兩下 借出按鈕
                    if ((book.Name == Lend_BookNametxt.Text) && (Lend_Nametxt.Text.Length != 0) && (Lend_StdIDtxt.Text.Length != 0) && (Lend_Classtxt.Text.Length != 0))
                    {
                        string available = MySQL.Available(string.Format("SELECT AVAILABLE FROM BOOKS WHERE ID = '{0}'", Lend_BookIDtxt.Text));
                        
                        if (available == "true")
                        {
                            MySQL.Insert(string.Format("INSERT INTO CURRENT_RECORD VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}')"
                           , Lend_Nametxt.Text, Lend_StdIDtxt.Text, Lend_Classtxt.Text, Lend_BookNametxt.Text, Lend_BookIDtxt.Text
                           , DateTime.Now.ToShortDateString(), period, points));

                            Personal_currRecord = MySQL.SelectCurrent("SELECT * FROM CURRENT_RECORD");

                            MySQL.Update(string.Format("UPDATE BOOKS SET AVAILABLE = '{0}' WHERE ID = '{1}'", "false", Lend_BookIDtxt.Text));
                            
                            Lend_Status.Text = "借閱完成";
                            //Response.Write("借閱完成");
                        }
                        else
                        {
                            Lend_Status.ForeColor = System.Drawing.Color.Red;
                            Lend_Status.Text = "此本書已經被借走了";
                        }
                    }
                    else
                    {
                        Lend_Status.ForeColor = System.Drawing.Color.Red;
                        Lend_Status.Text = "借閱失敗，書號與書名無法對應";
                        //Response.Write("借閱失敗");
                    }
                }
                catch (Exception error)
                {
                    Lend_Status.ForeColor = System.Drawing.Color.Red;
                    Lend_Status.Text = "借閱失敗";
                    //Response.Write("借閱失敗");
                }
            }
            else
            {
                Lend_Status.ForeColor = System.Drawing.Color.Red;
                Lend_Status.Text = "沒有此本書的資訊";
            }
        }
        catch (Exception error)
        {
            Console.WriteLine(error);
            Lend_Status.ForeColor = System.Drawing.Color.Red;
            Lend_Status.Text = "借閱失敗";
            //Response.Write("借閱失敗");
        }
    }
}