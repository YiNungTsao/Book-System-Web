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
        this.LeftBar.Items[7].Selected = true;

        if (this.LeftBar.Items[0].Selected) Response.Redirect("Lend.aspx");
        else if (this.LeftBar.Items[1].Selected) Response.Redirect("Return.aspx");
        else if (this.LeftBar.Items[2].Selected) Response.Redirect("NotReturn.aspx");
        else if (this.LeftBar.Items[3].Selected) Response.Redirect("PersonalRecord.aspx");
        else if (this.LeftBar.Items[4].Selected) Response.Redirect("ClassRecord.aspx");
        else if (this.LeftBar.Items[5].Selected) Response.Redirect("AddStudents.aspx");
        else if (this.LeftBar.Items[6].Selected) Response.Redirect("AddBooks.aspx");
        else if (this.LeftBar.Items[8].Selected) Response.Redirect("ReturnNoPoints.aspx");
        else if (this.LeftBar.Items[9].Selected) Response.Redirect("UpdateBook.aspx");
        else if (this.LeftBar.Items[10].Selected) Response.Redirect("UpdateStudent.aspx");
    }


    protected void DelStd_ReadData_Click(object sender, EventArgs e)
    {
        DelStd_Status.ForeColor = System.Drawing.Color.Black;
        try
        {
            List<Student> AllStudents = MySQL.SelectStudents("SELECT * FROM STUDENTS");
            bool Find = false;
            foreach (Student student in AllStudents)
            {
                if (student.ID == DelStd_StdIDtxt.Text)
                {
                    DelStd_Nametxt.Text = student.Name;
                    DelStd_Classtxt.Text = student.Class;
                    Find = true;
                    break;
                }
            }

            if (Find) DelStd_Status.Text = "查詢成功";
            else
            {
                DelStd_Classtxt.Text = "";
                DelStd_Nametxt.Text = "";
                DelStd_Status.ForeColor = System.Drawing.Color.Red;
                DelStd_Status.Text = "沒有此學生資料";
            } 
        }
        catch(Exception error)
        {
            DelStd_Status.ForeColor = System.Drawing.Color.Red;
            DelStd_Status.Text = "資料格式錯誤，查詢失敗";
        }
    }
    
    protected void DelStd_Delete_Click(object sender, EventArgs e)
    {
        DelStd_Status.ForeColor = System.Drawing.Color.Black;
        try
        {
            if ((DelStd_Nametxt.Text.Length != 0) && (DelStd_StdIDtxt.Text.Length != 0) && (DelStd_Classtxt.Text.Length != 0))
            {
                MySQL.Delete(string.Format("DELETE FROM STUDENTS WHERE ID = '{0}'", DelStd_StdIDtxt.Text));
                
                MySQL.Delete(string.Format("DELETE FROM HISTORY_RECORD WHERE StdID = '{0}'", DelStd_StdIDtxt.Text));
                DelStd_Nametxt.Text = "";
                DelStd_StdIDtxt.Text = "";
                DelStd_Classtxt.Text = "";
                DelStd_Status.Text = "刪除完成";
            }
            else
            {
                DelStd_Status.ForeColor = System.Drawing.Color.Red;
                DelStd_Status.Text = "請補齊欲刪除學生的資料";
            }
           
        }
        catch (Exception error)
        {
            DelStd_Status.ForeColor = System.Drawing.Color.Red;
            DelStd_Status.Text = "資料格式錯誤，刪除失敗";
        }
    }
}