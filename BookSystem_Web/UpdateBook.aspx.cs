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
        this.LeftBar.Items[9].Selected = true;

        if (this.LeftBar.Items[0].Selected) Response.Redirect("Lend.aspx");
        else if (this.LeftBar.Items[1].Selected) Response.Redirect("Return.aspx");
        else if (this.LeftBar.Items[2].Selected) Response.Redirect("NotReturn.aspx");
        else if (this.LeftBar.Items[3].Selected) Response.Redirect("PersonalRecord.aspx");
        else if (this.LeftBar.Items[4].Selected) Response.Redirect("ClassRecord.aspx");
        else if (this.LeftBar.Items[5].Selected) Response.Redirect("AddStudents.aspx");
        else if (this.LeftBar.Items[6].Selected) Response.Redirect("AddBooks.aspx");
        else if (this.LeftBar.Items[7].Selected) Response.Redirect("DelStudent.aspx");
        else if (this.LeftBar.Items[8].Selected) Response.Redirect("ReturnNoPoints.aspx");
        else if (this.LeftBar.Items[10].Selected) Response.Redirect("UpdateStudent.aspx");
    }

    protected void UpdateBook_ReadData_Click(object sender, EventArgs e)
    {
        try
        {
            UpdateBook_Status.Text = "";
            UpdateBook_Status.ForeColor = System.Drawing.Color.Black;

            Book book = MySQL.SelectBook(string.Format("SELECT * FROM BOOKS WHERE ID = '{0}'", UpdateBook_ErrorIDtxt.Text));

            UpdateBook_BookNametxt.Text = book.Name;
            UpdateBook_BookIDtxt.Text = book.ID;
            UpdateBook_Pointstxt.Text = book.Points.ToString();


            if ((UpdateBook_BookNametxt.Text.Length != 0) && (UpdateBook_BookNametxt.Text.Length != 0) && (UpdateBook_Pointstxt.Text.Length != 0))
                UpdateBook_Status.Text = "查詢完成";
            else
            {
                UpdateBook_Pointstxt.Text = "";
                UpdateBook_Status.ForeColor = System.Drawing.Color.Red;
                UpdateBook_Status.Text = "查詢不到此本書籍資料";
            }
            
        }
        catch (Exception error)
        {
            UpdateBook_Status.ForeColor = System.Drawing.Color.Red;
            UpdateBook_Status.Text = "資料格式錯誤，無法進行更新";
        }
    }

    protected void UpdateBook_Build_Click(object sender, EventArgs e)
    {
        try
        {
            UpdateBook_Status.ForeColor = System.Drawing.Color.Black;
            UpdateBook_Status.Text = "";

            List<Book> AllBooks = MySQL.SelectBooks("SELECT * FROM BOOKS");

            bool single = true;
            string BookName = "";
            string BookPoints = "0";
            foreach(Book book in AllBooks)
            {
                if (book.ID == UpdateBook_BookIDtxt.Text)
                {
                    single = false;
                    break;
                }
            }

            foreach (Book book in AllBooks)
            {
                if(book.ID == UpdateBook_ErrorIDtxt.Text)
                {
                    BookName = book.Name;
                    BookPoints = book.Points;
                    break;
                }
            }

            if (single)
            {
                if ((UpdateBook_BookNametxt.Text.Length != 0) && (UpdateBook_BookIDtxt.Text.Length != 0) && (UpdateBook_Pointstxt.Text.Length != 0))
                {
                    //更新Books
                    //MySQL.Update(string.Format("UPDATE BOOKS SET Name = '{0}', ID = '{1}', Period = '14', Points = '{2}' WHERE ID = '{3}'"
                    //    , UpdateBook_BookNametxt.Text, UpdateBook_BookIDtxt.Text, UpdateBook_Pointstxt.Text, UpdateBook_ErrorIDtxt.Text));
                    
                    //補習班電腦有bug所以用此方法更新Books Table
                    MySQL.Delete(string.Format("DELETE FROM BOOKS WHERE ID = '{0}'", UpdateBook_ErrorIDtxt.Text));
                    MySQL.Insert(string.Format("INSERT INTO BOOKS VALUES ('{0}', '{1}', '14', '{2}', 'true')", UpdateBook_BookNametxt.Text, UpdateBook_BookIDtxt.Text, UpdateBook_Pointstxt.Text));

                    //更新Current_Record 有bug
                    //MySQL.Update(string.Format("SET SQL_SAFE_UPDATES=0;UPDATE CURRENT_RECORD SET BooKName = '{0}', BooKID = '{1}', Points = '{2}' WHERE BookID = '{3}';SET SQL_SAFE_UPDATES=1;"
                    //    , UpdateBook_BookNametxt.Text, UpdateBook_BookIDtxt.Text, UpdateBook_Pointstxt.Text, UpdateBook_ErrorIDtxt.Text));

                    List<Current> Allcurrent = MySQL.Current_Record(string.Format("SELECT * FROM CURRENT_RECORD WHERE BookID = '{0}'", UpdateBook_ErrorIDtxt.Text));
                    foreach (Current current in Allcurrent)
                    {
                        MySQL.Delete(string.Format("DELETE FROM CURRENT_RECORD WHERE BookName = '{0}' and BookID = '{1}' and StartTime = '{2}'"
                            , current.BookName, current.BookID, current.StartTime));
                        MySQL.Insert(string.Format("INSERT INTO CURRENT_RECORD VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}')"
                            , current.StdName, current.StdID, current.Class, UpdateBook_BookNametxt.Text, UpdateBook_BookIDtxt.Text
                            , current.StartTime, current.Period, UpdateBook_Pointstxt.Text));
                    }

                    //更新History_Record
                    MySQL.Update(string.Format("UPDATE HISTORY_RECORD SET BooKName = '{0}', BooKID = '{1}', Points = '{2}' WHERE BookID = '{3}'"
                        , UpdateBook_BookNametxt.Text, UpdateBook_BookIDtxt.Text, UpdateBook_Pointstxt.Text, UpdateBook_ErrorIDtxt.Text));
                    
                    UpdateBook_Status.Text = "更新資料完成";
                }
                else
                {
                    UpdateBook_Status.ForeColor = System.Drawing.Color.Red;
                    UpdateBook_Status.Text = "更新資料不能為空白";
                }
            }
            else if (BookName != UpdateBook_BookNametxt.Text)
            {
                //更新Books
                MySQL.Update(string.Format("UPDATE BOOKS SET Name = '{0}', ID = '{1}', Period = '14', Points = '{2}' WHERE ID = '{3}'"
                    , UpdateBook_BookNametxt.Text, UpdateBook_BookIDtxt.Text, UpdateBook_Pointstxt.Text, UpdateBook_ErrorIDtxt.Text));
                
                //補習班電腦有bug所以用此方法更新Books Table
                MySQL.Delete(string.Format("DELETE FROM BOOKS WHERE ID = '{0}'", UpdateBook_ErrorIDtxt.Text));
                MySQL.Insert(string.Format("INSERT INTO BOOKS VALUES ('{0}', '{1}', '14', '{2}', 'true')", UpdateBook_BookNametxt.Text, UpdateBook_BookIDtxt.Text, UpdateBook_Pointstxt.Text));

                //更新Current_Record 有bug
                //MySQL.Update(string.Format("SET SQL_SAFE_UPDATES=0;UPDATE CURRENT_RECORD SET BooKName = '{0}', BooKID = '{1}', Points = '{2}' WHERE BookID = '{3}';SET SQL_SAFE_UPDATES=1;"
                //    , UpdateBook_BookNametxt.Text, UpdateBook_BookIDtxt.Text, UpdateBook_Pointstxt.Text, UpdateBook_ErrorIDtxt.Text));

                List<Current> Allcurrent = MySQL.Current_Record(string.Format("SELECT * FROM CURRENT_RECORD WHERE BookID = '{0}'", UpdateBook_ErrorIDtxt.Text));
                foreach (Current current in Allcurrent)
                {
                    MySQL.Delete(string.Format("DELETE FROM CURRENT_RECORD WHERE BookName = '{0}' and BookID = '{1}' and StartTime = '{2}'"
                        , current.BookName, current.BookID, current.StartTime));
                    MySQL.Insert(string.Format("INSERT INTO CURRENT_RECORD VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}')"
                        , current.StdName, current.StdID, current.Class, UpdateBook_BookNametxt.Text, UpdateBook_BookIDtxt.Text
                        , current.StartTime, current.Period, UpdateBook_Pointstxt.Text));
                }

                //更新History_Record
                MySQL.Update(string.Format("UPDATE HISTORY_RECORD SET BooKName = '{0}', BooKID = '{1}', Points = '{2}' WHERE BookID = '{3}'"
                    , UpdateBook_BookNametxt.Text, UpdateBook_BookIDtxt.Text, UpdateBook_Pointstxt.Text, UpdateBook_ErrorIDtxt.Text));

                UpdateBook_Status.Text = "更新資料完成";
            }
            else if (BookPoints != UpdateBook_Pointstxt.Text)
            {
                //更新Books
                MySQL.Update(string.Format("UPDATE BOOKS SET Name = '{0}', ID = '{1}', Period = '14', Points = '{2}' WHERE ID = '{3}'"
                    , UpdateBook_BookNametxt.Text, UpdateBook_BookIDtxt.Text, UpdateBook_Pointstxt.Text, UpdateBook_ErrorIDtxt.Text));
                
                //補習班電腦有bug所以用此方法更新Books Table
                MySQL.Delete(string.Format("DELETE FROM BOOKS WHERE ID = '{0}'", UpdateBook_ErrorIDtxt.Text));
                MySQL.Insert(string.Format("INSERT INTO BOOKS VALUES ('{0}', '{1}', '14', '{2}', 'true')", UpdateBook_BookNametxt.Text, UpdateBook_BookIDtxt.Text, UpdateBook_Pointstxt.Text));

                List<Current> Allcurrent = MySQL.Current_Record(string.Format("SELECT * FROM CURRENT_RECORD WHERE BookID = '{0}'", UpdateBook_ErrorIDtxt.Text));
                foreach (Current current in Allcurrent)
                {
                    MySQL.Delete(string.Format("DELETE FROM CURRENT_RECORD WHERE BookName = '{0}' and BookID = '{1}' and StartTime = '{2}'"
                        , current.BookName, current.BookID, current.StartTime));
                    MySQL.Insert(string.Format("INSERT INTO CURRENT_RECORD VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}')"
                        , current.StdName, current.StdID, current.Class, UpdateBook_BookNametxt.Text, UpdateBook_BookIDtxt.Text
                        , current.StartTime, current.Period, UpdateBook_Pointstxt.Text));
                }

                //更新Current_Record 有bug
                //MySQL.Update(string.Format("SET SQL_SAFE_UPDATES=0;UPDATE CURRENT_RECORD SET BooKName = '{0}', BooKID = '{1}', Points = '{2}' WHERE BookID = '{3}';SET SQL_SAFE_UPDATES=1;"
                //    , UpdateBook_BookNametxt.Text, UpdateBook_BookIDtxt.Text, UpdateBook_Pointstxt.Text, UpdateBook_ErrorIDtxt.Text));

                //更新History_Record
                MySQL.Update(string.Format("UPDATE HISTORY_RECORD SET BooKName = '{0}', BooKID = '{1}', Points = '{2}' WHERE BookID = '{3}'"
                    , UpdateBook_BookNametxt.Text, UpdateBook_BookIDtxt.Text, UpdateBook_Pointstxt.Text, UpdateBook_ErrorIDtxt.Text));

                UpdateBook_Status.Text = "更新資料完成";
            }
            else
            {
                UpdateBook_Status.ForeColor = System.Drawing.Color.Red;
                UpdateBook_Status.Text = "欲更新的資訊已經存在";
            }
        }
        catch (Exception error)
        {
            UpdateBook_Status.ForeColor = System.Drawing.Color.Red;
            UpdateBook_Status.Text = "資料格式有誤，更新資料失敗";
        }
    }
}