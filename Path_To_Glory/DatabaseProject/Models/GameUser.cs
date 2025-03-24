using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseProject.Models
{
   public class GameUser
    {
        public int UserId { get; set; } =0; //המספר המזהה של השחקן

        public string UserName { get; set; } = "Anonymous"; //שם השחקן

        public string UserEmail { get; set; } = string.Empty; //אימייל של השחקן

        public string UserPassword { get; set; } = string.Empty; //הססמא של השחקן

        public int Souls { get; set; } = 0; //כמות הנשמות שיש לשחקן(כסף בחנות) ץ

        public int Coins { get; set; } = 0; //הכסף שאסף במשחק

        public int Hp { get; set; } = 3; //כמות החיים שיש לשחקן

        public int MaxLevel { get; set; } = 1;//השלב  המתקדם ביותר שהמשתמש הגיע אליו

        public int CurrentPowerUp { get; set; } = 1; //הכוח המיוחד שיש כרגע לשחקן

        public GameLevel CurrentLevel = new GameLevel();//אם המשתמש לא יזדהה הוא ישחק בשלב בררת מחדל


    }
}
