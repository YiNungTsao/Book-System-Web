using Foundation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.LeftBar.Items[4].Selected = true ;
        if (this.LeftBar.Items[0].Selected) Response.Redirect("Lend.aspx");
        else if (this.LeftBar.Items[1].Selected) Response.Redirect("Return.aspx");
        else if (this.LeftBar.Items[2].Selected) Response.Redirect("NotReturn.aspx");
        else if (this.LeftBar.Items[3].Selected) Response.Redirect("PersonalRecord.aspx");
        else if (this.LeftBar.Items[5].Selected) Response.Redirect("AddStudents.aspx");
        else if (this.LeftBar.Items[6].Selected) Response.Redirect("AddBooks.aspx");
        else if (this.LeftBar.Items[7].Selected) Response.Redirect("DelStudent.aspx");
        else if (this.LeftBar.Items[8].Selected) Response.Redirect("ReturnNoPoints.aspx");
        else if (this.LeftBar.Items[9].Selected) Response.Redirect("UpdateBook.aspx");
        else if (this.LeftBar.Items[10].Selected) Response.Redirect("UpdateStudent.aspx");
    }

    protected void ClassRecord_show_Click(object sender, EventArgs e)
    {
        ClassRecord_View.DataSource = "";
        ClassRecord_View.DataBind();
        ClassRecord_Status.Text = "";

        ClassRecord_Status.ForeColor = System.Drawing.Color.Black;

        System.IO.FileStream fs = new System.IO.FileStream(string.Format(@"C:\Record\{0}-{1}.csv", ClassRecord_Classtxt.Text, ClassRecord_Monthytxt.Text), System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.Write);
        System.IO.StreamWriter sw = new System.IO.StreamWriter(fs, Encoding.Default);
        //設定欄位名稱
        sw.WriteLine("姓名" + "," + "點數");
        try
        {
            List<Student> AllStudents = MySQL.SelectStudents(string.Format("SELECT * FROM STUDENTS WHERE CLASS = '{0}'",ClassRecord_Classtxt.Text));
            List<Book> AllBooks = MySQL.SelectBooks("SELECT * FROM BOOKS");
            //還書
            Dictionary<string, List<string>> Personal_currRecord = MySQL.SelectCurrent("SELECT * FROM CURRENT_RECORD");

            //歷史紀錄
            Dictionary<string, Tuple<List<string>, List<string>, List<string>, List<string>>> Class_historyRecord = MySQL.SelectHistory(string.Format("SELECT * FROM history_RECORD where class = '{0}'",ClassRecord_Classtxt.Text), Information.Class);
            Dictionary<string, Tuple<List<string>, List<string>, List<string>, List<string>>> Personal_historyRecord = MySQL.SelectHistory("SELECT * FROM History_RECORD", Information.Personal);

            try
            {
                //Name,  EndTime, Points
                Tuple<List<string>, List<string>, List<string>, List<string>> value;
                Class_historyRecord.TryGetValue(ClassRecord_Classtxt.Text, out value);

                //宣告 Dictionary<string, int> key: StdName value: Points
                Dictionary<string, double> dic_Points = new Dictionary<string, double>();

                //判斷是否為指定月份 (以 EndTime 決定) 並加總點數
                string[] arr_StartTime;
                for (int item = 0; item < value.Item3.Count; item++)
                {
                    arr_StartTime = value.Item2[item].Split('/');
                    if (ClassRecord_Monthytxt.Text == arr_StartTime[1])
                    {
                        if (dic_Points.ContainsKey(value.Item1[item]))
                            dic_Points[value.Item1[item]] = dic_Points[value.Item1[item]] + Convert.ToDouble(value.Item3[item]);
                        else
                        {
                            dic_Points.Add(value.Item1[item], Convert.ToDouble(value.Item3[item]));
                        }
                    }
                }
                DataTable dt = new DataTable();
                List<string> ColumnName = new List<string> { "姓名", "點數" };
                dt = Foundation.Foundation.Add_Columns(dt, ColumnName);
                List<string> PointedStudents = new List<string>();
                if (dic_Points.Count > 0)
                {
                    //顯示在GridView中
                    foreach (var key in dic_Points.Keys)
                    {
                        DataRow dr = dt.NewRow();
                        double points;
                        dic_Points.TryGetValue(key, out points);
                        dr[0] = key;
                        dr[1] = points;
                        dt.Rows.Add(dr);

                        sw.WriteLine(key + ',' + points);
                        PointedStudents.Add(key);
                    }
                    foreach (var std in AllStudents)
                    { 
                        if (!PointedStudents.Contains(std.Name))
                        {
                            DataRow dr = dt.NewRow();
                            dr[0] = std.Name;
                            dr[1] = 0;
                            dt.Rows.Add(dr);
                            sw.WriteLine(string.Format("{0},{1}",std.Name,0));
                        }
                    }


                    sw.Close();
                    //Response.Write("輸出完成");
                    ClassRecord_View.DataSource = dt;
                    ClassRecord_View.DataBind();
                    ClassRecord_Status.Text = string.Format("{0}在{1}月的相關紀錄", ClassRecord_Classtxt.Text, ClassRecord_Monthytxt.Text);
                    //Response.Write("查詢完成");
                }
                else
                {
                    sw.Close();
                    ClassRecord_Status.ForeColor = System.Drawing.Color.Red;
                    ClassRecord_Status.Text = string.Format("沒有此班級在{0}月的相關紀錄", ClassRecord_Monthytxt.Text);
                }
            }
            catch (Exception error)
            {
                sw.Close();
                ClassRecord_Status.ForeColor = System.Drawing.Color.Red;
                ClassRecord_Status.Text = "沒有此班級的相關資訊";
            }
        }
        catch (Exception error)
        {
            sw.Close();
            //Console.WriteLine(error);
            ClassRecord_Status.ForeColor = System.Drawing.Color.Red;
            ClassRecord_Status.Text = "資料格式錯誤，查詢失敗";
            //Response.Write("查詢失敗");
        }
    }
}