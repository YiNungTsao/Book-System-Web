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
        this.LeftBar.Items[5].Selected = true;

        if (this.LeftBar.Items[0].Selected) Response.Redirect("Lend.aspx");
        else if (this.LeftBar.Items[1].Selected) Response.Redirect("Return.aspx");
        else if (this.LeftBar.Items[2].Selected) Response.Redirect("NotReturn.aspx");
        else if (this.LeftBar.Items[3].Selected) Response.Redirect("PersonalRecord.aspx");
        else if (this.LeftBar.Items[4].Selected) Response.Redirect("ClassRecord.aspx");
        else if (this.LeftBar.Items[6].Selected) Response.Redirect("AddBooks.aspx");
        else if (this.LeftBar.Items[7].Selected) Response.Redirect("DelStudent.aspx");
        else if (this.LeftBar.Items[8].Selected) Response.Redirect("ReturnNoPoints.aspx");
        else if (this.LeftBar.Items[9].Selected) Response.Redirect("UpdateBook.aspx");
        else if (this.LeftBar.Items[10].Selected) Response.Redirect("UpdateStudent.aspx");
    }

    protected void AddStd_Build_Click(object sender, EventArgs e)
    {
        List<Student> AllStudents = MySQL.SelectStudents("SELECT * FROM STUDENTS");

        AddStd_Status.ForeColor = System.Drawing.Color.Black;
        AddStd_Status.Text = "";
        try
        {
            Student AddStudent = new Student();
            if ((AddStd_Nametxt.Text.Length != 0) && (AddStd_StdIDtxt.Text.Length != 0) && (AddStd_Classtxt.Text.Length != 0))
            {
                AddStudent.Name = AddStd_Nametxt.Text;
                AddStudent.ID = AddStd_StdIDtxt.Text;
                AddStudent.Class = AddStd_Classtxt.Text;
                AddStudent.Points = "0";

                //防止輸入一樣的學號
                bool single = true;
                foreach (Student student in AllStudents)
                {
                    if (student.ID == AddStudent.ID)
                    {
                        single = false;
                        break;
                    }
                }

                if (single)
                {
                    MySQL.Insert(string.Format("INSERT INTO STUDENTS VALUES('{0}','{1}','{2}')", AddStudent.Name, AddStudent.ID, AddStudent.Class));

                    //清空文字方框
                    AddStd_Nametxt.Text = "";
                    AddStd_StdIDtxt.Text = "";
                    AddStd_Classtxt.Text = "";

                    AddStd_Status.Text = "新增資料成功";
                    //Response.Write("完成~");
                }
                else
                {
                    AddStd_Status.ForeColor = System.Drawing.Color.Red;
                    AddStd_Status.Text = "此學號已經存在 ! 請重新輸入"; ;
                }

            }
            else
            {
                AddStd_Status.ForeColor = System.Drawing.Color.Red;
                AddStd_Status.Text = "不得輸入空白資訊 !";
                //Response.Write("不得輸入空白資訊 !");
            }
        }
        catch (Exception error)
        {
            Console.WriteLine(error);
            AddStd_Status.ForeColor = System.Drawing.Color.Red;
            AddStd_Status.Text = "資料格式發生錯誤";
            //Response.Write("資料格式發生錯誤");
        }
    }
}