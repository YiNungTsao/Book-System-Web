using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using MySql.Data.MySqlClient;
using System.IO;


/// <summary>
/// Summary description for Foundation
/// </summary>
/// 

namespace Foundation
{
    public struct Student
    {
        public string Name;
        public string ID;
        public string Class;
        public string Points;
    }

    public struct Book
    {
        public string Name;
        public string ID;
        public string Period;
        public string Points;
    }

    public struct Current
    {
        public string StdName;
        public string StdID;
        public string Class;
        public string BookName;
        public string BookID;
        public string StartTime;
        public string Period;
        public string Points;
    }

    public enum Information
    {
        Personal, Class, StartTime, InTime, StdName, StdID
    }

    public class MySQL
    {
        /* public static string dbHost = "127.0.0.1";       //資料庫位址
         public static string dbUser = "root";           //資料庫使用者帳號
         public static string dbPass = "123456";         //資料庫使用者密碼
         public static string dbName = "new_schema";           //資料庫名稱*/

        public static string dbHost = "127.0.0.1";       //資料庫位址
        public static string dbUser = "root";           //資料庫使用者帳號
        public static string dbPass = "Alpha_academy123";         //資料庫使用者密碼
        public static string dbName = "new_schema";           //資料庫名稱

       /* public static string dbHost = "192.168.1.141";       //資料庫位址
        public static string dbUser = "root";           //資料庫使用者帳號
        public static string dbPass = "Alpha_academy123";         //資料庫使用者密碼
        public static string dbName = "booksystem";           //資料庫名稱*/

        public static string conString = string.Format("server={0};port=3306;uid={1};password={2};database={3};", dbHost, dbUser, dbPass, dbName);
        public static MySqlConnection conn = new MySqlConnection(conString);
        //MySqlCommand cmd = conn.CreateCommand();

        public static string SelectBookID(string Command)
        {
            string value = "";
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(Command, conn);
                MySqlDataReader read = cmd.ExecuteReader();
                if (read.Read())
                {
                    value = read.GetString(0);
                }
                conn.Close();
            }
            catch
            {
                conn.Close();
            }
            return value;
        }

