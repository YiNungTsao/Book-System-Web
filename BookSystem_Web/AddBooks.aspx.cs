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
        this.LeftBar.Items[6].Selected = true;

        if (this.LeftBar.Items[0].Selected) Response.Redirect("Lend.aspx");
        else if (this.LeftBar.Items[1].Selected) Response.Redirect("Return.aspx");
        else if (this.LeftBar.Items[2].Selected) Response.Redirect("NotReturn.aspx");
        else if (this.LeftBar.Items[3].Selected) Response.Redirect("PersonalRecord.aspx");
        else if (this.LeftBar.Items[4].Selected) Response.Redirect("ClassRecord.aspx");
        else if (this.LeftBar.Items[5].Selected) Response.Redirect("AddStudents.aspx");
        else if (this.LeftBar.Items[7].Selected) Response.Redirect("DelStudent.aspx");
        else if (this.LeftBar.Items[8].Selected) Response.Redirect("ReturnNoPoints.aspx");
        else if (this.LeftBar.Items[9].Selected) Response.Redirect("UpdateBook.aspx");
        else if (this.LeftBar.Items[10].Selected) Response.Redirect("UpdateStudent.aspx");
    }

    protected void AddBook_Build_Click(object sender, EventArgs e)
    {
        List<Book> AllBooks = MySQL.SelectBooks("SELECT * FROM BOOKS");
        
        AddBook_Status.Text = "";
        AddBook_Status.ForeColor = System.Drawing.Color.Black;
        try
        {
            Book AddBook = new Book();
            if ((AddBook_BookNametxt.Text.Length != 0) && (AddBook_BookIDtxt.Text.Length != 0) && (AddBook_Pointstxt.Text.Length != 0))
            {
                AddBook.Name = AddBook_BookNametxt.Text;
                AddBook.ID = AddBook_BookIDtxt.Text;
                AddBook.Period = AddBook_Periodtxt.Text;
                AddBook.Points = AddBook_Pointstxt.Text;

                //防止輸入一樣的書本代號
                bool single = true;
                foreach(Book book in AllBooks)
                {
                    if (book.ID == AddBook.ID)
                    {
                        single = false;
                        break;
                    }
                }

                if (single)
                {
                    try
                    {
                        MySQL.Insert(string.Format("INSERT INTO BOOKS VALUES('{0}','{1}','{2}','{3}','true')", AddBook.Name, AddBook.ID, AddBook.Period, AddBook.Points));

                        //清空文字方框
                        AddBook_BookNametxt.Text = "";
                        AddBook_BookIDtxt.Text = "";
                        AddBook_Pointstxt.Text = "";

                        AddBook_Status.Text = "新增書本完成";
                        //Response.Write("完成~");
                    }
                    catch (Exception error)
                    {
                        AddBook_Status.ForeColor = System.Drawing.Color.Red;
                        AddBook_Status.Text = "新增書本失敗，格式有誤";
                    }
                }
                else
                {
                    AddBook_Status.ForeColor = System.Drawing.Color.Red;
                    AddBook_Status.Text = "此書本代號已經存在 ! 請重新輸入";
                }

            }
            else
            {
                AddBook_Status.ForeColor = System.Drawing.Color.Red;
                AddBook_Status.Text = "不得輸入空白資訊 !";
                //Response.Write("不得輸入空白資訊 !");
            }
        }
        catch (Exception error)
        {
            //Console.WriteLine(error);
            AddBook_Status.ForeColor = System.Drawing.Color.Red;
            AddBook_Status.Text = "資料格式發生錯誤";
            //Response.Write("失敗");
        }
    }
}