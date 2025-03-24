using DatabaseProject.Models;
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


        public static GameUser AddNewUser(string name, string password, string mail)
        {
            int? userId = ValidateUser(name, password); //בדיקה אם המשתמש כבר נמצא במאגר
            if (userId != null)//המשתמש קיים-לשלוח להתחברות במקום הרשמה
            {
                return null;
            }
            //אם המשכנו, זאת אומרת המשתמש בעל הנתונים שהזין לא נמצא במאגר
            //מוסיפים את נתוניו האישיים של המשתמש שהזין לטבלת User
            string query = $"INSERT INTO [User] (UserName,UserPassword,Email) VALUES ('{name}','{password}','{mail}')";
            Execute(query);
            userId = ValidateUser(name, password);//קבלת UserId של המשתמש לאחר הוספתו לטבלת User
            query = $"INSERT INTO [GameData] (UserId,CurrentLevelId,CurrentPowerupId,MaxLvlId,Souls,Coins) VALUES ('{userId}','{1}','{1}','{1}','{0}','{0}')";
            Execute(query);
            query = $"INSERT INTO [Storage] (UserId,PowerUpId) VALUES ('{userId}','{1}')";
            Execute(query);
            //AddGameData(userId.Value); //הוספת ברירת מחדל
            //AddUserProduct(userId.Value);
            return GetUser(userId.Value);
        }
        /*
         הפעולה בודקת אם המשתמש הזין נתונים נכונים ונמצא במאגר המשתמשים אם הכל תקין,
        הפעולה מחזירה UserId של המשתמש אם נתונים אינם תקינים הפעולה מחזירה ערך null
        */
        public static int? ValidateUser(string name, string password)
        {
            string query = $"SELECT Id FROM [User] WHERE UserName='{name}' AND UserPassword='{password}'";
            using (SqliteConnection connection = new SqliteConnection(connectionString))
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
        // הפעולה מבצעת שאילתה
        private static void Execute(string query)
        {
            using (SqliteConnection connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                SqliteCommand command = new SqliteCommand(query, connection);
                command.ExecuteNonQuery();
            }
        }
        /// <summary>
        /// משיג את הססמא של המשתמש מהטבלה
        /// </summary>
        public static string GetPass(string Mail)
        {
            string query = $"SELECT UserPassword FROM [User] WHERE Email ='{Mail}'";

            using (SqliteConnection connection = new SqliteConnection(connectionString))
            {
                GameUser user = null;
                connection.Open();
                SqliteCommand command = new SqliteCommand(query, connection);
                SqliteDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {

                    reader.Read();
                    user = new GameUser
                    {
                        
                        UserPassword = reader.GetString(0)

                    };
                    return user.UserPassword;
                }
                else
                {
                    return null;
                }
            }
            
        }
        /*
         הפעולה מחזירה משתמש אשר כל שדותיו מלאים
         הפעולה אוספת נתונים מ- 4 טבלאות וממלאה באמצעותם את המשתמש 
         ולוקחת משם User כדי שיוכל לגשת למשחק. בשלב התחלתי הפעולה ניגשת לטבלת
         של המשתמש Id,Name,Mail
         הממשיכה למלא את נתוני המשתמש,SetUser לאחר מכן הפעולה נעזרת בפעולת עזר 
         */
        public static GameUser GetUser(int userId)
        {
            GameUser user = null;
            string query = $"SELECT Id, UserName, UserPassword, Email FROM [User] WHERE Id ={userId}";
            using (SqliteConnection connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                SqliteCommand command = new SqliteCommand(query, connection);
                SqliteDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    user = new GameUser
                    {
                        UserId = reader.GetInt32(0),
                        UserName = reader.GetString(1),
                        UserPassword = reader.GetString(2),
                        UserEmail = reader.GetString(3)

                    };
                }
            }
            if (user != null)
            {
                SetUser(user);
            }
            return user;
        }
        /*
 הפעולה ממשיכה למלא את שדותיו של המשתמש. בשלב הראשון
 MaxLevel,Money,CurrentLevelId,CurrentProductId :ושולפת משם את נתוני המשחק של המשתמש GameData היא ניגשת לטבלת 
 נכנסים וממלאים משתמש MaxLevel,Money ,כמו כן 
 במשתמש CurrentLevel -על מנת למלא את ה Level ניגשים לטבלת CurrentLevelId לאחר מכן באמצעות 
 SetCurrentLevel על זה תהיה אחראית פעולת עזר  
 GameData ששלפנו מהטבלה currentProductId בשלב הבא בעזרת 
 אשר השחקן שיחק בפעם האחרונה Feature -כדי לשלוף ממנה את השם ה Product ניגשים לטבלה 
 SetCurrentProduct על זה תהיה אחראית הפעולה .GameUser -הנתון הזה גם יכנס ל
 GameUser לסיכום, באופן מדורג נאספו הנתונים מארבע טבלאות ומילאו את העצם   
 כעת יוכל המשתמש לגשת למשחק
 */
        private static void SetUser(GameUser user)
        {
            int currentLevelId = 0;

            string query = $"SELECT CurrentLevelId, CurrentPowerupId , MaxLvlId, Souls, Coins FROM [GameData] WHERE UserId={user.UserId}";
            using (SqliteConnection connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                SqliteCommand command = new SqliteCommand(query, connection);
                SqliteDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    user.MaxLevel = reader.GetInt32(2);
                    user.Souls = reader.GetInt32(3);
                    currentLevelId = reader.GetInt32(0);
                    user.CurrentPowerUp = reader.GetInt32(1);
                    user.Coins = reader.GetInt32(4);
                }
            }
            SetCurrentLevel(user, currentLevelId);

        }
        /*
 ,שולפת ממנה את נתוני רמת הקושי currentLevelId ולפי Level הפעולה ניגשת לטבלת 
  ומכניסה אותו לתוך המשתמש GameLevel בשלב הבא הפעולה בונה עצם מסוג 
  מפני שנעזר בה בעקבות החלפת רמת הקושי public הדגש: הפעולה
 */
        public static void SetCurrentLevel(GameUser user, int currentLevelId)
        {
            string query = $"SELECT LevelId, LevelNumber, SkeletonHp, ReaprHp, GolemHp, CountSkeleton, CountGolem, CountReaper, CountBoss, CountPlatform, CountMonster FROM [GameLevel] WHERE LevelId={currentLevelId}";
            using (SqliteConnection connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                SqliteCommand command = new SqliteCommand(query, connection);
                SqliteDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    user.CurrentLevel = new GameLevel
                    {
                        LevelId = reader.GetInt32(0),
                        LevelNum = reader.GetInt32(1),
                        SkeletonHp = reader.GetInt32(2),
                        ReaprHp = reader.GetInt32(3),
                        GolemHp = reader.GetInt32(4),
                        CountSkeleton = reader.GetInt32(5),
                        CountGolem = reader.GetInt32(6),
                        CountReaper = reader.GetInt32(7),
                        CountBoss = reader.GetInt32(8),
                        CountPlatform = reader.GetInt32(9),
                        CountMonster = reader.GetInt32(10),
                    };
                }

            }
        }
        /*
        ושולפת ממנה את מספרי המוצרים שנמצאים בבעלותו של השחקן, כלומר Storage0 הפעולה ניגשת לטבלת המחסן
     מספרי המוצרים שהשחקן קנה בעבר.הפעולה מחזירה את רשימת מספרי המוצרים הללו
    משתמשים בפעולה זו כדי למנוע מהשחקן לקנות מוצר שכבר קנה בעבר
    */
   public static List<int> GetOwnProductsId(GameUser gameUser)
        {
            List<int> ownProductsIds = new List<int>();
            string query = $"SELECT PowerUpId FROM [Storage] WHERE UserId={gameUser.UserId}";
            using (SqliteConnection connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                SqliteCommand command = new SqliteCommand(query, connection);
                SqliteDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        ownProductsIds.Add(reader.GetInt32(0));
                    }
                    return ownProductsIds;
                }
                return null;
            }
        }
        /// <summary>
        /// משיג את הנשמות של כל המשתמשים את שמם ואת המספר המזהה שלהם
        /// </summary>
        public static List<Score> GetScores()
        {
            List<Score> ownProductsIds = new List<Score>();

            string query = @" SELECT User.Id AS UserId, User.UserName, GameData.Souls FROM GameData JOIN User ON GameData.UserId = User.Id ORDER BY GameData.Souls DESC;";

            using (SqliteConnection connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                using (SqliteCommand command = new SqliteCommand(query, connection))
                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read()) // Read each row
                    {
                        Score score = new Score
                        {
                            id = reader.GetInt32(0),   
                            name = reader.GetString(1), 
                            souls = reader.GetInt32(2)    
                        };

                        ownProductsIds.Add(score); 
                    }
                }
            }

            return ownProductsIds;
        }
        /// <summary>
        /// שומר את כל המידע של המשתמש כולל שלבים,כסף וכדומה
        /// </summary>
        public static void SaveData(GameUser user)
        {
            string query = $"UPDATE GameData SET  CurrentLevelId = '{user.CurrentLevel.LevelNum}', CurrentPowerupId = '{user.CurrentPowerUp}', MaxLvlId = '{user.MaxLevel}', Souls = '{user.Souls}', Coins = '{user.Coins}' WHERE UserId = {user.UserId}; ";
            using (SqliteConnection connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                SqliteCommand command = new SqliteCommand(query, connection);
                SqliteDataReader reader = command.ExecuteReader();
            }
        }
        /// <summary>
        /// מוסיף מוצר למחסן של המשתמש
        /// </summary>
        public static void AddProduct(GameUser user)
        {
            string query = $"INSERT INTO [Storage] (UserId,PowerUpId) VALUES ('{user.UserId}','{user.CurrentPowerUp}')";
            Execute(query);
        }
    }
}