        public static string Select(string Command, Information information)
        {
            string value = "";
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(Command, conn);
                MySqlDataReader read = cmd.ExecuteReader();

                switch (information)
                {
                    case Information.StartTime:
                        while (read.Read())
                        {
                            value = read.GetString(5);
                            Console.WriteLine(value);
                        }
                        conn.Close();
                        Console.WriteLine("successfully");
                        break;
                    case Information.InTime:
                        while (read.Read())
                        {
                            value = read.GetString(9);
                            Console.WriteLine(value);
                        }
                        conn.Close();
                        Console.WriteLine("successfully");
                        break;
                    case Information.StdName:
                        while (read.Read())
                        {
                            value = read.GetString(0);
                            Console.WriteLine(value);
                        }
                        conn.Close();
                        Console.WriteLine("successfully");
                        break;
                    case Information.StdID:
                        while (read.Read())
                        {
                            value = read.GetString(1);
                            Console.WriteLine(value);
                        }
                        conn.Close();
                        Console.WriteLine("successfully");
                        break;
                    case Information.Class:
                        while (read.Read())
                        {
                            value = read.GetString(2);
                            Console.WriteLine(value);
                        }
                        conn.Close();
                        Console.WriteLine("successfully");
                        break;
                }
            }
            catch (Exception e)
            {
                conn.Close();
                Console.WriteLine(e);
            }
            return value;
        }

        public static List<Student> SelectStudents(string Command)
        {
            List<Student> AllStudents = new List<Student>();
            Student student = new Student();
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(Command, conn);
                MySqlDataReader read = cmd.ExecuteReader();

                while (read.Read())
                {
                    student.Name = read.GetString(0);
                    student.ID = read.GetString(1);
                    student.Class = read.GetString(2);

                    AllStudents.Add(student);
                }
                conn.Close();
                Console.WriteLine("successfully");
            }
            catch (Exception e)
            {
                conn.Close();
                Console.WriteLine(e);
            }
            return AllStudents;
        }

        public static Student SelectStudent(string Command)
        {
            Student student = new Student();

            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(Command, conn);
                MySqlDataReader read = cmd.ExecuteReader();

                while (read.Read())
                {
                    student.Name = read.GetString(0);
                    student.ID = read.GetString(1);
                    student.Class = read.GetString(2);
                }
                conn.Close();
                Console.WriteLine("successfully");
            }
            catch (Exception e)
            {
                conn.Close();
                Console.WriteLine(e);
            }
            return student;
        }
        public static List<Book> SelectBooks(string Command)
        {
            List<Book> AllBooks = new List<Book>();
            Book book = new Book();
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(Command, conn);
                MySqlDataReader read = cmd.ExecuteReader();

                while (read.Read())
                {
                    book.Name = read.GetString(0);
                    book.ID = read.GetString(1);
                    book.Period = read.GetString(2);
                    book.Points = read.GetString(3);

                    AllBooks.Add(book);
                }
                conn.Close();
                Console.WriteLine("successfully");
            }
            catch (Exception e)
            {
                conn.Close();
                Console.WriteLine(e);
            }
            return AllBooks;
        }

        public static Book SelectBook(string Command)
        {
            Book book = new Book();

            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(Command, conn);
                MySqlDataReader read = cmd.ExecuteReader();

                while (read.Read())
                {
                    book.Name = read.GetString(0);
                    book.ID = read.GetString(1);
                    book.Period = read.GetString(2);
                    book.Points = read.GetString(3);
                }
                conn.Close();
                Console.WriteLine("successfully");
            }
            catch (Exception e)
            {
                conn.Close();
                Console.WriteLine(e);
            }
            return book;
        }

        public static string Available(string Command)
        {
            string available = "";
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(Command, conn);
                MySqlDataReader read = cmd.ExecuteReader();

                while (read.Read())
                {
                    available = read.GetString(0);
                }
                conn.Close();
                Console.WriteLine("successfully");
            }
            catch (Exception e)
            {
                conn.Close();
                Console.WriteLine(e);
            }
            return available;
        }

        public static List<Current> Current_Record(string Command)
        {
            List<Current> Allcurrent = new List<Current>();
            Current current = new Current();
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(Command, conn);
                MySqlDataReader read = cmd.ExecuteReader();

                while (read.Read())
                {
                    current.StdName = read.GetString(0);
                    current.StdID = read.GetString(1);
                    current.Class = read.GetString(2);
                    current.BookName = read.GetString(3);
                    current.BookID = read.GetString(4);
                    current.StartTime = read.GetString(5);
                    current.Period = read.GetString(6);
                    current.Points = read.GetString(7);

                    Allcurrent.Add(current);
                }
                conn.Close();
                Console.WriteLine("successfully");
            }
            catch (Exception e)
            {
                conn.Close();
                Console.WriteLine(e);
            }
            return Allcurrent;
        }

        public static Dictionary<string, List<string>> SelectCurrent(string Command)
        {
            Dictionary<string, List<string>> dic_Current = new Dictionary<string, List<string>>();
            string key = "";
            List<string> value = new List<string>();

            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(Command, conn);
                MySqlDataReader read = cmd.ExecuteReader();

                while (read.Read())
                {
                    lock (dic_Current)
                    {
                        key = read.GetString(1);
                        if (dic_Current.ContainsKey(key))
                        {
                            value.Add(read.GetString(3));
                            dic_Current[key] = value;
                        }
                        else
                        {
                            value = new List<string>();
                            value.Add(read.GetString(3));
                            dic_Current.Add(key, value);
                        }
                    }
                }
                conn.Close();
            }
            catch (Exception e)
            {
                conn.Close();
                Console.WriteLine(e);
            }
            return dic_Current;
        }

        public static Dictionary<string, Tuple<List<string>, List<string>, List<string>, List<string>>> SelectHistory(string Command, Information information)
        {
            Dictionary<string, Tuple<List<string>, List<string>, List<string>, List<string>>> dic_History = new Dictionary<string, Tuple<List<string>, List<string>, List<string>, List<string>>>();
            string key = "";
            List<string> StartTime = new List<string>();
            List<string> EndTime = new List<string>();
            List<string> value = new List<string>();
            List<string> BookID = new List<string>();

            switch (information)
            {
                //key: ID  Value: BookName StartTime EndTime
                case Information.Personal:
                    try
                    {
                        conn.Open();
                        MySqlCommand cmd = new MySqlCommand(Command, conn);
                        MySqlDataReader read = cmd.ExecuteReader();

                        while (read.Read())
                        {
                            key = read.GetString(1);
                            if (dic_History.ContainsKey(key))
                            {
                                value.Add(read.GetString(3));
                                BookID.Add(read.GetString(4));
                                StartTime.Add(read.GetString(5));
                                EndTime.Add(read.GetString(8));

                                dic_History[key] = Tuple.Create(value, StartTime, EndTime, BookID);
                            }
                            else
                            {
                                StartTime = new List<string>();
                                EndTime = new List<string>();
                                value = new List<string>();
                                BookID = new List<string>();

                                value.Add(read.GetString(3));
                                BookID.Add(read.GetString(4));
                                StartTime.Add(read.GetString(5));
                                EndTime.Add(read.GetString(8));

                                dic_History.Add(key, Tuple.Create(value, StartTime, EndTime, BookID));
                            }
                        }
                        conn.Close();
                    }
                    catch (Exception e)
                    {
                        conn.Close();
                        Console.WriteLine(e);
                    }
                    break;

                //Key Class Value: StdName StartTime EndTime
                case Information.Class:
                    try
                    {
                        conn.Open();
                        MySqlCommand cmd = new MySqlCommand(Command, conn);
                        MySqlDataReader read = cmd.ExecuteReader();

                        while (read.Read())
                        {
                            key = read.GetString(2);
                            if (dic_History.ContainsKey(key))
                            {
                                value.Add(read.GetString(0));
                                StartTime.Add(read.GetString(8));
                                EndTime.Add(read.GetString(7));

                                dic_History[key] = Tuple.Create(value, StartTime, EndTime, BookID);
                            }
                            else
                            {
                                value = new List<string>();
                                StartTime = new List<string>();
                                EndTime = new List<string>();

                                value.Add(read.GetString(0));
                                StartTime.Add(read.GetString(8));
                                EndTime.Add(read.GetString(7));

                                dic_History.Add(key, Tuple.Create(value, StartTime, EndTime, BookID));
                            }
                        }
                        conn.Close();
                    }
                    catch (Exception e)
                    {
                        conn.Close();
                        Console.WriteLine(e);
                    }
                    break;
            }
            return dic_History;
        }

        public static void Insert(string Command)
        {
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(Command, conn);
                MySqlDataReader read = cmd.ExecuteReader();
                conn.Close();
            }
            catch
            {
                conn.Close();
            }
        }

        public static void Delete(string Command)
        {
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(Command, conn);
                cmd.ExecuteReader();
                conn.Close();
            }
            catch
            {
                conn.Close();
            }
        }

        public static void Update(string Command)
        {
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(Command, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch
            {
                conn.Close();
            }
        }
    }
    public class Foundation
    {
        public static DataTable Add_Columns(DataTable dt, List<string> Column_Name)
        {
            foreach (string Column in Column_Name)
            {
                dt.Columns.Add(Column);
            }
            return dt;
        }
    }

}