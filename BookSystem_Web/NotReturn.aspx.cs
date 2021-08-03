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
        this.LeftBar.Items[2].Selected = true;
        if (this.LeftBar.Items[0].Selected) Response.Redirect("Lend.aspx");
        else if (this.LeftBar.Items[1].Selected) Response.Redirect("Return.aspx");
        else if (this.LeftBar.Items[3].Selected) Response.Redirect("PersonalRecord.aspx");
        else if (this.LeftBar.Items[4].Selected) Response.Redirect("ClassRecord.aspx");
        else if (this.LeftBar.Items[5].Selected) Response.Redirect("AddStudents.aspx");
        else if (this.LeftBar.Items[6].Selected) Response.Redirect("AddBooks.aspx");
        else if (this.LeftBar.Items[7].Selected) Response.Redirect("DelStudent.aspx");
        else if (this.LeftBar.Items[8].Selected) Response.Redirect("ReturnNoPoints.aspx");
        else if (this.LeftBar.Items[9].Selected) Response.Redirect("UpdateBook.aspx");
        else if (this.LeftBar.Items[10].Selected) Response.Redirect("UpdateStudent.aspx");
    }

    protected void NotReturn_Show_Click(object sender, EventArgs e)
    {
        try
        {
            NotReturn_Status.ForeColor = System.Drawing.Color.Black;

            List<Student> AllStudents = MySQL.SelectStudents("SELECT * FROM STUDENTS");
            List<Book> AllBooks = MySQL.SelectBooks("SELECT * FROM BOOKS");
            //還書
            Dictionary<string, List<string>> Personal_currRecord = MySQL.SelectCurrent("SELECT * FROM CURRENT_RECORD");

            //歷史紀錄
            Dictionary<string, Tuple<List<string>, List<string>, List<string>, List<string>>> Class_historyRecord = MySQL.SelectHistory("SELECT * FROM history_RECORD", Information.Class);
            Dictionary<string, Tuple<List<string>, List<string>, List<string>, List<string>>> Personal_historyRecord = MySQL.SelectHistory("SELECT * FROM History_RECORD", Information.Personal);


            NotReturnBookList.Items.Clear();

            List<string> books;

            //根據學號 補齊學生姓名、班級
            string StdID = NotReturn_StdIDtxt.Text;
            bool Std_Find = false;
            foreach (Student student in AllStudents)
            {
                if (student.ID == StdID)
                {
                    NotReturn_Classtxt.Text = student.Class;
                    NotReturn_Nametxt.Text = student.Name;
                    Std_Find = true;
                    break;
                }
            }

            if (Std_Find)
            {
                //顯示截至目前尚未歸還的書籍
                try
                {
                    Personal_currRecord.TryGetValue(StdID, out books);
                    for (int item = 0; item < books.Count; item++)
                    {
                        string BookID = MySQL.SelectBookID(string.Format("SELECT BOOKID FROM CURRENT_RECORD WHERE STDID = '{0}' AND BOOKNAME = '{1}'", NotReturn_StdIDtxt.Text, books[item]));
                        NotReturnBookList.Items.Add(string.Format("書名：{0} ; 書號：{1}",books[item],BookID));
                    }
                    NotReturn_Status.Text = "查詢成功";
                    //Response.Write("成功");
                }
                catch (Exception error)
                {
                    throw error;
                    NotReturn_Status.ForeColor = System.Drawing.Color.Red;
                    NotReturn_Status.Text = "此學生沒有未歸還的書籍";
                }
            }
            else
            {
                NotReturn_Classtxt.Text = "";
                NotReturn_Nametxt.Text = "";
                NotReturn_Status.ForeColor = System.Drawing.Color.Red;
                NotReturn_Status.Text = "沒有此學生的相關資訊";
            }
            
        }
        catch (Exception error)
        {
            Console.WriteLine(error);
            NotReturn_Status.ForeColor = System.Drawing.Color.Red;
            NotReturn_Status.Text = "資料格式發生錯誤，找不到資料";
            //Response.Write("找不到資料");
        }
    }
}