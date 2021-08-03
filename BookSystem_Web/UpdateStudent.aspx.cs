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
        this.LeftBar.Items[10].Selected = true;

        if (this.LeftBar.Items[0].Selected) Response.Redirect("Lend.aspx");
        else if (this.LeftBar.Items[1].Selected) Response.Redirect("Return.aspx");
        else if (this.LeftBar.Items[2].Selected) Response.Redirect("NotReturn.aspx");
        else if (this.LeftBar.Items[3].Selected) Response.Redirect("PersonalRecord.aspx");
        else if (this.LeftBar.Items[4].Selected) Response.Redirect("ClassRecord.aspx");
        else if (this.LeftBar.Items[5].Selected) Response.Redirect("AddStudents.aspx");
        else if (this.LeftBar.Items[6].Selected) Response.Redirect("AddBooks.aspx");
        else if (this.LeftBar.Items[7].Selected) Response.Redirect("DelStudent.aspx");
        else if (this.LeftBar.Items[8].Selected) Response.Redirect("ReturnNoPoints.aspx");
        else if (this.LeftBar.Items[9].Selected) Response.Redirect("UpdateBook.aspx");
    }

    protected void UpdateBook_ReadData_Click(object sender, EventArgs e)
    {
        try
        {
            UpdateStd_Status.Text = "";
            UpdateStd_Status.ForeColor = System.Drawing.Color.Black;

            Student student = MySQL.SelectStudent(string.Format("SELECT * FROM STUDENTS WHERE ID = '{0}'", UpdateStd_ErrorIDtxt.Text));

            UpdateStd_Nametxt.Text = student.Name;
            UpdateStd_IDtxt.Text = student.ID;
            UpdateStd_Classtxt.Text = student.Class.ToString();


            if ((UpdateStd_Nametxt.Text.Length != 0) && (UpdateStd_Nametxt.Text.Length != 0) && (UpdateStd_Classtxt.Text.Length != 0))
                UpdateStd_Status.Text = "查詢完成";
            else
            {
                UpdateStd_Classtxt.Text = "";
                UpdateStd_Status.ForeColor = System.Drawing.Color.Red;
                UpdateStd_Status.Text = "查詢不到此本書籍資料";
            }

        }
        catch (Exception error)
        {
            UpdateStd_Status.ForeColor = System.Drawing.Color.Red;
            UpdateStd_Status.Text = "資料格式錯誤，無法進行更新";
        }
    }

    protected void UpdateBook_Build_Click(object sender, EventArgs e)
    {
        try
        {
            UpdateStd_Status.ForeColor = System.Drawing.Color.Black;
            UpdateStd_Status.Text = "";

            List<Student> AllStudents = MySQL.SelectStudents("SELECT * FROM STUDENTS");

            bool single = true;
            string StdName = "";
            string StdClass = "";
            foreach (Student student in AllStudents)
            {
                if (student.ID == UpdateStd_IDtxt.Text)
                {
                    single = false;
                    break;
                }
            }

            foreach (Student student in AllStudents)
            {
                if (student.ID == UpdateStd_ErrorIDtxt.Text)
                {
                    StdName = student.Name;
                    StdClass = student.Class;
                    break;
                }
            }

            if (single)
            {
                if ((UpdateStd_Nametxt.Text.Length != 0) && (UpdateStd_IDtxt.Text.Length != 0) && (UpdateStd_Classtxt.Text.Length != 0))
                {
                    //更新Books
                    //MySQL.Update(string.Format("UPDATE BOOKS SET Name = '{0}', ID = '{1}', Period = '14', Points = '{2}' WHERE ID = '{3}'"
                    //    , UpdateBook_BookNametxt.Text, UpdateBook_BookIDtxt.Text, UpdateBook_Pointstxt.Text, UpdateBook_ErrorIDtxt.Text));

                    //補習班電腦有bug所以用此方法更新Students Table
                    MySQL.Delete(string.Format("DELETE FROM STUDENTS WHERE ID = '{0}'", UpdateStd_ErrorIDtxt.Text));
                    MySQL.Insert(string.Format("INSERT INTO STUDENTS VALUES ('{0}', '{1}', '{2}')"
                        , UpdateStd_Nametxt.Text, UpdateStd_IDtxt.Text, UpdateStd_Classtxt.Text));

                    //更新Current_Record 有bug
                    //MySQL.Update(string.Format("SET SQL_SAFE_UPDATES=0;UPDATE CURRENT_RECORD SET BooKName = '{0}', BooKID = '{1}', Points = '{2}' WHERE BookID = '{3}';SET SQL_SAFE_UPDATES=1;"
                    //    , UpdateBook_BookNametxt.Text, UpdateBook_BookIDtxt.Text, UpdateBook_Pointstxt.Text, UpdateBook_ErrorIDtxt.Text));

                    List<Current> Allcurrent = MySQL.Current_Record(string.Format("SELECT * FROM CURRENT_RECORD WHERE StdID = '{0}'", UpdateStd_ErrorIDtxt.Text));
                    foreach (Current current in Allcurrent)
                    {
                        MySQL.Delete(string.Format("DELETE FROM CURRENT_RECORD WHERE StdName = '{0}' and StdID = '{1}' and StartTime = '{2}'"
                            , current.StdName, current.StdID, current.StartTime));
                        MySQL.Insert(string.Format("INSERT INTO CURRENT_RECORD VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}')"
                            , UpdateStd_Nametxt.Text, UpdateStd_IDtxt.Text, UpdateStd_Classtxt.Text, current.BookName, current.BookID, current.StartTime, current.Period, current.Points));
                    }

                    //更新History_Record
                    MySQL.Update(string.Format("UPDATE HISTORY_RECORD SET StdName = '{0}', StdID = '{1}', Class = '{2}' WHERE StdID = '{3}'"
                        , UpdateStd_Nametxt.Text, UpdateStd_IDtxt.Text, UpdateStd_Classtxt.Text, UpdateStd_ErrorIDtxt.Text));

                    UpdateStd_Status.Text = "更新資料完成";
                }
                else
                {
                    UpdateStd_Status.ForeColor = System.Drawing.Color.Red;
                    UpdateStd_Status.Text = "更新資料不能為空白";
                }
            }
            else if (StdName != UpdateStd_Nametxt.Text)
            {
                //更新Books
                MySQL.Update(string.Format("UPDATE BOOKS SET Name = '{0}', ID = '{1}', Period = '14', Points = '{2}' WHERE ID = '{3}'"
                    , UpdateStd_Nametxt.Text, UpdateStd_IDtxt.Text, UpdateStd_Classtxt.Text, UpdateStd_ErrorIDtxt.Text));

                //補習班電腦有bug所以用此方法更新Students Table
                MySQL.Delete(string.Format("DELETE FROM STUDENTS WHERE ID = '{0}'", UpdateStd_ErrorIDtxt.Text));
                MySQL.Insert(string.Format("INSERT INTO STUDENTS VALUES ('{0}', '{1}', '{2}')"
                    , UpdateStd_Nametxt.Text, UpdateStd_IDtxt.Text, UpdateStd_Classtxt.Text));

                //更新Current_Record 有bug
                //MySQL.Update(string.Format("SET SQL_SAFE_UPDATES=0;UPDATE CURRENT_RECORD SET BooKName = '{0}', BooKID = '{1}', Points = '{2}' WHERE BookID = '{3}';SET SQL_SAFE_UPDATES=1;"
                //    , UpdateBook_BookNametxt.Text, UpdateBook_BookIDtxt.Text, UpdateBook_Pointstxt.Text, UpdateBook_ErrorIDtxt.Text));

                List<Current> Allcurrent = MySQL.Current_Record(string.Format("SELECT * FROM CURRENT_RECORD WHERE StdID = '{0}'", UpdateStd_ErrorIDtxt.Text));
                foreach (Current current in Allcurrent)
                {
                    MySQL.Delete(string.Format("DELETE FROM CURRENT_RECORD WHERE StdName = '{0}' and StdID = '{1}' and StartTime = '{2}'"
                        , current.StdName, current.StdID, current.StartTime));
                    MySQL.Insert(string.Format("INSERT INTO CURRENT_RECORD VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}')"
                        , UpdateStd_Nametxt.Text, UpdateStd_IDtxt.Text, UpdateStd_Classtxt.Text, current.BookName, current.BookID, current.StartTime, current.Period, current.Points));
                }

                //更新History_Record
                MySQL.Update(string.Format("UPDATE HISTORY_RECORD SET StdName = '{0}', StdID = '{1}', Class = '{2}' WHERE StdID = '{3}'"
                    , UpdateStd_Nametxt.Text, UpdateStd_IDtxt.Text, UpdateStd_Classtxt.Text, UpdateStd_ErrorIDtxt.Text));

                UpdateStd_Status.Text = "更新資料完成";
            }
            else if (StdClass != UpdateStd_Classtxt.Text)
            {
                //更新Books
                MySQL.Update(string.Format("UPDATE STUDENTS SET Name = '{0}', ID = '{1}', Class = '{2}' WHERE ID = '{3}'"
                    , UpdateStd_Nametxt.Text, UpdateStd_IDtxt.Text, UpdateStd_Classtxt.Text, UpdateStd_ErrorIDtxt.Text));

                //補習班電腦有bug所以用此方法更新Students Table
                MySQL.Delete(string.Format("DELETE FROM STUDENTS WHERE ID = '{0}'", UpdateStd_ErrorIDtxt.Text));
                MySQL.Insert(string.Format("INSERT INTO STUDENTS VALUES ('{0}', '{1}', '{2}')"
                    , UpdateStd_Nametxt.Text, UpdateStd_IDtxt.Text, UpdateStd_Classtxt.Text));

                //更新Current_Record 有bug
                //MySQL.Update(string.Format("SET SQL_SAFE_UPDATES=0;UPDATE CURRENT_RECORD SET BooKName = '{0}', BooKID = '{1}', Points = '{2}' WHERE BookID = '{3}';SET SQL_SAFE_UPDATES=1;"
                //    , UpdateBook_BookNametxt.Text, UpdateBook_BookIDtxt.Text, UpdateBook_Pointstxt.Text, UpdateBook_ErrorIDtxt.Text));
                List<Current> Allcurrent = MySQL.Current_Record(string.Format("SELECT * FROM CURRENT_RECORD WHERE StdID = '{0}'", UpdateStd_ErrorIDtxt.Text));
                foreach (Current current in Allcurrent)
                {
                    MySQL.Delete(string.Format("DELETE FROM CURRENT_RECORD WHERE StdName = '{0}' and StdID = '{1}' and StartTime = '{2}'"
                        , current.StdName, current.StdID, current.StartTime));
                    MySQL.Insert(string.Format("INSERT INTO CURRENT_RECORD VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}')"
                        , UpdateStd_Nametxt.Text, UpdateStd_IDtxt.Text, UpdateStd_Classtxt.Text, current.BookName, current.BookID, current.StartTime, current.Period, current.Points));
                }

                //更新History_Record
                MySQL.Update(string.Format("UPDATE HISTORY_RECORD SET StdName = '{0}', StdID = '{1}', Class = '{2}' WHERE StdID = '{3}'"
                    , UpdateStd_Nametxt.Text, UpdateStd_IDtxt.Text, UpdateStd_Classtxt.Text, UpdateStd_ErrorIDtxt.Text));

                UpdateStd_Status.Text = "更新資料完成";
            }
            else
            {
                UpdateStd_Status.ForeColor = System.Drawing.Color.Red;
                UpdateStd_Status.Text = "欲更新的資訊已經存在";
            }
        }
        catch (Exception error)
        {
            UpdateStd_Status.ForeColor = System.Drawing.Color.Red;
            UpdateStd_Status.Text = "資料格式有誤，更新資料失敗";
        }
    }
}