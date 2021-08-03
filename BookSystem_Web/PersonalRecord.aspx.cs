using Foundation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.LeftBar.Items[3].Selected = true;
        if (this.LeftBar.Items[0].Selected) Response.Redirect("Lend.aspx");
        else if (this.LeftBar.Items[1].Selected) Response.Redirect("Return.aspx");
        else if (this.LeftBar.Items[2].Selected) Response.Redirect("NotReturn.aspx");
        else if (this.LeftBar.Items[4].Selected) Response.Redirect("ClassRecord.aspx");
        else if (this.LeftBar.Items[5].Selected) Response.Redirect("AddStudents.aspx");
        else if (this.LeftBar.Items[6].Selected) Response.Redirect("AddBooks.aspx");
        else if (this.LeftBar.Items[7].Selected) Response.Redirect("DelStudent.aspx");
        else if (this.LeftBar.Items[8].Selected) Response.Redirect("ReturnNoPoints.aspx");
        else if (this.LeftBar.Items[9].Selected) Response.Redirect("UpdateBook.aspx");
        else if (this.LeftBar.Items[10].Selected) Response.Redirect("UpdateStudent.aspx");
    }

    protected void PersonalRecord_Record_Click(object sender, EventArgs e)
    {
        PersonalRecord_View.DataSource = "";
        PersonalRecord_View.DataBind();

        PersonalRecord_Status.ForeColor = System.Drawing.Color.Black;
        try
        {
            List<Student> AllStudents = MySQL.SelectStudents("SELECT * FROM STUDENTS");
            List<Book> AllBooks = MySQL.SelectBooks("SELECT * FROM BOOKS");
            //還書
            //Dictionary<string, List<string>> Personal_currRecord = MySQL.SelectCurrent("SELECT * FROM CURRENT_RECORD");

            //歷史紀錄
            //Dictionary<string, Tuple<List<string>, List<string>, List<string>>> Class_historyRecord = MySQL.SelectHistory("SELECT * FROM history_RECORD", Information.Class);
            Dictionary<string, Tuple<List<string>, List<string>, List<string>, List<string>>> Personal_historyRecord = MySQL.SelectHistory(string.Format("SELECT * FROM History_RECORD where StdID = '{0}'", PersonalRecord_StdIDtxt.Text), Information.Personal);
            
            //根據學號 補齊學生姓名、班級
            string StdID = PersonalRecord_StdIDtxt.Text;
            bool Std_Find = false;
            foreach (Student student in AllStudents)
            {
                if (StdID == student.ID)
                {
                    PersonalRecord_Nametxt.Text = student.Name;
                    PersonalRecord_Classtxt.Text = student.Class;
                    Std_Find = true;
                    break;
                }
            }

            if (Std_Find)
            {
                try
                {
                    //顯示截至目前已歸還的書籍
                    //Book, StartTime, EndTime
                    Tuple<List<string>, List<string>, List<string>, List<string>> value;
                    Personal_historyRecord.TryGetValue(StdID, out value);
                    string points = "0";
                    string InTime = "";
                    string BookID = "";

                    DataTable dt = new DataTable();
                    List<string> ColumnName = new List<string> { "借閱時間", "書名", "書號", "分數", "是否準時" };
                    dt = Foundation.Foundation.Add_Columns(dt, ColumnName);
                    /*dt.Columns.Add("借閱時間");
                    dt.Columns.Add("書名");
                    dt.Columns.Add("分數");
                    dt.Columns.Add("是否準時");*/
                    for (int item = 0; item < value.Item1.Count; item++)
                    {
                        foreach (var book in AllBooks)
                        {
                            if (value.Item1[item] == book.Name)
                            {
                                points = book.Points;
                                //BookID = book.ID;
                                break;
                            }
                        }

                        BookID = value.Item4[item];


                        //取得 InTime 欄位
                        InTime = MySQL.Select(string.Format("SELECT * FROM HISTORY_RECORD WHERE BOOKID = '{0}' AND EndTime = '{1}'", BookID, value.Item3[item]), Information.InTime);

                        //借閱&歸還日期 ; 書名;書號 ; 點數
                        dt.Rows.Add(string.Format("借出日期 : {0} \n\r 歸還日期 : {1}", value.Item2[item], value.Item3[item])
                        , value.Item1[item], BookID, points, InTime);
                    }
                    PersonalRecord_View.DataSource = dt;
                    PersonalRecord_View.DataBind();
                    PersonalRecord_Status.Text = "查詢完成";
                    //Response.Write("查詢紀錄完成");
                }
                catch (Exception error)
                {
                    PersonalRecord_Status.ForeColor = System.Drawing.Color.Red;
                    PersonalRecord_Status.Text = "此學生沒有歷史紀錄";
                }
            }
            else
            {
                PersonalRecord_Nametxt.Text = "";
                PersonalRecord_Classtxt.Text = "";
                PersonalRecord_Status.ForeColor = System.Drawing.Color.Red;
                PersonalRecord_Status.Text = "沒有此學生的相關資訊";
            }

        }
        catch (Exception error)
        {
            //Console.WriteLine(error);
            PersonalRecord_Status.ForeColor = System.Drawing.Color.Red;
            PersonalRecord_Status.Text = "資料格式錯誤，查詢紀錄失敗";
            //Response.Write("查詢紀錄失敗");
        }
    }
}