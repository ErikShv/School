﻿using DatabaseProject.Models;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace DatabaseProject
{
    //המחלקה מכילה פעולות המאפשרות לטפל במסד הנתונים
    public static class Server
    {
        private static string dbPath = ApplicationData.Current.LocalFolder.Path; //נתיב מסד הנתונים במחשב
        private static string connectionString = "Filename=" + dbPath + "\\MyDatabase.db";//הנתיב שדרכו התכנית מתחברת למסד הנתונים
        

        public static GameUser AddNewUser(string name,string password,string mail)
        {
            int? userId = ValidateUser(name, password); //בדיקה אם המשתמש כבר נמצא במאגר
            if(userId != null)//המשתמש קיים-לשלוח להתחברות במקום הרשמה
            {
                return null;
            }
            //אם המשכנו, זאת אומרת המשתמש בעל הנתונים שהזין לא נמצא במאגר
            //מוסיפים את נתוניו האישיים של המשתמש שהזין לטבלת User
            string query = $"INSERT INTO [User] (UserName,UserPassword,Email) VALUES ('{name}','{password}','{mail}')";
            Execute(query); 
            userId = ValidateUser(name, password);//קבלת UserId של המשתמש לאחר הוספתו לטבלת User

            AddGameData(userId.Value); //הוספת ברירת מחדל
            AddUserProduct(userId.Value);
            return GetUser(userId.Value);
        }
        /*
         הפעולה בודקת אם המשתמש הזין נתונים נכונים ונמצא במאגר המשתמשים אם הכל תקין,
        הפעולה מחזירה UserId של המשתמש אם נתונים אינם תקינים הפעולה מחזירה ערך null
        */
        private static int? ValidateUser(string name, string password)
        {
            string query = $"SELECT UserId FROM [User] WHERE UserName='{name}' AND UserPassword='{password}'";
            using(SqliteConnection connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                SqliteCommand command = new SqliteCommand(query, connection);
                SqliteDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    return reader.GetInt32(0);
                }
                return null;
            }
        }
    }
}